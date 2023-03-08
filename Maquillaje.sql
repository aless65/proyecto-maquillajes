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


--***********CREACION TABLA PANTALLAS*****************---
CREATE TABLE acce.tbPantallas(
	pant_Id					INT IDENTITY,
	pant_Nombre				NVARCHAR(100) NOT NULL,
	pant_UsuCreacion		INT NOT NULL,
	pant_FechaCreacion		DATETIME NOT NULL CONSTRAINT DF_pant_FechaCreacion DEFAULT(GETDATE()),
	pant_UsuModificacion	INT,
	pant_FechaModificacion	DATETIME,
	pant_Estado				BIT NOT NULL CONSTRAINT DF_pant_Estado DEFAULT(1)
	CONSTRAINT PK_acce_tbPantallas_pant_Id PRIMARY KEY(pant_Id)
);
GO

INSERT INTO acce.tbPantallas(pant_Nombre, pant_UsuCreacion)
VALUES ('Usuarios', 1),
       ('Departamentos', 1),
	   ('Municipios', 1),
	   ('Categorías', 1),
	   ('Clientes', 1),
	   ('Empleados', 1),
	   ('Facturas', 1),
	   ('Facturas detalles', 1),
	   ('Métodos de pago', 1),
	   ('Productos', 1),
	   ('Proveedores', 1)


