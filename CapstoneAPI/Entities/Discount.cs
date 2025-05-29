namespace CapstoneAPI.Entities
{
    public class Discount : MainEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Code  { get; set; }
        public int? DicountPercent { get; set; }
    }
}
