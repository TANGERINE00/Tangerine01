using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.M4;
using DominioTangerine.Fabrica;
using DominioTangerine.Entidades.M4;
using DominioTangerine;
using DatosTangerine.M4;
using LogicaTangerine.Fabrica;
using LogicaTangerine;

namespace PruebasUnitarias.M4
{
    [TestFixture]
    public class PruebaLogica
    {
        #region Atributos
        public Entidad theCompany;
        public Entidad theCompany1;
        public Entidad theCompany2;
        public Entidad Lugar1;
        public bool answer;
        public bool answer1;
        #endregion

        #region Setup&TearDown

        [SetUp]
        public void setup()
        {
            theCompany = FabricaEntidades.CrearEntidadCompaniaM4Llena(5,"CompaniaPrueba3", "J-111111113", "asd@asdddd.com", "3434234", "ASS", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            theCompany1 = FabricaEntidades.CrearEntidadCompaniaM4Llena(1,"CompaniaPrueba4", "J-111111114", "asdd@asddddd.com", "34342344", "AAS", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            Lugar1 = FabricaEntidades.CrearEntidadLugarM4(3,"Zulia");
        }

        [TearDown]
        public void clean()
        {
            DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            theCompany2 = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(), "CompaniaPrueba3", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            answer = daoCompania.DeleteCompany(theCompany2);
            theCompany = null;
            theCompany1 = null;
        }
        #endregion

        #region Tests

        /// <summary>
        /// Prueba que permite verificar el agregar una compañía a la base de datos.
        /// </summary>
        [Test]
        public void TestComandoAgregarCompania()
        {
            DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            Comando<Entidad> Comand2 = FabricaComandos.CrearConsultarCompania(DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(),"CompaniaPrueba3", "J-111111113", "asd@asdddd.com", "3434234", "ASS", new DateTime(2015, 2, 10), 1, 100, 30, 1));
            theCompany2 = Comand2.Ejecutar();
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).Id == daoCompania.ConsultLastCompanyId());
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).NombreCompania == "CompaniaPrueba3");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).RifCompania == "J-111111113");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).EmailCompania == "asd@asdddd.com");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).TelefonoCompania == "3434234" );
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).AcronimoCompania == "ASS");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).FechaRegistroCompania == new DateTime(2015, 2, 10));
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).StatusCompania == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).PresupuestoCompania == 100);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).PlazoPagoCompania == 30);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).IdLugar == 1);
          
        }

        /// <summary>
        /// Prueba que permite la búsqueda de una compañía a la base de datos
        /// </summary>
        [Test]
        public void TestComandoConsultarCompania()
        {

            DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            Comando<Entidad> Comand2 = FabricaComandos.CrearConsultarCompania(theCompany1);
            theCompany2 = Comand2.Ejecutar();
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).Id == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).NombreCompania == "GianFran CO");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).RifCompania == "J-236861976");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).EmailCompania == "giantufano@gmail.com");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).TelefonoCompania == "0412-2362151");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).AcronimoCompania == "GFC");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).FechaRegistroCompania == new DateTime(2016, 12, 12));
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).StatusCompania == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).PresupuestoCompania == 10000000);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).PlazoPagoCompania == 30);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).IdLugar == 5);
            
        }

        /// <summary>
        /// Prueba que permite verificar el consultar de todas las companías en la base de datos.
        /// </summary>
        [Test]
        public void TestComandoConsultarTodasCompanias()
        {
            DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            Comando<List<Entidad>> Comand2 = FabricaComandos.CrearConsultarTodasCompania();
            List<Entidad> companias = Comand2.Ejecutar();
            foreach (Entidad compania in companias)
            {
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
                //Consulto los lugares que son Ciudad que se hallan en la base de datos.
            }
            
        }

        /// <summary>
        /// Prueba que permite verificar el consultar de todas las companías Habilitadas en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultarCompaniasActivas()
        {
            DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            Comando <List<Entidad>> Comand2 = FabricaComandos.CrearConsultarCompaniasActivas();
            List<Entidad> companias = Comand2.Ejecutar();
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
        /// Prueba que permite deshabilitar una compania.
        /// </summary>
        [Test]
        public void TestComandoDeshabilitarCompania()
        {
            DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            theCompany2 = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(),
                "CompaniaPrueba3", "J-111111113", "asd@asdddd.com", "3434234", "ASS", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            Comando<bool> Comand2 = FabricaComandos.CrearDeshabilitarCompania(theCompany2);
            Assert.IsTrue(Comand2.Ejecutar());
            Comando<Entidad> Comand3 = FabricaComandos.CrearConsultarCompania(theCompany2);
            theCompany2 = Comand3.Ejecutar();
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).StatusCompania == 0);

        }

        /// <summary>
        /// Prueba que permite habilitar una compania.
        /// </summary>
        [Test]
        public void TestComandoHabilitarCompania()
        {
            DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            theCompany2 = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(),
                "CompaniaPrueba3", "J-111111113", "asd@asdddd.com", "3434234", "ASS", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            Comando<bool> Comand2 = FabricaComandos.CrearHabilitarCompania(theCompany2);
            Assert.IsTrue(Comand2.Ejecutar());
            Comando<Entidad> Comand3 = FabricaComandos.CrearConsultarCompania(theCompany2);
            theCompany2 = Comand3.Ejecutar();
            Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).StatusCompania == 1);
           
        }
     

        /// <summary>
        /// Prueba que permite verificar el consultar de lugares en la base de datos.
        /// </summary>
        [Test]
        public void TestComandoConsultarLugarXNombreID()
        {
            DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            Comando<List<Entidad>> Comand2 = FabricaComandos.CrearConsultarLugarXNombreID();
            List<Entidad> lugares = Comand2.Ejecutar();
            foreach (Entidad lugar in lugares)
            {
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.LugarDireccionM4)lugar).LugId);
                Assert.IsNotNull(((DominioTangerine.Entidades.M4.LugarDireccionM4)lugar).LugNombre);
            }

           
        }
        

        /// <summary>
        /// Prueba que permite Consultar Lugar por id.
        /// </summary>
        [Test]
        public void TestComandoConsultarLugarxID()
        {
            DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            Comando<Entidad> Comand2 = FabricaComandos.CrearConsultarLugarXID(Lugar1);
            Entidad lugar = Comand2.Ejecutar();
            Assert.IsTrue(((DominioTangerine.Entidades.M4.LugarDireccionM4)lugar).LugId == 3);
            Assert.IsTrue(((DominioTangerine.Entidades.M4.LugarDireccionM4)lugar).LugNombre == "Zulia");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.LugarDireccionM4)lugar).LugTipo == "Estado");
            Assert.IsTrue(((DominioTangerine.Entidades.M4.LugarDireccionM4)lugar).Fk_lugId == 1);
            
        }

        /// <summary>
        /// Prueba que permite agregar Lugar .
        /// </summary>
        [Test]
        public void TestComandoAgregarLugar()
        {
            try
            {
                DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
                Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
                Assert.IsTrue(Comand.Ejecutar());
                Comando<bool> Comand2 = FabricaComandos.CrearAgregarLugar(Lugar1);
                Comand2.Ejecutar();
                Assert.Fail();
            }
            catch (Exception e) {
                
                Assert.IsTrue(true);
            }

        }

        /// <summary>
        /// Prueba que permite modificar Lugar .
        /// </summary>
        [Test]
        public void TestComandoModificarLugar()
        {
            try
            {
                DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
                Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
                Assert.IsTrue(Comand.Ejecutar());
                Comando<bool> Comand2 = FabricaComandos.CrearModificarLugar(Lugar1);
                Comand2.Ejecutar();
                Assert.Fail();
            }
            catch (Exception e)
            {

                Assert.IsTrue(true);
            }


        }


        /// <summary>
        /// Prueba que permite consultar todos los Lugares .
        /// </summary>
        [Test]
        public void TestComandoConsultarTodosLugar()
        {
            try
            {
                DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
                Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
                Assert.IsTrue(Comand.Ejecutar());
                Comando<List<Entidad>> Comand2 = FabricaComandos.CrearConsultarLugar();
                List<Entidad> lugar = Comand2.Ejecutar();
                Assert.Fail();
                
            }
            catch (Exception e)
            {

                Assert.IsTrue(true);
            }


        }

        /// <summary>
        /// Prueba que permite modificar un Lugar.
        /// </summary>
        [Test]
        public void TestComandoModificarCompania()
        {
            DatosTangerine.InterfazDAO.M4.IDaoCompania daoCompania = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoCompania();
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            
                Comando < bool > Comand2 = FabricaComandos.CrearModificarCompania(
                    DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(),
                    "Prueba De Datos1", "J-134214513", "asd@asdd.com", "3439485", "ADD", new DateTime(2015, 12, 12), 0, 10000, 60, 3));
                Assert.IsTrue(Comand.Ejecutar());
                Comando<Entidad> Comand3 = FabricaComandos.CrearConsultarCompania(DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(), "CompaniaPrueba3", "J-111111113", "asd@asdddd.com", "3434234", "ASS", new DateTime(2015, 2, 10), 1, 100, 30, 1));
                theCompany2 = Comand3.Ejecutar();
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).Id == daoCompania.ConsultLastCompanyId());
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).NombreCompania == "Prueba De Datos1");
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).RifCompania == "J-134214513");
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).EmailCompania == "asd@asdd.com");
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).TelefonoCompania == "3439485");
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).AcronimoCompania == "ADD");
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).FechaRegistroCompania == new DateTime(2015, 12, 12));
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).StatusCompania == 0);
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).PresupuestoCompania == 10000);
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).PlazoPagoCompania == 60);
                Assert.IsTrue(((DominioTangerine.Entidades.M4.CompaniaM4)theCompany2).IdLugar == 3);
            
        }
        #endregion

    }
}
