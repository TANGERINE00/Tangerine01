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
        /// Método para probar el ObtenerRolUsuario de DAORol
        /// </summary>
        [Test]
        public void TestObtenerRolUsuario()
        {
            /*elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("Daniel", "1234", new DateTime(2015, 2, 10), "Activo", elRol1, 1);
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            answer = daoUsuario.Agregar(elUsuario);
            IDAORol daoRol = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoRol();
            DominioTangerine.Entidad theRol = daoRol.ObtenerRolUsuario(2);
            DominioTangerine.Entidades.M2.OpcionM2 rol = (DominioTangerine.Entidades.M2.OpcionM2)theRol;
            Assert.IsTrue(rol.Id == 2);*/


            /*IDAORol daoRol = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoRol();
            DominioTangerine.Entidad theRol = daoRol.ObtenerRolUsuario(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario).rol.Id);
            DominioTangerine.Entidades.M2.UsuarioM2 rol = (DominioTangerine.Entidades.M2.UsuarioM2)theRol;
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario).rol.Id == rol.Id);*/
        }

        #endregion


    }
}
