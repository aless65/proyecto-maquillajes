CREATE DATABASE Maquillaje

GO 
USE Maquillaje
GO

CREATE SCHEMA gral
GO
CREATE SCHEMA acce
GO
CREATE SCHEMA maqu


--************CREACION TABLA ROLES******************--
CREATE TABLE acce.tbRoles(
	role_Id					INT IDENTITY,
	role_Nombre				NVARCHAR(100) NOT NULL,
	role_UsuCreacion		INT NOT NULL,
	role_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_role_FechaCreacion DEFAULT(GETDATE()),
	role_UsuModificacion	INT,
	role_FechaModificacion	DATETIME,
	role_Estado				BIT NOT NULL CONSTRAINT DF_role_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbRoles_role_Id PRIMARY KEY(role_Id)
);
GO

--aaaaaaaaaaamaki

--***********CREACION TABLA PANTALLAS*****************---
CREATE TABLE acce.tbPantallas(
	pant_Id					INT IDENTITY,
	pant_Nombre				NVARCHAR(100) NOT NULL,
	pant_Url				NVARCHAR(300) NOT NULL,
	pant_Menu				NVARCHAR(300) NOT NULL,
	pant_HtmlId				NVARCHAR(80) NOT NULL,
	pant_UsuCreacion		INT NOT NULL,
	pant_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_pant_FechaCreacion DEFAULT(GETDATE()),
	pant_UsuModificacion	INT,
	pant_FechaModificacion	DATETIME,
	pant_Estado				BIT NOT NULL CONSTRAINT DF_pant_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbPantallas_pant_Id PRIMARY KEY(pant_Id)
);
GO

INSERT INTO acce.tbPantallas(pant_Nombre, pant_Url, pant_Menu, pant_HtmlId, pant_UsuCreacion)
VALUES ('Usuarios', '/Usuario/Listado', 'Seguridad', 'usuariosItem', 1),
       ('Departamentos', '/Departamento/Listado', 'General', 'departamentosItem', 1),
	   ('Municipios', '/Municipio/Listado', 'General', 'municipiosItem', 1),
	   ('Estados Civiles', '/EstadoCivil/Listado', 'General', 'estadosItem', 1),
	   ('Categorías', '/Categorias/Listado', 'Maquillaje', 'categoriasItem', 1),
	   ('Clientes', '/Clientes/Listado', 'Maquillaje', 'clientesItem', 1),
	   ('Empleados', '/Empleados/Listado','Maquillaje', 'empleadosItem', 1),
	   ('Facturas', '/Facturas/Listado', 'Maquillaje', 'facturasItem', 1),
	   ('Métodos de Pago', '/MetodosPago/Listado', 'Maquillaje', 'metodosItem', 1),
	   ('Productos', '/Producto/Listado', 'Maquillaje', 'productosItem', 1),
	   ('Proveedores', '/Proveedor/Listado', 'Maquillaje', 'proveedoresItem', 1),
	   ('Sucursales', '/Sucursal/Listado', 'Maquillaje', 'sucursalesItem', 1)


--***********CREACION TABLA ROLES/PANTALLA*****************---
CREATE TABLE acce.tbPantallasPorRoles(
	pantrole_Id					INT IDENTITY,
	role_Id						INT NOT NULL,
	pant_Id						INT NOT NULL,
	pantrole_UsuCreacion		INT NOT NULL,
	pantrole_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_pantrole_FechaCreacion DEFAULT(GETDATE()),
	pantrole_UsuModificacion	INT,
	pantrole_FechaModificacion	DATETIME,
	pantrole_Estado				BIT NOT NULL CONSTRAINT DF_pantrole_Estado DEFAULT(1)
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES acce.tbRoles(role_Id),
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbPantallas_pant_Id FOREIGN KEY(pant_Id)	REFERENCES acce.tbPantallas(pant_Id),
	CONSTRAINT PK_acce_tbPantallasPorRoles_pantrole_Id PRIMARY KEY(pantrole_Id),
);
GO


--****************CREACION TABLA USUARIOS****************--
CREATE TABLE acce.tbUsuarios(
	user_Id 				INT IDENTITY(1,1),
	user_NombreUsuario		NVARCHAR(100) NOT NULL,
	user_Contrasena			NVARCHAR(MAX) NOT NULL,
	user_EsAdmin			BIT,
	role_Id					INT,
	empe_Id					INT,
	user_UsuCreacion		INT,
	user_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_user_FechaCreacion DEFAULT(GETDATE()),
	user_UsuModificacion	INT,
	user_FechaModificacion	DATETIME,
	user_Estado				BIT NOT NULL CONSTRAINT DF_user_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbUsuarios_user_Id  PRIMARY KEY(user_Id),
);

--********* PROCEDIMIENTO INSERTAR USUARIOS ADMIN**************--
GO
CREATE OR ALTER PROCEDURE acce.UDP_InsertUsuario
	@user_NombreUsuario NVARCHAR(100),	@user_Contrasena NVARCHAR(200),
	@user_EsAdmin BIT,					@role_Id INT, 
	@empe_Id INT										
AS
BEGIN
	DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @user_Contrasena));

	INSERT acce.tbUsuarios(user_NombreUsuario, user_Contrasena, user_EsAdmin, role_Id, empe_Id, user_UsuCreacion)
	VALUES(@user_NombreUsuario, @password, @user_EsAdmin, @role_Id, @empe_Id, 1);
END;


GO
EXEC acce.UDP_InsertUsuario 'aless65', 'bonjour', 1, NULL, 1;


--********* ALTERAR TABLA ROLES **************--
--********* AGREGAR CAMPOS AUDITORIA**************--
GO
ALTER TABLE acce.tbRoles
ADD CONSTRAINT FK_acce_tbRoles_acce_tbUsuarios_role_UsuCreacion_user_Id 	FOREIGN KEY(role_UsuCreacion) REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_acce_tbRoles_acce_tbUsuarios_role_UsuModificacion_user_Id 	FOREIGN KEY(role_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id);




GO
INSERT INTO acce.tbRoles(role_Nombre, role_UsuCreacion)
VALUES ('Vendedor', 1)


--********* ALTERAR TABLA USUARIOS **************--
--********* AGREGAR CAMPO ROL, AUDITORIA**************--
GO
ALTER TABLE [acce].[tbUsuarios]
ADD CONSTRAINT FK_acce_tbUsuarios_acce_tbUsuarios_user_UsuCreacion_user_Id  FOREIGN KEY(user_UsuCreacion) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbUsuarios_acce_tbUsuarios_user_UsuModificacion_user_Id  FOREIGN KEY(user_UsuModificacion) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbUsuarios_acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES acce.tbRoles(role_Id)

GO 
ALTER TABLE [acce].[tbPantallasPorRoles]
ADD CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbUsuarios_pantrole_UsuCreacion_user_Id FOREIGN KEY([pantrole_UsuCreacion]) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbPantallasPorRoles_acce_tbUsuarios_pantrole_UsuModificacion_user_Id FOREIGN KEY([pantrole_UsuModificacion]) REFERENCES acce.tbUsuarios([user_Id])

