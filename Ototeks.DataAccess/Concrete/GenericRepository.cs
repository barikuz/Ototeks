using Microsoft.EntityFrameworkCore;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities; // Tabloları tanıması için
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ototeks.DataAccess.Concrete
{
    // Bu sınıf, IGenericRepository'deki kuralları T tipi için uygular.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // 1. Veritabanı bağlantımızı (Context) çağıralım
        // OtoteksContext sınıfı veritabanına açılan kapıdır.
        private readonly OtoteksContext _context;
        // Tablonun Kendisi
        private readonly DbSet<T> _dbSet;

        public GenericRepository()
        {
            _context = new OtoteksContext();
            _dbSet = _context.Set<T>();
        }

        // EKLEME İŞLEMİ
        public void Add(T entity)
        {

            _dbSet.Add(entity);
            _context.SaveChanges(); // Veritabanına kaydet
        }

        // GÜNCELLEME İŞLEMİ
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        // SİLME İŞLEMİ
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        // LİSTELEME İŞLEMİ (SELECT * FROM ...)
        public List<T> GetAll()
        {
            // _context.Set<T>() demek: "Bana gelen T neyse (Mesela Orders), git o tabloya bağlan"
            // Set<T>() o tablonun tamamını temsil eder. ToList() veriyi çeker.
            return _context.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null, params string[] includeProperties)
        {
            var query = PrepareQuery(filter,includeProperties);

            // Listeye çevirip dön
            return query.ToList();
        }

        // ID İLE BULMA İŞLEMİ
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetById(Expression<Func<T, bool>> filter, params string[] includeProperties)
        {
            // Ortak metodu çağır (Include'ları hallet)
            var query = PrepareQuery(filter,includeProperties);

            return query.FirstOrDefault();
        }

        // --- YARDIMCI METOT ---
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
    }
}