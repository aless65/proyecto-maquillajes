using System;
using System.Collections.Generic;
using System.Text;

namespace Maquillaje.DataAccess.Repository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> List();
        public int Insert(T item);
        public int Update(T item);
        public T find(int? id);
        public int Delete(T item);

    }
}
