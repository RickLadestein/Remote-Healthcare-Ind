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
        public static String GetFileContents(String file, String location)
        {
            try
            {
                String path = Directory.GetCurrentDirectory();
                path = Path.Combine(path, location);
                path = Path.Combine(path, file);
                FileStream file_s = File.Open(path, FileMode.Open);
                StreamReader reader = new StreamReader(file_s);
                string file_contents = reader.ReadToEnd();


                reader.Close();
                file_s.Dispose();
                reader.Dispose();

                return file_contents;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "ERROR";
            }
        }

        public static Boolean DeleteFile(String file_name, String location)
        {
            String path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, location);
            if (File.Exists(Path.Combine(path, file_name)))
            {
                File.Delete(Path.Combine(path, file_name));
                return true;
            }
            return false;
        }

        public static Boolean CreateFile(String file_name, String location)
        {
            String path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, location);
            if (!File.Exists(Path.Combine(path, file_name)))
            {
                File.Create(Path.Combine(path, file_name));
                return true;
            }
            else
                return false;
        }

        public static Boolean WriteFileContents(String file_name, String location, String data)
        {
            String path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, location);
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

        public static List<String> GetFileNames(string folder)
        {
            List<String> output = new List<string>() ;
            String path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, folder);

            string[] data = Directory.GetFiles(path);
            foreach(string s in data)
            {
                String[] files = s.Split("\\");
                output.Add(files[files.Length - 1]);
            }
            return output;  
        }
    }
}
