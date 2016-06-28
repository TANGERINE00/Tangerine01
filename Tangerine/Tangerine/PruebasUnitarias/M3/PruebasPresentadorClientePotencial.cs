using System;
using System.Collections.Generic;
using System.Linq;
using DominioTangerine.Entidades.M3;
using NUnit.Framework;
using Tangerine_Presentador.M3;
using Tangerine_Contratos.M3;

namespace PruebasUnitarias.M3
{
    [TestFixture]
    public class PruebasPresentadorClientePotencial
    {
        #region Atributos
        private PresentadorAgregarClientePotencial presentadorAgregar;
        private IContratoAgregarClientePotencial contratoAgregar;
        private LogicaTangerine.Comando<bool> comandoRespuesta;
        private ClientePotencial elCliente1;
        #endregion

        #region SetUp y TearDown
        /// <summary>
        /// SetUp para las pruebas de DAOClientePotencial
        /// </summary>
        [SetUp]
        public void Init()
        {
            elCliente1 = new DominioTangerine.Entidades.M3.ClientePotencial("Prueba", "J-121212121212-4", "prueba@gmail.com", 121212, 1);
            
            presentadorAgregar = new PresentadorAgregarClientePotencial(contratoAgregar);
        }

        /// <summary>
        /// TearDown para las pruebas de DAOClientePotencial
        /// </summary>
        [TearDown]
        public void Clean()
        {
            elCliente1 = null;
            presentadorAgregar = null;
        }
        #endregion

        /// <summary>
        /// Método para probar el ConsultarXId de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestPresentadorClientePotencial()
        {
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente1);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            Assert.False(presentadorAgregar.VerificarDatosDeCliente("Prueba",
                "J-121212121212-4", "prueba@gmail.com"));

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente1);
            Assert.IsTrue(comandoRespuesta.Ejecutar());
        }
    }
}
