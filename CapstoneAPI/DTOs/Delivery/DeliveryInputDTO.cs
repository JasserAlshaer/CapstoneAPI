namespace CapstoneAPI.DTOs.Delivery
{
    public class DeliveryInputDTO
    {
        public string Title { get; set; }
        public int ClientId { get; set; }
        public float Latatiude { get; set; }
        public float Longatiude { get; set; }
        public string? Description { get; set; }
    }
}
