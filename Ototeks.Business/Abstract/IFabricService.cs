using Ototeks.Entities;
using System.Collections.Generic;

namespace Ototeks.Business.Abstract
{
    public interface IFabricService
    {
        void Add(Fabric fabric);
        void Update(Fabric fabric);
        void Delete(Fabric fabric);

        List<Fabric> GetAll();
        Fabric GetById(int id);
    }
}
