using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T newRow);
        void Update(T updateRow);
        void Delete(int id);
    }
}
