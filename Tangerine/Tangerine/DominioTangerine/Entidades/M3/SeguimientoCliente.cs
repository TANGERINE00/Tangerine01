using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M3
{
    public class SeguimientoCliente: Entidad
    {
        private int idHistoria;
        private DateTime fechaHistoria;
        private String tipoHistoria;
        private String motivoHistoria;
        private int fkCliente;

        #region get's and set's
        public int IdHistoria
        {
            get
            {
                return this.idHistoria;
            }
            set
            {
                this.idHistoria = value;
            }
        }

        public DateTime FechaHistoria
        {
            get 
            {
                return this.fechaHistoria;
            }
            set
            {
                this.fechaHistoria = value;
            }
        }

        public String TipoHistoria
        {
            get
            {
                return this.tipoHistoria;
            }
            set 
            {
                this.tipoHistoria = value;
            }
        }

        public String MotivoHistoria
        {
            get
            {
                return this.motivoHistoria;
            }
            set
            {
                this.motivoHistoria = value;
            }
        }

        public int FkCliente
        {
            get 
            {
                return this.fkCliente;
            }
            set
            {
                this.fkCliente = value;
            }
        }
        #endregion

        #region Constructores
        public SeguimientoCliente()
        {
            this.idHistoria = 0;
            this.fechaHistoria = DateTime.Now;
            this.tipoHistoria = "";
            this.motivoHistoria = "";
            this.fkCliente = 0;
        }

        public SeguimientoCliente(int id, DateTime fecha, String tipo, String motivo, int fk)
        {
            this.idHistoria = id;
            this.fechaHistoria = fecha;
            this.tipoHistoria = tipo;
            this.motivoHistoria = motivo;
            this.fkCliente = fk;
        }

        public SeguimientoCliente(String tipo, String motivo, int fk)
        {
            this.fechaHistoria = DateTime.Now;
            this.tipoHistoria = tipo;
            this.motivoHistoria = motivo;
            this.fkCliente = fk;
        }
        #endregion
    }
}
