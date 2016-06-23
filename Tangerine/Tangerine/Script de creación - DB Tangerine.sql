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
	car_emp_sueldo numeric(18,0) not null,
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
	 cli_pot_id int IDENTITY (1, 1) NOT NULL,
	 cli_pot_nombre varchar(20) not null,
	 cli_pot_rif varchar(20) not null,
	 cli_pot_email varchar(50) not null,
	 cli_pot_pres_anual_inv numeric(12,3) not null,
	 cli_pot_num_llamadas int default(0) not null,
	 cli_pot_num_visitas int default(0) not null,
	 cli_pot_status int not null,

	 constraint pk_cli_pot primary key
	 (
	  cli_pot_id
	 )
);

create table COMPANIA
(
	com_id int IDENTITY(1,1) not null,
	com_nombre varchar(50) not null unique,
	com_rif varchar(20) not null unique,
	com_email varchar(50) not null,
	com_telefono varchar(30) not null,
	com_acronimo varchar(20),
	com_fecha_registro date not null,
	com_status int not null,
	com_presupuesto int not null,
	com_plazo_pago int not null,
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
	prop_id int IDENTITY(1,1) not null,
	prop_nombre varchar(200),
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
	req_id int IDENTITY(1,1) not null,
	req_codigo varchar(200) not null,
	req_descripcion varchar(200) not null,
	fk_prop_req_id varchar(200) not null,
	fk_prop_id int

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
	proy_estatus varchar(255) not null,
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
	fac_fecha_ultimo_pago date not null,
	fac_monto_total numeric(12,3) not null,
	fac_monto_restante numeric(12,3) not null,
	fac_tipo_moneda varchar(100) not null,
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
	pag_id int IDENTITY(1,1) not null,
	pag_moneda varchar(50) not null,
	pag_monto numeric(12,3) not null,
	pag_forma varchar(20) not null,
	pag_cod numeric (12,0) not null,
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

create table Seguimiento
(
	seg_id int not null,
	seg_fecha date not null,
	seg_tipo varchar(15) not null,--Género: Llamada, Visita
	seg_motivo varchar(255),
	fk_cli_pot int not null,

	constraint pk_Seguimiento primary key
	(
		seg_id
	),

	constraint fk_cliente_potencial_seg foreign key
	(
		fk_cli_pot
	) references CLIENTE_POTENCIAL(cli_pot_id)
);

GO

--------Stored Procedure M2---------------------------------------------------------------------------------------------------
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

CREATE PROCEDURE M2_BorrarUsuario
	@usu_id int
AS
	BEGIN
		DELETE FROM USUARIO
 		WHERE usu_id = @usu_id;
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
		@usuario [varchar](200),
		@contraseña [varchar](200)

AS
	BEGIN
		SELECT usu_fecha_creacion, usu_activo, fk_rol_id, isnull(fk_emp_num_ficha,0) as fk_emp_num_ficha
        FROM usuario
        WHERE usu_usuario = @usuario and usu_contrasena = @contraseña;
	END;
GO

CREATE PROCEDURE M2_ObtenerRolUsuario
@codigo_rol int
AS
	BEGIN
		SELECT distinct rol_nombre, m.men_nombre as men_nombre
		FROM rol, rol_opcion, opcion, menu m
		WHERE rol_id = fk_rol_id and fk_opc_id = opc_id and fk_men_id = m.men_id and rol_id = @codigo_rol;
	END;
GO

CREATE PROCEDURE M2_ObtenerOpciones
@menu_nom [varchar](200),
@codigo_rol int

AS
BEGIN
SELECT o.opc_nombre as opc_nombre, o.opc_url as opc_url
    FROM menu m, opcion o, rol_opcion ro
    WHERE m.men_nombre =@menu_nom and ro.fk_rol_id = @codigo_rol  and m.men_id = o.fk_men_id and o.opc_id = ro.fk_opc_id;
END;
GO

CREATE PROCEDURE M2_ObtenerUsuarioDeEmpleado
@emp_num_ficha int
AS
	BEGIN
		SELECT rol_nombre, usu_usuario
		FROM rol, usuario
		WHERE rol_id = fk_rol_id and fk_emp_num_ficha = @emp_num_ficha;
	END;
GO

CREATE PROCEDURE M2_ObtenerRolUsuarioPorNombre
@rol_nombre [varchar](100)
AS
	BEGIN
		SELECT rol_id
		FROM rol
		WHERE rol_nombre = @rol_nombre;
	END;
GO

CREATE PROCEDURE M2_VerificarUsuarioPorFichaEmpleado
@emp_num_ficha [varchar](100)
AS
	BEGIN
		SELECT usu_usuario
		FROM usuario
		WHERE fk_emp_num_ficha = @emp_num_ficha;
	END;
GO

CREATE PROCEDURE M2_VerificarExistenciaUsuario
@usuario [varchar](100)
AS
	BEGIN
		SELECT usu_usuario
		FROM usuario
		WHERE usu_usuario = @usuario;
	END;
GO

CREATE PROCEDURE M2_ConsultarIdUltimoUsuario
AS
 BEGIN
     SELECT MAX(usu_id) usu_id FROM USUARIO;
 end;
GO

CREATE PROCEDURE M2_ConsultarUsuario
	@id int
AS
	BEGIN
		SELECT usu_id as usu_id, usu_usuario as usu_usuario, usu_contrasena as usu_contrasena, usu_fecha_creacion as usu_fecha_creacion,
			usu_activo as usu_activo, fk_rol_id as fk_rol_id, fk_emp_num_ficha as fk_emp_num_ficha
		FROM USUARIO WHERE usu_id = @id;
	END
GO

CREATE PROCEDURE M2_ConsultarUsuarioPorNombre
	@usuario [varchar](100)
AS
	BEGIN
		SELECT  Employee.emp_num_ficha as emp_num_ficha, Employee.emp_p_nombre as emp_p_nombre,
				Employee.emp_s_nombre as emp_s_nombre,Employee.emp_p_apellido as emp_p_apellido,
				Employee.emp_s_apellido as emp_s_apellido,Employee.emp_cedula as emp_cedula,
				Employee.emp_fecha_nac as emp_fecha_nac,Employee.emp_activo as emp_activo,
				Employee.emp_email as emp_email, Employee.emp_genero as emp_genero,
				Employee.emp_nivel_estudio as emp_nivel_estudio,
				Job.car_nombre as car_nombre, Job.car_descripcion as car_descripcion,
				JobEmployee.car_emp_fecha_cont as car_emp_fecha_cont,
				JobEmployee.car_emp_modalidad as car_emp_modalidad,
				JobEmployee.car_emp_sueldo as car_emp_sueldo
			FROM EMPLEADO Employee, CARGO_EMPLEADO JobEmployee, CARGO job, USUARIO Usu, ROL Ro
		WHERE Employee.emp_num_ficha=JobEmployee.fk_emp_num_ficha
			  and JobEmployee.fk_car_id=Job.car_id
			  and Ro.rol_id = Usu.fk_rol_id
			  and Employee.emp_num_ficha = Usu.fk_emp_num_ficha
			  and Usu.usu_usuario = @usuario
	END;
GO
---------------------------------------------------------------------------------------------------------
--------Stored Procedure M3------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------


-------  Store Procedure agregar cliente_potencial -----------------------------------

create procedure M3_agregar_clientePotencial

@nombreClientePotencial [varchar](20),
@rifClientePotencial [varchar](20),
@emailClientePotencial [varchar](50),
@presupuestoAnualInversion [decimal],
@status [decimal]


as
 begin
   insert into cliente_Potencial(cli_pot_nombre,cli_pot_rif,cli_pot_email,cli_pot_pres_anual_inv,cli_pot_status)
                        values (@nombreClientePotencial,@rifClientePotencial,@emailClientePotencial,@presupuestoAnualInversion,@status);
 end;
go


----------- Store Procedure lista de clientes potenciales--------------------------
CREATE procedure M3_listar_cliente_potencial
as
	begin
		select cli_pot_id,cli_pot_nombre,cli_pot_rif,cli_pot_email,cli_pot_pres_anual_inv,cli_pot_status
		from cliente_Potencial
		where cli_pot_status != 3;

	end;
go


----------- Store Procedure eliminar cliente potencial--------------------------
CREATE PROCEDURE M3_eliminar_cliente_potencial
	@idClientePotencial [int]
as
 begin
		UPDATE cliente_Potencial
		SET
			cli_pot_status = 0
			WHERE
			cli_pot_id  = @idClientePotencial;

 end;
 go
----------Store Procedure Activar cliente potencial----------------------------

CREATE PROCEDURE M3_activar_cliente_potencial
	@idClientePotencial [int]
as
 begin
		UPDATE cliente_Potencial
		SET
			cli_pot_status = 1
			WHERE
			cli_pot_id  = @idClientePotencial;

 end;
 go



----------- Store Procedure promover cliente potencial-------------------------

CREATE PROCEDURE M3_promover_cliente_potencial
	@idClientePotencial [int]
as
 begin
		UPDATE cliente_Potencial
		SET
			cli_pot_status = 2
			WHERE
			cli_pot_id  = @idClientePotencial;

 end;
 go


----------- Store Procedure consulta de cliente potencial--------------------------


CREATE procedure M3_consultar_cliente_potencial
   @idClientePotencial		[int]
as
	begin
		select cli_pot_id , cli_pot_nombre ,
		cli_pot_rif, cli_pot_email ,cli_pot_pres_anual_inv,cli_pot_num_llamadas,cli_pot_num_visitas,cli_pot_status
		from cliente_Potencial
		where cli_pot_id = @idClientePotencial;

	end;
go


----------- Store Procedure modificar cliente potencial--------------------------
create procedure M3_modificar_clientePotencialF



	@idClientePotencial		[int],
	@nombreClientePotencial  	[varchar](20),
	@rifClientePotencial	[varchar](20),
	@emailClientePotencial	[varchar](50),
	@presupuestoAnualInversion [decimal],
        @num_llamadas[int],
        @num_visitas[int]


as
 begin
		UPDATE CLIENTE_POTENCIAL
		SET
			cli_pot_nombre          = @nombreClientePotencial,
            cli_pot_rif             = @rifClientePotencial,
			cli_pot_email	        = @emailClientePotencial,
	        cli_pot_pres_anual_inv  = @presupuestoAnualInversion,
            cli_pot_num_llamadas    = @num_llamadas,
            cli_pot_num_visitas     = @num_visitas

			WHERE
			cli_pot_id = @idClientePotencial;

 end;
 go


 --------------Eliminar cliente definitivo---------

 create procedure M3_eliminar_cliente_potencial_def
 	@idClientePotencial int
AS
 BEGIN
    DELETE FROM CLIENTE_POTENCIAL WHERE cli_pot_id = @idClientePotencial;
 end;
GO

---------------Buscar ultimo Id---------------------
CREATE PROCEDURE M3_ConsultarIdUltimoLead
AS
 BEGIN
     SELECT MAX(cli_pot_id) cli_pot_id FROM CLIENTE_POTENCIAL;
 end;
GO

------------------Consultar llamdas a cliente potencial----------------------
CREATE procedure M3_listar_Seguimento_llamadas
@idClientePotencial int,
@tipo varchar(15)
AS
BEGIN
SELECT Se.seg_id AS seg_id, Se.seg_fecha AS seg_fecha, 
  Se.seg_motivo AS seg_motivo, Se.seg_tipo AS seg_tipo, 
  Se.fk_cli_pot AS fk_cli_pot 
FROM Cliente_Potencial Cp, Seguimiento Se
WHERE Cp.cli_pot_id=Se.fk_cli_pot
 	and Se.fk_cli_pot=@idClientePotencial
 	and Se.seg_tipo=@tipo

END;

---------------------------------------------------------------------------------------------------------
--------FIN Stored Procedure M3------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------

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
	@presupuesto int,
	@plazo_pago int,
	@id_lugar int

AS
 BEGIN
    INSERT INTO COMPANIA(com_nombre, com_rif, com_email, com_telefono, com_acronimo,
		com_fecha_registro, com_status, com_presupuesto, com_plazo_pago, fk_lug_dir_id)
	VALUES(@nombre,	@rif, @email, @telefono, @acronimo, @fecha_registro, @status, @presupuesto,
		@plazo_pago, @id_lugar);
 END;
GO

---- StoredProcedure Consultar Compañia ----
CREATE PROCEDURE M4_ConsultarCompania
		@id int
AS
	BEGIN
		SELECT com_id as com_id, com_nombre as com_nombre, com_rif as com_rif, com_email as com_email,
			com_telefono as com_telefono, com_acronimo as com_acronimo,
			com_fecha_registro as com_fecha_registro, com_status as com_status,
			com_presupuesto as com_presupuesto, com_plazo_pago as com_plazo_pago,
			fk_lug_dir_id as fk_lug_dir_id
		FROM COMPANIA WHERE com_id = @id;
	END
GO

---- StoredProcedure Consultar Compañias ----
CREATE PROCEDURE M4_ConsultarCompanias

AS
	BEGIN
		SELECT com_id as com_id, com_nombre as com_nombre, com_rif as com_rif, com_email as com_email,
			com_telefono as com_telefono, com_acronimo as com_acronimo,
			com_fecha_registro as com_fecha_registro, com_status as com_status,
			com_presupuesto as com_presupuesto, com_plazo_pago as com_plazo_pago,
			fk_lug_dir_id as fk_lug_dir_id
		FROM COMPANIA;
	END
GO


---- StoredProcedure Consultar Compañia activas ----
CREATE PROCEDURE M4_ConsultarCompaniasActivas
AS
	BEGIN
		SELECT com_id as com_id, com_nombre as com_nombre, com_rif as com_rif, com_email as com_email,
			com_telefono as com_telefono, com_acronimo as com_acronimo,
			com_fecha_registro as com_fecha_registro, com_status as com_status,
			com_presupuesto as com_presupuesto, com_plazo_pago as com_plazo_pago,
			fk_lug_dir_id as fk_lug_dir_id
		FROM COMPANIA WHERE com_status = 1;
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
	@presupuesto int,
	@plazo_pago int,
	@id_lugar int
AS
 BEGIN
    update COMPANIA set com_nombre = @nombre, com_rif = @rif, com_email = @email,
    com_telefono = @telefono, com_acronimo = @acronimo, com_fecha_registro = @fecha_registro,
    com_status = @status, com_presupuesto = @presupuesto, com_plazo_pago = @plazo_pago,
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

--- StoredProcedure ConsultarIdUltimaCompania(Para pruebas) ----
CREATE PROCEDURE M4_ConsultarIdUltimaCompania
AS
 BEGIN
     SELECT MAX(com_id) com_id FROM COMPANIA;
 end;
GO

--- StoredProcedure Consultar Lugar(Para Agregar y Modificar) ----
CREATE PROCEDURE M4_ConsultarLugar

AS
	BEGIN
		SELECT lug_dir_id as lug_dir_id, lug_dir_nombre as lug_dir_nombre
		FROM Lugar_Direccion
		WHERE lug_dir_tipo LIKE 'Ciudad';
	end;
GO


--- StoredProcedure Consultar Lugar por id(Para Agregar y Modificar) ----
CREATE PROCEDURE M4_ConsultarLugarPorId
@id int
AS
	BEGIN
		SELECT lug_dir_id as lug_dir_id, lug_dir_nombre as lug_dir_nombre,
		lug_dir_tipo as lug_dir_tipo, fk_lug_dir_id as fk_lug_dir_id
		FROM Lugar_Direccion
		WHERE lug_dir_id = @id;
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
--Consultar todos los contactos
CREATE PROCEDURE M5_ConsultarTodosContactos
AS
	BEGIN
		SELECT contacto.con_id as con_id, contacto.con_nombre as con_nombre, contacto.con_apellido as con_apellido,
		contacto.con_departamento as con_departamento, contacto.con_cargo as con_cargo, contacto.con_telefono as con_telefono,
		contacto.con_correo as con_correo, contacto.con_tipo_emp as con_tipo_emp, contacto.fk_id_com_lead as fk_id_com_lead
		FROM CONTACTO
	END
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
--Consultar contactos de un proyecto
CREATE PROCEDURE M5_ConsultarContactoProyecto
		@id_proyecto INT
AS
	BEGIN
		SELECT contacto.con_id as con_id, contacto.con_nombre as con_nombre, contacto.con_apellido as con_apellido,
		contacto.con_departamento as con_departamento, contacto.con_cargo as con_cargo, contacto.con_telefono as con_telefono,
		contacto.con_correo as con_correo, contacto.con_tipo_emp as con_tipo_emp, contacto.fk_id_com_lead as fk_id_com_lead
		FROM CONTACTO, CONTACTO_PROYECTO WHERE CONTACTO_PROYECTO.fk_proy_id = @id_proyecto and CONTACTO_PROYECTO.fk_con_id = CONTACTO.con_id;
	END
GO
--Consultar contactos que no estan en el proyecto
CREATE PROCEDURE M5_ConsultarContactoNoProyecto
		@id_proyecto INT
AS
	BEGIN
		SELECT contacto.con_id as con_id, contacto.con_nombre as con_nombre, contacto.con_apellido as con_apellido,
		contacto.con_departamento as con_departamento, contacto.con_cargo as con_cargo, contacto.con_telefono as con_telefono,
		contacto.con_correo as con_correo, contacto.con_tipo_emp as con_tipo_emp, contacto.fk_id_com_lead as fk_id_com_lead
		FROM CONTACTO, COMPANIA, PROYECTO
		WHERE CONTACTO.con_tipo_emp = 1
		and CONTACTO.fk_id_com_lead = COMPANIA.com_id
		and COMPANIA.com_id = PROYECTO.fk_com_id
		and PROYECTO.proy_id = @id_proyecto
		and CONTACTO.con_id NOT IN (SELECT contacto.con_id as con_id
			FROM CONTACTO, CONTACTO_PROYECTO
			WHERE CONTACTO_PROYECTO.fk_proy_id = @id_proyecto
			and CONTACTO_PROYECTO.fk_con_id = CONTACTO.con_id)
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
	@tipoDura [varchar](200),
	@duracion [varchar](200),
	@acuerdo [varchar](200),
	@estatus [varchar](20),
	@moneda [varchar](40),
	@cantEntr int,
	@fechai date,
	@fechaf date,
	@costo int,
	@id_compania int
AS
 BEGIN
    INSERT INTO PROPUESTA(prop_nombre, prop_descripcion, prop_tipoDuracion, prop_Duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio,prop_fecha_fin,prop_costo,fk_com_id)
	VALUES(@nombre,	@descripcion, @tipoDura, @duracion, @acuerdo, @estatus, @moneda, @cantEntr, @fechai, @fechaf, @costo, @id_compania);
 end;
GO

--Agregar Requerimiento
CREATE PROCEDURE M6_AgregarRequerimiento
	@reqCodigo varchar(200),
	@reqDescripcion varchar(200),
	@fk_pro_req varchar(200)
AS
	BEGIN
		 INSERT INTO REQUERIMIENTO(req_codigo, req_descripcion,fk_prop_req_id)
	VALUES(@reqCodigo,@reqDescripcion,@fk_pro_req);
	END;
GO

--Lista Propuesta que no estan en proyecto
CREATE PROCEDURE M6_ListaPropuestaProyecto
AS
BEGIN
SELECT prop_id, prop_nombre, prop_descripcion, prop_tipoDuracion, prop_Duracion, prop_acuerdo_pago,
prop_estatus, prop_moneda, prop_cant_entregas, prop_fecha_inicio, prop_fecha_fin,prop_costo,
PROPUESTA.fk_com_id
FROM PROPUESTA LEFT JOIN PROYECTO ON (fk_propuesta_id=prop_id)
WHERE prop_estatus = 'Aprobado' and proy_id IS NULL
END;
GO

--Modificar Propuesta
CREATE PROCEDURE M6_ModificarPropuesta
@cod_Nombre [varchar] (50),
@descripcion [varchar] (255),
@tipoDura [varchar] (200),
@duracion [varchar] (200),
@acuerdo [varchar] (200),
@estatus [varchar] (20),
@moneda [varchar] (40),
@fechai date,
@fechaf date,
@costo int
AS
BEGIN
UPDATE PROPUESTA SET prop_descripcion = @descripcion, prop_tipoDuracion = @tipoDura,
prop_duracion = @duracion, prop_acuerdo_pago = @acuerdo, prop_estatus = @estatus, prop_moneda = @moneda, prop_fecha_inicio = @fechai, prop_fecha_fin = @fechaf, prop_costo = @costo
WHERE prop_nombre = @cod_Nombre
END;

GO

--- ConsultarIdUltimaPropuesta(Para pruebas) ----
CREATE PROCEDURE M6_ConsultarIdUltimaPropuesta
AS
 BEGIN
     SELECT MAX(prop_id) prop_id FROM PROPUESTA;
 end;

GO

-- Modificar Requerimiento
CREATE PROCEDURE M6_ModificarRequerimiento
@req_descripcion [varchar] (200),
@cod_Nombre [varchar] (50)
AS
BEGIN
UPDATE REQUERIMIENTO SET req_descripcion = @req_descripcion WHERE req_codigo = @cod_Nombre
END;

GO

--Listar requerimientos por propuesta
CREATE PROCEDURE M6_ListarRequerimientos
@cod_Nombre [varchar] (200)
AS
BEGIN
SELECT req_codigo, req_descripcion FROM REQUERIMIENTO WHERE fk_prop_req_id = @cod_Nombre
END;

GO

--Consultar propuesta por nombre
CREATE PROCEDURE M6_ConsultarPropuestaNombre
@propuesta_nombre [varchar] (50)
AS
BEGIN
SELECT prop_descripcion, prop_tipoDuracion, prop_duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas,
prop_fecha_inicio, prop_fecha_fin, prop_costo, fk_com_id FROM PROPUESTA WHERE prop_nombre = @propuesta_nombre
END;

GO

--Listar requerimientos por propuesta
CREATE PROCEDURE M6_ConsultarRequerimientoNombre
@reqnombre [varchar] (200)
AS
BEGIN
SELECT req_descripcion,fk_prop_req_id FROM REQUERIMIENTO WHERE req_codigo = @reqnombre
END;

GO

--Consultar todas las propuestas
CREATE PROCEDURE M6_ConsultarPropuestas
AS
BEGIN
SELECT prop_nombre,prop_descripcion, prop_tipoDuracion, prop_duracion, prop_acuerdo_pago, prop_estatus, prop_moneda, prop_cant_entregas,
prop_fecha_inicio, prop_fecha_fin, prop_costo, fk_com_id
FROM PROPUESTA
WHERE fk_com_id IN (select com_id from COMPANIA where com_status = 1)
END;
GO


--Eliminar Propuesta
CREATE PROCEDURE M6_EliminarPropuesta
@propuesta_nombre varchar(500)
AS
 BEGIN
    DELETE FROM REQUERIMIENTO WHERE fk_prop_req_id=@propuesta_nombre;
    DELETE FROM PROPUESTA WHERE prop_nombre=@propuesta_nombre;
 END;

GO

--Eliminar Requerimiento
CREATE PROCEDURE M6_EliminarRequerimiento
@cod_Nombre [varchar] (500)
AS
 BEGIN
    DELETE FROM REQUERIMIENTO WHERE req_codigo=@cod_Nombre;
 END;
GO

---ConsultarIdUltimoRequerimiento(Para pruebas) ----
CREATE PROCEDURE M6_ConsultarIdUltimoRequerimiento
AS
 BEGIN
     SELECT MAX(req_id) req_id FROM REQUERIMIENTO;
 end;
GO
---ConsultarNumeroPropuestas(Para pruebas) ----
CREATE PROCEDURE M6_ConsultarNumeroPropuestas
AS
 BEGIN
     SELECT COUNT(prop_id) prop_id FROM PROPUESTA;
 end;
GO
---ConsultarNumeroRequerimientos(Para pruebas) ----
CREATE PROCEDURE M6_ConsultarNumeroRequerimientos
AS
 BEGIN
     SELECT COUNT(req_id) req_id FROM REQUERIMIENTO;
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
    	INSERT INTO PROYECTO(proy_nombre,proy_codigo,proy_fecha_inicio,proy_fecha_est_fin,proy_costo,proy_descripcion,proy_realizacion,proy_estatus,proy_razon,proy_acuerdo_pago,fk_propuesta_id,fk_com_id,fk_gerente_id)
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
		FROM PROYECTO WHERE DAY(proy_fecha_inicio) = DAY(GETDATE()) and proy_estatus = 'En desarrollo' and proy_acuerdo_pago = 'Mensual';
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

--- StoredProsedure consultar nombre de una propuesta ----
CREATE PROCEDURE M7_ConsultarNombrePropuestaID

     @IdPropuestaPrpu int

AS
BEGIN
		SELECT prop_nombre
		FROM PROPUESTA, PROYECTO
		WHERE proyecto.fk_propuesta_id=PROPUESTA.prop_id and proy_id = @IdPropuestaPrpu;
	END
GO

--- StoredProsedure consultar el id del ultimo proyecto agregado ----
CREATE PROCEDURE M7_ConsultarMaxIdProyecto

AS
	BEGIN
		SELECT max(proy_id)as proy_id
		FROM PROYECTO;
	END
GO

---ConsultarNumeroProyectos(Para pruebas) ----
CREATE PROCEDURE M7_ConsultarNumeroProyectos
AS
 BEGIN
     SELECT COUNT(proy_id) proy_id FROM PROYECTO;
 end;
GO

--- StoredProsedure borrar proyecto ----
CREATE PROCEDURE M7_BorrarProyecto
	@proy_id int
AS
	BEGIN
		DELETE FROM PROYECTO
 		WHERE proy_id = @proy_id;
	END;
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
	@fecha_ultimo_pago date,
	@monto_total numeric(12,3),
	@monto_restante numeric(12,3),
	@tipo_moneda [varchar](100),
	@descripcion [varchar](500),
	@estatus int,
	@id_proyecto int,
	@id_compania int

AS
	BEGIN
    	INSERT INTO FACTURA(fac_fecha_emision, fac_fecha_ultimo_pago, fac_monto_total, fac_monto_restante, fac_tipo_moneda, fac_descripcion, fac_estatus, fk_proy_id, fk_compania_id)
		VALUES(@fecha_emision, @fecha_ultimo_pago, @monto_total, @monto_restante, @tipo_moneda, @descripcion, @estatus, @id_proyecto, @id_compania);
 	END;
GO

---- StoredProcedure Eliminar Factura ----
CREATE PROCEDURE M8_EliminarFactura
	@id_Factura int

AS
	BEGIN
		DELETE FROM FACTURA WHERE fac_id = @id_Factura;
	END;
GO

---- StoredProcedure Consultar Factura ----
CREATE PROCEDURE M8_ConsultarFactura
	@id_Factura int

AS
	BEGIN
		SELECT fac_id as fac_id, fac_fecha_emision AS fac_fecha_emision, fac_fecha_ultimo_pago AS fac_fecha_ultimo_pago, fac_monto_total AS fac_monto_total,
			fac_monto_restante AS fac_monto_restante, fac_tipo_moneda AS fac_tipo_moneda, fac_descripcion AS fac_descripcion, fac_estatus AS fac_estatus, fk_proy_id AS fk_proy_id, fk_compania_id AS fk_compania_id
		FROM FACTURA WHERE fac_id = @id_Factura;
	END
GO

---- StoredProcedure Consultar Facturas ----
CREATE PROCEDURE M8_ConsultarFacturas

AS
	BEGIN
		SELECT fac_id as fac_id, fac_fecha_emision AS fac_fecha_emision, fac_fecha_ultimo_pago AS fac_fecha_ultimo_pago, fac_monto_total AS fac_monto_total,
			fac_monto_restante AS fac_monto_restante, fac_tipo_moneda AS fac_tipo_moneda, fac_descripcion AS fac_descripcion, fac_estatus AS fac_estatus, fk_proy_id AS fk_proy_id, fk_compania_id AS fk_compania_id
		FROM FACTURA;
	END
GO

---- StoredProcedure Consultar Nombre Compañia Factura ----
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
	@fecha_ultimo_pago date,
	@monto_total numeric(12,3),
	@monto_restante numeric(12,3),
	@tipo_moneda [varchar](100),
	@descripcion [varchar](500),
	@estatus int,
	@id_proyecto int,
	@id_compania int

AS
 	BEGIN
    	UPDATE FACTURA SET fac_fecha_emision = @fecha_emision, fac_fecha_ultimo_pago = @fecha_ultimo_pago, fac_monto_total = @monto_total, fac_monto_restante = @monto_restante,
    		fac_tipo_moneda = @tipo_moneda, fac_descripcion = @descripcion, fac_estatus = @estatus, fk_proy_id = @id_proyecto, fk_compania_id = @id_compania
    	WHERE fac_id = @id_Factura;
 	END;
GO

---- StoredProcedure Anular Factura ----
CREATE PROCEDURE M8_AnularFactura
	@id_Factura int,
	@fecha_emision date,
	@fecha_ultimo_pago date,
	@monto_total numeric(12,3),
	@monto_restante numeric(12,3),
	@tipo_moneda [varchar](100),
	@descripcion [varchar](500),
	@estatus int,
	@id_proyecto int,
	@id_compania int

AS
	BEGIN
		UPDATE FACTURA SET fac_estatus = 2
    	WHERE fac_id = @id_Factura;
	END
GO

---- StoredProcedure Consultar Facturas por ID de Compañia ----
CREATE PROCEDURE M8_ConsultarFacturasCompania
	@id_compania int

AS
	BEGIN
		SELECT fac_id as fac_id, fac_fecha_emision AS fac_fecha_emision, fac_fecha_ultimo_pago AS fac_fecha_ultimo_pago, fac_monto_total AS fac_monto_total,
			fac_monto_restante AS fac_monto_restante, fac_tipo_moneda AS fac_tipo_moneda, fac_descripcion AS fac_descripcion, fac_estatus AS fac_estatus, fk_proy_id AS fk_proy_id, fk_compania_id AS fk_compania_id
			FROM FACTURA, COMPANIA
			WHERE com_id = @id_compania
			AND fac_estatus = 0
			AND fk_compania_id = com_id;
	END
GO

---- StoredProcedure Consultar Facturas Pagadas por ID de Compañia ----
CREATE PROCEDURE M8_ConsultarFacturasPagadasCompania
	@id_compania int

AS
	BEGIN
		SELECT fac_id as fac_id, fac_fecha_emision AS fac_fecha_emision, fac_fecha_ultimo_pago AS fac_fecha_ultimo_pago, fac_monto_total AS fac_monto_total,
			fac_monto_restante AS fac_monto_restante, fac_tipo_moneda AS fac_tipo_moneda, fac_descripcion AS fac_descripcion, fac_estatus AS fac_estatus, fk_proy_id AS fk_proy_id, fk_compania_id AS fk_compania_id
			FROM FACTURA, COMPANIA
			WHERE com_id = @id_compania
			AND fac_estatus = 1
			AND fk_compania_id = com_id;
	END
GO

---- StoredProcedure Facturas por Pagar ----
CREATE PROCEDURE M8_VerificarFacturasParaPagar
	@id_Factura int

AS
	BEGIN
		IF (SELECT DATEDIFF(day,fac_fecha_ultimo_pago,CONVERT(DATE,GETDATE())) FROM FACTURA WHERE fac_id = @id_Factura) >= 31
			UPDATE FACTURA SET fac_estatus = 2 WHERE fac_id = @id_Factura;
	END
GO

---- StoredProcedure Monto Restante de una Factura ----
CREATE PROCEDURE M8_ConsultarMontoRestanteFactura
	@id_Factura int

AS
	BEGIN
		SELECT fac_monto_restante AS fac_monto_restante
		FROM FACTURA WHERE fac_id = @id_Factura;
	END
GO

---- StoredProcedure Verificar si ya existe una Factura de una Fecha, Proyecto y Compañia ----
CREATE PROCEDURE M8_VerificarFacturaExistente
	@fecha_emision date,
	@id_proyecto int,
	@id_compania int

AS
	BEGIN
		SELECT fac_fecha_emision AS fac_fecha_emision, fk_proy_id AS fk_proy_id, fk_compania_id AS fk_compania_id
		FROM FACTURA
		WHERE fac_fecha_emision = @fecha_emision
		AND fk_proy_id = @id_proyecto
		AND fk_compania_id = @id_compania;
	END;
GO


-----------------------------------
------Fin Stored Procedure M8------
-----------------------------------


-----------------------------------
--------Stored Procedure M9--------
-----------------------------------

---- StoredProcedure Agregar Pago ----

CREATE PROCEDURE M9_AgregarPago
    @moneda [varchar] (50),
	@monto int,
	@forma [varchar](20),
	@cod int,
	--@fecha date,
	@id_factura int

AS
 BEGIN
    INSERT INTO PAGO(pag_monto, pag_moneda,pag_forma, pag_cod, pag_fecha, fk_fac_id)
	VALUES(@monto, @moneda, @forma, @cod, GETDATE(), @id_factura);
 END;
 GO

---- StoredProcedure cambiar status factura ----
CREATE PROCEDURE M9_CambioStatus
	@id_factura int,
	@status int
AS
 BEGIN
    update factura set fac_estatus = @status
    where fac_id = @id_factura;
 end;

GO

-----------------------------------
------Fin Stored Procedure M9------
-----------------------------------

CREATE PROCEDURE M9_EliminarPago
@cod int

AS
 BEGIN
	DELETE FROM PAGO 
	WHERE pag_cod = @cod
	END;
GO


-----------------------------------
--------Stored Procedure M9--------
-----------------------------------


---- StoredProcedure CONSULTAR Pago ----

CREATE PROCEDURE [dbo].[M9_ConsultarPago]
	@id_Factura int

AS
	BEGIN
		SELECT pag_monto as pag_monto, pag_fecha AS pag_fecha, pag_forma AS pag_forma, pag_cod AS pag_cod,
			pag_moneda AS pag_moneda
		FROM PAGO WHERE fk_fac_id = @id_Factura;
	END;

GO

-----------------------------------
------Fin Stored Procedure M9------
-----------------------------------

-----------------------------------
--------Stored Procedure M9--------
-----------------------------------


---- StoredProcedure HISTORICO Pago ----
CREATE PROCEDURE M9_historico_pago_por_compania
@id_compania int
AS
	BEGIN
		SELECT  fac_id, fac_fecha_emision,pag_fecha,pag_monto,pag_moneda, pag_cod
                FROM factura, pago
				WHERE fk_fac_id=fac_id AND fk_compania_id=@id_compania

	END;
GO

-----------------------------------
------Fin Stored Procedure M9------
-----------------------------------
-----------------------------------
--------Stored Procedure M10--------
-----------------------------------
---- StoredProcedure Agregar Empleado ----
CREATE PROCEDURE [dbo].[M10_AgregarEmpleado]
	@pNombre [varchar](150),
	@sNombre [varchar](150),
	@pApellido [varchar](150),
	@sApellido [varchar](150),
	@genero[varchar](50),
	@cedula int,
	@fechaNacimiento Date,
	@activo [varchar](50),
	@nivelEstudio [varchar](50),
	@correo[varchar](150),
	-----------------------empleado
	@cargo [varchar](150),
	-----------------------cargo
	@fechContrato Date,
	@modalidad [varchar](150),
	@sueldo numeric(6,3),
	---------------------------cargo empleado
	@estado [varchar](150),
	@ciudad [varchar](150),
	@direccion[varchar](150)
	---------------------------lugar direccion
AS
 BEGIN
	DECLARE @IdLugarPadre int;
	DECLARE @maxIdLugar int;
	DECLARE @maxIdEmplado int;
	DECLARE @cargoId int;

	SET @IdLugarPadre = (SELECT lug_dir_id
					  FROM LUGAR_DIRECCION
					  WHERE lug_dir_nombre =@estado);

	SET @maxIdLugar =(SELECT MAX(lug_dir_id)+1
				 FROM LUGAR_DIRECCION);

    INSERT INTO LUGAR_DIRECCION VALUES (@maxIdLugar, @ciudad,'Ciudad',@IdLugarPadre);
    INSERT INTO LUGAR_DIRECCION VALUES ((@maxIdLugar+1), @direccion,'Direccion',@maxIdLugar);

    SET @maxIdEmplado =(SELECT MAX(emp_num_ficha)+1
				 FROM EMPLEADO);

	INSERT INTO EMPLEADO VALUES (@maxIdEmplado,@cedula,@genero,@pNombre,@sNombre,@pApellido,@sApellido,
								 @fechaNacimiento, @nivelEstudio, @correo, @activo, @maxIdLugar);

	SET @cargoId = (SELECT car_id
					FROM CARGO
					WHERE car_nombre=@cargo);

	INSERT INTO CARGO_EMPLEADO VALUES (@fechContrato,null,@modalidad,@sueldo,@cargoId,@maxIdEmplado);

 END;
 GO

--Consultar Detalle empleado
USE [BDTangerine]
GO
/****** Object:  StoredProcedure [dbo].[M10_DetallarEmpleado]    Script Date: 05/15/2016 16:18:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE M10_DetallarEmpleado
	@id int
AS
	BEGIN
		SELECT Employee.emp_num_ficha AS emp_num_ficha, Employee.emp_cedula AS emp_cedula,
			   Employee.emp_p_nombre AS emp_p_nombre, Employee.emp_s_nombre AS emp_s_nombre,
			   Employee.emp_p_apellido AS emp_p_apellido,
			   Employee.emp_s_apellido AS emp_s_apellido,
			   Employee.emp_genero as emp_genero,
			   CAST(Employee.emp_fecha_nac AS DATE )AS emp_fecha_nac,
			   (YEAR (getdate()) - YEAR(Employee.emp_fecha_nac)) AS Edad,
			   Employee.emp_nivel_estudio AS emp_nivel_estudio ,
			   Employee.emp_email AS emp_email,
			   Employee.emp_activo AS emp_activo,
			   Employee.fk_lug_dir_id AS fk_lug_dir_id,
			   Job.car_nombre AS car_nombre,
			   Job.car_descripcion AS car_descripcion,
			   CAST(EmployeeJob.car_emp_sueldo AS VARCHAR) AS car_emp_sueldo,
			   CAST(EmployeeJob.car_emp_fecha_cont AS VARCHAR)AS car_emp_fecha_cont,
			   ISNULL(CAST(EmployeeJob.car_emp_fecha_fin AS VARCHAR),'Actualidad') AS  car_emp_fecha_fin,
			   (SELECT (P.lug_dir_nombre+', '+E.lug_dir_nombre+', '+
						C.lug_dir_nombre+', '+D.lug_dir_nombre) AS EmpDireccion
			   FROM LUGAR_DIRECCION P, LUGAR_DIRECCION E, LUGAR_DIRECCION C,
					  LUGAR_DIRECCION D, EMPLEADO Em
			   WHERE  Em.fk_lug_dir_id = D.lug_dir_id
					   and (D.fk_lug_dir_id=C.lug_dir_id
							and C.fk_lug_dir_id=E.lug_dir_id
							and E.fk_lug_dir_id=P.lug_dir_id)
					   and Em.emp_num_ficha=@id) AS EmpDireccion
		FROM EMPLEADO Employee, CARGO Job, CARGO_EMPLEADO EmployeeJob
		WHERE Job.car_id=EmployeeJob.fk_car_id
			  and Employee.emp_num_ficha=EmployeeJob.fk_emp_num_ficha
			  and EmployeeJob.car_emp_fecha_fin IS NULL
			  and Employee.emp_num_ficha=@id;
	END
go

CREATE PROCEDURE M10_ConsultarGerentes
		@prueba INT
AS
	BEGIN
		select * from EMPLEADO e,CARGO_EMPLEADO ce,CARGO c where
		e.emp_activo = 'Activo' and c.car_nombre = 'Gerente' and
		e.emp_num_ficha = ce.fk_emp_num_ficha and ce.fk_car_id = c.car_id;
	END
GO

CREATE PROCEDURE M10_ConsultarProgramadores
		@prueba INT
AS
	BEGIN
		select * from EMPLEADO e,CARGO_EMPLEADO ce,CARGO c where
		e.emp_activo = 'Activo' and c.car_nombre = 'Programador' and
		e.emp_num_ficha = ce.fk_emp_num_ficha and ce.fk_car_id = c.car_id;
	END
GO

CREATE PROCEDURE M10_LLenarSelectPaises
		@tipo [varchar](50)
AS
	BEGIN
		SELECT Pais.lug_dir_id as lug_dir_id ,
			   pais.lug_dir_nombre as lug_dir_nombre
		FROM LUGAR_DIRECCION Pais
		WHERE pais.lug_dir_tipo=@tipo;
	END
GO

CREATE PROCEDURE M10_LLenarSelectEstados
	@lugar [varchar](100),
	@tipo [varchar](100)
AS
 BEGIN
    SELECT Estado.lug_dir_id as lug_dir_id ,
	   Estado.lug_dir_nombre as lug_dir_nombre
	FROM LUGAR_DIRECCION Estado, LUGAR_DIRECCION Pais
	WHERE Pais.lug_dir_id=Estado.fk_lug_dir_id
			and Estado.lug_dir_tipo=@tipo
			and Estado.fk_lug_dir_id =(	SELECT lug_dir_id
										FROM LUGAR_DIRECCION
										WHERE lug_dir_nombre=@lugar);
 END
GO

CREATE PROCEDURE M10_LlenarSelectCargo
@id int
AS
BEGIN
	SELECT c.car_id as car_id, c.car_nombre as car_nombre,
	   c.car_descripcion as car_descripcion
	FROM CARGO c
END
GO

CREATE PROCEDURE M10_ConsultarEmpleado
		@param INT
AS
	BEGIN
		SELECT  Employee.emp_num_ficha as emp_num_ficha, Employee.emp_p_nombre as emp_p_nombre,
				Employee.emp_s_nombre as emp_s_nombre,Employee.emp_p_apellido as emp_p_apellido,
				Employee.emp_s_apellido as emp_s_apellido,Employee.emp_cedula as emp_cedula,
				Employee.emp_fecha_nac as emp_fecha_nac,Employee.emp_activo as emp_activo,
				Employee.emp_email as emp_email, Employee.emp_genero as emp_genero,
				Employee.emp_nivel_estudio as emp_nivel_estudio,
				Job.car_nombre as car_nombre, Job.car_descripcion as car_descripcion,
				JobEmployee.car_emp_fecha_cont as car_emp_fecha_cont,
				JobEmployee.car_emp_modalidad as car_emp_modalidad,
				JobEmployee.car_emp_sueldo as car_emp_sueldo
			FROM EMPLEADO Employee, CARGO_EMPLEADO JobEmployee, CARGO job
		WHERE Employee.emp_num_ficha=JobEmployee.fk_emp_num_ficha
			  and JobEmployee.fk_car_id=Job.car_id
	END
GO

CREATE PROCEDURE M10_CambiarEstatus
		@ficha INT
AS
	BEGIN
		update EMPLEADO
		set emp_activo = case
							when emp_activo = 'Activo' then 'Inactivo'
							else 'Activo'
						 end
	    where emp_num_ficha = @ficha;

	END
GO

CREATE PROCEDURE M1_ObtenerCorreoUsuario
		@usuario [varchar](100),
		@correo [varchar](100)
AS
	BEGIN
		select u.usu_usuario as usuario, u.usu_activo as usu_activo, e.emp_email as emp_email,u.usu_id as usu_id
		from USUARIO u, EMPLEADO e
		where u.fk_emp_num_ficha = e.emp_num_ficha and
		@usuario = u.usu_usuario and e.emp_email = @correo
	END
GO
-----------------------------------
------Fin Stored Procedure M10-----
-----------------------------------
