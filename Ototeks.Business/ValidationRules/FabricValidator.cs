using FluentValidation; // Kütüphaneyi çağır
using Ototeks.Entities;
using Ototeks.DataAccess.Abstract;
using System.Linq;

namespace Ototeks.Business.ValidationRules
{
    // AbstractValidator sınıfından miras alıyoruz
    public class FabricValidator : AbstractValidator<Fabric>
    {
        private readonly IGenericRepository<Fabric> _fabricRepo;
        private readonly int? _currentFabricId; // Güncellenen kaydın ID'si

        public FabricValidator(IGenericRepository<Fabric> fabricRepo, int? currentFabricId = null)
        {
            _fabricRepo = fabricRepo;
            _currentFabricId = currentFabricId;

            // Kural 1: "Kumaş Kodu boş olamaz"
            RuleFor(x => x.FabricCode)
                .NotEmpty().WithMessage("Kumaş kodu boş olamaz!")
                .Must(arg => arg != null && arg.StartsWith("KMS-")).WithMessage("Kumaş kodu KMS- ile başlamalı!"); // "KMS ile başlıyor olmalı"

            // Kural 2: "Kumaş kodu benzersiz olmalı"
            RuleFor(x => x.FabricCode)
                .Must(BeUniqueCode).WithMessage("Bu kumaş kodu zaten sistemde kayıtlı!");

            // Kural 3: "Kumaş Adı boş olamaz"
            RuleFor(x => x.FabricName)
                .NotEmpty().WithMessage("Kumaş adı boş olamaz!")
                .MinimumLength(3).WithMessage("Kumaş adı en az 3 karakter olmalıdır.");

            // Kural 4: "Renk seçilmeli"
            RuleFor(x => x.ColorId)
                .NotNull().WithMessage("Renk seçimi yapılmalıdır!")
                .GreaterThan(0).WithMessage("Geçerli bir renk seçilmelidir!");

            // Kural 5: "Stok miktarı 0'dan büyük olmalı"
            RuleFor(x => x.StockQuantity)
                .NotNull().WithMessage("Stok miktarı boş olamaz!")
                .GreaterThan(0).WithMessage("Stok miktarı 0'dan büyük olmalıdır!");
        }

        // Özel Kontrol Metodu - Benzersizlik Kontrolü
        private bool BeUniqueCode(string fabricCode)
        {
            // Veritabanına bak: Bu koddan başka var mı?
            var dbList = _fabricRepo.GetAll();
            var existingFabric = dbList.FirstOrDefault(x => x.FabricCode == fabricCode);
            
            if (existingFabric == null)
            {
                return true; // Kod yok, benzersiz
            }
            
            // Eğer güncelleme modundaysak ve bulunan kayıt aynı kayıtsa sorun yok
            if (_currentFabricId.HasValue && existingFabric.FabricId == _currentFabricId.Value)
            {
                return true; // Aynı kayıt, sorun yok
            }
            
            return false; // Başka kayıtta var, benzersiz değil
        }

        // Silme Kontrolü Metodu
        public void ValidateForDeletion(Fabric fabric)
        {
            // Bu kumaşın sipariş kalemlerinde kullanılıp kullanılmadığını kontrol et
            var fabricWithOrders = _fabricRepo.GetById(f => f.FabricId == fabric.FabricId, "OrderItems");
            
            if (fabricWithOrders?.OrderItems != null && fabricWithOrders.OrderItems.Any())
            {
                throw new System.Exception($"'{fabric.FabricCode}' kodlu kumaş silinemez! Bu kumaş {fabricWithOrders.OrderItems.Count} adet sipariş kaleminde kullanılmaktadır.");
            }
        }
    }
}