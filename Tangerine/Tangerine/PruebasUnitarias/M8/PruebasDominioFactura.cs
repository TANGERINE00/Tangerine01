using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioTangerine.Entidades.M8;
using DominioTangerine.Fabrica;
using DominioTangerine;
using System.Net.Mail;

namespace PruebasUnitarias.M8
{
    public class PruebasDominioFactura
    {
        #region Atributos

        private Facturacion _laFactura;
        private Entidad _laEntidad;
        private DateTime _fecha;
        private DateTime _fechaUltimoPago;
        private double _monto;
        private double _montoRestante;
        private String _tipoMoneda;
        private String _descripcion;
        private int _estatus;
        private int _idProyecto;
        private int _idCompania;
        private int _idEntidad;

        private DatosCorreo _datosCorreo;
        private String _asunto;
        private String _destinatario;
        private String _mensaje;
        private String _adjunto;

        #endregion

        #region SetUp y TearDown

        [SetUp]
        public void init()
        {
            _fecha = new DateTime(2016, 01, 02);
            _fechaUltimoPago = new DateTime(2016, 02, 02);
            _monto = 10000;
            _montoRestante = 5000;
            _tipoMoneda = "Bolivares";
            _descripcion = "Esto es una prueba de dominio";
            _estatus = 0;
            _idEntidad = 1;
            _idProyecto = 2;
            _idCompania = 3;
            _idEntidad = 4;

            _asunto = "Asunto correo";
            _destinatario = "istvanbokor8@gmail.com";
            _mensaje = "Mensaje correo";
            _adjunto = "Url adjunto";
            
        }

        [TearDown]
        public void Reset()
        {
            _laFactura = null;
            _laEntidad = null;
            _monto = 0;
            _montoRestante = 0;
            _tipoMoneda = String.Empty;
            _descripcion = String.Empty;
            _estatus = 0;
            _idProyecto = 0;
            _idCompania = 0;
            _idEntidad = 0;

            _datosCorreo = null;
            _asunto = String.Empty;
            _destinatario = String.Empty;
            _mensaje = String.Empty;
            _adjunto = String.Empty;
        }

        #endregion

        #region Pruebas Unitarias

        // Prueba unitaria del metodo ObtenerFacturacion() 
        [Test]
        public void PruebaConstructorObtenerFacturacion1()
        {
            _laFactura = (Facturacion)FabricaEntidades.ObtenerFacturacion();

            Assert.AreEqual(_laFactura.descripcionFactura, String.Empty);
            Assert.AreEqual(_laFactura.estatusFactura , 0);
            Assert.AreEqual(_laFactura.Id , 0);
            Assert.AreEqual(_laFactura.idCompaniaFactura , 0);
            Assert.AreEqual(_laFactura.idProyectoFactura , 0);
            Assert.AreEqual(_laFactura.montoFactura , 0);
            Assert.AreEqual(_laFactura.montoRestanteFactura , 0);
            Assert.AreEqual(_laFactura.tipoMoneda , String.Empty);
        }

        // Prueba unitaria del metodo ObtenerFacturacion() 
        [Test]
        public void PruebaConstructorObtenerFacturacion2()
        {
            _laFactura = (Facturacion)FabricaEntidades.ObtenerFacturacion(_fecha, _fechaUltimoPago, _monto,
            _montoRestante, _tipoMoneda, _descripcion, _estatus, _idProyecto, _idCompania);

            Assert.AreEqual(_laFactura.descripcionFactura, _descripcion);
            Assert.AreEqual(_laFactura.estatusFactura, _estatus);
            Assert.AreEqual(_laFactura.Id, 0);
            Assert.AreEqual(_laFactura.idCompaniaFactura, _idCompania);
            Assert.AreEqual(_laFactura.idProyectoFactura, _idProyecto);
            Assert.AreEqual(_laFactura.montoFactura, _monto);
            Assert.AreEqual(_laFactura.montoRestanteFactura, _montoRestante);
            Assert.AreEqual(_laFactura.tipoMoneda, _tipoMoneda);
            Assert.AreEqual(_laFactura.fechaFactura, _fecha);
            Assert.AreEqual(_laFactura.fechaUltimoPagoFactura, _fechaUltimoPago);
        }

        // Prueba unitaria del metodo ObtenerFacturacion() 
        [Test]
        public void PruebaConstructorObtenerFacturacion3()
        {
            _laFactura = (Facturacion)FabricaEntidades.ObtenerFacturacion(_idEntidad, _fecha, _fechaUltimoPago, _monto,
            _montoRestante, _tipoMoneda, _descripcion, _estatus, _idProyecto, _idCompania);

            Assert.AreEqual(_laFactura.descripcionFactura, _descripcion);
            Assert.AreEqual(_laFactura.estatusFactura, _estatus);
            Assert.AreEqual(_laFactura.Id, _idEntidad);
            Assert.AreEqual(_laFactura.idCompaniaFactura, _idCompania);
            Assert.AreEqual(_laFactura.idProyectoFactura, _idProyecto);
            Assert.AreEqual(_laFactura.montoFactura, _monto);
            Assert.AreEqual(_laFactura.montoRestanteFactura, _montoRestante);
            Assert.AreEqual(_laFactura.tipoMoneda, _tipoMoneda);
            Assert.AreEqual(_laFactura.fechaFactura, _fecha);
            Assert.AreEqual(_laFactura.fechaUltimoPagoFactura, _fechaUltimoPago);
        }

        // Prueba unitaria del metodo ObtenerDatosCorreo() 
        [Test]
        public void PruebaConstructorObtenerDatosCorreo1()
        {
            _datosCorreo = (DatosCorreo)FabricaEntidades.ObtenerDatosCorreo();

            Assert.AreEqual(_datosCorreo.adjunto, String.Empty);
            Assert.AreEqual(_datosCorreo.Id, 0);
            Assert.AreEqual(_datosCorreo.asunto, String.Empty);
            Assert.AreEqual(_datosCorreo.destinatario, String.Empty);
            Assert.AreEqual(_datosCorreo.mensjae, String.Empty);
        }

        // Prueba unitaria del metodo ObtenerDatosCorreo() 
        [Test]
        public void PruebaConstructorObtenerDatosCorreo2()
        {
            _datosCorreo = (DatosCorreo)FabricaEntidades.ObtenerDatosCorreo(_asunto, _destinatario, _mensaje);

            Assert.AreEqual(_datosCorreo.adjunto, String.Empty);
            Assert.AreEqual(_datosCorreo.Id, 0);
            Assert.AreEqual(_datosCorreo.asunto, _asunto);
            Assert.AreEqual(_datosCorreo.destinatario, _destinatario);
            Assert.AreEqual(_datosCorreo.mensjae, _mensaje);
        }

        // Prueba unitaria del metodo ObtenerDatosCorreo() 
        [Test]
        public void PruebaConstructorObtenerDatosCorreo3()
        {
            _datosCorreo = (DatosCorreo)FabricaEntidades.ObtenerDatosCorreo(_asunto, _destinatario, _mensaje, _adjunto);

            Assert.AreEqual(_datosCorreo.adjunto, _adjunto);
            Assert.AreEqual(_datosCorreo.Id, 0);
            Assert.AreEqual(_datosCorreo.asunto, _asunto);
            Assert.AreEqual(_datosCorreo.destinatario, _destinatario);
            Assert.AreEqual(_datosCorreo.mensjae, _mensaje);
        }

        #endregion
    }
}
