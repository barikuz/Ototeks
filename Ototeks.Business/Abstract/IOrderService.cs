using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IOrderService
    {
        // Standart İşlemler
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);

        // Listeleme
        List<Order> GetAll();
        Order GetById(int id);
    }
}