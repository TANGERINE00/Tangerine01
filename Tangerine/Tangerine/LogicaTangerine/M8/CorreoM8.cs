using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace LogicaTangerine.M8
{
    public class CorreoM8
    {
        public void enviarCorreoGmail(string asunto, string destinatario, string mensaje)
        {
            try
            {
                CorreoGmailM8 cr = new CorreoGmailM8();
                MailMessage mnsj = new MailMessage();

                mnsj.Subject = asunto;

                mnsj.To.Add(new MailAddress(destinatario));

                mnsj.From = new MailAddress("tangerine.dev.00@gmail.com", "Sistema Tangerine");

                /* Si deseamos Adjuntar algún archivo*/
                //mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));

                mnsj.Body = mensaje;

                /* Enviar */
                cr.mandarCorreo(mnsj);
                //Enviado = true;

                //MessageBox.Show("El Mail se ha Enviado Correctamente", "Listo!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    }

    public class CorreoGmailM8
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
            server.Credentials = new System.Net.NetworkCredential("tangerine.dev.00@gmail.com", "$Tangerine00");
            server.EnableSsl = true;
        }

        public void mandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }
    }
}
