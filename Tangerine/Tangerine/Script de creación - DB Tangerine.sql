create table LUGAR_DIRECCION
(
	lug_dir_id int not null,
	lug_dir_nombre varchar(255) not null,
	lug_dir_tipo varchar(10) not null,--TIPO: País, Estado, Ciudad, Dirección
	fk_lug_dir_id int,

	constraint pk_lug_dir primary key
	(
		lug_dir_id
	),

	constraint fk_lug_Dir foreign key
	(
		fk_lug_dir_id
	) references LUGAR_DIRECCION(lug_dir_id)
);

create table EMPLEADO
(
	emp_num_ficha int not null,
	emp_cedula int not null,
	emp_genero varchar(10) not null,--Género: Masculino, Femenino
	emp_p_nombre varchar(50) not null,
	emp_s_nombre varchar(50),
	emp_p_apellido varchar(50) not null,
	emp_s_apellido varchar(50),
	emp_fecha_nac date not null,
	emp_nivel_estudio varchar(25) not null,--Nivel de estudio: Universitario completado, Universitario en proceso, Bachiller
	emp_email varchar(50) not null,
	emp_activo varchar(8) not null,--Activo: Activo, Inactivo
	fk_lug_dir_id int not null,

	constraint pk_emp primary key
	(
		emp_num_ficha
	),

	constraint fk_emp_lug_dir foreign key
	(
		fk_lug_dir_id
	) references LUGAR_DIRECCION(lug_dir_id)
);

create table CARGO
(
	car_id int not null,
	car_nombre varchar(40) not null,
	car_descripcion varchar(100),

	constraint pk_car primary key
	(
		car_id
	)
);

create table CARGO_EMPLEADO
(
	car_emp_fecha_cont date not null,
	car_emp_fecha_fin date,
	car_emp_modalidad varchar(20) not null,
	car_emp_sueldo numeric(6,3) not null,
	fk_car_id int not null,
	fk_emp_num_ficha int not null,

	constraint pk_car_emp primary key
	(
		car_emp_fecha_cont,
		fk_car_id,
		fk_emp_num_ficha
	),

	constraint fk_car_emp_car foreign key
	(
		fk_car_id
	) references CARGO(car_id),

	constraint fk_car_emp_emp foreign key
	(
		fk_emp_num_ficha
	) references EMPLEADO(emp_num_ficha)
);

create table ROL 
(
	rol_id int not null,
	rol_nombre varchar(20) not null,--Nombre de rol: Administrador, Director, Gerente, Programador

	constraint  pk_rol primary key
	(
		rol_id
	)
);

create table USUARIO 
(
	usu_id int not null,
	usu_usuario varchar(20) not null,
	usu_contrasena varchar(100) not null,
	usu_fecha_creacion date not null,
	usu_activo varchar(8) not null, --Activo: Activo, Inactivo
	fk_rol_id int not null,
	fk_emp_num_ficha int,

	constraint pk_usu primary key
	(
		usu_id
	),

	constraint fk_rol_usu foreign key
	(
		fk_rol_id
	) references ROL(rol_id),

	constraint fk_emp_usu foreign key
	(
		fk_emp_num_ficha
	) references EMPLEADO(emp_num_ficha)
);

create table CLIENTE_POTENCIAL
(
	cli_pot_id int not null,
	cli_pot_nombre varchar(20) not null,
	cli_pot_rif varchar(20) not null,
	cli_pot_email varchar(50) not null,
	cli_pot_pres_anual_inv numeric(12,3) not null,
	cli_pot_num_llamadas int not null,
	cli_pot_num_visitas int not null,
	cli_pot_potencial bit default(0) not null,
	cli_pot_borrado bit default(0) not null,

	constraint pk_cli_pot primary key
	(
		cli_pot_id
	)
);

create table COMPANIA
(
	com_id int IDENTITY(1,1) not null,
	com_nombre varchar(50) not null,
	com_rif varchar(20) not null,
	com_email varchar(50) not null,
	com_telefono varchar(30) not null,
	com_acronimo varchar(20) not null,
	com_fecha_registro date not null,
	com_status int not null,
	fk_lug_dir_id int not null,

	constraint pk_com primary key
	(
		com_id
	),

	constraint fk_lug_dir_com foreign key
	(
		fk_lug_dir_id
	) references LUGAR_DIRECCION(lug_dir_id),
);

