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
        /// Método para probar el método ConsultarListaDeEmpleados de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestConsultarListaDeEmpleados() 
        {
            Assert.IsNotNull(LogicaAgregarUsuario.ConsultarListaDeEmpleados());
        }
        /// <summary>
        /// Metodo para probar el metodo ExisteUsuario de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestExisteUsuario()
        {
            BDUsuario.AgregarUsuario(theUser);
            Assert.IsTrue(LogicaAgregarUsuario.ExisteUsuario("userTest"));
            Assert.IsFalse(LogicaAgregarUsuario.ExisteUsuario(""));
        }
        /// <summary>
        /// Metodo para probar el metodo CrearUsuarioDefault de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestCrearUsuarioDefault()
        {
            Assert.AreEqual(usuarioDefault,LogicaAgregarUsuario.CrearUsuarioDefault("carlos","lozano"));
            Assert.IsEmpty(LogicaAgregarUsuario.CrearUsuarioDefault("",""));
        }


        /// <summary>
        /// Metodo para probar el metodo ObtenerCaracateres() de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestObtenerCaracteres()
        {
            String prueba = "prueba";
            Assert.AreEqual("pr", LogicaAgregarUsuario.ObtenerCaracteres(prueba, 2));
            Assert.IsEmpty("",LogicaAgregarUsuario.ObtenerCaracteres("",2));
        }

        /// <summary>
        /// Metodo para probar el metodo PrepararUsuario() de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestPrepararUsuario()
        {
            Assert.IsTrue(LogicaAgregarUsuario.PrepararUsuario("usuarionuevo", "contrasenanueva", "Gerente",1234));
        }


        /// <summary>
        /// Metodo para probar el metodo ObtenerUsuario() de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestObtenerUsuario()
        {
            
            Assert.IsNotNull(LogicaModificarRol.ObtenerUsuario(theEmpleado));
        }

        /// <summary>
        /// Metodo para probar el metodo ModificarRol de la clase LogicaModificarRol en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestModificarRol()
        {
            
            Assert.IsTrue(LogicaModificarRol.ModificarRol("craloz", "gerente"));

        }
       
        /// <summary>
        /// Metodo para probar el metodo VerificarAccesoAOpciones de la clase LogicaPrivilegios en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestVerificarAccesoAOpciones()
        {

            Assert.IsNotNull(LogicaPrivilegios.VerificarAccesoAOpciones("Gerente"));
            Assert.IsNotNull(LogicaPrivilegios.VerificarAccesoAOpciones("Administrador"));
            Assert.IsNotNull(LogicaPrivilegios.VerificarAccesoAOpciones("Programador"));
            Assert.IsNotNull(LogicaPrivilegios.VerificarAccesoAOpciones("Director"));
        }

        /// <summary>
        /// Meotodo para probar el metodo VerrificarUsuarioDeEmpleado de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]

        public void TestVerificarUsuarioDeEmpleado() 
        {
            Assert.IsFalse(LogicaAgregarUsuario.VerificarUsuarioDeEmpleado(0));
        }

        /// <summary>
        /// Metodo para probar el metodo VerificarAccesoAPaginas de la clase LogicaPrivilegios en
        /// LogicaTangerine
        /// </summary>
        [Test]

        public void TestVerificarAccesoAPaginas()
        {
            Assert.IsTrue(LogicaPrivilegios.VerificarAccesoAPagina("../../GUI/M2/RegistroUsuario.aspx", "Programador"));
            Assert.IsFalse(LogicaPrivilegios.VerificarAccesoAPagina("../../GUI/M1/Dashboard.aspx","Programador"));
        }

        /// <summary>
        /// Método para probar el disparo de una excepción el método VerificarAccesoAOpciones() de la clase LogicaPrivilegios en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestFailVerificarAccesoAOpciones()
        {
            Assert.Throws<ExcepcionPrivilegios>(() => LogicaPrivilegios.VerificarAccesoAOpciones(null));
        }

        /// <summary>
        /// Método para probar el disparo de una excepción el método VerificarAccesoAPagina() de la clase LogicaPrivilegios en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestFailVerificarAccesoAPagina()
        {
            Assert.Throws<ExcepcionPrivilegios>(() => LogicaPrivilegios.VerificarAccesoAPagina("RegistroUsuario.aspx", "Programador"));
            Assert.Throws<ExcepcionPrivilegios>(() => LogicaPrivilegios.VerificarAccesoAPagina("", ""));
        }

        /// <summary>
        /// Método para probar el disparo de una excepción el método ModificarRol() de la clase LogicaModificarRol en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestFailModificarRol()
        {
            Assert.Throws<NullReferenceException>(() => LogicaModificarRol.ModificarRol(null, null));

        }

        /// <summary>
        /// Método para probar el disparo de una excepción el método AgregarUsuario() de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestFailAgregarUsuario()
        {
            Assert.Throws<ExcepcionRegistro>(() => LogicaAgregarUsuario.AgregarUsuario(null));
        }

        

        /// <summary>
        /// Método para probar el disparo de una excepción el método CrearUsuarioDefault() de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestFailCrearUsuarioDefault()
        {
            Assert.Throws<ExcepcionRegistro>(() => LogicaAgregarUsuario.CrearUsuarioDefault(null, null));
        }


        /// <summary>
        /// Método para probar el disparo de una excepción el método ObtenerCaracteres() de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestFailObtenerCaracteres()
        {
            Assert.Throws<ExcepcionRegistro>(() => LogicaAgregarUsuario.ObtenerCaracteres(null, 2));
        }

        /// <summary>
        /// Método para probar el disparo de una excepción el método PrepararUsuario() de la clase LogicaAgregarUsuario en
        /// LogicaTangerine
        /// </summary>
        [Test]
        public void TestFailPrepararUsuario()
        {
            Assert.Throws<ExcepcionRegistro>(() => LogicaAgregarUsuario.PrepararUsuario(null, null, null, 1));
        }
       
    }
}
