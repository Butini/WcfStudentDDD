using System;
using System.Collections.Generic;
using System.Text;

namespace WcfStudent.Infrastructure.Repository.Contracts.Generics
{
    public interface IWriteFile<T, U>
    {
        U Add(U obj);
        U Update(U obj);
        U Delete(T value);
    }
}
