USE [Trauma_V15]
GO

/****** Object:  StoredProcedure [dbo].[PA_HD_REP_Avance_Ventas_Trauma_x_Vendedor_mail]    Script Date: 25/10/2018 08:21:01 a.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[PA_HD_REP_FEL_No_EnviadasSUNAT]
@codcia int
/**************************************************************
 Procedimiento	: PA_HD_REP_FEL_No_EnviadasSUNAT
 Proposito		: Generará un reporte las facturas electronicas NO ENVIADAS a SUNAT
 Inputs			: codigo de compañia

 Se asume		: Solo se devolveran los documentos de la vista V_DOC_VENTAS_DTE
 Efectos		: Ninguno
 Retorno		: Ninguno
 Notas			:
 Modificaciones	: 
 Autor			: Gerardo Cherre
 Fecha y Hora	: 24/08/2020
 Modificacion   : GCHERRE 20211220 - Alerta cuando documento tiene mas de 2 dias de emitido
**************************************************************/
AS
SET NOCOUNT ON

Declare @c_DirEmail_cc varchar(200), @c_DirBcc varchar(300),  @c_Subject varchar(500)
Declare @c_CodALE varchar(8), @Dias int ,@cant int
Declare @fecrep smalldatetime = getdate()
Declare @tdo_codtdo varchar(3), @grc_numero varchar(15),@fecha varchar(10),@ccr_nomaux varchar(150), @motivo varchar(40),@ubille char(8)


DECLARE @datos_table TABLE(
	c1 varchar(3),    -- TDoc
	c2 varchar(15),   -- NDoc
	c3 varchar(10),   -- Fecha
	c4 varchar(150),  -- Cliente
	c5 varchar(20)    -- Motivo
	);

DECLARE @Body Nvarchar(MAX),
		@TableHead VARCHAR(1000),
		@Table  VARCHAR(1000),
		@TableTail VARCHAR(1000),
		@TableHTML Nvarchar(MAX),
		@TableTotal Nvarchar(MAX)

Set @Dias = 5
Set @c_DirBcc      = 'sergio.narvasta@helpdesk.com.pe;'
Set @c_DirEmail_cc = 'sergio.narvasta@helpdesk.com.pe;'

Set @c_CodALE = 'ALERTA01'
Set @c_DirEmail_cc = 'sergio.narvasta@helpdesk.com.pe;'
/*(Select Isnull(dtepar_valstr,'') From DTE_Parametros_DtePar Where dtepar_estado='1' and dtepar_cod=@c_codALE)*/

If Len(@c_DirEmail_cc)<=0
Begin
   Print 'No hay parametros para envio de EMAILs de ALERTA01'
   return 
End 

If ( Exists(Select distinct 
       tdo_codtdo, grc_numero,Convert(varchar,grc_fecemi,103)
      From V_GUIAS_DTE
      Where 
	   cia_codcia=@codcia and grc_estado='1' 
	   and ano_codano= YEAR(@fecrep)     and Left(grc_numero,1)='T' 
	   and Isnull(dte_sitdte,'0') in ('0','1','2') and  DATEDIFF(dd,grc_fecemi,getdate())>=@Dias ) )
