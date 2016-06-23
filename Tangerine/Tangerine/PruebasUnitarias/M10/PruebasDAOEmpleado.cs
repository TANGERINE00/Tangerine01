using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M10;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M10;
using System.Collections;

namespace PruebasUnitarias.M10
{
    [TestFixture]
    public class PruebasDAOEmpleado
    {
        #region Atributos
        public Empleado theEmpleado;
        private DominioTangerine.Entidades.M10.EmpleadoM10 elEmpleado1, elEmpleado2, elEmpleado3, elEmpleado4;
        public bool answer;
        public List<Entidad> theEmpleados;
        public List<Entidad> theDireccion;
        public List<Entidad> theCargos;
        public Hashtable listaHash;
        public DominioTangerine.Entidades.M10.Cargo theCargo;
        int empleadoId;
        public Empleado consultaEmpleado;
        public string pais;
        #endregion

        #region SetUp y TearDown

        [SetUp]
        public void init()
        {
            elEmpleado1 = new DominioTangerine.Entidades.M10.EmpleadoM10();
            elEmpleado2 = new DominioTangerine.Entidades.M10.EmpleadoM10();
            elEmpleado3 = new DominioTangerine.Entidades.M10.EmpleadoM10();
            elEmpleado4 = new DominioTangerine.Entidades.M10.EmpleadoM10();
            theEmpleados = new List<Entidad>();
        }

        [TearDown]

        public void clean()
        {
            elEmpleado1 = null;
            elEmpleado2 = null;
            elEmpleado3 = null;
            elEmpleado4 = null;
        }

        #endregion


        #region Test
        [Test]

        public void TestConsultarXIdEmpleado() 
        {
            //daoEmpleado = DatosTangerine.Fabrica.FabricaDAOSqlServer.ConsultarDAOEmpleadoId();

            //respuesta = daoEmpleado.Agregar(elCliente1);
            //elCliente1.Id = daoCliente.ConsultarIdUltimoClientePotencial();
            //elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)daoCliente.ConsultarXId(elCliente1);

            //Assert.AreEqual(elCliente2.NombreClientePotencial, elCliente1.NombreClientePotencial);
            //Assert.AreEqual(elCliente2.RifClientePotencial, elCliente1.RifClientePotencial);
            //Assert.AreEqual(elCliente2.EmailClientePotencial, elCliente1.EmailClientePotencial);
            //Assert.AreEqual(elCliente2.PresupuestoAnual_inversion, elCliente1.PresupuestoAnual_inversion);
            //Assert.AreEqual(elCliente2.Status, elCliente1.Status);

            //daoCliente.Eliminar(elCliente1);
        }

        /// <summary>
        /// Prueba unitaria para el metodo Agregar Empleado
        /// </summary>
        public void TestAgregarEmpleado() 
        {

        }


        public void TestActivarEmpleado() 
        {

        }




        #endregion


    }
}
