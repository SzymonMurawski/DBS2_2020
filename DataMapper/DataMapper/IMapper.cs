using System;
using System.Collections.Generic;
using System.Text;

namespace DataMapper
{
    interface IMapper<T>
    {
        T GetById(int id);
        void Save(T t);
        void Delete(T t);
    }
}
