using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M9;
using DatosTangerine.InterfazDAO.M9;
using DatosTangerine.InterfazDAO;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M9;
using LogicaTangerine;



namespace PruebasUnitarias.M9
{
    [TestFixture]
    public class PruebaDaoPago
    {
        #region Atributos

        private bool answer;
        private Entidad elPago;
        private Entidad elPago1;
        private Entidad factura;
        private Entidad compania;
        private IDAOPago daoPago;
        private List<Entidad> listaPagos;
        private List<Entidad> listaFacturas;
        #endregion


        #region SetUp And TearDown

        /// <summary>
        /// SetUp para las pruebas de DAOPago
        /// </summary>
        [SetUp]
        public void init()
        {
            daoPago = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPago();
            elPago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(1234567, 12000, "EUR", "Deposito", 1);
            compania = DominioTangerine.Fabrica.FabricaEntidades.CrearCompaniaVacia();
            factura = DominioTangerine.Fabrica.FabricaEntidades.ObtenerFacturacion();
        }

        /// <summary>
        /// TearDown para las pruebas de DAOPago
        /// </summary>
        [TearDown]
        public void clean()
        {
            elPago = null;
            elPago1 = null;
            factura = null;
            compania = null;
            daoPago = null;
        }

        #endregion
        /// <summary>
        /// Método que permite verificar el agregar un pago en la base de datos
        /// </summary>
        [Test]
        public void TestAgregar()
        {

            answer = daoPago.Agregar(elPago);
            listaPagos = daoPago.ConsultarTodos();
            elPago = (Pago)listaPagos[listaPagos.Count - 1];

            Assert.IsTrue(answer);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).codPago == 1234567);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).montoPago == 12000);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).monedaPago == "EUR");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).formaPago == "Deposito");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).idFactura == 1);

            answer = daoPago.EliminarPago(elPago);
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Método que permite verificar el cambio de status de una factura
        /// </summary>
        [Test]
        public void TestCambiarStatus()
        {
            answer = daoPago.Agregar(elPago);
            factura.Id = ((Pago)elPago).idFactura;
            answer = daoPago.CargarStatus(((Pago)elPago).idFactura, 0);
            DatosTangerine.InterfazDAO.M8.IDaoFactura daoFact = 
                DatosTangerine.Fabrica.FabricaDAOSqlServer.ObtenerDAOFactura();
            daoFact.ConsultarXId(factura);
            Assert.IsTrue(((DominioTangerine.Entidades.M8.Facturacion)factura).estatusFactura==0);
            daoPago.EliminarPago(elPago);
        }

        [Test]
        public void TestPagosCompania()
        {
            ((DominioTangerine.Entidades.M8.Facturacion)factura).Id = 1;
            daoPago.Agregar(elPago);
            ((DominioTangerine.Entidades.M4.CompaniaM4)compania).Id= 1;
            ((DominioTangerine.Entidades.M8.Facturacion)factura).idCompaniaFactura = 1;
            listaPagos = daoPago.ConsultarPagosCompania(compania);
            elPago1 = (Pago)listaPagos[listaPagos.Count - 1];
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago1).codPago == 1234567);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago1).montoPago == 12000);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago1).monedaPago == "EUR");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago1).idFactura == 1);
            answer = daoPago.EliminarPago(elPago1);



        }
    }

}