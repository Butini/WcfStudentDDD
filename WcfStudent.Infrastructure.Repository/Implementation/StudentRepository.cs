using System;
using System.Collections.Generic;
using System.Text;
using WcfStudent.Domain.Entity;
using WcfStudent.Domain.StudentMain.Contracts.Repository;
using WcfStudent.Infrastructure.Utils.Contracts;

namespace WcfStudent.Infrastructure.Repository.Implementation
{
    public class StudentRepository : IStudentRepository<Student>
    {
        private readonly ISerilace<Student> _serilace;

        public StudentRepository(ISerilace<Student> serilace)
        {
            this._serilace = serilace;
        }
        public Student Add(Student student, FileManager fileManager)
        {
            _serilace.Serilace(student, fileManager.path);
            return student;
        }
    }
}
