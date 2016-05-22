using DominioTangerine;
using DatosTangerine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M2;

namespace PruebasUnitarias.M2
{
    [TestFixture]
    public class PruebasBDUsuario
    {
        #region Atributos

        public Usuario theUser;
        public Usuario theUserResultado;
        public Usuario theUserFail;
        public Rol theRol;

        #endregion

        #region SetUp and TearDown

        /// <summary>
        /// Método para inicializar los atributos de la clase para realizar las pruebas
        /// </summary>
        [SetUp]
        public void Init()
        {
            theRol = new Rol("Gerente");
            theUser = new Usuario("userTest", "testapp1", "Activo", theRol, 0, DateTime.Now);
            theUserResultado = new Usuario("userTest", "testapp1");
        }

        /// <summary>
        /// Método  para reiniciar los atributos
        /// </summary>
        [TearDown]
        public void Clean()
        {
            theRol = null;
            theUser = null;
        }

        #endregion

        /// <summary>
        /// Método para probar el método AgregarUsuario() de la clase BDUsuario en DatosTangerine
        /// </summary>
        [Test]
        public void TestAgregarUsuario()
        {
            bool resultado = BDUsuario.AgregarUsuario(theUser);

            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Método para probar el método ObtenerDatoUsuario() de la clase BDUsuario en DatosTangerine
        /// </summary>
        [Test]
        public void TestObtenerDatosUsuario()
        {
            theUserResultado = BDUsuario.ObtenerDatoUsuario(theUserResultado);

            Assert.AreEqual(theUserResultado.Rol.Nombre, "Gerente");
        }

        /// <summary>
        /// Método para probar el método ModifcarRolUsuario() de la clase BDUsuario en DatosTangerine
        /// </summary>
        [Test]
        public void TestModificarRolUsuario()
        {
            theRol.Nombre = "Director";

            theUser.Rol = theRol;

            bool resultado = BDUsuario.ModificarRolUsuario(theUser);

            theUserResultado = BDUsuario.ObtenerDatoUsuario(theUser);

            Assert.AreEqual(theUser.Rol.Nombre, theUserResultado.Rol.Nombre);
        }

        /// <summary>
        /// Método para probar el método ModifcarContraseniaUsuario() de la clase BDUsuario en DatosTangerine
        /// </summary>
        [Test]
        public void TestModificarContraseniaUsuario()
        {
            theUser.Contrasenia = "modificacion1";

            bool resultado = BDUsuario.ModificarContraseniaUsuario(theUser);

            theUserResultado = BDUsuario.ObtenerDatoUsuario(theUser);

            Assert.AreEqual(theUser.Contrasenia, theUserResultado.Contrasenia);
        }

        /// <summary>
        /// Método para probar el método ObtenerRolUsuario() de la clase BDUsuario en DatosTangerine
        /// </summary>
        [Test]
        public void TestObtenerRolUsuario()
        {
            theRol = BDUsuario.ObtenerRolUsuario(1);

            Assert.AreEqual(theRol.Nombre, "Administrador");
        }

        /// <summary>
        /// Método para probar el disparo de una excepción el método AgregarUsuario() de la clase BDUsuario en
        /// DatosTangerine
        /// </summary>
        [Test]
        public void TestFailAgregarUsuario()
        {
            theUserFail = new Usuario();
            theUserFail.NombreUsuario = "testFail";

            bool resultado = BDUsuario.AgregarUsuario(theUserFail);

            Assert.Fail("Se ha disparado la excepción de la prueba de AgregarUsuario()");
        }

        /// <summary>
        /// Método para probar el disparo de una excepción el método ModificarRolUsuario() de la clase BDUsuario en
        /// DatosTangerine
        /// </summary>
        [Test]
        public void TestFailModificarRolUsuario()
        {
            theUserFail = new Usuario();
            theUserFail.NombreUsuario = "testFail";

            bool resultado = BDUsuario.ModificarRolUsuario(theUserFail);

            Assert.Fail("Se ha disparado la excepción de la prueba de ModificarRolUsuario()");
        }

        /// <summary>
        /// Método para probar el disparo de una excepción el método ModificarContraseniaUsuario() de la clase BDUsuario en
        /// DatosTangerine
        /// </summary>
        [Test]
        public void TestFailModificarContraseniaUsuario()
        {
            theUserFail = new Usuario();
            theUserFail.NombreUsuario = "testFail";

            bool resultado = BDUsuario.ModificarContraseniaUsuario(theUserFail);

            Assert.Fail("Se ha disparado la excepción de la prueba de ModificarContraseniaUsuario()");
        }
        [Test]

        public void TestVerificarUsuarioPorFichaEmpleado()
        {
            Assert.IsFalse(BDUsuario.VerificarUsuarioPorFichaEmpleado(0));
        }

        [Test]
        public void TestVerificarExistenciaDeUsuario()
        {
            Assert.IsFalse(BDUsuario.VerificarExistenciaDeUsuario("elusuario"));
            Assert.IsTrue(BDUsuario.VerificarExistenciaDeUsuario("luarropa"));
        }

        [Test]

        public void TestFailObtenerRolUsuarioPorNombre()
        {

            String s = "";
            BDUsuario.ObtenerRolUsuarioPorNombre(s);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailObtenerUsuarioDeEmpleado()
        {
            BDUsuario.ObtenerUsuarioDeEmpleado(null);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailObtenerDatoUsuario()
        {
            BDUsuario.ObtenerDatoUsuario(null);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailObtenerOpciones()
        {
            BDUsuario.ObtenerOpciones(null, 1);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailObtenerRolUsuario()
        {
            int i = 0;
            BDUsuario.ObtenerRolUsuario(i);
            Assert.Fail("se ha disparado la excepcion");
        }


        [Test]
        public void TestFailVerificarExistenciaDeUsuario()
        {
            BDUsuario.VerificarExistenciaDeUsuario(null);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailVerificarUsuarioPorFichaEmpleado()
        {
            BDUsuario.VerificarUsuarioPorFichaEmpleado(0);
            Assert.Fail("se ha disparado la excepcion");
        }



    }
}
