using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesTransporte
{
    public class TotalEsPositivo : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int total))
            {
                if (total <= 0)
                {
                    return new ValidationResult(false, "El total debe ser un número positivo");
                }
                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "El total debe ser un número");
        }
    }
}
