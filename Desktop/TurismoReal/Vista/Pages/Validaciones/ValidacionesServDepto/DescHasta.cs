using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesServDepto
{
    public class DescHasta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var descripcion = Convert.ToString(value);

                if (descripcion != null && descripcion != string.Empty)
                {
                    if (descripcion.Length >= 1000)
                    {
                        return new ValidationResult(false, "La descripción no puede superar los 1000 caracteres");
                    }
                }
                else
                {
                    return new ValidationResult(false, "La descripción es requerida");
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
