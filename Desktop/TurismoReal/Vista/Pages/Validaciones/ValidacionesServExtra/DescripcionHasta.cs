using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesServExtra
{
    public class DescripcionHasta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var descServ = Convert.ToString(value);

                if (descServ != null && descServ != string.Empty)
                {
                    if (descServ.Length >= 1000)
                    {
                        return new ValidationResult(false, "La descripción del servicio no puede superar los 1000 caracteres");
                    }
                }
                else
                {
                    return new ValidationResult(false, "La descripción del servicio es requerida");
                }
                return ValidationResult.ValidResult;
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }
        }
    }
}
