using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesUsuario
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
                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "El teléfono debe ser un número");
        }    
    }
}
