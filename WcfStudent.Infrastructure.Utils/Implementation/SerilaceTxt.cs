using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using WcfStudent.Domain.Entity;
using WcfStudent.Infrastructure.Utils.Contracts;

namespace WcfStudent.Infrastructure.Utils.Implementation
{
    class SerilaceTxt : ISerilace<Student>
    {
        public List<Student> Deserilace(string path)
        {
            List<Student> list = new List<Student>();

            using (StreamReader sr = new StreamReader(path))
            {
                string currentLine;

                while ((currentLine = sr.ReadLine()) != null)
                {
                    var splitLine = currentLine.Split(',');

                    int StudentID = int.Parse(splitLine[0], CultureInfo.InvariantCulture);
                    String Name = splitLine[1];
                    String Surname = splitLine[2];
                    DateTime Birthday = DateTime.ParseExact(splitLine[3], "dd-MM-yyyy", CultureInfo.CreateSpecificCulture("es-US"));
                    int Age = int.Parse(splitLine[4], CultureInfo.InvariantCulture);

                    Student student = new Student(StudentID, Name, Surname, Age, Birthday);

                    list.Add(student);
                }
            }

            return list;
        }

        public void Serilace(List<Student> list, string path)
        {
            File.WriteAllText(path, "");

            using (StreamWriter sr = new StreamWriter(path, true))
            {
                foreach (var student in list)
                {
                    string text = TxtFormat(student);
                    sr.WriteLine(text);
                }
            }
        }

        private string TxtFormat(Student student)
        {
            string text = student.StudentId + "," +
            student.Name + "," +
            student.Surname + "," +
            student.Birthday.ToString("dd-MM-yyyy", CultureInfo.CreateSpecificCulture("es")) + "," +
            student.Age;

            return text;
        }
    }
}
