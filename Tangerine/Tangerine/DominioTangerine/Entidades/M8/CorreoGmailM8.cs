using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace DominioTangerine.Entidades.M8
{
    public class CorreoGmailM8 : Entidad
    {
        /*
        * Cliente SMTP
        * Gmail:  smtp.gmail.com  puerto:587
        * Hotmail: smtp.live.com  puerto:25
        */
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);

        public CorreoGmailM8()
        {
            /*
             * Autenticacion en el Servidor
             * Utilizaremos nuestra cuenta de correo
             *
             * Direccion de Correo (Gmail o Hotmail)
             * y Contrasena correspondiente
             */
            server.Credentials = new System.Net.NetworkCredential("sistematangerine.dev@gmail.com", "123456tg");
            server.EnableSsl = true;
        }

        public void mandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        } 
    }
}