create table TELEFONO 
(
	tel_id int IDENTITY(1,1) not null,
	tel_numero int not null,
	fk_emp_num_ficha int,
	fk_com_id int,
	fk_cli_pot_id int,

	constraint pk_tel primary key
	(
		tel_id
	),

	constraint fk_emp_tel foreign key
	(
		fk_emp_num_ficha
	) references EMPLEADO(emp_num_ficha),

	constraint fk_com_tel foreign key
	(
		fk_com_id
	) references COMPANIA(com_id),

	constraint  fk_cli_pot_tel foreign key
	(
		fk_cli_pot_id
	) references CLIENTE_POTENCIAL(cli_pot_id)
);

create table CONTACTO
(
	con_id int  IDENTITY(1,1) not null,
	con_nombre varchar(50) not null,
	con_apellido varchar(50) not null,
	con_departamento varchar(50) not null,
	con_cargo varchar(50) not null,
	con_telefono varchar(50),
	con_correo varchar(50),
	con_tipo_emp int not null,
	fk_id_com_lead int not null,

	constraint pk_con primary key
	(
		con_id
	)
);

      create table PROPUESTA
(
	prop_id int not null,
	prop_nombre varchar(50),
	prop_descripcion varchar(255),
	prop_tipoDuracion varchar(200),
	prop_Duracion varchar(200),
	prop_acuerdo_pago varchar(200),
	prop_estatus varchar(20),
	prop_moneda varchar(40),
	prop_cant_entregas int,
	prop_fecha_inicio date,
	prop_fecha_fin date,
	prop_costo int,
	fk_com_id int,

	constraint pk_prop primary key
	(
		prop_id
	),

	constraint fk_com_prop foreign key
	(
		fk_com_id
	) references COMPANIA(com_id)
);

create table REQUERIMIENTO
(
	req_id int not null,
	req_nombre varchar(200) not null,
	fk_prop_id int not null,

	constraint pk_req primary key
	(
		req_id
	),

	constraint fk_prop_req foreign key
	(
		fk_prop_id
	) references PROPUESTA(prop_id)
);

create table PROYECTO
(
	proy_id int IDENTITY(1,1) not null,
	proy_nombre varchar(50) not null,
	proy_codigo varchar(255) not null,
	proy_fecha_inicio date not null,
	proy_fecha_est_fin date not null,
	proy_costo numeric(12,3) not null,
	proy_descripcion varchar(255) not null,
	proy_realizacion varchar(100) not null,
	proy_estatus varchar(20) not null,
	proy_razon varchar(100) not null,
	proy_acuerdo_pago varchar(100) not null,
	fk_propuesta_id int not null,
	fk_com_id int not null,
	fk_gerente_id int not null,

	constraint pk_proy primary key
	(
		proy_id
	),

	constraint fk_com_proy foreign key
	(
		fk_com_id
	) references COMPANIA(com_id),
	
	constraint fk_propuesta_proy foreign key
	(
		fk_propuesta_id
	) references PROPUESTA(prop_id),
	
	constraint fk_gerente_proy foreign key
	(
		fk_gerente_id
	) references EMPLEADO(emp_num_ficha)
);

create table EMPLEADO_PROYECTO
(
	fk_emp_num_ficha int not null,
	fk_proy_id int not null,

	constraint pk_emp_proy primary key
	(
		fk_emp_num_ficha,
		fk_proy_id
	),

	constraint fk_emp_emp_proy foreign key
	(
		fk_emp_num_ficha
	) references EMPLEADO(emp_num_ficha),

	constraint fk_proy_emp_proy foreign key
	(
		fk_proy_id
	) references PROYECTO(proy_id)
);

create table CONTACTO_PROYECTO
(
	cp_id  int  IDENTITY(1,1) not null,
	fk_con_id int not null,
	fk_proy_id int not null,

	constraint pk_cp_id primary key
	(
		cp_id
	),

	constraint fk_con_con_proy foreign key
	(
		fk_con_id
	) references CONTACTO(con_id),

	constraint fk_proy_con_proy foreign key
	(
		fk_proy_id
	) references PROYECTO(proy_id)
);

create table FACTURA 
(
	fac_id int IDENTITY (1,1) not null,
	fac_fecha_emision date not null,
	fac_monto_total numeric(12,3) not null,
	fac_monto_restante numeric(12,3) not null,
	fac_descripcion varchar(500) not null,
	fac_estatus int not null,
	fk_proy_id int not null,
	fk_compania_id int not null,

	constraint pk_fac primary key
	(
		fac_id
	),
	
	constraint fk_compania_fac foreign key
	(
		fk_compania_id
	)references COMPANIA(com_id),

	constraint fk_proy_fac foreign key
	(
		fk_proy_id
	) references PROYECTO(proy_id)
);

