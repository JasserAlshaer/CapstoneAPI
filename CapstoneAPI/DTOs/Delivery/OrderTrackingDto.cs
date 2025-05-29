namespace CapstoneAPI.DTOs.Delivery
{
    public class OrderTrackingDto
    {
        public int OrderId { get; set; }
        public string? Status { get; set; } // Can be replaced with Status name from StatusId
        public string? EstimatedTime { get; set; } = "30 min"; // Placeholder
        public double? DriverLocationLat { get; set; }
        public double? DriverLocationLong { get; set; }
        public string? LocationTitle { get; set; }

        public string? DriverImage { get; set; }
        public string? DriverHero { get; set; }
        public string? PhoneNumber { get; set; }
        public int?    DriverId { get; set; }
    }
}
