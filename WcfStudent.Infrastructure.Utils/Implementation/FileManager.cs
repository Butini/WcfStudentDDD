using System;
using System.Configuration;
using System.IO;

namespace WcfStudent.Infrastructure.Utils
{
    public class FileManager
    {
        public string GetFile()
        {
            string path;
            string directory = Environment.CurrentDirectory;

            string file = "\\Student.txt";

            path = directory + file;

            if (!File.Exists(path)) CreateFile(path);

            return path;
        }

        private void CreateFile(string path)
        {
            File.WriteAllText(path, "");
        }
    }
}
