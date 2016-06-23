using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.Fabrica;
using DatosTangerine.DAO;
using DatosTangerine.DAO.M10;
using DominioTangerine.Entidades.M7;
using DominioTangerine.Fabrica;
using DominioTangerine;
using DatosTangerine.InterfazDAO.M10;
using ExcepcionesTangerine.M10;

namespace LogicaTangerine.Comandos.M10
{
    class ComandoAgregarEmpleado:Comando<bool>
    {
        public ComandoAgregarEmpleado(Entidad Empleado)
        {
            elEmpleado = Empleado;
        }
        public override bool Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEmpleado = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOEmpleado();
                return daoEmpleado.Agregar(elEmpleado);
            }
            catch (AgregarEmpleadoException e)
            {
                throw e;
            }
        }

        public Entidad elEmpleado { get; set; }
    }
}
