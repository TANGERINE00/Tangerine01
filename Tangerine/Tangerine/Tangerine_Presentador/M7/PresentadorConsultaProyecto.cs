using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M7;
using LogicaTangerine;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M7
{
    public class PresentadorConsultaProyecto
    {
        IContratoConsultaProyecto vista;

        public PresentadorConsultaProyecto(IContratoConsultaProyecto vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo para mostrar las notificaciones en la parte superior de la vista
        /// </summary>
        /// <param name="msj">valor con el cual se determina la notificacion a mostrar</param>
        public void Alerta(string msj)
        {
            if (msj == RecursoPresentadorM7.CodMsjAgregado)
            {
                vista.alertaClase = RecursoPresentadorM7.alertaModificado;
                vista.alertaRol = RecursoPresentadorM7.tipoAlerta;
                vista.alerta = RecursoPresentadorM7.alertaHtml + RecursoPresentadorM7.MsjAgregado
                    + RecursoPresentadorM7.alertaHtmlFinal;
            }
            else if (msj == RecursoPresentadorM7.CodMsjError)
            {
                vista.alertaClase = RecursoPresentadorM7.alertaError;
                vista.alertaRol = RecursoPresentadorM7.tipoAlerta;
                vista.alerta = RecursoPresentadorM7.alertaHtml + RecursoPresentadorM7.MsjError
                    + RecursoPresentadorM7.alertaHtmlFinal;
            }
            else if (msj == RecursoPresentadorM7.CodMsjModificado)
            {
                vista.alertaClase = RecursoPresentadorM7.alertaModificado;
                vista.alertaRol = RecursoPresentadorM7.tipoAlerta;
                vista.alerta = RecursoPresentadorM7.alertaHtml + RecursoPresentadorM7.MsjModificado
                    + RecursoPresentadorM7.alertaHtmlFinal;
            }
            else
            {
                vista.alertaClase = RecursoPresentadorM7.alertaError;
                vista.alertaRol = RecursoPresentadorM7.tipoAlerta;
                vista.alerta = RecursoPresentadorM7.alertaHtml + RecursoPresentadorM7.MsjErrorGenerico
                    + RecursoPresentadorM7.alertaHtmlFinal; ;
            }
        }

        /// <summary>
        /// Metodo para llamar a los comandos necesarios para carga toda la informacion de todos los proyectos existentes
        /// </summary>
        public void cargarConsultarProyectos()
        {
            try
            {
                Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosProyectos();
                List<Entidad> listaEntidad = comando.Ejecutar();
                foreach (Entidad theProject in listaEntidad)
                {
                    Comando<Entidad> comando2 = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoContactNombrePropuestaId(((DominioTangerine.Entidades.M7.Proyecto)theProject));
                    Entidad propuesta = comando2.Ejecutar();

                    
                    vista.Tabla.Text += RecursoPresentadorM7.OpenTr;

                    vista.Tabla.Text += RecursoPresentadorM7.OpenTD +
                            ((DominioTangerine.Entidades.M7.Proyecto)theProject).Nombre.ToString() +
                            RecursoPresentadorM7.CloseTd;

                    vista.Tabla.Text += RecursoPresentadorM7.OpenTD + 
                            ((DominioTangerine.Entidades.M7.Propuesta)propuesta).Nombre.ToString() + 
                            RecursoPresentadorM7.CloseTd;

                    vista.Tabla.Text += RecursoPresentadorM7.OpenTD + 
                            ((DominioTangerine.Entidades.M7.Proyecto)theProject).Codigo + 
                            RecursoPresentadorM7.CloseTd;

                    vista.Tabla.Text += RecursoPresentadorM7.OpenTD + 
                        ((DominioTangerine.Entidades.M7.Proyecto)theProject).Fechainicio.ToString(RecursoPresentadorM7.DateFormat2) +
                        RecursoPresentadorM7.CloseTd;

                    vista.Tabla.Text += RecursoPresentadorM7.OpenTD + 
                        ((DominioTangerine.Entidades.M7.Proyecto)theProject).Fechaestimadafin.ToString(RecursoPresentadorM7.DateFormat2) +
                        RecursoPresentadorM7.CloseTd;

                    vista.Tabla.Text += RecursoPresentadorM7.OpenTD + 
                        ((DominioTangerine.Entidades.M7.Proyecto)theProject).Realizacion.ToString() + 
                        RecursoPresentadorM7.CloseTd;

                    if (((DominioTangerine.Entidades.M7.Proyecto)theProject).Estatus.ToString().Equals(RecursoPresentadorM7.EstatusDesarrollo))
                    {
                        vista.Tabla.Text += RecursoPresentadorM7.OpenTD +
                            RecursoPresentadorM7.Desarrollo +
                            RecursoPresentadorM7.CloseTd;
                    }
                    if (((DominioTangerine.Entidades.M7.Proyecto)theProject).Estatus.ToString().Equals(RecursoPresentadorM7.Completado))
                    {
                        vista.Tabla.Text += RecursoPresentadorM7.OpenTD + 
                            RecursoPresentadorM7.Completado +
                            RecursoPresentadorM7.CloseTd;
                    }
                    if (((DominioTangerine.Entidades.M7.Proyecto)theProject).Estatus.ToString().Equals(RecursoPresentadorM7.CompletadoAdestiempo))
                    {
                        vista.Tabla.Text += RecursoPresentadorM7.OpenTD +
                            RecursoPresentadorM7.CompletadoAdestiempo + 
                            RecursoPresentadorM7.CloseTd;
                    }
                    if (((DominioTangerine.Entidades.M7.Proyecto)theProject).Estatus.ToString().Equals(RecursoPresentadorM7.EstatusCancelado))
                    {
                        vista.Tabla.Text += RecursoPresentadorM7.OpenTD +
                            RecursoPresentadorM7.Cancelado +
                            RecursoPresentadorM7.CloseTd;
                    }
                    vista.Tabla.Text += RecursoPresentadorM7.OpenTD + 
                        RecursoPresentadorM7.OpenBotonInfo + 
                        ((DominioTangerine.Entidades.M7.Proyecto)theProject).Id + 
                        RecursoPresentadorM7.CloseBotonParametro+
                        RecursoPresentadorM7.OpenBotonModificar + 
                        ((DominioTangerine.Entidades.M7.Proyecto)theProject).Id + 
                        RecursoPresentadorM7.CloseBotonParametro + RecursoPresentadorM7.CloseTd;

                    vista.Tabla.Text += RecursoPresentadorM7.CloseTr;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
