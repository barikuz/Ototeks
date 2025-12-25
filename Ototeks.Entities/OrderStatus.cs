namespace Ototeks.Entities
{
    // Siparişin geçebileceği tüm aşamalar
    public enum OrderStatus
    {
        Pending = 0,        // Bekliyor (Yeni Sipariş)
        Cutting = 1,        // Kesimhanede
        Sewing = 2,         // Dikim Atölyesinde
        Ironing = 3,        // Ütü / Paketlemede
        QualityControl = 4, // Kalite Kontrolde
        Completed = 5,      // Tamamlandı / Kargolandı
        Cancelled = 99      // İptal Edildi
    }
}