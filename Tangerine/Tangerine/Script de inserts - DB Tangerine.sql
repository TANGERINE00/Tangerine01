INSERT INTO LUGAR_DIRECCION VALUES (1,'Venezuela','Pais',null);

insert into lugar_direccion
values (2,'Caracas','Ciudad', 1);

insert into lugar_direccion
values (3,'Maracaibo','ciudad', 1);

insert into lugar_direccion
values (4,'Valencia','Ciudad', 1);

INSERT INTO CLIENTE_POTENCIAL VALUES (1,'jose','rifJose','emailJose',10,10,10,0,0);


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

INSERT INTO dbo.EMPLEADO(emp_num_ficha,emp_cedula, emp_genero, emp_p_nombre, emp_s_nombre, emp_p_apellido, emp_s_apellido, emp_fecha_nac, emp_nivel_estudio, emp_email, emp_activo, fk_lug_dir_id) 
VALUES (1,20183273,'Masculino','Armando','Pedro','Perez','Sanchez',convert(VARCHAR(10),'02-04-1990',110),'bajo','giantufano@gmail.com','bajo',2);

INSERT INTO dbo.EMPLEADO(emp_num_ficha,emp_cedula, emp_genero, emp_p_nombre, emp_s_nombre, emp_p_apellido, emp_s_apellido, emp_fecha_nac, emp_nivel_estudio, emp_email, emp_activo, fk_lug_dir_id) 
VALUES (2,10465723,'Masculino','Jose','Manuel','Armas','De la casa',convert(VARCHAR(10),'12-06-1994',110),'medio','giantufano@gmail.com','bajo',2);

INSERT INTO dbo.EMPLEADO(emp_num_ficha,emp_cedula, emp_genero, emp_p_nombre, emp_s_nombre, emp_p_apellido, emp_s_apellido, emp_fecha_nac, emp_nivel_estudio, emp_email, emp_activo, fk_lug_dir_id) 
VALUES (3,18529272,'Femenino','Karla','Andrea','Gonzales','Sanchez',convert(VARCHAR(10),'09-10-1992',110),'alto','giantufano@gmail.com','bajo',2);


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
insert into dbo.FACTURA(fac_id, fac_fecha_emision, fac_fecha_ultimo_pago, fac_monto_total, fac_monto_restante, fac_descripcion, fac_estatus, fk_proy_id, fk_compania_id) 
VALUES (1,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),100,100,'Proyecto de diseño',0,1,1);
SET IDENTITY_INSERT FACTURA OFF

SET IDENTITY_INSERT FACTURA ON
GO
insert into dbo.FACTURA(fac_id, fac_fecha_emision, fac_fecha_ultimo_pago, fac_monto_total, fac_monto_restante, fac_descripcion, fac_estatus, fk_proy_id, fk_compania_id) 
VALUES (2,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),100,100,'Proyecto de calidad',0,1,2);
SET IDENTITY_INSERT FACTURA OFF

SET IDENTITY_INSERT FACTURA ON
GO
insert into dbo.FACTURA(fac_id, fac_fecha_emision, fac_fecha_ultimo_pago, fac_monto_total, fac_monto_restante, fac_descripcion, fac_estatus, fk_proy_id, fk_compania_id) 
VALUES (3,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),100,100,'Analisis Inicial',2,1,3);
SET IDENTITY_INSERT FACTURA OFF

SET IDENTITY_INSERT FACTURA ON
GO
insert into dbo.FACTURA(fac_id, fac_fecha_emision, fac_fecha_ultimo_pago, fac_monto_total, fac_monto_restante, fac_descripcion, fac_estatus, fk_proy_id, fk_compania_id) 
VALUES (4,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),100,100,'Analisis Final',1,1,4);
SET IDENTITY_INSERT FACTURA OFF

