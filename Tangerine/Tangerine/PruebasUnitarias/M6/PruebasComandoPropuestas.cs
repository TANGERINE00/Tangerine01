using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using System.Collections;

namespace PruebasUnitarias.M6
{
    public class PruebasComandoPropuestas
    {
        #region Atributos

        private DominioTangerine.Entidades.M6.Propuesta laPropuesta, laPropuesta2, laPropuesta3;
        private DateTime Date1, Date2;
        private List<DominioTangerine.Entidad> listaPropuestas;
        private DominioTangerine.Entidades.M6.Requerimiento elRequerimiento;
        Boolean confirmacion;
        int contador;
        LogicaTangerine.Comando<Entidad> comandoEntidad;
        LogicaTangerine.Comando<List<Entidad>> comandoListEntidad;
        LogicaTangerine.Comando<bool> comandoBool;
        LogicaTangerine.Comando<int> comandoInt;
        #endregion


        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            Date1 = new DateTime(2016, 6, 4);
            Date2 = new DateTime(2016, 7, 4);
            laPropuesta = new DominioTangerine.Entidades.M6.Propuesta("NombrePropuestaPrueba",
            "DescripcionProPuestaPrueba", "Meses", "2", "acuerdo", "PendientePrueba", "Dolar", 1, Date1, Date2, 100, "1");
            elRequerimiento = new DominioTangerine.Entidades.M6.Requerimiento("NombreRequerimiento1",               
            "DescripcionRequerimientoPrueba1", "NombrePropuestaPrueba");
        }
        [TearDown]
        public void Clean()
        {
            laPropuesta = null;
            laPropuesta2 = null;
            elRequerimiento = null;
            contador = 0;
            comandoEntidad = null;
            comandoListEntidad = null;
            comandoBool = null;
            comandoInt = null;
        }


        #endregion


        // <summary>
        //Prueba que pueda agregar una propuesta
        // <summary>
        [Test]
        public void TestAgregarPropuesta()
        {
            //Se obtiene el número de propuestas totales antes de la inserción
            comandoEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(laPropuesta);
            comandoInt = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarNumeroPropuestas();
            contador = comandoInt.Ejecutar();
            //Se inserta la propuesta
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(laPropuesta);
            Assert.IsTrue(comandoBool.Ejecutar());
            //Se checkea que aumente en una unidad el total de las propuestas en la base de datos.
            Assert.AreEqual(comandoInt.Ejecutar(), contador + 1);
            comandoEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(laPropuesta);
            laPropuesta2 = (DominioTangerine.Entidades.M6.Propuesta)comandoEntidad.Ejecutar();
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
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoBorrarPropuesta(laPropuesta);
            confirmacion = comandoBool.Ejecutar();
        }

        // <summary>
        //Prueba que pueda modificar una propuesta
        // <summary>
        [Test]
        public void TestModificarPropuesta()
        {
            //Se inserta la propuesta
            comandoEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(laPropuesta);
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(laPropuesta);
            Assert.IsTrue(comandoBool.Ejecutar());
            laPropuesta2 = new DominioTangerine.Entidades.M6.Propuesta("NombrePropuestaPrueba", 
            "DescripcionProPuestaPruebaModificada", "MesesModificados", "3", "AcuerdoM", "PendientePruebaModif", "Dolar", 
            1, Date1, Date2, 100, "1");
            //Se modifica la propuesta
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoModificarPropuesta(laPropuesta2);
            Assert.IsTrue(comandoBool.Ejecutar());
            laPropuesta3 = (DominioTangerine.Entidades.M6.Propuesta)comandoEntidad.Ejecutar();
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
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoBorrarPropuesta(laPropuesta2);
            confirmacion = comandoBool.Ejecutar();
        }