Begin
   
   	SET @TableTail = '</body></html>' ;

	SET @TableHead = '<html><head>' + '<style>'
		+ 'table {width:60%;} '
		+ 'table, th, td {border: 1px solid black; border-collapse: collapse; font: 11px arial;} '
		+ 'th, td {padding: 5px ;} '
		+ 'td {text-align: center;} '
		+ 'table tr:nth-child(even) {background-color: blue;} '
		+ 'table tr:nth-child(odd) {background-color: gray; } '
		+ 'table th { background-color: blue; color: white; } ' 
		+ '</style>' + '</head>' 
		+ '<body>' 
		+ '<h1>ALERTA de fecha : ' + CONVERT(VARCHAR(50), @fecrep, 106) + '</h1> ' 
		+ '<p><b>Los siguientes documentos electronicos no han sido ENVIADOS A SUNAT:</b></p> ' 

	 SET @Table = '<table> '
		+ ' <caption style="color: white;font: 18px arial;">Listado de Documentos Pendientes</caption> '
		+ '<tr>'
		+ '<th >TDoc</th>'
		+ '<th >NroDoc</th>'
		+ '<th >Fecha</th>'
		+ '<th >Cliente</th>'
		+ '<th >Motivo</th>'
		+ '</tr>' ;
		/*Crea Tabla Temporal*/
        DROP TABLE ##Tempo;
		Select distinct tdo_codtdo, grc_numero,Convert(varchar,grc_fecemi,103)as fecha,ccr_nomaux,Space(40)as motivo
        into ##Tempo
		From V_GUIAS_DTE
        Where cia_codcia=@codcia and grc_estado='1'  and ano_codano=Year(@fecrep)   and Left(grc_numero,1)='T' 
	    and Isnull(dte_sitdte,'0') in ('0','1','2')  and  DATEDIFF(dd,grc_fecemi,getdate())>=@Dias
		/*Crea Cursor */
		Declare cur_cot cursor for
		Select distinct tdo_codtdo, grc_numero,Convert(varchar,grc_fecemi,103)as fecha,ccr_nomaux,Space(40)as motivo,grc_ubille
		From V_GUIAS_DTE
        Where cia_codcia=@codcia and grc_estado='1'  and ano_codano=Year(@fecrep)   and Left(grc_numero,1)='T' 
	    and Isnull(dte_sitdte,'0') in ('0','1','2')  and  DATEDIFF(dd,grc_fecemi,getdate())>=@Dias

	    open cur_cot
	    fetch next from cur_cot into @tdo_codtdo, @grc_numero,@fecha,@ccr_nomaux, @motivo ,@ubille
	    While (@@FETCH_STATUS = 0)
        Begin 
	       (Select @cant = count(grc_numero) From V_Guias_DTE Where grc_numero = @grc_numero Group by kad_cankgs Having kad_cankgs =0)
		   IF (@cant > 0)
		   Begin
		     Update ##Tempo
			 SET motivo =Concat(Cast(@cant as Char(2)),' Item sin Peso')
			 Where grc_numero = @grc_numero
		   End
		   
		   If(ISNULL(@ubille,'')='')
		   Begin
		      Update ##Tempo
			  SET motivo = iif(len(motivo)>0,Concat(motivo,'y sin ubigeo'),Concat(motivo,'Item sin ubigeo'))
			  Where grc_numero = @grc_numero
		   End
		  
	    fetch next from cur_cot into @tdo_codtdo, @grc_numero,@fecha,@ccr_nomaux, @motivo, @ubille
	    End
	    Close cur_cot;
        Deallocate cur_cot;
		delete from @datos_table

		insert into @datos_table (c1,c2,c3,c4,c5)
	    Select *from ##Tempo

		SET @Body = (
		Select 
		td = c1,
		td = c2,
		td = c3,
		td = c4,
		td = c5
		from @datos_table
		order by c3 desc
		FOR   XML RAW('tr'),
                  ELEMENTS )

        SELECT @TableTotal = @Table + ISNULL(@Body, '') + '</table> <br><br><HR><em>Email enviado automaticamente por el sistema HDSOFT - Facturacion Electronica. (tildes omitidos por compatibilidad)</em> '

		Set @c_Subject = 'HDSOFT - ALERTA DE GUIA DE REMISION ELECTRONICA al :' + CONVERT(VARCHAR(50), @fecrep, 106)
		SELECT @TableHTML = @TableHead + @TableTotal + @TableTail
		EXEC msdb.dbo.sp_send_dbmail 
			@profile_name='Profile OperadorHD',
			@recipients=@c_DirEmail_cc,
			@blind_copy_recipients = @c_DirBcc,
			@subject= @c_Subject,
			@body = @tableHTML,
			@body_format = 'HTML' ;
        
		Print 'Envio de Alerta 01 '
End
/*****

Declare @fecha smalldatetime
Set @fecha = convert(smalldatetime, '19/02/2018', 103)

Exec PA_HD_REP_FEL_No_EnviadasSUNAT @codcia=1

*****/
GO