--*******************************************--
--********TABLA DEPARTAMENTO****************---
GO
CREATE TABLE [gral].[tbDepartamentos](
	depa_Id  					CHAR(2) NOT NULL,
	depa_Nombre 				NVARCHAR(100) NOT NULL,
	depa_UsuCreacion			INT NOT NULL,
	depa_FechaCreacion			DATETIME NOT NULL CONSTRAINT DF_depa_FechaCreacion DEFAULT(GETDATE()),
	depa_UsuModificacion		INT,
	depa_FechaModificacion		DATETIME,
	depa_Estado					BIT NOT NULL CONSTRAINT DF_depa_Estado DEFAULT(1)
	CONSTRAINT PK_gral_tbDepartamentos_depa_Id 									PRIMARY KEY(depa_Id),
	CONSTRAINT FK_gral_tbDepartamentos_acce_tbUsuarios_depa_UsuCreacion_user_Id  		FOREIGN KEY(depa_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_gral_tbDepartamentos_acce_tbUsuarios_depa_UsuModificacion_user_Id  	FOREIGN KEY(depa_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
);


--********TABLA MUNICIPIO****************---
GO
CREATE TABLE gral.tbMunicipios(
	muni_id					CHAR(4)	NOT NULL,
	muni_Nombre				NVARCHAR(80) NOT NULL,
	depa_Id					CHAR(2)	NOT NULL,
	muni_UsuCreacion		INT	NOT NULL,
	muni_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_muni_FechaCreacion DEFAULT(GETDATE()),
	muni_UsuModificacion	INT,
	muni_FechaModificacion	DATETIME,
	muni_Estado				BIT	NOT NULL CONSTRAINT DF_muni_Estado DEFAULT(1)
	CONSTRAINT PK_gral_tbMunicipios_muni_Id 										PRIMARY KEY(muni_Id),
	CONSTRAINT FK_gral_tbMunicipios_gral_tbDepartamentos_depa_Id 						FOREIGN KEY (depa_Id) 						REFERENCES gral.tbDepartamentos(depa_Id),
	CONSTRAINT FK_gral_tbMunicipios_acce_tbUsuarios_muni_UsuCreacion_user_Id  		FOREIGN KEY(muni_UsuCreacion) 				REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_gral_tbMunicipios_acce_tbUsuarios_muni_UsuModificacion_user_Id  	FOREIGN KEY(muni_UsuModificacion) 			REFERENCES acce.tbUsuarios(user_Id)
);


CREATE TABLE maqu.tbCategorias
(
	cate_Id						INT IDENTITY,
	cate_Nombre					NVARCHAR(100) NOT NULL,
	cate_UsuCreacion			INT NOT NULL,
	cate_FechaCreacion			DATETIME NOT NULL CONSTRAINT DF_cate_FechaCreacion DEFAULT(GETDATE()),
	cate_UsuModificacion		INT,
	cate_FechaModificacion		DATETIME,
	cate_Estado					BIT NOT NULL CONSTRAINT DF_cate_Estado DEFAULT(1)

	CONSTRAINT PK_maqu_tbCategorias_cate_Id 										    PRIMARY KEY(cate_Id),
	CONSTRAINT FK_maqu_tbCategorias_acce_tbUsuarios_cate_UsuCreacion_user_Id  			FOREIGN KEY(cate_UsuCreacion) 			REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbCategorias_acce_tbUsuarios_cate_UsuModificacion_user_Id  		FOREIGN KEY(cate_UsuModificacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT UQ_maqu_tbCategorias_cate_Nombre UNIQUE(cate_Nombre)
);

CREATE TABLE maqu.tbMetodosPago
(
	meto_Id					INT IDENTITY,
	meto_Nombre				NVARCHAR(100)NOT NULL,
	meto_UsuCreacion		INT NOT NULL,
	meto_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_meto_FechaCreacion DEFAULT(GETDATE()),
	meto_UsuModificacion	INT,
	meto_FechaModificacion	DATETIME,
	meto_Estado				BIT NOT NULL CONSTRAINT DF_meto_Estado DEFAULT(1)

	CONSTRAINT PK_maqu_tbMetodosPago_meto_Id 													PRIMARY KEY(meto_Id),
	CONSTRAINT FK_maqu_tbMetodosPago_acce_tbUsuarios_meto_UsuCreacion_user_Id  				FOREIGN KEY(meto_UsuCreacion) 			REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbMetodosPago_acce_tbUsuarios_meto_UsuModificacion_user_Id  			FOREIGN KEY(meto_UsuModificacion) 		REFERENCES acce.tbUsuarios(user_Id)
);

CREATE TABLE gral.tbEstadosCiviles
(
	estacivi_Id					INT IDENTITY,
	estacivi_Nombre				NVARCHAR(50),
	estacivi_UsuCreacion			INT NOT NULL,
	estacivi_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_estacivi_FechaCreacion DEFAULT(GETDATE()),
	estacivi_UsuModificacion		INT,
	estacivi_FechaModificacion	DATETIME,
	estacivi_Estado				BIT NOT NULL CONSTRAINT DF_estacivi_Estado DEFAULT(1)
   
   CONSTRAINT PK_gral_tbEstadosCiviles 												PRIMARY KEY(estacivi_Id),
   CONSTRAINT FK_gral_tbEstadosCiviles_acce_tbUsuarios_estacivi_UsuCreacion_user_Id  	FOREIGN KEY(estacivi_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
   CONSTRAINT FK_gral_tbEstadosCiviles_acce_tbUsuarios_estacivi_UsuModificacion_user_Id  FOREIGN KEY(estacivi_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
);

CREATE TABLE maqu.tbProveedores
(
	prov_Id						INT IDENTITY,
	prov_Nombre					NVARCHAR(200) NOT NULL,
	prov_CorreoElectronico      NVARCHAR(200) NOT NULL,
	prov_Telefono				NVARCHAR(15)NOT NULL,
	prov_UsuCreacion			INT NOT NULL,
	prov_FechaCreacion			DATETIME NOT NULL CONSTRAINT DF_prov_FechaCreacion DEFAULT(GETDATE()),
	prov_UsuModificacion		INT,
	prov_FechaModificacion		DATETIME,
	prov_Estado					BIT NOT NULL CONSTRAINT DF_prov_Estado DEFAULT(1)

	CONSTRAINT PK_maqu_tbProveedores_prov_Id												PRIMARY KEY(prov_Id),
	CONSTRAINT FK_maqu_tbProveedores_acce_tbUsuarios_prov_UsuCreacion_user_Id  			FOREIGN KEY(prov_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT  FK_maqu_tbProveedores_acce_tbUsuarios_prov_UsuModificacion_user_Id 		FOREIGN KEY(prov_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
);
--***************TABLA SucursalES*************************--
GO
CREATE TABLE maqu.tbSucursales(
    sucu_Id                             INT IDENTITY(1,1), 
    sucu_Descripcion                    NVARCHAR(200) NOT NULL,
    muni_Id                             CHAR(4),
	sucu_DireccionExacta				NVARCHAR(500) NOT NULL,
    sucu_FechaCreacion					DATETIME NOT NULL DEFAULT GETDATE(),
    sucu_UsuCreacion					INT not null,
    sucu_FechaModificacion				DATETIME,
    sucu_UsuModificacion				INT,
    sucu_Estado							BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_maqu_tbSucursales_sucu_Id PRIMARY KEY(sucu_Id),
	CONSTRAINT FK_maqu_gral_tbSucursales_muni_Id FOREIGN KEY (muni_Id) REFERENCES gral.tbMunicipios (muni_Id),
	CONSTRAINT FK_maqu_acce_tbSucursales_user_Id FOREIGN KEY (sucu_UsuCreacion) REFERENCES acce.tbUsuarios (user_id)
);

--********TABLA EMPLEADOS****************---
GO
CREATE TABLE maqu.tbEmpleados(
	empe_Id						INT IDENTITY(1,1),
	empe_Nombres				NVARCHAR(100)	NOT NULL,
	empe_Apellidos				NVARCHAR(100)	NOT NULL,
	empe_Identidad				VARCHAR(13)		NOT NULL,
	empe_FechaNacimiento		DATE			NOT NULL,
	empe_Sexo					CHAR(1)			NOT NULL,
	estacivi_Id					INT				NOT NULL,
	muni_Id						CHAR(4)			NOT NULL,
	empe_Direccion				NVARCHAR(250)	NOT NULL,
	empe_Telefono				NVARCHAR(15)	NOT NULL,
	empe_CorreoElectronico		NVARCHAR(200)	NOT NULL,
	sucu_Id						INT				NOT NULL,
	empe_UsuCreacion			INT				NOT NULL,
	empe_FechaCreacion			DATETIME		NOT NULL CONSTRAINT DF_empe_FechaCreacion DEFAULT(GETDATE()),
	empe_UsuModificacion		INT,
	empe_FechaModificacion		DATETIME,
	empe_Estado					BIT NOT NULL CONSTRAINT DF_empe_Estado DEFAULT(1),
	
	CONSTRAINT PK_maqu_tbEmpleados_empe_Id 										PRIMARY KEY(empe_Id),
	CONSTRAINT CK_maqu_tbEmpleados_empe_Sexo									CHECK(empe_sexo IN ('F', 'M')),
	CONSTRAINT FK_maqu_tbEmpleados_gral_tbEstadosCiviles_estacivi_Id			FOREIGN KEY(estacivi_Id)					REFERENCES gral.tbEstadosCiviles(estacivi_Id),			
	CONSTRAINT FK_maqu_tbEmpleados_gral_tbMunicipios_muni_Id					FOREIGN KEY(muni_Id)						REFERENCES gral.tbMunicipios(muni_Id),
	CONSTRAINT FK_maqu_tbEmpleados_acce_tbUsuarios_UserCreate					FOREIGN KEY(empe_UsuCreacion)				REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbEmpleados_acce_tbUsuarios_UserUpdate					FOREIGN KEY(empe_UsuModificacion)			REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbEmpleados_maqu_tbSucursales_sucu_Id					FOREIGN KEY(sucu_Id)						REFERENCES maqu.tbSucursales(sucu_Id)		
);

--********TABLA Clientes****************---
CREATE TABLE maqu.tbClientes
(
	clie_Id						INT IDENTITY,
	clie_Nombres					NVARCHAR(300) NOT NULL,
	clie_Apellidos				NVARCHAR(300) NOT NULL,
	clie_Identidad				VARCHAR(13)	  NOT NULL,
	clie_Sexo					CHAR NOT NULL,
	muni_Id						CHAR(4) NOT NULL,
	clie_DireccionExacta			NVARCHAR(500) NOT NULL,
	clie_Telefono				NVARCHAR(15) NOT NULL,
	clie_CorreoElectronico		NVARCHAR(150) NOT NULL,
    clie_UsuCreacion				INT				NOT NULL,
	clie_FechaCreacion			DATETIME		NOT NULL CONSTRAINT DF_clie_FechaCreacion DEFAULT(GETDATE()),
	clie_UsuModificacion			INT,
	clie_FechaModificacion		DATETIME,
	clie_Estado					BIT NOT NULL CONSTRAINT DF_clie_Estado DEFAULT(1),

	CONSTRAINT PK_maqu_tbClientes_clie_Id 								PRIMARY KEY(clie_Id),
	CONSTRAINT CK_maqu_tbClientes_empe_Sexo 							CHECK(clie_sexo IN ('F', 'M')),
	CONSTRAINT FK_maqu_tbClientes_acce_tbUsuarios_clie_UsuCreacion_user_Id  	FOREIGN KEY(clie_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbClientes_acce_tbUsuarios_clie_UsuModificacion_user_Id  FOREIGN KEY(clie_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbClientes_gral_tbMunicipios_muni_Id						FOREIGN KEY(muni_Id)				REFERENCES gral.tbMunicipios(muni_Id)			
);

--********TABLA Productos****************---
CREATE TABLE maqu.tbProductos
(
	prod_Id								INT IDENTITY,
	prod_Nombre							NVARCHAR(200)NOT NULL,
	prod_PrecioUni						DECIMAL(18,2) NOT NULL,
	cate_Id								INT NOT NULL,
	prov_Id								INT NOT NULL,
	prod_Stock							INT NOT NULL,
	prod_UsuCreacion					INT NOT NULL,
	prod_FechaCreacion					DATETIME NOT NULL CONSTRAINT DF_prod_FechaCreacion DEFAULT(GETDATE()),
	prod_FechaModificacion				DATETIME,
	prod_UsuModificacion				INT,
	prod_Estado							BIT NOT NULL CONSTRAINT DF_prod_Estado DEFAULT(1),

	CONSTRAINT PK_maqu_tbProductos_prod_Id 										PRIMARY KEY(prod_Id),
	CONSTRAINT FK_maqu_tbProductos_maqu_tbProveedores_prov_Id 						FOREIGN KEY(prov_Id) 				REFERENCES maqu.tbProveedores(prov_Id),
	CONSTRAINT FK_maqu_tbProductos_maqu_tbCategorias_cate_Id 							FOREIGN KEY(cate_Id) 				REFERENCES maqu.tbCategorias(cate_Id),
	CONSTRAINT FK_maqu_tbProductos_acce_tbUsuarios_clie_UsuCreacion_user_Id  		FOREIGN KEY(prod_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbProductos_acce_tbUsuarios_clie_UsuModificacion_user_Id  	FOREIGN KEY(prod_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
);


--********TABLA Factura****************---
CREATE TABLE maqu.tbFacturas
(
	fact_Id								INT IDENTITY,
	clie_Id								INT NOT NULL,
	fact_Fecha							DATETIME NOT NULL,
	meto_Id								INT NOT NULL,
	empe_Id								INT NOT NULL,
	fact_UsuCreacion						INT NOT NULL,
	fact_FechaCreacion					DATETIME NOT NULL CONSTRAINT DF_fact_FechaCreacion DEFAULT(GETDATE()),
	fact_FechaModificacion				DATETIME,
	fact_UsuModificacion					INT,
	fact_Estado							BIT NOT NULL CONSTRAINT DF_fact_Estado DEFAULT(1),

	CONSTRAINT PK_maqu_tbFacturas_fact_Id 											PRIMARY KEY(fact_Id),
	CONSTRAINT FK_maqu_tbFacturas_maqu_tbClientes_clie_Id 							FOREIGN KEY(clie_Id) 				REFERENCES maqu.tbClientes(clie_Id),
	CONSTRAINT FK_maqu_tbFacturas_maqu_tbMetodosPago_meto_Id 						FOREIGN KEY(meto_Id) 				REFERENCES maqu.tbMetodosPago(meto_Id),
	CONSTRAINT FK_maqu_tbFacturas_maqu_tbEmpleados_empe_Id							FOREIGN KEY(empe_Id)				REFERENCES maqu.tbEmpleados(empe_Id),
	CONSTRAINT FK_maqu_tbFacturas_acce_tbUsuarios_fact_UsuCreacion_user_Id  		FOREIGN KEY(fact_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbFacturas_acce_tbUsuarios_fact_UsuModificacion_user_Id  	FOREIGN KEY(fact_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
)

--********TABLA Factura Detalles****************---
CREATE TABLE maqu.tbFacturasDetalles
(
	factdeta_Id								INT IDENTITY,
	fact_Id									INT NOT NULL,
	prod_Id									INT NOT NULL,
	factdeta_Cantidad							INT NOT NULL,
	factdeta_Precio							DECIMAL(18,2) NOT NULL,
	factdeta_UsuCreacion						INT NOT NULL,
	factdeta_FechaCreacion					DATETIME NOT NULL CONSTRAINT DF_factdeta_FechaCreacion DEFAULT(GETDATE()),
	factdeta_FechaModificacion				DATETIME,
	factdeta_UsuModificacion					INT,
	factdeta_Estado							BIT NOT NULL CONSTRAINT DF_factdeta_Estado DEFAULT(1),

	CONSTRAINT PK_maqu_tbFacturasDetalles_factdeta_Id 											PRIMARY KEY(factdeta_Id),
	CONSTRAINT FK_maqu_tbFacturasDetalles_maqu_tbFacturas_fact_Id 									FOREIGN KEY(fact_Id) 					REFERENCES maqu.tbFacturas(fact_Id),
	CONSTRAINT FK_maqu_tbFacturasDetalles_maqu_tbProductos_prod_Id								FOREIGN KEY(prod_Id)					REFERENCES maqu.tbProductos(prod_Id),
	CONSTRAINT FK_maqu_tbFacturasDetalles_acce_tbUsuarios_factdeta_UsuCreacion_user_Id  		FOREIGN KEY(factdeta_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbFacturasDetalles_acce_tbUsuarios_factdeta_UsuModificacion_user_Id  	FOREIGN KEY(factdeta_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
);


/*
INSERT DE LA BASE DE DATOS
*/

GO
INSERT gral.tbDepartamentos(depa_Id, depa_Nombre, depa_UsuCreacion)
VALUES('01','Atlantida', 1),
      ('02','Colon', 1),
	  ('03','Comayagua', 1),
	  ('04','Copan', 1),
	  ('05','Cortes', 1),
	  ('06','Choluteca', 1),
	  ('07','El Paraiso', 1),
	  ('08','Francisco Morazan', 1),
	  ('09','Gracias a Dios', 1),
	  ('10','Intibuca', 1),
	  ('11','Islas de La Bahia', 1),
	  ('12','La Paz', 1),
	  ('13','Lempira', 1),
	  ('14','Ocotepeque', 1),
	  ('15','Olancho', 1),
	  ('16','Santa Barbara', 1),
	  ('17','Valle', 1),
	  ('18','Yoro', 1);

GO
INSERT gral.tbMunicipios(muni_id, muni_Nombre, depa_Id, muni_UsuCreacion)
VALUES('0101','La Ceiba ','01', 1),
      ('0102','El Porvenir','01', 1), 
	  ('0103','Jutiapa','01', 1),
	  ('0104','Jutiapa','01', 1),
	  ('0105','La Masica','01', 1),
	  ('0201','Trujillo','02', 1),
	  ('0202','Balfate','02', 1),
	  ('0203','Iriona','02', 1),
	  ('0204','Limon','02', 1),
	  ('0205','Saba','02', 1),
	  ('0301','Comayagua','03', 1),
	  ('0302','Ajuterique','03', 1),
      ('0303','El Rosario','03', 1),
	  ('0304','Esquias','03', 1),
      ('0305','Humuya','03', 1),
	  ('0401','Santa Rosa de Copan','04', 1),
	  ('0402','Cabanas','04', 1),
      ('0403','Concepcion','04', 1),
	  ('0404','Copan Ruinas','04', 1),
      ('0405','Corquin','04', 1),
	  ('0501','San Pedro Sula ','05', 1),
      ('0502','Choloma ','05', 1),
      ('0503','Omoa','05', 1),
      ('0504','Pimienta','05', 1),
	  ('0505','Potrerillos','05', 1),
	  ('0506','Puerto Cortes','05', 1),
	  ('0601','Choluteca','06', 1),
      ('0602','Apacilagua','06', 1),
      ('0603','Concepcion de Maria','06', 1),
      ('0604','Duyure','06', 1),
	  ('0605','El Corpus','07', 1),
	  ('0701','Yuscaran','07', 1),
      ('0702','Alauca','07', 1),
      ('0703','Danli','07', 1),
	  ('0704','El Paraiso','07', 1),
      ('0705','Ghinope','07', 1),
	  ('0801','Distrito Central (Comayaguela y Tegucigalpa)','08', 1),
      ('0802','Alubaran','08', 1),
      ('0803','Cedros','08', 1),
      ('0804','Curaron','08', 1),
	  ('0805','El Porvenir','08', 1),
	  ('0901','Puerto Lempira','09', 1),
      ('0902','Brus Laguna','09', 1),
      ('0903','Ahuas','09', 1),
	  ('0904','Juan Francisco Bulnes','09', 1),
      ('0905','Villeda Morales','09', 1),
	  ('1001','La Esperanza','10', 1),
      ('1002','Camasca','10', 1),
      ('1003','Colomoncagua','10', 1),
	  ('1004','Concepcion','10', 1),
      ('1005','Dolores','10', 1),
	  ('1101','Roatan','11', 1),
      ('1102','Guanaja','11', 1),
      ('1103','Jose Santos Guardiola','11', 1),
	  ('1104','Utila','11', 1),
	  ('1201','La Paz','12', 1),
      ('1202','Aguanqueterique','12', 1),
      ('1203','Cabanas','12', 1),
	  ('1204','Cane','12', 1),
      ('1205','Chinacla','12', 1),
	  ('1301','Gracias','13', 1),
      ('1302','Belen','13', 1),
      ('1303','Candelaria','13', 1),
	  ('1304','Cololaca','13', 1),
      ('1305','Erandique','13', 1),
	  ('1401','Ocotepeque','14', 1),
      ('1402','Belen Gualcho','14', 1),
      ('1403','Concepcion','14', 1),
	  ('1404','Dolores Merendon','14', 1),
      ('1405','Fraternidad','14', 1),
	  ('1501','Juticalpa','15', 1),
      ('1502','Campamento','15', 1),
      ('1503','Catacamas','15', 1),
	  ('1504','Concordia','15', 1),
      ('1505','Dulce Nombre de Culmo','15', 1),
	  ('1601','Santa Barbara','16', 1),
      ('1602','Arada','16', 1),
      ('1603','Atima','16', 1),
	  ('1604','Azacualpa','16', 1),
      ('1605','Ceguaca','16', 1),
	  ('1701','Nacaome','17', 1),
      ('1702','Alianza','17', 1),
      ('1703','Amapala','17', 1),
	  ('1704','Aramecina','17', 1),
      ('1705','Caridad','17', 1),
	  ('1801','Yoro','18', 1),
      ('1802','Arenal','18', 1),
      ('1803','El Negrito','18', 1),
	  ('1804','El Progreso','18', 1),
      ('1805','Jocon','18', 1)


--********PROCEDIMIENTOS****************---
--GO
--CREATE OR ALTER PROCEDURE UDP_maqu_tbMetodosPago_INSERT
--	@meto_Nombre			NVARCHAR(100),
--	@meto_UsuCreacion	INT
--AS
--BEGIN
--	INSERT INTO maqu.tbMetodosPago(meto_Nombre, meto_UsuCreacion)
--	VALUES (@meto_Nombre, @meto_UsuCreacion)
--END




--Iniciar sesion
GO
CREATE OR ALTER PROCEDURE UDP_Login 
	@user_Nombre NVARCHAR(100), @user_Contrasena NVARCHAR(200)
AS
BEGIN

	DECLARE @contraEncriptada NVARCHAR(MAX) = HASHBYTES('SHA2_512', @user_Contrasena);

	SELECT [user_Id], [user_NombreUsuario] [role_Id]
	FROM [acce].[tbUsuarios]
	WHERE [user_Contrasena] = @contraEncriptada
	AND [user_NombreUsuario] = @user_Nombre
	AND [user_Estado] = 1
END

GO

--**************** ESTADOS CIVILES ****************--
/*Vista Estados Civiles*/
GO
CREATE OR ALTER VIEW gral.VW_gral_tbEstadosCiviles_VW
AS
SELECT estacivi_Id, estacivi_Nombre, 
estacivi_UsuCreacion,[user1].user_NombreUsuario AS estacivi_UsuCreacion_Nombre, estacivi_FechaCreacion, 
estacivi_UsuModificacion,[user2].user_NombreUsuario AS estacivi_UsuModificacion_Nombre, estacivi_FechaModificacion, 
estacivi_Estado
FROM gral.tbEstadosCiviles estacivi INNER JOIN acce.tbUsuarios [user1]
ON estacivi.estacivi_UsuCreacion = [user1].user_Id LEFT JOIN acce.tbUsuarios [user2]
ON estacivi.estacivi_UsuModificacion = [user2].user_Id 
WHERE estacivi_Estado = 1

/*Vista Estados Civiles UDP*/
GO
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbEstadosCiviles_VW
AS
SELECT * FROM VW_gral_tbEstadosCiviles_VW

/*Listar Estados Civiles*/
GO
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbEstadosCiviles_List
AS
BEGIN 
	SELECT	estacivi_Id, estacivi_Nombre, 
			estacivi_UsuCreacion, estacivi_FechaCreacion, 
			estacivi_UsuModificacion, estacivi_FechaModificacion, 
			estacivi_Estado
	FROM [gral].[tbEstadosCiviles]
END
GO

--Insertar estados civiles
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbEstadosCiviles_INSERT
	@estacivi_Nombre		NVARCHAR(100),
	@estacivi_UsuCreacion INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM gral.tbEstadosCiviles WHERE estacivi_Nombre = @estacivi_Nombre)
			BEGIN
				INSERT INTO [gral].[tbEstadosCiviles]([estacivi_Nombre], [estacivi_UsuCreacion])
				VALUES(@estacivi_Nombre, @estacivi_UsuCreacion)

				SELECT 1
			END
		ELSE IF EXISTS (SELECT * FROM gral.tbEstadosCiviles
						WHERE estacivi_Nombre = @estacivi_Nombre
							  AND estacivi_Estado = 1)
			SELECT 2
		ELSE
			BEGIN
				UPDATE gral.tbEstadosCiviles
				SET estacivi_Estado = 1
				WHERE estacivi_Nombre = @estacivi_Nombre

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

--Editar estados civiles
GO
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbEstadosCiviles_UPDATE
	@estacivi_Id 		INT,
	@estacivi_Nombre	NVARCHAR(100),
	@estacivi_UsuModificacion INT
AS
BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT * FROM gral.tbEstadosCiviles WHERE estacivi_Nombre = @estacivi_Nombre)
		BEGIN			
			UPDATE [gral].[tbEstadosCiviles]
			SET [estacivi_Nombre] = @estacivi_Nombre,
				[estacivi_UsuModificacion] = @estacivi_UsuModificacion,
				[estacivi_FechaModificacion] = GETDATE()
			WHERE [estacivi_Id] = @estacivi_Id

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM gral.tbEstadosCiviles
						WHERE @estacivi_Nombre = estacivi_Nombre
							  AND estacivi_Estado = 1
							  AND estacivi_Id != @estacivi_Id)
			SELECT 2
		ELSE
			UPDATE gral.tbEstadosCiviles
			SET estacivi_Estado = 1,
			    estacivi_UsuModificacion = @estacivi_UsuModificacion
			WHERE estacivi_Nombre = @estacivi_Nombre

			SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

--Eliminar estados civiles
GO
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbEstadosCiviles_DELETE
	@estacivi_Id INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM maqu.tbEmpleados WHERE estacivi_Id = @estacivi_Id)
			BEGIN
				UPDATE [gral].[tbEstadosCiviles]
				SET  [estacivi_Estado] = 0
				WHERE [estacivi_Id] = @estacivi_Id
				
				SELECT 1
			END
		ELSE
			SELECT 2
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Insert estados civiles*/
GO
EXECUTE gral.UDP_gral_tbEstadosCiviles_INSERT 'Soltero(a)',1
EXECUTE gral.UDP_gral_tbEstadosCiviles_INSERT 'Casado(a)',1
EXECUTE gral.UDP_gral_tbEstadosCiviles_INSERT 'Union Libre',1
EXECUTE gral.UDP_gral_tbEstadosCiviles_INSERT 'Viudo(a)',1

--*******************Sucursales*************************--
/*Vista Sucursales*/
GO
CREATE OR ALTER VIEW maqu.VW_maqu_tbSucursales_VW
AS
SELECT sucu_Id, sucu_Descripcion, sucu_DireccionExacta, sucu_FechaCreacion, sucu_UsuCreacion, 
    sucu_FechaModificacion, sucu_UsuModificacion, sucu_Estado, muni.depa_Id, depa.depa_Nombre, sucu.muni_Id, muni.muni_Nombre, 
    [user1].user_NombreUsuario AS sucu_UsuCreacion_Nombre, [user2].user_NombreUsuario AS sucu_UsuModificacion_Nombre
FROM maqu.tbSucursales sucu
INNER JOIN gral.tbMunicipios muni ON sucu.muni_Id = muni.muni_id 
LEFT JOIN acce.tbUsuarios [user1] ON sucu.sucu_UsuCreacion = [user1].user_Id
LEFT JOIN acce.tbUsuarios [user2] ON sucu.sucu_UsuModificacion = [user2].user_Id
INNER JOIN gral.tbDepartamentos depa ON muni.depa_Id = depa.depa_Id
WHERE sucu.sucu_Estado = 1

/*Vista Sucursales UDP*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbSucursales_VW
AS
BEGIN
SELECT * FROM maqu.VW_maqu_tbSucursales_VW
END

/*Insertar Sucursal*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbSucursales_Insert
    @sucu_Descripcion NVARCHAR(200),
    @muni_Id CHAR(4),
    @sucu_DireccionExacta NVARCHAR(500),
    @sucu_UsuCreacion INT
AS
BEGIN
	BEGIN TRY
		
		IF NOT EXISTS (SELECT * FROM [maqu].tbSucursales
						WHERE @sucu_Descripcion = sucu_Descripcion)
		BEGIN

			INSERT INTO maqu.tbSucursales (sucu_Descripcion, muni_Id, sucu_DireccionExacta, sucu_UsuCreacion)
			VALUES (@sucu_Descripcion, @muni_Id, @sucu_DireccionExacta, @sucu_UsuCreacion);

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [maqu].tbSucursales
						WHERE @sucu_Descripcion = sucu_Descripcion
							  AND sucu_Estado = 1)
			SELECT 2
		ELSE
			BEGIN
				UPDATE [maqu].tbSucursales
				SET sucu_Estado = 1,
					muni_Id = @muni_Id,
					sucu_DireccionExacta = @sucu_DireccionExacta
				WHERE sucu_Descripcion = @sucu_Descripcion

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH 
END

GO

EXEC maqu.UDP_maqu_tbSucursales_Insert 'Sucursal 1','0501','Calle 5',1
EXEC maqu.UDP_maqu_tbSucursales_Insert 'Sucursal 2','0501','Calle 7',1
EXEC maqu.UDP_maqu_tbSucursales_Insert 'Sucursal 3','0501','Calle 6',1

/*Editar Sucursal*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbSucursales_Edit
    @sucu_Id INT,
    @sucu_Descripcion NVARCHAR(200),
    @muni_Id CHAR(4),
    @sucu_DireccionExacta NVARCHAR(500),
    @sucu_UsuModificacion INT
AS
BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT * FROM [maqu].tbSucursales
						WHERE @sucu_Descripcion = sucu_Descripcion)
		BEGIN			
			UPDATE [maqu].tbSucursales
			SET     sucu_Descripcion = @sucu_Descripcion,
					sucu_DireccionExacta = @sucu_DireccionExacta,
					muni_Id = @muni_Id,
					sucu_UsuModificacion = @sucu_UsuModificacion,
					sucu_FechaModificacion = GETDATE()
			WHERE 	sucu_Id = @sucu_Id

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [maqu].tbSucursales
						WHERE @sucu_Descripcion = sucu_Descripcion
							  AND sucu_Estado = 1
							  AND sucu_Id != @sucu_Id)
			SELECT 2
		ELSE
			UPDATE [maqu].tbSucursales
			SET sucu_Estado = 1,
				sucu_DireccionExacta = @sucu_DireccionExacta,
				muni_Id = @muni_Id,
			    sucu_UsuModificacion = @sucu_UsuModificacion,
				sucu_FechaModificacion = GETDATE()
			WHERE sucu_Descripcion = @sucu_Descripcion

			SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
    
/*Eliminar Sucursal*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbSucursales_Delete 
    @sucu_Id INT
AS
BEGIN
    BEGIN TRY
        IF NOT EXISTS (SELECT * FROM [maqu].[tbEmpleados] WHERE sucu_Id = @sucu_Id AND empe_Estado = 1)
            BEGIN
                UPDATE [maqu].tbSucursales
                SET sucu_Estado = 0
                WHERE sucu_Id = @sucu_Id

                SELECT 1
            END
        ELSE
            SELECT 2
    END TRY
    BEGIN CATCH
        SELECT 0
    END CATCH
END

--**************** EMPLEADOS ****************--
/*Empleados*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbEmpleados_VISTA
AS
BEGIN
	SELECT [empe_Nombres],
		   [empe_Apellidos],
		   CASE WHEN [empe_Sexo] = 'F' THEN 'Femenino'
				ELSE 'Masculino'
		   END AS Sexo,
		   T2.estacivi_Nombre
	FROM [maqu].[tbEmpleados] T1 INNER JOIN [gral].[tbEstadosCiviles] T2
	ON T1.[estacivi_Id] = T2.estacivi_Id
	WHERE [empe_Estado] = 1
END


/*Insertar Empleados*/
GO 
CREATE OR ALTER PROCEDURE maqu.UPD_maqu_tbEmpleados_Insert
	@empe_Nombres NVARCHAR(200),
	@empe_Apellidos NVARCHAR(200),
	@empe_Identidad NVARCHAR(13),
	@empe_FechaNacimiento DATE,
	@empe_Sexo CHAR,
	@estacivi_Id INT,
	@muni_Id NVARCHAR(4),
	@sucu_Id INT, 
	@empe_Direccion NVARCHAR(200),
	@empe_Telefono NVARCHAR(15),
	@empe_CorreoElectronico NVARCHAR(200),
	@empe_UsuCreacion INT
AS
BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT empe_Identidad FROM maqu.tbEmpleados WHERE empe_Identidad = @empe_Identidad)
	BEGIN 
		INSERT INTO maqu.tbEmpleados(empe_Nombres, empe_Apellidos, 
									empe_Identidad, empe_FechaNacimiento, 
									empe_Sexo, estacivi_Id, muni_Id,sucu_Id, 
									empe_Direccion, empe_Telefono, 
									empe_CorreoElectronico, empe_UsuCreacion)
		VALUES(@empe_Nombres,@empe_Apellidos,
				@empe_Identidad,@empe_FechaNacimiento,
				@empe_Sexo,@estacivi_Id,
				@muni_Id,@sucu_Id,@empe_Direccion,
				@empe_Telefono,@empe_CorreoElectronico,
				@empe_UsuCreacion)
		SELECT 1
		END
		ELSE IF EXISTS(SELECT * FROM maqu.tbEmpleados WHERE empe_Identidad = @empe_Identidad AND empe_Estado =1)
		SELECT 2
			ELSE
		BEGIN
		UPDATE tbEmpleados 
		SET empe_Nombres = @empe_Nombres,
		empe_Apellidos = @empe_Apellidos,
		empe_Identidad = @empe_Identidad,
		empe_FechaNacimiento = @empe_FechaNacimiento,
		empe_Sexo = @empe_Sexo,
		estacivi_Id  = @estacivi_Id,
		muni_Id = @muni_Id,
		sucu_Id = @sucu_Id,
		empe_Direccion = @empe_Direccion,
		empe_Telefono = @empe_Telefono,
		empe_CorreoElectronico = @empe_CorreoElectronico,
		empe_UsuCreacion = @empe_UsuCreacion
		WHERE empe_Identidad = @empe_Identidad

		SELECT 1
		END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Editar Empleados*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbEmpleados_Update
    @empe_Id					INT,
    @empe_Nombres				NVARCHAR(200),
    @empe_Apellidos				NVARCHAR(200),
    @empe_Identidad				NVARCHAR(13),
    @empe_FechaNacimiento		DATE,
    @empe_Sexo					CHAR,
    @estacivi_Id				INT,
    @muni_Id					NVARCHAR(4),
	@sucu_Id					INT,
    @empe_Direccion				NVARCHAR(200),
    @empe_Telefono				NVARCHAR(15),
    @empe_CorreoElectronico		NVARCHAR(200),
    @empe_usuModificacion		INT
AS
BEGIN
    BEGIN TRY
	IF NOT EXISTS (SELECT * FROM maqu.tbEmpleados WHERE empe_Identidad = @empe_Identidad)
	BEGIN
        UPDATE maqu.tbEmpleados
        SET     empe_Nombres = @empe_Nombres,
                empe_Apellidos = @empe_Apellidos,
                empe_Identidad = @empe_Identidad,
                empe_FechaNacimiento = @empe_FechaNacimiento,
                empe_Sexo = @empe_Sexo,
                estacivi_Id = @estacivi_Id,
                muni_Id = @muni_Id,
				sucu_Id = @sucu_Id,
                empe_Telefono = @empe_Telefono,
                empe_CorreoElectronico = @empe_CorreoElectronico,
                empe_UsuModificacion = @empe_usuModificacion,
                empe_FechaModificacion = GETDATE()
        WHERE   empe_Id = @empe_Id
        SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM maqu.tbEmpleados WHERE empe_Identidad = @empe_Identidad AND empe_Id != @empe_Id AND empe_Estado = 1)
		SELECT 2
		ELSE
		BEGIN
  UPDATE maqu.tbEmpleados
        SET     empe_Nombres = @empe_Nombres,
                empe_Apellidos = @empe_Apellidos,
                empe_Identidad = @empe_Identidad,
                empe_FechaNacimiento = @empe_FechaNacimiento,
                empe_Sexo = @empe_Sexo,
                estacivi_Id = @estacivi_Id,
                muni_Id = @muni_Id,
				sucu_Id = @sucu_Id,
                empe_Telefono = @empe_Telefono,
                empe_CorreoElectronico = @empe_CorreoElectronico,
                empe_UsuModificacion = @empe_usuModificacion,
                empe_FechaModificacion = GETDATE()
        WHERE   empe_Id = @empe_Id
        SELECT 1
		END
    END TRY
    BEGIN CATCH
        SELECT 0
    END CATCH
END
GO
EXECUTE maqu.UDP_maqu_tbEmpleados_Update 1,'Alessio','Medino','12412','10-10-2005','M',2,'0501',1,'assa','321412','alessi@gmail.com',1

/*Eliminar Empleados*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbEmpleados_Delete
	@empe_Id INT
AS
BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT * FROM maqu.tbEmpleados WHERE empe_Id = @empe_Id)
	BEGIN
	SELECT 0
	END
	ELSE 
	IF NOT EXISTS(SELECT * FROM maqu.tbFacturas WHERE empe_Id = @empe_Id AND fact_Estado = 1)
	BEGIN
		UPDATE maqu.tbEmpleados
		SET 	empe_Estado = 0
		WHERE 	empe_Id = @empe_Id
		SELECT 1
		END
		ELSE
		BEGIN
		SELECT 2
		END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO

/*Vista empleados*/
GO
CREATE OR ALTER VIEW maqu.VW_maqu_tbEmpleados_View
AS
SELECT empe.empe_Id,(SELECT empe_Nombres + ' ' + empe_Apellidos ) AS NombreCompleto,
empe_Nombres, empe_Apellidos, empe_Identidad, empe_FechaNacimiento, empe_Sexo,
empe.estacivi_Id,estacivi.estacivi_Nombre,depa.depa_Id,depa.depa_Nombre,empe.muni_Id,muni.muni_Nombre,empe.sucu_Id, sucu_Descripcion, 
empe_Direccion,empe_Telefono, empe_CorreoElectronico,empe_UsuCreacion,[user1].user_NombreUsuario,
empe_UsuModificacion = [user2].user_NombreUsuario,empe.empe_FechaCreacion,empe.empe_FechaModificacion
FROM maqu.tbEmpleados empe INNER JOIN gral.tbMunicipios muni 
ON empe.muni_Id = muni.muni_id INNER JOIN gral.tbDepartamentos depa 
ON muni.depa_Id = depa.depa_Id INNER JOIN acce.tbUsuarios [user1]
ON empe.empe_UsuCreacion = [user1].user_Id LEFT JOIN acce.tbUsuarios [user2]
ON empe.empe_UsuModificacion = [user2].user_Id INNER JOIN gral.tbEstadosCiviles estacivi
ON empe.estacivi_Id = estacivi.estacivi_Id INNER JOIN maqu.tbSucursales sucu
ON empe.sucu_Id = sucu.sucu_Id

GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbEmpleados_View
AS
BEGIN
SELECT * FROM maqu.VW_maqu_tbEmpleados_View
END

/*Listar empleado x Id*/
GO 
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbEmpleados_ListById 
@empe_Id INT 
AS
BEGIN
SELECT empe_Id, 
		   empe_Nombres, 
		   empe_Apellidos, 
		   empe_Identidad, 
		   empe_FechaNacimiento, 
		    empe_Sexo,
		   muni_Id,
		   estacivi_Id,
		   sucu_Id,
		   empe_Direccion, 
		   empe_Telefono, 
		   empe_CorreoElectronico
		   FROM [maqu].[tbEmpleados]
		   WHERE empe_Id = @empe_Id
END

/*Listar Empleado*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbEmpleados_List
AS
BEGIN
	SELECT empe_Id, 
		   empe_Nombres, 
		   empe_Apellidos, 
		   empe_Identidad, 
		   empe_FechaNacimiento, 
		   CASE empe_Sexo WHEN 'F' THEN 'Femenino'
						  ELSE 'Masculino'
		   END AS empe_Sexo,
		   muni_Id, 
		   sucu_Id,
		   empe_Direccion, 
		   empe_Telefono, 
		   empe_CorreoElectronico
		   FROM [maqu].[tbEmpleados]
		   WHERE empe_Estado = 1
END
GO

EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Alessia', 'Medina', '0501200506728', '2005-05-06', 'F', 1, '0501',1, 'casa', '99349019', 'aless@hootmail.com', 1
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Juan', 'García', '0501199201234', '1992-01-05', 'M', 2, '0101',1, 'Calle 1', '99999999', 'juan@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'María', 'González', '0501199123456', '1991-01-01', 'F', 3, '0102',1, 'Calle 2', '88888888', 'maria@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Pedro', 'Hernández', '0501198809876', '1988-01-01', 'M', 4, '0203',1, 'Calle 3', '77777777', 'pedro@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Ana', 'Martínez', '0501198504321', '1985-01-01', 'F', 1, '0304',1, 'Calle 4', '66666666', 'ana@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Luis', 'Guzmán', '0501198008765', '1980-01-01', 'M', 2, '0204',1, 'Calle 5', '55555555', 'luis@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Lucía', 'Sánchez', '0501197912345', '1979-01-01', 'F', 3, '0701',1, 'Calle 6', '44444444', 'lucia@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Carlos', 'Pérez', '0501197609876', '1976-01-01', 'M', 4, '0506',1, 'Calle 7', '33333333', 'carlos@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Marta', 'López', '0501197304321', '1973-01-01', 'F', 1, '1001',1, 'Calle 8', '22222222', 'marta@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Jorge', 'Díaz', '0501197008765', '1970-01-01', 'M', 2, '1002',1, 'Calle 9', '11111111', 'jorge@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Laura', 'Ramírez', '0501196701234', '1967-01-01', 'F', 3, '0802',1, 'Calle 10', '00000000', 'laura@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Diego', 'Gómez', '0501196409876', '1964-01-01', 'M', 4, '0803',1, 'Calle 11', '99999999', 'diego@mail.com', 1;
GO
ALTER TABLE acce.tbUsuarios
ADD CONSTRAINT FK_acce_tbUsuarios_maqu_tbEmpleados_empe_Id FOREIGN KEY(empe_Id) REFERENCES maqu.tbEmpleados(empe_Id)
/*Obtener muni_Id x empe_Id*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_tbEmpleados_maqu_GetMuni_Id
@empe_Id INT	
AS
BEGIN
SELECT * FROM maqu.VW_maqu_tbEmpleados_DDLMunicipios WHERE empe_Id = @empe_Id
END 

/*Vista para cargar dll de municipios (tbEmpleados)*/
GO
CREATE OR ALTER VIEW maqu.VW_maqu_tbEmpleados_DDLMunicipios
AS 
SELECT t2.muni_Nombre,t2.muni_id,t1.empe_Id,t3.depa_Id,t3.depa_Nombre FROM maqu.tbEmpleados t1 INNER JOIN gral.tbMunicipios t2
ON t1.muni_Id = t2.muni_id INNER JOIN gral.tbDepartamentos t3
ON t2.depa_Id = t3.depa_Id


/*Obtener muni_Id x clie_Id*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_tbClientes_maqu_GetMuni_Id 
	@clie_Id INT	
AS
BEGIN
SELECT * FROM maqu.VW_maqu_tbClientes_DDLMunicipios WHERE clie_Id = @clie_Id
END 

/*Vista para cargar dll de municipios (tbClientes)*/
GO
CREATE OR ALTER VIEW maqu.VW_maqu_tbClientes_DDLMunicipios
AS 
SELECT t2.muni_Nombre,t2.muni_id,t1.clie_Id,t3.depa_Id,t3.depa_Nombre FROM maqu.tbClientes t1 INNER JOIN gral.tbMunicipios t2
ON t1.muni_Id = t2.muni_id INNER JOIN gral.tbDepartamentos t3
ON t2.depa_Id = t3.depa_Id


--********************Municipios****************************--
/*Vista Municipios*/
GO
CREATE OR ALTER VIEW gral.VW_gral_tbMunicipios_VW
AS
SELECT muni_id, muni_Nombre, 
muni.depa_Id,depa.depa_Nombre, muni_UsuCreacion,[user1].user_NombreUsuario AS muni_UsuCreacion_Nombre, 
muni_FechaCreacion, muni_UsuModificacion,[user2].user_NombreUsuario AS muni_UsuModificacion_Nombre, 
muni_FechaModificacion, muni_Estado
FROM gral.tbMunicipios muni INNER JOIN gral.tbDepartamentos depa
ON muni.depa_Id = depa.depa_Id INNER JOIN acce.tbUsuarios [user1]
ON muni.muni_UsuCreacion = [user1].user_Id LEFT JOIN acce.tbUsuarios [user2]
ON muni.muni_UsuModificacion = [user2].user_Id
WHERE muni_Estado = 1

/*Insertar Municipios*/
GO
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbMunicipios_Insert
	@muni_Id				CHAR(4),
	@muni_Nombre			NVARCHAR(150),
	@depa_Id				CHAR(2),
	@muni_UsuCreacion		INT
AS
BEGIN
	BEGIN TRY
		
		IF NOT EXISTS (SELECT * FROM [gral].[tbMunicipios]
						WHERE @muni_Id = muni_id)
		BEGIN
		INSERT INTO gral.tbMunicipios(muni_id, muni_Nombre, depa_Id, muni_UsuCreacion, muni_FechaCreacion, muni_UsuModificacion, muni_FechaModificacion, muni_Estado)
		VALUES(@muni_Id,@muni_Nombre,@depa_Id,@muni_UsuCreacion,GETDATE(),NULL,NULL,1)

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [gral].[tbMunicipios]
						WHERE @muni_Id = muni_id
							  AND muni_Estado = 1)
			SELECT 2
		ELSE
			BEGIN
				UPDATE [gral].[tbMunicipios]
				SET muni_Estado = 1,
					depa_Id = @depa_Id,
					muni_Nombre = @muni_Nombre
				WHERE muni_id = @muni_Id

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH 

END

/*Editar Municipios*/
GO
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbMunicipios_Edit 
	@muni_Id				CHAR(4),
	@muni_Nombre			NVARCHAR(150),
	@depa_Id				CHAR(2),
	@muni_UsuModificacion   INT
AS
BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT * FROM [gral].[tbMunicipios]
						WHERE @muni_Id = muni_id)
		BEGIN

			UPDATE gral.tbMunicipios
			SET muni_Nombre = @muni_Nombre,
				depa_Id = @depa_Id,
				muni_UsuModificacion = @muni_UsuModificacion,
				muni_FechaModificacion = GETDATE()
			WHERE muni_Id = @muni_Id

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [gral].[tbMunicipios]
						WHERE @muni_Nombre = muni_Nombre
							  AND muni_Estado = 1
							  AND muni_id != @muni_Id)
			SELECT 2
		ELSE
			UPDATE [gral].[tbMunicipios]
			SET muni_Estado = 1,
				depa_Id = @depa_Id,
				muni_Nombre = @muni_Nombre,
				muni_UsuModificacion = @muni_UsuModificacion,
				muni_FechaModificacion = GETDATE()
			WHERE muni_id = @muni_Id

			SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Eliminar Municipio*/
GO 
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbMunicipios_Delete
@muni_Id CHAR(4)
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM [maqu].tbEmpleados WHERE muni_Id = @muni_Id)
			BEGIN

				UPDATE gral.tbMunicipios
				SET muni_Estado = 0
				WHERE muni_id = @muni_Id

				SELECT 1
			END
		ELSE IF NOT EXISTS (SELECT * FROM [maqu].tbClientes WHERE muni_Id = @muni_Id)
			BEGIN

				UPDATE gral.tbMunicipios
				SET muni_Estado = 0
				WHERE muni_id = @muni_Id

				SELECT 1
			END
		ELSE
			SELECT 2
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Vista Municipios UDP*/
GO
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbMunicipios_VW
AS
SELECT * FROM gral.VW_gral_tbMunicipios_VW

/*Listado municipios para DropDownList*/
GO 
CREATE OR ALTER PROCEDURE UDP_gral_tbMunicipios_ListDDL
@depa_Id CHAR(4)
AS
BEGIN
	SELECT muni_id,muni_Nombre 
	FROM [gral].[tbMunicipios] 
	WHERE depa_Id = @depa_Id
	AND [muni_Estado] = 1
END

/*Departamento y municipio por empleado*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_tbMunicipios_tbEmpleados_ListDDL 
	@empe_Id	INT
AS
BEGIN
	SELECT depa_Id, T1.muni_Id
	FROM [maqu].[tbEmpleados] T1 INNER JOIN [gral].[tbMunicipios] T2
	ON T1.muni_Id = T2.muni_Id
	WHERE empe_Id = @empe_Id
END

--**************** DEPARTAMENTOS ****************--
/*Vista Departamentos*/
GO
CREATE OR ALTER VIEW gral.VW_gral_tbDepartamentos_VW
AS
SELECT depa_Id, depa_Nombre, 
depa_UsuCreacion,[user1].user_NombreUsuario AS depe_UsuCreacion_Nombre, depa_FechaCreacion, 
depa_UsuModificacion,[user2].user_NombreUsuario AS depa_UsuModificacion_Nombre, depa_FechaModificacion, 
depa_Estado
FROM gral.tbDepartamentos depa INNER JOIN acce.tbUsuarios [user1] 
ON depa_UsuCreacion = [user1].user_Id LEFT JOIN acce.tbUsuarios [user2]
ON depa_UsuModificacion = [user2].user_Id 


/*Vista Departamentos UDP*/
GO
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbDepartamentos_VW
AS
SELECT * FROM gral.VW_gral_tbDepartamentos_VW WHERE depa_Estado = 1

/*Insertar Departamentos*/
GO
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbDepartamentos_Insert
	@depa_Id			NVARCHAR(2),
	@depa_Nombre 		NVARCHAR(100),
	@depa_UsuCreacion 	INT
AS
BEGIN

	BEGIN TRY
		
		IF NOT EXISTS (SELECT * FROM gral.tbDepartamentos
						WHERE @depa_Id = depa_Id)
		BEGIN

			INSERT INTO gral.tbDepartamentos(depa_Id,depa_Nombre, depa_UsuCreacion)
			VALUES(@depa_Id,@depa_Nombre,@depa_UsuCreacion)

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM gral.tbDepartamentos
						WHERE @depa_Id = depa_Id
							  AND depa_Estado = 1)
			SELECT 2
		ELSE
			BEGIN
				UPDATE gral.tbDepartamentos
				SET depa_Estado = 1,
					depa_Nombre = @depa_Nombre
				WHERE @depa_Id = depa_Id

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH 
END

/*Editar Departamentos*/
GO
CREATE OR ALTER PROCEDURE gral.UDP_gral_tbDepartamentos_UPDATE
	@depa_Id					NVARCHAR(2),
	@depa_Nombre 				NVARCHAR(100),
	@depa_UsuModificacion 		INT
AS
BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT * FROM gral.tbDepartamentos
						WHERE @depa_Id = depa_Id)
		BEGIN			
			UPDATE gral.tbDepartamentos
			SET     depa_Nombre = @depa_Nombre,
					depa_UsuModificacion = @depa_UsuModificacion,
					depa_FechaModificacion = GETDATE()
			WHERE 	depa_Id = @depa_Id

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM gral.tbDepartamentos
						WHERE @depa_Nombre = depa_Nombre
							  AND depa_Estado = 1
							  AND depa_Id != @depa_Id)
			SELECT 2
		ELSE
			UPDATE gral.tbDepartamentos
			SET depa_Estado = 1,
				depa_Nombre = @depa_Nombre,
			    depa_UsuModificacion = @depa_UsuModificacion
			WHERE @depa_Id = depa_Id

			SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH

END

/*Eliminar Departamentos*/
GO
CREATE OR ALTER PROCEDURE UDP_gral_tbDepartamentos_DELETE
	@depa_Id CHAR(2)
AS
BEGIN

	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM gral.tbMunicipios WHERE depa_Id = @depa_Id)
			BEGIN
				UPDATE gral.tbDepartamentos
				SET   depa_Estado = 0
				WHERE depa_Id = @depa_Id

				SELECT 1
			END
		ELSE
			SELECT 2
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Listar Departamentos*/
GO 
CREATE OR ALTER PROCEDURE gral.UPD_gral_tbDepartamentos_List
AS
BEGIN
SELECT depa_Id,depa_Nombre FROM [gral].[tbDepartamentos]
END

--**************** METODOS DE PAGO ****************--
/*Vista metodos de pago*/
GO
CREATE OR ALTER VIEW maqu.VW_maqu_tbMetodosPago_View
AS
SELECT meto_Id, meto_Nombre, 
meto_UsuCreacion,[user1].user_NombreUsuario AS meto_UsuCreacion_Nombre, meto_FechaCreacion, 
meto_UsuModificacion,[user2].user_NombreUsuario AS meto_UsuModificacion_Nombre, meto_FechaModificacion, 
meto_Estado 
FROM maqu.tbMetodosPago meto INNER JOIN acce.tbUsuarios [user1]
ON meto.meto_UsuCreacion = [user1].user_Id LEFT JOIN acce.tbUsuarios [user2]
ON meto.meto_UsuModificacion = [user2].user_Id

/*Vista metodos de pago UDP*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbMetodosPago_VW
AS
SELECT * FROM VW_maqu_tbMetodosPago_View

/*Insert metodos de pago*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbMetodosPago_INSERT
	@meto_Nombre				NVARCHAR(100),
	@meto_UsuCreacion 			INT
AS
BEGIN
	BEGIN TRY
		
		IF NOT EXISTS (SELECT * FROM [maqu].[tbMetodosPago]
						WHERE @meto_Nombre = meto_Nombre)
		BEGIN
			INSERT INTO [maqu].[tbMetodosPago](meto_Nombre, meto_UsuCreacion)
			VALUES (@meto_Nombre, @meto_UsuCreacion)

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [maqu].[tbMetodosPago]
						WHERE @meto_Nombre = meto_Nombre
							  AND meto_Estado = 1)
			SELECT 2
		ELSE
			BEGIN
				UPDATE [maqu].[tbMetodosPago]
				SET [meto_Estado] = 1
				WHERE meto_Nombre = @meto_Nombre

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH 
END

/*Editar metodos de pago*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbMetodosPago_UPDATE
	@meto_Id 				INT,
	@meto_Nombre			NVARCHAR(100),
	@meto_UsuModificacion 	INT
AS
BEGIN
	BEGIN TRY
	IF NOT EXISTS (SELECT * FROM [maqu].[tbMetodosPago]
						WHERE @meto_Nombre = meto_Nombre)
		BEGIN			
			UPDATE [maqu].[tbMetodosPago]
			SET     [meto_Nombre] = @meto_Nombre,
					[meto_UsuModificacion] = @meto_UsuModificacion,
					[meto_FechaModificacion] = GETDATE()
			WHERE 	[meto_Id] = @meto_Id

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [maqu].[tbMetodosPago]
						WHERE @meto_Nombre = meto_Nombre
							  AND meto_Estado = 1
							  AND meto_Id != @meto_Id)
			SELECT 2
		ELSE
			UPDATE [maqu].[tbMetodosPago]
			SET [meto_Estado] = 1,
			   meto_UsuModificacion = @meto_UsuModificacion
			WHERE meto_Nombre = @meto_Nombre

			SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Eliminar metodos de pago*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbMetodosPago_DELETE 
	@meto_Id INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM [maqu].[tbFacturas] WHERE meto_Id = @meto_Id)
			BEGIN
				UPDATE [maqu].[tbMetodosPago]
				SET [meto_Estado] = 0
				WHERE [meto_Id] = @meto_Id
				
				SELECT 1
			END
		ELSE
			SELECT 2
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

GO
EXEC maqu.UDP_maqu_tbMetodosPago_INSERT 'Efectivo', 1
/*Listar métodos de pago*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbMetodosPago
AS
BEGIN
	SELECT [meto_Id], [meto_Nombre]
	FROM [maqu].[tbMetodosPago]
	WHERE [meto_Estado] = 1
END

----*******************Sucursales*************************--
--/*Vista Sucursales*/
--GO
--CREATE OR ALTER VIEW maqu.VW_maqu_tbSucursales_VW
--AS
--SELECT sucu_Id, sucu_Descripcion, sucu_DireccionExacta, sucu_FechaCreacion, sucu_UsuCreacion, 
--    sucu_FechaModificacion, sucu_UsuModificacion, sucu_Estado, muni.depa_Id, depa.depa_Nombre, sucu.muni_Id, muni.muni_Nombre, 
--    [user1].user_NombreUsuario AS sucu_UsuCreacion_Nombre, [user2].user_NombreUsuario AS sucu_UsuModificacion_Nombre
--FROM maqu.tbSucursales sucu
--INNER JOIN gral.tbMunicipios muni ON sucu.muni_Id = muni.muni_id 
--LEFT JOIN acce.tbUsuarios [user1] ON sucu.sucu_UsuCreacion = [user1].user_Id
--LEFT JOIN acce.tbUsuarios [user2] ON sucu.sucu_UsuModificacion = [user2].user_Id
--INNER JOIN gral.tbDepartamentos depa ON muni.depa_Id = depa.depa_Id
--WHERE sucu.sucu_Estado = 1

--/*Vista Sucursales UDP*/
--GO
--CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbSucursales_VW
--AS
--BEGIN
--SELECT * FROM maqu.VW_maqu_tbSucursales_VW
--END

--/*Insertar Sucursal*/
--GO
--CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbSucursales_Insert
--    @sucu_Descripcion NVARCHAR(200),
--    @muni_Id CHAR(4),
--    @sucu_DireccionExacta NVARCHAR(500),
--    @sucu_UsuCreacion INT
--AS
--BEGIN

--	BEGIN TRY
		
--		IF NOT EXISTS (SELECT * FROM maqu.tbSucursales
--						WHERE @sucu_Descripcion = sucu_Descripcion)
--		BEGIN
--			INSERT INTO maqu.tbSucursales (sucu_Descripcion, muni_Id, sucu_DireccionExacta, sucu_UsuCreacion)
--			VALUES (@sucu_Descripcion, @muni_Id, @sucu_DireccionExacta, @sucu_UsuCreacion);

--			SELECT 1
--		END
--		ELSE IF EXISTS (SELECT * FROM maqu.tbSucursales
--						WHERE @sucu_Descripcion = sucu_Descripcion
--							  AND sucu_Estado = 1)
--			SELECT 2
--		ELSE
--			BEGIN
--				UPDATE maqu.tbSucursales
--				SET sucu_Estado = 1,
--					sucu_Descripcion = @sucu_Descripcion,
--					muni_Id = @muni_Id,
--					sucu_DireccionExacta = @sucu_DireccionExacta
--				WHERE sucu_Descripcion = @sucu_Descripcion

--				SELECT 1
--			END
--	END TRY
--	BEGIN CATCH
--		SELECT 0
--	END CATCH 

--END

--GO

--EXEC maqu.UDP_maqu_tbSucursales_Insert 'Sucursal 1','0501','Calle 5',1
--EXEC maqu.UDP_maqu_tbSucursales_Insert 'Sucursal 2','0501','Calle 7',1
--EXEC maqu.UDP_maqu_tbSucursales_Insert 'Sucursal 3','0501','Calle 6',1

--/*Editar Sucursal*/
--GO
--CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbSucursales_Edit
--    @sucu_Id INT,
--    @sucu_Descripcion NVARCHAR(200),
--    @muni_Id CHAR(4),
--    @sucu_DireccionExacta NVARCHAR(500),
--    @sucu_UsuModificacion INT
--AS
--BEGIN

--	BEGIN TRY
--		IF NOT EXISTS (SELECT * FROM [maqu].tbSucursales
--							WHERE @sucu_Descripcion = sucu_Descripcion)
--			BEGIN	
--				UPDATE maqu.tbSucursales
--				SET sucu_Descripcion = @sucu_Descripcion,
--					muni_Id = @muni_Id,
--					sucu_DireccionExacta = @sucu_DireccionExacta,
--					sucu_UsuModificacion = @sucu_UsuModificacion,
--					sucu_FechaModificacion = GETDATE()
--				WHERE sucu_Id = @sucu_Id;

--				SELECT 1
--			END
--			ELSE IF EXISTS (SELECT * FROM [maqu].tbSucursales
--							WHERE @sucu_Descripcion = sucu_Descripcion
--								  AND sucu_Estado = 1
--								  AND sucu_Id != @sucu_Id)
--				SELECT 2
--			ELSE
--				BEGIN
--					UPDATE [maqu].tbSucursales
--					SET sucu_Estado = 1,
--						muni_Id = @muni_Id,
--						sucu_DireccionExacta = @sucu_DireccionExacta,
--						sucu_UsuModificacion = @sucu_UsuModificacion,
--						sucu_FechaModificacion = GETDATE()
--					WHERE sucu_Descripcion = @sucu_Descripcion

--					SELECT 1
--				END
--	END TRY
--	BEGIN CATCH
--		SELECT 0
--	END CATCH
--END

--/*Eliminar Sucursal*/
--GO
--CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbSucursales_Delete
--	@sucu_Id INT
--AS
--BEGIN
--	BEGIN TRY
--		IF NOT EXISTS (SELECT * FROM [maqu].tbSucursales WHERE sucu_Id = @sucu_Id AND sucu_Estado = 1)
--			BEGIN
--				UPDATE [maqu].tbSucursales
--				SET sucu_Estado = 0
--				WHERE sucu_Id = @sucu_Id
				
--				SELECT 1
--			END
--		ELSE
--			SELECT 2
--	END TRY
--	BEGIN CATCH
--		SELECT 0
--	END CATCH

--	UPDATE maqu.tbSucursales 
--	SET sucu_Estado = 0
--	WHERE sucu_Id = @sucu_Id
--END

/*DDL muni x sucursal*/
--GO
--CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbSucursales_gral_tbMunicipios_DDL
--	@sucu_Id INT
--AS
--BEGIN
--	SELECT [muni_Id] 
--	FROM [maqu].[tbSucursales] T1 INNER JOIN 
--END

--**************** CATEGORIAS ****************--
/*Vista Categoria*/
GO
CREATE OR ALTER VIEW maqu.VW_maqu_tbCategorias_VW
AS
SELECT cate_Id, cate_Nombre, 
cate_UsuCreacion,[user1].user_NombreUsuario AS cate_UsuCreacion_Nombre, cate_FechaCreacion, 
cate_UsuModificacion,[user2].user_NombreUsuario AS cate_UsuModificacion_Nombre, cate_FechaModificacion, 
cate_Estado
FROM maqu.tbCategorias cate INNER JOIN acce.tbUsuarios [user1]
ON cate.cate_UsuCreacion = [user1].user_Id LEFT JOIN acce.tbUsuarios [user2]
ON cate.cate_UsuModificacion = [user2].user_Id
WHERE cate.cate_Estado = 1

/*Vista Categorias UDP*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbCategorias_VW
AS
BEGIN
SELECT * FROM maqu.VW_maqu_tbCategorias_VW
END
/*Insertar categoria*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbCategorias_INSERT 
	@cate_Nombre 			NVARCHAR(100),
	@cate_UsuCreacion 		INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM [maqu].[tbCategorias] 
						WHERE cate_Nombre = @cate_Nombre)
			BEGIN
			INSERT INTO [maqu].[tbCategorias](cate_Nombre, cate_UsuCreacion)
			VALUES(@cate_Nombre, @cate_UsuCreacion)
			
			SELECT 1
			END
		ELSE IF EXISTS (SELECT * FROM [maqu].[tbCategorias] 
						WHERE cate_Nombre = @cate_Nombre
						AND cate_Estado = 0)
			BEGIN
				UPDATE [maqu].[tbCategorias]
				SET cate_Estado = 1
				WHERE cate_Nombre = @cate_Nombre

				SELECT 1
			END
		ELSE
			SELECT 2
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO


/*Editar categoria*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbCategorias_UPDATE
	@cate_Id					INT,
	@cate_Nombre 				NVARCHAR(100),
	@cate_UsuModificacion 		INT
AS
BEGIN 
	BEGIN TRY
	IF NOT EXISTS (SELECT * FROM [maqu].[tbCategorias]
						WHERE @cate_Nombre = [cate_Nombre])
		BEGIN			
			UPDATE [maqu].[tbCategorias]
			SET 	[cate_Nombre] = @cate_Nombre,
					[cate_UsuModificacion] = @cate_UsuModificacion,
					[cate_FechaModificacion] = GETDATE()
			WHERE 	[cate_Id] = @cate_Id
			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [maqu].[tbCategorias]
						WHERE @cate_Nombre = [cate_Nombre]
							  AND cate_Estado = 1
							  AND [cate_Id] != @cate_Id)
			SELECT 2
		ELSE
			UPDATE [maqu].[tbCategorias]
			SET cate_Estado = 1,
			   cate_UsuModificacion = @cate_UsuModificacion
			WHERE [cate_Nombre] = @cate_Nombre

			SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END


/*Eliminar categoria*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbCategorias_Delete 
	@cate_Id	INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM [maqu].[tbProductos] WHERE cate_Id = @cate_Id)
			BEGIN
				UPDATE [maqu].[tbCategorias]
				SET cate_Estado = 0
				WHERE cate_Id = @cate_Id

				SELECT 1
			END
		ELSE
			SELECT 2
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Listado de categorias*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbCategorias_List
AS
BEGIN
	SELECT [cate_Id], [cate_Nombre] 
	FROM [maqu].[tbCategorias]
	WHERE [cate_Estado] = 1
END

/*Listado de categoria x Id*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_tbCategorias_maqu_ListById
@cate_Id INT
AS
BEGIN
SELECT * FROM maqu.tbCategorias WHERE cate_Id = @cate_Id
END


--***************Clientes************************--
/*Vista Cliente*/
GO
CREATE OR ALTER VIEW maqu.VW_maqu_tbClientes_VW
AS
SELECT clie_Id,(SELECT clie_Nombres + ' ' + clie_Apellidos) AS clie_NombreCompleto,
clie_Identidad,clie_Sexo,muni.depa_Id,depa.depa_Nombre,clie.muni_Id,muni.muni_Nombre,clie_DireccionExacta,clie_Telefono,
clie_CorreoElectronico,
clie_FechaCreacion,clie_UsuCreacion,[user1].user_NombreUsuario AS clie_UsuCreacion_Nombre,
clie_UsuModificacion, [user2].user_Id AS clie_UsuModificacion_Nombre,clie_FechaModificacion
FROM maqu.tbClientes clie INNER JOIN gral.tbMunicipios muni
ON clie.muni_Id = muni.muni_id INNER JOIN gral.tbDepartamentos depa 
ON muni.depa_Id = depa.depa_Id INNER JOIN acce.tbUsuarios [user1]
ON clie.clie_UsuCreacion = [user1].user_Id LEFT JOIN acce.tbUsuarios [user2]
ON clie.clie_UsuModificacion = [user2].user_Id
WHERE clie.clie_Estado = 1

/*Vista Clientes UDP*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbClientes_VW
AS
BEGIN
SELECT * FROM maqu.VW_maqu_tbClientes_VW
END

/*Insertar Cliente*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbClientes_Insert 
    @clie_Nombres                NVARCHAR(200),
    @clie_Apellidos               NVARCHAR(200),
    @clie_Identidad               NVARCHAR(13),
    @clie_Sexo                    CHAR,
    @muni_Id                      CHAR(4),
    @clie_DireccionExacta         NVARCHAR(100),
    @clie_Telefono                NVARCHAR(15),
    @clie_CorreoElectronico       NVARCHAR(200),
    @clie_UsuCreacion			  INT
AS
BEGIN
	BEGIN TRY
		
		IF NOT EXISTS (SELECT * FROM [maqu].[tbClientes]
						WHERE @clie_Identidad = clie_Identidad)
		BEGIN
			INSERT INTO [maqu].[tbClientes](clie_Nombres, 
                                    clie_Apellidos, clie_Identidad, 
                                    clie_Sexo, muni_Id, 
                                    clie_DireccionExacta, clie_Telefono, 
                                    clie_CorreoElectronico, clie_UsuCreacion)
			VALUES(@clie_Nombres,@clie_Apellidos,
					@clie_Identidad,
					@clie_Sexo,@muni_Id,
					@clie_DireccionExacta,@clie_Telefono,
					@clie_CorreoElectronico,@clie_UsuCreacion)

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [maqu].[tbClientes]
						WHERE @clie_Identidad = clie_Identidad
							  AND clie_Estado = 1)
			SELECT 2
		ELSE
			BEGIN
				UPDATE [maqu].[tbClientes]
				SET clie_Estado = 1,
					clie_Nombres = @clie_Nombres,
					clie_Apellidos = @clie_Apellidos,
					clie_Identidad = @clie_Identidad,
					clie_Sexo = @clie_Sexo,
					muni_Id = @muni_Id,
					clie_DireccionExacta = @clie_DireccionExacta,
					clie_Telefono = @clie_Telefono,
					clie_CorreoElectronico = @clie_CorreoElectronico
				WHERE clie_Identidad = @clie_Identidad

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH 
END 

/*Editar Cliente*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbClientes_Update
    @clie_Id                    INT,
    @clie_Nombres                NVARCHAR(200),
    @clie_Apellidos                NVARCHAR(200),
    @clie_Identidad                NVARCHAR(13),
    @clie_Sexo                    CHAR,
    @muni_Id                        CHAR(4),
    @clie_DireccionExacta        NVARCHAR(100),
    @clie_Telefono                NVARCHAR(15),
    @clie_CorreoElectronico        NVARCHAR(200),
    @clie_UsuModificacion        INT
AS
BEGIN
	
	BEGIN TRY
	IF NOT EXISTS (SELECT * FROM [maqu].[tbClientes]
						WHERE @clie_Identidad = clie_Identidad)
		BEGIN	
			UPDATE [maqu].[tbClientes]
					   SET clie_Nombres = @clie_Nombres,
						clie_Apellidos = @clie_Apellidos,
						clie_Identidad = @clie_Identidad,
						clie_Sexo = @clie_Sexo,
						muni_Id = @muni_Id,
						clie_DireccionExacta = @clie_DireccionExacta,
						clie_Telefono = @clie_Telefono,
						clie_CorreoElectronico = @clie_CorreoElectronico,
						clie_UsuModificacion = @clie_UsuModificacion,
						clie_FechaModificacion = GETDATE()
				WHERE   clie_Id = @clie_Id	
			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [maqu].[tbClientes]
						WHERE @clie_Identidad = clie_Identidad
							  AND clie_Estado = 1
							  AND clie_Id != @clie_Id)
			SELECT 2
		ELSE
			BEGIN
				UPDATE [maqu].[tbClientes]
				SET clie_Estado = 1,
				    clie_UsuCreacion = @clie_UsuModificacion,
					clie_Nombres = @clie_Nombres,
					clie_Apellidos = @clie_Apellidos,
					clie_Identidad = @clie_Identidad,
					clie_Sexo = @clie_Sexo,
					muni_Id = @muni_Id,
					clie_DireccionExacta = @clie_DireccionExacta,
					clie_Telefono = @clie_Telefono,
					clie_CorreoElectronico = @clie_CorreoElectronico
				WHERE clie_Identidad = @clie_Identidad

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Eliminar Cliente*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbClientes_Delete
	@clie_Id INT
AS
BEGIN
	
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM [maqu].[tbFacturas] WHERE clie_Id = @clie_Id AND fact_Estado = 1)
			BEGIN
				UPDATE [maqu].[tbClientes] 
				SET clie_Estado = 0
				WHERE clie_Id = @clie_Id
				
				SELECT 1
			END
		ELSE
			SELECT 2
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Listar Clientes*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbClientes_List
AS
BEGIN
    SELECT [clie_Id],
		   [clie_Nombres], 
           [clie_Apellidos], 
           [clie_Identidad],
           CASE [clie_Sexo] WHEN 'F' THEN 'Femenino'
                            ELSE 'Masculino'
           END AS clie_Sexo
    FROM [maqu].[tbClientes]
    WHERE [clie_Estado] = 1
END
GO

EXECUTE maqu.UDP_maqu_tbClientes_Insert 'Christopher','Aguilar','0501200414817','M','0501','calle 1','99122657','chris@gmail.com',1
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Hugo', 'Pérez', '0501199409876', '1994-01-01', 'M', 2, '0101',1, 'Calle de la Montaña 123', '99988877', 'hugo@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Lucía', 'Rodríguez', '0501199901234', '1999-01-01', 'F', 3, '0102',1, 'Avenida del Sol 456', '88877766', 'lucia@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Max', 'Hernández', '0501188809876', '1988-01-01', 'M', 4, '0203',1, 'Calle de la Luna 789', '77766655', 'max@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Ana', 'González', '0501198504321', '1985-01-01', 'F', 1, '0304',1, 'Calle del Mar 1011', '66655544', 'ana@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Javier', 'Gómez', '0501198008765', '1980-01-01', 'M', 2, '0204',1, 'Calle del Río 1213', '55544433', 'javier@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Mónica', 'Pérez', '0501197912345', '1979-01-01', 'F', 3, '0701',1, 'Avenida del Bosque 1415', '44433322', 'monica@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Diego', 'Sánchez', '0501197609876', '1976-01-01', 'M', 4, '0506',1, 'Calle de la Playa 1617', '33322211', 'diego@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Valeria', 'López', '0501197304321', '1973-01-01', 'F', 1, '1001',1, 'Calle de las Flores 1819', '22211100', 'valeria@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'Carlos', 'Díaz', '0501197008765', '1970-01-01', 'M', 2, '1002',1, 'Avenida del Aire 2021', '11100099', 'carlos@mail.com', 1;
EXEC maqu.UPD_maqu_tbEmpleados_Insert 'María', 'Ramírez', '0501196701234', '1967-01-01', 'F', 3, '0802',1, 'Calle de la Primavera 2223', '00099988', 'maria@mail.com', 1;

--*********Facturas*************-
/*Listado Factura*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbFacturas_Listado
AS
BEGIN
	SELECT * FROM maqu.VW_tbFacturas_List
END

GO
CREATE OR ALTER VIEW maqu.VW_tbFacturas_List
AS
	SELECT [fact_Id], 
			(T2.clie_Nombres + ' ' + t2.clie_Apellidos) AS clie_Nombres,
			(T3.empe_Nombres + ' ' + T3.empe_Apellidos) AS empe_Nombres,
			T4.meto_Nombre,
			fact_Fecha,t3.sucu_Id,
			T5.user_NombreUsuario AS user_UsuCreacion,
			T6.user_NombreUsuario AS user_UsuModificacion,
			fact_FechaCreacion,
			fact_FechaModificacion
	FROM [maqu].[tbFacturas] T1 INNER JOIN [maqu].[tbClientes] T2
	ON T1.clie_Id = T2.clie_Id INNER JOIN [maqu].[tbEmpleados] T3
	ON T1.empe_Id = T3.empe_Id INNER JOIN [maqu].[tbMetodosPago] T4
	ON T1.meto_Id = T4.meto_Id INNER JOIN [acce].[tbUsuarios] T5
	ON T1.fact_UsuCreacion = T5.user_Id LEFT JOIN [acce].[tbUsuarios] T6
	ON T1.fact_UsuModificacion = t6.user_Id INNER JOIN maqu.tbSucursales sucu
	ON t3.sucu_Id =  sucu.sucu_Id

/*Insertar Factura*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbFacturas_Insert
	@clie_Id INT,
	@meto_Id INT,
	@empe_Id INT,
	@fact_usuCreacion INT
AS
BEGIN
	BEGIN TRY
		INSERT INTO [maqu].[tbFacturas](clie_Id, fact_Fecha, 
					meto_Id, empe_Id, 
					fact_UsuCreacion)
		VALUES(@clie_Id,GETDATE(),
				@meto_Id,@empe_Id,
				@fact_usuCreacion)

		SELECT SCOPE_IDENTITY()
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Editar Factura*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbFacturas_Update
	@clie_Id INT,
	@meto_Id INT,
	@fact_UsuModificacion INT,
	@fact_Id INT
AS
BEGIN
UPDATE [maqu].[tbFacturas]
	SET clie_Id = @clie_Id,
		meto_Id = @meto_Id,
		fact_UsuModificacion = @fact_UsuModificacion,
		fact_FechaModificacion = GETDATE()
	WHERE fact_Id = fact_Id
END

/*Listado de factura con sus detalles*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbFacturasDetalles_Listado 
	@fact_Id INT
AS
BEGIN
	SELECT * FROM maqu.VW_tbFacturasDetalles_List WHERE [fact_Id] = @fact_Id
END

GO
CREATE OR ALTER VIEW maqu.VW_tbFacturasDetalles_List
AS
	SELECT T1.factdeta_Id,
		   [fact_Id], 
		   T2.prod_Id,
		   T2.prod_Nombre,
		   T2.cate_Id,
		   T1.factdeta_Cantidad,
		   factdeta_Precio,
		   (T1.factdeta_Cantidad*factdeta_Precio) AS factdeta_PrecioTotal
	FROM [maqu].[tbFacturasDetalles] T1 INNER JOIN [maqu].[tbProductos] T2
	ON T1.prod_Id = T2.prod_Id
	WHERE [factdeta_Estado] = 1

/*Insertar factura detalles*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbFacturasDetalles_Insert 
	@fact_Id				INT,
	@prod_Id				INT,
	@factdeta_Cantidad		INT,
	@factdeta_UsuCreacion	INT
AS
BEGIN
	BEGIN TRY
		DECLARE @factdeta_Precio DECIMAL(18,2) = (SELECT [prod_PrecioUni] FROM [maqu].[tbProductos] WHERE prod_Id = @prod_Id)

		INSERT INTO [maqu].[tbFacturasDetalles](fact_Id, 
												prod_Id, 
												factdeta_Cantidad, 
												factdeta_Precio, 
												factdeta_UsuCreacion)
		VALUES(@fact_Id, @prod_Id, @factdeta_Cantidad, @factdeta_Precio, @factdeta_UsuCreacion)
		SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Eliminar factura detalles*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbFacturasDetalles_Delete 
	@factdeta_Id	INT
AS
BEGIN
	BEGIN TRY
		DELETE 
		FROM [maqu].[tbFacturasDetalles]
		WHERE factdeta_Id = @factdeta_Id
		SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Eliminar factura detalles*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbFacturasDetalles_Update 
	@factdeta_Id				INT,
	@prod_Id					INT,
	@factdeta_Cantidad			INT,
	@factdeta_UsuModificacion	INT
AS
BEGIN
	BEGIN TRY
		DECLARE @factdeta_Precio DECIMAL(18,2) = (SELECT [prod_PrecioUni] FROM [maqu].[tbProductos] WHERE prod_Id = @prod_Id)

		UPDATE [maqu].[tbFacturasDetalles]
		SET [prod_Id] = @prod_Id,
			[factdeta_Cantidad] = @factdeta_Cantidad,
			[factdeta_Precio] = @factdeta_Precio,
			[factdeta_UsuModificacion] = @factdeta_UsuModificacion
		WHERE [factdeta_Id] = @factdeta_Id

		SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END


/*Eliminar Factura con sus Detalles*/
--GO
--CREATE OR ALTER PROCEDURE UDP_maqu_tbFacturas_Delete
--@fact_Id INT
--AS
--BEGIN
--	--Borrado Logico de la factura
--	UPDATE [maqu].[tbFacturas] 
--	SET fact_Estado = 0 
--	WHERE fact_Id = @fact_Id

--	--Borrado de las facturas detalles por fact_Id
--	DELETE FROM maqu.tbFacturasDetalles WHERE fact_Id = @fact_Id
--END


--**********************Listar Productos***************************--

/*Vista Productos*/
GO
CREATE OR ALTER VIEW maqu.VW_maqu_tbProductos_VW
AS
SELECT prod_Id, prod_Nombre, 
prod_PrecioUni, prod.cate_Id, 
cate.cate_Nombre,prod.prov_Id,
prov.prov_Nombre,prod_Stock,
prod_UsuCreacion,[user1].user_NombreUsuario AS user_UsuCreacion_Nombre,
prod_FechaCreacion, prod_FechaModificacion, 
prod_UsuModificacion,[user2].user_NombreUsuario AS user_UsuModificacion_Nombre, prod_Estado
FROM maqu.tbProductos prod INNER JOIN maqu.tbCategorias cate
ON prod.cate_Id = cate.cate_Id INNER JOIN maqu.tbProveedores prov
ON prod.prov_Id = prov.prov_Id INNER JOIN acce.tbUsuarios [user1]
ON prod.prod_UsuCreacion = [user1].user_Id LEFT JOIN acce.tbUsuarios [user2]
ON prod.prod_UsuModificacion = [user2].user_Id
WHERE prod.prod_Estado = 1

/*Listar Producos View*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbProductos_List_View 
AS
BEGIN
SELECT *FROM VW_maqu_tbProductos_VW
END
/*Insertar Productos*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbProductos_Insert 
	@prod_Nombre			NVARCHAR(100),
	@prod_PrecioUni			DECIMAL (18,2),
	@cate_Id				INT,
	@prov_Id				INT,
	@prod_Stock				INT,
	@prod_UsuCreacion		INT
AS
BEGIN
	BEGIN TRY
		
		IF NOT EXISTS (SELECT * FROM [maqu].[tbProductos]
						WHERE prod_Nombre = @prod_Nombre)
		BEGIN
			
			INSERT INTO [maqu].[tbProductos](prod_Nombre, 
						prod_PrecioUni, cate_Id, 
						prov_Id, prod_Stock, 
						prod_UsuCreacion)
			VALUES(@prod_Nombre,@prod_PrecioUni,
					@cate_Id,@prov_Id,
					@prod_Stock,@prod_UsuCreacion)

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [maqu].[tbProductos]
						WHERE prod_Nombre = @prod_Nombre
						AND prod_Estado = 1)
			SELECT 2
		ELSE
			BEGIN
				UPDATE [maqu].[tbProductos]
				SET prod_Estado = 1,
					prod_PrecioUni = @prod_PrecioUni,
					cate_Id = @cate_Id,
					prod_Stock = @prod_Stock,
					prov_Id = @prov_Id
				WHERE prod_Nombre = @prod_Nombre

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH 

END

/*Editar Producto*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbProducto_Update
	@prod_Id				INT,
	@prod_Nombre			NVARCHAR(100),
	@prod_PrecioUni			DECIMAL(18,2),
	@cate_Id				INT,
	@prov_Id				INT,
	@prod_Stock				INT,
	@prod_UsuModificacion   INT
AS
BEGIN

	BEGIN TRY
	IF NOT EXISTS (SELECT * FROM [maqu].[tbProductos]
						WHERE @prod_Nombre = prod_Nombre)
		BEGIN			
			UPDATE [maqu].[tbProductos]
			SET prod_Nombre = @prod_Nombre,
				prod_PrecioUni = @prod_PrecioUni,
				cate_Id = @cate_Id,
				prov_Id = @prov_Id,
				prod_Stock = @prod_Stock,
				prod_UsuModificacion = @prod_UsuModificacion,
				prod_FechaModificacion = GETDATE()
			WHERE prod_Id = @prod_Id

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [maqu].[tbProductos]
						WHERE @prod_Nombre = prod_Nombre
							  AND prod_Estado = 1
							  AND prod_Id != @prod_Id)
			SELECT 2
		ELSE
			BEGIN
				UPDATE [maqu].[tbProductos]
				SET prod_Estado = 1,
				    prod_UsuModificacion = @prod_UsuModificacion,
					prod_PrecioUni = @prod_PrecioUni,
					cate_Id = @cate_Id,
					prov_Id = @prov_Id,
					prod_Stock = @prod_Stock,
					prod_FechaModificacion = GETDATE()
				WHERE prod_Nombre = @prod_Nombre

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Eliminar Producto*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbProductos_Delete 
	@prod_Id INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM [maqu].[tbFacturasDetalles] WHERE prod_Id = @prod_Id)
			BEGIN
				UPDATE [maqu].[tbProductos]
				SET prod_Estado = 0
				WHERE prod_Id = @prod_Id
				
				SELECT 1
			END
		ELSE
			SELECT 2
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Listado prod_Id x cate_Id*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbProductos_ListDDL
	@cate_Id	INT
AS
BEGIN
	SELECT [prod_Id], [prod_Nombre], [prod_PrecioUni]
	FROM [maqu].[tbProductos]
	WHERE [cate_Id] = @cate_Id
	AND [prod_Estado] = 1
END

/*Precio de producto*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbProductos_Precios 
	@prod_Id	INT
AS
BEGIN
	SELECT [prod_Id], [prod_Nombre], [prod_PrecioUni]
	FROM [maqu].[tbProductos]
	WHERE @prod_Id = [prod_Id]
END

--**************Proveedores************************--
/*Vista Proveedores*/
GO
CREATE OR ALTER VIEW maqu.VW_maqu_tbProveedores_VW
AS
SELECT prov_Id, prov_Nombre, 
prov_CorreoElectronico, prov_Telefono, 
prov_UsuCreacion,[user1].user_NombreUsuario AS prov_UsuCreacion_Nombre,prov_FechaCreacion, 
prov_UsuModificacion,[user2].user_NombreUsuario AS prov_UsuModificacion_Nombre, prov_FechaModificacion, 
prov_Estado
FROM maqu.tbProveedores prov INNER JOIN acce.tbUsuarios [user1]
ON prov.prov_UsuCreacion = [user1].user_Id LEFT JOIN acce.tbUsuarios [user2]
ON prov.prov_UsuModificacion = [user2].user_Id
WHERE prov.prov_Estado = 1

/*Vista proveedores UDP*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbProveedores_VW
AS
BEGIN
SELECT * FROM VW_maqu_tbProveedores_VW
END

/*Insertar Proveedores*/
GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbProveedores_Insert
	@prov_Nombre					NVARCHAR(200),
	@prov_CorreoElectronico			NVARCHAR(150),
	@prov_Telefono					NVARCHAR(15),
	@prov_UsuCreacion				INT
AS
BEGIN
	BEGIN TRY
		
		IF NOT EXISTS (SELECT * FROM [maqu].[tbProveedores]
						WHERE @prov_Nombre = prov_Nombre)
		BEGIN
			INSERT INTO [maqu].[tbProveedores](prov_Nombre, prov_CorreoElectronico, 
						prov_Telefono, prov_UsuCreacion)
			VALUES(@prov_Nombre,@prov_CorreoElectronico,
					@prov_Telefono,@prov_UsuCreacion)

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM [maqu].[tbProveedores]
						WHERE @prov_Nombre = prov_Nombre
							  AND prov_Estado = 1)
			SELECT 2
		ELSE
			BEGIN
				UPDATE [maqu].[tbProveedores]
				SET [prov_Estado] = 1,
					prov_CorreoElectronico = @prov_CorreoElectronico,
					prov_Telefono = @prov_Telefono
				WHERE prov_Nombre = @prov_Nombre

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH 
END

