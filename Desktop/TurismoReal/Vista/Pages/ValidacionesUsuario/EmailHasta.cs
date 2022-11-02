using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesUsuario
{
    public class EmailHasta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var email = Convert.ToString(value);

                if (email != null && email != string.Empty)
                {
                    if (email.Length > 254)
                    {
                        return new ValidationResult(false, "El email no puede superar los 254 caracteres");
                    }
                }
                else
                {
                    return new ValidationResult(false, "El email es requerido");
                }
                return ValidationResult.ValidResult;
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Algo anda mal");
            }
        }
    }
}
