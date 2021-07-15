using System;
using System.Collections.Generic;
using System.Text;

namespace WcfStudent.Domain.StudentMain.Contracts.Repository
{
    public interface IStudentRepository <TStudent>
    {
        TStudent Add(TStudent student);
    }
}
