using DominioTangerine;
using LogicaTangerine;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Tangerine_Contratos.M7;
using System.Web;
using System.Web.UI;

namespace Tangerine_Presentador.M7
{
    public class PresentadorModificarProyecto
    {
        IContratoModificarProyecto vista;
        Entidad proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();

        public Entidad Proyecto
        {
            get { return proyecto; }
            set { proyecto = value; }
        }

        public PresentadorModificarProyecto(IContratoModificarProyecto vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo para llamar a los comandos necesarios para carga toda la informacion del proyecto seleccionado
        /// </summary>
        /// <param name="id">Id del proyecto seleccionado </param>
        public void CargarProyecto(int id)
        {
            Entidad parametro = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
            ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id = id;

            Comando<Entidad> comando =
                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarXIdProyecto(parametro);
            proyecto = comando.Ejecutar();

            Comando<List<Entidad>> comando1 =
                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarContactosXIdProyecto(parametro);
            List<Entidad> contactos = comando1.Ejecutar();

            Comando<Entidad> comando2 = 
                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoContactNombrePropuestaId(parametro);
            Entidad propuesta = comando2.Ejecutar();

            Comando<List<Entidad>> comando3 = 
                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosGerentes();
            List<Entidad> gerentes = comando3.Ejecutar();

            Comando<List<Entidad>> comando4 = 
                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosProgramadores();
            List<Entidad> programadores = comando4.Ejecutar();

            Comando<Entidad> comando5 = 
                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarXIdProyectoContacto(parametro);
            Entidad contactoEmp = comando5.Ejecutar();

            Comando<List<Entidad>> comando6 =
                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarHistoricoGerente(parametro);
            List<Entidad> GerentesHist = comando6.Ejecutar();

            Comando<List<Entidad>> comandoConsultarEmpleados = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarEmpleadosXIdProyecto(parametro);
            List<Entidad> listaEmpleados = comandoConsultarEmpleados.Ejecutar();

            //Comando<List<Entidad>> comandoConsultarContacto =
            //  LogicaTangerine.Fabrica.FabricaComandos.CrearComandoConsultarContactosPorCompania(_compania, 1);
            //List<Entidad> listaContacto = comandoConsultarContacto.Ejecutar();

            try
            {
                llenarComboEstatus(proyecto);
                llenarInputEncargados(contactos, contactoEmp);
                llenarComboGerentes(gerentes, proyecto);
                llenarInputPersonal(programadores, listaEmpleados);
                llenarInputGerentesPasados(GerentesHist, gerentes);

                vista.idPropuesta.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idpropuesta.ToString();
                vista.inputPropuesta.Text = ((DominioTangerine.Entidades.M7.Propuesta)propuesta).Nombre;
                vista.idProyecto.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id.ToString();
                vista.textInputCosto.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo.ToString();
                vista.textInputNombreProyecto.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre;
                vista.textInputCodigo.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo;
                vista.textInputFechaInicio.Text = 
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio.ToString(RecursoPresentadorM7.DateFormat3);
                vista.textInputPorcentaje.Text = 
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion.ToString();
                vista.descripcion.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Descripcion;
                vista.acuerdoPago.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Acuerdopago;
                vista.idCompania.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idcompania.ToString();
                vista.text10.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Razon;
                vista.realizacion.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion;
                vista.gteAct.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para llenar combobox con los posibles estatus de un proyecto
        /// </summary>
        /// <param name="proyecto">Entidad proyecto</param>
        private void llenarComboEstatus(Entidad proyecto)
        {
            Dictionary<int, string> Estatus = new Dictionary<int, string>();
                Estatus.Add(0, RecursoPresentadorM7.EstatusDesarrollo);
                Estatus.Add(1, RecursoPresentadorM7.EstatusCompletado);
                Estatus.Add(2, RecursoPresentadorM7.EstatusCompletadoDestiempo);
                Estatus.Add(3, RecursoPresentadorM7.EstatusCancelado);

            vista.inputEstatus.DataSource = Estatus;
            vista.inputEstatus.DataTextField = RecursoPresentadorM7.Value;
            vista.inputEstatus.DataValueField = RecursoPresentadorM7.Key;

            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.Equals(RecursoPresentadorM7.EstatusDesarrollo))
            {
                vista.inputEstatus.SelectedIndex = 0;
            }
            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.ToString().Equals(RecursoPresentadorM7.EstatusCompletado))
            {
                vista.inputEstatus.SelectedIndex = 1;
            }
            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.Equals(RecursoPresentadorM7.EstatusCompletadoDestiempo))
            {
                vista.inputEstatus.SelectedIndex = 2;
            }
            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.Equals(RecursoPresentadorM7.EstatusCancelado))
            {
                vista.inputEstatus.SelectedIndex = 3;
            }

