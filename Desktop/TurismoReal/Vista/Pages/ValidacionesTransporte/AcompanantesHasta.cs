using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesTransporte
{
    internal class AcompanantesHasta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int acompanante))
            {
                if (acompanante <= 0)
                {
                    return new ValidationResult(false, "El nro de acompañantes debe ser un número positivo");
                }
                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "El nro de acompañantes debe ser un número");
        }
    }
}
