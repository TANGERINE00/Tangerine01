using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine;
using DominioTangerine;

namespace PruebasUnitarias.M5
{
    [TestFixture]
    public class PruebasDatos
    {
        #region Atributos
        public Contacto theContact;
        public Contacto theContact2;
        public bool answer;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theContact = new Contacto();
            theContact.IdContacto = 1;
            theContact.Nombre = "Istvan";
            theContact.Apellido = "Bokor";
            theContact.Departamento = "Ventas";
            theContact.Cargo = "Gerente";
            theContact.Correo = "asd@asd.com";
            theContact.Telefono = "7654321";
            theContact.TipoCompañia = 1;
            theContact.IdCompañia = 1;
        }

        [TearDown]
        public void clean()
        {
            theContact = null;
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el insertar de un contacto en la base de datos
        /// </summary>
        [Test]
        public void TestAddContact()
        {
            //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"
            DatosTangerine.M5.BDContacto test = new DatosTangerine.M5.BDContacto();
            answer = test.AddContact(theContact);

            //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar el eliminar de un contacto en la base de datos
        /// </summary>
        [Test]
        public void TestDeleteContact()
        {
            //Declaro test de tipo BDContacto para poder invocar el "DeleteContact(Contacto theContact)"
            DatosTangerine.M5.BDContacto test = new DatosTangerine.M5.BDContacto();
            answer = test.DeleteContact(theContact);

            //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }
    }
}
