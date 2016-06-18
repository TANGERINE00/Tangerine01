using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M4
{
    public class LugarDireccionM4 : Entidad
    {
        #region Atributos
        private int lugId;
        private string lugNombre;
        private string lugTipo;
        private int fk_lugId;

        private List<LugarDireccionM4> address = new List<LugarDireccionM4>();
        #endregion

        #region Constructor
        public LugarDireccionM4() { }

        public LugarDireccionM4(int lugId, string lugNombre)
        {
            this.lugId = lugId;
            this.lugNombre = lugNombre;
        }

        public LugarDireccionM4(int lugId, string lugNombre, string lugTipo, int fk_lugId)
        {
            this.lugId = lugId;
            this.lugNombre = lugNombre;
            this.lugTipo = lugTipo;
            this.fk_lugId = fk_lugId;
        }

        public LugarDireccionM4(int lugId, string lugNombre, string lugTipo, int fk_lugId,
                              List<LugarDireccionM4> address)
        {
            this.lugId = lugId;
            this.lugNombre = lugNombre;
            this.lugTipo = lugTipo;
            this.fk_lugId = fk_lugId;
            this.address = address;
        }

        public LugarDireccionM4(string lugNombre, string lugTipo)
        {
            this.lugNombre = lugNombre;
            this.lugTipo = lugTipo;
        }
        #endregion

        #region Get's Set's
        public int LugId
        {
            get
            {
                return this.lugId;
            }
        }

        public string LugNombre
        {
            get
            {
                return this.lugNombre;
            }
        }

        public string LugTipo
        {
            get
            {
                return this.lugTipo;
            }
        }

        public int Fk_lugId
        {
            get
            {
                return this.fk_lugId;
            }
        }

        public List<LugarDireccionM4> Address
        {
            get
            {
                return this.address;
            }
        }

        #endregion
    }
}
