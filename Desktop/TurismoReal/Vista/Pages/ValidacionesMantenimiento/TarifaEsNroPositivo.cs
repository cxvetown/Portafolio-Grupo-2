using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesMantenimiento
{
    public class TarifaEsNroPositivo : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int costo))
            {
                if (costo <= 0)
                {
                    return new ValidationResult(false, "El costo debe ser un número positivo");
                }
                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "El costo debe ser un número");
        }
    }
}
