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
            bool resultado = BDUsuario.AgregarUsuario( theUser );

            Assert.IsTrue( resultado );
        }

        /// <summary>
        /// Método para probar el método ModifcarRolUsuario() de la clase BDUsuario en DatosTangerine
        /// </summary>
        [Test]
        public void TestModificarRolUsuario() 
        {
            theRol.Nombre = "Director";

            theUser.Rol = theRol;

            bool resultado = BDUsuario.ModificarRolUsuario( theUser );

            Assert.IsTrue( resultado );
        }

        /// <summary>
        /// Método para probar el método ModifcarContraseniaUsuario() de la clase BDUsuario en DatosTangerine
        /// </summary>
        [Test]
        public void TestModificarContraseniaUsuario() 
        {
            theUser.Contrasenia = "modificacion1";

            bool resultado = BDUsuario.ModificarContraseniaUsuario( theUser );

            Assert.IsTrue( resultado );
        }
    }
}
