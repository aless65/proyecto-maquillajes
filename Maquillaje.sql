CREATE DATABASE Maquillaje

GO 
USE Maquillaje
GO


--************CREACION TABLA ROLES******************--
CREATE TABLE tbRoles(
	rol_Id					INT IDENTITY,
	rol_Nombre				NVARCHAR(100) NOT NULL,
	rol_UsuCreacion			INT NOT NULL,
	rol_FechaCreacion		DATETIME NOT NULL,
	rol_UsuModificacion		INT,
	rol_FechaModificacion	DATETIME,
	rol_Estado				BIT NOT NULL
	CONSTRAINT PK_dbo_tbRoles_rol_Id PRIMARY KEY(rol_Id)
);
GO


--***********CREACION TABLA PANTALLAS*****************---
CREATE TABLE tbPantallas(
	pant_Id					INT IDENTITY,
	pant_Nombre				NVARCHAR(100) NOT NULL,
	pant_UsuCreacion		INT NOT NULL,
	pant_FechaCreacion		DATETIME NOT NULL,
	pant_UsuModificacion	INT,
	pant_FechaModificacion	DATETIME,
	pant_Estado				BIT NOT NULL
	CONSTRAINT PK_dbo_tbPantallas_pant_Id PRIMARY KEY(pant_Id)
);
GO


--***********CREACION TABLA ROLES/PANTALLA*****************---
CREATE TABLE tbPantallasPorRoles(
	pantrol_Id					INT IDENTITY,
	pantrol_Identificador		NVARCHAR(100) NOT NULL,
	rol_Id						INT NOT NULL,
	pant_Id						INT NOT NULL,
	pantrol_UsuCreacion			INT NOT NULL,
	pantrol_FechaCreacion		DATETIME NOT NULL,
	pantrol_UsuModificacion		INT,
	pantrol_FechaModificacion	DATETIME,
	pantrol_Estado				BIT NOT NULL
	CONSTRAINT PK_tbPantallasPorRoles_pantrol_Id PRIMARY KEY(pantrol_Id),
	CONSTRAINT FK_tbPantallasPorRoles_tbRoles_rol_Id FOREIGN KEY(rol_Id) REFERENCES tbRoles(rol_Id),
	CONSTRAINT FK_tbPantallasPorRoles_tbPantallas_pant_Id FOREIGN KEY(pant_Id)	REFERENCES tbPantallas(pant_Id)
);
GO


--****************CREACION TABLA USUARIOS****************--
CREATE TABLE tbUsuarios(
	usu_id					INT IDENTITY(1,1),
	usu_NombreUsuario		NVARCHAR(100) NOT NULL,
	usu_Contrasena			NVARCHAR(MAX) NOT NULL,
	usu_EsAdmin				BIT,
	rol_Id					INT,
	emp_Id					INT,
	usu_UsuCreacion			INT,
	usu_FechaCreacion		DATETIME NOT NULL,
	usu_UsuModificacion		INT,
	usu_FechaModificacion	DATETIME,
	usu_Estado				BIT NOT NULL
	CONSTRAINT PK_dbo_tbUsuarios_usu_Id PRIMARY KEY(usu_Id),
);

--********* PROCEDIMIENTO INSERTAR USUARIOS ADMIN**************--
GO
CREATE OR ALTER PROCEDURE UDP_InsertUsuario
	@usu_NombreUsuario NVARCHAR(100),	@usu_Contrasena NVARCHAR(200),
	@usu_EsAdmin BIT,					@rol_Id INT, 
	@emp_Id INT										
AS
BEGIN
	DECLARE @password NVARCHAR(MAX)=(SELECT HASHBYTES('Sha2_512', @usu_Contrasena));

	INSERT tbUsuarios(usu_NombreUsuario, usu_Contrasena, usu_EsAdmin, rol_Id, emp_Id, usu_UsuCreacion, usu_FechaCreacion, usu_Estado)
	VALUES(@usu_NombreUsuario, @password, @usu_EsAdmin, @rol_Id, @emp_Id, @emp_Id, GETDATE(), 1);
END;


GO
EXEC UDP_InsertUsuario 'aless65', 'bonjour', 1, NULL, 1;


