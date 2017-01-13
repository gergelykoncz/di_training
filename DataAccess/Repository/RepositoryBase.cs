using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T: IEntity
    {
        private List<T> _inner = new List<T>();

        protected abstract IEnumerable<T> fillData();

        public RepositoryBase()
        {
            this._inner.AddRange(this.fillData());
        }

        public virtual void Add(T entity)
        {
            this._inner.Add(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this._inner.AsReadOnly();
        }

        public virtual IEnumerable<T> GetByCriteria(Func<T, bool> criteria)
        {
            return this._inner.Where(criteria);
        }

        public virtual T GetOne(Func<T, bool> predicate)
        {
            return this._inner.SingleOrDefault(predicate);
        }
    }
}
