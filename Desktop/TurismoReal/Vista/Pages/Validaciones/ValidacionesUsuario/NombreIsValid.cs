using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Vista.Pages.Validaciones.ValidacionesUsuario
{
    public class NombreIsValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var nombre = value.ToString();
                return nombre == null || nombre == string.Empty || nombre.Trim().Length == 0
                    ? new ValidationResult(false, "El nombre es un campo obligatorio")
                    : ValidationResult.ValidResult;
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Algo anda mal");
            }

        }
    }
}
