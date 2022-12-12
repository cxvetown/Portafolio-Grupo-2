using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesDepto
{
    public class DireccionIsValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var dir = Convert.ToString(value);

                if (dir != null && dir != string.Empty)
                {
                    if (dir.Length >= 200)
                    {
                        return new ValidationResult(false, "La dirección no puede superar los 200 caracteres");
                    } 
                }
                else
                {
                    return new ValidationResult(false, "La dirección es requerida");
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
