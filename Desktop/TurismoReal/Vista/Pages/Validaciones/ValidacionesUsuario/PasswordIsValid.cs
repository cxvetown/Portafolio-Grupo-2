using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesUsuario
{
    public class PasswordIsValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
			try
			{
                string pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
                var pass = value.ToString();
                if (string.IsNullOrEmpty(pass)) return new ValidationResult(false, "La contraseña no puede estar vacía");
                if (pass.Length < 8) return new ValidationResult(false, "La contraseña debe tener al menos 8 caracteres");
                if (!Regex.IsMatch(pass, pattern)) return new ValidationResult(false, "La contraseña no es lo suficientemente fuerte");
                return ValidationResult.ValidResult;

            }
            catch (Exception)
			{

				throw;
			}
        }
    }
}
