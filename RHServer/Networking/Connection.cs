﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net.Security;
using System.IO;

namespace RHServer.Networking
{
    class Connection
    {
        public TcpClient client;
        private NetworkStream stream;
        private ConnectionEventListener handle;
        private ConnectionType type;
        public int message_delta_time;
        public bool connected;
        public String ip_endpoint;

        private bool reading = false, writing = false;
        public Connection(TcpClient c, ConnectionEventListener l)
        {
            this.client = c;
            this.stream = c.GetStream();
            this.handle = l;
            this.message_delta_time = 0;
            this.connected = c.Connected;
            this.ip_endpoint = this.client.Client.RemoteEndPoint.ToString();
        }

        public void update()
        {
            this.message_delta_time++;

            if(this.connected && this.message_delta_time >= 1280)
            {
                this.connected = false;
                this.EndConnection();
                this.handle.onConnectionError(this, new Exception("Connection timed out"));
            }
        }

        public void EndConnection()
        {
            try
            {
                this.client.Close();
                this.client.Dispose();
                this.stream.Dispose();
            } catch(Exception e)
            {
                throw e;
            }
        }

        public void SendData(byte[] data, ushort length)
        {
            if(client.Connected)
            {
                try
                {
                    byte lower = (byte)(length >> 8);
                    byte upper = (byte)(length & 0x00FF);
                    byte[] tosend = new byte[data.Length + 2];
                    tosend[0] = lower;
                    tosend[1] = upper;
                    data.CopyTo(tosend, 2);

                    stream.BeginWrite(tosend, 0, tosend.Length, new AsyncCallback(WriteCallback), this);
                    this.message_delta_time = 0;
                } catch(Exception e)
                {
                    handle.onConnectionError(this, e);
                }
            }
        }

        public void WriteCallback(IAsyncResult result)
        {
            if(result.IsCompleted)
            {
                stream.EndWrite(result);
                stream.Flush();
            }
        }

        public void ReadData()
        {
            if (client.Connected)
            {
                if (!reading)
                {
                    reading = true;
                    try
                    {
                        if (stream.DataAvailable)
                        {
                            stream.ReadTimeout = 2000;
                            byte top = (byte)stream.ReadByte();
                            byte lower = (byte)stream.ReadByte();
                            ushort value = (ushort)(lower + (top << 8));

                            byte[] data = new byte[value];

                            stream.BeginRead(data, 0, value, new AsyncCallback(ReadCallback), this);
                            handle.onDataReceived(this, data, value);
                            this.message_delta_time = 0;
                        }
                    }
                    catch (Exception e)
                    {
                        handle.onConnectionError(this, e);
                    }
                }
                reading = false;
            }
        }

        public void ReadCallback(IAsyncResult result)
        {
            if(result.IsCompleted)
            {
                stream.EndRead(result);
            }
        }
    }

    interface ConnectionEventListener
    {
        void onConnectionError(Connection c, Exception e);
        void onDataReceived(Connection c, byte[] data, ushort length);
    }
}
