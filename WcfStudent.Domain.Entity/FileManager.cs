using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WcfStudent.Domain.Entity
{
    public class FileManager
    {
        public string path { get; set; }

        public FileManager(string FileName)
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;

            path = Path.Combine(directory, FileName);

            if (!File.Exists(path)) CreateFile(path);
        }

        private void CreateFile(string path)
        {
            File.WriteAllText(path, "");
        }
    }


}
