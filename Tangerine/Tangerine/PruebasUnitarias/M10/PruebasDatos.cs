using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using DatosTangerine.M10;
using DominioTangerine;

namespace PruebasUnitarias.M10
{
    [TestFixture]
    class PruebaDatos
    {
        #region Atributos
        public Empleado theEmpleado;
        public BDEmpleado theEmpleado2;
        public bool answer;
        public List<Empleado> theEmpleados;
        public List<LugarDireccion> theDireccion;
        public List<Cargo> theCargos;
        public Hashtable listaHash;
        public Cargo theCargo;
        int empleadoId;
        public Empleado consultaEmpleado;
        public string pais;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theEmpleado = new Empleado();
            theEmpleado = new Empleado();
            List<LugarDireccion> direccion = new List<LugarDireccion>();
            theCargo = new Cargo("Gerente", "Gerente de proyectos de software",
                                    DateTime.ParseExact("04/01/2016", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                    "Tiempo compleato", Double.Parse("60"));

            direccion.Add(new LugarDireccion("Venezuela", "Pais"));
            direccion.Add(new LugarDireccion("Distrito Capital", "Estado"));
            direccion.Add(new LugarDireccion("Caracas", "Ciudad"));
            direccion.Add(new LugarDireccion("Plaza Sucre", "Direccion"));

            theEmpleado = new Empleado(0, "Antonio", "Juan", "Garcia",
                                               "Gobea", "Masculino",
                                               19627934,
                                               DateTime.ParseExact("05/02/1991", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                               "Activo", "Bachiller", "antonio11346@hotmail.com", theCargo,
                                               direccion);


            empleadoId = 1;
            pais = "Venezuela";
            consultaEmpleado = new Empleado();

        }

        [TearDown]
        public void clean()
        {
            theEmpleado = null;
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el insertar de un empleado en la base de datos
        /// </summary>
        [Test]
        public void TestAddEmpleado()
        {
            //Declaro test de tipo BDEmpleado para poder invocar el "AddEmpleado(Empleado theEmpleado)"
            answer = BDEmpleado.AddEmpleado(theEmpleado);

            //answer obtiene true si se inserta el empleado
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar la consulta de empleados en la base de datos
        /// </summary>
        [Test]
        public void TestListarEmpleado()
        {
            //Declaro test de tipo BDEmpleado para poder invocar el metodo "ListarEmpleados()"
            theEmpleados = BDEmpleado.ListarEmpleados();

            //La prueba pasa el metodo retorna al menos 1 empleado
            Assert.IsTrue(theEmpleados.Count > 0);
        }

        /// <summary>
        /// Prueba que permite verificar la consulta de un empleado dado su id a la base de datos
        /// </summary>
        [Test]
        public void TestGetEmpleadoById()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "GetEmployeeById(empleadoId)"
            consultaEmpleado = BDEmpleado.GetEmployeeById(empleadoId);

            //La prueba pasa el metodo retorna a un empleado
            Assert.NotNull(consultaEmpleado);
        }

        /// <summary>
        /// Prueba que permite verificar la consulta de una lista de paises en la base de datos
        /// </summary>
        [Test]
        public void TestGetListaPaises()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "GetElementsForSelectCountry()"
            theDireccion = BDEmpleado.GetElementsForSelectCountry();

            //La prueba pasa el metodo retorna al menos 1 pais
            Assert.IsTrue(theDireccion.Count > 0);

        }

        /// <summary>
        /// Prueba que permite verificar la consulta de una lista de estados dado el id de un pais
        /// en la base de datos
        /// </summary>
        [Test]
        public void TestGetListaEstados()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "GetElementsForSelectState()"
            theDireccion = BDEmpleado.GetElementsForSelectState(pais);

            //La prueba pasa el metodo retorna al menos 1 pais
            Assert.IsTrue(theDireccion.Count > 0);
        }

        /// <summary>
        /// Prueba que permite verificar la consulta de una lista de cargos en la base de datos
        /// </summary>
        [Test]
        public void TestGetListaCargos()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "GetElementsForSelectJob()"
            theCargos = BDEmpleado.GetElementsForSelectJob();

            //La prueba pasa el metodo retorna al menos 1 pais
            Assert.IsTrue(theCargos.Count > 0);

        }

        /// <summary>
        /// Prueba que permite verificar la consulta de una lista de empleados cuyo cargo es el de
        /// "Gerente"
        /// </summary>
        [Test]
        public void TestGetListarGerentes()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "ListarGerentes()"
            theEmpleados = BDEmpleado.ListarGerentes();
            answer = true;
            foreach (Empleado empleadoPrueba in theEmpleados)
            {
                if (empleadoPrueba.Job.Nombre != "Gerente")
                    answer = false;
            }

            //La prueba pasa el metodo retorna al menos 1 gerente
            Assert.IsTrue((theEmpleados.Count > 0) && (answer));
        }

        /// <summary>
        /// Prueba que permite verificar la consulta de una lista de empleados cuyo cargo es el de
        /// "Programador"
        /// </summary>
        [Test]
        public void TestGetListarProgramadores()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "ListarGerentes()"
            theEmpleados = BDEmpleado.ListarProgramadores();
            answer = true;
            foreach (Empleado empleadoPrueba in theEmpleados)
            {
                if (empleadoPrueba.Job.Nombre != "Programador")
                    answer = false;
            }

            //La prueba pasa el metodo retorna al menos 1 programador
            Assert.IsTrue((theEmpleados.Count > 0) && (answer));
        }

        /// <summary>
        /// Prueba que permite retornar una tabla hash con la direccion del Empleado separada en niveles:
        /// "Pais" -> "Estado" -> "Ciudad" -> "Direccion"
        /// </summary>
        [Test]
        public void TestGetListaHash()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "ListElementos(theEmpleado)"
            listaHash = BDEmpleado.listElementos(theEmpleado);

            //La prueba pasa el metodo retorna al menos 1 programador
            Assert.NotNull(listaHash);
        }

        /// <summary>
        /// Prueba que permite verificar la modificacion del status de un empleado de activo a inactivo
        /// o de inactivo a activo, segun sea su estado actual
        /// </summary>
        [Test]
        public void TestCambiarBDEstatusEmpleado()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "CambiarEstatus(empleadoId)"
            answer = BDEmpleado.CambiarEstatus(empleadoId);

            //La prueba pasa el metodo retorna al menos 1 pais
            Assert.IsTrue(answer);

            //Retorno al empleado a su estado anterior
            answer = BDEmpleado.CambiarEstatus(empleadoId);

        }
    }
}
