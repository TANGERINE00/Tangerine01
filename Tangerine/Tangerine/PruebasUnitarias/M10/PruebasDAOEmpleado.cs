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
using LogicaTangerine;
using LogicaTangerine.Fabrica;

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
        private Entidad theEmpleado2;
        private Entidad theEmpleado3;
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
        private int contadorCargos;
        private Entidad ElUsuario;       
        private Entidad ElUsuarioActivo;
        private Entidad ElRol;
        private Comando<Boolean> ComandoBooleano;
        private bool Confirma;
        private Comando<List<Entidad>> ComandoLista;
        private List<Entidad> ListaEmpleado;
        private Comando<Entidad> ComandoEntidad;
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

            Direccion = new List<DominioTangerine.Entidades.M10.LugarDireccion>();
            Direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Venezuela", "Pais"));
            Direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Distrito Capital", "Estado"));
            Direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Caracas", "Ciudad"));
            Direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Plaza Sucre", "Direccion"));

            ElRol = (RolM2)FabricaEntidades.crearRolNombre("Administrador");
            ElUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("leojma@gmail.com", "leojma", 
                new DateTime(2015, 2, 10),"Activo", ((RolM2)ElRol), 1);
            ElUsuarioActivo = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioConUsuarioYContrasena
                             ("leojma@gmail.com", "leojma");
            


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
           
            //Se agrega un empleado
            ComandoBooleano = FabricaComandos.ComandoAgregarEmpleado(empleado);
            Confirma = ComandoBooleano.Ejecutar();
            
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
            listCargo = null;
            listEmpleados = null;
            listLugar = null;
            
        }

        #endregion


        #region Test
        /// <summary>
        /// Prueba unitaria para el metodo consultar por id
        /// </summary>
        //[Test]

        //public void TestConsultarXIdEmpleadoDAO()
        //{         

        //    //Consulta todos los empleados
        //    ComandoLista = FabricaComandos.ConsultarEmpleados();
        //    ListaEmpleado = ComandoLista.Ejecutar();

        //    //Me traigo el ultimo el empleado insertado
        //    theEmpleado2 = (EmpleadoM10)ListaEmpleado[(ListaEmpleado.Count) - 1];


        //    //Envio ese empleado para que lo consulte por id

        //    theEmpleado3 = daoEmpleado.ConsultarXId(empleado);

        //    Assert.AreEqual(((EmpleadoM10)theEmpleado3).emp_id, ((EmpleadoM10)theEmpleado2).emp_id);
        //    Assert.IsNotEmpty(ComandoLista.Ejecutar());
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_p_nombre, "Eduardo");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_s_nombre, "Jose");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_p_apellido, "Pacheco");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_s_apellido, "Aguirre");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_genero, "Masculino");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_cedula.ToString(), "19162756");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_fecha_nac.ToString(), "10/8/1989 12:00:00 a. m.");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_activo, "Activo");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_nivel_estudio, "Bachiller");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_email, "eddcold@mail.com");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Nombre, "Gerente");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.FechaContratacion.ToString(), "1/4/2016 12:00:00 a. m.");
        //    Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Modalidad, "Tiempo completo");

        //}

        /// <summary>
        /// Prueba unitaria para el metodo Agregar Empleado
        /// </summary>
        /// 
        [Test]
        public void TestAgregarEmpleadoDAO()
        {
            respuesta = daoEmpleado.Agregar(empleado);
            Assert.True(respuesta);


                    
            ComandoLista = FabricaComandos.ConsultarEmpleados();
            ListaEmpleado = ComandoLista.Ejecutar();

            theEmpleado2 = (EmpleadoM10)ListaEmpleado[((ListaEmpleado.Count) - 1)];

            Assert.IsTrue(ComandoBooleano.Ejecutar());
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_p_nombre, "Eduardo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_s_nombre, "Jose");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_p_apellido, "Pacheco");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_s_apellido, "Aguirre");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_genero, "Masculino");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_cedula.ToString(), "19162756");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_fecha_nac.ToString(), "10/8/1989 12:00:00 a. m.");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_activo, "Activo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_nivel_estudio, "Bachiller");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_email, "eddcold@mail.com");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Nombre, "Gerente");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.FechaContratacion.ToString(), "1/4/2016 12:00:00 a. m.");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Modalidad, "Tiempo completo");

        }

        /// <summary>
        /// Prueba unitaria para el metodo consultar todos
        /// </summary>
        [Test]
        public void TestConsultarTodosDAO() 
        {
            listEmpleados = daoEmpleado.ConsultarTodos();

            theEmpleado2 = (EmpleadoM10)listEmpleados[(ListaEmpleado.Count) - 1];

            Assert.IsNotEmpty(listEmpleados);
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_p_nombre, "Eduardo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_s_nombre, "Jose");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_p_apellido, "Pacheco");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_s_apellido, "Aguirre");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_genero, "Masculino");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_cedula.ToString(), "19162756");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_fecha_nac.ToString(), "10/8/1989 12:00:00 a. m.");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_activo, "Activo");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_nivel_estudio, "Bachiller");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Emp_email, "eddcold@mail.com");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Nombre, "Gerente");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.FechaContratacion.ToString(), "1/4/2016 12:00:00 a. m.");
            Assert.AreEqual(((EmpleadoM10)theEmpleado2).Jobs.Modalidad, "Tiempo completo");
            

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
