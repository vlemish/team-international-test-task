using System;

namespace TeamInternationalTestEf.Repos
{
    public interface IRepo<T> : IDisposable
    {
        public T[] GetAll();

        public T GetOneById(int id);

        public void Add(T entity);

        public void AddRange(T[] entities);

        public void Remove(T entity);

        public void RemoveRange(T[] entities);

        public void Update(T entity);

        public void UpdateRange(T[] entities);

        public bool SaveChanges();
    }
}
