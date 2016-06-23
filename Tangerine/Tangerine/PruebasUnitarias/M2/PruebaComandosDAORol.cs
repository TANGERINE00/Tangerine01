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
    [TestFixture]
    public class PruebaComandosDAORol
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
        /// SetUp para las pruebas de ComandosDAORol
        /// </summary>
        [SetUp]
        public void init()
        {
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto( "Daniel" , "1234" , new DateTime(2015, 2, 10) , 
                                                                                        "Activo" , elRol , 1 );
        }

        /// <summary>
        /// TearDown para las pruebas de ComandosDAORol
        /// </summary>
        [TearDown]
        public void clean()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            elUsuario1 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID( daoUsuario.ConsultLastUserID() , 
                                                                  "Daniel" , "1234" , new DateTime(2015, 2, 10) , "Activo" , elRol1 , 1 );
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario1 = ( DominioTangerine.Entidades.M2.UsuarioM2 )elUsuario1;
            answer = daoUsuario.BorrarUsuario( theUsuario1.Id );
            elUsuario = null;
            elRol = null;
            elRol1 = null;
        }

        #endregion

        #region Test

        /// <summary>
        /// Método para probar el ComandoModificarRol de ComandosDAORol
        /// </summary>
        [Test]
        public void TestComandoModificarRol()
        {
            bool resultado, resultado2;
            LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario( elUsuario );
            resultado = commandAgregarUsuario.Ejecutar();
            Assert.IsTrue(resultado);
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario = ( DominioTangerine.Entidades.M2.UsuarioM2 )elUsuario;
            LogicaTangerine.Comando<Boolean> commandModificarRol = FabricaComandos.obtenerComandoModificarRol( theUsuario.nombreUsuario , 
                                                                                                               theUsuario.rol.nombre );
            resultado2 = commandModificarRol.Ejecutar();
            Assert.IsTrue( resultado2 );
        }

        /// <summary>
        /// Método para probar el ComandoModificarRolUsuario de ComandosDAORol
        /// </summary>
        [Test]
        public void TestComandoModificarRolUsuario()
        {
            bool resultado, resultado2;
            LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario( elUsuario );
            resultado = commandAgregarUsuario.Ejecutar();
            Assert.IsTrue( resultado );
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto( "Daniel" , "1234" , new DateTime(2015, 2, 10) , 
                                                                                        "Activo" , elRol1 , 1 );
            LogicaTangerine.Comando<Boolean> commandModificarRolUsuario = FabricaComandos.obtenerComandoModificarRolUsuario( elUsuario );
            resultado2 = commandModificarRolUsuario.Ejecutar();
            Assert.IsTrue( resultado2 );
        }

        /// <summary>
        /// Método para probar el ComandoObtenerOpciones de ComandosDAORol
        /// </summary>
        [Test]
        public void TestComandoObtenerOpciones()
        {
            bool resultado;
            LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario( elUsuario );
            resultado = commandAgregarUsuario.Ejecutar();
            Assert.IsTrue( resultado );
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto( "Daniel" , "1234" , new DateTime(2015, 2, 10) ,
                                                                                        "Activo" , elRol1 , 1 );
            LogicaTangerine.Comando<DominioTangerine.Entidad> commandObtenerOpciones
                = FabricaComandos.obtenerComandoObtenerOpciones( "Gestión de Pagos" , 2 );
            DominioTangerine.Entidad theResultado = commandObtenerOpciones.Ejecutar();
            DominioTangerine.Entidades.M2.ListaGenericaM2<DominioTangerine.Entidades.M2.OpcionM2> lista
                = ( DominioTangerine.Entidades.M2.ListaGenericaM2<DominioTangerine.Entidades.M2.OpcionM2> )theResultado;
            Assert.IsNotEmpty( lista );
        }

        /// <summary>
        /// Método para probar el ComandoObtenerRolUsuario de ComandosDAORol
        /// </summary>
        [Test]
        public void TestComandoObtenerRolUsuario()
        {
            bool resultado;
            LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario( elUsuario );
            resultado = commandAgregarUsuario.Ejecutar();
            Assert.IsTrue( resultado );
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto( "Daniel" , "1234" , new DateTime(2015, 2, 10) ,
                                                                                        "Activo" , elRol1 , 1 );
            LogicaTangerine.Comando<DominioTangerine.Entidad> commandObtenerRolUsuario
                = FabricaComandos.obtenerComandoObtenerRolUsuario( 2 );
            DominioTangerine.Entidad theRol = commandObtenerRolUsuario.Ejecutar();
            DominioTangerine.Entidades.M2.RolM2 rol = ( DominioTangerine.Entidades.M2.RolM2 )theRol;
            Assert.IsNotNull( rol );
        }

        /// <summary>
        /// Método para probar el ComandoObtenerRolUsuarioPorNombre de ComandosDAORol
        /// </summary>
        [Test]
        public void TestComandoObtenerRolUsuarioPorNombre()
        {
            bool resultado;
            LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario( elUsuario );
            resultado = commandAgregarUsuario.Ejecutar();
            Assert.IsTrue( resultado );
            RolM2 elRol = new RolM2( 1 );
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto( "Daniel" , "1234" , new DateTime(2015, 2, 10) , 
                                                                                        "Activo" , elRol1 , 1 );
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario = ( DominioTangerine.Entidades.M2.UsuarioM2 )elUsuario;
            LogicaTangerine.Comando<DominioTangerine.Entidad> commandObtenerRolUsuarioPorNombre
                = FabricaComandos.obtenerComandoObtenerRolUsuarioPorNombre( theUsuario.nombreUsuario );
            DominioTangerine.Entidad theResultado = commandObtenerRolUsuarioPorNombre.Ejecutar();
            DominioTangerine.Entidades.M2.RolM2 resultado2 = ( DominioTangerine.Entidades.M2.RolM2 )theResultado;
            Assert.IsNotNull( resultado2.Id );
        }

        #endregion
    }
}
