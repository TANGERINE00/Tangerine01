using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using DominioTangerine;
using LogicaTangerine.M1;

namespace PruebasUnitarias.M1
{
    [TestFixture]
    class M1PruebasLogica
    {
        #region Atributos
        string usuario;
        string clave;
        bool answer;
        LogicaM1 logicaM1 = new LogicaM1();
        List<String> campos;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void Init()
        {
            usuario = "luarropa";
            clave = "1234";
            campos = new List<string>(new string[] { usuario, clave });
        }

        [TearDown]
        public void Clean()
        {
            usuario = null;
            clave = null;
        }

        #endregion

        /// <summary>
        /// Prueba que permite verificar la validacion de que una lista de strings no contenga
        /// ningun caracter vacio
        /// </summary>
        [Test]
        public void TestValidarCredencialVacio()
        {
            answer = logicaM1.ValidarVacio(campos);

            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar la validacion de que un string solo contenga
        /// caracteres alfanumericos, underscore o guion 
        /// </summary>
        [Test]
        public void TestValidarCaracter()
        {
            answer = logicaM1.ValidarCaracter(usuario);

            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar la validacion y existencia de un Usuario registrado
        /// </summary>
        [Test]
        public void TestValidarUsuario()
        {
            answer = logicaM1.ValidarUsuario(usuario,clave);

            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar la existencia de un Usuario registrado
        /// </summary>
        [Test]
        public void TestConsultarUsuario()
        {
            answer = logicaM1.ConsultarUsuario(usuario, clave);

            Assert.IsTrue(answer);
        }


    }
}
