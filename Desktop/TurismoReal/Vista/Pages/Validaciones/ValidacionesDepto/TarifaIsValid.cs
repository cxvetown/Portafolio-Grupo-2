using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesDepto
{
    public class TarifaIsValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (value != null && value.ToString() != string.Empty)
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
                else
                {
                    return new ValidationResult(false, "La tarifa es requerida");
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
