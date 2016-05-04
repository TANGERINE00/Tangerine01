using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M5;

namespace Tangerine.GUI.M5
{
    public partial class ConsultarContactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaM5 prueba = new LogicaM5();
            
            //Aqui ejecuto el filltable de la clase creada en logica para probar la conexion a la bd
            //los parametros son tipo de empresa 1 (Compania), id de la empresa 1.
            //prueba.fillTable(1,1);
            //prueba.init();

            DominioTangerine.Contacto theContact = new DominioTangerine.Contacto(1, "a", "b", "c", "d", "e", "f", 1, 1);
            bool answer = prueba.AddNewContact(theContact);
            
        }
    }
}