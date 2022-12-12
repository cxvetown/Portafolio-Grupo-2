﻿using System;
using System.Globalization;
using System.Windows.Controls;

namespace Vista.Pages.Validaciones.ValidacionesServExtra
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
                    return new ValidationResult(false, "El valor de la multa debe ser un número positivo");
                }
                return ValidationResult.ValidResult;
            }
            catch (Exception)
            {
                return new ValidationResult(false, "El valor de la multa debe ser un número");
            }
        }
    }
}