/*Editar proveedores*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbProveedores_Update
	@prov_Id					INT,
	@prov_Nombre				NVARCHAR(100),
	@prov_CorreoElectronico		NVARCHAR(150),
	@prov_Telefono				NVARCHAR(15),
	@prov_UsuModificacion		INT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM [maqu].[tbProveedores]
							WHERE @prov_Nombre = prov_Nombre)
			BEGIN			
				UPDATE [maqu].[tbProveedores]
				SET prov_Nombre = @prov_Nombre,
					prov_CorreoElectronico = @prov_CorreoElectronico,
					prov_Telefono = @prov_Telefono,
					prov_UsuModificacion = @prov_UsuModificacion,
					prov_FechaModificacion = GETDATE()
				WHERE prov_Id = @prov_Id
			END
			ELSE IF EXISTS (SELECT * FROM [maqu].[tbProveedores]
							WHERE @prov_Nombre = prov_Nombre
								  AND prov_Estado = 1
								  AND prov_Id != @prov_Id)
				SELECT 2
			ELSE
				BEGIN
					UPDATE [maqu].[tbProveedores]
					SET prov_Estado = 1,
					    prov_UsuModificacion = @prov_UsuModificacion,
						prov_CorreoElectronico = @prov_CorreoElectronico,
						prov_Telefono = @prov_Telefono
					WHERE prov_Nombre = @prov_Nombre

					SELECT 1
				END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH 
END

/*Eliminar Proveedores*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbProveedores_DELETE 
	@prov_Id INT
AS
BEGIN

	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM [maqu].[tbProductos] WHERE prov_Id = @prov_Id AND prod_Estado = 1)
			BEGIN
				UPDATE [maqu].tbProveedores
				SET prov_Estado = 0
				WHERE prov_Id = @prov_Id
				
				SELECT 1
			END
		ELSE
			SELECT 2
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

--************Roles**************************--
GO
CREATE OR ALTER PROCEDURE acce.UDP_acce_tbRoles_List
AS
BEGIN
SELECT * FROM acce.tbRoles
END
--************USUARIOS******************--
SELECT * FROM acce.tbUsuarios

/*Insertar Usuarios*/
GO
CREATE OR ALTER PROCEDURE acce.UDP_acce_tbUsuarios_Insert
	@user_NombreUsuario NVARCHAR(150),
	@user_Contrasena NVARCHAR(MAX),
	@user_EsAdmin BIT,
	@role_Id INT, 
	@empe_Id INT,
	@user_usuCreacion INT
