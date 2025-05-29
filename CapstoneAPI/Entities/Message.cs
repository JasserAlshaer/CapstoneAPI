namespace CapstoneAPI.Entities
{
    public class Message : MainEntity
    {
        public string Text { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; }
    }
}
