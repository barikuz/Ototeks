using FluentValidation;
using Ototeks.Entities;
using Ototeks.DataAccess.Abstract;
using System.Linq;
using System;

namespace Ototeks.Business.ValidationRules
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly int? _currentCustomerId; // Güncellenen kaydýn ID'si

        public CustomerValidator(IGenericRepository<Customer> customerRepo, int? currentCustomerId = null)
        {
            _customerRepo = customerRepo;
            _currentCustomerId = currentCustomerId;

            // Kural 1: "Müþteri adý boþ olamaz ve benzersizlik kontrolü"
            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Müþteri adý boþ olamaz!")
                .Must(customerName => IsUnique(customerName, c => c.CustomerName))
                .WithMessage("Bu müþteri adý zaten sistemde kayýtlý!");

            // Kural 2: "Telefon boþ olamaz, format kontrolü ve benzersizlik kontrolü"
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon numarasý boþ olamaz!")
                .Matches(@"^[\+]?[1-9][\d]{0,15}$")
                .WithMessage("Geçerli bir telefon numarasý giriniz!")
                .Must(phone => IsUnique(phone, c => c.Phone))
                .WithMessage("Bu telefon numarasý zaten sistemde kayýtlý!");

            // Kural 3: "E-posta boþ olamaz ve format,benzersizlik kontrolü"
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boþ olamaz!")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz!")
                .Must(email => IsUnique(email, c => c.Email))
                .WithMessage("Bu e-posta adresi zaten sistemde kayýtlý!");

            // Kural 4: "Adres boþ olamaz"
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres bilgisi boþ olamaz!");

        }

        // Generic benzersizlik kontrolü
        private bool IsUnique(string? value, Func<Customer, string?> propertySelector)
        {
            if (string.IsNullOrEmpty(value))
                return true; // Boþ deðer için benzersizlik kontrolü yapmayýz

            // Veritabanýna bak: Bu deðer baþka bir müþteride var mý?
            var dbList = _customerRepo.GetAll();
            var existingCustomer = dbList.FirstOrDefault(x => 
            {
                var propertyValue = propertySelector(x);
                return propertyValue != null && propertyValue.Equals(value, StringComparison.OrdinalIgnoreCase);
            });
            
            if (existingCustomer == null)
            {
                return true; // Deðer yok, benzersiz
            }
            
            // Eðer güncelleme modundaysak ve bulunan kayýt ayný kayýtsa sorun yok
            if (_currentCustomerId.HasValue && existingCustomer.CustomerId == _currentCustomerId.Value)
            {
                return true; // Ayný kayýt, sorun yok
            }
            
            return false; // Baþka kayýtta var, benzersiz deðil
        }

        // Silme Kontrolü Metodu
        public void ValidateForDeletion(Customer customer)
        {
            // Bu müþterinin sipariþlerinin olup olmadýðýný kontrol et
            var customerWithOrders = _customerRepo.GetById(c => c.CustomerId == customer.CustomerId, "Orders");
            
            if (customerWithOrders?.Orders != null && customerWithOrders.Orders.Any())
            {
                throw new System.Exception($"'{customer.CustomerName}' isimli müþteri silinemez! Bu müþterinin {customerWithOrders.Orders.Count} adet sipariþi bulunmaktadýr.");
            }
        }
    }
}