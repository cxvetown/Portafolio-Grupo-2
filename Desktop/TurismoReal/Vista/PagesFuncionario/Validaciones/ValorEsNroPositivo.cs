using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.PagesFuncionario.Validaciones
{
    public class ValorEsNroPositivo : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var valorServ = Convert.ToInt32(value);

                if (valorServ <= 0)
                {
                    return new ValidationResult(false, "El valor del servicio debe ser un número positivo");
                }
                return ValidationResult.ValidResult;
            }
            catch (Exception)
            {
                return new ValidationResult(false, "El valor del servicio debe ser un número");
            }
        }
    }
}