--***********CREACION TABLA ROLES/PANTALLA*****************---
CREATE TABLE acce.tbPantallasPorRoles(
	pantrole_Id					INT IDENTITY,
	pantrole_Identificador		NVARCHAR(100) NOT NULL,
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
CREATE OR ALTER PROCEDURE UDP_InsertUsuario
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
EXEC UDP_InsertUsuario 'aless65', 'bonjour', 1, NULL, 1;


--********* ALTERAR TABLA ROLES **************--
--********* AGREGAR CAMPOS AUDITORIA**************--
GO
ALTER TABLE acce.tbRoles
ADD CONSTRAINT FK_acce_tbRoles_acce_tbUsuarios_role_UsuCreacion_user_Id 	FOREIGN KEY(role_UsuCreacion) REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_acce_tbRoles_acce_tbUsuarios_role_UsuModificacion_user_Id 	FOREIGN KEY(role_UsuModificacion) REFERENCES acce.tbUsuarios(user_Id);




GO
INSERT INTO acce.tbRoles(role_Nombre, role_UsuCreacion)
VALUES ('Recursos humanos', 1),
	   ('Vendedor', 1)




--********* ALTERAR TABLA USUARIOS **************--
--********* AGREGAR CAMPO ROL, AUDITORIA**************--
GO
ALTER TABLE [acce].[tbUsuarios]
ADD CONSTRAINT FK_acce_tbUsuarios_acce_tbUsuarios_user_UsuCreacion_user_Id  FOREIGN KEY(user_UsuCreacion) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbUsuarios_acce_tbUsuarios_user_UsuModificacion_user_Id  FOREIGN KEY(user_UsuModificacion) REFERENCES acce.tbUsuarios([user_Id]),
	CONSTRAINT FK_acce_tbUsuarios_acce_tbRoles_role_Id FOREIGN KEY(role_Id) REFERENCES acce.tbRoles(role_Id)


GO
INSERT INTO [acce].[tbPantallas](pant_Nombre, pant_UsuCreacion)
VALUES('Departamentos', 1),
	  ('Municipios', 1),
	  ('Categor�as', 1)


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

	CONSTRAINT PK_maqu_tbCategorias_cate_Id 												PRIMARY KEY(cate_Id),
	CONSTRAINT FK_maqu_tbCategorias_acce_tbUsuarios_cate_UsuCreacion_user_Id  			FOREIGN KEY(cate_UsuCreacion) 			REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbCategorias_acce_tbUsuarios_cate_UsuModificacion_user_Id  		FOREIGN KEY(cate_UsuModificacion) 		REFERENCES acce.tbUsuarios(user_Id)
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
	CONSTRAINT FK_maqu_tbClientes_acce_tbUsuarios_clie_UsuModificacion_user_Id  FOREIGN KEY(clie_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
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

	CONSTRAINT PK_maqu_tbFacturas_fact_Id 										PRIMARY KEY(fact_Id),
	CONSTRAINT FK_maqu_tbFacturas_maqu_tbClientes_clie_Id 								FOREIGN KEY(clie_Id) 				REFERENCES maqu.tbClientes(clie_Id),
	CONSTRAINT FK_maqu_tbFacturas_maqu_tbMetodosPago_meto_Id 							FOREIGN KEY(meto_Id) 				REFERENCES maqu.tbMetodosPago(meto_Id),
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
	CONSTRAINT FK_maqu_tbFacturasDetalles_acce_tbUsuarios_factdeta_UsuCreacion_user_Id  		FOREIGN KEY(factdeta_UsuCreacion) 		REFERENCES acce.tbUsuarios(user_Id),
	CONSTRAINT FK_maqu_tbFacturasDetalles_acce_tbUsuarios_factdeta_UsuModificacion_user_Id  	FOREIGN KEY(factdeta_UsuModificacion) 	REFERENCES acce.tbUsuarios(user_Id)
);


/*
INSERT DE LA BASE DE DATOS
*/

GO
INSERT gral.tbDepartamentos(depa_Id, depa_Nombre, depa_UsuCreacion)
VALUES('01','Atl�ntida', 1),
      ('02','Col�n', 1),
	  ('03','Comayagua', 1),
	  ('04','Cop�n', 1),
	  ('05','Cort�s', 1),
	  ('06','Choluteca', 1),
	  ('07','El Para�so', 1),
	  ('08','Francisco Moraz�n', 1),
	  ('09','Gracias a Dios', 1),
	  ('10','Intibuc�', 1),
	  ('11','Islas de La Bah�a', 1),
	  ('12','La Paz', 1),
	  ('13','Lempira', 1),
	  ('14','Ocotepeque', 1),
	  ('15','Olancho', 1),
	  ('16','Santa B�rbara', 1),
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
	  ('0204','Lim�n','02', 1),
	  ('0205','Sab�','02', 1),
	  ('0301','Comayagua','03', 1),
	  ('0302','Ajuterique','03', 1),
      ('0303','El Rosario','03', 1),
	  ('0304','Esqu�as','03', 1),
      ('0305','Humuya','03', 1),
	  ('0401','Santa Rosa de Cop�n','04', 1),
	  ('0402','Caba�as','04', 1),
      ('0403','Concepci�n','04', 1),
	  ('0404','Cop�n Ruinas','04', 1),
      ('0405','Corqu�n','04', 1),
	  ('0501','San Pedro Sula ','05', 1),
      ('0502','Choloma ','05', 1),
      ('0503','Omoa','05', 1),
      ('0504','Pimienta','05', 1),
	  ('0505','Potrerillos','05', 1),
	  ('0506','Puerto Cort�s','05', 1),
	  ('0601','Choluteca','06', 1),
      ('0602','Apacilagua','06', 1),
      ('0603','Concepci�n de Mar�a','06', 1),
      ('0604','Duyure','06', 1),
	  ('0605','El Corpus','07', 1),
	  ('0701','Yuscar�n','07', 1),
      ('0702','Alauca','07', 1),
      ('0703','Danl�','07', 1),
	  ('0704','El Para�so','07', 1),
      ('0705','G�inope','07', 1),
	  ('0801','Distrito Central (Comayag�ela y Tegucigalpa)','08', 1),
      ('0802','Alubar�n','08', 1),
      ('0803','Cedros','08', 1),
      ('0804','Curar�n','08', 1),
	  ('0805','El Porvenir','08', 1),
	  ('0901','Puerto Lempira','09', 1),
      ('0902','Brus Laguna','09', 1),
      ('0903','Ahuas','09', 1),
	  ('0904','Juan Francisco Bulnes','09', 1),
      ('0905','Villeda Morales','09', 1),
	  ('1001','La Esperanza','10', 1),
      ('1002','Camasca','10', 1),
      ('1003','Colomoncagua','10', 1),
	  ('1004','Concepci�n','10', 1),
      ('1005','Dolores','10', 1),
	  ('1101','Roat�n','11', 1),
      ('1102','Guanaja','11', 1),
      ('1103','Jos� Santos Guardiola','11', 1),
	  ('1104','Utila','11', 1),
	  ('1201','La Paz','12', 1),
      ('1202','Aguanqueterique','12', 1),
      ('1203','Caba�as','12', 1),
	  ('1204','Cane','12', 1),
      ('1205','Chinacla','12', 1),
	  ('1301','Gracias','13', 1),
      ('1302','Bel�n','13', 1),
      ('1303','Candelaria','13', 1),
	  ('1304','Cololaca','13', 1),
      ('1305','Erandique','13', 1),
	  ('1401','Ocotepeque','14', 1),
      ('1402','Bel�n Gualcho','14', 1),
      ('1403','Concepci�n','14', 1),
	  ('1404','Dolores Merend�n','14', 1),
      ('1405','Fraternidad','14', 1),
	  ('1501','Juticalpa','15', 1),
      ('1502','Campamento','15', 1),
      ('1503','Catacamas','15', 1),
	  ('1504','Concordia','15', 1),
      ('1505','Dulce Nombre de Culm�','15', 1),
	  ('1601','Santa B�rbara','16', 1),
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
      ('1805','Joc�n','18', 1)


--********PROCEDIMIENTOS****************---
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbMetodosPago_INSERT
	@meto_Nombre			NVARCHAR(100),
	@meto_UsuCreacion	INT
AS
BEGIN
	INSERT INTO maqu.tbMetodosPago(meto_Nombre, meto_UsuCreacion)
	VALUES (@meto_Nombre, @meto_UsuCreacion)
END

GO
EXEC UDP_maqu_tbMetodosPago_INSERT 'Efectivo', 1


--Iniciar sesi�n
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
--Insertar estados civiles
CREATE OR ALTER PROCEDURE UDP_gral_tbEstadosCiviles_INSERT
	@estacivi_Nombre		NVARCHAR(100),
	@estacivi_UsuCreacion INT
AS
BEGIN
	INSERT INTO [gral].[tbEstadosCiviles]([estacivi_Nombre], [estacivi_UsuCreacion])
	VALUES(@estacivi_Nombre, @estacivi_UsuCreacion)
END

--Editar estados civiles
GO
CREATE OR ALTER PROCEDURE UDP_gral_tbEstadosCiviles_UPDATE
	@estacivi_Id 		INT,
	@estacivi_Nombre	NVARCHAR(100),
	@estacivi_UsuModificacion INT
AS
BEGIN
	UPDATE [gral].[tbEstadosCiviles]
	SET [estacivi_Nombre] = @estacivi_Nombre,
		[estacivi_UsuModificacion] = @estacivi_UsuModificacion,
		[estacivi_FechaModificacion] = GETDATE()
	WHERE [estacivi_Id] = @estacivi_Id
END

--Eliminar estados civiles
GO
CREATE OR ALTER PROCEDURE UDP_gral_tbEstadosCiviles_DELETE
	@estacivi_Id INT
AS
BEGIN
	UPDATE [gral].[tbEstadosCiviles]
	SET  [estacivi_Estado] = 0
	WHERE [estacivi_Id] = @estacivi_Id
END

/*Insert estados civiles*/
GO
EXECUTE UDP_gral_tbEstadosCiviles_INSERT 'Soltero(a)',1
EXECUTE UDP_gral_tbEstadosCiviles_INSERT 'Casado(a)',1
EXECUTE UDP_gral_tbEstadosCiviles_INSERT 'Union Libre',1
EXECUTE UDP_gral_tbEstadosCiviles_INSERT 'Viudo(a)',1

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
CREATE OR ALTER PROCEDURE UPD_maqu_tbEmpleados_Insert
	@empe_Nombres NVARCHAR(200),
	@empe_Apellidos NVARCHAR(200),
	@empe_Identidad NVARCHAR(13),
	@empe_FechaNacimiento DATE,
	@empe_Sexo CHAR,
	@estacivi_Id INT,
	@muni_Id NVARCHAR(4),
	@empe_Direccion NVARCHAR(200),
	@empe_Telefono NVARCHAR(15),
	@empe_CorreoElectronico NVARCHAR(200),
	@empe_UsuCreacion INT
AS
BEGIN
	INSERT INTO maqu.tbEmpleados(empe_Nombres, empe_Apellidos, 
								empe_Identidad, empe_FechaNacimiento, 
								empe_Sexo, estacivi_Id, muni_Id, 
								empe_Direccion, empe_Telefono, 
								empe_CorreoElectronico, empe_UsuCreacion)
	VALUES(@empe_Nombres,@empe_Apellidos,
			@empe_Identidad,@empe_FechaNacimiento,
			@empe_Sexo,@estacivi_Id,
			@muni_Id,@empe_Direccion,
			@empe_Telefono,@empe_CorreoElectronico,
			@empe_UsuCreacion)
END

/*Editar Empleados*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbEmpleados_Update
	@empe_Id 				INT,
	@empe_Nombres 			NVARCHAR(200),
	@empe_Apellidos 		NVARCHAR(200),
	@empe_Identidad 		NVARCHAR(13),
	@empe_FechaNacimiento 	DATE,
	@empe_Sexo 				CHAR,
	@estacivi_Id 			INT,
	@muni_Id 				NVARCHAR(4),
	@empe_Direccion 		NVARCHAR(200),
	@empe_Telefono 			NVARCHAR(15),
	@empe_CorreoElectronico NVARCHAR(200),
	@empe_usuModificacion 	INT
AS
BEGIN
	UPDATE maqu.tbEmpleados
	SET     empe_Nombres = @empe_Nombres,
			empe_Apellidos = @empe_Apellidos,
			empe_Identidad = @empe_Identidad,
			empe_FechaNacimiento = @empe_FechaNacimiento,
			empe_Sexo = @empe_Sexo,
			estacivi_Id = @estacivi_Id,
			muni_Id = @empe_Direccion,
			empe_Telefono = @empe_Telefono,
			empe_CorreoElectronico = @empe_CorreoElectronico,
			empe_UsuModificacion = @empe_usuModificacion,
			empe_FechaModificacion = GETDATE()
	WHERE 	empe_Id = @empe_Id
END

/*Eliminar Empleados*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbEmpleados_Delete
	@empe_Id INT
AS
BEGIN
	UPDATE maqu.tbEmpleados
	SET 	empe_Estado = 0
	WHERE 	empe_Id = @empe_Id
END


GO
EXEC UPD_maqu_tbEmpleados_Insert 'Alessia', 'Medina', '0501200506728', '2005-05-06', 'F', 1, '0501', 'casa', '99349019', 'aless@hootmail.com', 1

GO
ALTER TABLE acce.tbUsuarios
ADD CONSTRAINT FK_acce_tbUsuarios_maqu_tbEmpleados_empe_Id	FOREIGN KEY(empe_Id) REFERENCES maqu.tbEmpleados(empe_Id)

--**************** DEPARTAMENTOS ****************--
/*Insertar Departamentos*/
GO
CREATE OR ALTER PROCEDURE UDP_gral_tbDepartamentos_Insert
	@depa_Nombre 		NVARCHAR(100),
	@depa_UsuCreacion 	INT
AS
BEGIN
	INSERT INTO gral.tbDepartamentos(depa_Nombre, depa_UsuCreacion)
	VALUES(@depa_Nombre,@depa_UsuCreacion)
END

/*Editar Departamentos*/
GO
CREATE OR ALTER PROCEDURE UDP_gral_tbDepartamentos_UPDATE
	@depa_Id					INT,
	@depa_Nombre 				NVARCHAR(100),
	@depa_UsuModificacion 		INT
AS
BEGIN
UPDATE gral.tbDepartamentos
	SET     depa_Nombre = @depa_Nombre,
			depa_UsuModificacion = @depa_UsuModificacion,
			depa_FechaModificacion = GETDATE()
	WHERE 	depa_Id = @depa_Id
END

/*Eliminar Departamentos*/
GO
CREATE OR ALTER PROCEDURE UDP_gral_tbDepartamentos_DELETE
	@depa_Id INT
AS
BEGIN
	UPDATE gral.tbDepartamentos
	SET   depa_Estado = 0
	WHERE depa_Id = @depa_Id
END

--**************** M�TODOS DE PAGO ****************--
/*Insert m�todos de pago*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbMetodosPago_INSERT
	@meto_Nombre				NVARCHAR(100),
	@meto_UsuCreacion 		INT
AS
BEGIN
	INSERT INTO [maqu].[tbMetodosPago](meto_Nombre, meto_UsuCreacion)
	VALUES (@meto_Nombre, @meto_UsuCreacion)
END

/*Editar m�todos de pago*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbMetodosPago_UPDATE
	@meto_Id 				INT,
	@meto_Nombre			NVARCHAR(100),
	@meto_UsuModificacion 	INT
AS
BEGIN
	UPDATE [maqu].[tbMetodosPago]
	SET     [meto_Nombre] = @meto_Nombre,
			[meto_UsuModificacion] = @meto_UsuModificacion,
			[meto_FechaModificacion] = GETDATE()
	WHERE 	[meto_Id] = @meto_Id
END

/*Eliminar m�todos de pago*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbMetodosPago_DELETE
	@meto_Id INT
AS
BEGIN
	UPDATE [maqu].[tbMetodosPago]
	SET [meto_Estado] = 0
	WHERE [meto_Id] = @meto_Id
END


--**************** CATEGOR�AS ****************--
/*Insertar categor�a*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbCategorias_INSERT
	@cate_Nombre 			NVARCHAR(100),
	@cate_UsuCreacion 		INT
AS
BEGIN
	INSERT INTO [maqu].[tbCategorias](cate_Nombre, cate_UsuCreacion)
	VALUES(@cate_Nombre, @cate_UsuCreacion)
END

/*Editar categor�a*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbCategorias_UPDATE
	@cate_Id					INT,
	@cate_Nombre 				NVARCHAR(100),
	@cate_UsuModificacion 		INT
AS
BEGIN
	UPDATE [maqu].[tbCategorias]
	SET 	[cate_Nombre] = @cate_Nombre,
			[cate_UsuModificacion] = @cate_UsuModificacion,
			[cate_FechaModificacion] = GETDATE()
	WHERE 	[cate_Id] = @cate_Id
END

/*Eliminar categor�a*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbCategorias_ELIMINAR
	@cate_Id	INT
AS
BEGIN
	UPDATE [maqu].[tbCategorias]
	SET [cate_Estado] = 0
	WHERE [cate_Id] = @cate_Id
END

--/*Insertar Cliente*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbClientes_Insert
	@clie_Nombres				NVARCHAR(200),
	@clie_Apellidos				NVARCHAR(200),
	@clie_Identidad				NVARCHAR(13),
	@clie_Sexo					CHAR,
	@mun_Id						CHAR(4),
	@clie_DireccionExacta		NVARCHAR(100),
	@clie_Telefono				NVARCHAR(15),
	@clie_CorreoElectronico		NVARCHAR(200),
	@clie_UsuCreacion			INT
AS
BEGIN
	INSERT INTO [maqu].[tbClientes](clie_Nombres, 
									clie_Apellidos, clie_Identidad, 
									clie_Sexo, muni_Id, 
									clie_DireccionExacta, clie_Telefono, 
									clie_CorreoElectronico, clie_UsuCreacion)
	VALUES(@clie_Nombres,@clie_Apellidos,
			@clie_Identidad,
			@clie_Sexo,@mun_Id,
			@clie_DireccionExacta,@clie_Telefono,
			@clie_CorreoElectronico,@clie_UsuCreacion)
END

/*Editar Cliente*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbClientes_Update
	@clie_Id					INT,
	@clie_Nombres				NVARCHAR(200),
	@clie_Apellidos				NVARCHAR(200),
	@clie_Identidad				NVARCHAR(13),
	@clie_Sexo					CHAR,
	@mun_Id						CHAR(4),
	@clie_DireccionExacta		NVARCHAR(100),
	@clie_Telefono				NVARCHAR(15),
	@clie_CorreoElectronico		NVARCHAR(200),
	@clie_UsuModificacion		INT
AS
BEGIN
UPDATE [maqu].[tbClientes]
   		SET clie_Nombres = @clie_Nombres,
			clie_Apellidos = @clie_Apellidos,
			clie_Identidad = @clie_Identidad,
			clie_Sexo = @clie_Sexo,
			muni_Id = @mun_Id,
			clie_DireccionExacta = @clie_DireccionExacta,
			clie_Telefono = @clie_Telefono,
			clie_CorreoElectronico = @clie_CorreoElectronico,
			clie_UsuModificacion = @clie_UsuModificacion,
			clie_FechaModificacion = GETDATE()
    WHERE 	clie_Id = @clie_Id
END

/*Eliminar Cliente*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbClientes_Delete
	@clie_Id INT
AS
BEGIN
	UPDATE [maqu].[tbClientes] 
	SET clie_Estado = 0
	WHERE clie_Id = @clie_Id
END

/*Insertar Factura*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbFacturas_Insert
	@clie_Id INT,
	@fact_Fecha DATETIME,
	@meto_Id INT,
	@empe_Id INT,
	@fact_usuCreacion INT
AS
BEGIN
INSERT INTO [maqu].[tbFacturas](clie_Id, fact_Fecha, 
			meto_Id, empe_Id, 
			fact_UsuCreacion)
VALUES(@clie_Id,@fact_Fecha,
		@meto_Id,@empe_Id,
		@fact_usuCreacion)
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

/*Eliminar Factura con sus Detalles*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbFacturas_Delete
@fact_Id INT
AS
BEGIN

--Borrado Logico de la factura
UPDATE [maqu].[tbFacturas] 
SET fact_Estado = 0 
WHERE fact_Id = @fact_Id

--Borrado de las facturas detalles por fact_Id
DELETE FROM maqu.tbFacturasDetalles WHERE fact_Id = @fact_Id
END

/*Insertar Productos*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbProductos_Insert
@prod_Nombre			NVARCHAR(100),
@prod_PrecioUni			DECIMAL (18,2),
@cate_Id				INT,
@prov_Id				INT,
@prod_Stock				INT,
@prod_UsuCreacion		INT
AS
BEGIN
INSERT INTO [maqu].[tbProductos](prod_Nombre, 
prod_PrecioUni, cate_Id, 
prov_Id, prod_Stock, 
prod_UsuCreacion, prod_FechaCreacion, 
prod_FechaModificacion, prod_UsuModificacion, 
prod_Estado)
VALUES(@prod_Nombre,@prod_PrecioUni,
@cate_Id,@prov_Id,
@prod_Stock,@prod_UsuCreacion,
GETDATE(),NULL,
NULL,1)
END

/*Editar Producto*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbProducto_Update
@prod_Nombre			NVARCHAR(100),
@prod_PrecioUni			DECIMAL(18,2),
@cate_Id				INT,
@prov_Id				INT,
@prod_Stock				INT,
@prod_UsuModificacion   INT
AS
BEGIN
UPDATE [maqu].[tbProductos]
SET prod_Nombre = @prod_Nombre,
prod_PrecioUni = @prod_PrecioUni,
cate_Id = @cate_Id,
prov_Id = @prov_Id,
prod_Stock = @prod_Stock,
prod_UsuModificacion = @prod_UsuModificacion,
prod_FechaModificacion = GETDATE()
END

/*Eliminar Producto*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbProductos_Delete
@prod_Id INT
AS
BEGIN
UPDATE [maqu].[tbProductos]
SET prod_Estado = 0
WHERE prod_Id = @prod_Id
END


SELECT * FROM [maqu].[tbProveedores]
/*Insertar Proveedores*/
GO
CREATE OR ALTER PROCEDURE UDP_maqu_tbProveedores_Insert
@prov_Nombre					NVARCHAR(200),
@prov_CorreoElectronico			NVARCHAR(150),
@prov_Telefono					NVARCHAR(15),
@prov_UsuCreacion				INT
AS
BEGIN
INSERT INTO [maqu].[tbProveedores](prov_Nombre, prov_CorreoElectronico, 
prov_Telefono, prov_UsuCreacion, 
prov_FechaCreacion, prov_UsuModificacion, 
prov_FechaModificacion, prov_Estado)
VALUES(@prov_Nombre,@prov_CorreoElectronico,
@prov_Telefono,@prov_UsuCreacion,
GETDATE(),NULL,
NULL,1)
END