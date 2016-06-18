using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M6
{
    public class Requerimiento : Entidad
    {
        #region Atributos

        /// <summary>
        /// Clase Requerimiento
        /// <attr name="_codigoRG">Codigo unico indentificador del requerimiento asociado a una propuesta</attr>
        /// <attr name="_descripcion">breve descripcion del requerimientos</attr>
        /// </summary>

        private string _codigoRequerimiento;
        private string _descripcion;
        private string _codigoPropuesta;
        private int p1;
        private string p2;
        private string p3;
        #endregion

        #region Propiedades

        public string CodigoRequerimiento
        {
            get { return _codigoRequerimiento; }
            //set { _codigoRequerimiento = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            //set { _descripcion = value; }
        }

        public string CodigoPropuesta
        {
            get { return _codigoPropuesta; }
            //set { _codigoPropuesta = value; }
        }

        #endregion

        #region Constructor

        public Requerimiento()
        {

        }

        public Requerimiento(string codreq, string descripr, string codpro)
        {
            this._codigoRequerimiento = codreq;
            this._descripcion = descripr;
            this._codigoPropuesta = codpro;
        }

        #endregion

    }
}