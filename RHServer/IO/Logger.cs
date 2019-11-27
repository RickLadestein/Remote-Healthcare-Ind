using System;
using System.Collections.Generic;
using System.Text;
using RHServer.Networking;

namespace RHServer.IO
{
    class Logger
    {
        public enum LOGMODE
        {
            ALL = 0x00,
            LIMITED = 0x01,
            NONE = 0x02
        }

        private static LOGMODE logmode = LOGMODE.NONE;

        public static void SetLogMode(LOGMODE mode)
        {
            logmode = mode;
        }
        public static void LogReceiveMessage(string message)
        {
            if(logmode == LOGMODE.ALL)
            {
                Console.WriteLine($"[{GetTimeStamp()}][Server <-- Client]: {message}");
            } else if(logmode == LOGMODE.LIMITED)
            {
                if(message != DataPackages.Message_Alive())
                {
                    Console.WriteLine($"[{GetTimeStamp()}][Server <-- Client]: {message}");
                }
            }

        }

        public static void LogSendMessage(string message)
        {
            if (logmode == LOGMODE.ALL)
            {
                Console.WriteLine($"[{GetTimeStamp()}][Server --> Client]: {message}");
            }
            else if (logmode == LOGMODE.LIMITED)
            {
                if (message != DataPackages.Message_Alive())
                {
                    Console.WriteLine($"[{GetTimeStamp()}][Server --> Client]: {message}");
                }
            }
        }

        private static String GetTimeStamp()
        {
            return string.Format("{0:HH:mm:ss}", DateTime.Now);
        }
    }
}
