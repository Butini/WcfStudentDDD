using System;
using System.Collections.Generic;
using System.Text;

namespace WcfStudent.Domain.Entity
{
    public class FileManager
    {
        string Path { get; set; }
        string FileName { get; set; }
        string Extension { get; set; }

        public FileManager()
        {
        }

        public FileManager(string path, string fileName, string extension)
        {
            Path = path;
            FileName = fileName;
            Extension = extension;
        }

        public override bool Equals(object obj)
        {
            return obj is FileManager file &&
                   Path == file.Path &&
                   FileName == file.FileName &&
                   Extension == file.Extension;
        }

        public override int GetHashCode()
        {
            int hashCode = -2071389000;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Path);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FileName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Extension);
            return hashCode;
        }
    }
}
