using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesReservaTrans
{
    public class TerminalIsValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var nombre = value.ToString();
                return nombre == null || nombre == string.Empty || nombre.Trim().Length == 0
                    ? new ValidationResult(false, "El terminal es un campo obligatorio")
                    : ValidationResult.ValidResult;
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Algo anda mal");
            }
        }
    }
}
