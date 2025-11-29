using Ototeks.Business.Abstract;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System;
using System.Collections.Generic;

namespace Ototeks.Business.Concrete
{
    public class FabricManager : IFabricService
    {

        private readonly IGenericRepository<Fabric> _fabricRepo;

        public FabricManager(IGenericRepository<Fabric> fabricRepo)
        {
            _fabricRepo = fabricRepo;
        }

        public void Add(Fabric fabric)
        {
            // Kumaş kodu boşsa ekleme yapma.
            if (string.IsNullOrEmpty(fabric.FabricCode))
            {
                throw new Exception("Kumaş kodu boş olamaz!");
            }

            // Kuralları geçtiyse Repository'e gönder
            _fabricRepo.Add(fabric);
        }

        public void Delete(Fabric fabric)
        {
            _fabricRepo.Delete(fabric);
        }

        public List<Fabric> GetAll()
        {
            return _fabricRepo.GetAll();
        }

        public Fabric GetById(int id)
        {
            return _fabricRepo.GetById(id);
        }

        public void Update(Fabric fabric)
        {
            // Stok eksiye düşerse güncelleme yapma
            if (fabric.StockQuantity < 0)
            {
                throw new Exception("Stok miktarı 0'dan küçük olamaz!");
            }

            _fabricRepo.Update(fabric);
        }
    }
}