using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ThursdayMarket.DataAccess.IRepository
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T Get(Expression<Func<T,bool>> filter);
        public void Add(T item);
        public void Remove(T entity);
        void DeleteRange(IEnumerable<T> item);
    }
}
