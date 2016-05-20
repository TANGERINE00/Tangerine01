INSERT INTO LUGAR_DIRECCION VALUES (1,'Venezuela','Pais',null);

insert into lugar_direccion
values (2,'Caracas','Ciudad', 1);

insert into lugar_direccion
values (3,'Maracaibo','ciudad', 1);

insert into lugar_direccion
values (4,'Valencia','Ciudad', 1);

--------Clientes Potenciales------------------------------------------------------------------------------------------------

insert into cliente_potencial(cli_pot_nombre,cli_pot_rif,cli_pot_email,cli_pot_pres_anual_inv,cli_pot_num_llamadas,
cli_pot_num_visitas,cli_pot_potencial,cli_pot_borrado) values ('Skynet','J12345678','skynet@gmail.com',15120,0,0,1,0);

insert into cliente_potencial(cli_pot_nombre,cli_pot_rif,cli_pot_email,cli_pot_pres_anual_inv,cli_pot_num_llamadas,
cli_pot_num_visitas,cli_pot_potencial,cli_pot_borrado) values ('Cyberdyne','J2945677','cyberdynesystems@gmail.com',18120,2,3,1,0);

 insert into cliente_potencial(cli_pot_nombre,cli_pot_rif,cli_pot_email,cli_pot_pres_anual_inv,cli_pot_num_llamadas,
 cli_pot_num_visitas,cli_pot_potencial,cli_pot_borrado) values ('Umbrella Corp','J99123557','umbrellacorp@gmail.com',20450,1,2,1,0);

insert into cliente_potencial(cli_pot_nombre,cli_pot_rif,cli_pot_email,cli_pot_pres_anual_inv,cli_pot_num_llamadas,
cli_pot_num_visitas,cli_pot_potencial,cli_pot_borrado) values ('TerraSave','J25674897','terrasave@gmail.com',17020,3,3,1,0);

insert into cliente_potencial(cli_pot_nombre,cli_pot_rif,cli_pot_email,cli_pot_pres_anual_inv,cli_pot_num_llamadas,
cli_pot_num_visitas,cli_pot_potencial,cli_pot_borrado) values ('LexCorp','J34554334','lexCorp@gmail.com',12020,1,2,1,0);

insert into cliente_potencial(cli_pot_nombre,cli_pot_rif,cli_pot_email,cli_pot_pres_anual_inv,cli_pot_num_llamadas,
cli_pot_num_visitas,cli_pot_potencial,cli_pot_borrado) values ('Weyland_yutani_corp','J34114334','weyland@gmail.com',12020,1,2,1,0);

insert into cliente_potencial(cli_pot_nombre,cli_pot_rif,cli_pot_email,cli_pot_pres_anual_inv,cli_pot_num_llamadas,
cli_pot_num_visitas,cli_pot_potencial,cli_pot_borrado) values ('WilPharma','J45675811','wpcorp@gmail.com',18020,1,2,0,0);

------------------------------------------------------------------------------------------------------------------
insert into Compania (com_nombre, com_rif, com_email, com_telefono, com_acronimo, com_fecha_registro, com_status, fk_lug_dir_id)
values ('pepsi', 'j-3452346', 'giantufano@gmail.com', '04122362151', 'psi', '12/12/2016', 1, 1);

insert into Compania (com_nombre, com_rif, com_email, com_telefono, com_acronimo, com_fecha_registro, com_status, fk_lug_dir_id)
values ('coca', 'j-3452346', 'giantufano@gmail.com', '04122362151', 'cca', '12/12/2016', 0, 1);

insert into Compania (com_nombre, com_rif, com_email, com_telefono, com_acronimo, com_fecha_registro, com_status, fk_lug_dir_id)
values ('maguca', 'j-3452346', 'giantufano@gmail.com', '04122362151', 'mgc', '12/12/2016', 1, 1);

insert into Compania (com_nombre, com_rif, com_email, com_telefono, com_acronimo, com_fecha_registro, com_status, fk_lug_dir_id)
values ('tangerine', 'j-3452346', 'giantufano@gmail.com', '04122362151', 'tgn', '12/12/2016', 0, 1);


SET IDENTITY_INSERT PROPUESTA ON
insert into dbo.PROPUESTA(prop_id,prop_nombre, prop_descripcion, prop_tipoDuracion, prop_Duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio, prop_fecha_fin, prop_costo, fk_com_id)
VALUES (1,'Modulo de gestion de empleados','Se tratara de un modulo de gestion de empleados','Alta','Mensual','Mensual','Aprobado','Bolivar',5,convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,1);
SET IDENTITY_INSERT PROPUESTA OFF

