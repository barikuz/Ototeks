using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
    }
}