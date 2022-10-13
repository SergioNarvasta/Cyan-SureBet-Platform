SELECT a.local,a.visita,b.casa,b.cuota_local,b.cuota_empate,b.cuota_visita FROM bet_cab A 
   left join bet_det B ON A.idcab = B.idcab
   WHERE B.idcab IS NOT NULL

SELECT  RIGHT(B.idcab,2), A.idcab,
        A.local,
        A.visita,
        B.casa,
        B.cuota_local,
        B.cuota_empate,
        B.cuota_visita 
FROM bet_cab A 
LEFT JOIN bet_det B ON A.idcab = B.idcab
WHERE B.idcab IS NOT NULL
GROUP BY  RIGHT(A.idcab,2),A.local,A.visita,B.casa,B.cuota_local,B.cuota_empate,B.cuota_visita 
HAVING COUNT (*)>1

/*CREAR TABLAS TEMPORALES PARA ALMACENAR INFO Y PROCESAR SUREBETS*/
/*INPUT = DATA DE CASAS, OUTPUT= SUREBETS*/

  CREATE TEMPORARY TABLE TempPinnacle
     (Id int PRIMARY KEY AUTO_INCREMENT,lo varchar(30),vi varchar(30),cuota1 decimal(8,3),cuotax decimal(8,3),cuota2 decimal(8,3));
  CREATE TEMPORARY TABLE TempOncebet
     (Id int PRIMARY KEY AUTO_INCREMENT,lo varchar(30),vi varchar(30),cuota1 decimal(8,3),cuotax decimal(8,3),cuota2 decimal(8,3));

  INSERT INTO TempPinnacle(lo,vi,cuota1,cuotaX,cuota2)
  SELECT a.local,a.visita,b.cuota_local,b.cuota_empate,b.cuota_visita FROM bet_cab A 
    LEFT JOIN bet_det B ON A.idcab = B.idcab
  WHERE B.idcab IS NOT NULL AND B.casa='Pinnacle';
  
  INSERT INTO TempOncebet(lo,vi,cuota1,cuotaX,cuota2)
  SELECT a.local,a.visita,b.cuota_local,b.cuota_empate,b.cuota_visita FROM bet_cab A 
    LEFT JOIN bet_det B ON A.idcab = B.idcab
  WHERE B.idcab IS NOT NULL AND B.casa='OnceBet';
  
  SELECT*FROM TempPinnacle;
  SELECT*FROM TempOncebet