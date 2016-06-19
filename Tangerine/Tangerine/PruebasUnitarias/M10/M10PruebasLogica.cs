using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;
using DominioTangerine;
using LogicaTangerine.M10;

namespace PruebasUnitarias.M10
{
    [TestFixture]
    class M10PruebasLogica
    {
        #region Atributos
        public Empleado theEmpleado;
        public Empleado consultaEmpleado;
        public List<Empleado> theEmpleados;
        public List<LugarDireccion> theDireccion;
        public List<Cargo> theCargos;
        public LogicaM10 logicaM10;
        public int empleadoId;
        string pais;
        public bool answer;
        public Cargo theCargo;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            logicaM10 = new LogicaM10();
            theEmpleado = new Empleado();
            List<LugarDireccion> direccion = new List<LugarDireccion>();
            theCargo = new Cargo("Gerente", "Gerente de proyectos de software",
                                    DateTime.ParseExact("04/01/2016", "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                    "Tiempo compleato", Double.Parse("60"));

            direccion.Add(new LugarDireccion("Venezuela", "Pais"));
            direccion.Add(new LugarDireccion("Distrito Capital", "Estado"));
            direccion.Add(new LugarDireccion("Caracas", "Ciudad"));
            direccion.Add(new LugarDireccion("Plaza Sucre", "Direccion"));

            theEmpleado = new Empleado();

            //theEmpleado = new Empleado(0, "Antonio", "Juan", "Garcia",
            //                                   "Gobea", "Masculino",
            //                                   19627934,
            //                                   DateTime.ParseExact("05/02/1991", "MM/dd/yyyy", CultureInfo.InvariantCulture),
            //                                   "Activo", "Bachiller", "antonio11346@hotmail.com", theCargo,
            //                                   direccion);

      
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
        public void TestAddNewEmpleado()
        {
            //Declaro test de tipo BDEmpleado para poder invocar el "AddEmpleado(Empleado theEmpleado)"
            answer = logicaM10.AddNewEmpleado(theEmpleado);

            //answer obtiene true si se inserta el empleado
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar la consulta de los empleados a la base de datos
        /// </summary>
        [Test]
        public void TestGetEmpleados()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "GetEmpleados()"
            theEmpleados = logicaM10.GetEmpleados();

            //La prueba pasa el metodo retorna al menos 1 empleado
            Assert.IsTrue(theEmpleados.Count > 0);
        }

        /// <summary>
        /// Prueba que permite verificar la consulta de un empleado a la base de datos
        /// </summary>
        [Test]
        public void TestGetEmpleado()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "GetEmployee()"
            consultaEmpleado = logicaM10.GetEmployee(empleadoId);

            //La prueba pasa el metodo retorna a un empleado
            Assert.NotNull(consultaEmpleado);
        }

        /// <summary>
        /// Prueba que permite verificar la consulta de una lista de paises en la base de datos
        /// </summary>
        [Test]
        public void TestListaPaises()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "ItemsForListCountry()"
            theDireccion = logicaM10.ItemsForListCountry();

            //La prueba pasa el metodo retorna al menos 1 pais
            Assert.IsTrue(theDireccion.Count > 0);

        }

        /// <summary>
        /// Prueba que permite verificar la consulta de una lista de estados de una pais en la base de datos
        /// </summary>
        [Test]
        public void TestListaEstados()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "ItemsForListState(pais)"
            theDireccion = logicaM10.ItemsForListState(pais);

            //La prueba pasa el metodo retorna al menos 1 pais
            Assert.IsTrue(theDireccion.Count > 0);

        }

        /// <summary>
        /// Prueba que permite verificar la consulta de una lista de cargos en la base de datos
        /// </summary>
        [Test]
        public void TestListaCargos()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "ItemsForListJobs()"
            theCargos = logicaM10.ItemsForListJobs();

            //La prueba pasa el metodo retorna al menos 1 pais
            Assert.IsTrue(theCargos.Count > 0);

        }

        /// <summary>
        /// Prueba que permite verificar la consulta de una lista de empleados en la base de datos
        /// con cargo de 'Gerente'
        /// </summary>
        [Test]
        public void TestListaGerentes()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "GetGerentes()"
            theEmpleados = logicaM10.GetGerentes();
            answer = true;
            foreach (Empleado empleadoPrueba in theEmpleados)
            {
                if (empleadoPrueba.Job.Nombre != "Gerente")
                    answer = false;
            }

            //La prueba pasa el metodo retorna al menos 1 gerente
            Assert.IsTrue((theEmpleados.Count > 0)&&(answer));

        }

        /// <summary>
        /// Prueba que permite verificar la consulta de una lista de empleados en la base de datos
        /// con cargo de 'Programador'
        /// </summary>
        [Test]
        public void TestListaProgramadores()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "GetProgramadores()"
            theEmpleados = logicaM10.GetProgramadores();
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
        /// Prueba que permite verificar la modificacion del status de un empleado de activo a inactivo
        /// o de inactivo a activo, segun sea su estado actual
        /// </summary>
        [Test]
        public void TestCambiarEstatusEmpleado()
        {
            //Declaro test de tipo LogicaM10 para poder invocar el metodo "CambiarEstatus(empleadoId)"
            answer = logicaM10.CambiarEstatus(empleadoId);

            //La prueba pasa el metodo retorna al menos 1 pais
            Assert.IsTrue(answer);

            //Retorno al empleado a su estado anterior
            answer = logicaM10.CambiarEstatus(empleadoId);

        }
    }
}
