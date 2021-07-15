using System;
using System.Collections.Generic;
using System.Text;
using WcfStudent.Application.Services.Contracts;

namespace WcfStudent.Application.Services.Implementation
{
    
    public class StudentAppService : IStudentAppService
    {
        public int GetData()
        {
            return Infrastrucuture.GetData();
        }
    }
}
