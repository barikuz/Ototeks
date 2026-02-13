namespace Ototeks.Entities
{
    // All possible stages an order can go through
    public enum OrderStatus
    {
        Pending = 0,        // Pending (New Order)
        Cutting = 1,        // At Cutting Department
        Sewing = 2,         // At Sewing Workshop
        Ironing = 3,        // Ironing / Packaging
        QualityControl = 4, // Quality Control Check
        Completed = 5,      // Completed / Shipped
        Cancelled = 99      // Cancelled
    }
}
