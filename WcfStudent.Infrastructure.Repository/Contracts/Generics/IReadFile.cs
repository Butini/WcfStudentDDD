using System;
using System.Collections.Generic;
using System.Text;

namespace WcfStudent.Infrastructure.Repository.Contracts.Generics
{
    public interface IReadFile<T, U>
    {
        U Get(T value);
        List<U> GetAll();
    }
}
