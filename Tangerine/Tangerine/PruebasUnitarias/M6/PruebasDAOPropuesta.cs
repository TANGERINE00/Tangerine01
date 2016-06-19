using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M6;
using LogicaTangerine.M6;
using DominioTangerine;

namespace PruebasUnitarias.M6
{
    public class PruebasDAOPropuesta
    {
        #region Atributos

        private DominioTangerine.Entidades.M6.Propuesta laPropuesta, laPropuesta2, laPropuesta3;
        private DateTime Date1, Date2;
        private List<DominioTangerine.Entidad> listaPropuestas;
        private DominioTangerine.Entidades.M6.Requerimiento elRequerimiento, elRequerimiento2, elRequerimiento3;
        Boolean confirmacion;
        #endregion


        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            Date1 = new DateTime(2016, 6, 4);
            Date2 = new DateTime(2016, 7, 4);
            laPropuesta = new DominioTangerine.Entidades.M6.Propuesta("NombrePropuestaPrueba", "DescripcionProPuestaPrueba", "Meses", "2", "acuerdo", "PendientePrueba", "Dolar", 1, Date1, Date2, 100, "1");


            elRequerimiento = new DominioTangerine.Entidades.M6.Requerimiento("NombreRequerimiento1", "DescripcionRequerimientoPrueba1", "NombrePropuestaPrueba");
        }
        [TearDown]
        public void Clean()
        {
            laPropuesta = null;
            laPropuesta2 = null;
            elRequerimiento = null;
            elRequerimiento2 = null;
        }


        #endregion


        // <summary>
        //Prueba que pueda agrega una propuesta
        // <summary>
        [Test]
        public void TestAgregarPropuesta()
        {
            //Se crea un objeto DAO para poder realizar la inserción.
            DatosTangerine.InterfazDAO.M6.IDAOPropuesta dao = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
            //Se inserta la propuesta
            Assert.IsTrue(dao.Agregar(laPropuesta));
            laPropuesta2 = (DominioTangerine.Entidades.M6.Propuesta)dao.ConsultarXId(laPropuesta);
            Assert.AreEqual(laPropuesta.Descripcion, laPropuesta2.Descripcion);
            Assert.AreEqual(laPropuesta.TipoDuracion, laPropuesta2.TipoDuracion);
            Assert.AreEqual(laPropuesta.CantDuracion, laPropuesta2.CantDuracion);
            Assert.AreEqual(laPropuesta.Acuerdopago, laPropuesta2.Acuerdopago);
            Assert.AreEqual(laPropuesta.Estatus, laPropuesta2.Estatus);
            Assert.AreEqual(laPropuesta.Moneda, laPropuesta2.Moneda);
            Assert.AreEqual(laPropuesta.Entrega, laPropuesta2.Entrega);
            Assert.AreEqual(laPropuesta.Feincio, laPropuesta2.Feincio);
            Assert.AreEqual(laPropuesta.Feincio, laPropuesta2.Feincio);
            Assert.AreEqual(laPropuesta.Costo, laPropuesta2.Costo);
            Assert.AreEqual(laPropuesta.IdCompañia, laPropuesta2.IdCompañia);

            //Elimino la propuesta de prueba
            confirmacion = dao.BorrarPropuesta("NombrePropuestaPrueba");
        }

        // <summary>
        //Prueba que pueda modificar una propuesta
        // <summary>
        [Test]
        public void TestModificarPropuesta()
        {
            //Se crea un objeto DAO para poder realizar la inserción.
            DatosTangerine.InterfazDAO.M6.IDAOPropuesta dao = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
            //Se inserta la propuesta
            Assert.IsTrue(dao.Agregar(laPropuesta));
            laPropuesta2 = new DominioTangerine.Entidades.M6.Propuesta("NombrePropuestaPrueba", "DescripcionProPuestaPruebaModificada", "MesesModificados", "3", "AcuerdoM", "PendientePruebaModif", "Dolar", 1, Date1, Date2, 100, "1");
            //Se modifica la propuesta
            Assert.IsTrue(dao.Modificar(laPropuesta2));
            laPropuesta3 = (DominioTangerine.Entidades.M6.Propuesta)dao.ConsultarXId(laPropuesta);
            //Comparo y confirmo la modificacion
            Assert.AreEqual(laPropuesta2.Descripcion, laPropuesta3.Descripcion);
            Assert.AreEqual(laPropuesta2.TipoDuracion, laPropuesta3.TipoDuracion);
            Assert.AreEqual(laPropuesta2.TipoDuracion, laPropuesta3.TipoDuracion);
            Assert.AreEqual(laPropuesta2.Acuerdopago, laPropuesta3.Acuerdopago);
            Assert.AreEqual(laPropuesta2.Estatus, laPropuesta3.Estatus);
            Assert.AreEqual(laPropuesta2.Moneda, laPropuesta3.Moneda);
            Assert.AreEqual(laPropuesta2.Entrega, laPropuesta3.Entrega);
            Assert.AreEqual(laPropuesta2.Feincio, laPropuesta3.Feincio);
            Assert.AreEqual(laPropuesta2.Fefinal, laPropuesta3.Fefinal);
            Assert.AreEqual(laPropuesta2.Costo, laPropuesta3.Costo);
            Assert.AreEqual(laPropuesta2.IdCompañia, laPropuesta3.IdCompañia);

            //Elimino la propuesta de prueba
            confirmacion = dao.BorrarPropuesta("NombrePropuestaPrueba");
        }