AS 
BEGIN
	
	BEGIN TRY
		
		DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @user_Contrasena));

		IF NOT EXISTS (SELECT * FROM acce.tbUsuarios
						WHERE @user_NombreUsuario = user_NombreUsuario)
		BEGIN
			INSERT INTO acce.tbUsuarios
			VALUES(@user_NombreUsuario,@password,@user_EsAdmin,@role_Id,@empe_Id,@user_usuCreacion,GETDATE(),NULL,NULL,1)

			SELECT 1
		END
		ELSE IF EXISTS (SELECT * FROM acce.tbUsuarios
						WHERE @user_NombreUsuario = user_NombreUsuario
							  AND user_Estado = 1)
			SELECT 2
		ELSE
			BEGIN
				UPDATE acce.tbUsuarios
				SET user_Estado = 1,
					user_Contrasena = @password,
					user_EsAdmin = @user_EsAdmin,
					role_Id = @role_Id,
					empe_Id = @empe_Id
				WHERE user_NombreUsuario = @user_NombreUsuario

				SELECT 1
			END
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH 
END

/*Listar Usuarios*/
GO
CREATE OR ALTER PROCEDURE acce.UDP_acce_tbUsuarios_List
AS
BEGIN
SELECT * FROM acce.tbUsuarios
END

