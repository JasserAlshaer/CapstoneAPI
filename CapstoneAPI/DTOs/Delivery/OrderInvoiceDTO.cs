namespace CapstoneAPI.DTOs.Delivery
{
    public class OrderInvoiceDTO
    {
        public int OrderId { get; set; }
        public float? SubTotal { get; set; }
        public float? Delivery { get; set; }
        public float? Discount { get; set; }
        public float? TotalPrice { get; set; }
    }
}
