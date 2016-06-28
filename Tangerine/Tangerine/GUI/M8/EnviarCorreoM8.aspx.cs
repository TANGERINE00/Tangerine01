using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using Tangerine_Presentador.M8;
using Tangerine_Contratos.M8;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace Tangerine.GUI.M8
{
    public partial class EnviarCorreoM8 : System.Web.UI.Page, IContratoCorreo
    {

        #region presentador
        PresentadorCorreo _presentador;

        public EnviarCorreoM8()
        {
            _presentador = new PresentadorCorreo(this);
        }
        #endregion

        #region contrato
        public string numero
        {
            get { return this.textNumeroFactura.Text; }
            set { this.textNumeroFactura.Text = value; }
        }

        public string destinatario
        {
            get { return this.textDestinatario_M8.Value; }
            set { this.textDestinatario_M8.Value = value; }
        }

        public string asunto
        {
            get { return this.textAsunto_M8.Value; }
            set { this.textAsunto_M8.Value = value; }
        }

        public string mensaje
        {
            get { return this.textMensaje_M8.Value; }
            set { this.textMensaje_M8.Value = value; }
        }

        public string adjunto
        {
            get { return this.Label1.Text; }
            set { this.Label1.Text = value; }
        }

        public string alertaClase
        {
            set { alert.Attributes[ResourceGUIM8.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[ResourceGUIM8.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }



        #endregion

        /// <summary>
        /// Carga la ventana Enviar Correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="idFac">Id de la factura</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                textNumeroFactura.Text = Request.QueryString[ResourceGUIM8.idFac]; ;
                if (!IsPostBack)
                {
                    _presentador.correofactura();
                }
            }
            catch
            {
                Response.Redirect(ResourceGUIM8.volver);
            }
        }

        /// <summary>
        /// Boton para enviar el correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonEnviarCorreo_Click(object sender, EventArgs e)
        {
            if (fuImage.HasFile)
                SaveFile(fuImage.PostedFile);

            if (_presentador.enviarCorreo())
                Server.Transfer(ResourceGUIM8.volverCorreo);
        }

        /// <summary>
        /// Metodo para guardar el archivo adjunto
        /// </summary>
        /// <param name="file">Archivo a enviar por correo</param>
        void SaveFile(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
            string savePath = Server.MapPath(ResourceGUIM8.path) + System.IO.Path.DirectorySeparatorChar;

            // Get the name of the file to upload.
            string fileName = file.FileName;

            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }
                fileName = tempfileName;
            }
            adjunto = fileName;
            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            file.SaveAs(savePath);

        }
    }
}