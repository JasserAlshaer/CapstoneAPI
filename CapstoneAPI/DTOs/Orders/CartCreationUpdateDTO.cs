namespace CapstoneAPI.DTOs.Orders
{
    public class CartCreationDTO
    {
        
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public string Note { get; set; }
        public int Quantity {  get; set; }
    }
    public class CartUpdateDTO
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public int Quantity { get; set; }
    }
}