            vista.inputEstatus.DataBind();
        }

        /// <summary>
        /// Metodo para llenar listbox con los encargados del proyecto
        /// </summary>
        /// <param name="contactos">Lista de entidad contacto con todos los contactos existente para el proyecto</param>
        /// <param name="contactoEmp">Entidad contacto con la informacion de contacto encargado actual</param>
        private void llenarInputEncargados(List<Entidad> contactos, Entidad contactoEmp)
        {
            int index = 0;

            foreach (Entidad contacto in contactos)
            {
                Comando<Entidad> comandoContacto = LogicaTangerine.Fabrica.FabricaComandos.CrearComandoConsultarContacto(contacto);
                Entidad elContacto = comandoContacto.Ejecutar();

                vista.imputEncargado.Items.Add(((DominioTangerine.Entidades.M5.ContactoM5)elContacto).Id +"-"+
                    (((DominioTangerine.Entidades.M5.ContactoM5)elContacto).Nombre) +
                    " " + ((DominioTangerine.Entidades.M5.ContactoM5)elContacto).Apellido);

                if (((DominioTangerine.Entidades.M5.ContactoM5)elContacto).Id == ((DominioTangerine.Entidades.M7.Contacto)contactoEmp).Id)
                {
                    vista.imputEncargado.SelectedIndex = index;
                }

                index++;
            }
            
        }

        /// <summary>
        /// Metodo para llenar listbox con los gerentes pasados del proyecto
        /// </summary>
        /// <param name="GerentesHist">Lista de entidad empleado con el historico de gerentes pasados</param>
        /// <param name="gerentes">Lista de entidad empleado con el todos los gerentes existentes</param>
        private void llenarInputGerentesPasados(List<Entidad> GerentesHist, List<Entidad> gerentes)
        {
            List<Entidad> noAsignados = new List<Entidad>();
            List<Entidad> Asignados = new List<Entidad>();

            foreach (Entidad actual in GerentesHist)
            {
                foreach (Entidad programador in gerentes)
                {
                    if (((DominioTangerine.Entidades.M7.Empleado)programador).Id ==
                                            ((DominioTangerine.Entidades.M7.Empleado)actual).Id)
                    {
                        Asignados.Add(programador);
                        gerentes.Remove(programador);
                        break;
                    }
                }
            }
            foreach (Entidad actual in Asignados)
            {
                vista.GerentesPasados.Items.Add(((DominioTangerine.Entidades.M7.Empleado)actual).Id.ToString() + "-" +
                    ((DominioTangerine.Entidades.M7.Empleado)actual).emp_p_nombre + " " +
                    ((DominioTangerine.Entidades.M7.Empleado)actual).emp_p_apellido);
            }

        }