create table PAGO
(
	pag_id int not null,
	pag_monto numeric(12,3) not null,
	pag_fecha date not null,
	fk_fac_id int not null,

	constraint pk_pag primary key
	(
		pag_id
	),

	constraint fk_fac_pag foreign key
	(
		fk_fac_id
	) references FACTURA(fac_id)
);

create table TIPO_PAGO
(
	tip_id int not null,
	tip_nombre varchar(50) not null,
	tip_descripcion varchar(200) not null,
	fk_pag_id int not null,

	constraint pk_tip_pag primary key
	(
		tip_id
	),

	constraint fk_pag_tip foreign key
	(
		fk_pag_id
	) references PAGO(pag_id)
);

create table DETALLE_PAGO
(
	det_pag_id int not null,
	det_pag_nombre varchar(40) not null,
	det_pag_descripcion varchar(200) not null,
	det_pag_encriptado varchar(200) not null,
	fk_pag_id int not null,

	constraint pk_det_pag primary key
	(
		det_pag_id
	),

	constraint fk_pag_det_pag foreign key
	(
		fk_pag_id
	) references PAGO(pag_id)
);

create table MENU
(
	men_id int not null,
	men_nombre varchar(100) not null,

	constraint pk_men primary key
	(
		men_id
	)
);

create table OPCION
(
	opc_id int not null,
	opc_nombre varchar(100) not null,
	opc_url varchar(500) not null,
	fk_men_id int not null,

	constraint pk_opc primary key
	(
		opc_id
	),

	constraint fk_men_opc foreign key
	(
		fk_men_id
	) references MENU(men_id)	
);

create table ROL_OPCION
(
	fk_rol_id int not null,
	fk_opc_id int not null,

	constraint pk_rol_opc primary key
	(
		fk_rol_id,
		fk_opc_id
	),

	constraint fk_rol_rol_opc foreign key
	(
		fk_rol_id
	) references ROL(rol_id),

	constraint fk_opc_rol_opc foreign key
	(
		fk_opc_id
	) references OPCION(opc_id)
);
GO

--------Stored Procedure M4--------
CREATE PROCEDURE M2_AgregarUsuario
	(@usuario [varchar](20),
	@contraseña [varchar](100),
	@emp_num_ficha int,
	@fecha_creacion date,
	@rol_nombre [varchar](20))
AS
DECLARE
	@id_rol int,
	@id_usuario int
BEGIN
	set @id_usuario = (SELECT ISNULL(MAX(usu_id), 0) FROM USUARIO); 
	set @id_rol = (SELECT rol_id FROM ROL WHERE rol_nombre = @rol_nombre);
    if @emp_num_ficha < 1
		set @emp_num_ficha = null;
	INSERT INTO USUARIO VALUES (@id_usuario + 1, @usuario, @contraseña, @fecha_creacion, 'Activo', 
		                        @id_rol, @emp_num_ficha);
END;
GO

CREATE PROCEDURE M2_ModificarRolUsuario
	(@usuario [varchar](20),
	@rol_nombre_nuevo [varchar](20))
AS
DECLARE
	@id_rol int,
	@id_usuario int
BEGIN
	set @id_usuario = (SELECT usu_id FROM USUARIO WHERE usu_usuario = @usuario); 
	set @id_rol = (SELECT rol_id FROM ROL WHERE rol_nombre = @rol_nombre_nuevo);
	UPDATE USUARIO SET fk_rol_id = @id_rol where usu_id = @id_usuario;
END;
GO

CREATE PROCEDURE M2_ModificarContraUsuario
	(@usuario [varchar](20),
	@contraseña_nueva [varchar](100))
AS
DECLARE
	@id_usuario int
BEGIN
	set @id_usuario = (SELECT usu_id FROM USUARIO WHERE usu_usuario = @usuario); 
	UPDATE USUARIO SET usu_contrasena = @contraseña_nueva where usu_id = @id_usuario;
END;
GO

CREATE PROCEDURE M2_ObtenerDatoUsuario
		@usu_nom [varchar](200),
		@usu_contra [varchar](200)

