using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ototeks.DataAccess.Abstract
{
    // Generic repository interface: works with any entity class T.
    // "where T : class" ensures only reference types (entity classes) can be used, not value types.
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        // Retrieve a single record by its primary key
        T GetById(int id);

        T GetById(Expression<Func<T, bool>> filter, params string[] includeProperties);

        List<T> GetAll();

        List<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includeProperties);
    }
}
