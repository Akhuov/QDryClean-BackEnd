namespace QDryClean.Application.Common.Helpers
{
    public static class PhoneNumberHelper
    {
        public static string NormalizePhoneNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            // Оставляем только цифры
            var digitsOnly = new string(input.Where(char.IsDigit).ToArray());

            // Если начинается с 998, добавляем +
            if (digitsOnly.StartsWith("998"))
            {
                return $"+{digitsOnly}";
            }
            // Если длина 9 цифр (без кода), добавляем +998
            else if (digitsOnly.Length == 9)
            {
                return $"+998{digitsOnly}";
            }

            // Некорректный номер
            return null;
        }
    }
}
