using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesServDepto
{
    public class NombreHasta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var dir = Convert.ToString(value);

                if (dir != null && dir != string.Empty)
                {
                    if (dir.Length >= 50)
                    {
                        return new ValidationResult(false, "El nombre no puede superar los 50 caracteres");
                    }
                }
                else
                {
                    return new ValidationResult(false, "El nombre es requerido");
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
