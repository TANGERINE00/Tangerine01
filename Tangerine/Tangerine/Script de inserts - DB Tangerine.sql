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
VALUES (1,'HOla','Dificil','Alta','Mensual','Dia','lucas','Fua',2,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),10,1);
SET IDENTITY_INSERT PROPUESTA OFF

INSERT INTO dbo.EMPLEADO(emp_num_ficha,emp_cedula, emp_genero, emp_p_nombre, emp_s_nombre, emp_p_apellido, emp_s_apellido, emp_fecha_nac, emp_nivel_estudio, emp_email, emp_activo, fk_lug_dir_id) 
VALUES (1,1,'hola','holas','chao','chaos','gua',convert(VARCHAR(10),'11-10-2015',110),'bajo','bajo','bajo',1);

SET IDENTITY_INSERT PROYECTO ON
GO
insert into dbo.PROYECTO(proy_id, proy_nombre, proy_codigo, proy_fecha_inicio, proy_fecha_est_fin, proy_costo, proy_descripcion, proy_realizacion, proy_estatus, proy_razon, proy_acuerdo_pago, fk_propuesta_id, fk_com_id, fk_gerente_id) 
VALUES (1,'ProyectoDS','CodigoPDS',convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),10,'Dificil','Buena','Actual','Hola','Chao',1,1,1);
SET IDENTITY_INSERT PROYECTO OFF


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

