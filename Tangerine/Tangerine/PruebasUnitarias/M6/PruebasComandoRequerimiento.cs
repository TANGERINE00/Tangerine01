using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace PruebasUnitarias.M6
{
    public class PruebasComandoRequerimiento
    {
        #region Atributos

        private DominioTangerine.Entidades.M6.Propuesta laPropuesta;
        private DateTime Date1, Date2;
        private List<DominioTangerine.Entidad> listaRequerimientos;
        private DominioTangerine.Entidades.M6.Requerimiento elRequerimiento, elRequerimiento2, elRequerimiento3;
        Boolean confirmacion;
        LogicaTangerine.Comando<Entidad> comandoEntidad;
        LogicaTangerine.Comando<List<Entidad>> comandoListEntidad;
        LogicaTangerine.Comando<bool> comandoBool;
        LogicaTangerine.Comando<int> comandoInt;
        int contador;
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
            elRequerimiento = null;
            elRequerimiento2 = null;
            contador = 0;
            comandoEntidad = null;
            comandoListEntidad = null;
            comandoBool = null;
            comandoInt = null;
        }


        #endregion

        // <summary>
        //Prueba que se agrega un requerimiento
        // </summary>

        [Test]
        public void TestAgregarRequerimiento()
        {
            //Se inserta la propuesta
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(laPropuesta);
            Assert.IsTrue(comandoBool.Ejecutar());
            //Se obtiene el número de requerimientos totales antes de la inserción
            comandoInt = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarNumeroRequerimientos();
            contador = comandoInt.Ejecutar();
            //Se agrega un Requerimiento y pruebo que se agregó
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(elRequerimiento);
            Assert.IsTrue(comandoBool.Ejecutar());
            //Se checkea que la cantidad total de requerimientos en la base de datos haya aumentado en una unidad
            Assert.AreEqual(comandoInt.Ejecutar(), contador + 1);
            //Pruebo que el requerimiento pertenece a la propuesta que acabo de agregar
            comandoListEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarRequerimientoXPropuesta(laPropuesta);
            listaRequerimientos = comandoListEntidad.Ejecutar();
            Assert.AreEqual("NombreRequerimiento1", 
            ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).CodigoRequerimiento);
            Assert.AreEqual("DescripcionRequerimientoPrueba1",
            ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).Descripcion);
            Assert.AreEqual("NombrePropuestaPrueba", 
            ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).CodigoPropuesta);

            //Elimino la propuesta de prueba junto con el requerimiento
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoBorrarPropuesta(laPropuesta);
            confirmacion = comandoBool.Ejecutar();
        }

        // <summary>
        //Prueba que se modifique un requerimiento
        // </summary>
        [Test]
        public void TestModificarRequerimiento()
        {
            elRequerimiento2 = new DominioTangerine.Entidades.M6.Requerimiento("NombreRequerimiento1",
            "DescripcionRequerimientoPrueba1Modificado", "NombrePropuestaPrueba");
            //Se inserta la propuesta
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(laPropuesta);
            Assert.IsTrue(comandoBool.Ejecutar());
            //Agregar un Requerimiento y pruebo que se agregó
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(elRequerimiento);
            Assert.IsTrue(comandoBool.Ejecutar());
            //Modifico el requerimiento
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoModificarRequerimiento(elRequerimiento2);
            Assert.IsTrue(comandoBool.Ejecutar());
            //Consulto el requerimiento modificado 
            comandoListEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarRequerimientoXPropuesta(laPropuesta);
            listaRequerimientos = comandoListEntidad.Ejecutar();
            Assert.AreEqual("NombreRequerimiento1", 
            ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).CodigoRequerimiento);
            Assert.AreEqual("DescripcionRequerimientoPrueba1Modificado", 
            ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).Descripcion);
            Assert.AreEqual("NombrePropuestaPrueba", 
            ((DominioTangerine.Entidades.M6.Requerimiento)listaRequerimientos.ElementAt(0)).CodigoPropuesta);

            //Elimino la propuesta de prueba junto con el requerimiento
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoBorrarPropuesta(laPropuesta);
            confirmacion = comandoBool.Ejecutar();
        }

        // <summary>
        //Prueba que se consulten requerimientos por propuesta
        // </summary>
        [Test]
        public void TestConsultarRequerimientosXPropuesta()
        {
            elRequerimiento2 = new DominioTangerine.Entidades.M6.Requerimiento("NombreRequerimiento1",
            "DescripcionRequerimientoPrueba", "NombrePropuestaPrueba");
            elRequerimiento3 = new DominioTangerine.Entidades.M6.Requerimiento("NombreRequerimiento2",
            "DescripcionRequerimientoPrueba2", "NombrePropuestaPrueba");
            //Se inserta la propuesta
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(laPropuesta);
            Assert.IsTrue(comandoBool.Ejecutar());
            //Agregar un Requerimiento y pruebo que se agregó
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(elRequerimiento);
            Assert.IsTrue(comandoBool.Ejecutar());
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(elRequerimiento2);
            Assert.IsTrue(comandoBool.Ejecutar());
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(elRequerimiento3);
            Assert.IsTrue(comandoBool.Ejecutar());
            comandoListEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarRequerimientoXPropuesta(laPropuesta);
            listaRequerimientos = comandoListEntidad.Ejecutar();
            foreach (Entidad requerimiento in listaRequerimientos)
            {
                Assert.AreEqual(((DominioTangerine.Entidades.M6.Requerimiento)requerimiento).CodigoPropuesta,
                "NombrePropuestaPrueba");
            }
            //Elimino la propuesta de prueba junto con los requerimientos
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoBorrarPropuesta(laPropuesta);
            confirmacion = comandoBool.Ejecutar();
        }

        // <summary>
        //Prueba que pueda eliminar un requerimiento
        // <summary>
        [Test]
        public void TestEliminarRequerimiento()
        {
            //Se obtiene el número de propuestas totales antes del insertado
            comandoInt = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarNumeroRequerimientos();
            contador = comandoInt.Ejecutar();
            //Se inserta el requerimiento
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(elRequerimiento);
            Assert.IsTrue(comandoBool.Ejecutar());
            //Elimino el requerimiento de prueba
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoEliminarRequerimiento(elRequerimiento);
            Assert.IsTrue(comandoBool.Ejecutar());
            //Se checkea que haya disminuido en una unidad la cantidad de requerimientos en la base de datos
            Assert.AreEqual(comandoInt.Ejecutar(), contador);
            try
            {
                //Se intenta consultar el requerimiento anteriormente eliminado.
                comandoEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdRequerimiento(elRequerimiento);
                elRequerimiento = (DominioTangerine.Entidades.M6.Requerimiento)comandoEntidad.Ejecutar();
            }
            //Se chequea que no haya sido encontrada.
            catch (ExcepcionesTangerine.ExceptionsTangerine)
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Prueba que se requerimientos por nombre.
        /// </summary>
        [Test]
        public void TestConsultaRequerimientoXId()
        {
            //Se inserta el requerimiento
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(elRequerimiento);
            Assert.IsTrue(comandoBool.Ejecutar());
            comandoEntidad = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdRequerimiento(elRequerimiento);
            elRequerimiento2 = (DominioTangerine.Entidades.M6.Requerimiento)comandoEntidad.Ejecutar();
            Assert.AreEqual(elRequerimiento.CodigoRequerimiento, elRequerimiento2.CodigoRequerimiento);
            Assert.AreEqual(elRequerimiento.Descripcion, elRequerimiento2.Descripcion);
            Assert.AreEqual(elRequerimiento.CodigoPropuesta, elRequerimiento2.CodigoPropuesta);
            //Elimino el requerimiento
            comandoBool = LogicaTangerine.Fabrica.FabricaComandos.ComandoEliminarRequerimiento(elRequerimiento);
            confirmacion = comandoBool.Ejecutar();
        }
    }
}
