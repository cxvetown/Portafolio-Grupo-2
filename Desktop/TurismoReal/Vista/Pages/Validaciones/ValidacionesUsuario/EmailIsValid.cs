using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesUsuario
{
    public class EmailIsValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var email = value.ToString();
                if (email == null && email != string.Empty) return new ValidationResult(false, "El correo es un campo obligatorio");
                if (!IsValidEmailAddress(email)) return new ValidationResult(false, "Formato inválido");
                return ValidationResult.ValidResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static bool IsValidEmailAddress(string s)
        {
            string pattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])\." + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|" + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
            Regex regex = new(pattern);
            return regex.IsMatch(s);
        }
    }
}