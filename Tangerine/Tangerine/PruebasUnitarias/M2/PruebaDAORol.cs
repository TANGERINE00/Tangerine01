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
    public class PruebaDAORol
    {

        #region Atributos

        public bool answer;
        public RolM2 elRol = new RolM2("Administrador");
        public RolM2 elRol1 = new RolM2("Gerente");
        public Entidad elUsuario;
        public Entidad elUsuario1;

        #endregion

        #region SetUp And TearDown

        /// <summary>
        /// SetUp para las pruebas de DAORol
        /// </summary>
        [SetUp]
        public void init()
        {
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("Daniel", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
        }

        /// <summary>
        /// TearDown para las pruebas de DAORol
        /// </summary>
        [TearDown]
        public void clean()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            elUsuario1 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID(daoUsuario.ConsultLastUserID(), "Daniel", "1234", new DateTime(2015, 2, 10), "Activo", elRol, 1);
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario1 = (DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1;
            answer = daoUsuario.BorrarUsuario(theUsuario1.Id);
            elUsuario = null;
            elRol = null;
            elRol1 = null;
        }

        #endregion

        #region Test

        /// <summary>
        /// Método para probar el ModificarRolUsuario de DAORol
        /// </summary>
        [Test]
        public void TestModificarRolUsuario()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            answer = daoUsuario.Agregar(elUsuario);
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("Daniel", "1234", new DateTime(2015, 2, 10), "Activo", elRol1, 1);
            IDAORol daoRol = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoRol();
            bool resultado = daoRol.ModificarRolUsuario(elUsuario);
            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Método para probar el ObtenerRolUsuarioPorNombre de DAORol
        /// </summary>
        [Test]
        public void TestObtenerRolUsuarioPorNombre()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            answer = daoUsuario.Agregar(elUsuario);
            RolM2 elRol2 = new RolM2(1);
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("Daniel", "1234", new DateTime(2015, 2, 10), "Activo", elRol2, 1);
            DominioTangerine.Entidades.M2.UsuarioM2 theUsuario = (DominioTangerine.Entidades.M2.UsuarioM2)elUsuario;
            IDAORol daoRol = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoRol();
            DominioTangerine.Entidad theResultado = daoRol.ObtenerRolUsuarioPorNombre(theUsuario.nombreUsuario);
            DominioTangerine.Entidades.M2.RolM2 resultado = (DominioTangerine.Entidades.M2.RolM2)theResultado;
            Assert.IsTrue(resultado.Id == 1);
        }

        #endregion


    }
}
