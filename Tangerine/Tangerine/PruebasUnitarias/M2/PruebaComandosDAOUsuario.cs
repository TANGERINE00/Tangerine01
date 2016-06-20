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
    public class PruebaComandosDAOUsuario
    {
        #region Atributos

        public bool answer;
        public RolM2 elRol = new RolM2("Administrador");
        public Entidad elUsuario;
        public Entidad elUsuario1;
        public Entidad elUsuario2;
        public String usuarioDefault;

        #endregion

        #region SetUp And TearDown

        /// <summary>
        /// SetUp para las pruebas de ComandosDAOUsuario
        /// </summary>
        [SetUp]
        public void init()
        {
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("Daniel", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
            elUsuario1 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("GianJose", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
            usuarioDefault = "giberl";
        }

        /// <summary>
        /// TearDown para las pruebas de ComandosDAOUsuario
        /// </summary>
        [TearDown]
        public void clean()
        {
            elUsuario = null;
            elUsuario1 = null;
            elUsuario2 = null;
            usuarioDefault = null;
        }

        #endregion

        #region Test

        /// <summary>
        /// Método para probar el ComandoAgregarUsuario de ComandosDAOUsuario
        /// </summary>
        [Test]
        public void TestComandoAgregarUsuario()
        {
            bool resultado;
            LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario( elUsuario );
            resultado = commandAgregarUsuario.Ejecutar();
            Assert.IsTrue(resultado);
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            elUsuario2 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID(daoUsuario.ConsultLastUserID(), "Daniel", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario2 = (DominioTangerine.Entidades.M2.UsuarioM2)elUsuario2;
            answer = daoUsuario.BorrarUsuario(theUsuario2.Id);
        }

        /// <summary>
        /// Método para probar el ComandoCrearUsuarioDefault de ComandosDAOUsuario
        /// </summary>
        [Test]
        public void TestComandoCrearUsuarioDefault()
        {
            String resultado, resultado2;
            LogicaTangerine.Comando<String> commandCrearUsuarioDefault = FabricaComandos.crearUsuario("gianfranco", "berlino");
            LogicaTangerine.Comando<String> commandCrearUsuarioDefault2 = FabricaComandos.crearUsuario("", "");
            resultado = commandCrearUsuarioDefault.Ejecutar();
            resultado2 = commandCrearUsuarioDefault2.Ejecutar();
            Assert.AreEqual(usuarioDefault, resultado);
            Assert.IsEmpty(resultado2);
        }

        /// <summary>
        /// Método para probar el ComandoModificarContrasena de ComandosDAOUsuario
        /// </summary>
        [Test]
        public void TestComandoModificarContrasena()
        {
            bool resultado, resultado2;
            LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario(elUsuario);
            resultado = commandAgregarUsuario.Ejecutar();
            Assert.IsTrue(resultado);
            LogicaTangerine.Comando<Boolean> commandModificarContrasena = FabricaComandos.modificarContrasenaUsuario(elUsuario);
            resultado2 = commandModificarContrasena.Ejecutar();
            Assert.IsTrue(resultado2);
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            elUsuario2 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID(daoUsuario.ConsultLastUserID(), "Daniel",
                                                                   "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario2 = (DominioTangerine.Entidades.M2.UsuarioM2)elUsuario2;
            answer = daoUsuario.BorrarUsuario(theUsuario2.Id);
        }

        /// <summary>
        /// Método para probar el ComandoObtenerCaracteres de ComandosDAOUsuario
        /// </summary>
        [Test]
        public void TestComandoObtenerCaracteres()
        {
            String resultado, resultado2;
            String testPrueba = "prueba";
            LogicaTangerine.Comando<String> commandObtenerCaracteres = FabricaComandos.obtenerCaracteres(testPrueba, 2);
            LogicaTangerine.Comando<String> commandObtenerCaracteres2 = FabricaComandos.obtenerCaracteres("", 2);
            resultado = commandObtenerCaracteres.Ejecutar();
            resultado2 = commandObtenerCaracteres2.Ejecutar();
            Assert.AreEqual("pr", resultado);
            Assert.IsEmpty(resultado2);
        }

        /// <summary>
        /// Método para probar el ComandoObtenerUsuario de ComandosDAOUsuario
        /// </summary>
        [Test]
        public void TestComandoObtenerUsuario()
        {
            bool resultado;
            LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario( elUsuario );
            resultado = commandAgregarUsuario.Ejecutar();
            Assert.IsTrue(resultado);
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario = (DominioTangerine.Entidades.M2.UsuarioM2)elUsuario;
            LogicaTangerine.Comando<DominioTangerine.Entidad> commandObtenerUsuario = 
                                                              FabricaComandos.obtenerUsuario( theUsuario.fichaEmpleado );
            DominioTangerine.Entidad resultado2 = commandObtenerUsuario.Ejecutar();
            DominioTangerine.Entidades.M2.UsuarioM2 theResultado2 = (DominioTangerine.Entidades.M2.UsuarioM2)resultado2;
            Assert.IsTrue(theResultado2.nombreUsuario == "Daniel");
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            elUsuario2 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID(daoUsuario.ConsultLastUserID() , "Daniel" , 
                                                                   "1234" , new DateTime(2015, 2, 10) , "Activo" , elRol , 1 );
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario2 = ( DominioTangerine.Entidades.M2.UsuarioM2 )elUsuario2;
            answer = daoUsuario.BorrarUsuario( theUsuario2.Id );
        }

        /// <summary>
        /// Método para probar el ComandoPrepararUsuario de ComandosDAOUsuario
        /// </summary>
        [Test]
        public void TestComandoPrepararUsuario()
        {
            bool resultado;
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario = (DominioTangerine.Entidades.M2.UsuarioM2)elUsuario;
            LogicaTangerine.Comando<Boolean> commandPrepararUsuario = FabricaComandos.prepararUsuario( theUsuario.nombreUsuario , 
                                                               theUsuario.contrasena , theUsuario.rol.nombre , theUsuario.fichaEmpleado );
            resultado = commandPrepararUsuario.Ejecutar();
            Assert.IsTrue(resultado);
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            elUsuario2 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID(daoUsuario.ConsultLastUserID(), "Daniel",
                                                                   "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario2 = (DominioTangerine.Entidades.M2.UsuarioM2)elUsuario2;
            answer = daoUsuario.BorrarUsuario(theUsuario2.Id);

        }

        /// <summary>
        /// Método para probar el ComandoVerificar de ComandosDAOUsuario
        /// </summary>
        [Test]
        public void TestComandoValidarUsuario()
        {
            bool resultado;
            bool agregar;
            LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario(elUsuario);
            agregar = commandAgregarUsuario.Ejecutar();
            LogicaTangerine.Comando<Boolean> commandValidarUsuario = FabricaComandos.validarUsuario("Daniel");
            resultado = commandValidarUsuario.Ejecutar();
            Assert.IsTrue(resultado);
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            elUsuario2 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID(daoUsuario.ConsultLastUserID(), "Daniel", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario2 = (DominioTangerine.Entidades.M2.UsuarioM2)elUsuario2;
            answer = daoUsuario.BorrarUsuario(theUsuario2.Id);
        }

        /// <summary>
        /// Método para probar el ComandoVerificar de ComandosDAOUsuario
        /// </summary>
        [Test]
        public void TestComandoVerificarUsuario()
        {
            bool resultado;
            bool agregar;
            LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario(elUsuario);
            agregar = commandAgregarUsuario.Ejecutar();
            LogicaTangerine.Comando<Boolean> commandVerificarUsuario = FabricaComandos.verificarUsuario(1);
            resultado = commandVerificarUsuario.Ejecutar();
            Assert.IsTrue(resultado);
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            elUsuario2 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID(daoUsuario.ConsultLastUserID(), "Daniel", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario2 = (DominioTangerine.Entidades.M2.UsuarioM2)elUsuario2;
            answer = daoUsuario.BorrarUsuario(theUsuario2.Id);
        }

        #endregion
    }
}
