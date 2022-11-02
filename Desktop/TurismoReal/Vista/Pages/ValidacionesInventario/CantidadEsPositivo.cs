using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesInventario
{
    internal class CantidadEsPositivo :ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int cantidad))
            {
                if (cantidad <= 0)
                {
                    return new ValidationResult(false, "La cantidad debe ser un número positivo");
                }
                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "La cantidad debe ser un número");
        }
    }
}
