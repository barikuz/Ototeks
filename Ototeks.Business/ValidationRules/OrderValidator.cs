using FluentValidation;
using Ototeks.Entities;

namespace Ototeks.Business.ValidationRules
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            // 1. Sipariş Numarası Kontrolü
            RuleFor(x => x.OrderNumber)
                .NotEmpty().WithMessage("Sipariş numarası boş olamaz!");

            // 2. Müşteri Seçimi Kontrolü
            // (CustomerID int olduğu için 0'dan büyük olmalı)
            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Lütfen bir müşteri seçiniz!");

            // 3. Liste Boş Olamaz Kontrolü
            // (Sepet boşsa hata fırlatacak)
            RuleFor(x => x.OrderItems)
                .Must(items => items != null && items.Count > 0)
                .WithMessage("Lütfen listeye en az bir ürün ekleyin!");

            // 4. Detay Kontrolü 
            // "Siparişin içindeki ürün listesi boş olamaz"
            RuleFor(x => x.OrderItems)
                .Must(items => items != null && items.Count > 0)
                .WithMessage("Siparişin içinde en az bir ürün olmalıdır!");
        }
    }
}