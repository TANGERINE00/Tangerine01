using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatosTangerine.DAO.M9;
using DatosTangerine.InterfazDAO.M9;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M9;
using LogicaTangerine.Fabrica;


namespace PruebasUnitarias.M9
{
    public class PruebaComandoDaoPago
    {
        #region Atributos

        public bool answer;
        public Entidad elPago;
        public Entidad elPago1;
        public Entidad elPago2;


        #endregion


        #region SetUp And TearDown

        /// <summary>
        /// SetUp para las pruebas de ComandosDAOPago
        /// </summary>
        [SetUp]
        public void init()
        {
            elPago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(1111111111, 12000, "EUR", "Deposito", 1);
        }



        /// <summary>
        /// TearDown para las pruebas de ComandosDAOPago
        [TearDown]
        public void clean()
        {
            elPago = null;
            elPago1 = null;
            elPago2 = null;

        }

        #endregion



        #region Test

        /// <summary>
        /// Método para probar el ComandoAgregarPago de ComandosDAOPago
        /// </summary>
        [Test]
        public void TestComandoAgregarPago()
        {
            bool resultado;
            LogicaTangerine.Comando<Boolean> comandoAgregarPago = FabricaComandos.cargarPago(elPago);
            resultado = comandoAgregarPago.Ejecutar();
            Assert.IsNotNull(comandoAgregarPago);
            Assert.IsTrue(resultado);
         

        }

        #endregion

    }
}