/*Editar usuarios*/
GO
CREATE OR ALTER PROCEDURE acce.UDP_acce_tbUsuarios_UPDATE
	@user_Id					INT,
	@user_EsAdmin				BIT,
	@role_Id					INT,
	@empe_Id					INT,
	@user_UsuModificacion		INT
AS
BEGIN
	BEGIN TRY
		UPDATE acce.tbUsuarios
		SET user_EsAdmin = @user_EsAdmin,
			role_Id = @role_Id,
			empe_Id = @empe_Id,
			user_UsuModificacion = @user_UsuModificacion,
			user_FechaModificacion = GETDATE()
		WHERE user_Id = @user_Id

		SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Eliminar usuarios*/
GO
CREATE OR ALTER PROCEDURE acce.UDP_acce_tbUsuarios_DELETE
	@user_Id	INT
AS
BEGIN
	BEGIN TRY
		UPDATE acce.tbUsuarios
		SET user_Estado = 0
		WHERE user_Id = @user_Id

		SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

GO
/*UDP para vista de usuarios*/
GO
CREATE OR ALTER PROCEDURE acce.UDP_acce_tbUsuarios_View 
@user_Id INT
AS
BEGIN
SELECT * FROM acce.VW_acce_tbUsuarios_View WHERE user_Id = @user_Id
END

