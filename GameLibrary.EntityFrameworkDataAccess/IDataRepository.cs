using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GameLibrary.EntityFrameworkDataAccess
{
    public interface IDataRepository<T>
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        void Create(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }
}
