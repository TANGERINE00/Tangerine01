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

namespace PruebasUnitarias.M8
{
    [TestFixture]
    public class PruebasDatosFactura
    {
        #region Atributos

        private Facturacion _laFactura;
        private List<Entidad> _listaFactura;
        private bool _respuesta;
        private DateTime _fecha;
        private IDaoFactura _DAO;

        #endregion

        #region SetUp y TearDown

        [SetUp]
        public void init()
        {
            _fecha = new DateTime(2016, 01, 02);
            _DAO = (IDaoFactura)FabricaDAOSqlServer.ObtenerDAOFactura();
            _laFactura = (Facturacion)FabricaEntidades.ObtenerFacturacion(_fecha, _fecha, 100, 101,
                "Dolares", "Proyecto de diseño", 0, 1, 1);
        }

        #endregion

        #region Pruebas Unitarias

        /// <summary>
        /// Prueba que permite verificar el insertar de una Factura en la base de datos
        /// </summary>
        [Test]
        public void PruebaAgregarFactura()
        {
            //Agregamos la factura
            _respuesta = _DAO.Agregar(_laFactura);
            _listaFactura = _DAO.ConsultarTodos();
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
            Assert.AreEqual(true, _DAO.DeleteFactura(_listaFactura[_listaFactura.Count - 1]));

        }

        #endregion
    }
}