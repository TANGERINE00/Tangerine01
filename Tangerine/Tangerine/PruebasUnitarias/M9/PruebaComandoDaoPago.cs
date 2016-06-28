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
using LogicaTangerine.Fabrica;
using LogicaTangerine;


namespace PruebasUnitarias.M9
{
    public class PruebaComandoDaoPago
    {
        #region Atributos
        private bool answer;
        private Entidad elPago;
        private Entidad elPago1;
        private Entidad factura;
        private Entidad compania;
        private List<Entidad> listaPagos;
        Comando<Entidad> _comandoEntidad;
        Comando<bool> _comandoBool;
        Comando<List<Entidad>> _comandoList;



        #endregion


        #region SetUp And TearDown

        /// <summary>
        /// SetUp para las pruebas de ComandosDAOPago
        /// </summary>
        [SetUp]
        public void init()
        {
            elPago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(1234567, 12000, "EUR", "Deposito", 1);
            compania = DominioTangerine.Fabrica.FabricaEntidades.CrearCompaniaVacia();
            factura = DominioTangerine.Fabrica.FabricaEntidades.ObtenerFacturacion();
        }



        /// <summary>
        /// TearDown para las pruebas de ComandosDAOPago
        [TearDown]
        public void clean()
        {
            elPago = null;
            elPago1 = null;
            factura = null;
            compania = null;

        }

        #endregion



        #region Test

        /// <summary>
        /// Método para probar el Comando de Agregar un Pago en la base de datos
        /// </summary>
        [Test]
        public void TestComandoAgregarPago()
        {

            LogicaTangerine.Comando<Boolean> comandoAgregarPago = FabricaComandos.cargarPago(elPago);
            answer = comandoAgregarPago.Ejecutar();

            _comandoList = FabricaComandos.ConsultarPagosTodos();
            listaPagos = _comandoList.Ejecutar();
            elPago = (Pago)listaPagos[listaPagos.Count - 1];


            Assert.IsNotNull(comandoAgregarPago);
            Assert.IsTrue(answer);

            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).codPago == 1234567);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).montoPago == 12000);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).monedaPago == "EUR");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).formaPago == "Deposito");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).idFactura == 1);

            LogicaTangerine.Comando<Boolean> comandoEliminarPago = FabricaComandos.EliminarPago(elPago);
            answer = comandoEliminarPago.Ejecutar();
            Assert.IsTrue(answer);

        }


        /// <summary>
        /// Método que permite verificar el Comando que consulta los pagos hechos por una compañia
        /// </summary>
        [Test]
        public void TestComandoPagosCompania()
        {
            ((DominioTangerine.Entidades.M8.Facturacion)factura).Id = 1;
            ((DominioTangerine.Entidades.M4.CompaniaM4)compania).Id = 1;
            LogicaTangerine.Comando<Boolean> comandoAgregarPago = FabricaComandos.cargarPago(elPago);
            answer = comandoAgregarPago.Ejecutar();
            LogicaTangerine.Comando<List<Entidad>> comandoPagosCompania = FabricaComandos.
                ConsultarPagosCompania(compania);
            listaPagos = comandoPagosCompania.Ejecutar();
            elPago1 = (Pago)listaPagos[listaPagos.Count - 1];
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago1).codPago == 1234567);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago1).montoPago == 12000);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago1).monedaPago == "EUR");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago1).idFactura == 1);
            LogicaTangerine.Comando<Boolean> comandoEliminarPago = FabricaComandos.EliminarPago(elPago);
            answer = comandoEliminarPago.Ejecutar();


        }
        #endregion

    }
}