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

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <returns>booleano que refleja el exito de la ejecucion del comando</returns>
        public override bool Ejecutar()
        {
            try
            {
                DatosCorreo _datosCorreo = (DatosCorreo)LaEntidad;

                CorreoGmailM8 cr = new CorreoGmailM8();
                MailMessage mnsj = new MailMessage();

                mnsj.Subject = _datosCorreo.asunto;
                mnsj.From = new MailAddress(ResourceLogicaM8.systemmail, ResourceLogicaM8.SysName);
                mnsj.Body = _datosCorreo.mensjae;
                /* Si deseamos Adjuntar algún archivo*/
                mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));

                string[] mailArray = _datosCorreo.destinatario.Split(',');
                List<string> mailsList = new List<string>(mailArray.Length);
                mailsList.AddRange(mailArray);
                mailsList.Reverse();

                foreach (String value in mailsList)
                {
                    IsValid(value);
                    mnsj.To.Add(value);
                    cr.mandarCorreo(mnsj);
                }
               

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
