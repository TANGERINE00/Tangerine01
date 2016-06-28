using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M10;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M10;
using System.Collections;
using DominioTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;

namespace PruebasUnitarias.M10
{
    [TestFixture]
    public class PruebasDAOEmpleado
    {
        #region Atributos
        public Empleado theEmpleado;
        private DominioTangerine.Entidades.M10.EmpleadoM10 elEmpleado1, elEmpleado2, elEmpleado3, elEmpleado4;
        public bool respuesta;
        public List<Entidad> listEmpleados;
        public List<Entidad> listLugar;
        public List<Entidad> listCargo;
        public DominioTangerine.Entidades.M10.Cargo elCargo;
        public Empleado consultaEmpleado;
        public string pais;
        private IDAOEmpleado daoEmpleado;
        private IDAOUsuarios daoUsuario;
        private Entidad empleado;
        private int contadorEmpleados;
        private int contadorPaises;
        private int contadorEstados;
        private int contadorCargos;
        #endregion

        #region SetUp y TearDown

        [SetUp]
        public void init()
        {
           
        }

        [TearDown]

        public void clean()
        {
            elEmpleado1 = null;
            elEmpleado2 = null;
            elEmpleado3 = null;
            elEmpleado4 = null;
        }

        #endregion


        #region Test
        /// <summary>
        /// Prueba unitaria para el metodo consultar por id
        /// </summary>
        [Test]

        public void TestConsultarXIdEmpleadoDAO()
        {
            Entidad empleado = FabricaEntidades.ConsultarEmpleados();
            empleado.Id = 2;

            empleado = daoEmpleado.ConsultarXId(empleado);
            EmpleadoM10 nuevo = (EmpleadoM10)empleado;
            Assert.AreEqual(nuevo.emp_p_nombre, "Armando");
        }

        /// <summary>
        /// Prueba unitaria para el metodo Agregar Empleado
        /// </summary>
        /// 
        [Test]
        public void TestAgregarEmpleadoDAO() 
        {
            respuesta = daoEmpleado.Agregar(empleado);
            Assert.True(respuesta);

            listEmpleados = daoEmpleado.ConsultarTodos();
            contadorEmpleados = listEmpleados.Count;
            Assert.AreEqual(contadorEmpleados, 2);

            EmpleadoM10 empleados = (EmpleadoM10)empleado;
            bool verificar = false;

            foreach (Entidad e in listEmpleados) 
            {
                EmpleadoM10 ep = (EmpleadoM10)e;

                if (ep.emp_p_nombre.Equals(empleados.emp_p_nombre) && ep.emp_s_nombre.Equals(empleados.emp_s_nombre) &&
                ep.emp_p_apellido.Equals(empleados.emp_p_apellido) && ep.emp_s_apellido.Equals(empleados.emp_s_apellido)
                && ep.emp_genero.Equals(empleados.emp_genero) && ep.emp_cedula.Equals(empleados.emp_cedula) &&
                    ep.emp_fecha_nac.Equals(empleados.emp_fecha_nac) && ep.emp_estudio.Equals(empleados.emp_estudio) &&
                    ep.emp_email.Equals(empleados.emp_email) && ep.jobs.Nombre.Equals(empleados.jobs.Nombre) &&
                    ep.jobs.FechaContratacion.Equals(empleados.jobs.FechaContratacion) &&
                    ep.emp_modalidad.Equals(empleados.emp_modalidad) && ep.emp_salario.Equals(empleados.emp_salario) &&
                    ep.Emp_Direccion.Equals(empleados.Emp_Direccion))
                {
                    verificar = true;
                }
            }

            Assert.IsTrue(verificar);
        }

        /// <summary>
        /// Prueba unitaria para el metodo consultar todos
        /// </summary>
        [Test]
        public void TestConsultarTodosDAO() 
        {
            listEmpleados = daoEmpleado.ConsultarTodos();
            contadorEmpleados = listEmpleados.Count;

            Assert.AreEqual(contadorEmpleados, 3);
        }


        /// <summary>
        /// Prueba unitaria para el metodo obtener paises
        /// </summary>
        [Test]
        public void TestObtenerPaisesDAO() 
        {
            listLugar = daoEmpleado.ObtenerPaises();
            contadorPaises = listLugar.Count;

            Assert.AreEqual(contadorPaises, 3);
            
        }

        /// <summary>
        /// Prueba unitaria para el metodo Obtener estados
        /// </summary>
        [Test]
        public void TestObtenerEstadosDAO()
        {
            Entidad lugar = FabricaEntidades.ObtenerEstadoM10();
            lugar.Id = 2;

            listLugar = daoEmpleado.ObtenerEstados(lugar);
            contadorPaises = listLugar.Count;

            Assert.AreEqual(contadorEstados, 3);

        }

        /// <summary>
        /// Prueba unitaria para el metodo ObtenerCargo
        /// </summary>
        [Test]
        public void TestObtenerCargoDAO() 
        {
            listCargo = daoEmpleado.ObtenerCargos();
            contadorCargos = listCargo.Count;

            Assert.AreEqual(contadorCargos, 3);
        }

      

        #endregion


    }
}
