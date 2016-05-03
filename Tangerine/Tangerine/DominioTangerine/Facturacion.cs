using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class Facturacion
    {
        #region Atributos

        private int _idNumeroFactura;
        private DateTime _fecha;
        private int _idCliente;
        private int _idProyecto;
        private String _descripcion;
        private double _monto;
        private double _montoRestante;

        #endregion

        #region Get´s Set´s

        /// <summary>
        /// Metodo para obtener el ID de la factura
        /// </summary>
        /// <returns>Retorna el numero de la factura</returns>
        public int getIdNumeroFactura() { return _idNumeroFactura; }

        /// <summary>
        /// Metodo para setear el ID de la factura
        /// </summary>
        /// <param name="idNumeroFactura"></param>
        public void setIdNumeroFactura( int idNumeroFactura ) { _idNumeroFactura = idNumeroFactura; }

        /// <summary>
        /// Metodo para obtener la fecha
        /// </summary>
        /// <returns>Retorna la fecha de la factura</returns>
        public DateTime getFecha() { return _fecha; }

        /// <summary>
        /// Metodo para setear la fecha
        /// </summary>
        /// <param name="fecha"></param>
        public void setFecha( DateTime fecha ) { _fecha = fecha; }

        /// <summary>
        /// Metodo para obtener el ID del cliente
        /// </summary>
        /// <returns>Retorna el ID del cliente</returns>
        public int getIdCliente() { return _idCliente; }

        /// <summary>
        /// Metodo para setear el ID del cliente
        /// </summary>
        /// <param name="idCliente"></param>
        public void setIdCliente( int idCliente ) { _idCliente = idCliente; }

        /// <summary>
        /// Metodo para obtener el ID del proyecto
        /// </summary>
        /// <returns>Retorna el ID del proyecto</returns>
        public int getIdProyecto() { return _idProyecto; }

        /// <summary>
        /// Metodo para setear el ID del proyecto
        /// </summary>
        /// <param name="idProyecto"></param>
        public void setIdProyecto( int idProyecto ) { _idProyecto = idProyecto; }

        /// <summary>
        /// Metodo para obtener la descripcion
        /// </summary>
        /// <returns>Retorna la descripcion del proyecto</returns>
        public String getDescripcion() { return _descripcion; }

        /// <summary>
        /// Metodo para setear la descripcion
        /// </summary>
        /// <param name="descripcion"></param>
        public void setDescripcion( String descripcion ) { _descripcion = descripcion; }

        /// <summary>
        /// Metodo para obtener el monto de la factura
        /// </summary>
        /// <returns>Retorna el monto de facturacion del proyecto</returns>
        public double getMonto() { return _monto; }

        /// <summary>
        /// Metodo para setear el monto de la factura
        /// </summary>
        /// <param name="monto"></param>
        public void setMonto( double monto ) { _monto = monto; }

        /// <summary>
        /// Metodo para obtener el monto restante de la factura
        /// </summary>
        /// <returns>Retorna el monto restante de facturacion del proyecto</returns>
        public double getMontoRestante() { return _montoRestante; }

        /// <summary>
        /// Metodo para setear el monto restante de la factura
        /// </summary>
        /// <param name="montoRestante"></param>
        public void setMontoRestante( double montoRestante ) { _montoRestante = montoRestante; }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase.
        /// </summary>
        public Facturacion() { }

        /// <summary>
        /// Constructor con los atributos.
        /// </summary>
        /// <param name="idNumeroFactura"></param>
        /// <param name="fecha"></param>
        /// <param name="idCliente"></param>
        /// <param name="idProyecto"></param>
        /// <param name="descripcion"></param>
        /// <param name="monto"></param>
        /// <param name="montoRestante"></param>
        public Facturacion( int idNumeroFactura, DateTime fecha, int idCliente, int idProyecto, String descripcion, double monto, double montoRestante )
        {
            _idNumeroFactura = idNumeroFactura;
            _fecha = fecha;
            _idCliente = idCliente;
            _idProyecto = idProyecto;
            _descripcion = descripcion;
            _monto = monto;
            _montoRestante = montoRestante;
        }

        #endregion
    }
}