AS
	BEGIN
		SELECT usu_fecha_creacion, usu_activo, fk_rol_id, fk_emp_num_ficha
        FROM usuario
        WHERE usu_usuario = @usu_nom and usu_contrasena = @usu_contra;
	END;
GO

--------Stored Procedure M4--------
---- StoredProcedure Agregar Compañia ----
CREATE PROCEDURE M4_AgregarCompania
	@nombre [varchar](50),
	@rif [varchar](20),
	@email [varchar](50),
	@telefono [varchar](30),
	@acronimo [varchar](20),
	@fecha_registro date,
	@status int,
	@id_lugar int

AS
 BEGIN
    INSERT INTO COMPANIA(com_nombre, com_rif, com_email, com_telefono, com_acronimo, com_fecha_registro, com_status, fk_lug_dir_id) 
	VALUES(@nombre,	@rif, @email, @telefono, @acronimo, @fecha_registro, @status, @id_lugar);  
 END;
GO

---- StoredProcedure Consultar Compañia ----
CREATE PROCEDURE M4_ConsultarCompania
		@id int
AS
	BEGIN
		SELECT com_nombre as com_nombre, com_rif as com_rif, com_email as con_email, com_telefono as com_telefono, com_acronimo as com_acronimo,
			com_fecha_registro as com_fecha_registro, com_status as com_status, fk_lug_dir_id as fk_lug_dir_id
		FROM COMPANIA WHERE com_id = @id;
	END
GO

---- StoredProcedure Consultar Compañias ----
CREATE PROCEDURE M4_ConsultarCompanias

AS
	BEGIN
		SELECT com_id as com_id, com_nombre as com_nombre, com_rif as com_rif, com_email as com_email, com_telefono as com_telefono,
				com_acronimo as com_acronimo,com_fecha_registro as com_fecha_registro, com_status as com_status, 
				fk_lug_dir_id as fk_lug_dir_id
		FROM COMPANIA;
	END
GO

---- StoredProcedure Modificar Compañia ----
CREATE PROCEDURE M4_ModificarCompania
	@id int,
	@nombre [varchar](50),
	@rif [varchar](20),
	@email [varchar](50),
	@telefono [varchar](30),
	@acronimo [varchar](20),
	@fecha_registro date,
	@status int,
	@id_lugar int
AS
 BEGIN
    update COMPANIA set com_nombre = @nombre, com_rif = @rif, com_email = @email, com_telefono = @telefono,
    com_acronimo = @acronimo, com_fecha_registro = @fecha_registro, com_status = @status,
    fk_lug_dir_id = @id_lugar
    where com_id = @id;  
 end;
GO

---- StoredProcedure Inhabilitar/Habilirar Compañia ----
CREATE PROCEDURE M4_InhabilitarHabilitarCompania
	@id int,
	@status int
AS
 BEGIN
    update COMPANIA set com_status = @status
    where com_id = @id;  
 end;

GO
--- StoredProcedure Eliminar una compañia(Para pruebas) ----
CREATE PROCEDURE M4_EliminarCompania
	@id int
AS
 BEGIN
    DELETE FROM Compania WHERE com_id = @id;  
 end;
GO

------Fin Stored Procedure M4------




-----------------------------------
--------Stored Procedure M5--------
-----------------------------------
--Agregar Contacto
CREATE PROCEDURE M5_AgregarContacto
	@nombre [varchar](50),
	@apellido [varchar](50),
	@departamento [varchar](50),
	@cargo [varchar](50),
	@telefono [varchar](50),
	@correo [varchar](50),
	@tipo_comp int,
	@id_empresa int
AS
 BEGIN
    INSERT INTO CONTACTO(con_nombre, con_apellido, con_departamento, con_cargo, con_telefono, con_correo, con_tipo_emp, fk_id_com_lead) 
	VALUES(@nombre,	@apellido, @departamento, @cargo, @telefono, @correo, @tipo_comp, @id_empresa);  
 end;
GO
--Consultar un contacto por su id
CREATE PROCEDURE M5_ConsultarContactoId
		@id INT
AS
	BEGIN
		SELECT con_id as con_id, con_nombre as con_nombre, con_apellido as con_apellido,
		con_departamento as con_departamento, con_cargo as con_cargo, con_telefono as con_telefono,
		con_correo as con_correo, con_tipo_emp as con_tipo_emp, fk_id_com_lead as fk_id_com_lead
		FROM CONTACTO WHERE con_id = @id;
	END;