        /// <summary>
        /// Metodo para llenar listbox con los gerentes pasados del proyecto
        /// </summary>
        /// <param name="gerentes">Lista de entidad empleado con el historico de gerentes pasados</param>
        /// <param name="proyecto">Entidad proyecto para obtener el ID</param>
        private void llenarComboGerentes(List<Entidad> gerentes, Entidad proyecto)
        {
            Dictionary<int, string> listaGerentes = new Dictionary<int, string>();
            foreach (Entidad gerente in gerentes)
            {
                listaGerentes.Add(((DominioTangerine.Entidades.M7.Empleado)gerente).Id, 
                                    (((DominioTangerine.Entidades.M7.Empleado)gerente).emp_p_nombre) +
                                    " " + (((DominioTangerine.Entidades.M7.Empleado)gerente).emp_p_apellido));
            }
            vista.inputGerente.DataSource = listaGerentes;
            vista.inputGerente.DataTextField = RecursoPresentadorM7.Value;
            vista.inputGerente.DataValueField = RecursoPresentadorM7.Key;
            vista.inputGerente.SelectedIndex = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente;
            vista.inputGerente.DataBind();
        }

        /// <summary>
        /// Metodo para llenar listbox personal activo y no activo
        /// </summary>
        /// <param name="programadores">Lista de entidad empleado con todos los programadores</param>
        /// <param name="actuales">Lista de entidad empleado con los empleados activos</param></param>
        private void llenarInputPersonal(List<Entidad> programadores, List<Entidad> actuales)
        {
            List<Entidad> noAsignados = new List<Entidad>();
            List<Entidad> Asignados = new List<Entidad>();

            foreach (Entidad actual in actuales)
            {
                foreach (Entidad programador in programadores)
                {
                    if (((DominioTangerine.Entidades.M7.Empleado)programador).Id ==
                                            ((DominioTangerine.Entidades.M7.Empleado)actual).emp_num_ficha)
                    {
                        programadores.Remove(programador);
                        Asignados.Add(programador);
                        break;
                    }
                }
            }

            foreach(Entidad programador in programadores)
            {
                vista.inputPersonalNoActivo.Items.Add(((DominioTangerine.Entidades.M7.Empleado)programador).Id.ToString() + "-" +
                    ((DominioTangerine.Entidades.M7.Empleado)programador).emp_p_nombre + " " +
                    ((DominioTangerine.Entidades.M7.Empleado)programador).emp_p_apellido);
            }

            foreach (Entidad actual in Asignados)
            {
                vista.inputPersonal.Items.Add(((DominioTangerine.Entidades.M7.Empleado)actual).Id.ToString() + "-" +
                    ((DominioTangerine.Entidades.M7.Empleado)actual).emp_p_nombre + " " +
                    ((DominioTangerine.Entidades.M7.Empleado)actual).emp_p_apellido);
            }
            

        }


