using Microsoft.EntityFrameworkCore;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities; // Tabloları tanıması için
using System.Collections.Generic;
using System.Linq;

namespace Ototeks.DataAccess.Concrete
{
    // Bu sınıf, IGenericRepository'deki kuralları T tipi için uygular.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // 1. Veritabanı bağlantımızı (Context) çağıralım
        // OtoteksContext sınıfı veritabanına açılan kapıdır.
        private readonly OtoteksContext _context;

        public GenericRepository()
        {
            _context = new OtoteksContext();
        }

        // EKLEME İŞLEMİ
        public void Add(T entity)
        {

            _context.Set<T>().Add(entity);
            _context.SaveChanges(); // Veritabanına kaydet
        }

        // GÜNCELLEME İŞLEMİ
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        // SİLME İŞLEMİ
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        // LİSTELEME İŞLEMİ (SELECT * FROM ...)
        public List<T> GetAll()
        {
            // _context.Set<T>() demek: "Bana gelen T neyse (Mesela Orders), git o tabloya bağlan"
            // Set<T>() o tablonun tamamını temsil eder. ToList() veriyi çeker.
            return _context.Set<T>().ToList();
        }

        // ID İLE BULMA İŞLEMİ
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id)!;
        }
        
    }
}