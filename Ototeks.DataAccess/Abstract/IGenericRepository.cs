using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ototeks.DataAccess.Abstract
{
    // <T> demek: Bana hangi tabloyu (Sınıfı) gönderirsen onun için çalışırım demek.
    // where T : class demek: T yerine sadece bir Class (Tablo) gelebilir, int/string gelemez demek.
    public interface IGenericRepository<T> where T : class
    {
        // Ekleme
        void Add(T entity);

        // Silme
        void Delete(T entity);

        // Güncelleme
        void Update(T entity);

        // Tek bir kayıt getir (ID'ye göre)
        T GetById(int id);

        T GetById(Expression<Func<T, bool>> filter, params string[] includeProperties);

        // Hepsini listele
        List<T> GetAll();

        List<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includeProperties);
    }
}