        /// <summary>
        /// Metodo para recibir el accionar del boton modificar
        /// </summary>
        public bool EventoClick_Modificar()
        {
            bool resultado = Validaciones();

            if (resultado == true)
            {
                ModificarDatos();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo para validaciones manuales de campos criticos requeridos
        /// </summary>
        public bool Validaciones()
        {
            
            DateTime inicio = 
            DateTime.ParseExact(vista.textInputFechaInicio.Text.ToString(), RecursoPresentadorM7.DateFormat3, null);

            if (vista.FechaFin == "")
            {
                vista.alertaClase = RecursoPresentadorM7.alertaError;
                vista.alertaRol = RecursoPresentadorM7.tipoAlerta;
                vista.alerta = RecursoPresentadorM7.alertaHtml + RecursoPresentadorM7.ErrorFFinVacio
                                + RecursoPresentadorM7.alertaHtmlFinal;
                return false;
            }

            DateTime nuevaFechaFin = DateTime.ParseExact(vista.FechaFin, RecursoPresentadorM7.DateFormat3, null);

            if (inicio > nuevaFechaFin)
            {
                vista.alertaClase = RecursoPresentadorM7.alertaError;
                vista.alertaRol = RecursoPresentadorM7.tipoAlerta;
                vista.alerta = RecursoPresentadorM7.alertaHtml + RecursoPresentadorM7.ErrorRangoFechas
                                + RecursoPresentadorM7.alertaHtmlFinal;
                return false;
            }

            if (vista.inputPersonal.Items.Count <= 0)
            {
               vista.alertaClase = RecursoPresentadorM7.alertaError;
                vista.alertaRol = RecursoPresentadorM7.tipoAlerta;
                vista.alerta = RecursoPresentadorM7.alertaHtml + RecursoPresentadorM7.ErrorEmpleadoVacio
                                + RecursoPresentadorM7.alertaHtmlFinal;
                return false;
            }

            ModificarDatos();
            return true;
        }

        /// <summary>
        /// Metodo para llenar crear nueva entidad proyecto y modificar en la base de datos
        /// </summary>
        public bool ModificarDatos() 
        {
            try
            {
                Entidad _proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Id = int.Parse(vista.idProyecto.Text);
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Nombre = vista.textInputNombreProyecto.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Codigo = vista.textInputCodigo.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Fechaestimadafin = 
                    DateTime.ParseExact(vista.FechaFin, RecursoPresentadorM7.DateFormat3, null);
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Costo = int.Parse(vista.textInputCosto.Text);

                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Estatus =
                    vista.inputEstatus.SelectedItem.ToString();
                
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Razon = vista.text10.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Idgerente = 
                    int.Parse(vista.inputGerente.SelectedValue);

                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Fechainicio =
                    DateTime.ParseExact(vista.textInputFechaInicio.Text.ToString(), RecursoPresentadorM7.DateFormat3, null);

                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Idpropuesta = int.Parse(vista.idPropuesta.Text);
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Descripcion = vista.descripcion.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Acuerdopago = vista.acuerdoPago.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Idcompania = int.Parse(vista.idCompania.Text);

                Entidad _propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta();
                ((DominioTangerine.Entidades.M7.Propuesta)_propuesta).Id = int.Parse(vista.idPropuesta.Text);
                ((DominioTangerine.Entidades.M7.Propuesta)_propuesta).Nombre = vista.inputPropuesta.Text;

                //Entidad _contacto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerContacto();

                string _encargadoNombre;
                foreach (ListItem item in vista.imputEncargado.Items)
                {
                    if (item.Selected)
                    {
                        _encargadoNombre = item.Text.ToString();
                        Char delimiter = '-';
                        String[] substrings = _encargadoNombre.Split(delimiter);

                        List<Entidad> _contactos = new List<Entidad>();
                        Entidad _contacto = DominioTangerine.Fabrica.FabricaEntidades.crearContactoVacio();

                        ((DominioTangerine.Entidades.M5.ContactoM5)_contacto).Id = int.Parse(substrings[0]);
                        _contactos.Add(_contacto);
                        ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).set_contactos(_contactos);
                    }
                }



              
                if (vista.inputEstatus.SelectedItem.ToString() == RecursoPresentadorM7.EstatusCompletado)

                {
                    ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Realizacion = RecursoPresentadorM7.PorcentajeCompleto;
                }
                else
                {
                    ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Realizacion = vista.textInputPorcentaje.Text;
                }


                if (vista.textInputPorcentaje.Text == RecursoPresentadorM7.PorcentajeCompleto)
                {
                    ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Estatus = RecursoPresentadorM7.EstatusCompletado;
                }
                else
                {
                    ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Estatus =
                        vista.inputEstatus.SelectedItem.ToString();
                }


                if (vista.gteAct.Text != vista.inputGerente.SelectedValue)
                {
                    foreach (ListItem anterior in vista.GerentesPasados.Items)
                    {
                        string valor = anterior.Value;
                        String[] substrings = valor.Split('-');
                        if (vista.inputGerente.SelectedValue != substrings[0])
                        {
                            Entidad nuevo = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEmpleado();
                            ((DominioTangerine.Entidades.M7.Empleado)nuevo).Id = int.Parse(vista.inputGerente.SelectedValue);
                            Comando<Boolean> comandoGte =
                                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarHistoricoGerente(_proyecto, nuevo);
                            Boolean resulto = comandoGte.Ejecutar();
                            break;
                        }
                    }
                    if(vista.GerentesPasados.Items.Count <= 0)
                    {
                        Entidad nuevo = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEmpleado();
                        ((DominioTangerine.Entidades.M7.Empleado)nuevo).Id = int.Parse(vista.gteAct.Text);
                        Comando<Boolean> comandoGte =
                            LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarHistoricoGerente(_proyecto, nuevo);
                        Boolean resulto = comandoGte.Ejecutar();
                    }
                }

                List<Entidad> _trabajadores = new List<Entidad>();

                foreach (ListItem item in vista.inputPersonal.Items)
                {
                    Entidad _trabajador = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEmpleado();
                    ((DominioTangerine.Entidades.M7.Empleado)_trabajador).Emp_p_nombre = item.Text.ToString();
                    _trabajadores.Add(_trabajador);
                }

                Comando<Boolean> comando =
                    LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoModificarProyecto(_propuesta, _proyecto, _trabajadores);
                Boolean ejecutado = comando.Ejecutar();

                if ( double.Parse(vista.realizacion.Text) < double.Parse(vista.textInputPorcentaje.Text))
                {
                    double monto = calcularPago(double.Parse(vista.realizacion.Text), double.Parse(vista.textInputPorcentaje.Text), double.Parse(vista.textInputCosto.Text));

                    HttpContext.Current.Response.Redirect(RecursoPresentadorM7.RedirectFactura +
                        int.Parse(vista.idCompania.Text) + RecursoPresentadorM7.idProyecto +
                        int.Parse(vista.idProyecto.Text) + RecursoPresentadorM7.Monto + monto);
                }
                else 
                {
                    HttpContext.Current.Response.Redirect(RecursoPresentadorM7.RedirectInfoProyecto +
                                                                int.Parse(vista.idProyecto.Text) );
                }
                

            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        /// <summary>
        /// Metodo solicitado por M8 para calcular el monto a pagar en la factura que se genera
        /// </summary>
        /// <param name="por_viejo">porcentaje de cuminacion antes de modificar </param>
        /// <param name="por_nuevo">porcentaje de cuminacion nuevo</param>
        /// <param name="monto">costo total del proyecto</param>
        /// <returns>double con el monto resultante</returns>
        public double calcularPago(double por_viejo, double por_nuevo, double monto)
        {
            double por_cobro = por_nuevo - por_viejo;
            return monto * (por_cobro / 100);
        }

        /// <summary>
        /// Metodo para mover empleados entre listbox de empleados asignados al proyecto
        /// </summary>
        public void MoverIzquierda()
        {
            for (int i = vista.inputPersonal.Items.Count - 1; i >= 0; i--)
            {
                if (vista.inputPersonal.Items[i].Selected == true)
                {
                    vista.inputPersonalNoActivo.Items.Add(vista.inputPersonal.Items[i]);
                    ListItem li = vista.inputPersonal.Items[i];
                    vista.inputPersonal.Items.Remove(li);
                }
            }
        }

        /// <summary>
        /// Metodo para mover empleados entre listbox de empleados asignados al proyecto
        /// </summary>
        public void MoverDerecha()
        {
            for (int i = vista.inputPersonalNoActivo.Items.Count - 1; i >= 0; i--)
            {
                if (vista.inputPersonalNoActivo.Items[i].Selected == true)
                {
                    vista.inputPersonal.Items.Add(vista.inputPersonalNoActivo.Items[i]);
                    ListItem li = vista.inputPersonalNoActivo.Items[i];
                    vista.inputPersonalNoActivo.Items.Remove(li);
                }
            }
        }

    }
}
