using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesUsuario
{
    public class TelefonoEsNroPositivo : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int telefono))
            {              
                if (telefono <= 0)
                {
                    return new ValidationResult(false, "El teléfono debe ser un número positivo");
                }
                if (telefono.ToString().Length < 9 || telefono.ToString().Length > 11)
                {
                    return new ValidationResult(false, "El largo del teléfono no es válido");
                }

                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "El teléfono debe ser un número");
        }
    }
}