/*Vista usuarios*/
GO
CREATE OR ALTER VIEW acce.VW_acce_tbUsuarios_View
AS
SELECT t1.user_Id, t1.user_NombreUsuario, 
t1.user_Contrasena, t1.user_EsAdmin, 
t1.role_Id,t2.role_Nombre, t1.empe_Id,(SELECT t3.empe_Nombres + ' '+ empe_Apellidos) AS empe_NombreCompleto, 
t1.user_UsuCreacion, t4.user_NombreUsuario AS user_UsuCreacion_Nombre,t1.user_FechaCreacion, 
t1.user_UsuModificacion,t5.user_NombreUsuario AS user_UsuModificacion_Nombre, t1.user_FechaModificacion,
t1.user_Estado,sucu_Id FROM acce.tbUsuarios t1 INNER JOIN acce.tbRoles t2
ON t1.role_Id = t2.role_Id
INNER JOIN maqu.tbEmpleados t3
ON t3.empe_Id = t1.empe_Id 
INNER JOIN acce.tbUsuarios t4
ON t1.user_UsuCreacion = T4.user_Id
LEFT JOIN acce.tbUsuarios t5
ON t1.user_UsuModificacion = t5.user_Id

--************INICIAR SESIÓN******************--
/*Cambiar Contrasena*/
GO
CREATE OR ALTER PROCEDURE UDP_RecuperarContrasena
	@user_NombreUsuario	NVARCHAR(100),
	@user_Contrasena	NVARCHAR(100)
