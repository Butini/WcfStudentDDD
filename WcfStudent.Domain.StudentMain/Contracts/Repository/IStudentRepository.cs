using System;
using System.Collections.Generic;
using System.Text;
using WcfStudent.Domain.Entity;

namespace WcfStudent.Domain.StudentMain.Contracts.Repository
{
    public interface IStudentRepository <TStudent>
    {
        TStudent Add(TStudent student, FileManager fileManager);
    }
}