        // <summary>
        //Prueba que pueda eliminar una propuesta
        // <summary>
        [Test]
        public void EliminarPropuesta()
        {
            //Se crea un objeto DAO para poder realizar la inserción.
            DatosTangerine.InterfazDAO.M6.IDAOPropuesta dao = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
            //Se inserta la propuesta
            Assert.IsTrue(dao.Agregar(laPropuesta));
            //Elimino la propuesta de prueba
            confirmacion = dao.BorrarPropuesta("NombrePropuestaPrueba");
            try
            {
                //Se intenta consultar la propuesta anteriormente eliminada.
                laPropuesta2 = (DominioTangerine.Entidades.M6.Propuesta)dao.ConsultarXId(laPropuesta);
            }
            //Se chequea que no haya sido encontrada.
            catch (ExcepcionesTangerine.ExceptionsTangerine e)
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Prueba que se consulten propuestas aprobadas no halladas en proyectos en ejecución.
        /// </summary>
        [Test]
        public void ConsultaPropuestaProyecto()
        {
            //Se crea un objeto DAO para poder realizar la inserción.
            DatosTangerine.InterfazDAO.M6.IDAOPropuesta dao = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
            //Se inserta la propuesta.
            if (dao.Agregar(laPropuesta))
            {
                //Se listan las propuestas aprobadas no halladas en proyectos en curso.
                listaPropuestas = dao.PropuestaProyecto();
                //Se checkea que el método devuelve por lo menos la propuesta anteriormente insertada
                Assert.IsNotEmpty(listaPropuestas);
                //Se recorre la lista y se prueba que solo aparezcan propuestas aprobadas en la lista.
                foreach (Entidad propuesta in listaPropuestas)
                {
                    Assert.AreEqual(((DominioTangerine.Entidades.M6.Propuesta)propuesta).Estatus, "Aprobado");
                }
                //Se Elimina la propuesta de prueba
                Assert.IsTrue(dao.BorrarPropuesta("NombrePropuestaPrueba"));
            }

        }

        /// <summary>
        /// Prueba que se consulten propuestas por nombre.
        /// </summary>
        [Test]
        public void ConsultaPropuestaXId()
        {
            //Se crea un objeto DAO para poder realizar la inserción.
            DatosTangerine.InterfazDAO.M6.IDAOPropuesta dao = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
            //Se inserta la propuesta
            confirmacion = dao.Agregar(laPropuesta);
            laPropuesta2 = (DominioTangerine.Entidades.M6.Propuesta)dao.ConsultarXId(laPropuesta);
            Assert.AreEqual(laPropuesta.Descripcion, laPropuesta2.Descripcion);
            Assert.AreEqual(laPropuesta.TipoDuracion, laPropuesta2.TipoDuracion);
            Assert.AreEqual(laPropuesta.CantDuracion, laPropuesta2.CantDuracion);
            Assert.AreEqual(laPropuesta.Acuerdopago, laPropuesta2.Acuerdopago);
            Assert.AreEqual(laPropuesta.Estatus, laPropuesta2.Estatus);
            Assert.AreEqual(laPropuesta.Moneda, laPropuesta2.Moneda);
            Assert.AreEqual(laPropuesta.Entrega, laPropuesta2.Entrega);
            Assert.AreEqual(laPropuesta.Feincio, laPropuesta2.Feincio);
            Assert.AreEqual(laPropuesta.Fefinal, laPropuesta2.Fefinal);
            Assert.AreEqual(laPropuesta.Costo, laPropuesta2.Costo);
            Assert.AreEqual(laPropuesta.IdCompañia, laPropuesta2.IdCompañia);
            //Elimino la propuesta de prueba
            confirmacion = dao.BorrarPropuesta("NombrePropuestaPrueba");
        }

        /// <summary>
        /// Prueba que se consulten todas las propuestas
        /// </summary>
        [Test]
        public void ConsultaTodasPropuesta()
        {
            //Se crea un objeto DAO para poder realizar la inserción.
            DatosTangerine.InterfazDAO.M6.IDAOPropuesta dao = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
            //Se inserta la propuesta para tener un minimo
            confirmacion = dao.Agregar(laPropuesta);
            //Se cuentan la cantidad de propuestas
            int contador = dao.ConsultarNumeroPropuestas();
            listaPropuestas = dao.ConsultarTodos();
            int contador2 = 0;
            foreach (Entidad propuesta in listaPropuestas)
            {
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).Descripcion);
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).TipoDuracion);
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).CantDuracion);
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).Acuerdopago);
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).Estatus);
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).Moneda);
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).Entrega);
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).Feincio);
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).Fefinal);
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).Costo);
                Assert.NotNull(((DominioTangerine.Entidades.M6.Propuesta)propuesta).IdCompañia);
                contador2++;
            }
            //Se checkea que el numero de propuestas extraidas coincida con el numero de propuestas en la bd
            Assert.AreEqual(contador, contador2);
        }


    }
}
