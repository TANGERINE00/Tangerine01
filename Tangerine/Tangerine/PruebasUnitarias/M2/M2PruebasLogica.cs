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
        public void TestConsultarListaDeEmpleados() 
        {
            Assert.IsNotNull(LogicaAgregarUsuario.ConsultarListaDeEmpleados());
        }

        [Test]
        public void TestExisteUsuario()
        {
            Assert.IsTrue(LogicaAgregarUsuario.ExisteUsuario("luarropa"));
            Assert.IsFalse(LogicaAgregarUsuario.ExisteUsuario(""));
        }

        [Test]
        public void TestCrearUsuarioDefault()
        {
            String usuarioDefault = "caloza";
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
            Empleado theEmpleado = new Empleado();
            Assert.IsNotNull(LogicaModificarRol.ObtenerUsuario(theEmpleado));
        }

       
        [Test]
        public void TestModificarRol()
        {
            Assert.IsTrue(LogicaModificarRol.ModificarRol("luarropa", "Gerente"));

        }

      

        [Test]
        public void TestConsultarListaDeUsuarios()
        {
            Assert.IsNotNull(LogicaModificarRol.ConsultarListaDeUsuarios());
        }



    }
}
