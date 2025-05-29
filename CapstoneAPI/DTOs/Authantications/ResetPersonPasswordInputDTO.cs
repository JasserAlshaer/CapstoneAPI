namespace CapstoneAPI.DTOs
{
    public class ResetPersonPasswordInputDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