SET IDENTITY_INSERT PROPUESTA ON
insert into dbo.PROPUESTA(prop_id,prop_nombre, prop_descripcion, prop_tipoDuracion, prop_Duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio, prop_fecha_fin, prop_costo, fk_com_id)
VALUES (2,'Modulo de gestion de empresas','Se tratara de un modulo de gestion de empresas','Alta','Mensual','Mensual','Aprobado','Bolivar',5,convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,1);
SET IDENTITY_INSERT PROPUESTA OFF

SET IDENTITY_INSERT PROPUESTA ON
insert into dbo.PROPUESTA(prop_id,prop_nombre, prop_descripcion, prop_tipoDuracion, prop_Duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio, prop_fecha_fin, prop_costo, fk_com_id)
VALUES (3,'Modulo de gestion de contactos','Se tratara de un modulo de gestion de contactos','Alta','Mensual','Mensual','Aprobado','Bolivar',5,convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,1);
SET IDENTITY_INSERT PROPUESTA OFF

SET IDENTITY_INSERT PROPUESTA ON
insert into dbo.PROPUESTA(prop_id,prop_nombre, prop_descripcion, prop_tipoDuracion, prop_Duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio, prop_fecha_fin, prop_costo, fk_com_id)
VALUES (4,'Modulo de gestion de listas','Se tratara de un modulo de gestion de listas','Alta','Mensual','Mensual','Aprobado','Bolivar',5,convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,1);
SET IDENTITY_INSERT PROPUESTA OFF

SET IDENTITY_INSERT PROPUESTA ON
insert into dbo.PROPUESTA(prop_id,prop_nombre, prop_descripcion, prop_tipoDuracion, prop_Duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio, prop_fecha_fin, prop_costo, fk_com_id)
VALUES (5,'Modulo de gestion de Roles','Se tratara de un modulo de gestion de Roles','Alta','Mensual','Por entregas','Aprobado','Bolivar',5,convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,1);
SET IDENTITY_INSERT PROPUESTA OFF

SET IDENTITY_INSERT PROPUESTA ON
insert into dbo.PROPUESTA(prop_id,prop_nombre, prop_descripcion, prop_tipoDuracion, prop_Duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio, prop_fecha_fin, prop_costo, fk_com_id)
VALUES (6,'Modulo de gestion de Usuarios','Se tratara de un modulo de gestion de Ususarios','Alta','Mensual','Mensual','Aprobado','Bolivar',5,convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,1);
SET IDENTITY_INSERT PROPUESTA OFF

SET IDENTITY_INSERT PROPUESTA ON
insert into dbo.PROPUESTA(prop_id,prop_nombre, prop_descripcion, prop_tipoDuracion, prop_Duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio, prop_fecha_fin, prop_costo, fk_com_id)
VALUES (7,'Modulo de prueba','Se tratara de un modulo de gestion de pruebas','Alta','Mensual','Mensual','Aprobado','Bolivar',5,convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,1);
SET IDENTITY_INSERT PROPUESTA OFF



INSERT INTO dbo.EMPLEADO(emp_num_ficha,emp_cedula, emp_genero, emp_p_nombre, emp_s_nombre, emp_p_apellido, emp_s_apellido, emp_fecha_nac, emp_nivel_estudio, emp_email, emp_activo, fk_lug_dir_id) 
VALUES (1,20183273,'Masculino','Armando','Pedro','Perez','Sanchez',convert(VARCHAR(10),'02-04-1990',110),'bajo','giantufano@gmail.com','bajo',2);

INSERT INTO dbo.EMPLEADO(emp_num_ficha,emp_cedula, emp_genero, emp_p_nombre, emp_s_nombre, emp_p_apellido, emp_s_apellido, emp_fecha_nac, emp_nivel_estudio, emp_email, emp_activo, fk_lug_dir_id) 
VALUES (2,10465723,'Masculino','Jose','Manuel','Armas','De la casa',convert(VARCHAR(10),'12-06-1994',110),'medio','giantufano@gmail.com','bajo',2);

INSERT INTO dbo.EMPLEADO(emp_num_ficha,emp_cedula, emp_genero, emp_p_nombre, emp_s_nombre, emp_p_apellido, emp_s_apellido, emp_fecha_nac, emp_nivel_estudio, emp_email, emp_activo, fk_lug_dir_id) 
VALUES (3,18529272,'Femenino','Karla','Andrea','Gonzales','Sanchez',convert(VARCHAR(10),'09-10-1992',110),'alto','giantufano@gmail.com','bajo',2);

