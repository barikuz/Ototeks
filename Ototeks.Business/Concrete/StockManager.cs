using Ototeks.Business.Abstract;
using Ototeks.DataAccess.Abstract;
using Ototeks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ototeks.Business.Concrete
{
    public class StockManager : IStockService
    {
        private readonly IGenericRepository<Fabric> _fabricRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public StockManager(IGenericRepository<Fabric> fabricRepo, IGenericRepository<ProductType> productTypeRepo)
        {
            _fabricRepo = fabricRepo;
            _productTypeRepo = productTypeRepo;
        }

        public Dictionary<int, decimal> CalculateRequiredFabricAmounts(ICollection<OrderItem> orderItems)
        {
            var fabricRequirements = new Dictionary<int, decimal>();

            foreach (var orderItem in orderItems)
            {
                if (!orderItem.FabricId.HasValue || !orderItem.TypeId.HasValue)
                    continue;

                // Ürün tipinin gerektirdiði kumaþ miktarýný al
                var productType = _productTypeRepo.GetById(orderItem.TypeId.Value);
                if (productType == null) continue;

                decimal requiredAmountPerUnit = productType.RequiredFabricAmount;
                decimal totalRequired = requiredAmountPerUnit * orderItem.Quantity;

                int fabricId = orderItem.FabricId.Value;

                if (fabricRequirements.ContainsKey(fabricId))
                {
                    fabricRequirements[fabricId] += totalRequired;
                }
                else
                {
                    fabricRequirements[fabricId] = totalRequired;
                }
            }

            return fabricRequirements;
        }

        public bool HasSufficientStock(int fabricId, decimal requiredAmount)
        {
            var fabric = _fabricRepo.GetById(fabricId);
            if (fabric == null || !fabric.StockQuantity.HasValue)
                return false;

            return fabric.StockQuantity.Value >= requiredAmount;
        }

        public Dictionary<string, decimal> CheckStockAvailability(ICollection<OrderItem> orderItems)
        {
            var stockInsufficiencies = new Dictionary<string, decimal>();
            var fabricRequirements = CalculateRequiredFabricAmounts(orderItems);

            foreach (var requirement in fabricRequirements)
            {
                int fabricId = requirement.Key;
                decimal requiredAmount = requirement.Value;

                var fabric = _fabricRepo.GetById(fabricId);
                if (fabric == null) continue;

                decimal availableStock = fabric.StockQuantity ?? 0;
                
                if (availableStock < requiredAmount)
                {
                    decimal insufficiency = requiredAmount - availableStock;
                    string fabricDisplayName = $"{fabric.FabricCode} - {fabric.FabricName}";
                    stockInsufficiencies[fabricDisplayName] = insufficiency;
                }
            }

            return stockInsufficiencies;
        }

        public void DeductStockFromFabrics(ICollection<OrderItem> orderItems)
        {
            var fabricRequirements = CalculateRequiredFabricAmounts(orderItems);

            foreach (var requirement in fabricRequirements)
            {
                int fabricId = requirement.Key;
                decimal amountToDeduct = requirement.Value;

                var fabric = _fabricRepo.GetById(fabricId);
                if (fabric == null || !fabric.StockQuantity.HasValue)
                    continue;

                // Stoktan düþ
                fabric.StockQuantity -= amountToDeduct;
                
                // Negatif olmasýný engelle (güvenlik için)
                if (fabric.StockQuantity < 0)
                    fabric.StockQuantity = 0;

                _fabricRepo.Update(fabric);
            }
        }

        public void RestoreStockToFabrics(ICollection<OrderItem> orderItems)
        {
            var fabricRequirements = CalculateRequiredFabricAmounts(orderItems);

            foreach (var requirement in fabricRequirements)
            {
                int fabricId = requirement.Key;
                decimal amountToRestore = requirement.Value;

                var fabric = _fabricRepo.GetById(fabricId);
                if (fabric == null || !fabric.StockQuantity.HasValue)
                    continue;

                // Stoðu geri ekle
                fabric.StockQuantity += amountToRestore;
                _fabricRepo.Update(fabric);
            }
        }
    }
}