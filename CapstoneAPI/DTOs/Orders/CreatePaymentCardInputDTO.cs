namespace CapstoneAPI.DTOs.Orders
{
    public class CreatePaymentCardInputDTO
    {
        public int ClientId { get; set; }
        public string CardHolder { get; set; }
        public string VisaNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public int   TypeId { get; set; }
    }
}
