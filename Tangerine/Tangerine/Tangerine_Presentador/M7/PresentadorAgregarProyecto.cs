using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M7;
using LogicaTangerine;
using DominioTangerine;
using System.Web;
using DominioTangerine.Entidades.M7;
using DominioTangerine.Fabrica;
using LogicaTangerine.Fabrica;
using System.Web.UI.WebControls;

namespace Tangerine_Presentador.M7
{
    public class PresentadorAgregarProyecto
    {
       private IContratoAgregarProyecto _vista;

        DateTime _fechaIni;
        DateTime _fechaFin;
        Double _costo;
        List<Entidad> listaPropuestas;

        public PresentadorAgregarProyecto(IContratoAgregarProyecto vista)
        {
            _vista = vista;
        }


        public void agregarProyecto()
        {

            _fechaIni = DateTime.ParseExact(_vista.FechaInicio, "MM/dd/yyyy", null);
            _fechaFin = DateTime.ParseExact(_vista.FechaFin, "MM/dd/yyyy", null);
            _costo = Convert.ToDouble(_vista.Costo);

            /*DominioTangerine.Entidades.M7.Proyecto p = new DominioTangerine.Entidades.M7.Proyecto(_vista.NombreProyecto,
                                                   _vista.CodigoProyecto,_fechaIni, _fechaFin, _costo, "Descripcion",
                                                     "0", "En desarrollo", "", "AcuerdoPago", "IDPropuesta", "IdResponsable", "idgerente");
            */
        }

        public void cargarPropuestas()
        {
            _vista.inputPropuesta.Items.Add("");
            Comando<List<Entidad>> comandoLista = FabricaComandos.ComandoConsultarPropuestaXProyecto();

            listaPropuestas = comandoLista.Ejecutar();

            foreach (Entidad entidad in listaPropuestas)
            {
                DominioTangerine.Entidades.M6.Propuesta propuesta = (DominioTangerine.Entidades.M6.Propuesta) entidad;
                _vista.inputPropuesta.Items.Add(propuesta.Nombre);
            }
        }


        public void CargarPagina()
        {
            cargarPropuestas();
        }



        public void CargarInformacionPropuesta(object sender)
        {
            {
                
                String prueba2 = ((DropDownList)sender).SelectedValue;
               /* Entidad Parametro = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuestaM7();
            ((DominioTangerine.Entidades.M7.Propuesta)Parametro).Nombre =  prueba2;
                */
                
                DominioTangerine.Entidades.M6.Propuesta Parametro = new DominioTangerine.Entidades.M6.Propuesta(
                    prueba2,null,null,null,null,null,
                         null, 0, DateTime.MinValue, DateTime.MinValue, 0, null);
                
                
                
                Comando<Entidad> comandoConsultarPropuesta = FabricaComandos.ComandoConsultarXIdPropuesta(Parametro);
                Entidad propuesta2 = comandoConsultarPropuesta.Ejecutar();

                DominioTangerine.Entidades.M6.Propuesta tal = (DominioTangerine.Entidades.M6.Propuesta)propuesta2;
                _vista.Costo = tal.Costo.ToString();

                Comando<String> comandoGenerarCodigo = FabricaComandos.ObtenerComandoGenerarCodigoProyecto(Parametro);
                String codigo = comandoGenerarCodigo.Ejecutar();
                _vista.CodigoProyecto = codigo;

                Entidad Parametro2 = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaVacia();
                ((DominioTangerine.Entidades.M4.CompaniaM4)Parametro2).Id = Int32.Parse(tal.IdCompañia);
                Comando<List<Entidad>> comandoConsultarContacto = FabricaComandos.CrearComandoConsultarContactosPorCompania(Parametro2,1);
                List<Entidad> listaContacto = comandoConsultarContacto.Ejecutar();

                foreach (Entidad entidad in listaContacto)
                {
                    DominioTangerine.Entidades.M5.ContactoM5 contacto = (DominioTangerine.Entidades.M5.ContactoM5)entidad;
                    _vista.inputEncargado.Items.Add(contacto.Nombre + " " + contacto.Apellido);
                }

                Comando<List<Entidad>> comandoConsultarEmpleados = FabricaComandos.ConsultarEmpleados();
                List<Entidad> listaEmpleados = comandoConsultarEmpleados.Ejecutar();

                foreach (Entidad entidad in listaEmpleados)
                { 
                    DominioTangerine.Entidades.M10.EmpleadoM10 empleado = (DominioTangerine.Entidades.M10.EmpleadoM10) entidad;

                    if (empleado.jobs.Nombre == "Gerente")
                    {
                        _vista.inputGerente.Items.Add(empleado.emp_p_nombre + " " + empleado.emp_p_apellido);
                    }

                    if (empleado.jobs.Nombre == "Programador")
                    {
                        _vista.inputPersonal.Items.Add(empleado.emp_p_nombre + " " + empleado.emp_p_apellido);
                    }
                }
                
            }
        }

        public void AgregarPersonal()
        {
            _vista.columna2.Visible = true;
            _vista.BtnGenerar.Enabled = true;
        }
    }


}
