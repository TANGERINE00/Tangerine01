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

         public void CargarInformacionProyecto(int id)
         {

             Entidad parametro = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
             ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id = id;

             Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarXIdproyecto(parametro);
             Entidad proyecto = comando.Ejecutar();

             Comando<List<Entidad>> comando1 = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarContactosXIdProyecto(parametro);
             List<Entidad> contactos = comando1.Ejecutar();

             Comando<Entidad> comando2 = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoContactNombrePropuestaId(parametro);
             Entidad propuesta = comando2.Ejecutar();

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

                   /*-->> Proyecto Proyecto = new Proyecto();
                   LogicaProyecto LogicaM7 = new LogicaProyecto();
                   -->> Proyecto = LogicaM7.consultarProyecto(Proyectoid);
                   -->> ContactosProyecto = LogicaM5.GetContactsProyect(Proyecto);
                   ProgramadoresProyecto = LogicaM7.obtenerListaEmpleados(Proyecto);
                   -->> NombrePropuesta.Text = LogicaM7.ConsultarNombrePropuestaID(Proyecto.Idpropuesta);
                   NombreProyecto.Text = Proyecto.Nombre;
                   CodigoProyecto.Text = Proyecto.Codigo;
                   FechaInicio.Text = Proyecto.Fechainicio.ToString("dd/MM/yyyy");
                   FechaFin.Text = Proyecto.Fechaestimadafin.ToString("dd/MM/yyyy");
                   Costo.Text = Proyecto.Costo.ToString();
                   Porcentaje.Text = Proyecto.Realizacion;
                   Estatus.Text = Proyecto.Estatus;
                   for (int i = 0; i < ProgramadoresProyecto.Count; i++)
                   {
                       inputPersonal.Items.Add(ProgramadoresProyecto[i].emp_p_nombre + " " + ProgramadoresProyecto[i].emp_p_apellido);
                   }

                   for (int i = 0; i < ContactosProyecto.Count; i++)
                   {
                       inputEncargado.Items.Add(ContactosProyecto[i].Nombre + " " + ContactosProyecto[i].Apellido);
                   }*/
              }

              catch (Exception ex)
              {
                  throw ex;
              }
         }

        private void llenarCombo(List<Entidad> contactos)
        {
            Dictionary<int, string> listaContactos = new Dictionary<int, string>();
            foreach (Entidad contacto in contactos)
            {
                listaContactos.Add(((DominioTangerine.Entidades.M7.Contacto)contacto).Id, (((DominioTangerine.Entidades.M7.Contacto)contacto).Nombre) + 
                                " " +((DominioTangerine.Entidades.M7.Contacto)contacto).Apellido);
            }
            vista.inputEncargado.DataSource = listaContactos;
            vista.inputEncargado.DataTextField = RecursoPresentadorM7.Value;
            vista.inputEncargado.DataValueField = RecursoPresentadorM7.Key;
            vista.inputEncargado.DataBind();
        }
    }
}
