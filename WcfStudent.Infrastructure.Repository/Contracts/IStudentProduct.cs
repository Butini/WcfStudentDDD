using System;
using System.Collections.Generic;
using System.Text;
using WcfStudent.Domain.Entity;
using WcfStudent.Infrastructure.Repository.Contracts.Generics;

namespace WcfStudent.Infrastructure.Repository.Contracts
{
    public interface IStudentProduct : IReadFile<int, Student>, IWriteFile<int, Student>, ISerialize<Student>
    {
    }
}