AS
BEGIN
	DECLARE @user_ContrasenaEncript NVARCHAR(MAX) = HASHBYTES('SHA2_512', @user_Contrasena)
	IF EXISTS (SELECT user_NombreUsuario FROM acce.tbUsuarios WHERE user_NombreUsuario = @user_NombreUsuario)
	BEGIN
	UPDATE acce.tbUsuarios 
	SET user_Contrasena = @user_ContrasenaEncript
	WHERE user_NombreUsuario = @user_NombreUsuario
	SELECT 1
	END
	ELSE
	BEGIN
	SELECT 0
	END
END

/*Login*/
GO
CREATE OR ALTER PROCEDURE UDP_Login 
	@user_NombreUsuario	NVARCHAR(100),
	@user_Contrasena	NVARCHAR(100)
AS
BEGIN
	DECLARE @user_ContrasenaEncript NVARCHAR(MAX) = HASHBYTES('SHA2_512', @user_Contrasena)

	SELECT user_NombreUsuario,[empe_Nombres], [empe_Apellidos], [role_Id], [user_id],user_EsAdmin,t1.empe_Id,sucu_Id
	FROM [acce].[tbUsuarios] T1 INNER JOIN [maqu].[tbEmpleados] T2
	ON T1.empe_Id = T2.empe_Id 
	WHERE [user_NombreUsuario] = @user_NombreUsuario
	AND [user_Contrasena] = @user_ContrasenaEncript