GO
--Agregar a contacto_proyecto
CREATE PROCEDURE M5_AgregarContactoProyecto
	@id_contacto int,
	@id_proyecto int
AS
 BEGIN
    INSERT INTO CONTACTO_PROYECTO(fk_con_id, fk_proy_id) 
	VALUES(@id_contacto,@id_proyecto);  
 end;
GO
--Eliminar a contacto_proyecto
CREATE PROCEDURE M5_EliminarContactoProyecto
	@id_contacto int,
	@id_proyecto int
AS
 BEGIN
    DELETE FROM CONTACTO_PROYECTO WHERE fk_con_id = @id_contacto AND fk_proy_id = @id_proyecto;  
 end;
GO
--Eliminar de contacto y contacto_proyecto por id
CREATE PROCEDURE M5_EliminarContacto
@id int
AS
 BEGIN
    DELETE FROM CONTACTO_PROYECTO WHERE fk_con_id = @id;
	DELETE FROM CONTACTO WHERE con_id = @id;
 END;
GO
--Modificar un contacto
CREATE PROCEDURE M5_ModificarContacto
	@id int,
	@nombre [varchar](50),
	@apellido [varchar](50),
	@departamento [varchar](50),
	@cargo [varchar](50),
	@telefono [varchar](50),
	@correo [varchar](50)
AS
 BEGIN
    update CONTACTO set con_nombre = @nombre, con_apellido = @apellido, con_departamento = @departamento,
    con_cargo = @cargo, con_telefono = @telefono, con_correo = @correo
    where con_id = @id;  
 end;
GO
--Consultar contactos de una empresa
CREATE PROCEDURE M5_ConsultarContactoCompania
		@tipo_comp INT,
		@id_empresa INT
AS
	BEGIN
		SELECT con_id as con_id, con_nombre as con_nombre, con_apellido as con_apellido,
		con_departamento as con_departamento, con_cargo as con_cargo, con_telefono as con_telefono,
		con_correo as con_correo, con_tipo_emp as con_tipo_emp, fk_id_com_lead as fk_id_com_lead
		FROM CONTACTO WHERE fk_id_com_lead = @id_empresa and con_tipo_emp = @tipo_comp;
	END
GO
-----------------------------------
------Fin Stored Procedure M5------
-----------------------------------

-----------------------------------
--------Stored Procedure M6--------
-----------------------------------
--Agregar Propuesta
CREATE PROCEDURE M6_AgregarPropuesta
	@nombre [varchar](50),
	@descripcion [varchar](255),
	@duracion [varchar](200),
	@acuerdo [varchar](200),
	@estatus [varchar](20),
	@moneda [varchar](40),
	@cantEntr int,
	@fechai date,
	@fechaf date
AS
 BEGIN
    INSERT INTO PROPUESTA(prop_nombre, prop_descripcion, prop_duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio,prop_fecha_fin) 
	VALUES(@nombre,	@descripcion, @duracion, @acuerdo, @estatus, @moneda, @cantEntr, @fechai,@fechaf);  
 end;
GO
-----------------------------------
------Fin Stored Procedure M6------
-----------------------------------


-----------------------------------
--------Stored Procedure M7--------
-----------------------------------
---- StoredProcedure Agregar Proyecto ----
CREATE PROCEDURE M7_AgregarProyecto
    @Nombre [varchar](500),
    @Codigo [varchar](500),
    @FechaInicio date,
    @FechaEstFin date,
    @Costo numeric(12,3),
    @Descripcion [varchar](500),
    @Realizacion [varchar](500),
    @Estatus [varchar](500),
    @Razon [varchar](500),
    @AcuerdoPago [varchar](500),
    @IdPropuesta int,
    @IdCompania int,
    @IdGerente int

AS
	BEGIN
    	INSERT INTO PROYECTO(proy_nombre,proy_codigo,proy_fecha_inicio,proy_fecha_est_fin,proy_costo,proy_descripcion,proy_realizacion,proy_estatus,proy_acuerdo_pago,proy_razon,fk_propuesta_id,fk_com_id,fk_gerente_id) 
		VALUES(@Nombre,@Codigo,@FechaInicio,@FechaEstFin,@Costo,@Descripcion,@Realizacion,@Estatus,@Razon,@AcuerdoPago,@IdPropuesta,@IdCompania,@IdGerente);  
 	END;
GO

---- StoredProcedure Consultar Proyecto ----
CREATE PROCEDURE M7_ConsultarProyecto
	@IdProyecto int

