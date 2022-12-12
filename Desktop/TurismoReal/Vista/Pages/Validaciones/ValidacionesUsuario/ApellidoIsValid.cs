using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesUsuario
{
    public class ApellidoIsValid : ValidationRule
    {        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var apellido = Convert.ToString(value);

                if (apellido != null && apellido != string.Empty)
                {
                    if (!NotContainsSpecialChars(apellido))
                    {
                        return new ValidationResult(false, "El apellido no puede contener caracteres especiales");
                    }
                    if (apellido.Length > 60)
                    {
                        return new ValidationResult(false, "El apellido no puede superar los 60 caracteres");
                    }
                }
                else
                {
                    return new ValidationResult(false, "El apellido es requerido");
                }
                return ValidationResult.ValidResult;
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Algo anda mal");
            }

            static bool NotContainsSpecialChars(string s)
            {
                Regex regex = new(@"^[a-zA-Z\s]*$");
                return regex.IsMatch(s);
            }
        }
    }
}