INSERT INTO dbo.CONTACTO(con_nombre,con_apellido,con_departamento,con_cargo,con_telefono,con_correo,con_tipo_emp,fk_id_com_lead)
VALUES('Oscar','Armas','Finanzas','Gerente','04162345678','giantufano@gmail.com',1,1);

INSERT INTO dbo.CONTACTO(con_nombre,con_apellido,con_departamento,con_cargo,con_telefono,con_correo,con_tipo_emp,fk_id_com_lead)
VALUES('Jose','Perez','Finanzas','Gerente','04162345678','giantufano@gmail.com',1,1);

INSERT INTO dbo.CONTACTO(con_nombre,con_apellido,con_departamento,con_cargo,con_telefono,con_correo,con_tipo_emp,fk_id_com_lead)
VALUES('Maria','Del Carmen','Finanzas','Gerente','04162345678','giantufano@gmail.com',1,1);

SET IDENTITY_INSERT PROYECTO ON
GO
insert into dbo.PROYECTO(proy_id, proy_nombre, proy_codigo, proy_fecha_inicio, proy_fecha_est_fin, proy_costo, proy_descripcion, proy_realizacion, proy_estatus, proy_razon, proy_acuerdo_pago, fk_propuesta_id, fk_com_id, fk_gerente_id) 
VALUES (1,'ProyectoDS','CodigoPDS',convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,'Se tratara de un modulo de gestion de empleados','60','En desarrollo','','Mensual',1,1,1);
SET IDENTITY_INSERT PROYECTO OFF

SET IDENTITY_INSERT PROYECTO ON
GO
insert into dbo.PROYECTO(proy_id, proy_nombre, proy_codigo, proy_fecha_inicio, proy_fecha_est_fin, proy_costo, proy_descripcion, proy_realizacion, proy_estatus, proy_razon, proy_acuerdo_pago, fk_propuesta_id, fk_com_id, fk_gerente_id) 
VALUES (2,'ProyectoEMP','CodigoEMP',convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,'Se tratara de un modulo de gestion de empresas','60','Cancelado','','Mensual',2,1,1);
SET IDENTITY_INSERT PROYECTO OFF

SET IDENTITY_INSERT PROYECTO ON
GO
insert into dbo.PROYECTO(proy_id, proy_nombre, proy_codigo, proy_fecha_inicio, proy_fecha_est_fin, proy_costo, proy_descripcion, proy_realizacion, proy_estatus, proy_razon, proy_acuerdo_pago, fk_propuesta_id, fk_com_id, fk_gerente_id) 
VALUES (3,'ProyectoCON','CodigoCON',convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,'Se tratara de un modulo de gestion de contactos','60','Completado','','Mensual',3,1,1);
SET IDENTITY_INSERT PROYECTO OFF

SET IDENTITY_INSERT PROYECTO ON
GO
insert into dbo.PROYECTO(proy_id, proy_nombre, proy_codigo, proy_fecha_inicio, proy_fecha_est_fin, proy_costo, proy_descripcion, proy_realizacion, proy_estatus, proy_razon, proy_acuerdo_pago, fk_propuesta_id, fk_com_id, fk_gerente_id) 
VALUES (4,'ProyectoLIS','CodigoLIS',convert(VARCHAR(10),'10-03-2016',110),convert(VARCHAR(10),'10-08-2016',110),10000,'Se tratara de un modulo de gestion de listas','60','A destiempo','','Por Entregas',4,1,1);
SET IDENTITY_INSERT PROYECTO OFF


INSERT INTO dbo.EMPLEADO_PROYECTO(fk_emp_num_ficha,fk_proy_id)
VALUES(2,1);
INSERT INTO dbo.EMPLEADO_PROYECTO(fk_emp_num_ficha,fk_proy_id)
VALUES(3,1);

INSERT INTO dbo.EMPLEADO_PROYECTO(fk_emp_num_ficha,fk_proy_id)
VALUES(2,2);
INSERT INTO dbo.EMPLEADO_PROYECTO(fk_emp_num_ficha,fk_proy_id)
VALUES(3,2);

INSERT INTO dbo.EMPLEADO_PROYECTO(fk_emp_num_ficha,fk_proy_id)
VALUES(2,3);
INSERT INTO dbo.EMPLEADO_PROYECTO(fk_emp_num_ficha,fk_proy_id)
VALUES(3,3);

