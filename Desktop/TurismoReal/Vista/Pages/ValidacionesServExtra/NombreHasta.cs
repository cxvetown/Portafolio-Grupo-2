using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesServExtra
{
    public class NombreHasta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var nombreServ = Convert.ToString(value);

                if (nombreServ != null && nombreServ != string.Empty)
                {
                    if (nombreServ.Length >= 50)
                    {
                        return new ValidationResult(false, "El nombre del servicio no puede superar los 50 caracteres");
                    }
                }
                else
                {
                    return new ValidationResult(false, "El nombre del servicio es requerido");
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
