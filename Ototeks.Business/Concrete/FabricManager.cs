using FluentValidation.Results;
using Ototeks.Business.Abstract;
using Ototeks.Business.ValidationRules;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            FormatData(fabric);
            CheckValidation(fabric);
            _fabricRepo.Add(fabric);
        }

        public void Delete(Fabric fabric)
        {
            var validator = new FabricValidator(_fabricRepo);
            validator.ValidateForDeletion(fabric);
            _fabricRepo.Delete(fabric);
        }

        public List<Fabric> GetAll()
        {
            return _fabricRepo.GetAll(null, "Color");
        }

        public Fabric GetById(int id)
        {
            return _fabricRepo.GetById(id);
        }

        public void Update(Fabric fabric)
        {
            FormatData(fabric);
            CheckValidation(fabric, fabric.FabricId);
            _fabricRepo.Update(fabric);
        }

        // --- HELPER METHODS ---

        private void CheckValidation(Fabric fabric, int? excludeId = null)
        {
            var validator = new FabricValidator(_fabricRepo, excludeId);
            ValidationResult result = validator.Validate(fabric);

            if (!result.IsValid)
            {
                throw new Exception(result.Errors[0].ErrorMessage);
            }
        }

        private static void FormatData(Fabric fabric)
        {
            fabric.FabricCode = fabric.FabricCode?.Trim().ToUpper();

            fabric.FabricName = fabric.FabricName?.Trim();
        }
    }
}
