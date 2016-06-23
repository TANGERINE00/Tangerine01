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
                vista.textInputFechaInicio.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio.ToString("dd/MM/yyyy");
                vista.textInputPorcentaje.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion.ToString();
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


        private void llenarComboEstatus(Entidad proyecto)
        {
            Dictionary<int, string> Estatus = new Dictionary<int, string>();
                Estatus.Add(0, "En desarrollo");
                Estatus.Add(1, "Completado");
                Estatus.Add(2, "Completado a destiempo");
                Estatus.Add(3, "Cancelado");

            vista.inputEstatus.DataSource = Estatus;
            vista.inputEstatus.DataTextField = RecursoPresentadorM7.Value;
            vista.inputEstatus.DataValueField = RecursoPresentadorM7.Key;

            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.Equals("En desarrollo"))
            {
                vista.inputEstatus.SelectedIndex = 0;
            }
            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.ToString().Equals("Completado"))
            {
                vista.inputEstatus.SelectedIndex = 1;
            }
            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.Equals("Completado a destiempo"))
            {
                vista.inputEstatus.SelectedIndex = 2;
            }
            if (((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus.Equals("Cancelado"))
            {
                vista.inputEstatus.SelectedIndex = 3;
            }

            vista.inputEstatus.DataBind();
        }


        private void llenarInputEncargados(List<Entidad> contactos, Entidad contactoEmp)
        {
            int index = 0;
            foreach (Entidad contacto in contactos)
            { 
                if (contacto.Id == contactoEmp.Id)
                {
                    vista.imputEncargado.Items.Add((((DominioTangerine.Entidades.M7.Contacto)contacto).Id) +
                                    "-" + (((DominioTangerine.Entidades.M7.Contacto)contacto).Nombre) +
                                    " " + ((DominioTangerine.Entidades.M7.Contacto)contacto).Apellido);
                    vista.imputEncargado.SelectedIndex = index;
                    index++;
                }
                else
                {
                    vista.imputEncargado.Items.Add((((DominioTangerine.Entidades.M7.Contacto)contacto).Id) +
                                    "-" + (((DominioTangerine.Entidades.M7.Contacto)contacto).Nombre) +
                                    " " + ((DominioTangerine.Entidades.M7.Contacto)contacto).Apellido);
                    index++;
                }
            }
        }


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

                return true;
            }
        }


        public bool Validaciones()
        {
            
            DateTime inicio = DateTime.ParseExact(vista.textInputFechaInicio.Text.ToString(), "dd/MM/yyyy", null);

            if (vista.FechaFin == "")
            {
                MessageBox.Show("Debe seleccionar una fecha fin para el proyecto", "Tangerine TG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime nuevaFechaFin = DateTime.ParseExact(vista.FechaFin, "dd/MM/yyyy", null);

            if (inicio > nuevaFechaFin)
            {
               MessageBox.Show("Debe seleccionar una fecha fin mayor a la fecha de inicio", "Tangerine TG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return false;
            }

            if (vista.inputPersonal.Items.Count <= 0)
            {
                MessageBox.Show("Debe seleccionar por lo menos una persona para trabajar en el proyecto",
                    "Tangerine TG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                vista.inputPersonal.Focus();
                return false;
            }

            ModificarDatos();
            return true;
        }


                public bool ModificarDatos() 
        {
            try
            {
                Entidad _proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Id = int.Parse(vista.idProyecto.Text);
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Nombre = vista.textInputNombreProyecto.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Codigo = vista.textInputCodigo.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Fechaestimadafin = DateTime.ParseExact(vista.FechaFin, "dd/MM/yyyy", null);
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Costo = int.Parse(vista.textInputCosto.Text);
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Realizacion = vista.textInputPorcentaje.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Estatus = 
                    vista.inputEstatus.SelectedItem.ToString();

                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Razon = vista.text10.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Idgerente = 
                    int.Parse(vista.inputGerente.SelectedValue);

                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Fechainicio =
                    Convert.ToDateTime(vista.textInputFechaInicio.Text.ToString());

                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Idpropuesta = int.Parse(vista.idPropuesta.Text);
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Descripcion = vista.descripcion.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Acuerdopago = vista.acuerdoPago.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Acuerdopago = vista.acuerdoPago.Text;
                ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Idcompania = int.Parse(vista.idCompania.Text);

                Entidad _propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta();
                ((DominioTangerine.Entidades.M7.Propuesta)_propuesta).Id = int.Parse(vista.idPropuesta.Text);
                ((DominioTangerine.Entidades.M7.Propuesta)_propuesta).Nombre = vista.inputPropuesta.Text;

                Entidad _contacto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerContacto();

                string _encargadoNombre;
                foreach (ListItem item in vista.imputEncargado.Items)
                {
                    if (item.Selected)
                    {
                        _encargadoNombre = item.Text.ToString();
                    }
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

                    HttpContext.Current.Response.Redirect("../M8/GenerarFacturaM8.aspx?IdCompania=" +
                        int.Parse(vista.idCompania.Text) + "&IdProyecto=" +
                        int.Parse(vista.idProyecto.Text) + "&Monto=" + monto);
                }

                

            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        public double calcularPago(double por_viejo, double por_nuevo, double monto)
        {
            double por_cobro = por_nuevo - por_viejo;
            return monto * (por_cobro / 100);
        }

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
