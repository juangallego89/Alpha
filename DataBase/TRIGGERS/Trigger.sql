-- =============================================  
-- Autor:  <Author,Juan David Gallego Giraldo>  
-- Create date: <Create Date, 12-03-2021>  
-- Description: <Description, DML para creaci�n de trigger para tabla COR.Correspondencia>  
-- =============================================
USE Alpha
GO
DROP TRIGGER IF EXISTS COR.CorrespondenciaTrigger
GO
CREATE TRIGGER COR.CorrespondenciaTrigger
ON COR.Correspondencia
AFTER INSERT, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO AUD.Auditoria(
		Evento,
		Operacion,
		UsuarioCreaId
    )
    SELECT
        CONCAT('Creaci�n de nuevo registro, id: ', i.CorrespondenciaId, '  fecha:  ', CONVERT(varchar, GETDATE(), 21), '  usuario que realiza la operaci�n : ', i.UsuarioCreaId),
        'INS',
		i.UsuarioCreaId
    FROM
        inserted i
    UNION ALL
    SELECT
        CONCAT('Borrado de registro id: ', d.CorrespondenciaId , '  fecha:  ', CONVERT(varchar, GETDATE(), 21), ' usuario que realiza la operaci�n : ', d.UsuarioModificaId),
        'DEL',
		d.UsuarioModificaId
    FROM
        deleted d;
END