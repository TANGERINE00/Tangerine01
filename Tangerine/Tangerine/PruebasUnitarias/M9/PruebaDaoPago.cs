using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M9;
using DatosTangerine.InterfazDAO.M9;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M9;



namespace PruebasUnitarias.M9
{
    [TestFixture]
    public class PruebaDaoPago
    {
        #region Atributos

        public bool answer;
        public Entidad elPago;
        public Entidad elPago1;
        public Entidad elPago2;
        // public List<Pago> listaPagos;
        #endregion


        #region SetUp And TearDown

        /// <summary>
        /// SetUp para las pruebas de DAOPago
        /// </summary>
        [SetUp]
        public void init()
        {

            elPago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(1111111111, 12000, "EUR", "Deposito", 1);

        }

        /// <summary>
        /// TearDown para las pruebas de DAOPago
        /// </summary>
        [TearDown]
        public void clean()
        {


            //IDAOPago daoPago = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPago(); ;
            //elPago2 = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(1111111111, 12000, "EUR", "Deposito", 1);
            //DominioTangerine.Entidades.M9.Pago Pago = (DominioTangerine.Entidades.M9.Pago)elPago2;

            elPago = null;
            elPago1 = null;
            elPago2 = null;

        }

        #endregion



      



        /// <summary>
        /// Método para probar el Agregar de DAOPago
        /// </summary>
        [Test]
        public void TestAgregar()
        {
            IDAOPago daoPago = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPago();

            answer = daoPago.Agregar(elPago);

            Assert.IsTrue(answer);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).codPago == 1111111111);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).montoPago == 12000);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).monedaPago == "EUR");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).formaPago == "Deposito");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).idFactura == 1);

        }

    }

}