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

        public bool answer;
        public Entidad elClientePotencial1;
        public Entidad elClientePotencial2;

        #endregion

        #region SetUp y TearDown
        /// <summary>
        /// SetUp para las pruebas de DAOClientePotencial
        /// </summary>
        [SetUp]
        public void init()
        {
            elClientePotencial1 = DominioTangerine.Fabrica.FabricaEntidades.CrearClientePotencial(40, "TestCorp", "J-2342434-6",
                                                                                        "prueba@gmail.com", 12121, 0,0);
        }

        /// <summary>
        /// TearDown para las pruebas de DAOClientePotencial
        /// </summary>
        [TearDown]
        public void clean()
        {
            elClientePotencial1 = null;
            elClientePotencial2 = null;
        }
        #endregion

        /// <summary>
        /// Método para probar el ConsultarXId de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestConsultarXId()
        {
            IDAOClientePotencial daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
            answer = daoCliente.Agregar(elClientePotencial1);
            //Aplico el metodo para consultar el usuario agregado anteriormente.
            elClientePotencial2 = DominioTangerine.Fabrica.FabricaEntidades.CrearClientePotencial(40, "TestCorp", "J-2342434-6",
                                                                                        "prueba@gmail.com", 12121, 0,0);
            elClientePotencial1 = daoCliente.ConsultarXId(elClientePotencial2);
            
            Assert.IsTrue(((DominioTangerine.Entidades.M3.ClientePotencial)elClientePotencial1).IdClientePotencial == 40);
            Assert.IsTrue(((DominioTangerine.Entidades.M3.ClientePotencial)elClientePotencial1).NombreClientePotencial == "TestCorp");
            Assert.IsTrue(((DominioTangerine.Entidades.M3.ClientePotencial)elClientePotencial1).RifClientePotencial == "J-2342434-6");
            Assert.IsTrue(((DominioTangerine.Entidades.M3.ClientePotencial)elClientePotencial1).EmailClientePotencial == "prueba@gmail.com");
            Assert.IsTrue(((DominioTangerine.Entidades.M3.ClientePotencial)elClientePotencial1).PresupuestoAnual_inversion == 12121);
            Assert.IsTrue(((DominioTangerine.Entidades.M3.ClientePotencial)elClientePotencial1).NumeroLlamadas == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M3.ClientePotencial)elClientePotencial1).NumeroVisitas == 5);
        }

    }
}
