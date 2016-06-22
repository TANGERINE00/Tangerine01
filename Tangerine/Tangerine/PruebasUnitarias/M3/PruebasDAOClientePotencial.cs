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
    public class PruebasDAOClientePotencial
    {
        #region Atributos

        private DominioTangerine.Entidades.M3.ClientePotencial elCliente1, elCliente2, elCliente3;
        Boolean respuesta;
        DatosTangerine.InterfazDAO.M3.IDAOClientePotencial daoCliente;
        int contador;

        #endregion

        #region SetUp y TearDown
        /// <summary>
        /// SetUp para las pruebas de DAOClientePotencial
        /// </summary>
        [SetUp]
        public void init()
        {
            elCliente1 = new DominioTangerine.Entidades.M3.ClientePotencial("Test2", "J-121212-F","prueba@gmail.com",121212,1);
            elCliente2 = new DominioTangerine.Entidades.M3.ClientePotencial();
        }

        /// <summary>
        /// TearDown para las pruebas de DAOClientePotencial
        /// </summary>
        [TearDown]
        public void clean()
        {
            elCliente1 = null;
        }
        #endregion

        /// <summary>
        /// Método para probar el ConsultarXId de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestConsultarXId()
        {
            IDAOClientePotencial daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
            
            respuesta = daoCliente.Agregar(elCliente1);
            elCliente1.Id = daoCliente.ConsultarIdUltimoClientePotencial();
            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)daoCliente.ConsultarXId(elCliente1);

            Assert.AreEqual(elCliente2.NombreClientePotencial,elCliente1.NombreClientePotencial);
            Assert.AreEqual(elCliente2.RifClientePotencial, elCliente1.RifClientePotencial);
            Assert.AreEqual(elCliente2.EmailClientePotencial, elCliente1.EmailClientePotencial);
            Assert.AreEqual(elCliente2.PresupuestoAnual_inversion, elCliente1.PresupuestoAnual_inversion);
            Assert.AreEqual(elCliente2.Status, elCliente1.Status);

        }

    }
}
