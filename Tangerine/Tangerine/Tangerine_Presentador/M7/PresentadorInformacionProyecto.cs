using DominioTangerine;
using LogicaTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M7;

namespace Tangerine_Presentador.M7
{
    public class PresentadorInformacionProyecto
    {
         IContratoInformacionProyecto vista;

         public PresentadorInformacionProyecto(IContratoInformacionProyecto vista)
        {
            this.vista = vista;
        }

         /// <summary>
         /// Metodo para llamar a los comandos necesarios para carga toda la informacion del proyecto seleccionado
         /// </summary>
         /// <param name="id">Id del proyecto seleccionado </param>
         public void CargarInformacionProyecto(int id)
         {

             Entidad parametro = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
             ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id = id;

             Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarXIdProyecto(parametro);
                                                                          
             Entidad proyecto = comando.Ejecutar();

             Comando<List<Entidad>> comando1 = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarContactosXIdProyecto(parametro);
             List<Entidad> contactos = comando1.Ejecutar();

             Comando<Entidad> comando2 = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoContactNombrePropuestaId(parametro);
             Entidad propuesta = comando2.Ejecutar();

             Comando<List<Entidad>> comandoConsultarEmpleados = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarEmpleadosXIdProyecto(parametro);
             List<Entidad> listaEmpleados = comandoConsultarEmpleados.Ejecutar();

             Comando<List<Entidad>> comando4 =
                LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosProgramadores();
             List<Entidad> programadores = comando4.Ejecutar();

              try
              {
                   vista.NombrePropuesta.Text = ((DominioTangerine.Entidades.M7.Propuesta)propuesta).Nombre;
                   vista.NombreProyecto.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre;
                   vista.CodigoProyecto.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo;
                   vista.FechaInicio.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio.ToString("dd/MM/yyyy");
                   vista.FechaFin.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechaestimadafin.ToString("dd/MM/yyyy");
                   vista.Costo.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo.ToString();
                   vista.Porcentaje.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion;
                   vista.Estatus.Text = ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus;

                   llenarCombo(contactos);
                   llenarComboPersonal(programadores, listaEmpleados);

              }

              catch (Exception ex)
              {
                  throw ex;
              }
         }

         /// <summary>
         /// Metodo para llenar combobox del personal activo
         /// </summary>
         /// <param name="programadores">Lista de entidad empleado con todos los programadores</param>
         /// <param name="actuales">Lista de entidad empleado con los empleados activos</param></param>
         private void llenarComboPersonal(List<Entidad> programadores, List<Entidad> actuales)
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
                         Asignados.Add(programador);
                         programadores.Remove(programador);
                         break;
                     }
                 }
             }
             Dictionary<int, string> listaEmpleados = new Dictionary<int, string>();
             foreach (Entidad empleado in Asignados)
             {
                 listaEmpleados.Add(((DominioTangerine.Entidades.M7.Empleado)empleado).Id,
                     (((DominioTangerine.Entidades.M7.Empleado)empleado).emp_p_nombre) +
                     " " + ((DominioTangerine.Entidades.M7.Empleado)empleado).emp_p_apellido);
             }
             vista.inputPersonal.DataSource = listaEmpleados;
             vista.inputPersonal.DataTextField = RecursoPresentadorM7.Value;
             vista.inputPersonal.DataValueField = RecursoPresentadorM7.Key;
             vista.inputPersonal.DataBind();
         }

         /// <summary>
         /// Metodo para llenar combobox con los contactos del proyecto
         /// </summary>
         /// <param name="contactos">Lista de entidad contacto con todos los contactos existente para el proyecto</param>
        private void llenarCombo(List<Entidad> contactos)
        {
            Dictionary<int, string> listaContactos = new Dictionary<int, string>();
            foreach (Entidad contacto in contactos)
            {
                Comando<Entidad> comandoContacto = LogicaTangerine.Fabrica.FabricaComandos.CrearComandoConsultarContacto(contacto);
                Entidad elContacto = comandoContacto.Ejecutar();

                listaContactos.Add(((DominioTangerine.Entidades.M5.ContactoM5)elContacto).Id, 
                    (((DominioTangerine.Entidades.M5.ContactoM5)elContacto).Nombre) +
                    " " + ((DominioTangerine.Entidades.M5.ContactoM5)elContacto).Apellido);
            }
            vista.inputEncargado.DataSource = listaContactos;
            vista.inputEncargado.DataTextField = RecursoPresentadorM7.Value;
            vista.inputEncargado.DataValueField = RecursoPresentadorM7.Key;
            vista.inputEncargado.DataBind();
        }
    }
}
