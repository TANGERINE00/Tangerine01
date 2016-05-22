using DominioTangerine;
using DatosTangerine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M2;
using LogicaTangerine.M2;

namespace PruebasUnitarias.M2
{
    [TestFixture]
    public class M2PruebasLogica

    {
        #region Atributos

        public Usuario theUser;
        public Usuario theUserResultado;
        public Usuario theUserFail;
        public Rol theRol;
        public Empleado theEmpleado;
        public String usuarioDefault;
        
        #endregion 

        #region SetUp and TearDown
        
        /// <summary>
        /// Método para inicializar los atributos de la clase para realizar las pruebas
        /// </summary>
        [SetUp]
        public void Init() 
        {
            theRol = new Rol( "Gerente" );
            theUser = new Usuario( "userTest", "testapp1", "Activo", theRol, 0, DateTime.Now );
            theUserResultado = new Usuario( "userTest", "testapp1" );
            theEmpleado = new Empleado();
            usuarioDefault = "caloza";
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
        /// Método para probar el método ConsultarListaDeEmpleados de la clase LogicaAgregarUsuario
        /// </summary>
        [Test]
        public void TestConsultarListaDeEmpleados() 
        {
            Assert.IsNotNull(LogicaAgregarUsuario.ConsultarListaDeEmpleados());
        }
        /// <summary>
        /// Metodo para probar el metodo ExisteUsuario de la clase LogicaAgregarUsuario
        /// </summary>
        [Test]
        public void TestExisteUsuario()
        {
            BDUsuario.AgregarUsuario(theUser);
            Assert.IsTrue(LogicaAgregarUsuario.ExisteUsuario("userTest"));
            Assert.IsFalse(LogicaAgregarUsuario.ExisteUsuario(""));
        }
        /// <summary>
        /// Metodo para probar el metodo CrearUsuarioDefault de la clase LogicaAgregarUsuario
        /// </summary>
        [Test]
        public void TestCrearUsuarioDefault()
        {
            Assert.AreEqual(usuarioDefault,LogicaAgregarUsuario.CrearUsuarioDefault("carlos","lozano"));
            Assert.IsEmpty(LogicaAgregarUsuario.CrearUsuarioDefault("",""));
        }

        

        [Test]
        public void TestObtenerCaracteres()
        {
            String prueba = "prueba";
            Assert.AreEqual("pr", LogicaAgregarUsuario.ObtenerCaracteres(prueba, 2));
            Assert.IsEmpty("",LogicaAgregarUsuario.ObtenerCaracteres("",2));
        }

        [Test]
        public void TestPrepararUsuario()
        {
            Assert.IsTrue(LogicaAgregarUsuario.PrepararUsuario("usuarionuevo", "contrasenanueva", "Gerente",1234));
        }
        
        [Test]
        public void TestObtenerUsuario()
        {
            
            Assert.IsNotNull(LogicaModificarRol.ObtenerUsuario(theEmpleado));
        }

        /// <summary>
        /// Metodo para probar el metodo ModificarRol de la clase LogicaModificarRol
        /// </summary>
        [Test]
        public void TestModificarRol()
        {
            BDUsuario.AgregarUsuario(theUser);
            System.Diagnostics.Debug.WriteLine(theUser.NombreUsuario);
            Assert.IsTrue(LogicaModificarRol.ModificarRol(theUser.NombreUsuario, "Gerente"));

        }


      
        /// <summary>
        /// Metodo para probar el metodo TestConsultarListaDeUsuarios de la clase LogicaModificarRol
        /// </summary>
       


        /// <summary>
        /// Metodo para probar el metodo VerificarAccesoAOpciones de la clase LogicaPrivilegios
        /// </summary>
        [Test]
        public void TestVerificarAccesoAOpciones()
        {

            Assert.IsNotNull(LogicaPrivilegios.VerificarAccesoAOpciones("Gerente"));
            Assert.IsNotNull(LogicaPrivilegios.VerificarAccesoAOpciones("Administrador"));
            Assert.IsNotNull(LogicaPrivilegios.VerificarAccesoAOpciones("Programador"));
            Assert.IsNotNull(LogicaPrivilegios.VerificarAccesoAOpciones("Director"));
        }

        [Test]

        public void TestVerificarUsuarioDeEmpleado() 
        {
            Assert.IsFalse(LogicaAgregarUsuario.VerificarUsuarioDeEmpleado(0));
        }

        [Test]

        public void TestVerificarAccesoAPaginas()
        {
            Assert.IsTrue(LogicaPrivilegios.VerificarAccesoAPagina("../../GUI/M2/RegistroUsuario.aspx", "Programador"));
            Assert.IsFalse(LogicaPrivilegios.VerificarAccesoAPagina("../../GUI/M1/Dashboard.aspx","Programador"));
        }

        [Test]
        public void TestFailVerificarAccesoAOpciones()
        {
            LogicaPrivilegios.VerificarAccesoAOpciones(null);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]

        public void TestFailVerificarAccesoAPagina()
        {
            LogicaPrivilegios.VerificarAccesoAPagina("RegistroUsuario.aspx", "Programador");
            Assert.Fail("se ha disparado la excepcion");
        }


        [Test]
        public void TestFailModificarRol()
        {
            LogicaModificarRol.ModificarRol(null, null);
            Assert.Fail("se ha disparado la excepcion");

        }

        [Test]
        public void TestFailAgregarUsuario()
        {
            LogicaAgregarUsuario.AgregarUsuario(null);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailConsultarListaDeEmpleados()
        {
            LogicaAgregarUsuario.ConsultarListaDeEmpleados();
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailCrearUsuarioDefault()
        {
            LogicaAgregarUsuario.CrearUsuarioDefault(null,null);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailExisteUsuario()
        {
            LogicaAgregarUsuario.ExisteUsuario(null);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailObtenerCaracteres()
        {
            LogicaAgregarUsuario.ObtenerCaracteres(null,2);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailPrepararUsuario()
        {
            LogicaAgregarUsuario.PrepararUsuario(null,null,null,1);
            Assert.Fail("se ha disparado la excepcion");
        }

        [Test]
        public void TestFailVerificarUsuarioDeEmpleado()
        {
            LogicaAgregarUsuario.VerificarUsuarioDeEmpleado(1);
            Assert.Fail("se ha disparado la excepcion");
        }

       
    }
}
