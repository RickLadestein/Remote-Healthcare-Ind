using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace RHServer.IO
{
    class FileManager
    {
        public static FileManager instance;
        public static FileManager GetInstance()
        {
            if (instance == null)
                instance = new FileManager();
            return instance;
        }

        private FileManager() { }

        public String GetFileContents(String file)
        {
            try
            {
                String path = Directory.GetCurrentDirectory();
                FileStream file_s = File.Open(Path.Combine(path, file), FileMode.Open);
                StreamReader reader = new StreamReader(file_s);
                string file_contents = reader.ReadToEnd();


                reader.Close();
                file_s.Dispose();
                reader.Dispose();

                return file_contents;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }

        public Boolean DeleteFile(String file_name)
        {
            String path = Directory.GetCurrentDirectory();
            if (File.Exists(Path.Combine(path, file_name)))
            {
                File.Delete(Path.Combine(path, file_name));
                return true;
            }
            return false;
        }

        public Boolean CreateFile(String file_name)
        {
            String path = Directory.GetCurrentDirectory();
            if (!File.Exists(Path.Combine(path, file_name)))
            {
                File.Create(Path.Combine(path, file_name));
                return true;
            }
            else
                return false;
        }

        public Boolean WriteFileContents(String file_name, String data)
        {
            String path = Directory.GetCurrentDirectory();
            if (!File.Exists(Path.Combine(path, file_name)))
            {
                try
                {
                    
                    FileStream file = File.Open(Path.Combine(path, file_name), FileMode.CreateNew);
                    StreamWriter writer = new StreamWriter(file);
                    writer.WriteLine(data);

                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                    file.Dispose();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<String> GetFileNames()
        {
            List<String> output = new List<string>() ;
            String path = Directory.GetCurrentDirectory();

            string[] data = Directory.GetFiles(path);
            foreach(string s in data)
            {
                output.Add(s);
            }
            return output;  
        }
    }
}
