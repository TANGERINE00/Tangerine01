using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioTangerine.Entidades.M8;
using DominioTangerine.Fabrica;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M8;
using DominioTangerine;
using DominioTangerine.Entidades.M4;
using LogicaTangerine;
using LogicaTangerine.Fabrica;

namespace PruebasUnitarias.M8
{
    [TestFixture]
    public class PruebasLogicaFactura
    {
        #region Atributos

        private Facturacion _laFactura;
        private Facturacion _laFactura2;
        private List<Entidad> _listaFactura;
        private bool _respuesta;
        private DateTime _fecha;
        private CompaniaM4 _laCompania;
        private double _monto;
        Comando<Entidad> _comandoEntidad;
        Comando<bool> _comandoBool;
        Comando<List<Entidad>> _comandoList;
        Comando<double> _comandoDouble;

        #endregion

        #region SetUp y TearDown

        [SetUp]
        public void init()
        {
            _fecha = new DateTime(2016, 01, 02);
            _laFactura = (Facturacion)FabricaEntidades.ObtenerFacturacion(_fecha, _fecha, 100, 101,
                "Dolares", "Proyecto de diseño", 0, 1, 1);
            _laCompania = (CompaniaM4)FabricaEntidades.CrearCompaniaConId(1, "CompaniaPrueba3",
                "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
        }

        [TearDown]
        public void Reset()
        {
            _laFactura = null;
            _laFactura2 = null;
            _listaFactura = null;
            _respuesta = false;
            _laCompania = null;
            _monto = 0;
            _comandoEntidad = null;
            _comandoBool = null;
            _comandoList = null;
            _comandoDouble = null;
        }

        #endregion

        #region Pruebas Unitarias

        /// <summary>
        /// Prueba que permite verificar el comando de insertar de una Factura en la base de datos
        /// </summary>
        [Test]
        public void PruebaAgregar()
        {
            //Agregamos la factura
            _comandoBool = FabricaComandos.CrearAgregarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            _comandoList = FabricaComandos.CrearConsultarTodosFactura();
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Validamos los campos
            Assert.AreEqual(true, _respuesta);
            Assert.AreEqual(_laFactura.descripcionFactura, "Proyecto de diseño");
            Assert.AreEqual(_laFactura.estatusFactura, 0);
            Assert.AreEqual(_laFactura.fechaFactura, _fecha);
            Assert.AreEqual(_laFactura.fechaUltimoPagoFactura, _fecha);
            Assert.AreEqual(_laFactura.idCompaniaFactura, 1);
            Assert.AreEqual(_laFactura.idProyectoFactura, 1);
            Assert.AreEqual(_laFactura.montoFactura, 100);
            Assert.AreEqual(_laFactura.montoRestanteFactura, 101);
            Assert.AreEqual(_laFactura.tipoMoneda, "Dolares");

            //Eliminamos la factura insertada
            _comandoBool = FabricaComandos.CrearEliminarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();
        }

        /// <summary>
        /// Prueba que permite verificar el comando de modificar de una Factura en la base de datos
        /// </summary>
        [Test]
        public void PruebaModificar()
        {
            //Agregamos la factura
            _comandoBool = FabricaComandos.CrearAgregarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            _comandoList = FabricaComandos.CrearConsultarTodosFactura();
            _listaFactura = _comandoList.Ejecutar();

            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Modificamos los datos de la factura
            _laFactura.descripcionFactura = "Proyecto de modificado";
            _laFactura.estatusFactura = 1;
            _laFactura.fechaFactura = new DateTime(2016, 02, 01);
            _laFactura.fechaUltimoPagoFactura = new DateTime(2016, 02, 01);
            _laFactura.idCompaniaFactura = 2;
            _laFactura.idProyectoFactura = 2;
            _laFactura.montoFactura = 102;
            _laFactura.montoRestanteFactura = 103;
            _laFactura.tipoMoneda = "Euros";

            //Modifico la factura
            _comandoBool = FabricaComandos.CrearModificarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            //Consulto la factura modificada
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Validamos los campos
            Assert.AreEqual(true, _respuesta);
            Assert.AreEqual(_laFactura.descripcionFactura, "Proyecto de modificado");
            Assert.AreEqual(_laFactura.estatusFactura, 1);
            Assert.AreEqual(_laFactura.fechaFactura, new DateTime(2016, 02, 01));
            Assert.AreEqual(_laFactura.fechaUltimoPagoFactura, new DateTime(2016, 02, 01));
            Assert.AreEqual(_laFactura.idCompaniaFactura, 2);
            Assert.AreEqual(_laFactura.idProyectoFactura, 2);
            Assert.AreEqual(_laFactura.montoFactura, 102);
            Assert.AreEqual(_laFactura.montoRestanteFactura, 103);
            Assert.AreEqual(_laFactura.tipoMoneda, "Euros");

            //Eliminamos la factura insertada
            _comandoBool = FabricaComandos.CrearEliminarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();
        }

        /// <summary>
        /// Prueba que permite verificar el comando de consultar de una Factura por id en la base de datos
        /// </summary>
        [Test]
        public void PruebaConsultarXId()
        {
            //Agregamos la factura
            _comandoBool = FabricaComandos.CrearAgregarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            _comandoList = FabricaComandos.CrearConsultarTodosFactura();
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Buscamos la factura especifica (por su id)
            _comandoEntidad = FabricaComandos.CrearConsultarXIdFactura(_laFactura);
            _laFactura2 = (Facturacion)_comandoEntidad.Ejecutar();

            //Validamos los campos
            Assert.AreEqual(true, _respuesta);
            Assert.AreEqual(_laFactura2.Id, _laFactura.Id);
            Assert.AreEqual(_laFactura2.descripcionFactura, "Proyecto de diseño");
            Assert.AreEqual(_laFactura2.estatusFactura, 0);
            Assert.AreEqual(_laFactura2.fechaFactura, _fecha);
            Assert.AreEqual(_laFactura2.fechaUltimoPagoFactura, _fecha);
            Assert.AreEqual(_laFactura2.idCompaniaFactura, 1);
            Assert.AreEqual(_laFactura2.idProyectoFactura, 1);
            Assert.AreEqual(_laFactura2.montoFactura, 100);
            Assert.AreEqual(_laFactura2.montoRestanteFactura, 101);
            Assert.AreEqual(_laFactura2.tipoMoneda, "Dolares");

            //Eliminamos la factura insertada
            _comandoBool = FabricaComandos.CrearEliminarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();
        }

        /// <summary>
        /// Prueba que permite verificar el comando de consultar todas las Factura en la base de datos
        /// </summary>
        [Test]
        public void PruebaConsultarTodos()
        {
            //Agregamos la factura
            _comandoBool = FabricaComandos.CrearAgregarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            _comandoList = FabricaComandos.CrearConsultarTodosFactura();
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Validamos los campos
            Assert.Greater(_listaFactura.Count, 0);

            //Eliminamos la factura insertada
            _comandoBool = FabricaComandos.CrearEliminarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();
        }

        /// <summary>
        /// Prueba que permite verificar el comando de eliminar una Factura en la base de datos
        /// </summary>
        [Test]
        public void PruebaDeleteFactura()
        {
            //Agregamos la factura
            _comandoBool = FabricaComandos.CrearAgregarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            _comandoList = FabricaComandos.CrearConsultarTodosFactura();
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Eliminamos la factura insertada
            _comandoBool = FabricaComandos.CrearEliminarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            //Consultamos todas las facturas para validar el id de la eliminada
            _listaFactura = _comandoList.Ejecutar();

            //Validamos los campos
            Assert.AreEqual(true, _respuesta);
            foreach (Facturacion _laFactura2 in _listaFactura)
            {
                Assert.AreNotEqual(_laFactura.Id, _laFactura2.Id);
            }
        }

        /// <summary>
        /// Prueba que permite verificar el comando de Annular una Factura en la base de datos
        /// </summary>
        [Test]
        public void PruebaAnnularFactura()
        {
            //Agregamos la factura
            _comandoBool = FabricaComandos.CrearAgregarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            _comandoList = FabricaComandos.CrearConsultarTodosFactura();
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Cambiamos el status de la factura
            _comandoBool = FabricaComandos.CrearAnularFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            //Consultamos la factura
            _comandoEntidad = FabricaComandos.CrearConsultarXIdFactura(_laFactura);
            _laFactura2 = (Facturacion)_comandoEntidad.Ejecutar();

            //Validamos los campos
            Assert.AreEqual(true, _respuesta);
            Assert.AreEqual(_laFactura2.estatusFactura, 2);

            //Eliminamos la factura insertada
            _comandoBool = FabricaComandos.CrearEliminarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();
        }

        /// <summary>
        /// Prueba que permite verificar el comando de consultar todas las Facturas de una compania
        /// </summary>
        [Test]
        public void PruebaContactFacturasCompania()
        {
            //Agregamos la factura
            _comandoBool = FabricaComandos.CrearAgregarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            _comandoList = FabricaComandos.CrearConsultarFacturasCompania(_laCompania);
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Validamos los campos
            Assert.GreaterOrEqual(_listaFactura.Count, 1);

            //Eliminamos la factura insertada
            _comandoBool = FabricaComandos.CrearEliminarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();
        }

        /// <summary>
        /// Prueba que permite verificar el comando de consultar todas las Facturas pagadas de una compania
        /// </summary>
        [Test]
        public void PruebaContactFacturasPagadasCompania()
        {
            //Agregamos la factura
            _laFactura.estatusFactura = 1;//Factura pagada
            _comandoBool = FabricaComandos.CrearAgregarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            _comandoList = FabricaComandos.CrearConsultarFacturasPagadasCompania(_laCompania);
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Validamos los campos
            Assert.GreaterOrEqual(_listaFactura.Count, 1);
            Assert.AreEqual(_laFactura.estatusFactura, 1);

            //Eliminamos la factura insertada
            _comandoBool = FabricaComandos.CrearEliminarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();
        }

        /// <summary>
        /// Prueba que permite verificar el comando de monto restante de una Factura en la base de datos
        /// </summary>
        [Test]
        public void PruebaContactMontoRestanteFactura()
        {
            //Agregamos la factura
            _comandoBool = FabricaComandos.CrearAgregarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            _comandoList = FabricaComandos.CrearConsultarTodosFactura();
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Consultamos el monto restante
            _comandoDouble = FabricaComandos.CrearBuscarMontoRestanteFactura(_laFactura);
            _monto = _comandoDouble.Ejecutar();

            //Validamos los campos
            Assert.AreEqual(101, _monto);

            //Eliminamos la factura insertada
            _comandoBool = FabricaComandos.CrearEliminarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();
        }

        /// <summary>
        ///Prueba que permite verificar el comando de si ya existe una factura para una fecha, proyecto y compañia dada
        /// </summary>
        [Test]
        public void PruebaCheckExistingInvoice()
        {
            //Agregamos la factura
            _comandoBool = FabricaComandos.CrearAgregarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            _comandoList = FabricaComandos.CrearConsultarTodosFactura();
            _listaFactura = _comandoList.Ejecutar();
            _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];

            //Validamos los campos
            _comandoBool = FabricaComandos.CrearSearchExistingBill(_laFactura);
            _respuesta = _comandoBool.Ejecutar();
            Assert.AreEqual(true, _respuesta);

            //Eliminamos la factura insertada
            _comandoBool = FabricaComandos.CrearEliminarFactura(_laFactura);
            _respuesta = _comandoBool.Ejecutar();

            //Validamos que no exista
            _comandoBool = FabricaComandos.CrearSearchExistingBill(_laFactura);
            _respuesta = _comandoBool.Ejecutar();
            Assert.AreEqual(false, _respuesta);
        }

        #endregion
    }
}