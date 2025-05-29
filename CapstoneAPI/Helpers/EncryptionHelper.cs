using CapstoneAPI.DTOs.Encryption;
using System.Security.Cryptography;
using System.Text;

namespace CapstoneAPI.Helpers
{
    public static class EncryptionHelper
    {
        public static EncyptDataDTO  Encrypt(string value, byte[] key)
        {
            using var aesGcm = new AesGcm(key);

            var nonce = RandomNumberGenerator.GetBytes(12);
            var bytes = Encoding.UTF8.GetBytes(value);
            var tag = new byte[16];
            var cipsherByter = new byte[bytes.Length];

            aesGcm.Encrypt(nonce, bytes, cipsherByter, tag);

            return new EncyptDataDTO
            {
                CipherText = Convert.ToBase64String(cipsherByter),
                Nonce = Convert.ToBase64String(nonce),
                Tag = Convert.ToBase64String(tag)   
            };
        }

        public static string Decrypt(string CipherText , string Nonce , string Tag , byte[] key)
        {
            using var aesGcm = new AesGcm(key);

            var cipherBytes = Convert.FromBase64String(CipherText);
            var nonce = Convert.FromBase64String(Nonce);
            var tag = Convert.FromBase64String(Tag);
            var plainBytes = new byte[cipherBytes.Length];

            aesGcm.Decrypt(nonce, cipherBytes, tag, plainBytes);

            return Encoding.UTF8.GetString(plainBytes);
        }
    }
}
