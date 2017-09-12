IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SP_SelecionaUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SP_SelecionaUsuario]
GO 

CREATE PROCEDURE [dbo].[SP_SelecionaUsuario]
	
	AS

	/*
	Documentação
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: busca todos os usuarios
	Autor.............: Douglas Karpinski
 	Data..............: 12/09/2017
	Ex................: EXEC [dbo].[SP_SelecionaUsuario]
	*/

	BEGIN
		SELECT * FROM [dbo].[Usuario]
	END
GO
