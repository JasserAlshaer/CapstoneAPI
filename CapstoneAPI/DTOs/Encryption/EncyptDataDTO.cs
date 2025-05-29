namespace CapstoneAPI.DTOs.Encryption
{
    public class EncyptDataDTO
    {
        public string Nonce { get; set; }
        public string Tag { get; set; }
        public string CipherText { get; set; }
    }
}
