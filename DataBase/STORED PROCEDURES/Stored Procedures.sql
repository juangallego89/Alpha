USE Alpha
GO  
DROP PROCEDURE IF EXISTS COR.CrearCorrespondencia 
GO
-- =============================================  
-- Autor:  <Author,Juan David Gallego Giraldo>  
-- Create date: <Create Date, 12-03-2021>  
-- Description: <Description, Inserta un nuevo registro en la tabla COR.Correspondencia>  
-- =============================================
CREATE PROC COR.CrearCorrespondencia (
@numeroRadicado varchar(10) OUT,
@correspondenciaId bigint OUT,
@usuarioId bigint,
@remitenteId bigint,
@destinatarioId bigint,
@fechaRadicacion datetime,
@tipo varchar(5),
@estado varchar(10),
@ruta varchar(200))
AS
BEGIN
  BEGIN TRY 

  	  IF @tipo = 'CE'
		SET @numeroRadicado = RIGHT('CE000000' +  CAST(NEXT VALUE FOR COR.CorrespondenciaExterna AS VARCHAR(10)), 10)
	  ELSE IF @tipo = 'CI'
	  	SET @numeroRadicado = RIGHT('CI000000' +  CAST(NEXT VALUE FOR COR.CorrespondenciaInterna AS VARCHAR(10)), 10)
	  ELSE
		RETURN

	  INSERT INTO COR.Correspondencia
	  (
		NumeroRadicado,
		UsuarioCreaId,
		FechaRadicacion,
		RemitentePersonaId,
		DestinatarioPersonaId,
		Tipo,
		Estado
	  )
	  VALUES
	  (
		@numeroRadicado,
		@usuarioId,
		@fechaRadicacion,
		@remitenteId,
		@destinatarioId,
		@tipo,
		@estado
	  )
	  SET @correspondenciaId = SCOPE_IDENTITY()

	  INSERT INTO COR.Archivos
	  (
		CorrespondenciaId,
		Ruta,
		UsuarioCreaId
	  )
	  VALUES
	  (
		@correspondenciaId,
		@ruta,
		@usuarioId
	  )
  END TRY
  BEGIN CATCH
    SELECT
      ERROR_NUMBER() AS ErrorNumber,
      ERROR_SEVERITY() AS ErrorSeverity,
      ERROR_STATE() AS ErrorState,
      ERROR_PROCEDURE() AS ErrorProcedure,
      ERROR_LINE() AS ErrorLine,
      ERROR_MESSAGE() AS ErrorMessage;
  END CATCH
END;
GO