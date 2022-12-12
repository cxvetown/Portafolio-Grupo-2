using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesDepto
{
    internal class CapacidadIsValid : ValidationRule
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
                            return new ValidationResult(false, "La capacidad debe ser un número positivo");
                        }
                        return ValidationResult.ValidResult;
                    }
                    return new ValidationResult(false, "La capacidad debe ser un número");
                }
                else
                {
                    return new ValidationResult(false, "La capacidad es requerida");
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, "La capacidad debe ser un número");
            }
        }
    }
}
