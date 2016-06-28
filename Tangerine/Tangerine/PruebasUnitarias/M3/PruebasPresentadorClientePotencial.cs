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
        private ClientePotencial elCliente1, elCliente2;

        private PresentadorModificarClientePotencial presentadorModificar;
        private IContratoModificarClientePotencial contratoModificar;
        private LogicaTangerine.Comando<int> comandoNumero;
        #endregion

        #region SetUp y TearDown
        /// <summary>
        /// SetUp para las pruebas de DAOClientePotencial
        /// </summary>
        [SetUp]
        public void Init()
        {
            elCliente1 = new DominioTangerine.Entidades.M3.ClientePotencial("Prueba", "J-121212121212-4", "prueba@gmail.com", 121212, 1);
            elCliente2 = new DominioTangerine.Entidades.M3.ClientePotencial("Prueba2", "J-121212121212-4", "prueba@gmail.com", 121212, 1);
            presentadorAgregar = new PresentadorAgregarClientePotencial(contratoAgregar);
            presentadorModificar = new PresentadorModificarClientePotencial(contratoModificar);
        }

        /// <summary>
        /// TearDown para las pruebas de DAOClientePotencial
        /// </summary>
        [TearDown]
        public void Clean()
        {
            elCliente1 = null;
            elCliente2 = null;
            presentadorAgregar = null;
            presentadorModificar = null;
        }
        #endregion

        /// <summary>
        /// Método para probar el método verificar en el presentador de agregar
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

        /// <summary>
        /// Método para probar el verificar en el presentador de modificar
        /// </summary>
        [Test]
        public void TestPresentadorModificarClientePotencial()
        {
            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente1);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            comandoNumero = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoUltimoIdClientePotencial();
            elCliente1.Id = comandoNumero.Ejecutar();

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(elCliente2);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            Assert.False(presentadorModificar.VerificarDatosDeCliente("Prueba2",
                "J-121212121212-4", "prueba@gmail.com",elCliente1.Id));

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente1);
            Assert.IsTrue(comandoRespuesta.Ejecutar());

            comandoRespuesta = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoEliminarClientePotencial(elCliente2);
            Assert.IsTrue(comandoRespuesta.Ejecutar());
        }
    }
}
