using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    class SeguimientoLead
    {
        #region Atributos
        private int seg_id;
        private DateTime seg_fecha;
        private String seg_tipo;
	    private String seg_motivo;
        private int fk_cli_pot;
        #endregion

        #region get´s y set´s
        public int Seg_id 
        {
            get 
            {
                return this.seg_id;
            }
            set
            {
                this.seg_id = value;
            }
        }

        public DateTime Seg_fecha 
        {
            get
            {
                return this.seg_fecha;
            }
            set
            {
                this.seg_fecha = value;
            }
        }

        public String Seg_tipo
        {
            get 
            {
                return this.seg_tipo;
            }
            set 
            {
                this.seg_tipo = value;
            }
        }

        public String Seg_motivo
        {
            get
            {
                return this.seg_motivo;
            }
            set
            {
                this.seg_motivo = value;
            }
        }

        public int Fk_cli_pot
        {
            get
            {
                return this.fk_cli_pot;
            }
            set
            {
                this.fk_cli_pot = value;
            }
        }
        #endregion 

        #region Constructor
        //<summary>
        //Constructor de cliente potencial vacio    
        //</summary>
        public SeguimientoLead()
        {
            this.seg_id = 0;
            this.seg_fecha = DateTime.Now;
            this.seg_tipo = "";
            this.seg_motivo = "";
            this.fk_cli_pot = 0;
        }

        //<summary>
        //Constructor de cliente potencial completo    
        //</summary>
        //<param name="id">identificador del registro en la BD</param>
        //<param name="fecha">fecha de registro</param>
        //<param name="tipo">tipo de registro sobre seguimiento (llamada o visita)</param>
        //<param name="motivo">Motivo de registro de seguimiento</param>
        //<param name="fk">Rferencia del cliente potencial</param>
        public SeguimientoLead(int id, DateTime fecha, String tipo, String motivo, int fk)
        {
            this.seg_id = id;
            this.seg_fecha = fecha;
            this.seg_tipo = tipo;
            this.seg_motivo = motivo;
            this.fk_cli_pot = fk;
        }

        //<summary>
        //Constructor de cliente potencial para registro de seguimiento    
        //</summary>
        //<param name="tipo">tipo de registro sobre seguimiento (llamada o visita)</param>
        //<param name="motivo">Motivo de registro de seguimiento</param>
        //<param name="fk">Rferencia del cliente potencial</param>
        public SeguimientoLead(String tipo, String motivo, int fk)
        {
            this.seg_fecha = DateTime.Now;
            this.seg_tipo = tipo;
            this.seg_motivo = motivo;
            this.fk_cli_pot = fk;
        }
        #endregion

    }
}