        // <summary>
        //Prueba que pueda eliminar una propuesta
        // <summary>
        [Test]
        public void TestEliminarPropuesta()
        {
            //Se obtiene el número de propuestas totales antes del insertado
            comandoInt=LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarNumeroPropuestas();
            comandoEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(laPropuesta);
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(laPropuesta);
            contador = comandoInt.Ejecutar();
            //Se inserta la propuesta
            Assert.IsTrue(comandoBool.Ejecutar());
            //Elimino la propuesta de prueba
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoBorrarPropuesta(laPropuesta);
            confirmacion = comandoBool.Ejecutar();
            //Se checkea que haya disminuido en una unidad la cantidad de propuestas en la base de datos
            Assert.AreEqual(comandoInt.Ejecutar(), contador);
            try
            {
                //Se intenta consultar la propuesta anteriormente eliminada.
                laPropuesta2 = (DominioTangerine.Entidades.M6.Propuesta)comandoEntidad.Ejecutar();
            }
            //Se chequea que no haya sido encontrada.
            catch (ExcepcionesTangerine.ExceptionsTangerine)
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Prueba que se consulten propuestas aprobadas no halladas en proyectos en ejecución.
        /// </summary>
        [Test]
        public void TestConsultaPropuestaProyecto()
        {
            //Se inserta la propuesta.
            comandoListEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarPropuestaXProyecto();
            comandoEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(laPropuesta);
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(laPropuesta);
            if (comandoBool.Ejecutar())
            {
                //Se listan las propuestas aprobadas no halladas en proyectos en curso.
                listaPropuestas = comandoListEntidad.Ejecutar();
                //Se checkea que el método devuelve por lo menos la propuesta anteriormente insertada
                Assert.IsNotEmpty(listaPropuestas);
                //Se recorre la lista y se prueba que solo aparezcan propuestas aprobadas en la lista.
                foreach (Entidad propuesta in listaPropuestas)
                {
                    Assert.AreEqual(((DominioTangerine.Entidades.M6.Propuesta)propuesta).Estatus, "Aprobado");
                }
                //Se Elimina la propuesta de prueba
                comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoBorrarPropuesta(laPropuesta);
                Assert.IsTrue(comandoBool.Ejecutar());
            }


        }

        /// <summary>
        /// Prueba que se consulten propuestas por nombre.
        /// </summary>
        [Test]
        public void TestConsultaPropuestaXId()
        {
            //Se inserta la propuesta
            comandoListEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarPropuestaXProyecto();
            comandoEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(laPropuesta);
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(laPropuesta);

            confirmacion = comandoBool.Ejecutar();
            laPropuesta2 = (DominioTangerine.Entidades.M6.Propuesta)comandoEntidad.Ejecutar();
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
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoBorrarPropuesta(laPropuesta);
            confirmacion = comandoBool.Ejecutar();
        }

        /// <summary>
        /// Prueba que se consulten todas las propuestas
        /// </summary>
        [Test]
        public void TestConsultaTodasPropuesta()
        {
            //Se inserta la propuesta para tener un minimo
            comandoListEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarPropuestaXProyecto();
            comandoEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(laPropuesta);
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(laPropuesta);

            confirmacion = comandoBool.Ejecutar();
            //Se cuentan la cantidad de propuestas
            comandoListEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarTodosPropuesta();
            listaPropuestas = comandoListEntidad.Ejecutar();
            //Se almacena el tamaño de la estructura de propuestas
            int cantidadPropuestas = listaPropuestas.Count;
            comandoListEntidad = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompaniasActivas();
            //Se obtienen las compañías activas 
            List<Entidad> companias = comandoListEntidad.Ejecutar();
            //Se crea una estructura de datos
            ArrayList idscompaniasactivas = new ArrayList();
            //Se llena la estructura de datos con los ids de las compañias activas
            foreach (Entidad compania in companias)
            {
                idscompaniasactivas.Add(((DominioTangerine.Entidades.M4.CompaniaM4)compania).Id.ToString());
            }
            //Se inicializa un contador para las propuestas
            contador = 0;
            //Se recorre la estructura con las propuestas y se cuentan las propuestas que cuyo id de compañía estén en la estructura anteriormente creada
            foreach (Entidad propuesta in listaPropuestas)
            {
                if (idscompaniasactivas.Contains(((DominioTangerine.Entidades.M6.Propuesta)propuesta).IdCompañia))
                {
                    //Se verifica que los campos no estén en null
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
                    contador++;
                }
            }
            //Se verifica que la totalidad de las propuestas en la estructura de datos pertenezcan a una compañia activa
            Assert.AreEqual(cantidadPropuestas, contador);
            //Elimino la propuesta de prueba
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoBorrarPropuesta(laPropuesta);
            confirmacion = comandoBool.Ejecutar();
        }



    }
}