INSERT INTO dbo.EMPLEADO_PROYECTO(fk_emp_num_ficha,fk_proy_id)
VALUES(2,4);
INSERT INTO dbo.EMPLEADO_PROYECTO(fk_emp_num_ficha,fk_proy_id)
VALUES(3,4);

SET IDENTITY_INSERT FACTURA ON
GO
insert into dbo.FACTURA(fac_id, fac_fecha_emision, fac_fecha_ultimo_pago, fac_monto_total, fac_monto_restante, fac_tipo_moneda, fac_descripcion, fac_estatus, fk_proy_id, fk_compania_id) 
VALUES (1,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),100,100,'Dolares','Proyecto de diseño',0,1,1);
SET IDENTITY_INSERT FACTURA OFF

SET IDENTITY_INSERT FACTURA ON
GO
insert into dbo.FACTURA(fac_id, fac_fecha_emision, fac_fecha_ultimo_pago, fac_monto_total, fac_monto_restante, fac_tipo_moneda, fac_descripcion, fac_estatus, fk_proy_id, fk_compania_id) 
VALUES (2,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),100,100,'Bolivares','Proyecto de calidad',0,1,2);
SET IDENTITY_INSERT FACTURA OFF

SET IDENTITY_INSERT FACTURA ON
GO
insert into dbo.FACTURA(fac_id, fac_fecha_emision, fac_fecha_ultimo_pago, fac_monto_total, fac_monto_restante, fac_tipo_moneda, fac_descripcion, fac_estatus, fk_proy_id, fk_compania_id) 
VALUES (3,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),100,100,'Euros','Analisis Inicial',2,1,3);
SET IDENTITY_INSERT FACTURA OFF

SET IDENTITY_INSERT FACTURA ON
GO
insert into dbo.FACTURA(fac_id, fac_fecha_emision, fac_fecha_ultimo_pago, fac_monto_total, fac_monto_restante, fac_tipo_moneda, fac_descripcion, fac_estatus, fk_proy_id, fk_compania_id) 
VALUES (4,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),100,100,'Dolares','Analisis Final',1,1,4);
SET IDENTITY_INSERT FACTURA OFF

-----Inserts de Usuarios y Roles-------
insert into ROL values (1, 'Administrador');
insert into ROL values (2, 'Gerente');
insert into ROL values (3, 'Director');
insert into	ROL values (4, 'Programador');

insert into MENU values (1, 'Configuracion');
insert into OPCION values (1, 'RegistrarUsuario', '../M2/RegistroUsuario.aspx', 1);
insert into OPCION values (2, 'ModificarRol', '../M2/CambiarRol.aspx', 1);
insert into OPCION values (21, 'Usuario', 'Usuario', 1);

insert into MENU values (2, 'Gestión de Leads');
insert into OPCION values (3, 'Listar', '../M3/Listar.aspx', 2);

insert into MENU values (3, 'Gestión de Compañías');
insert into OPCION values (4, 'RegistrarCompañía', '../M4/AgregarCompania.aspx', 3);
insert into OPCION values (5, 'ConsultarCompañía', '../M4/ConsultarCompania.aspx', 3);
insert into OPCION values (6, 'ModificarCompañía', '../M4/ModificarCompania.aspx', 3);
insert into OPCION values (7, 'Habilitar/Deshabilitar', '../M4/HabilitarCompania.aspx', 3);
insert into OPCION values (22, 'GestionDeCompañias', 'Gestión de Compañías', 3);

insert into MENU values (4, 'Gestión de Contactos');
insert into OPCION values (8, 'Contactos', '../M5/ConsultarContactos.aspx', 4)

insert into MENU values (5, 'Gestión de Propuestas');
insert into OPCION values (9, 'AgregarPropuesta', '../M6/AgregarPropuesta.aspx', 5);
insert into OPCION values (10, 'ConsultarPropuestas', '../M6/ListarPropuesta.aspx', 5);
insert into OPCION values (23, 'GestionDePropuestas', 'Gestión de Propuestas', 5);

insert into MENU values (6, 'Gestión de Proyectos');
insert into OPCION values (11, 'CrearProyecto', '../M7/Agregar proyecto.aspx', 6);
insert into OPCION values (12, 'ModificarProyecto', '../M7/modificarProyecto.aspx', 6);
insert into OPCION values (13, 'ConsultarProyecto', '../M7/ConsultaProyecto.aspx', 6);
insert into OPCION values (24, 'GestionDeProyectos', 'Gestión de Proyectos', 6);

