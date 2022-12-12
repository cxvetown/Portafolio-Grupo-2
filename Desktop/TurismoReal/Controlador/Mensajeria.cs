using System.Net;
using System.Net.Mail;

namespace Controlador
{
    public class Mensajeria
    {
        public static void PlanificarTransporte(string receptor, string asunto, string cantidadPersonas, string lugar, string horaIda, string horaVuelta, string dpto, string direccion)
        {
            string fromMail = "noreplyturismoreal22@gmail.com";
            string fromPass = "gqqvwitfyphbarzb";

            MailMessage mail = new()
            {
                From = new MailAddress(fromMail),
                Subject = asunto,
                Body = $"Transporte para {cantidadPersonas}, el día {horaIda} en {lugar}, con dirección {dpto}, {direccion}.\n Fecha de vuelta {horaVuelta}"
            };
            mail.To.Add(new MailAddress(receptor));
            var smtpCliente = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPass),
                EnableSsl = true, 
                UseDefaultCredentials= false,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpCliente.Send(mail);
        }
    }
}
