namespace CapstoneAPI.DTOs
{
    public class SignUpInputDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DateofBirth { get; set; }
        public int CountryCodeId { get; set; }
        public string Phone { get; set; }
    }
}
