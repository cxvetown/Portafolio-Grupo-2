using System.Globalization;
using System;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesDepto
{
    public class NombreDeptoIsValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var dir = (string)value;

                if (dir != null && dir != string.Empty)
                {
                    if (dir.Length >= 100)
                    {
                        return new ValidationResult(false, "El nombre no puede superar los 100 caracteres");
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