AS
	BEGIN
		SELECT proy_id AS proy_id ,proy_nombre AS proy_nombre, proy_codigo AS proy_codigo, proy_fecha_inicio AS proy_fecha_inicio,
			proy_fecha_est_fin AS proy_fecha_est_fin, proy_costo AS proy_costo, proy_descripcion AS proy_descripcion,
			proy_realizacion AS proy_realizacion,proy_estatus AS proy_estatus,proy_razon AS proy_razon,
			proy_acuerdo_pago AS proy_acuerdo_pago,fk_propuesta_id AS fk_propuesta_id,fk_com_id AS fk_com_id,fk_gerente_id AS fk_gerente_id
		FROM PROYECTO WHERE proy_id = @IdProyecto;
	END
GO

---- StoredProcedure Consultar Proyectos ----
CREATE PROCEDURE M7_ConsultarProyectos

AS
	BEGIN
		SELECT proy_id AS proy_id, proy_nombre AS proy_nombre, proy_codigo AS proy_codigo, proy_fecha_inicio AS proy_fecha_inicio,
			proy_fecha_est_fin AS proy_fecha_est_fin, proy_costo AS proy_costo, proy_descripcion AS proy_descripcion,
			proy_realizacion AS proy_realizacion,proy_estatus AS proy_estatus,proy_razon AS proy_razon,
			proy_acuerdo_pago AS proy_acuerdo_pago,fk_propuesta_id AS fk_propuesta_id,fk_com_id AS fk_com_id,fk_gerente_id AS fk_gerente_id
		FROM PROYECTO;
	END
GO

---- StoredProcedure Modificar Proyecto ----
CREATE PROCEDURE M7_ModificarProyecto
	@IdProyecto int,
	@Nombre [varchar](500),
    @Codigo [varchar](500),
    @FechaInicio date,
    @FechaEstFin date,
    @Costo numeric(12,3),
    @Descripcion [varchar](500),
    @Realizacion [varchar](500),
    @Estatus [varchar](500),
    @Razon [varchar](500),
    @AcuerdoPago [varchar](500),
    @IdPropuesta int,
    @IdCompania int,
    @IdGerente int

AS
 	BEGIN
    	UPDATE PROYECTO SET proy_nombre = @Nombre, proy_codigo = @Codigo, proy_fecha_inicio = @FechaInicio,
    		proy_fecha_est_fin = @FechaEstFin, proy_costo = @Costo, proy_descripcion = @Descripcion,
    		proy_realizacion = @Realizacion, proy_estatus = @Estatus, proy_razon = @Razon,
    		proy_acuerdo_pago = @AcuerdoPago,fk_propuesta_id = @IdPropuesta, fk_com_id = @IdCompania, fk_gerente_id = @IdGerente
    	WHERE proy_id = @IdProyecto;  
 	end;
GO


---- StoredProcedure Agregar ProyectoContacto ----
CREATE PROCEDURE M7_AgregarProyectoContacto
    @PCIdContacto int,
    @IdProyecto int
AS
	BEGIN
    	INSERT INTO CONTACTO_PROYECTO(	fk_con_id,fk_proy_id) 
		VALUES(@PCIdContacto,@IdProyecto);  
 	END;
GO


---- StoredProcedure Consultar ProyectoContacto ----
CREATE PROCEDURE M7_ConsultarProyectoContacto
	@IdProyecto int

AS
	BEGIN
		SELECT fk_con_id AS fk_con_id
		FROM CONTACTO_PROYECTO WHERE fk_proy_id = @IdProyecto;
	END
GO


---- StoredProcedure Eliminar ProyectoContacto ----
CREATE PROCEDURE M7_EliminarProyectoContacto
	@IdProyecto int
AS
 BEGIN
    DELETE FROM CONTACTO_PROYECTO WHERE fk_proy_id = @IdProyecto;  
 end;
GO

---- StoredProcedure Agregar ProyectoEmpleado ----
CREATE PROCEDURE M7_AgregarProyectoEmpleado
	@PEIdEmpleado int,
    @IdProyecto int
AS
	BEGIN
    	INSERT INTO EMPLEADO_PROYECTO(	fk_emp_num_ficha,fk_proy_id) 
		VALUES(@PEIdEmpleado,@IdProyecto);  
 	END;
GO


---- StoredProcedure Consultar ProyectoEmpleado ----
CREATE PROCEDURE M7_ConsultarProyectoEmpleado
	@IdProyecto int
