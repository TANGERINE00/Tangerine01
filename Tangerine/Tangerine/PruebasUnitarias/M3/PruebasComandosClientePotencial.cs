using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.Comandos.M3;
using LogicaTangerine;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M3;

namespace PruebasUnitarias.M3
{
    [TestFixture]
    public class PruebasComandosClientePotencial
    {
        #region Atributos

        private DominioTangerine.Entidades.M3.ClientePotencial elCliente1, elCliente2, elCliente3, elCliente4;
        private Boolean respuesta;
        private List<Entidad> losClientes;
        private LogicaTangerine.Comando<bool> comandoRespuesta;
        private LogicaTangerine.Comando<int> comandoNumero;
        private LogicaTangerine.Comando<Entidad> comandoBuscar;

        #endregion

        #region SetUp y TearDown
        /// <summary>
        /// SetUp para las pruebas de DAOClientePotencial
        /// </summary>
        [SetUp]
        public void init()
        {
            elCliente1 = new DominioTangerine.Entidades.M3.ClientePotencial("Test2", "J-121212-F", "prueba@gmail.com", 121212, 1);
            elCliente2 = new DominioTangerine.Entidades.M3.ClientePotencial();
            elCliente3 = new DominioTangerine.Entidades.M3.ClientePotencial("Test2Cambio", "J-121212-F", "cambio@gmail.com", 746, 1);
            elCliente4 = new DominioTangerine.Entidades.M3.ClientePotencial("Test3", "J-121212-F", "prueba@gmail.com", 121212, 0);
            losClientes = new List<Entidad>();
        }

        /// <summary>
        /// TearDown para las pruebas de DAOClientePotencial
        /// </summary>
        [TearDown]
        public void clean()
        {
            elCliente1 = null;
            elCliente2 = null;
            elCliente3 = null;
            elCliente4 = null;
        }
        #endregion

        /// <summary>
        /// Método para probar el Comando para agregar un cliente potencial
        /// </summary>
        [Test]
        public void TestComandoAgregarClientePotencial()
        {
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente1);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            comandoNumero = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoUltimoIdClientePotencial();
            elCliente1.Id = comandoNumero.Ejecutar();

            comandoBuscar = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarClientePotencial(elCliente1);
            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)comandoBuscar.Ejecutar();

            Assert.AreEqual(elCliente1.NombreClientePotencial,elCliente2.NombreClientePotencial);
            
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente1);
            Assert.IsTrue(comandoRespuesta.Ejecutar());
        }
    }
}
