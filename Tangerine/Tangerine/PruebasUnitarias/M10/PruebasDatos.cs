using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
