using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Fabrica;
using DominioTangerine.Entidades.M4;
using DominioTangerine;
using LogicaTangerine.Fabrica;
using LogicaTangerine;
using System.Globalization;

namespace PruebasUnitarias.M10
{
    [TestFixture]
    public class PruebaLogica
    {
         #region Atributos
        private Entidad theEmpleado;
        private Entidad theEmpleado2;
        private Empleado consultaEmpleado;
        private List<Empleado> theEmpleados;
        private List<Entidad> theDireccion;
        private List<Cargo> theCargos;
        private List<Entidad> paises;
        private int empleadoId;
        private string pais;
        private bool answer;
        private Entidad theCargo;
        private string pnombre;
        private string snombre;
        private string papellido;
        private string sapellido;
        private string genero;
        private int cedula;
        private DateTime fechaNac;
        private CultureInfo cultura;
        private string status;
        private string estudio;
        private string correo;
        private int id;
        private Entidad Pais;
        Comando<Entidad> ComandoEntidad;
        Comando<Boolean> ComandoBooleano;
        Comando<List<Entidad>> ComandoLista;


        #endregion

        #region Setup&TearDown

        [SetUp]
        public void setup()
        {
          
        //     public void pruebaAgregarResultadoKata()
        //{
        //    listaEntidad = new List<Entidad>();
        //    entidad = DominioSKD.Fabrica.FabricaEntidades.ObtenerResultadoKata();
        //    ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Inscripcion.Id = 4;
        //    ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado1 = 2;
        //    ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado2 = 3;
        //    ((DominioSKD.Entidades.Modulo11.ResultadoKata)entidad).Jurado3 = 3;
        //    listaEntidad.Add(entidad);
        //    Comando<bool> comando = FabricaComandos.ObtenerComandoAgregarResultadoKata(listaEntidad);
        //    bool a = comando.Ejecutar();
        //    Assert.IsTrue(a);
         
        //}
            Pais = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEstadoM10();
            ((DominioTangerine.Entidades.M10.LugarDireccion)Pais).LugNombre = "Venezuela";
            id = 100;
            List<DominioTangerine.Entidades.M10.LugarDireccion> direccion = new List<DominioTangerine.Entidades.M10.LugarDireccion>();
            pnombre = "Eduardo";
            snombre = "José";
            papellido = "Pacheco";
            sapellido = "Aguirre";
            genero = "Masculino";
            cedula = 19563263;
            fechaNac = DateTime.ParseExact("08/10/1989","MM/dd/yyyy", CultureInfo.InvariantCulture);
            status = "Activo";
            estudio = "Profesional";
            correo = "eddcold@mail.com";
                        
            theCargo =FabricaEntidades.CrearEntidadCargo("Gerente", "Gerente de proyectos de software",
                                    DateTime.ParseExact("04/01/2016", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                    "Tiempo completo", Double.Parse("60"));
            
            
            direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Venezuela", "Pais"));
            direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Distrito Capital", "Estado"));
            direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Caracas", "Ciudad"));
            direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion("Plaza Sucre", "Direccion"));



            theEmpleado = FabricaEntidades.CrearEntidadEmpleado(0, pnombre, snombre, papellido,
                                               sapellido, genero,
                                               cedula,
                                               fechaNac,
                                               status, estudio, correo, theCargo,
                                               direccion);

            theEmpleado2 = FabricaEntidades.AgregarEmpledoM10();
            ((DominioTangerine.Entidades.M10.EmpleadoM10)theEmpleado2).emp_id = 100;
            
            empleadoId = 1;
            pais = "Venezuela";
            consultaEmpleado = new Empleado();





            //Empleado1 = FabricaEntidades.CrearEntidadCompaniaM4Llena(5, "CompaniaPrueba3", "J-111111113", "asd@asdddd.com", "3434234", "ASS", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            //theCompany1 = FabricaEntidades.CrearEntidadCompaniaM4Llena(1, "CompaniaPrueba4", "J-111111114", "asdd@asddddd.com", "34342344", "AAS", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            //Lugar1 = FabricaEntidades.CrearEntidadLugarM4(3, "Zulia");
        }

        [TearDown]
        public void clean()
        {
            //DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            //theCompany2 = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(), "CompaniaPrueba3", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            //answer = daoCompania.DeleteCompany(theCompany2);
            //theCompany = null;
            //theCompany1 = null;
            ComandoEntidad=null;
            ComandoBooleano = null;
            ComandoLista = null;
        }
        #endregion

        #region Tests

        /// <summary>
        /// Prueba Comando Agregar Empleado
        /// </summary>
        [Test]
        public void TestComandoAgregarEmpleado()
        {           
           
            //Se agrega un empleado
            Comando<bool> Comand = FabricaComandos.ComandoAgregarEmpleado(theEmpleado);
            Assert.IsTrue(Comand.Ejecutar());

           // ComandoLista = FabricaEntidades.ConsultarEmpleados;
            


        }

        /// <summary>
        /// Prueba Comando Consultar Empleado
        /// </summary>
        [Test]
        public void TestComandoConsultarEmpleado()
        {

            Comando<List<Entidad>> Comand = FabricaComandos.ConsultarEmpleados();
            Assert.IsNotEmpty(Comand.Ejecutar());
            
        }

        /// <summary>
        /// Prueba Comando Consultar por Id
        /// </summary>
        [Test]
        public void TestComandoConsultarPorId()
        {            
            
            Comando<Entidad> Comand = FabricaComandos.ConsultarIdEmpleado(theEmpleado);            
            Assert.AreEqual(((DominioTangerine.Entidades.M10.EmpleadoM10) Comand.Ejecutar()).emp_id,100);            
        }

        /// <summary>
        /// Prueba Comando Cambiar estado de estatus de un empleado
        /// </summary>
        [Test]
        public void TestComandoCambiarStatus()
        {

            Entidad estatusId = DominioTangerine.Fabrica.FabricaEntidades.ConsultarEmpleados();
            estatusId.Id = id;
            Comando<bool> Comando = LogicaTangerine.Fabrica.FabricaComandos.HabilitarEmpleado(estatusId);            
            Assert.IsTrue(Comando.Ejecutar());

        }

        /// <summary>
        /// Prueba para obtener la lista de todos los cargos
        /// </summary>
        [Test]
        public void TestObtenerCargos()
        {
            Comando <List<Entidad>> Comando =FabricaComandos.ObtenerFabricaCargo();
            List<Entidad> listaCargo = Comando.Ejecutar();
            Assert.IsNotEmpty(listaCargo);

        }

        /// <summary>
        /// Prueba para obtener la lista de todos los estados
        /// </summary>
        [Test]
        public void TestObtenerEstados()
        {
            Comando<List<Entidad>> Comando = FabricaComandos.ObtenerFabricaEstado(Pais);
            List<Entidad> ListaEstado = Comando.Ejecutar();
            Assert.IsNotEmpty(ListaEstado);
        }
        /// <summary>
        /// Prueba para obtener la lista de todos los paises
        /// </summary>
        [Test]
        public void TestObtenerPaises()
        {
            Comando<List<Entidad>> Comando = FabricaComandos.ObtenerFabricaPaises();
            List<Entidad> ListaPais = Comando.Ejecutar();
            Assert.IsNotEmpty(ListaPais);
        }
        
        #endregion

    }
}
