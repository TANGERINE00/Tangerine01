using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M2;
using DatosTangerine.InterfazDAO.M2;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M2;
using LogicaTangerine.Fabrica;

namespace PruebasUnitarias.M2
{
    public class PruebasComandosEspecificos
    {
        #region Atributos

        public bool answer;
        public RolM2 elRol = new RolM2( "Administrador" );
        public RolM2 elRol1 = new RolM2( "Gerente" );
        public Entidad elUsuario;
        public Entidad elUsuario1;

        #endregion

        #region SetUp And TearDown

        /// <summary>
        /// SetUp para las pruebas de ComandosEspecificos
        /// </summary>
        [SetUp]
        public void init()
        {
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto( "Daniel" , "1234" , new DateTime(2015, 2, 10) ,
                                                                                        "Activo" , elRol , 1 );
        }

        /// <summary>
        /// TearDown para las pruebas de ComandosEspecificos
        /// </summary>
        [TearDown]
        public void clean()
        {
            elUsuario = null;
            elRol = null;
            elRol1 = null;
        }

        #endregion

        #region Test

        /// <summary>
        /// Método para probar el ComandoVerificarAccesoAOpciones de ComandosEspecificos
        /// </summary>
        [Test]
        public void TestComandoVerificarAccesoAOpciones()
        {
            List<String> listaResultado;
            LogicaTangerine.Comando<List<String>> commandVerificarAccesoAOpciones =
                FabricaComandos.obtenerComandoVerificarAccesoAOpciones("Gerente");
            listaResultado = commandVerificarAccesoAOpciones.Ejecutar();
            Assert.IsNotEmpty(listaResultado);
        }

        /// <summary>
        /// Método para probar el ComandoVerificarAccesoAPagina de ComandosEspecificos
        /// </summary>
        [Test]
        public void TestComandoVerificarAccesoAPagina()
        {
            bool resultado;
            LogicaTangerine.Comando<Boolean> commandVerificarAccesoAPagina =
                FabricaComandos.obtenerComandoVerificarAccesoAPagina("../../GUI/M2/RegistroUsuario.aspx", "Programador");
            resultado = commandVerificarAccesoAPagina.Ejecutar();
            Assert.IsNotNull(resultado);
        }

        #endregion
    }
}