insert into MENU values (7, 'Gestión de Facturas');
insert into OPCION values (14, 'GenerarFactura', '../M8/GenerarFacturaM8.aspx', 7);
insert into OPCION values (15, 'ConsultarFactura', '../M8/ConsultarFacturaM8.aspx', 7);
insert into OPCION values (16, 'ModificarFactura', '../M8/ModificarFacturaM8.aspx', 7);
insert into OPCION values (17, 'AnularFactura', '../M8/AnularFacturaM8.aspx', 7);
insert into OPCION values (25, 'GestionDeFacturas', 'Gestión de Facturas', 7);

insert into MENU values (8, 'Gestión de Pagos');
insert into OPCION values (18, 'Cargarpago', '../M9/SeleccionCompania.aspx', 8);

insert into MENU values (9, 'Gestión de Empleados');
insert into OPCION values (19, 'Empleados', '../M1/EmpleadosAdmin.aspx', 9);
insert into OPCION values (20, 'Cargos', '../M10/AdminCargo.aspx', 9);
insert into OPCION values (26, 'GestionDeEmpleados', 'Gestión de Empleados', 9);

insert into ROL_OPCION values (2, 14);
insert into ROL_OPCION values (2, 15);
insert into ROL_OPCION values (2, 16);
insert into ROL_OPCION values (2, 17);
insert into ROL_OPCION values (2, 25);
insert into ROL_OPCION values (2, 18);

insert into ROL_OPCION values (3, 1);
insert into ROL_OPCION values (3, 2);
insert into ROL_OPCION values (3, 21);

insert into ROL_OPCION values (4, 1);
insert into ROL_OPCION values (4, 2);
insert into ROL_OPCION values (4, 21);
insert into ROL_OPCION values (4, 3);
insert into ROL_OPCION values (4, 4);
insert into ROL_OPCION values (4, 5);
--insert into ROL_OPCION values (4, 6);
--insert into ROL_OPCION values (4, 7);
insert into ROL_OPCION values (4, 22);
insert into ROL_OPCION values (4, 8);
insert into ROL_OPCION values (4, 9);
insert into ROL_OPCION values (4, 10);
insert into ROL_OPCION values (4, 23);
insert into ROL_OPCION values (4, 11);
insert into ROL_OPCION values (4, 14);
insert into ROL_OPCION values (4, 15);
insert into ROL_OPCION values (4, 16);
insert into ROL_OPCION values (4, 17);
insert into ROL_OPCION values (4, 25);
insert into ROL_OPCION values (4, 18);
insert into ROL_OPCION values (4, 19);
insert into ROL_OPCION values (4, 20);
insert into ROL_OPCION values (4, 26);

insert into USUARIO values (1, 'luarropa', '81dc9bdb52d04dc20036dbd8313ed055', CONVERT(DATE, '07/05/2016'), 'Activo', 2, null);
insert into USUARIO values (2, 'geastone', '81dc9bdb52d04dc20036dbd8313ed055', CONVERT(DATE, '07/05/2016'), 'Activo', 2, null);
insert into USUARIO values (3, 'calozano', '81dc9bdb52d04dc20036dbd8313ed055', CONVERT(DATE, '07/05/2016'), 'Activo', 2, null);
---------Fin de Inserts de Usuarios y Roles-----------


--------------------------INSERTS REQUERIMIENTOS---------------------------
INSERT INTO [BDTangerine].[dbo].[REQUERIMIENTO]
           ([req_codigo]
           ,[req_descripcion]
           ,[fk_prop_req_id]
           ,[fk_prop_id])
     VALUES
           ('prueba1',
           'descripcion1',
           'Modulo de prueba',
           7);

INSERT INTO [BDTangerine].[dbo].[REQUERIMIENTO]
           ([req_codigo]
           ,[req_descripcion]
           ,[fk_prop_req_id]
           ,[fk_prop_id])
     VALUES
           ('prueba2',
           'descripcion2',
           'Modulo de prueba',
           7);
INSERT INTO [BDTangerine].[dbo].[REQUERIMIENTO]
           ([req_codigo]
           ,[req_descripcion]
           ,[fk_prop_req_id]
           ,[fk_prop_id])
     VALUES
           ('prueba3',
           'descripcion3',
           'Modulo de prueba',
           7);
--------------------------FIN DE INSERTS DE REQUERIMIENTOS---------------------------