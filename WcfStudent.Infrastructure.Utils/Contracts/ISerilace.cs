using System;
using System.Collections.Generic;
using System.Text;

namespace WcfStudent.Infrastructure.Utils.Contracts
{
    public interface ISerilace<TObject>
    {
        void Serilace(TObject obj, string path);
        List<TObject> Deserilace(string path);
    }
}
