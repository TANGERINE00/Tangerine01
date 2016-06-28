using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M3;
using DatosTangerine.InterfazDAO.M3;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M3;

namespace PruebasUnitarias.M3
{
    [TestFixture]
    public class PruebasDAOClientePotencial
    {
        #region Atributos

        private ClientePotencial elCliente1, elCliente2, elCliente3,elCliente4;
        private Boolean respuesta;
        private List<Entidad> losClientes;
        private DatosTangerine.InterfazDAO.M3.IDAOClientePotencial daoCliente;
        private List<Entidad> llamadas, visitas;
        private SeguimientoCliente elSeguimiento;
             
        #endregion

        #region SetUp y TearDown
        /// <summary>
        /// SetUp para las pruebas de DAOClientePotencial
        /// </summary>
        [SetUp]
        public void Init()
        {
            elCliente1 = new ClientePotencial("Test2", "J-121212-F","prueba@gmail.com",121212,1);
            elCliente2 = new ClientePotencial();
            elCliente3 = new ClientePotencial("Test2Cambio", "J-121212-F", "cambio@gmail.com", 746, 1);
            elCliente4 = new ClientePotencial("Test3", "J-121212-F", "prueba@gmail.com", 121212, 0);
            losClientes = new List<Entidad>();
            elSeguimiento = new SeguimientoCliente(new DateTime(2016,05,02),"Llamada","Prueba de seguimiento",5);

        }

        /// <summary>
        /// TearDown para las pruebas de DAOClientePotencial
        /// </summary>
        [TearDown]
        public void Clean()
        {
            elCliente1 = null;
            elCliente2 = null;
            elCliente3 = null;
            elCliente4 = null;
        }
        #endregion

        /// <summary>
        /// Método para probar el ConsultarXId de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestConsultarXIdClientePotencial()
        {
            daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
            
            respuesta = daoCliente.Agregar(elCliente1);
            elCliente1.Id = daoCliente.ConsultarIdUltimoClientePotencial();
            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)daoCliente.ConsultarXId(elCliente1);

            Assert.AreEqual(elCliente2.NombreClientePotencial,elCliente1.NombreClientePotencial);
            Assert.AreEqual(elCliente2.RifClientePotencial, elCliente1.RifClientePotencial);
            Assert.AreEqual(elCliente2.EmailClientePotencial, elCliente1.EmailClientePotencial);
            Assert.AreEqual(elCliente2.PresupuestoAnual_inversion, elCliente1.PresupuestoAnual_inversion);
            Assert.AreEqual(elCliente2.Status, elCliente1.Status);

            daoCliente.Eliminar(elCliente1);

        }

        /// <summary>
        /// Método para probar el Agregar de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestAgregarClientePotencial()
        {
            daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();

            Assert.IsTrue(daoCliente.Agregar(elCliente1));
            elCliente1.Id = daoCliente.ConsultarIdUltimoClientePotencial();
            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)daoCliente.ConsultarXId(elCliente1);

            Assert.AreEqual(elCliente2.NombreClientePotencial, elCliente1.NombreClientePotencial);
            Assert.AreEqual(elCliente2.RifClientePotencial, elCliente1.RifClientePotencial);
            Assert.AreEqual(elCliente2.EmailClientePotencial, elCliente1.EmailClientePotencial);
            Assert.AreEqual(elCliente2.PresupuestoAnual_inversion, elCliente1.PresupuestoAnual_inversion);
            Assert.AreEqual(elCliente2.Status, elCliente1.Status);

