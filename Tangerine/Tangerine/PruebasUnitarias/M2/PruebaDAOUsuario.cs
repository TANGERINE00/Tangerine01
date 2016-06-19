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
    class PruebaDAOUsuario
    {
        #region Atributos
        public bool answer;
        //public bool answer1;
        public RolM2 elRol = new RolM2("Administrador"); 
        public Entidad elUsuario;
        public Entidad elUsuario1;
        public Entidad elUsuario2;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            
            elUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("Daniel", "1234", new DateTime(2015, 2, 10),"Activo", elRol,1);
            elUsuario1 = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto("GianJose", "1234", new DateTime(2015, 2, 10), "Activo", elRol,1);

        }

        [TearDown]
        public void clean()
        {
            elUsuario = null;
            elUsuario1 = null;
            elUsuario2 = null;
        }
        #endregion

        #region Test
        /// <summary>
        /// Prueba que permite verificar el insertar de un usuario en la base de datos.
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

        [Test]
        public void TestModificar()
        {
            IDAOUsuarios daoUsuario = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoUsuario();
            //Inserto un Usuario
            answer = daoUsuario.Agregar(elUsuario);
            /*
            //elUsuario1 = daoUsuario.ConsultarXId(DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(daoCompania.ConsultLastCompanyId(),"CompaniaPrueba3", "J-111134112", "affdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1));
            //Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).Id == daoUsuario.consultLastUserId());
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).nombreUsuario == "Daniel");
            Assert.IsTrue(((DominioTangerine.Entidades.M2.UsuarioM2)elUsuario1).contrasena == "1234");
            */
        }
        #endregion

        public Entidad dao { get; set; }
    }
}