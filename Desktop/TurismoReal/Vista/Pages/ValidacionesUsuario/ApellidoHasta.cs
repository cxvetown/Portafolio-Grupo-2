using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesUsuario
{
    public class ApellidoHasta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var apellido = Convert.ToString(value);

                if (apellido != null && apellido != string.Empty)
                {
                    if (apellido.Length >= 200)
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
        }
    }
}
