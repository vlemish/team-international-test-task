using System;
using System.Collections.Generic;
using System.Text;

namespace TeamInternationalTestEf.Repos
{
    interface IRepo<T>
    {
        public T[] GetAll();

        public T GetOneById(int id);

        public void Add(T entity);

        public void Remove(T entity);

        public void Update(T entity);

        public bool SaveChanges();
    }
}
