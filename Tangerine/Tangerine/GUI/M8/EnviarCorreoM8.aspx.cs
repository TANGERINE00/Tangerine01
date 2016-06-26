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

        protected void buttonEnviarCorreo_Click(object sender, EventArgs e)
        {
            if (fuImage.HasFile)
            {
                SaveFile(fuImage.PostedFile);
                // SaveAs method of PostedFile property used
                // to save the file at specified rooted path
                //fuImage.PostedFile.SaveAs(Server.MapPath("~/Facturas") + System.IO.Path.DirectorySeparatorChar + fuImage.PostedFile.FileName);
                
                // success message
                //adjunto = Server.MapPath("~/Facturas") + System.IO.Path.DirectorySeparatorChar + fuImage.PostedFile.FileName;
            }

            if (_presentador.enviarCorreo(adjunto))
                Server.Transfer(ResourceGUIM8.volver);
        }

        void SaveFile(HttpPostedFile file)
        {
            // Specify the path to save the uploaded file to.
            string savePath = Server.MapPath("~/Facturas") + System.IO.Path.DirectorySeparatorChar;

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

                // Notify the user that the file name was changed.
                //UploadStatusLabel.Text = "A file with the same name already exists." + "<br />Your file was saved as " + fileName;
                int i = 1;
            }
            else
            {
                // Notify the user that the file was saved successfully.
                //UploadStatusLabel.Text = "Your file was uploaded successfully.";
                int i = 1;
            }

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            file.SaveAs(savePath);
            adjunto = savePath;

        }
    }
}