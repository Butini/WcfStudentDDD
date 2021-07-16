using System;
using System.Collections.Generic;
using System.Text;
using WcfStudent.Application.Services.Contracts;
using WcfStudent.Domain.Entity;
using WcfStudent.Domain.StudentMain.Contracts.Repository;

namespace WcfStudent.Application.Services.Implementation
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentRepository<Student> _studentRepository;

        public StudentAppService(IStudentRepository<Student> studentRepository)
        {
            this._studentRepository = studentRepository;
        }
    }
}