            daoCliente.Eliminar(elCliente1);

        }

        /// <summary>
        /// Método para probar el Activar de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestActivarClientePotencial()
        {
            daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();

            respuesta = daoCliente.Agregar(elCliente4);
            elCliente4.Id = daoCliente.ConsultarIdUltimoClientePotencial();
            Assert.IsTrue(daoCliente.Activar(elCliente4));

            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)daoCliente.ConsultarXId(elCliente4);
            Assert.AreEqual(1, elCliente2.Status);

            daoCliente.Eliminar(elCliente4);

        }

        /// <summary>
        /// Método para probar el Desactivar de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestDesactivarClientePotencial()
        {
            daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();

            respuesta = daoCliente.Agregar(elCliente1);
            elCliente1.Id = daoCliente.ConsultarIdUltimoClientePotencial();
            Assert.IsTrue(daoCliente.Desactivar(elCliente1));

            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)daoCliente.ConsultarXId(elCliente1);
            Assert.AreEqual(0, elCliente2.Status);

            daoCliente.Eliminar(elCliente1);

        }

        /// <summary>
        /// Método para probar el Modificar de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestModificarClientePotencial()
        {
            daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();

            respuesta = daoCliente.Agregar(elCliente1);
            elCliente1.Id = daoCliente.ConsultarIdUltimoClientePotencial();

            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)daoCliente.ConsultarXId(elCliente1);
            elCliente2.Id = daoCliente.ConsultarIdUltimoClientePotencial();

            Assert.IsTrue(daoCliente.Modificar(elCliente2));
            
            daoCliente.Eliminar(elCliente1);

        }

        /// <summary>
        /// Método para probar el Modificar de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestListarClientePotencial()
        {
            daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();

            losClientes = daoCliente.ConsultarTodos();

            Assert.IsTrue(losClientes.Count()>0);

            daoCliente.Eliminar(elCliente1);

        }

        /// <summary>
        /// Método para probar el Promover de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestPromoverClientePotencial()
        {
            daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();

            respuesta = daoCliente.Agregar(elCliente1);
            elCliente1.Id = daoCliente.ConsultarIdUltimoClientePotencial();
            Assert.IsTrue(daoCliente.Promover(elCliente1));

            elCliente2 = (DominioTangerine.Entidades.M3.ClientePotencial)daoCliente.ConsultarXId(elCliente1);
            Assert.AreEqual(2, elCliente2.Status);

            daoCliente.Eliminar(elCliente1);

        }

        /// <summary>
        /// Método para probar el Listar llamadas de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestDaoListarLlamadasClientePotencial()
        {
            daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
            elCliente1.Id = 1;
            llamadas = daoCliente.ConsultarLlamadasXId(elCliente1);

            Assert.NotNull(llamadas);

            foreach (Entidad seguimiento in llamadas)
            {
                Assert.NotNull(((SeguimientoCliente)seguimiento).Id);
                Assert.AreEqual("Llamada", ((SeguimientoCliente)seguimiento).TipoHistoria);
            }

        }

        /// <summary>
        /// Método para probar el Listar visitas de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestDaoListarVisitasClientePotencial()
        {
            daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
            elCliente1.Id = 1;
            visitas = daoCliente.ConsultarVistaXId(elCliente1);

            Assert.NotNull(visitas);

            foreach (Entidad seguimiento in visitas)
            {
                Assert.NotNull(((SeguimientoCliente)seguimiento).Id);
                Assert.AreEqual("Visita", ((SeguimientoCliente)seguimiento).TipoHistoria);
            }

        }

        /// <summary>
        /// Método para probar el agregar seguimiento de DAOClientePotencial
        /// </summary>
        [Test]
        public void TestDaoAgregarSeguimientoClientePotencial()
        {
            bool condicion = false;
            daoCliente = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
            elCliente1.Id = 5;

            daoCliente.AgregarSeguimientoDeCliente(elSeguimiento);
            llamadas = daoCliente.ConsultarLlamadasXId(elCliente1);

            Assert.NotNull(llamadas);

            foreach (Entidad seguimiento in llamadas)
            {
                Assert.NotNull(((SeguimientoCliente)seguimiento).Id);
                Assert.AreEqual("Llamada", ((SeguimientoCliente)seguimiento).TipoHistoria);
                if (((SeguimientoCliente)seguimiento).TipoHistoria == elSeguimiento.TipoHistoria &&
                    ((SeguimientoCliente)seguimiento).MotivoHistoria == elSeguimiento.MotivoHistoria &&
                    ((SeguimientoCliente)seguimiento).FkCliente == elSeguimiento.FkCliente)
                {
                    condicion = true;
                }
            }
            Assert.IsTrue(condicion);

        }
    }
}