AS
	BEGIN
		SELECT fk_emp_num_ficha AS fk_emp_num_ficha
		FROM EMPLEADO_PROYECTO WHERE fk_proy_id = @IdProyecto;
	END
GO


---- StoredProcedure Eliminar ProyectoEmpleado ----
CREATE PROCEDURE M7_EliminarProyectoEmpleado
	@IdProyecto int
AS
 BEGIN
    DELETE FROM EMPLEADO_PROYECTO 
     WHERE fk_proy_id = @IdProyecto;  
 end;
GO

---- StoredProcedure Consultar Proyecto por acuerdo de pago mensual ----
CREATE PROCEDURE M7_ConsultarAcuerdoPagoMensual

AS
	BEGIN
		SELECT proy_id AS proy_id ,proy_nombre AS proy_nombre, proy_codigo AS proy_codigo, proy_fecha_inicio AS proy_fecha_inicio,
			proy_fecha_est_fin AS proy_fecha_est_fin, proy_costo AS proy_costo, proy_descripcion AS proy_descripcion,
			proy_realizacion AS proy_realizacion,proy_estatus AS proy_estatus,proy_razon AS proy_razon,
			proy_acuerdo_pago AS proy_acuerdo_pago,fk_propuesta_id AS fk_propuesta_id,fk_com_id AS fk_com_id,fk_gerente_id AS fk_gerente_id
		FROM PROYECTO WHERE DAY(proy_fecha_inicio) = DAY(GETDATE()) and proy_estatus = 'Desarrollo' and proy_acuerdo_pago = 'Mensual';
	END
GO


---- StoredProcedure Consultar Proyectos  en los que trabaja un empleado----
CREATE PROCEDURE M7_ConsultarProyectoTrabajaEmpleado
@PEIdEmpleado int

AS
	BEGIN
		SELECT proy_id AS proy_id, proy_nombre AS proy_nombre, proy_codigo AS proy_codigo, proy_fecha_inicio AS proy_fecha_inicio,
			proy_fecha_est_fin AS proy_fecha_est_fin, proy_costo AS proy_costo, proy_descripcion AS proy_descripcion,
			proy_realizacion AS proy_realizacion,proy_estatus AS proy_estatus,proy_razon AS proy_razon,
			proy_acuerdo_pago AS proy_acuerdo_pago,fk_propuesta_id AS fk_propuesta_id,fk_com_id
			 AS fk_com_id,fk_gerente_id AS fk_gerente_id
		FROM PROYECTO, EMPLEADO_PROYECTO 
		WHERE PROYECTO.proy_id = EMPLEADO_PROYECTO.fk_proy_id AND EMPLEADO_PROYECTO.fk_emp_num_ficha = @PEIdEmpleado; 

	END;
GO
		
---- StoredProcedure Consultar Los proyectos que tenga un gerente ----
CREATE PROCEDURE M7_ConsultarProyectosPorGerente

     @IdGerente int
     
AS
	BEGIN
		SELECT proy_id AS proy_id ,proy_nombre AS proy_nombre, proy_codigo AS proy_codigo, proy_fecha_inicio AS proy_fecha_inicio,
			proy_fecha_est_fin AS proy_fecha_est_fin, proy_costo AS proy_costo, proy_descripcion AS proy_descripcion,
			proy_realizacion AS proy_realizacion,proy_estatus AS proy_estatus,proy_razon AS proy_razon,
			proy_acuerdo_pago AS proy_acuerdo_pago,fk_propuesta_id AS fk_propuesta_id,fk_com_id AS fk_com_id,fk_gerente_id AS fk_gerente_id
		FROM PROYECTO WHERE fk_gerente_id = @IdGerente ;
	END
GO		



-----------------------------------
------Fin Stored Procedure M7------
-----------------------------------

-----------------------------------
--------Stored Procedure M8--------
-----------------------------------
---- StoredProcedure Agregar Factura ----
CREATE PROCEDURE M8_AgregarFactura
	@fecha_emision date,
	@monto_total numeric(12,3),
	@monto_restante numeric(12,3),
	@descripcion [varchar](500),
	@estatus int,
	@id_proyecto int,
	@id_compania int

AS
	BEGIN
    	INSERT INTO FACTURA(fac_fecha_emision, fac_monto_total, fac_monto_restante, fac_descripcion, fac_estatus, fk_proy_id, fk_compania_id) 
		VALUES(@fecha_emision, @monto_total, @monto_restante, @descripcion, @estatus, @id_proyecto, @id_compania);  
 	END;
