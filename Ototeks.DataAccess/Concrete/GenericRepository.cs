using Microsoft.EntityFrameworkCore;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ototeks.DataAccess.Concrete
{
    // Implements IGenericRepository for any entity type T.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // Database connection through the DbContext
        private readonly OtoteksContext _context;
        // The DbSet representing the table for entity type T
        private readonly DbSet<T> _dbSet;

        public GenericRepository()
        {
            _context = new OtoteksContext();
            _dbSet = _context.Set<T>();
        }

        // ADD
        public void Add(T entity)
        {

            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        // UPDATE
        public void Update(T entity)
        {
            // Clear all tracked entities to avoid conflicts with the incoming entity
            _context.ChangeTracker.Clear();

            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        // DELETE
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        // LIST ALL (SELECT * FROM ...)
        public List<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includeProperties)
        {
            var query = PrepareQuery(filter,includeProperties);

            query = query.AsNoTracking();

            return query.ToList();
        }

        // FIND BY ID
        public T GetById(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(e => EF.Property<int>(e, GetPrimaryKeyName()) == id);
        }

        public T GetById(Expression<Func<T, bool>> filter, params string[] includeProperties)
        {
            var query = PrepareQuery(filter,includeProperties);

            query = query.AsNoTracking();

            return query.FirstOrDefault();
        }

        // --- HELPER METHODS ---
        private IQueryable<T> PrepareQuery(Expression<Func<T, bool>> filter, params string[] includeProperties)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query;
        }

        // Dynamically resolve the primary key property name for entity type T
        private string GetPrimaryKeyName()
        {
            var entityType = _context.Model.FindEntityType(typeof(T));
            var primaryKey = entityType.FindPrimaryKey();
            return primaryKey.Properties.First().Name;
        }
    }
}
