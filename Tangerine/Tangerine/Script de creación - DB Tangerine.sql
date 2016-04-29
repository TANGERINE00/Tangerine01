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
	fk_emp_num_ficha int not null,

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
	cli_pot_potencial varchar(20) not null,

	constraint pk_cli_pot primary key
	(
		cli_pot_id
	)
);

create table COMPANIA
(
	com_id int not null,
	com_nombre varchar(20) not null,
	com_rif varchar(20) not null,
	com_email varchar(50) not null,
	com_acronimo varchar(20) not null,
	com_fecha_registro date not null,
	fk_lug_dir_id int not null,
	fk_cli_pot_id int,

	constraint pk_com primary key
	(
		com_id
	),

	constraint fk_lug_dir_com foreign key
	(
		fk_lug_dir_id
	) references LUGAR_DIRECCION(lug_dir_id),

	constraint fk_cli_pot_com foreign key
	(
		fk_cli_pot_id
	) references CLIENTE_POTENCIAL(cli_pot_id)
);

create table TELEFONO 
(
	tel_id int not null,
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
	prop_nombre varchar(50) not null,
	prop_descripcion varchar(255) not null,
	prop_duracion varchar(200) not null,
	prop_fecha_emision date not null,
	prop_fecha_aprob date not null,
	prop_acuerdo_pago varchar(200) not null,
	prop_estatus varchar(20) not null,
	prop_moneda varchar(40) not null,
	prop_cant_entregas int,
	prop_fecha_inicio date not null,
	prop_fecha_fin date,
	fk_com_id int not null,

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
	proy_id int not null,
	proy_nombre varchar(50) not null,
	proy_codigo int not null,
	proy_fecha_inicio date not null,
	proy_fecha_est_fin date not null,
	proy_descripcion varchar(255) not null,
	proy_costo int not null,
	proy_realizacion varchar(100) not null,
	proy_estatus varchar(20) not null, 
	fk_com_id int not null,

	constraint pk_proy primary key
	(
		proy_id
	),

	constraint fk_com_proy foreign key
	(
		fk_com_id
	) references COMPANIA(com_id)
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
	fac_id int not null,
	fac_fecha_emision date not null,
	fac_monto_total numeric(12,3) not null,
	fac_monto_restante numeric(12,3) not null,
	fk_proy_id int not null,

	constraint pk_fac primary key
	(
		fac_id
	),

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

create table ROL_MENU
(
	fk_rol_id int not null,
	fk_men_id int not null,

	constraint pk_rol_men primary key
	(
		fk_rol_id,
		fk_men_id
	),

	constraint fk_rol_rol_men foreign key
	(
		fk_rol_id
	) references ROL(rol_id),

	constraint fk_men_rol_men foreign key
	(
		fk_men_id
	) references MENU(men_id)
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