GO

---- StoredProcedure Consultar Factura ----
CREATE PROCEDURE M8_ConsultarFactura
	@id_Factura int

AS
	BEGIN
		SELECT fac_id as fac_id, fac_fecha_emision AS fac_fecha_emision, fac_monto_total AS fac_monto_total, fac_monto_restante AS fac_monto_restante,
			fac_descripcion AS fac_descripcion, fac_estatus AS fac_estatus, fk_proy_id AS fk_proy_id, fk_compania_id AS fk_compania_id
		FROM FACTURA WHERE fac_id = @id_Factura;
	END
GO

---- StoredProcedure Consultar Facturas ----
CREATE PROCEDURE M8_ConsultarFacturas

AS
	BEGIN
		SELECT fac_id as fac_id, fac_fecha_emision AS fac_fecha_emision, fac_monto_total AS fac_monto_total, fac_monto_restante AS fac_monto_restante,
			fac_descripcion AS fac_descripcion, fac_estatus AS fac_estatus, fk_proy_id AS fk_proy_id, fk_compania_id AS fk_compania_id
		FROM FACTURA;
	END
GO

CREATE PROCEDURE M8_ConsultarNombreCompaniaFacturas
	@id int

AS
	BEGIN
		SELECT com_nombre AS com_nombre
		FROM COMPANIA WHERE com_id = @id;
	END
GO

---- StoredProcedure Modificar Factura ----
CREATE PROCEDURE M8_ModificarFactura
	@id_Factura int,
	@fecha_emision date,
	@monto_total numeric(12,3),
	@monto_restante numeric(12,3),
	@descripcion [varchar](500),
	@estatus int,
	@id_proyecto int,
	@id_compania int

AS
 	BEGIN
    	UPDATE FACTURA SET fac_fecha_emision = @fecha_emision, fac_monto_total = @monto_total, fac_monto_restante = @monto_restante,
    		fac_descripcion = @descripcion, fac_estatus = @estatus, fk_proy_id = @id_proyecto, fk_compania_id = @id_compania
    	WHERE fac_id = @id_Factura;  
 	END;
GO

/*Falta el campo factura*/
/*---- StoredProcedure Cambiar Estatus de Factura ----
CREATE PROCEDURE M8_EstatusFactura
	@id int,
	@estatus [varchar](500)
AS
 	BEGIN
    	UPDATE FACTURA SET fac_estatus = @estatus
    	WHERE fac_id = @id;  
 	END;
GO*/

-----------------------------------
------Fin Stored Procedure M8------
-----------------------------------

-----------------------------------
--------Stored Procedure M10--------
-----------------------------------
---- StoredProcedure Agregar Empleado ----
CREATE PROCEDURE M10_AgregarEmpleado
	@activo [varchar](50),
	@cedula int,
	@direccion [varchar](50),
	@email [varchar](50),
	@estado [varchar](50),
	@fecha_nac date,
	@ficha int,
	@genero [varchar](50),
	@nivel_estudio [varchar](50),
	@pais [varchar](50),
	@p_apellido [varchar](50),
	@p_nombre [varchar](50),
	@s_apellido [varchar](50),
	@s_nombre [varchar](50)
AS
 BEGIN
    INSERT INTO EMPLEADO(emp_p_nombre, emp_s_nombre, emp_p_apellido, emp_s_apellido, emp_cedula, emp_activo,
						emp_email, emp_fecha_nac, emp_genero, emp_nivel_estudio,fk_lug_dir_id) 
	VALUES(@p_nombre,	@s_nombre, @p_apellido, @s_apellido, @cedula, @activo, @email, @fecha_nac, @genero, @nivel_estudio,1);  
 end;
GO

--Consultar empleados
CREATE PROCEDURE M10_ConsultarEmpleado
		@prueba INT
AS
	BEGIN
		SELECT emp_num_ficha as emp_num_ficha, emp_p_nombre as emp_p_nombre,emp_s_nombre as emp_s_nombre,
		emp_p_apellido as emp_p_apellido, emp_s_apellido as emp_s_apellido,
		emp_cedula as emp_cedula, emp_fecha_nac as emp_fecha_nac,
		emp_activo as emp_activo, fk_lug_dir_id as fk_lug_dir_id
		FROM EMPLEADO;
	END
GO

-----------------------------------
------Fin Stored Procedure M10-----
-----------------------------------