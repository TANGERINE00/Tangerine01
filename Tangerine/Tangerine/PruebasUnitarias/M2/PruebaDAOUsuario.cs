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

namespace PruebasUnitarias.M2
{
    [TestFixture]
    public class PruebaDAOUsuario
    {

        #region Atributos

        public bool answer;
        public RolM2 elRol = new RolM2("Administrador"); 
        public Entidad elUsuario;
        public Entidad elUsuario1;
        public Entidad elUsuario2;

        #endregion

        #region SetUp And TearDown

        /// <summary>
        /// SetUp para las pruebas de DAOUsuario
        /// </summary>
        [SetUp]
        public void init()
        {
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("Daniel", "1234", new DateTime(2015, 2, 10),"Activo", elRol, 1);
            elUsuario1 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("GianJose", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
        }

        /// <summary>
        /// TearDown para las pruebas de DAOUsuario
        /// </summary>
        [TearDown]
        public void clean()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            elUsuario2 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID(daoUsuario.ConsultLastUserID(),"Daniel", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario2 = (DominioTangerine.Entidades.M2.UsuarioM2)elUsuario2;
            answer = daoUsuario.BorrarUsuario(theUsuario2.Id);
            elUsuario = null;
            elUsuario1 = null;
            elUsuario2 = null;
        }

        #endregion

        #region Test

        /// <summary>
        /// Método para probar el Agregar de DAOUsuario
        /// </summary>
        [Test]
        public void TestAgregar()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            //Inserto un Usuario
            answer = daoUsuario.Agregar(elUsuario);

            elUsuario1 = daoUsuario.ConsultarXId(DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID(daoUsuario.ConsultLastUserID(),"GianJose", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1));
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).Id == daoUsuario.ConsultLastUserID());
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).nombreUsuario == "Daniel");
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).contrasena == "1234");
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).fechaCreacion == new DateTime(2015, 2, 10));
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).activo == "Activo");
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).rol.Id == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).fichaEmpleado == 1);
        }

        /// <summary>
        /// Método para probar el ConsultarXId de DAOUsuario
        /// </summary>
        [Test]
        public void TestConsultarXId()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            answer = daoUsuario.Agregar(elUsuario1);
            elUsuario2 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID(daoUsuario.ConsultLastUserID(), "Fernando", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
            //Aplico el metodo para consultar el usuario agregado anteriormente.
            elUsuario1 = daoUsuario.ConsultarXId(elUsuario2);
            //Comparo que el id del usuario creado coincide con el id del usuario consultado.
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).Id == daoUsuario.ConsultLastUserID());
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).nombreUsuario == "GianJose");
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).contrasena == "1234");
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).fechaCreacion == new DateTime(2015, 2, 10));
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).activo == "Activo");
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).rol.Id == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).fichaEmpleado == 1);
        }

        /// <summary>
        /// Método para probar el VerificarUsuarioPorFichaEmpleado de DAOUsuario
        /// </summary>
        [Test]
        public void TestVerificarUsuarioPorFichaEmpleado()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            answer = daoUsuario.Agregar( elUsuario );
            bool resultado = daoUsuario.VerificarUsuarioPorFichaEmpleado(1);
            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Método para probar el VerificarExistenciaUsuario de DAOUsuario
        /// </summary>
        [Test]
        public void TestVerificarExistenciaUsuario()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            answer = daoUsuario.Agregar(elUsuario);
            bool resultado = daoUsuario.VerificarExistenciaUsuario(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario).nombreUsuario);
            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Método para probar el ObtenerUsuarioDeEmpleado de DAOUsuario
        /// </summary>
        [Test]
        public void TestObtenerUsuarioDeEmpleado()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            answer = daoUsuario.Agregar(elUsuario);
            DominioTangerine.Entidad theUsuario =
                                daoUsuario.ObtenerUsuarioDeEmpleado(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario).fichaEmpleado);
            DominioTangerine.Entidades.M2.UsuarioM2 usuario = (DominioTangerine.Entidades.M2.UsuarioM2)theUsuario;
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario).nombreUsuario == usuario.nombreUsuario);
        }
        
        /// <summary>
        /// Método para probar el ObtenerDatoUsuario de DAOUsuario
        /// </summary>
        [Test]
        public void TestObtenerDatoUsuario()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            answer = daoUsuario.Agregar(elUsuario);
            DominioTangerine.Entidad theUsuario = daoUsuario.ObtenerDatoUsuario(elUsuario);
            DominioTangerine.Entidades.M2.UsuarioM2 usuario = (DominioTangerine.Entidades.M2.UsuarioM2)theUsuario;
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario).fechaCreacion == usuario.fechaCreacion);
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario).activo == usuario.activo);
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario).rol.Id == usuario.rol.Id);
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario).fichaEmpleado == usuario.fichaEmpleado);
        }

        /// <summary>
        /// Método para probar el ObtenerDatoUsuario de DAOUsuario
        /// </summary>
        [Test]
        public void TestModificarContraseniaUsuario()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            answer = daoUsuario.Agregar(elUsuario);
            bool resultado = daoUsuario.ModificarContraseniaUsuario(elUsuario);
            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Método para probar el ConsultLastUserID de DAOUsuario
        /// </summary>
        [Test]
        public void TestConsultLastUserId()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            answer = daoUsuario.Agregar(elUsuario);
            int lastID = daoUsuario.ConsultLastUserID();
            Assert.IsTrue(lastID > 0);
        }

        #endregion

    }
}