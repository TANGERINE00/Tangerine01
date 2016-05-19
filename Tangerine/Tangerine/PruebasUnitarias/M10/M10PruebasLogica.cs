using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public bool answer;
        public List<Empleado> theEmpleados;
        public LogicaM10 logicaM10;
        public int empleadoId;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theEmpleado = new Empleado();
            theEmpleado.Emp_num_ficha = 1;
            theEmpleado.emp_p_nombre = "Antonio";
            theEmpleado.emp_s_nombre = "Juan";
            theEmpleado.emp_p_apellido = "García";
            theEmpleado.emp_s_apellido = "Gobea";
            theEmpleado.emp_activo = "Activo";
            theEmpleado.emp_cedula = 19627934;
            theEmpleado.emp_email = "antonio@gmail.com";
            theEmpleado.emp_fecha_nac = new DateTime(1991, 5, 04);
            theEmpleado.emp_genero = "Masculino";
            theEmpleado.emp_nivel_estudio = "Bachiller";
            theEmpleado.fk_lug_dir_id = 1;
            empleadoId = 1;
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
    }
}
