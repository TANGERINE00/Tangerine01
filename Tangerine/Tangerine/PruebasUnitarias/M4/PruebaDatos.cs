using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M4;
using DominioTangerine;
using DatosTangerine.InterfazDAO.M4;
using DominioTangerine.Entidades.M4;
namespace PruebasUnitarias.M4
{
    [TestFixture]
    public class PruebasDatos
    {
        #region Atributos
        public bool answer;
        public bool answer1;
        public Entidad lacompania;
        public Entidad lacompania1;
        public Entidad lacompania2;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            lacompania = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaSinId("Touch", "J-111111111", "asd@asd.com", "3434234", "ASD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            lacompania1 = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaSinId("CompaniaPrueba3", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
         
        }

        [TearDown]
        public void clean()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            lacompania2 = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(), "CompaniaPrueba3", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            answer = daoCompania.DeleteCompany(lacompania2);
            lacompania = null;
            lacompania1 = null;
            lacompania2 = null;
            daoCompania = null;
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el insertar de una compañía en la base de datos.
        /// </summary>
        [Test]
        public void TestAgregar()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            //Inserto una compañía.
            answer = daoCompania.Agregar(lacompania);

            lacompania1 = daoCompania.ConsultarXId(DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(),"CompaniaPrueba3", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1));
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).Id == daoCompania.ConsultLastCompanyId());
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).NombreCompania == "Touch");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).RifCompania == "J-111111111");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).EmailCompania == "asd@asd.com");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).TelefonoCompania == "3434234");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).AcronimoCompania == "ASD");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).FechaRegistroCompania == new DateTime(2015, 2, 10));
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).StatusCompania == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).PresupuestoCompania == 100);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).PlazoPagoCompania == 30);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).IdLugar == 1);
        
        }

        /// <summary>
        /// Prueba que permite verificar el modificar de una compañía en la base de datos.
        /// </summary>
        [Test]
        public void TestModificar()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            //Inserto una compañía.
            answer = daoCompania.Agregar(lacompania);
            answer1 = daoCompania.Modificar(DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(), "CompaniaPrueba3", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1));
            lacompania1 = daoCompania.ConsultarXId(DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(), "CompaniaPrueba3", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1));
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).Id == daoCompania.ConsultLastCompanyId());
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).NombreCompania == "CompaniaPrueba3");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).RifCompania == "J-111134112");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).EmailCompania == "affdd@asdd.com");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).TelefonoCompania == "34342344");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).AcronimoCompania == "ADD");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).FechaRegistroCompania == new DateTime(2015, 2, 10));
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).StatusCompania == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).PresupuestoCompania == 100);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).PlazoPagoCompania == 30);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).IdLugar == 1);
        }

        /// <summary>
        /// Prueba que permite consultar compañía por su id en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultarXId()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            answer = daoCompania.Agregar(lacompania1);
            lacompania2 = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(), "CompaniaPrueb43", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            //Aplico el metodo para consultar la companía agregada anteriormente.
            lacompania1 = daoCompania.ConsultarXId(lacompania2);
            //Comparo que el id de la companía creada coincide con el id de la compañía consultada.
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).Id == daoCompania.ConsultLastCompanyId());
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).NombreCompania == "CompaniaPrueba3");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).RifCompania == "J-111134112");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).EmailCompania == "affdd@asdd.com");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).TelefonoCompania == "34342344");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).AcronimoCompania == "ADD");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).FechaRegistroCompania == new DateTime(2015, 2, 10));
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).StatusCompania == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).PresupuestoCompania == 100);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).PlazoPagoCompania == 30);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania1).IdLugar == 1);
            
        }

        /// <summary>
        /// Prueba que permite verificar el consultar del último id de una companía en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultLastCompanyId()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            answer = daoCompania.Agregar(lacompania);
            int lastid = daoCompania.ConsultLastCompanyId();
            Assert.IsTrue(lastid > 0 );
        }

        /// <summary>
        /// Prueba que permite verificar el consultar de todas las compañías en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultarTodos()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            answer = daoCompania.Agregar(lacompania);
            //Consulto todas las compañías en la base de datos.
            List<Entidad> companias = daoCompania.ConsultarTodos();
            //Recorro las compañías y verifico que su id no es nulo para corroborar que está extrayendo correctamente.
            foreach(Entidad compania in companias){
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).Id);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).NombreCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).RifCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).EmailCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).TelefonoCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).AcronimoCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).FechaRegistroCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).StatusCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).PresupuestoCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).PlazoPagoCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).IdLugar);
            }
        }

        /// <summary>
        /// Prueba que permite verificar el inhabilitar de una companía en la base de datos.
        /// </summary>
        [Test]
        public void TestDisableCompany()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            answer = daoCompania.Agregar(lacompania);
            lacompania2 = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(), "CompaniaPrueb43", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            answer1 = daoCompania.DisableCompany(lacompania2);
            //Compruebo que el metodo de inhabilitación finalizó correctamente.
            lacompania2 = daoCompania.ConsultarXId(lacompania2);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania2).StatusCompania == 0);
        }
        /// <summary>
        /// Prueba que permite verificar el habilitar de una companía en la base de datos.
        /// </summary>
        [Test]
        public void TestEnableCompany()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            answer = daoCompania.Agregar(lacompania);
            lacompania2 = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(), "CompaniaPrueb43", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            answer1 = daoCompania.EnableCompany(lacompania2);
            //Compruebo que el metodo de inhabilitación finalizó correctamente.
            lacompania2 = daoCompania.ConsultarXId(lacompania2);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)lacompania2).StatusCompania == 1);
        }

        /// <summary>
        /// Prueba que permite verificar las companias activas en la base de datos.
        /// </summary>

        [Test]
        public void TestConsultarCompaniasActivas()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            answer = daoCompania.Agregar(lacompania);

            List<Entidad> companias = daoCompania.ConsultarCompaniasActivas();
            //Recorro las compañías y verifico que su id no es nulo para corroborar que está extrayendo correctamente.
            foreach (Entidad compania in companias)
            {
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).Id);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).NombreCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).RifCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).EmailCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).TelefonoCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).AcronimoCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).FechaRegistroCompania);
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)compania).StatusCompania == 1);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).PresupuestoCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).PlazoPagoCompania);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.CompaniaM4)compania).IdLugar);
                //Consulto los lugares que son Ciudad que se hallan en la base de datos.
            }
        }


        /// <summary>
        /// Prueba que permite verificar que se pueda eliminar una compania de la base de datos.
        /// </summary>

        [Test]
        public void TestDeleteCompany()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            answer = daoCompania.Agregar(lacompania);
            answer1 = daoCompania.Agregar(lacompania1);
            answer = daoCompania.DeleteCompany(DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(), "CompaniaPrueba3", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1));
            Assert.IsTrue(answer);
    
        }
        
        
        /// <summary>
        /// Prueba que permite verificar el consultar los lugares en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultPlaces()
        {
            IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            answer = daoCompania.Agregar(lacompania);
            IDaoLugarDireccion daoLugarDireccion = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoLugarDireccion();

            List<Entidad> lugares = daoLugarDireccion.ConsultCityPlaces();
            //Recorro los lugares y verifico que su id no es nulo para corroborar que está extrayendo correctamente.
            foreach (Entidad lugar in lugares)
            {
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.LugarDireccionM4)lugar).LugId);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.LugarDireccionM4)lugar).LugNombre);
            }
        }

      
    }
}

