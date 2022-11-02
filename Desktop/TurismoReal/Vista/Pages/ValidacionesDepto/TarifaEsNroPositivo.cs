using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesDepto
{
    public class TarifaEsNroPositivo : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int tarifaDiara))
            {
                if (tarifaDiara <= 0)
                {
                    return new ValidationResult(false, "La tarifa debe ser un número positivo");
                }
                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "La tarifa debe ser un número");
        }
    }
}