END

GO
EXEC UDP_maqu_tbCategorias_INSERT 'Base de maquillaje', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Corrector de maquillaje', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Iluminador', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Brochas de maquillaje', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Pintalabios', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Pintalabios mate', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Pintalabios líquido', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Brillo de labios', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Perfilador de labios', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Sombra de ojos', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Máscara de pestañas', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Eyeliner', 1
EXEC UDP_maqu_tbCategorias_INSERT 'Diseño de cejas', 1

GO
EXEC acce.UDP_acce_tbUsuarios_UPDATE 1, 1, 1, 1, 1

GO
INSERT INTO [acce].[tbRoles]([role_Nombre], [role_UsuCreacion])
VALUES ('Inventario', 1),
	   ('Recursos Humanos', 1)

INSERT INTO [acce].[tbPantallasPorRoles] ([role_Id], [pant_Id], [pantrole_UsuCreacion])
VALUES (1, 8, 1),
	   (1, 9, 1),
	   (1, 6, 1),
	   (2, 5, 1),
	   (2, 10, 1),
	   (2, 11, 1),
	   (3, 7, 1),
	   (3, 12, 1),
	   (3, 4, 1),
	   (3, 6, 1)

GO
EXEC maqu.UDP_maqu_tbProveedores_Insert 'LOréal Paris', 'contact@loreal.com', '1-800-322-2036', 1
EXEC maqu.UDP_maqu_tbProveedores_Insert 'Kylie Cosmetics', 'customerservice@kyliecosmetics.com', '833-545-9543', 1
EXEC maqu.UDP_maqu_tbProveedores_Insert 'Armani Beauty', 'contact@giorgioarmanibeauty.fr', '0800-5870829', 1
EXEC maqu.UDP_maqu_tbProveedores_Insert 'Hourglass Cosmetics', 'CS@hourglasscosmetics.com', '855-846-3814', 1
EXEC maqu.UDP_maqu_tbProveedores_Insert 'Fenty Beauty', 'customerservice@fentybeauty.com', '1-855-440-7474', 1

GO
EXEC maqu.UDP_maqu_tbProductos_Insert 'Base de maquillaje con acido hialuronico L’Oréal Accord Parfait: 1W ivoire', 299.09, 1, 1, 250, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'Base en polvo con ácido hialurónico L’Oréal Accord Parfait: 3D Beige Dore', 294.56, 1, 1, 250, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'Better Than Sex Eyeliner', 728.33, 12, 5, 250, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'Perfect Strokes', 598.23, 12, 5, 250, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'forever and always', 390.32, 9, 2, 150, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'iced latte', 390.32, 9, 2, 150, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'give me a kiss', 390.32, 9, 2, 150, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'caramel', 390.32, 9, 2, 150, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'souffle', 390.32, 9, 2, 150, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'Glow Mon Amour gotas iluminadoras Loving Peach', 552.32, 3, 1, 50, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'Lip Maestro', 936.76, 6, 3, 125, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'Ecstasy Lacquer', 564.66, 8, 3, 125, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'Powder Brush', 1639.33, 4, 3, 25, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'Concealer Brush', 1431.16, 4, 3, 35, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'POWER FABRIC BASE LÍQUIDA DE COBERTURA TOTAL', 702.57, 1, 3, 50, 1
EXEC maqu.UDP_maqu_tbProductos_Insert 'POWER FABRIC HIGH COVERAGE LIQUID CONCEALER', 637.52, 2, 3, 50, 1

GO
EXEC maqu.UDP_maqu_tbMetodosPago_INSERT 'Tarjeta', 1
EXEC maqu.UDP_maqu_tbMetodosPago_INSERT 'Cheque', 1

EXEC maqu.UDP_maqu_tbFacturas_Insert 1, 1, 1, 1

INSERT INTO [maqu].[tbFacturasDetalles]([fact_Id], [prod_Id], [factdeta_Cantidad], [factdeta_Precio], [factdeta_UsuCreacion])
VALUES (1, 1, 2, 299.09, 1)


----------------------------------------------------------------------------------------
GO
CREATE OR ALTER TRIGGER maqu.trg_AumentarStockluegoBorrar
   ON  [maqu].[tbFacturasDetalles]
   AFTER Delete
AS 
BEGIN
	DECLARE @NuevoStock int = (SELECT t1.prod_Stock 
								FROM [maqu].[tbProductos] AS t1 
								WHERE t1.prod_Id = (SELECT t1.prod_Id 
													FROM deleted AS t1)) + (SELECT t1.[factdeta_Cantidad] 
																			FROM deleted AS t1 WHERE t1.prod_Id = (SELECT t1.prod_Id FROM deleted AS t1))

	UPDATE [maqu].[tbProductos]
	   SET [prod_Stock] = @NuevoStock
	 WHERE prod_Id = (SELECT t1.prod_Id FROM deleted AS t1)
END
GO

-------------------------------------------------------------------------------------------

GO
CREATE OR ALTER TRIGGER maqu.trg_DisminuirStock
   ON  [maqu].[tbFacturasDetalles]
   AFTER INSERT
AS 
BEGIN

	DECLARE @NuevoStock INT = (SELECT t1.prod_Stock 
								FROM [maqu].[tbProductos] AS t1 
								WHERE t1.prod_Id = (SELECT t1.prod_Id 
													FROM inserted AS t1)) - (SELECT t1.factdeta_Cantidad 
																			 FROM inserted AS t1 
																			 WHERE t1.prod_Id = (SELECT t1.prod_Id 
																								FROM inserted AS t1))

	UPDATE [maqu].[tbProductos]
	   SET [prod_Stock] = @NuevoStock
	 WHERE prod_Id = (SELECT t1.prod_Id FROM inserted AS t1)

END
GO

GO
CREATE OR ALTER TRIGGER maqu.trg_StockAfterUpdate
	ON [maqu].[tbFacturasDetalles]
	AFTER UPDATE
AS
BEGIN
	UPDATE [maqu].[tbProductos]
	SET [prod_Stock] = [prod_Stock] + (SELECT factdeta_Cantidad FROM deleted)
	WHERE prod_Id = (SELECT prod_Id FROM deleted)

	UPDATE [maqu].[tbProductos]
	SET [prod_Stock] = [prod_Stock] - (SELECT factdeta_Cantidad FROM inserted)
	WHERE prod_Id = (SELECT prod_Id FROM inserted)
END

GO
CREATE OR ALTER PROCEDURE maqu.UDP_maqu_tbFacturas_RevisarStock 
	@prod_Stock	INT,
	@prod_Id	INT
AS
BEGIN
	DECLARE @stockRestante INT = (SELECT prod_Stock FROM maqu.tbProductos WHERE prod_Id = @prod_Id) - @prod_Stock

	IF @stockRestante < 0
		SELECT 0
	ELSE
		SELECT 1
END

GO
CREATE OR ALTER PROCEDURE acce.tbRolesPorPantalla 
	@role_Id	INT,
	@esAdmin	BIT,
	@pant_Id	INT
AS
BEGIN
	IF @esAdmin = 1
		SELECT 1
	ELSE IF EXISTS (SELECT * FROM [acce].[tbPantallasPorRoles] WHERE [role_Id] = @role_Id AND [pant_Id] = @pant_Id)
		SELECT 1
	ELSE
		SELECT 0
END

GO 
CREATE OR ALTER PROCEDURE acce.tbRolesPorPantallaMenu
	@role_Id	INT,
	@esAdmin	BIT
AS
BEGIN
	IF @esAdmin = 1
		BEGIN
			SELECT DISTINCT pant_Id, pant_Nombre, pant_Url, pant_Menu, pant_HtmlId, @role_Id AS role_Id, @esAdmin AS esAdmin
			FROM [acce].[tbPantallas] 
		END
	ELSE
		SELECT DISTINCT T1.pant_Id, pant_Nombre, pant_Url, pant_Menu, pant_HtmlId, @role_Id AS role_Id, @esAdmin AS esAdmin
		FROM [acce].[tbPantallas] T1 INNER JOIN [acce].[tbPantallasPorRoles] T2
		ON T1.pant_Id = T2.pant_Id
		WHERE role_Id = @role_Id
END