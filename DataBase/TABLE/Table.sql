-- =============================================  
-- Autor:  <Author,Juan David Gallego Giraldo>  
-- Create date: <Create Date, 12-03-2021>  
-- Description: <Description, DML para creación de base de datos de la compañia Alpha>  
-- =============================================
USE master
GO
DROP DATABASE IF EXISTS Alpha
GO
CREATE DATABASE Alpha
GO
USE Alpha
GO
CREATE SCHEMA PAR
GO
CREATE SCHEMA ADM
GO
CREATE SCHEMA COR
GO
CREATE SCHEMA AUD
GO
CREATE TABLE ADM.Persona
(
	PersonaId BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	TipoDocumento  VARCHAR(5) NOT NULL,
	Documento  VARCHAR(50) NOT NULL,
	PrimerNombre VARCHAR(50) NOT NULL,
	SegundoNombre VARCHAR(50) NULL,
	PrimerApellido VARCHAR(50) NOT NULL,
	SegundoApellido VARCHAR(50) NULL,
	Telefono VARCHAR(20) NOT NULL,
	CorreoElectronico VARCHAR(100) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	UsuarioCreaId BIGINT NOT NULL,
	FechaModificacion DATETIME NULL,
	UsuarioModificaId BIGINT NULL
)
GO
CREATE TABLE ADM.Usuario
(
	UsuarioId BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	PersonaId BIGINT NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Contrasena VARCHAR(300) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	UsuarioCreaId BIGINT NOT NULL,
	FechaModificacion DATETIME NULL,
	UsuarioModificaId BIGINT NULL,
	CONSTRAINT FK_Persona_Usuario FOREIGN KEY (PersonaId) REFERENCES ADM.Persona (PersonaId)
)
GO
CREATE TABLE ADM.Rol
(
	RolId BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	UsuarioId BIGINT NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	UsuarioCreaId BIGINT NOT NULL,
	FechaModificacion DATETIME NULL,
	UsuarioModificaId BIGINT NULL,
	CONSTRAINT FK_Usuario_Rol FOREIGN KEY (UsuarioId) REFERENCES ADM.Usuario (UsuarioId)
)
GO
CREATE TABLE COR.Correspondencia
(
	CorrespondenciaId BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	NumeroRadicado VARCHAR(20) NOT NULL,
	FechaRadicacion DATETIME NOT NULL,
	RemitentePersonaId BIGINT NOT NULL,
	DestinatarioPersonaId BIGINT NOT NULL,
	Tipo VARCHAR(5) NOT NULL,
	Estado VARCHAR(10) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	UsuarioCreaId BIGINT NOT NULL,
	FechaModificacion DATETIME NULL,
	UsuarioModificaId BIGINT NULL,
	CONSTRAINT FK_PersonaRemitente_Correspondencia FOREIGN KEY (RemitentePersonaId) REFERENCES ADM.Persona (PersonaId),
	CONSTRAINT FK_PersonaDestinatario_Correspondencia FOREIGN KEY (DestinatarioPersonaId) REFERENCES ADM.Persona (PersonaId)
)
GO
CREATE TABLE COR.Archivos
(
	ArchivoId BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	CorrespondenciaId BIGINT NOT NULL,
	Ruta VARCHAR(200) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	UsuarioCreaId BIGINT NOT NULL,
	FechaModificacion DATETIME NULL,
	UsuarioModificaId BIGINT NULL,
	CONSTRAINT FK_Correspondencia_Archivos FOREIGN KEY (CorrespondenciaId) REFERENCES COR.Correspondencia (CorrespondenciaId)
)
GO
CREATE TABLE PAR.TipoCorrespondencia
(
	TipoCorrespondenciaId BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Codigo VARCHAR(5) NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	Activo BIT DEFAULT 1 NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
	UsuarioCreaId BIGINT NOT NULL,
	FechaModificacion DATETIME NULL,
	UsuarioModificaId BIGINT NULL
)
GO
CREATE TABLE AUD.Auditoria
(
	AuditoriaId BIGINT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Evento VARCHAR(500) NOT NULL,
	Operacion VARCHAR(10) NOT NULL,
	UsuarioCreaId BIGINT NOT NULL,
	FechaCreacion DATETIME DEFAULT GETDATE() NOT NULL
)
GO
DROP SEQUENCE IF EXISTS COR.CorrespondenciaInterna
GO
CREATE SEQUENCE COR.CorrespondenciaInterna
AS INT 
START WITH 1  
INCREMENT BY 1  
MINVALUE 00000000  
MAXVALUE 99999999
CYCLE
GO
DROP SEQUENCE IF EXISTS COR.CorrespondenciaExterna
GO
CREATE SEQUENCE COR.CorrespondenciaExterna
AS INT 
START WITH 1  
INCREMENT BY 1  
MINVALUE 00000000  
MAXVALUE 99999999
CYCLE
GO 

