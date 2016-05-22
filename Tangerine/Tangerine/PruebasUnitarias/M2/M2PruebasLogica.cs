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
using ExcepcionesTangerine.M2;

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
            theRol = new Rol( "Administrador" );
            theUser = new Usuario("userTest", "81dc9bdb52d04dc20036dbd8313ed055", "Activo", theRol, 0, DateTime.Now);
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
            Assert.IsTrue(LogicaAgregarUsuario.ExisteUsuario("luarropa"));
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
            Assert.IsTrue(LogicaModificarRol.ModificarRol(theUser.NombreUsuario, "Programador"));

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
           // Assert.IsNull(LogicaPrivilegios.VerificarAccesoAOpciones("Administrador"));
            //Assert.IsNotNull(LogicaPrivilegios.VerificarAccesoAOpciones("Programador"));
            //Assert.IsNotNull(LogicaPrivilegios.VerificarAccesoAOpciones("Director"));
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

            Assert.Throws<ExcepcionPrivilegios>(() => LogicaPrivilegios.VerificarAccesoAOpciones(null));
        }

        [Test]

        public void TestFailVerificarAccesoAPagina()
        {
            
            Assert.Throws<ExcepcionPrivilegios>(() => LogicaPrivilegios.VerificarAccesoAPagina("RegistroUsuario.aspx", "Programador"));
        }


        [Test]
        public void TestFailModificarRol()
        {
            
            Assert.Throws<NullReferenceException>(() => LogicaModificarRol.ModificarRol(null, null));

        }

        [Test]
        public void TestFailAgregarUsuario()
        {
            
            Assert.Throws<ExcepcionRegistro>(() => LogicaAgregarUsuario.AgregarUsuario(null));
        }

        [Test]
        public void TestFailConsultarListaDeEmpleados()
        {

            Assert.Throws<ExcepcionRegistro>(() => LogicaAgregarUsuario.ConsultarListaDeEmpleados());
        }

        [Test]
        public void TestFailCrearUsuarioDefault()
        {
            
            Assert.Throws<ExcepcionRegistro>(() => LogicaAgregarUsuario.CrearUsuarioDefault(null,null));
         
        }

        [Test]
        public void TestFailExisteUsuario()
        {
            Assert.Throws<ExcepcionRegistro>(() => LogicaAgregarUsuario.ExisteUsuario("")); 
            
        }

        [Test]
        public void TestFailObtenerCaracteres()
        {
            
            Assert.Throws<ExcepcionRegistro>(() => LogicaAgregarUsuario.ObtenerCaracteres(null,2));
            
        }

        [Test]
        public void TestFailPrepararUsuario()
        {
            
            Assert.Throws<ExcepcionRegistro>(() => LogicaAgregarUsuario.PrepararUsuario(null,null,null,1));
        }

       
    }
}
