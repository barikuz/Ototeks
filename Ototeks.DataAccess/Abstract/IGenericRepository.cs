using System.Collections.Generic;

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

        // Hepsini listele
        List<T> GetAll();
    }
}