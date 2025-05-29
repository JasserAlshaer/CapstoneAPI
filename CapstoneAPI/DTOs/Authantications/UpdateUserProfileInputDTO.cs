namespace CapstoneAPI.DTOs
{
    public class UpdateUserProfileInputDTO
    {
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Image { get; set; }
        public int Id { get; set; }
    }
}
