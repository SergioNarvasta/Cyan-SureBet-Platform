

SELECT a.tcc_codepk,a.tdo_codtdo,a.tcc_numdoc,c.tdo_codtdo,c.dte_codtip,dte_destip,b.tcc_codepk,b.*
FROM TRAN_CTACTE_TCC a
LEFT JOIN TRAN_DOCCOB_DTE b
ON a.tcc_codepk = b.tcc_codepk and a.cia_codcia=b.cia_codcia and a.suc_codsuc=b.suc_codsuc
left join DTE_Tipo_NCR_NDB c
ON b.DTE_CODTIP = c.dte_codtip 
WHERE a.cia_codcia=1 and a.suc_codsuc=1 and a.tcc_codepk =' 2207000024'
and a.tdo_codtdo = 'NCR'
order by a.tcc_numdoc
--and tcc_codepk = 2205000133 

SELECT* FROM TRAN_DOCCOB_DTE
SELECT *
FROM TRAN_CTACTE_TCC a
WHERE tcc_codepk =' 2207000024'
SELECT*FROM TRAN_DOCCOB_DTE
SELECT*FROM DTE_Tipo_NCR_NDB
GO
--VER DOCUMENTOS POR TIPO
SELECT tcc_codepk,tcc_numtcc,ccr_codepk,tcc_numdoc,tcc_numdoc
FROM TRAN_CTACTE_TCC
WHERE tdo_codtdo = 'NCR'
--ORDER BY tcc_numdoc


Select dte_codtip,dte_destip,tdo_codtdo 
From DTE_Tipo_NCR_NDB 
Where dte_estado=1 and tdo_codtdo='NCR'