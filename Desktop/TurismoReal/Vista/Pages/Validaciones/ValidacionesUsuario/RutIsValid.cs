using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesUsuario
{
    public class RutIsValid : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var rut = value.ToString();

                if (rut == null || rut == string.Empty) return new ValidationResult(false, "El Rut es un campo obligatorio");
                if (rut.Length >= 2)
                {
                    string nRut = rut.Split('-').First();
                    string dvRut = rut.Split('-').Last();
                    if (!Rut.ValidaRut(nRut, dvRut))
                    {
                        return new ValidationResult(false, "El Rut no es válido");
                    }
                    else
                    {
                        return ValidationResult.ValidResult;
                    }
                }
                return new ValidationResult(false, "El Rut es un campo obligatorio");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
