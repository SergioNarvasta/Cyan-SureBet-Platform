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

  /************/
    /*  
  Recorrer la informacion de Ob y comparar con la casa Pi
  Si el local Ob es igual a local Pi 
  Hallar couta mayor de local y visita en ambas casas,
  Si (local y visita son de la misma casa)-> cuota empate se halla de la casa contraria
  Sino() -> hallar mayor cuota empate
  Sumar(100/lo)+(100/em)+(100/vi) si es menor a 100 -> es una surebet
  
  */
  DELIMITER $$
CREATE PROCEDURE PA_Procesa()
BEGIN
  CREATE TEMPORARY TABLE TempPi(Id int PRIMARY KEY AUTO_INCREMENT,lo varchar(30),vi varchar(30),cuota1 decimal(8,3),cuotax decimal(8,3),cuota2 decimal(8,3));
  CREATE TEMPORARY TABLE TempOb(Id int PRIMARY KEY AUTO_INCREMENT,lo varchar(30),vi varchar(30),cuota1 decimal(8,3),cuotax decimal(8,3),cuota2 decimal(8,3));

  INSERT INTO TempPi(lo,vi,cuota1,cuotaX,cuota2)
  SELECT a.local,a.visita,b.cuota_local,b.cuota_empate,b.cuota_visita FROM bet_cab A 
    LEFT JOIN bet_det B ON A.idcab = B.idcab
  WHERE B.idcab IS NOT NULL AND B.casa='Pinnacle';
  
  INSERT INTO TempOb(lo,vi,cuota1,cuotaX,cuota2)
  SELECT a.local,a.visita,b.cuota_local,b.cuota_empate,b.cuota_visita FROM bet_cab A 
    LEFT JOIN bet_det B ON A.idcab = B.idcab
  WHERE B.idcab IS NOT NULL AND B.casa='OnceBet';
  
  SELECT*FROM TempPi;
  SELECT*FROM TempOb;
END;
---
 DELIMITER $$
CREATE PROCEDURE PA_Procesa()
BEGIN
  CREATE TEMPORARY TABLE TempPi
         (Id int PRIMARY KEY AUTO_INCREMENT,lo varchar(30),vi varchar(30),cuota1 decimal(8,3),cuotax decimal(8,3),cuota2 decimal(8,3),res decimal(8,3));
  CREATE TEMPORARY TABLE TempOb
         (Id int PRIMARY KEY AUTO_INCREMENT,lo varchar(30),vi varchar(30),cuota1 decimal(8,3),cuotax decimal(8,3),cuota2 decimal(8,3),res decimal(8,3));

  INSERT INTO TempPi(lo,vi,cuota1,cuotax,cuota2)
  SELECT a.local,a.visita,b.cuota_local,b.cuota_empate,b.cuota_visita,space(10)as Resultado FROM bet_cab A 
    LEFT JOIN bet_det B ON A.idcab = B.idcab
  WHERE B.idcab IS NOT NULL AND B.casa='Pinnacle';
  
  INSERT INTO TempOb(lo,vi,cuota1,cuotax,cuota2)
  SELECT a.local,a.visita,b.cuota_local,b.cuota_empate,b.cuota_visita,space(10)as Resultado FROM bet_cab A 
    LEFT JOIN bet_det B ON A.idcab = B.idcab
  WHERE B.idcab IS NOT NULL AND B.casa='OnceBet';
  
  DECLARE p_Id INT, p_lo varchar(30), p_vi varchar(30), p_cu1 decimal(8,3), p_cux decimal(8,3), p_cu2 decimal(8,3);
  DECLARE o_Id INT, o_lo varchar(30), o_vi varchar(30), o_cu1 decimal(8,3), o_cux decimal(8,3), o_cu2 decimal(8,3);
  DECLARE macu1, macux, macu2 decimal(8,3);
  DECLARE curPi CURSOR FOR SELECT Id,lo,vi,cuota1,cuotax,cuota2 FROM TempPi;
  DECLARE curOb CURSOR FOR SELECT Id,lo,vi,cuota1,cuotax,cuota2 FROM TempOb;
  DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
  OPEN curPi;
  OPEN curOb;
  
  WHILE done = FALSE DO
  FETCH curPi INTO p_Id, p_lo, p_vi, p_cu1, p_cux, p_cu2;
  FETCH curOb INTO o_Id, o_lo, o_vi, o_cu1, o_cux, p_cu2;
  IF done = FALSE THEN
    IF (p_lo LIKE o_lo OR p_vi LIKE o_vi)  THEN
       macu1 = iif(p_cu1>o_cu1, p_cu1, o_cu1);
       macu2 = iif(p_cu2>o_cu2, p_cu2, o_cu2);
       
      INSERT INTO test.t3 VALUES (a,b);
    ELSE
      INSERT INTO test.t3 VALUES (a,c);
    END IF;
  END IF;
END WHILE;

CLOSE cur1;


END;
  
  /*
  Crea TempOb
  Crea cursor para Pinnacle, Recorre y compara con TempOb
  Almacena informacion en TempRes
  
  Recorrer la informacion de Ob y comparar con la casa Pi
  Si el local Ob es igual a local Pi 
  Hallar couta mayor de local y visita en ambas casas,
  Si (local y visita son de la misma casa)-> cuota empate se halla de la casa contraria
  Sino() -> hallar mayor cuota empate
  Sumar(100/lo)+(100/em)+(100/vi) si es menor a 100 -> es una surebet
  
  local visita cuota1 cuotax cuota2 resultado
  */