using DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T: IEntity
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        T GetOne(Func<T, bool> predicate);
        IEnumerable<T> GetByCriteria(Func<T, bool> criteria);
        void Update(T entity);
        void Delete(T entity);
    }
}
