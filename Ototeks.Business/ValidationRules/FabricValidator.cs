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

        public FabricValidator(IGenericRepository<Fabric> fabricRepo)
        {
            _fabricRepo = fabricRepo;

            // Kural 1: "Kumaş Kodu boş olamaz"
            RuleFor(x => x.FabricCode)
                .NotEmpty().WithMessage("Kumaş kodu boş olamaz!")
                .Must(arg => arg != null && arg.StartsWith("KMS")).WithMessage("Kumaş kodu KMS ile başlamalı!"); // "KMS ile başlıyor olmalı"

            // Kural 2: "Kumaş kodu benzersiz olmalı"
            RuleFor(x => x.FabricCode)
                .Must(BeUniqueCode).WithMessage("Bu kumaş kodu zaten sistemde kayıtlı!");

            // Kural 3: "Kumaş Adı boş olamaz"
            RuleFor(x => x.FabricName)
                .NotEmpty().WithMessage("Kumaş adı boş olamaz!")
                .MinimumLength(3).WithMessage("Kumaş adı en az 3 karakter olmalıdır.");

            // Kural 4: "Stok eksi olamaz"
            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stok eksiye düşemez.");
        }

        // Özel Kontrol Metodu
        private bool BeUniqueCode(string fabricCode)
        {
            // Veritabanına bak: Bu koddan başka var mı?
            var dbList = _fabricRepo.GetAll();
            bool exists = dbList.Any(x => x.FabricCode == fabricCode);
            return !exists;
        }
    }
}