using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




/* no se ha podido eliminar esta clase debido a que el m10 esta haciendo referencia al mismo en vez de hacer referencia 
 * a la clase lugardireccionM4 encontrada en la carpeta entidades hora 10:00 am jueves 23/06/16 */


namespace DominioTangerine
{
    public class LugarDireccion
    {
        #region Atributos
        private int lugId;
        private string lugNombre;
        private string lugTipo;
        private int fk_lugId;

        private List<LugarDireccion> address = new List<LugarDireccion>();
        #endregion

        #region Constructor
        public LugarDireccion() { }

        public LugarDireccion(int lugId, string lugNombre)
        {
            this.lugId = lugId;
            this.lugNombre = lugNombre;
        }

        public LugarDireccion(int lugId,string lugNombre, string lugTipo, int fk_lugId) 
        {
            this.lugId = lugId;
            this.lugNombre = lugNombre;
            this.lugTipo=lugTipo;
            this.fk_lugId=fk_lugId;
        }

        public LugarDireccion(int lugId, string lugNombre, string lugTipo, int fk_lugId, 
                              List<LugarDireccion> address)
        {
            this.lugId = lugId;
            this.lugNombre = lugNombre;
            this.lugTipo = lugTipo;
            this.fk_lugId = fk_lugId;
            this.address = address;
        }

        public LugarDireccion(string lugNombre, string lugTipo)
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
            set
            {
                this.lugId = value;
            }
        }

        public string LugNombre 
        {
            get
            {
                return this.lugNombre;
            }
            set
            {
                this.lugNombre = value;
            }
        }

        public string LugTipo
        {
            get 
            {
                return this.lugTipo;
            }
            set
            {
                this.lugTipo = value;
            }
        }

        public int Fk_lugId
        {
            get 
            {
                return this.fk_lugId;
            }
            set
            {
                this.fk_lugId = value;
            }
        }

        public List<LugarDireccion> Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        #endregion

    }
}
