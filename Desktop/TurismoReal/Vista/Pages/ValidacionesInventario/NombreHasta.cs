using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.ValidacionesInventario
{
    internal class NombreHasta : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var nombre = Convert.ToString(value);

                if (nombre != null && nombre != string.Empty)
                {
                    if (nombre.Length >= 50)
                    {
                        return new ValidationResult(false, "El nombre no puede superar los 50 caracteres");
                    }
                }
                else
                {
                    return new ValidationResult(false, "El nombre es requerido");
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
