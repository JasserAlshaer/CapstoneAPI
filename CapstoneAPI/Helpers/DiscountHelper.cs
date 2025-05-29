namespace CapstoneAPI.Helpers
{
    public static class DiscountHelper
    {
        public static bool EvaluateCondition(float actual, string op, float target)
        {
            return op switch
            {
                ">" => actual > target,
                ">=" => actual >= target,
                "<" => actual < target,
                "<=" => actual <= target,
                "=" or "==" => actual == target,
                "!=" => actual != target,
                _ => false,
            };
        }
        public static int GetUserAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
