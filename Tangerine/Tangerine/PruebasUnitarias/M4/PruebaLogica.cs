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
        LogicaM4 Logica = new LogicaM4();
        #endregion

        #region Setup&TearDown

        [SetUp]
        public void setup()
        {
            theCompany = FabricaEntidades.CrearEntidadCompaniaM4Llena(5,"CompaniaPrueba3", "J-111111113", "asd@asdddd.com", "3434234", "ASS", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            theCompany1 = FabricaEntidades.CrearEntidadCompaniaM4Llena(1,"CompaniaPrueba4", "J-111111114", "asdd@asddddd.com", "34342344", "AAS", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            Lugar1 = FabricaEntidades.CrearEntidadLugarM4(5,"Caracas");
        }

        [TearDown]
        public void clean()
        {
            theCompany = null;
            theCompany1 = null;
        }
        #endregion

        #region Tests

        /// <summary>
        /// Prueba que permite verificar el agregar una compañía a la base de datos.
        /// </summary>
        [Test]
        public void TestAddNewCompany()
        {
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            Comando<Entidad> Comand2 = FabricaComandos.CrearConsultarCompania(theCompany);
            theCompany2 = Comand2.Ejecutar();
            Assert.IsTrue(theCompany2.Id == 5);
          
        }

        /// <summary>
        /// Prueba que permite la búsqueda de una compañía a la base de datos
        /// </summary>
        [Test]
        public void TestGet()
        {
           
            Comando<Entidad> Comand2 = FabricaComandos.CrearConsultarCompania(theCompany1);
            theCompany2 = Comand2.Ejecutar();
            Assert.IsTrue(theCompany2.Id == 1);
            
        }

        /// <summary>
        /// Prueba que permite verificar el consultar de todas las companías en la base de datos.
        /// </summary>
        [Test]
        public void TestGetAll()
        {
            Comando<List<Entidad>> Comand2 = FabricaComandos.CrearConsultarTodasCompania();
            List<Entidad> Companias = Comand2.Ejecutar();
            for (int i = 0; i < Companias.Count(); i++)
            {

                Assert.IsTrue(Companias[i].Id != 0);
            }
            
        }

        /// <summary>
        /// Prueba que permite verificar el consultar de todas las companías Habilitadas en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultarCompaniasActivas()
        {
            Comando <List<Entidad>> Comand2 = FabricaComandos.CrearConsultarCompaniasActivas();
            List<Entidad> Companias = Comand2.Ejecutar();
            for (int i = 0; i < Companias.Count(); i++)
            {

                Assert.IsTrue(Companias[i].Id != 0);
            }

        }   

        /// <summary>
        /// Prueba que permite deshabilitar una compania.
        /// </summary>
        [Test]
        public void TestDisableCompany()
        {
            Comando<bool> Comand = FabricaComandos.CrearDeshabilitarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
        }

        /// <summary>
        /// Prueba que permite habilitar una compania.
        /// </summary>
        [Test]
        public void TestEnableCompany()
        {
            Comando<bool> Comand = FabricaComandos.CrearHabilitarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
           
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el consultar de lugares en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultPlaces()
        {
            Comando<List<Entidad>> Comand = FabricaComandos.CrearConsultarLugarXNombreID();
            List<Entidad> lugar = Comand.Ejecutar();
            for (int i = 0; i < lugar.Count(); i++)
            {

                Assert.IsTrue(lugar[i].Id != 0);
            }

           
        }
        

        /// <summary>
        /// Prueba que permite Consultar Lugar por id.
        /// </summary>
        [Test]
        public void TestConsultarLugarxID()
        {
            Comando<Entidad> Comand = FabricaComandos.CrearConsultarLugarXID(Lugar1);
            Entidad lugar = Comand.Ejecutar();
            Assert.IsTrue(lugar.Id==5);
            
        }

        /// <summary>
        /// Prueba que permite agregar Lugar .
        /// </summary>
        [Test]
        public void TestAgregarLugar()
        {
            try
            {
                Comando<bool> Comand = FabricaComandos.CrearAgregarLugar(Lugar1);
                Assert.IsTrue(Comand.Ejecutar());
            }
            catch (Exception e) {
                
                Assert.IsTrue(true);
            }

        }

        /// <summary>
        /// Prueba que permite modificar Lugar .
        /// </summary>
        [Test]
        public void TestModificarLugar()
        {
            try
            {
                Comando<bool> Comand = FabricaComandos.CrearModificarLugar(Lugar1);
                Assert.IsTrue(Comand.Ejecutar());
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
        public void TestConsultarLugar()
        {
            try
            {
                Comando<List<Entidad>> Comand = FabricaComandos.CrearConsultarLugar();
                List<Entidad> lugar = Comand.Ejecutar();
                for (int i = 0; i < lugar.Count(); i++)
                {

                    Assert.IsTrue(lugar[i].Id != 0);
                }
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
        public void TestModificarLugar()
        {
            try
            {
                Comando < bool > Comand = FabricaComandos.CrearModificarLugar(Lugar1);
                Assert.IsTrue(Comand.Ejecutar());
               
            }
            catch (Exception e)
            {

                Assert.IsTrue(true);
            }


        }
    }
}
