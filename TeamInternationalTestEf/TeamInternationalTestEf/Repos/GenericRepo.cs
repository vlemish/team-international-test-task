using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TeamInternationalTestEf.Repos
{
    public class GenericRepo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        protected DbContext _context;

        protected DbSet<TEntity> _table;


        public GenericRepo()
        {

        }

        public GenericRepo(DbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }


        public virtual void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            _table.Add(entity);
            SaveChanges();
        }

        public virtual void AddRange(TEntity[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            _table.AddRange(entities);
            SaveChanges();
        }

        public virtual TEntity[] GetAll()
        {
            return _table.Select(e => e).ToArray();
        }

        public virtual TEntity GetOneById(int id)
        {
            return _table.Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            var dbEntity = _table.Where(e => e.Equals(entity)).FirstOrDefault();
            if (dbEntity == null)
            {
                throw new NullReferenceException("There is no such entity in the DB!");
            }

            _table.Remove(dbEntity);
            SaveChanges();
        }

        public virtual void RemoveRange(TEntity[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            _table.RemoveRange(entities);
            SaveChanges();
        }

        public virtual bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // log exception or do other actions to handle the error...

                throw;
            }
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            var dbEntity = _table.Where(e => e.Equals(entity)).FirstOrDefault();
            if (dbEntity == null)
            {
                throw new NullReferenceException("There is no such entity in the DB!");
            }

            _context.Entry(entity).State = EntityState.Modified;

            SaveChanges();
        }

        public virtual void UpdateRange(TEntity[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            _table.UpdateRange(entities);
            SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