--********* ALTERAR TABLA ROLES **************--
--********* AGREGAR CAMPOS AUDITORIA**************--
GO
ALTER TABLE tbRoles
ADD CONSTRAINT FK_tbRoles_tbUsuarios_rol_UsuCreacion_usu_id	FOREIGN KEY(rol_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbRoles_tbUsuarios_rol_UsuModificacion_usu_id	FOREIGN KEY(rol_UsuModificacion) REFERENCES tbUsuarios(usu_id);




GO
INSERT INTO tbRoles(rol_Nombre, rol_UsuCreacion, rol_FechaCreacion, rol_Estado)
VALUES ('Recursos humanos', 1, GETDATE(), 1),
	   ('Vendedor', 1, GETDATE(), 1)




--********* ALTERAR TABLA USUARIOS **************--
--********* AGREGAR CAMPO ROL, AUDITORIA**************--
GO
ALTER TABLE tbUsuarios
ADD CONSTRAINT FK_tbUsuarios_tbUsuarios_usu_UsuCreacion_usu_id FOREIGN KEY(usu_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbUsuarios_tbUsuarios_usu_UsuModificacion_usu_id FOREIGN KEY(usu_UsuModificacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbUsuarios_tbRoles_rol_Id FOREIGN KEY(rol_Id) REFERENCES tbRoles(rol_Id)


GO
INSERT INTO [dbo].[tbPantallas](pant_Nombre, pant_UsuCreacion, pant_FechaCreacion, pant_Estado)
VALUES('Departamentos', 1, GETDATE(), 1),
	  ('Municipios', 1, GETDATE(), 1),
	  ('Categorías', 1, GETDATE(), 1)


--*******************************************--
--********TABLA DEPARTAMENTO****************---
GO
CREATE TABLE tbDepartamentos(
	dep_Id  CHAR(2) NOT NULL,
	dep_Nombre NVARCHAR(100) NOT NULL,
	dep_UsuCreacion			INT NOT NULL,
	dep_FechaCreacion		DATETIME NOT NULL,
	dep_UsuModificacion		INT,
	dep_FechaModificacion	DATETIME,
	dep_Estado				BIT NOT NULL
	CONSTRAINT PK_dbo_tbDepartamentos_dep_Id PRIMARY KEY(dep_Id),
	CONSTRAINT FK_tbDepartamentos_tbUsuarios_dep_UsuCreacion_usu_id FOREIGN KEY(dep_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbDepartamentos_tbUsuarios_dep_UsuModificacion_usu_id FOREIGN KEY(dep_UsuModificacion) REFERENCES tbUsuarios(usu_id)
);


--********TABLA MUNICIPIO****************---
GO
CREATE TABLE tbMunicipios(
	mun_id					CHAR(4)			NOT NULL,
	mun_Nombre				NVARCHAR(80)	NOT NULL,
	dep_Id					CHAR(2)			NOT NULL,
	mun_UsuCreacion			INT				NOT NULL,
	mun_FechaCreacion		DATETIME		NOT NULL,
	mun_UsuModificacion		INT,
	mun_FechaModificacion	DATETIME,
	mun_Estado				BIT				NOT NULL
	CONSTRAINT PK_dbo_tbMunicipios_mun_Id PRIMARY KEY(mun_Id),
	CONSTRAINT FK_dbo_tbMunicipios_tbDepartamentos_dep_Id  FOREIGN KEY (dep_Id) REFERENCES tbDepartamentos(dep_Id),
	CONSTRAINT FK_tbMunicipios_tbUsuarios_mun_UsuCreacion_usu_id FOREIGN KEY(mun_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbMunicipios_tbUsuarios_mun_UsuModificacion_usu_id FOREIGN KEY(mun_UsuModificacion) REFERENCES tbUsuarios(usu_id)
);


CREATE TABLE tbCategorias
(
	cat_Id					INT IDENTITY,
	cat_Nombre				NVARCHAR(100) NOT NULL,
	cat_UsuCreacion			INT NOT NULL,
	cat_FechaCreacion		DATETIME NOT NULL,
	cat_UsuModificacion		INT,
	cat_FechaModificacion	DATETIME,
	cat_Estado				BIT NOT NULL

	CONSTRAINT PK_tbCategorias_cat_Id PRIMARY KEY(cat_Id),
	CONSTRAINT FK_tbCategorias_tbUsuarios_cat_UsuCreacion_usu_id FOREIGN KEY(cat_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbCategorias_tbUsuarios_cat_UsuModificacion_usu_id FOREIGN KEY(cat_UsuModificacion) REFERENCES tbUsuarios(usu_id)
);

CREATE TABLE tbMetodosPago
(
	met_Id					INT IDENTITY,
	met_Nombre				NVARCHAR(100)NOT NULL,
	met_UsuCreacion			INT NOT NULL,
	met_FechaCreacion		DATETIME NOT NULL,
	met_UsuModificacion		INT,
	met_FechaModificacion	DATETIME,
	met_Estado				BIT NOT NULL

	CONSTRAINT PK_tbMetodosPago_met_Id PRIMARY KEY(met_Id),
	CONSTRAINT FK_tbMetodosPago_tbUsuarios_met_UsuCreacion_usu_id FOREIGN KEY(met_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbMetodosPago_tbUsuarios_met_UsuModificacion_usu_id FOREIGN KEY(met_UsuModificacion) REFERENCES tbUsuarios(usu_id)
);

CREATE TABLE tbEstadosCiviles
(
	estciv_Id					INT IDENTITY,
	estciv_Nombre				NVARCHAR(50),
	estciv_UsuCreacion			INT NOT NULL,
	estciv_FechaCreacion		DATETIME NOT NULL,
	estciv_UsuModificacion		INT,
	estciv_FechaModificacion	DATETIME,
	estciv_Estado				BIT NOT NULL
   
   CONSTRAINT PK_tbEstadosCiviles PRIMARY KEY(estciv_Id),
   CONSTRAINT FK_tbEstadosCiviles_tbUsuarios_estciv_UsuCreacion_usu_id FOREIGN KEY(estciv_UsuCreacion) REFERENCES tbUsuarios(usu_id),
   CONSTRAINT FK_tbEstadosCiviles_tbUsuarios_estciv_UsuModificacion_usu_id FOREIGN KEY(estciv_UsuModificacion) REFERENCES tbUsuarios(usu_id)
);

CREATE TABLE tbProveedores
(
	prov_Id						INT IDENTITY,
	prov_Nombre					NVARCHAR(200) NOT NULL,
	prov_CorreoElectronico      NVARCHAR(200) NOT NULL,
	prov_Telefono				NVARCHAR(15)NOT NULL,
	prov_UsuCreacion			INT NOT NULL,
	prov_FechaCreacion			DATETIME NOT NULL,
	prov_UsuModificacion		INT,
	prov_FechaModificacion		DATETIME,
	prov_Estado					BIT NOT NULL

	CONSTRAINT PK_tbProveedores_prov_Id PRIMARY KEY(prov_Id),
	CONSTRAINT FK_tbProveedores_tbUsuarios_prov_UsuCreacion_usu_id FOREIGN KEY(prov_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT  FK_tbProveedores_tbUsuarios_prov_UsuModificacion_usu_id FOREIGN KEY(prov_UsuModificacion) REFERENCES tbUsuarios(usu_id)
);

--********TABLA EMPLEADOS****************---
GO
CREATE TABLE tbEmpleados(
	emp_Id					INT IDENTITY(1,1),
	emp_Nombres				NVARCHAR(100)	NOT NULL,
	emp_Apellidos			NVARCHAR(100)	NOT NULL,
	emp_Identidad			VARCHAR(13)		NOT NULL,
	emp_FechaNacimiento		DATE			NOT NULL,
	emp_Sexo				CHAR(1)			NOT NULL,
	estciv_Id				INT				NOT NULL,
	mun_Id					CHAR(4)			NOT NULL,
	emp_Direccion			NVARCHAR(250)	NOT NULL,
	emp_Telefono			NVARCHAR(15)	NOT NULL,
	emp_CorreoElectronico	NVARCHAR(200)	NOT NULL,
	emp_UsuCreacion			INT				NOT NULL,
	emp_FechaCreacion		DATETIME		NOT NULL,
	emp_UsuModificacion		INT,
	emp_FechaModificacion	DATETIME,
	emp_Estado				BIT,
	
	CONSTRAINT PK_dbo_tbEmpleados_emp_Id PRIMARY KEY(emp_Id),
	CONSTRAINT CK__dbo_TbEmpleados_emp_Sexo CHECK(emp_sexo IN ('F', 'M')),
	CONSTRAINT FK_dbo_tbEmpledos_tbEstadoCivil_estaciv_Id	FOREIGN KEY(estciv_Id)				REFERENCES tbEstadosCiviles(estciv_Id),
	CONSTRAINT FK_dbo_tbEmpledos_tbMunicipios_mun_Id		FOREIGN KEY(mun_Id)					REFERENCES tbMunicipios(mun_Id),
	CONSTRAINT FK_dbo_tbEmpleados_dbo_tbUsuarios_UserCreate	FOREIGN KEY(emp_UsuCreacion)		REFERENCES tbUsuarios(usu_Id),
	CONSTRAINT FK_dbo_tbEmpleados_dbo_tbUsuarios_UserUpdate	FOREIGN KEY(emp_UsuModificacion)	REFERENCES tbUsuarios(usu_Id),
);

--********TABLA Clientes****************---
CREATE TABLE tbClientes
(
	cli_Id						INT IDENTITY,
	cli_Nombres					NVARCHAR(300) NOT NULL,
	cli_Apellidos				NVARCHAR(300) NOT NULL,
	cli_Identidad				VARCHAR(13)	  NOT NULL,
	cli_Sexo					CHAR NOT NULL,
	mun_Id						CHAR(4) NOT NULL,
	cli_DireccionExacta			NVARCHAR(500) NOT NULL,
	cli_Telefono				NVARCHAR(15) NOT NULL,
	cli_CorreoElectronico		NVARCHAR(150) NOT NULL,
    cli_UsuCreacion				INT				NOT NULL,
	cli_FechaCreacion			DATETIME		NOT NULL,
	cli_UsuModificacion			INT,
	cli_FechaModificacion		DATETIME,
	cli_Estado					BIT,

	CONSTRAINT PK_tbClientes_cli_Id PRIMARY KEY(cli_Id),
	CONSTRAINT CK_dbo_tbClientes_emp_Sexo CHECK(cli_sexo IN ('F', 'M')),
	CONSTRAINT FK_tbClientes_tbUsuarios_cli_UsuCreacion_usu_id FOREIGN KEY(cli_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbClientes_tbUsuarios_cli_UsuModificacion_usu_id FOREIGN KEY(cli_UsuModificacion) REFERENCES tbUsuarios(usu_id)
);

--********TABLA Productos****************---
CREATE TABLE tbProductos
(
	pro_Id								INT IDENTITY,
	pro_Nombre							NVARCHAR(200)NOT NULL,
	pro_PrecioUni						DECIMAL(18,2) NOT NULL,
	cat_Id								INT NOT NULL,
	prov_Id								INT NOT NULL,
	pro_Stock							INT NOT NULL,
	pro_UsuCreacion						INT NOT NULL,
	pro_FechaCreacion					DATETIME NOT NULL,
	pro_FechaModificacion				DATETIME,
	pro_UsuModificacion					INT,
	pro_Estado							BIT NOT NULL,

	CONSTRAINT PK_tbProductos_pro_Id PRIMARY KEY(pro_Id),
	CONSTRAINT FK_tbProductos_tbProveedores_prov_Id FOREIGN KEY(prov_Id) REFERENCES tbProveedores(prov_Id),
	CONSTRAINT FK_tbProductos_tbCategorias_cat_Id FOREIGN KEY(cat_Id) REFERENCES tbCategorias(cat_Id),
	CONSTRAINT FK_tbProductos_tbUsuarios_cli_UsuCreacion_usu_id FOREIGN KEY(pro_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbProductos_tbUsuarios_cli_UsuModificacion_usu_id FOREIGN KEY(pro_UsuModificacion) REFERENCES tbUsuarios(usu_id)
);


--********TABLA Factura****************---
CREATE TABLE tbFacturas
(
	fac_Id								INT IDENTITY,
	cli_Id								INT NOT NULL,
	fac_Fecha							DATETIME NOT NULL,
	met_Id								INT NOT NULL,
	emp_Id								INT NOT NULL,
	fac_UsuCreacion						INT NOT NULL,
	fac_FechaCreacion					DATETIME NOT NULL,
	fac_FechaModificacion				DATETIME,
	fac_UsuModificacion					INT,
	fac_Estado							BIT NOT NULL,

	CONSTRAINT PK_tbFacturas_fac_Id PRIMARY KEY(fac_Id),
	CONSTRAINT FK_tbFacturas_tbClientes_cli_Id FOREIGN KEY(cli_Id) REFERENCES tbClientes(cli_Id),
	CONSTRAINT FK_tbFacturas_tbMetodosPago_met_Id FOREIGN KEY(met_Id) REFERENCES tbMetodosPago(met_Id),
	CONSTRAINT FK_tbFacturas_tbUsuarios_fac_UsuCreacion_usu_id FOREIGN KEY(fac_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbFacturas_tbUsuarios_fac_UsuModificacion_usu_id FOREIGN KEY(fac_UsuModificacion) REFERENCES tbUsuarios(usu_id)
)

--********TABLA Factura Detalles****************---
CREATE TABLE tbFacturasDetalles
(
	facdet_Id								INT IDENTITY,
	fac_Id									INT NOT NULL,
	pro_Id									INT NOT NULL,
	facdet_Cantidad							INT NOT NULL,
	facdet_Precio							DECIMAL(18,2) NOT NULL,
	facdet_UsuCreacion						INT NOT NULL,
	facdet_FechaCreacion					DATETIME NOT NULL,
	facdet_FechaModificacion				DATETIME,
	facdet_UsuModificacion					INT,
	facdet_Estado							BIT NOT NULL,

	CONSTRAINT PK_tbFacturasDetalles_facdet_Id PRIMARY KEY(facdet_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbFacturas_fac_Id FOREIGN KEY(fac_Id) REFERENCES tbFacturas(fac_Id),
	CONSTRAINT FK_tbFacturasDetalles_tbUsuarios_facdet_UsuCreacion_usu_id FOREIGN KEY(facdet_UsuCreacion) REFERENCES tbUsuarios(usu_id),
	CONSTRAINT FK_tbFacturasDetalles_tbUsuarios_facdet_UsuModificacion_usu_id FOREIGN KEY(facdet_UsuModificacion) REFERENCES tbUsuarios(usu_id)
);


/*
INSERT DE LA BASE DE DATOS
*/

GO
INSERT tbDepartamentos(dep_Id, dep_Nombre, dep_UsuCreacion, dep_FechaCreacion, dep_Estado)
VALUES('01','Atlántida', 1, GETDATE(), 1),
      ('02','Colón', 1, GETDATE(), 1),
	  ('03','Comayagua', 1, GETDATE(), 1),
	  ('04','Copán', 1, GETDATE(), 1),
	  ('05','Cortés', 1, GETDATE(), 1),
	  ('06','Choluteca', 1, GETDATE(), 1),
	  ('07','El Paraíso', 1, GETDATE(), 1),
	  ('08','Francisco Morazán', 1, GETDATE(), 1),
	  ('09','Gracias a Dios', 1, GETDATE(), 1),
	  ('10','Intibucá', 1, GETDATE(), 1),
	  ('11','Islas de La Bahía', 1, GETDATE(), 1),
	  ('12','La Paz', 1, GETDATE(), 1),
	  ('13','Lempira', 1, GETDATE(), 1),
	  ('14','Ocotepeque', 1, GETDATE(), 1),
	  ('15','Olancho', 1, GETDATE(), 1),
	  ('16','Santa Bárbara', 1, GETDATE(), 1),
	  ('17','Valle', 1, GETDATE(), 1),
	  ('18','Yoro', 1, GETDATE(), 1);

GO
INSERT tbMunicipios(mun_id, mun_Nombre, dep_Id, mun_UsuCreacion, mun_FechaCreacion, mun_Estado)
VALUES('0101','La Ceiba ','01', 1, GETDATE(), 1),
      ('0102','El Porvenir','01', 1, GETDATE(), 1), 
	  ('0103','Jutiapa','01', 1, GETDATE(), 1),
	  ('0104','Jutiapa','01', 1, GETDATE(), 1),
	  ('0105','La Masica','01', 1, GETDATE(), 1),
	  ('0201','Trujillo','02', 1, GETDATE(), 1),
	  ('0202','Balfate','02', 1, GETDATE(), 1),
	  ('0203','Iriona','02', 1, GETDATE(), 1),
	  ('0204','Limón','02', 1, GETDATE(), 1),
	  ('0205','Sabá','02', 1, GETDATE(), 1),
	  ('0301','Comayagua','03', 1, GETDATE(), 1),
	  ('0302','Ajuterique','03', 1, GETDATE(), 1),
      ('0303','El Rosario','03', 1, GETDATE(), 1),
	  ('0304','Esquías','03', 1, GETDATE(), 1),
      ('0305','Humuya','03',1, GETDATE(), 1),
	  ('0401','Santa Rosa de Copán','04', 1, GETDATE(), 1),
	  ('0402','Cabañas','04', 1, GETDATE(), 1),
      ('0403','Concepción','04', 1, GETDATE(), 1),
	  ('0404','Copán Ruinas','04', 1, GETDATE(), 1),
      ('0405','Corquín','04', 1, GETDATE(), 1),
	  ('0501','San Pedro Sula ','05', 1, GETDATE(), 1),
      ('0502','Choloma ','05', 1, GETDATE(), 1),
      ('0503','Omoa','05', 1, GETDATE(), 1),
      ('0504','Pimienta','05', 1, GETDATE(), 1),
	  ('0505','Potrerillos','05', 1, GETDATE(), 1),
	  ('0506','Puerto Cortés','05', 1, GETDATE(), 1),
	  ('0601','Choluteca','06', 1, GETDATE(), 1),
      ('0602','Apacilagua','06', 1, GETDATE(), 1),
      ('0603','Concepción de María','06', 1, GETDATE(), 1),
      ('0604','Duyure','06', 1, GETDATE(), 1),
	  ('0605','El Corpus','07', 1, GETDATE(), 1),
	  ('0701','Yuscarán','07', 1, GETDATE(), 1),
      ('0702','Alauca','07', 1, GETDATE(), 1),
      ('0703','Danlí','07', 1, GETDATE(), 1),
	  ('0704','El Paraíso','07', 1, GETDATE(), 1),
      ('0705','Güinope','07', 1, GETDATE(), 1),
	  ('0801','Distrito Central (Comayagüela y Tegucigalpa)','08', 1, GETDATE(), 1),
      ('0802','Alubarén','08', 1, GETDATE(), 1),
      ('0803','Cedros','08', 1, GETDATE(), 1),
      ('0804','Curarén','08', 1, GETDATE(), 1),
	  ('0805','El Porvenir','08', 1, GETDATE(), 1),
	  ('0901','Puerto Lempira','09', 1, GETDATE(), 1),
      ('0902','Brus Laguna','09', 1, GETDATE(), 1),
      ('0903','Ahuas','09', 1, GETDATE(), 1),
	  ('0904','Juan Francisco Bulnes','09', 1, GETDATE(), 1),
      ('0905','Villeda Morales','09', 1, GETDATE(), 1),
	  ('1001','La Esperanza','10', 1, GETDATE(), 1),
      ('1002','Camasca','10', 1, GETDATE(), 1),
      ('1003','Colomoncagua','10', 1, GETDATE(), 1),
	  ('1004','Concepción','10', 1, GETDATE(), 1),
      ('1005','Dolores','10', 1, GETDATE(), 1),
	  ('1101','Roatán','11', 1, GETDATE(), 1),
      ('1102','Guanaja','11', 1, GETDATE(), 1),
      ('1103','José Santos Guardiola','11', 1, GETDATE(), 1),
	  ('1104','Utila','11', 1, GETDATE(), 1),
	  ('1201','La Paz','12', 1, GETDATE(), 1),
      ('1202','Aguanqueterique','12', 1, GETDATE(), 1),
      ('1203','Cabañas','12', 1, GETDATE(), 1),
	  ('1204','Cane','12', 1, GETDATE(), 1),
      ('1205','Chinacla','12', 1, GETDATE(), 1),
	  ('1301','Gracias','13', 1, GETDATE(), 1),
      ('1302','Belén','13', 1, GETDATE(), 1),
      ('1303','Candelaria','13', 1, GETDATE(), 1),
	  ('1304','Cololaca','13', 1, GETDATE(), 1),
      ('1305','Erandique','13', 1, GETDATE(), 1),
	  ('1401','Ocotepeque','14', 1, GETDATE(), 1),
      ('1402','Belén Gualcho','14', 1, GETDATE(), 1),
      ('1403','Concepción','14', 1, GETDATE(), 1),
	  ('1404','Dolores Merendón','14', 1, GETDATE(), 1),
      ('1405','Fraternidad','14', 1, GETDATE(), 1),
	  ('1501','Juticalpa','15', 1, GETDATE(), 1),
      ('1502','Campamento','15', 1, GETDATE(), 1),
      ('1503','Catacamas','15', 1, GETDATE(), 1),
	  ('1504','Concordia','15', 1, GETDATE(), 1),
      ('1505','Dulce Nombre de Culmí','15', 1, GETDATE(), 1),
	  ('1601','Santa Bárbara','16', 1, GETDATE(), 1),
      ('1602','Arada','16', 1, GETDATE(), 1),
      ('1603','Atima','16', 1, GETDATE(), 1),
	  ('1604','Azacualpa','16', 1, GETDATE(), 1),
      ('1605','Ceguaca','16', 1, GETDATE(), 1),
	  ('1701','Nacaome','17', 1, GETDATE(), 1),
      ('1702','Alianza','17', 1, GETDATE(), 1),
      ('1703','Amapala','17', 1, GETDATE(), 1),
	  ('1704','Aramecina','17', 1, GETDATE(), 1),
      ('1705','Caridad','17', 1, GETDATE(), 1),
	  ('1801','Yoro','18', 1, GETDATE(), 1),
      ('1802','Arenal','18', 1, GETDATE(), 1),
      ('1803','El Negrito','18', 1, GETDATE(), 1),
	  ('1804','El Progreso','18', 1, GETDATE(), 1),
      ('1805','Jocón','18', 1, GETDATE(), 1)


--********PROCEDIMIENTOS****************---
GO
CREATE OR ALTER PROCEDURE UDP_tbMetodosPago_INSERT
	@met_Nombre			NVARCHAR(100),
	@met_UsuCreacion	INT
AS
BEGIN
	INSERT INTO tbMetodosPago(met_Nombre, met_UsuCreacion, met_FechaCreacion, met_Estado)
	VALUES (@met_Nombre, @met_UsuCreacion, GETDATE(), 1)
END

GO
EXEC UDP_tbMetodosPago_INSERT 'Efectivo', 1


--Iniciar sesión
GO
CREATE OR ALTER PROCEDURE UDP_Login
	@usu_Nombre NVARCHAR(100), @usu_Contrasena NVARCHAR(200)
AS
BEGIN

	DECLARE @contraEncriptada NVARCHAR(MAX) = HASHBYTES('SHA2_512', @usu_Contrasena);

	SELECT [usu_id], [usu_NombreUsuario] [rol_Id]
	FROM [dbo].[tbUsuarios]
	WHERE [usu_Contrasena] = @contraEncriptada
	AND [usu_NombreUsuario] = @usu_Nombre
	AND [usu_Estado] = 1
END

GO

--**************** ESTADOS CIVILES ****************--
--Insertar estados civiles
CREATE OR ALTER PROCEDURE UDP_tbEstadosCiviles_INSERT
	@estciv_Nombre	NVARCHAR(100),
	@estciv_UsuCreacion INT
AS
BEGIN
	INSERT INTO [dbo].[tbEstadosCiviles]([estciv_Nombre], [estciv_UsuCreacion], [estciv_FechaCreacion], [estciv_Estado])
	VALUES(@estciv_Nombre, @estciv_UsuCreacion, GETDATE(), 1)
END

--Editar estados civiles
GO
CREATE OR ALTER PROCEDURE UDP_tbEstadosCiviles_UPDATE
	@estciv_Id INT,
	@estciv_Nombre	NVARCHAR(100),
	@estciv_UsuModificacion INT
AS
BEGIN
	UPDATE [dbo].[tbEstadosCiviles]
	SET [estciv_Nombre] = @estciv_Nombre,
		[estciv_UsuModificacion] = @estciv_UsuModificacion,
		[estciv_FechaModificacion] = GETDATE()
	WHERE [estciv_Id] = @estciv_Id
END

--Eliminar estados civiles
GO
CREATE OR ALTER PROCEDURE UDP_tbEstadosCiviles_DELETE
	@estciv_Id INT
AS
BEGIN
	UPDATE [dbo].[tbEstadosCiviles]
	SET  [estciv_Estado] = 0
	WHERE [estciv_Id] = @estciv_Id
END

/*Insert estados civiles*/
GO
EXECUTE UDP_tbEstadosCiviles_INSERT 'Soltero',1
EXECUTE UDP_tbEstadosCiviles_INSERT 'Casado',1
EXECUTE UDP_tbEstadosCiviles_INSERT 'Union Libre',1
EXECUTE UDP_tbEstadosCiviles_INSERT 'Viudo(a)',1

--**************** EMPLEADOS ****************--
/*Empleados*/
GO
CREATE OR ALTER PROCEDURE UDP_tbEmpleados_VISTA
AS
BEGIN
	SELECT [emp_Nombres],
		   [emp_Apellidos],
		   CASE WHEN [emp_Sexo] = 'F' THEN 'Femenino'
				ELSE 'Masculino'
		   END AS Sexo,
		   T2.estciv_Nombre
	FROM [dbo].[tbEmpleados] T1 INNER JOIN [dbo].[tbEstadosCiviles] T2
	ON T1.[estciv_Id] = T2.estciv_Id
	WHERE [emp_Estado] = 1
END


/*Insertar Empleados*/
GO 
CREATE OR ALTER PROCEDURE UPD_tbEmpleados_Insert
@emp_Nombres NVARCHAR(200),
@emp_Apellidos NVARCHAR(200),
@emp_Identidad NVARCHAR(13),
@emp_FechaNacimiento DATE,
@emp_Sexo CHAR,
@estciv_Id INT,
@mun_Id NVARCHAR(4),
@emp_Direccion NVARCHAR(200),
@emp_Telefono NVARCHAR(15),
@emp_CorreoElectronico NVARCHAR(200),
@emp_UsuCreacion INT
AS
BEGIN
INSERT INTO tbEmpleados(emp_Nombres, emp_Apellidos, 
emp_Identidad, emp_FechaNacimiento, 
emp_Sexo, estciv_Id, mun_Id, 
emp_Direccion, emp_Telefono, 
emp_CorreoElectronico, emp_UsuCreacion, 
emp_FechaCreacion, emp_UsuModificacion, 
emp_FechaModificacion, emp_Estado)
VALUES(@emp_Nombres,@emp_Apellidos,
@emp_Identidad,@emp_FechaNacimiento,
@emp_Sexo,@estciv_Id,
@mun_Id,@emp_Direccion,
@emp_Telefono,@emp_CorreoElectronico,
@emp_UsuCreacion,GETDATE(),
NULL,NULL,
1)
END

/*Editar Empleados*/
GO
CREATE OR ALTER PROCEDURE UDP_tbEmpleados_Update
@emp_Id INT,
@emp_Nombres NVARCHAR(200),
@emp_Apellidos NVARCHAR(200),
@emp_Identidad NVARCHAR(13),
@emp_FechaNacimiento DATE,
@emp_Sexo CHAR,
@estciv_Id INT,
@mun_Id NVARCHAR(4),
@emp_Direccion NVARCHAR(200),
@emp_Telefono NVARCHAR(15),
@emp_CorreoElectronico NVARCHAR(200),
@emp_usuModificacion INT
AS
BEGIN
UPDATE tbEmpleados
SET emp_Nombres = @emp_Nombres,
emp_Apellidos = @emp_Apellidos,
emp_Identidad = @emp_Identidad,
emp_FechaNacimiento = @emp_FechaNacimiento,
emp_Sexo = @emp_Sexo,
estciv_Id = @estciv_Id,
mun_Id = @emp_Direccion,
emp_Telefono = @emp_Telefono,
emp_CorreoElectronico = @emp_CorreoElectronico,
emp_UsuModificacion = @emp_usuModificacion,
emp_FechaModificacion = GETDATE()
END

/*Eliminar Empleados*/
GO
CREATE OR ALTER PROCEDURE UDP_tbEmpleados_Delete
@emp_Id INT
AS
BEGIN
UPDATE tbEmpleados
SET emp_Estado = 0
END


GO
EXEC UPD_tbEmpleados_Insert 'Alessia', 'Medina', '0501200506728', '2005-05-06', 'F', 1, '0501', 'casa', '99349019', 'aless@hootmail.com', 1

GO
ALTER TABLE tbUsuarios
ADD CONSTRAINT FK_tbUsuarios_tbEmpleados_emp_Id	FOREIGN KEY(emp_Id) REFERENCES tbEmpleados(emp_Id)

--**************** DEPARTAMENTOS ****************--
/*Insertar Departamentos*/
GO
CREATE OR ALTER PROCEDURE UDP_tbDepartamentos_Insert
@dep_Nombre NVARCHAR(100),
@dep_UsuCreacion INT
AS
BEGIN
INSERT INTO tbDepartamentos(dep_Nombre, dep_UsuCreacion, dep_FechaCreacion, dep_UsuModificacion, dep_FechaModificacion, dep_Estado)
VALUES(@dep_Nombre,@dep_UsuCreacion,GETDATE(),NULL,NULL,1)
END

/*Editar Departamentos*/
GO
CREATE OR ALTER PROCEDURE UDP_tbDepartamentos_UPDATE
@dep_Nombre NVARCHAR(100),
@dep_UsuModificacion INT
AS
BEGIN
UPDATE tbDepartamentos
SET dep_Nombre = @dep_Nombre,
dep_UsuModificacion = @dep_UsuModificacion,
dep_FechaModificacion = GETDATE()
END

/*Eliminar Departamentos*/
GO
CREATE OR ALTER PROCEDURE UDP_tbDepartamentos_DELETE
@dep_Id INT
AS
BEGIN
UPDATE tbDepartamentos
SET dep_Estado = 0
WHERE dep_Id = @dep_Id
END

--**************** MÉTODOS DE PAGO ****************--
/*Insert métodos de pago*/
GO
CREATE OR ALTER PROCEDURE UDP_tbMetodosPago_INSERT
	@met_Nombre	NVARCHAR(100),
	@met_UsuCreacion INT
AS
BEGIN
	INSERT INTO [dbo].[tbMetodosPago](met_Nombre, met_UsuCreacion, met_FechaCreacion, met_Estado)
	VALUES (@met_Nombre, @met_UsuCreacion, GETDATE(), 1)
END

/*Editar métodos de pago*/
GO
CREATE OR ALTER PROCEDURE UDP_tbMetodosPago_UPDATE
	@met_Id INT,
	@met_Nombre	NVARCHAR(100),
	@met_UsuModificacion INT
AS
BEGIN
	UPDATE [dbo].[tbMetodosPago]
	SET [met_Nombre] = @met_Nombre,
		[met_UsuModificacion] = @met_UsuModificacion,
		[met_FechaModificacion] = GETDATE()
	WHERE [met_Id] = @met_Id
END

/*Eliminar métodos de pago*/
GO
CREATE OR ALTER PROCEDURE UDP_tbMetodosPago_DELETE
	@met_Id INT
AS
BEGIN
	UPDATE [dbo].[tbMetodosPago]
	SET [met_Estado] = 0
	WHERE [met_Id] = @met_Id
END


--**************** CATEGORÍAS ****************--
/*Insertar categoría*/
GO
CREATE OR ALTER PROCEDURE UDP_tbCategorias_INSERT
	@cat_Nombre NVARCHAR(100),
	@cat_UsuCreacion INT
AS
BEGIN
	INSERT INTO [dbo].[tbCategorias](cat_Nombre, cat_UsuCreacion, cat_FechaCreacion, cat_Estado)
	VALUES(@cat_Nombre, @cat_UsuCreacion, GETDATE(), 1)
END

/*Editar categoría*/
GO
CREATE OR ALTER PROCEDURE UDP_tbCategorias_UPDATE
	@cat_Id	INT,
	@cat_Nombre NVARCHAR(100),
	@cat_UsuModificacion INT
AS
BEGIN
	UPDATE [dbo].[tbCategorias]
	SET [cat_Nombre] = @cat_Nombre,
		[cat_UsuModificacion] = @cat_UsuModificacion,
		[cat_FechaModificacion] = GETDATE()
	WHERE [cat_Id] = @cat_Id
END

/*Eliminar categoría*/
GO
CREATE OR ALTER PROCEDURE UDP_tbCategorias_ELIMINAR
	@cat_Id	INT
AS
BEGIN
	UPDATE [dbo].[tbCategorias]
	SET [cat_Estado] = 0
	WHERE [cat_Id] = @cat_Id
END

