drop table pago;
drop table factura;
drop table contacto_proyecto;
drop table empleado_proyecto;
drop table requerimiento;
drop table contacto;
drop table telefono;
drop table seguimiento;
drop table cliente_potencial;
drop table usuario;
drop table cargo_empleado;
drop table cargo;
drop table HISTORICO_GERENTES;
drop table rol_opcion;
drop table rol;
drop table opcion;
drop table menu;
drop table proyecto;
drop table propuesta;
drop table compania;
drop table empleado;
drop table lugar_direccion;

drop procedure M2_ObtenerOpciones;
drop procedure M2_ObtenerRolUsuario;
drop procedure M2_ObtenerDatoUsuario;
drop procedure M2_ModificarContraUsuario;
drop procedure M2_ModificarRolUsuario;
drop procedure M2_AgregarUsuario;
drop procedure M2_ObtenerUsuarioDeEmpleado;
drop procedure M2_ObtenerRolUsuarioPorNombre;
drop procedure M2_VerificarUsuarioPorFichaEmpleado;
drop procedure M2_VerificarExistenciaUsuario;
drop procedure M2_ConsultarIdUltimoUsuario;
drop procedure M2_ConsultarUsuario;
drop procedure M2_BorrarUsuario;
drop procedure M2_ConsultarUsuarioPorNombre;
drop procedure M2_ModificarUsuario;
drop procedure M2_ConsultarIdUltimoEmpleado;

drop procedure M3_agregar_clientePotencial;
drop procedure M3_listar_cliente_potencial;
drop procedure M3_eliminar_cliente_potencial;
drop procedure M3_promover_cliente_potencial;
drop procedure M3_consultar_cliente_potencial;
drop procedure M3_modificar_clientePotencialF;
drop procedure M3_activar_cliente_potencial;
drop procedure M3_eliminar_cliente_potencial_def;
drop procedure M3_ConsultarIdUltimoLead;
drop procedure M3_listar_Seguimento_llamadas;
drop procedure M3_Agrgar_Seguimento;

drop procedure M4_AgregarCompania;
drop procedure M4_ConsultarCompania;
drop procedure M4_ConsultarCompanias;
drop procedure M4_ConsultarCompaniasActivas;
drop procedure M4_ModificarCompania;
drop procedure M4_InhabilitarHabilitarCompania;
drop procedure M4_EliminarCompania;
drop procedure M4_ConsultarIdUltimaCompania;
drop procedure M4_ConsultarLugar;
drop procedure M4_ConsultarLugarPorId;


drop procedure M5_AgregarContacto;
drop procedure M5_ConsultarContactoId;
drop procedure M5_AgregarContactoProyecto;
drop procedure M5_EliminarContactoProyecto;
drop procedure M5_EliminarContacto;
drop procedure M5_ModificarContacto;
drop procedure M5_ConsultarContactoCompania;
drop procedure M5_ConsultarContactoProyecto;
drop procedure M5_ConsultarContactoNoProyecto;
drop procedure M5_ConsultarTodosContactos;

drop procedure M6_AgregarPropuesta;
drop procedure M6_ListaPropuestaProyecto;
drop procedure M6_ModificarPropuesta;
drop procedure M6_ModificarRequerimiento;
drop procedure M6_ListarRequerimientos;
drop procedure M6_AgregarRequerimiento;
drop procedure M6_ConsultarPropuestaNombre;
drop procedure M6_ConsultarPropuestas;
drop procedure M6_EliminarPropuesta;
drop procedure M6_ConsultarNumeroPropuestas;
drop procedure M6_ConsultarNumeroRequerimientos;
drop procedure M6_EliminarRequerimiento;
drop procedure M6_ConsultarRequerimientoNombre;

drop procedure M7_AgregarProyecto;
drop procedure M7_ConsultarProyecto;
drop procedure M7_ConsultarProyectos;
drop procedure M7_ModificarProyecto;
drop procedure M7_AgregarProyectoContacto;
drop procedure M7_ConsultarProyectoContacto;
drop procedure M7_EliminarProyectoContacto;
drop procedure M7_AgregarProyectoEmpleado;
drop procedure M7_ConsultarProyectoEmpleado;
drop procedure M7_EliminarProyectoEmpleado;
drop procedure M7_ConsultarAcuerdoPagoMensual;
drop procedure M7_ConsultarProyectoTrabajaEmpleado;
drop procedure M7_COnsultarProyectosPorGerente;
drop procedure M7_ConsultarNombrePropuestaID;
drop procedure M7_ConsultarMaxIdProyecto;
drop procedure M7_ConsultarNumeroProyectos;
drop procedure M7_BorrarProyecto;
drop procedure M7_HistoricoGerentes;
drop procedure M7_ConsultarHistoricoGerente;

drop procedure M8_AgregarFactura;
drop procedure M8_ConsultarFactura;
drop procedure M8_ConsultarFacturas;
drop procedure M8_ModificarFactura;
drop procedure M8_ConsultarNombreCompaniaFacturas;
drop procedure M8_AnularFactura;
drop procedure M8_ConsultarFacturasCompania;
drop procedure M8_VerificarFacturasParaPagar;
drop procedure M8_ConsultarMontoRestanteFactura;
drop procedure M8_VerificarFacturaExistente;
drop procedure M8_ConsultarFacturasPagadasCompania;
drop procedure M8_EliminarFactura;

drop procedure M9_AgregarPago;
drop procedure M9_CambioStatus;
drop Procedure M9_ConsultarPagos;
drop procedure M9_HistoricoPagoCompania;
drop procedure M9_EliminarPago;

drop procedure M10_AgregarEmpleado;
drop procedure M10_ConsultarEmpleado;
drop procedure M10_DetallarEmpleado;
drop procedure M10_ConsultarGerentes;
drop procedure M10_ConsultarProgramadores;
drop procedure M10_LLenarSelectPaises;
drop procedure M10_LLenarSelectEstados;
drop procedure M10_LlenarSelectCargo;
drop procedure M10_CambiarEstatus;
drop procedure M1_ObtenerCorreoUsuario;






