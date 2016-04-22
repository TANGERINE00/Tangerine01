using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class Proyecto
    {
        #region Atributos

        /*------------------------------------Atributos de la clase------------------------------------------*/
        private int id_proyecto;
        private string nombre;
        private string codigo;
        private DateTime fecha_inicio;
        private DateTime fecha_estimada_fin;
        private double costo;
        private double realizacion;
        private string estatus;
        private string razon;
        private int id_propuesta;
        private int id_responsable;
        private int id_gerente;

        // esperando para integrar la clse de personas "List<empleado> empleador = new List<empleados>();"



        /*--------------------------aqui termina la declaracion de atributos------------------*/

        #endregion

        #region Constructores
        /*-----------------------constructores de la clase---------------------------------*/
        Proyecto()
        {

        }

        Proyecto(int id_proyecto,string nombre,string codigo,DateTime fecha_inicio,DateTime fecha_estimada_fin,
                  double costo,double realizacion,string estatus,string razon,int id_propuesta,int id_responsable,
                 int id_gerente)
        {
            this.id_proyecto = id_proyecto;
            this.nombre = nombre;
            this.codigo = codigo;
            this.fecha_inicio = fecha_inicio;
            this.fecha_estimada_fin = fecha_estimada_fin;
            this.costo = costo;
            this.realizacion = realizacion;
            this.estatus = estatus;
            this.razon = razon;
            this.id_propuesta = id_propuesta;
            this.id_responsable = id_responsable;
            this.id_gerente = id_gerente;
        }

        /*-----------------------aqui terminan los constructores----------------------------*/

        #endregion

        #region Get's Set's
        /*--------------------metodos get and set de la clase--------------------------*/

        public int getId_Proyecto()
        {
            return this.id_proyecto;
        }

        public void setId_Proyecto(int id_proyecto)
        {
            this.id_proyecto = id_proyecto;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public void setNombre(string Nombre)
        {
            this.nombre = Nombre;
        }

        public string getCodigo()
        {
            return this.codigo;
        }

        public void setCodigo(string Codigo)
        {
            this.codigo = Codigo;
        }

        public DateTime getFecha_inicio()
        {
            return this.fecha_inicio;
        }

        public void setFecha_inicio(DateTime Fecha_inicio)
        {
            this.fecha_inicio = Fecha_inicio;
        }

        public DateTime getFecha_estimada_fin()
        {
            return this.fecha_estimada_fin;
        }

        public void setFecha_estimada_fin(DateTime fecha_estimada_fin)
        {
            this.fecha_estimada_fin = fecha_estimada_fin;
        }

        public double getCosto()
        {
            return this.costo;
        }

        public void setCosto(double costo)
        {
            this.costo = costo;
        }

        public double getRealizacion()
        {
            return this.realizacion;
        }

        public void setRealizacion(double realizacion)
        {
            this.realizacion = realizacion;
        }

        public string getEstatus()
        {
            return this.estatus;
        }

        public void setEstatus(string estatus)
        {
            this.estatus = estatus;
        }

        public string getRazon()
        {
            return this.razon;
        }

        public void setRazon(string razon)
        {
            this.razon = razon;
        }

        public int getId_Propuesta()
        {
            return this.id_propuesta;
        }

        public void setId_Propuesta(int id_propuesta)
        {
            this.id_propuesta = id_propuesta;
        }

        public int getId_Gerente()
        {
            return this.id_gerente;
        }

        public void setId_Gerente(int id_gerente)
        {
            this.id_gerente = id_gerente;
        }

        public int getId_Responsable()
        {
            return this.id_responsable;
        }

        public void setId_Responsable(int id_responsable)
        {
            this.id_responsable = id_responsable;
        }



        /*----------------------------------Aqui terminan los metodos get y set---------------------------*/

        #endregion
    }
}