namespace CapstoneAPI.Entities
{
    public class DiscountCondition
    {
        public int Id { get; set; }
        public int DiscountId { get; set; }
        public string ConditionType { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

    }
}
