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
using System.Globalization;
using DominioTangerine.Entidades.M2;
using DatosTangerine.Fabrica;

namespace PruebasUnitarias.M10
{
    [TestFixture]
    public class PruebasDAOEmpleado
    {
        #region Atributos
        private string pnombre;
        private string snombre;
        private string papellido;
        private string sapellido;
        private string genero;
        private int cedula;
        private DateTime fechaNac;
        private string status;
        private string estudio;
        private string correo;
        private Entidad Pais;
        private Entidad elCargo;
        private Double Salario;
        private string Telefono;
        public Empleado theEmpleado;
        private DominioTangerine.Entidades.M10.EmpleadoM10 elEmpleado1, elEmpleado2, elEmpleado3, elEmpleado4;
        public bool respuesta;
        public List<Entidad> listEmpleados;
        public List<Entidad> listLugar;
        public List<Entidad> listCargo;
        //public DominioTangerine.Entidades.M10.Cargo elCargo;
        private List<DominioTangerine.Entidades.M10.LugarDireccion> Direccion;
        public Empleado consultaEmpleado;
        public string pais;
        private IDAOEmpleado daoEmpleado;
        private IDAOUsuarios daoUsuario;
        private Entidad empleado;
        private int contadorEmpleados;
        private int contadorPaises;
        private int contadorEstados;
        private int contadorCargos;
        private Entidad ElUsuario;
        private Entidad ElUsuario2;
        private Entidad ElUsuarioActivo;
        private Entidad ElRol;
        #endregion

        #region SetUp y TearDown

        [SetUp]
        public void init()
        {
            pnombre = "Eduardo";
            snombre = "Jose";
            papellido = "Pacheco";
            sapellido = "Aguirre";
            genero = "Masculino";
            cedula = 19162756;
            fechaNac = DateTime.ParseExact("08/10/1989", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            status = "Activo";
            estudio = "Bachiller";
            correo = "eddcold@mail.com";
            Salario = 60;
            Telefono = "0212-7935754";
            elCargo = FabricaEntidades.CrearEntidadCargo("Gerente",
                                       DateTime.ParseExact("04/01/2016", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                       "Tiempo completo", Salario);

          

            ElRol = (RolM2)FabricaEntidades.crearRolNombre("Administrador");
            ElUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("leojma@gmail.com", "leojma", new DateTime(2015, 2, 10),
                                                                                      "Activo", ((RolM2)ElRol), 1);
            ElUsuarioActivo = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioConUsuarioYContrasena("leojma@gmail.com", "leojma");
            


            empleado = (EmpleadoM10)FabricaEntidades.CrearEntidadEmpleado(pnombre, snombre, papellido,
                                               sapellido, genero,
                                               cedula,
                                               fechaNac,
                                               status, estudio, correo, elCargo, Telefono,
                                               Direccion);
            listEmpleados = new List<Entidad>();

            listLugar = new List<Entidad>();

            daoEmpleado = FabricaDAOSqlServer.CrearDAOEmpleado();

            respuesta = false;

            contadorEmpleados = 0;
            
        }

        [TearDown]

        public void clean()
        {
            pnombre = null;
            snombre = null;
            papellido = null;
            sapellido = null;
            genero = null;
            cedula = 0;
            status = null;
            estudio = null;
            correo = null;
            ElRol = null;
            ElUsuario = null;
            ElUsuario2 = null;
            listCargo = null;
            listEmpleados = null;
            listLugar = null;
            
        }

        #endregion


        #region Test
        /// <summary>
        /// Prueba unitaria para el metodo consultar por id
        /// </summary>
        [Test]

        public void TestConsultarXIdEmpleadoDAO()
        {
            empleado = FabricaEntidades.ConsultarEmpleados();
            empleado.Id = 2;

            empleado = daoEmpleado.ConsultarXId(empleado);
            EmpleadoM10 nuevo = (EmpleadoM10)empleado;
            Assert.AreEqual(nuevo.emp_p_nombre, "Jose");
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
            Assert.AreEqual(contadorEmpleados, 3);

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
                    ep.emp_modalidad.Equals(empleados.emp_modalidad) && ep.emp_salario.Equals(empleados.emp_salario))
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

            Assert.AreEqual(contadorEmpleados, 26);
        }


        /// <summary>
        /// Prueba unitaria para el metodo obtener paises
        /// </summary>
        [Test]
        public void TestObtenerPaisesDAO() 
        {
            listLugar = daoEmpleado.ObtenerPaises();
            contadorPaises = listLugar.Count;

            Assert.AreEqual(contadorPaises, 1);
            
        }

        
        /// <summary>
        /// Prueba unitaria para el metodo ObtenerCargo
        /// </summary>
        [Test]
        public void TestObtenerCargoDAO() 
        {
            listCargo = daoEmpleado.ObtenerCargos();
            contadorCargos = listCargo.Count;

            Assert.AreEqual(contadorCargos, 2);
        }

      

        #endregion


    }
}
