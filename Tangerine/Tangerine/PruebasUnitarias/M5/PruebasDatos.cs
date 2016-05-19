using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M5;
using DominioTangerine;


namespace PruebasUnitarias.M5
{
    [TestFixture]
    public class PruebasDatos
    {
        #region Atributos
        bool answer;
        public Contacto theContact;
        public Contacto theContact2;
        public List<Contacto> listContact;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theContact = new Contacto();
            theContact.IdContacto = 8;
            theContact.Nombre = "Istvan";
            theContact.Apellido = "Bokor";
            theContact.Departamento = "Ventas";
            theContact.Cargo = "Gerente";
            theContact.Correo = "asd@asd.com";
            theContact.Telefono = "7654321";
            theContact.TipoCompañia = 1;
            theContact.IdCompañia = 1;
            answer = false;
        }

        [TearDown]
        public void clean()
        {
            answer = false;
            theContact = null;
            theContact2 = null;
            listContact = null;
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el insertar de un contacto en la base de datos
        /// </summary>
        [Test]
        public void TestAddContact()
        {
            //Agrego el contacto a eliminar
            Assert.IsTrue(BDContacto.AddContact(theContact));
            //Consulto todos los contactos de la compania 1
            listContact = BDContacto.ContactCompany(1, 1);
            //Mando a eliminar el id del ultimo contacto de la lista (El contacto que inserte)
            answer = BDContacto.DeleteContact(listContact[listContact.Count - 1].IdContacto);
        }

        /// <summary>
        /// Prueba que permite verificar el modificar de un contacto en la base de datos
        /// </summary>
        [Test]
        public void TestChangeContact()
        {
            //Agrego el contacto a modificar, theContact.Nombre = Istvan
            answer = BDContacto.AddContact(theContact);
            //Consulto todos los contactos de la compania 1 para traer el id del contacto insertado
            listContact = BDContacto.ContactCompany(1, 1);
            //Cambio el campo del nombre y asigno el id de la bd
            theContact.IdContacto = listContact[listContact.Count - 1].IdContacto;
            theContact.Nombre = "Joaquin";
            //Invoco "ChangeContact(Contacto theContact)" y valido si regresa true
            Assert.IsTrue(BDContacto.ChangeContact(theContact));
            //Vuelvo a traer la lista con el cambio del nombre del ultimo contacto
            listContact = BDContacto.ContactCompany(1, 1);
            //Valido el nombre del contacto con el string que le asugne
            Assert.AreEqual("Joaquin", listContact[listContact.Count - 1].Nombre);
            //Elimino ese contacto de la bd
            answer = BDContacto.DeleteContact(listContact[listContact.Count - 1].IdContacto);
        }

        /// <summary>
        /// Prueba que permite verificar el eliminar de un contacto en la base de datos
        /// </summary>
        [Test]
        public void TestDeleteContact()
        {
            //Agrego el contacto a eliminar
            answer = BDContacto.AddContact(theContact);
            //Consulto todos los contactos de la compania 1
            listContact = BDContacto.ContactCompany(1,1);
            //Mando a eliminar el id del ultimo contacto de la lista (El contacto que inserte)
            answer = BDContacto.DeleteContact(listContact[listContact.Count-1].IdContacto);
            //answer obtiene true si se elimina el contacto
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar el consultar lista de contactos de una empresa en bd
        /// </summary>
        [Test]
        public void TestContactCompany()
        {
            //Agrego el contacto a eliminar
            answer = BDContacto.AddContact(theContact);
            //Consulto todos los contactos de la compania 1
            listContact = BDContacto.ContactCompany(1, 1);
            //answer obtiene true si se elimina el contacto
            Assert.IsNotNull(listContact);
            //Mando a eliminar el id del ultimo contacto de la lista (El contacto que inserte)
            answer = BDContacto.DeleteContact(listContact[listContact.Count - 1].IdContacto);

        }
    }
}
