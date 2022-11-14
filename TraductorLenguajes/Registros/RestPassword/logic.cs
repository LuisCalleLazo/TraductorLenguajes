using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace TraductorLenguajes.Registros
{
    class logic
    {
        public string SendMail(string email_envio, string asunto, string cuerpo)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "traductorlenguajes@outlook.com";
            string pass = "traclangs788##$$//CaBaAl";
            string displayName = "Traductor Lenguajes";

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(email_envio);

                mail.Subject = asunto;
                mail.Body = cuerpo;
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.office365.com",587);
                client.Credentials = new NetworkCredential(from, pass);
                client.EnableSsl = true;

                client.Send(mail);
                msge = "¡Codigo enviado exitosamente!.\nPronto te llegara el código de verificación";
                
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return msge;
        }
    }
}
