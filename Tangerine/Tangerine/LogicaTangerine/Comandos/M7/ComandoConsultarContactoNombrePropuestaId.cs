using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoConsultarContactoNombrePropuestaId : Comando<Entidad>
    {
            private Entidad propuesta;

            public Entidad Propuesta
            {
                get { return propuesta; }
                set { propuesta = value; }
            }

            public ComandoConsultarContactoNombrePropuestaId(Entidad propuesta)
            {
                this.propuesta = propuesta;
            }

            public override Entidad Ejecutar()
            {
                try
                {
                    IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
                    Entidad propuestaResult = daoProyecto.ContactNombrePropuestaId(Propuesta);
                    return propuestaResult;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
