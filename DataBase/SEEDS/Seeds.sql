-- =============================================  
-- Autor:  <Author,Juan David Gallego Giraldo>  
-- Create date: <Create Date, 12-03-2021>  
-- Description: <Description, Semillas para la configuración inical del sistema>  
-- =============================================
USE Alpha
GO
INSERT INTO ADM.Persona (TipoDocumento, Documento, PrimerNombre, PrimerApellido, Telefono, CorreoElectronico, UsuarioCreaId) 
VALUES('CC', '1120565911', 'JUAN', 'GALLEGO', '3134595990', 'juangallego98@gmail.com', 1);
INSERT INTO ADM.Usuario(PersonaId, Nombre, Contrasena, UsuarioCreaId) VALUES(1, 'Administrador', 'ABC', 1);

INSERT INTO ADM.Persona (TipoDocumento, Documento, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Telefono, CorreoElectronico, UsuarioCreaId) 
VALUES('CC', '1234567890', 'JOSÉ', 'MIGUEL', 'LOPEZ', 'SANCHEZ', '3105555555', 'jose@gmail.com', (Select UsuarioId from ADM.Usuario where Nombre = 'Administrador'));
INSERT INTO ADM.Persona (TipoDocumento, Documento, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Telefono, CorreoElectronico, UsuarioCreaId) 
VALUES('CC', '1234567891', 'LAURA', 'MARCELA', 'LAFFERTY', 'GIRALDO', '3104444444', 'laura.lafferty@gmail.com', (Select UsuarioId from ADM.Usuario where Nombre = 'Administrador'));

INSERT INTO ADM.Usuario(PersonaId, Nombre, Contrasena, UsuarioCreaId) VALUES ((Select PersonaId from ADM.Persona where Documento = '1234567890'), 'CC1234567890', 'ABC', (Select UsuarioId from ADM.Usuario where Nombre = 'Administrador'));
INSERT INTO ADM.Usuario(PersonaId, Nombre, Contrasena, UsuarioCreaId) VALUES ((Select PersonaId from ADM.Persona where Documento = '1234567891'), 'CC1234567891', 'ABC', (Select UsuarioId from ADM.Usuario where Nombre = 'Administrador'));

INSERT INTO ADM.Rol (UsuarioId, Nombre, UsuarioCreaId) 
VALUES ((Select UsuarioId from ADM.Usuario where Nombre = 'Administrador'), 'Administrador', (Select UsuarioId from ADM.Usuario where Nombre = 'Administrador'));
INSERT INTO ADM.Rol (UsuarioId, Nombre, UsuarioCreaId) 
VALUES ((Select UsuarioId from ADM.Usuario where Nombre = 'CC1234567890'), 'Gestor Documental', (Select UsuarioId from ADM.Usuario where Nombre = 'Administrador'));
INSERT INTO ADM.Rol (UsuarioId, Nombre, UsuarioCreaId) 
VALUES ((Select UsuarioId from ADM.Usuario where Nombre = 'CC1234567891'), 'Destinatario', (Select UsuarioId from ADM.Usuario where Nombre = 'Administrador'));


INSERT INTO PAR.TipoCorrespondencia (Codigo, Nombre, UsuarioCreaId)
VALUES('CI', 'Interna',(Select UsuarioId from ADM.Usuario where Nombre = 'Administrador'));
INSERT INTO PAR.TipoCorrespondencia (Codigo, Nombre, UsuarioCreaId)
VALUES('CE', 'Externa',(Select UsuarioId from ADM.Usuario where Nombre = 'Administrador'));