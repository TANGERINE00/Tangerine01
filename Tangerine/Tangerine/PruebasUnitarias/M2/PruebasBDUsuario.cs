using DominioTangerine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.M2
{
    [TestFixture]
    class PruebasBDUsuario
    {
        #region Atributos

        public Usuario theUser;
        public Rol theRol;
        
        #endregion 

        #region SetUp and TearDown
        
        [SetUp]
        public void Init() 
        {
            theRol = new Rol( "Gerente" );
            theUser = new Usuario( "userTest", "testapp1", "Activo", theRol, 0, DateTime.Now );
        }

        public void Clean() 
        {
            theRol = null;
            theUser = null;
        }
        
        #endregion
    }
}
