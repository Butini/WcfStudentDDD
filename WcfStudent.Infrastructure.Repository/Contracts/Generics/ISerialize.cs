using System;
using System.Collections.Generic;
using System.Text;
using WcfStudent.Domain.Entity;

namespace WcfStudent.Infrastructure.Repository.Contracts.Generics
{
    public interface ISerialize<T>
    {
        void Serialize(FileManager fileManager, List<T> list);
        List<T> Deserialize(FileManager fileManager);
    }
}
