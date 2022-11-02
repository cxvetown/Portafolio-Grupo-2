using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesInventario
{
    public class ValorEsNroPositivo : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int valorUnitario))
            {
                if (valorUnitario <= 0)
                {
                    return new ValidationResult(false, "El valor unitario debe ser un número positivo");
                }
                return ValidationResult.ValidResult;

            }
            return new ValidationResult(false, "El valor unitario debe ser un número");
        }
    }
}
