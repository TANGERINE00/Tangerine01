using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using DominioTangerine.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PruebasUnitarias.M5
{
    [TestFixture]
    public class PruebasDatos
    {
        #region Atributos
        private Entidad _contactoAgregar;
        private IDAOContacto _daoContacto;
        private bool _respuesta;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            _contactoAgregar = FabricaEntidades.crearContactoSinId( "pruebaNombre", "pruebaApellido",
                                                                    "pruebaDepartamento", "pruebaCargo",
                                                                    "pruebaTelefono", "pruebaCorreo", 1, 1 );
            _daoContacto = FabricaDAOSqlServer.crearDAOContacto();
            _respuesta = false;
        }

        [TearDown]
        public void clean()
        {
        }
        #endregion

        #region Pruebas Unitarias
        [Test]
        public void PruebaDAOContactoAgregar() 
        {
            _respuesta = _daoContacto.Agregar( _contactoAgregar );
            Assert.True( _respuesta );


        }

        #endregion
    }
}
