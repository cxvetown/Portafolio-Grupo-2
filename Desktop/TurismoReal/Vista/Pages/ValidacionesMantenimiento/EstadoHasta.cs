using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesMantenimiento
{
    public class EstadoHasta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var estado = Convert.ToString(value);

                if (estado != null && estado != string.Empty)
                {
                    if (estado.Length > 1)
                    {
                        return new ValidationResult(false, "El estado solo puede ser 1 caracter");
                    }
                }
                else
                {
                    return new ValidationResult(false, "El estado es requerido");
                }
                return ValidationResult.ValidResult;
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Algo anda mal");
            }
        }
    }
}
