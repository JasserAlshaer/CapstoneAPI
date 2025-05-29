namespace CapstoneAPI.DTOs.Orders
{
    public class CheckoutOrderInputDTO
    {
        public int OrderId { get; set; }
        public int? PaymentCardId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? ConnectionId { get; set; }
    }
}
