namespace CapstoneAPI.DTOs.Chats
{
    public class CreateMessageInputDTO
    {
        public int SenderId { get; set; }
        public int ChatId { get; set; }
        public string? Message { get; set; }
        public string? Image { get; set; }
        public bool IsFromClient { get; set; }
    }
}
