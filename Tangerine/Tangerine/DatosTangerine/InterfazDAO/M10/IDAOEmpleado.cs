using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;


namespace DatosTangerine.InterfazDAO.M10
{

    public interface IDAOEmpleado : IDao<Entidad, Boolean , Entidad>
    {        
       
        //List<Entidad> ConsultarXId(Entidad empleado);    

        
        //bool AgregarEmpleado(Empleado elEmpleado);
        

        List<Entidad> ConsultarTodos();

    public interface IDAOEmpleado : IDao
    {
        /// <summary> Firma de Método para agregar un empleado </summary>
        /// <param name="elEmpleado"> de tipo Empleado</param>
        /// <returns>Retorna true cuando se agrega exitosamente</returns>
        bool AgregarEmpleado(Empleado elEmpleado);
        
        /// <summary> Firma de Método para consultar todos los empleados </summary>
        /// <param></param>
        /// <returns></returns>
        List<Entidad> ConsultarTodos();

        /// <summary>
        /// Firma de Método para modificar todos los empleados por su estatus
        /// </summary>
        /// <param name="empleadoEstatus"></param>
        /// <returns>Retorna true si fue habilitado o inhabilitado exitosamente</returns>
        bool CambiarEstatus(Entidad empleadoEstatus);       

        /// <summary>
        /// Firma de Metodo para obtener los paises
        /// </summary>
        /// <returns>Retorna los paises</returns>
        List<Entidad> ObtenerPaises();

        /// <summary>
        /// Firma de Metodo para obtener los cargos 
        /// </summary>
        /// <returns>Retorna los cargos existentes</returns>
        List<Entidad> ObtenerCargos();


        /// <summary>
        /// Firma de Metodo para obtener los estados
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        List<Entidad> ObtenerEstados(Entidad parametro);


    }
}
