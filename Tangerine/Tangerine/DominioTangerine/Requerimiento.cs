using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    class Requerimiento
    {
        #region Atributos

        /// <summary>
        /// Clase Requerimiento
        /// <attr name="_codigoRG">Codigo unico indentificador del requerimiento asociado a una propuesta</attr>
        /// <attr name="_descripcion">breve descripcion del requerimientos</attr>
        /// </summary>

        private string _codigoRG;
        private string _descripcion;
        #endregion
   
        #region Propiedades

        public string CodigoRG
        {
            get { return _codigoRG; }
            set { _codigoRG = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        #endregion

        #region Constructor
        public Requerimiento()
        {

        }

        public Requerimiento(string cod, string descripr)
        {
            this._codigoRG = cod;
            this._descripcion = descripr;
        }
        #endregion
    
    }
}
