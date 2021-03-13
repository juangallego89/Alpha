-- =============================================  
-- Autor:  <Author,Juan David Gallego Giraldo>  
-- Create date: <Create Date, 12-03-2021>  
-- Description: <Description, Crea una vista para consulta de comunicaciones en un rango de fechas>  
-- =============================================
USE Alpha
GO
DROP VIEW IF EXISTS COR.VistaCorrespondencia
GO
CREATE VIEW COR.VistaCorrespondencia
AS
SELECT 
cor.FechaRadicacion AS 'Fecha de radicacion',
CONCAT(per.PrimerNombre, ' ', per.SegundoNombre, ' ', per.PrimerApellido, ' ', per.SegundoApellido) AS 'Remitente',
cor.NumeroRadicado AS 'Numero de radicado',
cor.Tipo,
cor.Estado,
arc.Ruta
FROM COR.Correspondencia cor
INNER JOIN ADM.Persona per ON cor.RemitentePersonaId = per.PersonaId
INNER JOIN COR.Archivos arc ON arc.CorrespondenciaId = arc.CorrespondenciaId
AND cor.Activo = 1
AND per.Activo = 1
AND arc.Activo = 1
GO

SELECT *
FROM COR.VistaCorrespondencia vcor
WHERE vcor.[Fecha de Radicacion] BETWEEN '2021-01-01' AND '2021-05-01'
