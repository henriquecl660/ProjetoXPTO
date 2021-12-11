CREATE PROCEDURE PR_UPD_TB_XPTO_OS

   @NUM_OS INT 
  ,@TITULO_SERV VARCHAR(150)
  ,@CNPJ_CLI NUMERIC (14,0)
  ,@NOME_CLI VARCHAR(150)
  ,@CPF_PREST NUMERIC (11,0)
  ,@NOME_PREST VARCHAR(150)
  ,@DATA_SERV  DATE
  ,@VALOR_SERV NUMERIC (13,2)

AS 

UPDATE TB_XPTO_OS SET
	   TITULO_SERV  =      @TITULO_SERV
	  ,CNPJ_CLI		=	   @CNPJ_CLI
   	  ,NOME_CLI		=	   @NOME_CLI
	  ,CPF_PREST	=	   @CPF_PREST
	  ,NOME_PREST	=	   @NOME_PREST
	  ,DATA_SERV	=	   @DATA_SERV
	  ,VALOR_SERV	=	   @VALOR_SERV
WHERE  NUM_OS       =      @NUM_OS
  

  