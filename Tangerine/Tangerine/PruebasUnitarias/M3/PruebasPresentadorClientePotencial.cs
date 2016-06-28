using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M3;
using DatosTangerine.InterfazDAO.M3;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M3;

namespace PruebasUnitarias.M3
{
    [TestFixture]
    public class PruebasPresentadorClientePotencial
    {
        #region Atributos

        private ClientePotencial elCliente1, elCliente2, elCliente3, elCliente4;
        private Boolean respuesta;
        private List<Entidad> losClientes;
        private DatosTangerine.InterfazDAO.M3.IDAOClientePotencial daoCliente;
        private List<Entidad> llamadas, visitas;
        private SeguimientoCliente elSeguimiento;

        #endregion

        #region SetUp y TearDown
        /// <summary>
        /// SetUp para las pruebas de DAOClientePotencial
        /// </summary>
        [SetUp]
        public void Init()
        {
            elCliente1 = new ClientePotencial("Test2", "J-121212-F", "prueba@gmail.com", 121212, 1);
            elCliente2 = new ClientePotencial();
            elCliente3 = new ClientePotencial("Test2Cambio", "J-121212-F", "cambio@gmail.com", 746, 1);
            elCliente4 = new ClientePotencial("Test3", "J-121212-F", "prueba@gmail.com", 121212, 0);
            losClientes = new List<Entidad>();
            elSeguimiento = new SeguimientoCliente(new DateTime(2016, 05, 02), "Llamada", "Prueba de seguimiento", 5);

        }

        /// <summary>
        /// TearDown para las pruebas de DAOClientePotencial
        /// </summary>
        [TearDown]
        public void Clean()
        {
            elCliente1 = null;
            elCliente2 = null;
            elCliente3 = null;
            elCliente4 = null;
        }
        #endregion

        /// <summary>
        /// Método para probar el ConsultarXId de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestPresentadorClientePotencial()
        {
            

        }
    }
}
