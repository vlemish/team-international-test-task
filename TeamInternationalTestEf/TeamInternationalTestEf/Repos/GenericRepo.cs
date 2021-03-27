using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamInternationalTestEf.EF;

namespace TeamInternationalTestEf.Repos
{
    public class GenericRepo<TEntity> : IRepo<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        private readonly DbSet<TEntity> _table;


        public GenericRepo(DbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }


        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            _table.Add(entity);
            SaveChanges();
        }

        public void AddRange(TEntity[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            _table.AddRange(entities);
            SaveChanges();
        }

        public TEntity[] GetAll()
        {
            return _table.Select(e => e).ToArray();
        }

        public TEntity GetOneById(int id)
        {
            return _table.Find(id);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            var dbEntity = _table.Find(entity);
            if (dbEntity == null)
            {
                throw new NullReferenceException("There is no such entity in the DB!");
            }

            _table.Remove(dbEntity);
            SaveChanges();
        }

        public void RemoveRange(TEntity[] entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            _table.RemoveRange(entities);
            SaveChanges();
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // log exception or do other actions to handle the error...

                return false;
            }            
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"Input value can't be null!");
            }

            var dbEntity = _table.Find(entity);
            if (dbEntity == null)
            {
                throw new NullReferenceException("There is no such entity in the DB!");
            }

            _table.Update(entity);
        }

        public void UpdateRange(TEntity[] entities)
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
