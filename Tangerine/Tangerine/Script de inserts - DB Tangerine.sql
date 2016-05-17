INSERT INTO LUGAR_DIRECCION VALUES (1,'Venezuela','Pais',null);

INSERT INTO CLIENTE_POTENCIAL VALUES (1,'jose','rifJose','emailJose',10,10,10,0,0);

SET IDENTITY_INSERT COMPANIA ON
GO
insert into dbo.COMPANIA(com_id,com_nombre, com_rif, com_email, com_telefono, com_acronimo, com_fecha_registro, com_status, fk_lug_dir_id)
VALUES (1,'Trascend','rifTrascend','emailTrascend','123','TR',convert(VARCHAR(10),'11-10-2015',110),0,1);
SET IDENTITY_INSERT COMPANIA OFF

SET IDENTITY_INSERT PROPUESTA ON
insert into dbo.PROPUESTA(prop_id,prop_nombre, prop_descripcion, prop_tipoDuracion, prop_Duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio, prop_fecha_fin, prop_costo, fk_com_id)
VALUES (1,'HOla','DIficil','Alta','Mensual','Dia','lucas','Fua',2,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),10,1);
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
VALUES (1,convert(VARCHAR(10),'11-10-2015',110),convert(VARCHAR(10),'11-10-2015',110),100,100,'Hola',0,1,1);
SET IDENTITY_INSERT FACTURA OFF

