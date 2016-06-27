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
        public bool answer;
        public Entidad elPago;
        public Entidad elPago1;
        public Entidad factura;
        public Entidad compania;
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
            elPago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(1111111111, 12000, "EUR", "Deposito", 1);
            compania = DominioTangerine.Fabrica.FabricaEntidades.CrearCompaniaVacia();

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
        /*public void TestComandoAgregarPago()
        {

            LogicaTangerine.Comando<Boolean> comandoAgregarPago = FabricaComandos.cargarPago(elPago);
            answer = comandoAgregarPago.Ejecutar();

            _comandoList = FabricaComandos.();
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];


            Assert.IsNotNull(comandoAgregarPago);
            Assert.IsTrue(resultado);

            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).codPago == 1111111111);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).montoPago == 12000);
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).monedaPago == "EUR");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).formaPago == "Deposito");
            Assert.IsTrue(((DominioTangerine.Entidades.M9.Pago)elPago).idFactura == 1);

            LogicaTangerine.Comando<Boolean> comandoEliminarPago = FabricaComandos.EliminarPago(elPago);
            resultado = comandoEliminarPago.Ejecutar();
            Assert.IsTrue(resultado);

        }*/


        /// <summary>
        /// Método que permite verificar el Comando que consulta los pagos hechos por una compañia
        /// </summary>
        [Test]
        public void TestComandoPagosCompania()
        {
            ((DominioTangerine.Entidades.M4.CompaniaM4)compania).Id = 1;
            LogicaTangerine.Comando<List<Entidad>> comandoPagosCompania = FabricaComandos.
                ConsultarPagosCompania(compania);
            List<Entidad> Fact = comandoPagosCompania.Ejecutar();
            Assert.IsNotNull(comandoPagosCompania);
            Assert.IsNotNull(Fact);


        }
        #endregion

    }
}