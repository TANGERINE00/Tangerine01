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
                DatosCorreo _datosCorreo = (DatosCorreo)LaEntidad;

                CorreoGmailM8 cr = new CorreoGmailM8();
                MailMessage mnsj = new MailMessage();

                mnsj.Subject = _datosCorreo.asunto;

                string destino;
                int j = 0;
                _datosCorreo.destinatario += ",";
                for (int i = 0; i <= _datosCorreo.destinatario.Length; i++)
                {
                    if (_datosCorreo.destinatario[i].ToString() == ",")
                    {
                        destino = _datosCorreo.destinatario.Substring(j, i);
                        j = i + 2;
                        i++;
                        mnsj.To.Add(new MailAddress(destino));
                    }
                }


                //mnsj.To.Add(new MailAddress(_datosCorreo.destinatario));

                mnsj.From = new MailAddress(ResourceLogicaM8.systemmail, ResourceLogicaM8.SysName);

                /* Si deseamos Adjuntar algún archivo*/
                //mnsj.Attachments.Add(new Attachment("C:\\archivo.pdf"));

                mnsj.Body = _datosCorreo.mensjae;

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
