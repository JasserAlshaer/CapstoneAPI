using System.Text.RegularExpressions;

namespace CapstoneAPI.Helpers
{
    public static class DataValidationHelper
    {
        public async static Task<bool> IsValidCodeFormat(string value)
        {
            return value.Length == 4 && value.All(char.IsDigit);
        }
        public async static Task<bool> IsValidOperationType(string value)
        {
            if (value.Equals("Signup",StringComparison.OrdinalIgnoreCase)
                || value.Equals("SignIn", StringComparison.OrdinalIgnoreCase)
                || value.Equals("ResetPass", StringComparison.OrdinalIgnoreCase))
            {
               return true;
            }
            return false;
        }
        public async static Task<bool> IsValidBirthDay(string value) {

            var dateOfBirth = DateOnly.Parse(value);
            var today = DateOnly.FromDateTime(DateTime.Today);

            // احسب العمر
            int age = today.Year - dateOfBirth.Year;

            // تأكد إذا ما أكمل عيد ميلاده هالسنة
            if (dateOfBirth > today.AddYears(-age))
            {
                age--;
            }

            if (age < 18)
            {
                return false;
            }
            return true;
        }
        public async static Task<bool> IsJordanianPhone(string phone)
        {
            // يقبل 07X-XXXXXXX أو +9627XXXXXXXX
            var pattern = @"^(?:\+962|0)?7[789]\d{7}$";
            return Regex.IsMatch(phone, pattern);
        }
        public async static Task<bool>  IsValidCountryCode(int countryCode)
        {
            return countryCode == 1;
        }
        public async static Task<bool> IsStrongPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            var hasUpperCase = Regex.IsMatch(password, "[A-Z]");
            var hasLowerCase = Regex.IsMatch(password, "[a-z]");
            var hasDigit = Regex.IsMatch(password, "[0-9]");
            var hasSpecialChar = Regex.IsMatch(password, @"[\W_]"); // أي رمز غير حرف/رقم

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }
        public async static Task<bool> IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        public async static Task<bool> IsSingleLanguageFullName(string name)
        {
            name = name.Trim(); // شيل المسافات من البداية والنهاية

            // تحقق من اللغة أولاً
            var arabicPattern = @"^[\u0600-\u06FF]+(?:\s[\u0600-\u06FF]+)*$";
            var englishPattern = @"^[a-zA-Z]+(?:\s[a-zA-Z]+)*$";

            return Regex.IsMatch(name, arabicPattern) || Regex.IsMatch(name, englishPattern);
        }
    }
}
