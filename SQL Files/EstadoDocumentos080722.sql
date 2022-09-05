--Select*from CEX_TipoCarga
Select* from CEX_Importacion
Select* from CEX_ImportacionREC
Select* from CEX_Documento
go
--(Case When b.Mre_flgFisico =1 or b.Mre_flgVirtual = 1 Then 1 Else 0 End) as Cantidad
Select Distinct 
       a.IdImportacion, a.cia_codcia,    --,c.documento, 
	   DocEnv  = cast(sum(d.Cantidad)as char(2))+ '/'+ cast(count(d.Total)as char(2)) ,
	   Estatus = (Case When d.Cantidad = d.Total Then 'Completado' Else 'Pendiente' End )   
From CEX_Importacion A
Left join CEX_ImportacionREC B on (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)
Left Join CEX_Documento C on (a.cia_codcia=c.cia_codcia and b.IdDocumento = c.iddocumento)
Left join (Select a.cia_codcia,a.IdImportacion,a.IdDocumento,
              (Case When a.Mre_flgFisico =1 or a.Mre_flgVirtual = 1 Then 1 Else 0 End) as Cantidad,
                (count(a.IdDocumento)) as Total  From  CEX_ImportacionREC a   Left Join CEX_Documento b on (a.cia_codcia=b.cia_codcia and a.IdDocumento = b.iddocumento)
				 where  b.flgDocumentoRec = 1 group by a.cia_codcia,a.IdImportacion,a.IdDocumento,a.Mre_flgFisico,a.Mre_flgVirtual )D
				 on (a.cia_codcia=d.cia_codcia and a.IdImportacion = d.IdImportacion ) 
group by a.IdImportacion, c.iddocumento,d.Cantidad, d.Total,a.cia_codcia

Left join (Select a.cia_codcia,a.IdImportacion,a.IdDocumento,
              (Case When a.Mre_flgFisico =1 or a.Mre_flgVirtual = 1 Then 1 Else 0 End) as Cantidad,
                (count(a.IdDocumento)) as Total  From  CEX_ImportacionENV a   Left Join CEX_Documento b on (a.cia_codcia=b.cia_codcia and a.IdDocumento = b.iddocumento)
				 where  b.flgDocumentoEnv = 1 group by a.cia_codcia,a.IdImportacion,a.IdDocumento,a.Mre_flgFisico,a.Mre_flgVirtual )E
				 on (a.cia_codcia=d.cia_codcia and a.IdImportacion = d.IdImportacion ) 
 --and a.IdImportacion=2097 
group by a.IdImportacion, c.iddocumento--,d.Cantidad, d.Total--,b.Mre_flgFisico, b.Mre_flgVirtual,c.flgDocumentoRec,   --,

--and a.IdImportacion=2097

--(Case When a.Mre_flgFisico = 0 or a.Mre_flgVirtual = 1 Then 1 Else 1 End)
--Cantidad extraida



--Nelio Script 080722
--Documentos recibidos
select a.IdImportacion, 
       count(*) as recibidos, 
	   total = (select count(*) from CEX_ImportacionREC where IdImportacion = a.IdImportacion and mre_flgfisico = 1 or mre_flgfisico = 1),
	   IIF(count() = (select count() from CEX_ImportacionREC where IdImportacion = a.IdImportacion and mre_flgfisico = 1 or mre_flgfisico = 1),'COMPLETO', 'PENDIENTE') as estado
from CEX_ImportacionREC a 
where (a.mre_flgfisico = 1 or a.mre_flgfisico = 1)
group by IdImportacion

--Documentos Enviados
select a.IdImportacion, 
       count(*) as enviados, 
	   total = (select count(*) from CEX_ImportacionENV where IdImportacion = a.IdImportacion and mre_flgfisico = 1 or mre_flgfisico = 1),
	   IIF(count() = (select count() from CEX_ImportacionENV where IdImportacion = a.IdImportacion and mre_flgfisico = 1 or mre_flgfisico = 1),'COMPLETO', 'PENDIENTE') as estado
from CEX_ImportacionENV a 
where (a.mre_flgfisico = 1 or a.mre_flgfisico = 1)
group by IdImportacion
------NS














Select a.IdImportacion,c.documento,
      -- ISNULL(b.Mre_flgFisico,0)Fisico,ISNULL(b.Mre_flgVirtual,0)Virtual, 
	  -- (Case When d.Cantidad = d.Total Then 'Completado' Else 'Pendiente' End )as Estatus,   
	 -- sum(d.Cantidad),sum(d.Total),
	  cast(sum(d.Cantidad)as char(2))+ '/'+ cast(count(d.Total)as char(2))as DocEnv	   
From CEX_Importacion a
Left join CEX_ImportacionREC b on (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)
Left Join CEX_Documento c on (a.cia_codcia=c.cia_codcia and b.IdDocumento = c.iddocumento)
Left join (Select a.cia_codcia,a.IdImportacion,a.IdDocumento,
              (Case When a.Mre_flgFisico =1 or a.Mre_flgVirtual = 1 Then 1 Else 0 End) as Cantidad,
                (count(IdDocumento)) as Total  From  CEX_ImportacionREC a group by a.cia_codcia,a.IdImportacion,a.IdDocumento,a.Mre_flgFisico,a.Mre_flgVirtual)d on (a.cia_codcia=d.cia_codcia and a.IdImportacion = d.IdImportacion and b.IdDocumento = c.iddocumento) 
where  c.flgDocumentoRec = 1 --and a.IdImportacion=2097 
group by a.IdImportacion,d.Cantidad, d.Total,c.documento      --,b.Mre_flgFisico, b.Mre_flgVirtual,c.flgDocumentoRec--, 









--AUX
GO
Select a.IdImportacion,c.documento,(Case When b.Mre_flgFisico =1 or b.Mre_flgVirtual = 1 Then 1 Else 0 End) as Cantidad
From CEX_Importacion a
Left join CEX_ImportacionREC b on (a.cia_codcia=b.cia_codcia and a.IdImportacion=b.IdImportacion)
Left Join CEX_Documento c on (a.cia_codcia=c.cia_codcia and b.IdDocumento = c.iddocumento)
