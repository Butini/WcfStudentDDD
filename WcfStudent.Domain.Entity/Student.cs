using System;
using System.Collections.Generic;
using System.Text;

namespace WcfStudent.Domain.Entity
{
    public class Student
    {
        int StudentId { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        int Age { get; set; }
        DateTime Birthday { get; set; }

        public Student()
        {
        }

        public Student(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public Student(int studentId, string name, string surname, int age, DateTime birthday)
        {
            StudentId = studentId;
            Name = name;
            Surname = surname;
            Age = age;
            Birthday = birthday;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   StudentId == student.StudentId &&
                   Name == student.Name &&
                   Surname == student.Surname &&
                   Age == student.Age &&
                   Birthday == student.Birthday;
        }

        public override int GetHashCode()
        {
            int hashCode = -416822847;
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + Birthday.GetHashCode();
            return hashCode;
        }
    }
}
