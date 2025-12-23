using FluentValidation;
using Ototeks.DataAccess.Abstract;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Linq;

namespace Ototeks.Business.ValidationRules
{
    public class OrderValidator : AbstractValidator<Order>
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly int? _currentOrderId; // Güncellenen kaydın ID'si

        public OrderValidator(IGenericRepository<Order> orderRepository, int? currentOrderId = null)
        {
            _orderRepository = orderRepository;
            _currentOrderId = currentOrderId;

            // 1. Sipariş Numarası Kontrolü
            RuleFor(x => x.OrderNumber)
                .NotEmpty().WithMessage("Sipariş numarası boş olamaz!")
                .Must(BeUniqueOrderNumber).WithMessage("Bu sipariş numarası zaten kullanılmaktadır!");

            // 2. Sipariş Tarihi 
            RuleFor(x => x.OrderDate)
                .NotNull().WithMessage("Lütfen bir sipariş tarihi seçiniz!")
                .Must(date => date.Value != default(DateTime))
                .WithMessage("Lütfen geçerli bir sipariş tarihi seçiniz!");

            // 3. Müşteri Seçimi Kontrolü
            // (CustomerID int olduğu için 0'dan büyük olmalı)
            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Lütfen bir müşteri seçiniz!");

            // 4. Liste Boş Olamaz Kontrolü (Ana Liste Kontrolü)
            RuleFor(x => x.OrderItems)
                .NotNull().WithMessage("Liste boş olamaz!")
                .Must(items => items.Count > 0)
                .WithMessage("Siparişe en az bir ürün eklemelisiniz!");

            // 5. DETAYLI LİSTE KONTROLÜ
            // Listenin içindeki HER BİR elemanı tek tek gezer ve kontrol eder.
            RuleForEach(x => x.OrderItems).ChildRules(items =>
            {
                // Ürün Tipi Kontrolü (nullable int için doğru kontrol)
                items.RuleFor(x => x.TypeId)
                     .NotNull().WithMessage("Listede 'Ürün Tipi' seçilmemiş satırlar var!");

                // Kumaş Kontrolü (nullable int için doğru kontrol)
                items.RuleFor(x => x.FabricId)
                     .NotNull().WithMessage(item => $"'{GetProductTypeName(item)}' için 'Kumaş Türü' seçilmemiş!");

                // Adet Kontrolü
                items.RuleFor(x => x.Quantity)
                     .GreaterThan(0)
                     .WithMessage(item => $"'{GetProductTypeName(item)}' için ADET girmelisiniz!");
            });
        }

        // Ürün tipi adını getiren yardımcı metot
        private string GetProductTypeName(OrderItem item)
        {
            // TypeId'den ProductType'ı çek
            if (item.TypeId.HasValue)
            {
                var productTypeRepo = new GenericRepository<ProductType>();
                var productType = productTypeRepo.GetById(item.TypeId.Value);
                return productType?.TypeName ?? "Bilinmeyen Ürün";
            }

            return "Seçilmemiş";
        }

        // Sipariş numarası benzersizlik kontrolü
        private bool BeUniqueOrderNumber(Order order, string orderNumber)
        {
            // Veritabanından aynı numaraya sahip sipariş var mı kontrol et
            var existingOrders = _orderRepository.GetAll();
            var existingOrder = existingOrders.FirstOrDefault(x => 
                x.OrderNumber.Equals(orderNumber, StringComparison.OrdinalIgnoreCase));

            if (existingOrder == null)
            {
                return true; // Numara yok, benzersiz
            }

            // Eğer güncelleme modundaysak ve bulunan kayıt aynı kayıtsa sorun yok
            if (_currentOrderId.HasValue && existingOrder.OrderId == _currentOrderId.Value)
            {
                return true; // Aynı kayıt, sorun yok
            }

            return false; // Başka kayıtta var, benzersiz değil
        }
    }
}