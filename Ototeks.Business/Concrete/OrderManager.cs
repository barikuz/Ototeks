using FluentValidation.Results;
using Ototeks.Business.Abstract;
using Ototeks.Business.ValidationRules;
using Ototeks.DataAccess.Abstract;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ototeks.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IStockService _stockService;

        public OrderManager(IGenericRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;

            // Initialize StockService
            var fabricRepo = new GenericRepository<Fabric>();
            var productTypeRepo = new GenericRepository<ProductType>();
            _stockService = new StockManager(fabricRepo, productTypeRepo);
        }

        public void Add(Order order)
        {
            MergeDuplicateOrderItems(order);
            CheckValidation(order);
            CheckStockAvailability(order.OrderItems);
            _orderRepo.Add(order);
            _stockService.DeductStockFromFabrics(order.OrderItems);
        }

        public void Update(Order order)
        {
            var existingOrder = _orderRepo.GetById(
                filter: o => o.OrderId == order.OrderId,
                includeProperties: new string[] { "OrderItems" }
            );

            if (existingOrder == null)
                throw new Exception("Order to update was not found!");

            // If only OrderStatus is being updated (OrderItems is null or empty), skip stock operations
            bool isStatusOnlyUpdate = order.OrderItems == null || !order.OrderItems.Any();

            if (!isStatusOnlyUpdate)
            {
                MergeDuplicateOrderItems(order);
                CheckValidation(order, order.OrderId);

                // Restore stock from the previous order before applying changes
                if (existingOrder.OrderItems != null && existingOrder.OrderItems.Any())
                {
                    _stockService.RestoreStockToFabrics(existingOrder.OrderItems);
                }

                // Verify stock availability for the updated order
                CheckStockAvailability(order.OrderItems);
            }

            _orderRepo.Update(order);

            if (!isStatusOnlyUpdate)
            {
                // Deduct stock for the updated order
                _stockService.DeductStockFromFabrics(order.OrderItems);
            }
        }

        public void Delete(Order order)
        {
            var orderWithItems = _orderRepo.GetById(
                filter: o => o.OrderId == order.OrderId,
                includeProperties: new string[] { "OrderItems" }
            );

            if (orderWithItems == null)
                throw new Exception("Order to delete was not found!");

            // Restore stock before deleting the order
            if (orderWithItems.OrderItems != null && orderWithItems.OrderItems.Any())
            {
                _stockService.RestoreStockToFabrics(orderWithItems.OrderItems);
            }

            _orderRepo.Delete(order);
        }

        public List<Order> GetAll()
        {
            return _orderRepo.GetAll(null,
                "Customer",
                "OrderItems",
                "OrderItems.Fabric",
                "OrderItems.Fabric.Color",
                "OrderItems.Type"
            );
        }

        public Order GetById(int id)
        {
            return _orderRepo.GetById(
                filter: o => o.OrderId == id,
                includeProperties: new string[]
                {
                    "Customer",
                    "OrderItems",
                    "OrderItems.Fabric",
                    "OrderItems.Fabric.Color",
                    "OrderItems.Type"
                }
            );
        }

        public Dictionary<string, decimal> CheckOrderStockAvailability(ICollection<OrderItem> orderItems)
        {
            return _stockService.CheckStockAvailability(orderItems);
        }

        public Dictionary<string, decimal> CalculateRequiredFabrics(ICollection<OrderItem> orderItems)
        {
            var fabricRequirements = _stockService.CalculateRequiredFabricAmounts(orderItems);
            var result = new Dictionary<string, decimal>();

            var fabricRepo = new GenericRepository<Fabric>();
            var fabricManager = new FabricManager(fabricRepo);

            foreach (var requirement in fabricRequirements)
            {
                var fabric = fabricManager.GetById(requirement.Key);
                if (fabric != null)
                {
                    string fabricDisplayName = $"{fabric.FabricCode} - {fabric.FabricName}";
                    result[fabricDisplayName] = requirement.Value;
                }
            }

            return result;
        }

        // --- HELPER METHODS ---

        /// <summary>
        /// Merges order items that share the same FabricId and TypeId.
        /// Duplicate items are combined into a single item with their quantities summed.
        /// </summary>
        private void MergeDuplicateOrderItems(Order order)
        {
            if (order.OrderItems == null || !order.OrderItems.Any())
                return;

            var mergedItems = order.OrderItems
                .GroupBy(item => new { item.FabricId, item.TypeId })
                .Select(group => new OrderItem
                {
                    // Preserve the first item's ID for update operations
                    OrderItemId = group.First().OrderItemId,
                    OrderId = group.First().OrderId,
                    FabricId = group.Key.FabricId,
                    TypeId = group.Key.TypeId,
                    Quantity = group.Sum(item => item.Quantity),
                    CurrentStage = group.First().CurrentStage,
                    ProcessedByUserId = group.First().ProcessedByUserId
                })
                .ToList();

            order.OrderItems = mergedItems;
        }

        private void CheckValidation(Order order, int? excludeId = null)
        {
            var validator = new OrderValidator(_orderRepo, excludeId);
            var result = validator.Validate(order);

            if (!result.IsValid)
            {
                throw new Exception(result.Errors[0].ErrorMessage);
            }
        }

        private void CheckStockAvailability(ICollection<OrderItem> orderItems)
        {
            if (orderItems == null || !orderItems.Any())
                return;

            var stockInsufficiencies = _stockService.CheckStockAvailability(orderItems);

            if (stockInsufficiencies.Any())
            {
                var errorMessage = new StringBuilder();
                errorMessage.AppendLine("Order cannot be placed! Insufficient stock for the following fabrics:");
                errorMessage.AppendLine();

                foreach (var insufficiency in stockInsufficiencies)
                {
                    errorMessage.AppendLine($"• {insufficiency.Key}: {insufficiency.Value:F2} meters short");
                }

                throw new Exception(errorMessage.ToString());
            }
        }
    }
}
