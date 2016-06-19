using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using DominioTangerine;
using System.Net.Mail;
using DominioTangerine.Entidades.M8;

namespace LogicaTangerine.Comandos.M8
{
    public class ComandoEnviarCorreoGmail : Comando<bool>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Factura a agregar</param>
        public ComandoEnviarCorreoGmail(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <returns>booleano que refleja el exito de la ejecucion del comando</returns>
        public override bool Ejecutar()
        {
            try
            {
                DatosCorreo theEmail = (DatosCorreo)LaEntidad;

                CorreoGmailM8 cr = new CorreoGmailM8();
                MailMessage mnsj = new MailMessage();

                mnsj.Subject = theEmail.asunto;

                mnsj.To.Add(new MailAddress(theEmail.destinatario));

                mnsj.From = new MailAddress("sistematangerine.dev@gmail.com", "Sistema Tangerine");

                /* Si deseamos Adjuntar algún archivo*/
                //mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));

                mnsj.Body = theEmail.mensjae;

                /* Enviar */
                cr.mandarCorreo(mnsj);
                //Enviado = true;

                //MessageBox.Show("El Mail se ha Enviado Correctamente", "Listo!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
