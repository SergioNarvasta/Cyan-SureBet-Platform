SELECT a.local,a.visita,b.casa,b.cuota_local,b.cuota_empate,b.cuota_visita FROM bet_cab A 
   left join bet_det B ON A.idcab = B.idcab
   WHERE B.idcab IS NOT NULL

SELECT * FROM bet_cab A 
   left join bet_det B ON A.idcab = B.idcab
   WHERE B.idcab IS NOT NULL AND DAY(A.fecreg) = DAY(CURRENT_TIME);
--------
    $sqlpi = "SELECT *  FROM bet_cab A LEFT JOIN bet_det B ON A.idcab = B.idcab 
               WHERE B.idcab IS NOT NULL AND B.casa='Pinnacle' AND DAY(A.fecreg) = DAY(CURRENT_TIME)"; 
    $sqlob = "SELECT * FROM bet_cab A LEFT JOIN bet_det B ON A.idcab = B.idcab 
               WHERE B.idcab IS NOT NULL AND B.casa='OnceBet' AND DAY(A.fecreg) = DAY(CURRENT_TIME)"; 
    $datapi=mysqli_query($cn,$sqlpi); $dataob=mysqli_query($cn,$sqlob);
    $cantpi=mysqli_num_rows($datapi); 
    $cantob=mysqli_num_rows($dataob); 
    header("Location: operaciones.php?cpi=$cantpi&cob=$cantob");

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

/*
Autor     : SNarvasta 
Function  : PA_Procesa()
Fecha Cr  : 14/10/2022 22:12
Fecha Act : 15/10/2022 01:52
*/

 DELIMITER $$
CREATE PROCEDURE PA_Procesa_SB()
BEGIN
  DECLARE done INT DEFAULT FALSE;
  DECLARE pId, oId INT; 
  DECLARE p_lo, p_vi, o_lo, o_vi, comp varchar(30);
  DECLARE p_cu1, p_cu2, p_cu3, o_cu1, o_cu2, o_cu3 decimal(8,3);
  DECLARE macu1, macu2, macu3, res decimal(8,3);
  DECLARE casa1, casa2, casa3, merc1, merc2, merc3 varchar(30);
  DECLARE curPi CURSOR FOR SELECT Id,lo,vi,cuota1,cuota2,cuota3 FROM TempPi;
  DECLARE curOb CURSOR FOR SELECT Id,lo,vi,cuota1,cuota2,cuota3 FROM TempOb;
  DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

  CREATE TEMPORARY TABLE TempPi
       (Id int PRIMARY KEY AUTO_INCREMENT,lo varchar(30),vi varchar(30),cuota1 decimal(8,3),cuota2 decimal(8,3),cuota3 decimal(8,3));
  CREATE TEMPORARY TABLE TempOb
       (Id int PRIMARY KEY AUTO_INCREMENT,lo varchar(30),vi varchar(30),cuota1 decimal(8,3),cuota2 decimal(8,3),cuota3 decimal(8,3));

  INSERT INTO TempPi(lo,vi,cuota1,cuota2,cuota3)
  SELECT a.local,a.visita,b.cuota_local,b.cuota_empate,b.cuota_visita FROM bet_cab A 
    LEFT JOIN bet_det B ON A.idcab = B.idcab
  WHERE B.idcab IS NOT NULL AND B.casa='Pinnacle';
  INSERT INTO TempOb(lo,vi,cuota1,cuota2,cuota3)
  SELECT a.local,a.visita,b.cuota_local,b.cuota_empate,b.cuota_visita FROM bet_cab A 
    LEFT JOIN bet_det B ON A.idcab = B.idcab
  WHERE B.idcab IS NOT NULL AND B.casa='OnceBet'; 
  
  OPEN curPi;
  OPEN curOb;
  WHILE done = FALSE DO
  FETCH curPi INTO pId, p_lo, p_vi, p_cu1, p_cu2, p_cu3;
  FETCH curOb INTO oId, o_lo, o_vi, o_cu1, o_cu2, o_cu3;
  IF done = FALSE THEN
    IF (p_lo LIKE o_lo OR p_vi LIKE o_vi)  THEN
       IF p_cu1>=o_cu1 THEN 
          SET macu1=p_cu1; SET casa1='Pinnacle'; 
       ELSE 
         SET macu1=o_cu1; SET casa1='OnceBet'; 
       END IF;
       IF p_cu3>=o_cu3 THEN 
         SET macu3=p_cu3; SET casa3='Pinnacle'; 
       ELSE 
         SET macu3=o_cu3; SET casa3='OnceBet'; 
       END IF;
       IF macu1=p_cu1 AND macu3=p_cu3 THEN
         SET macu2=o_cu2; SET casa2='OnceBet';
       ELSEIF macu1=o_cu1 AND macu3=o_cu3 THEN
         SET macu2=p_cu2; SET casa2='Pinnacle';
       ELSE
         IF p_cu2>=o_cu2 THEN SET macu2=p_cu2; SET casa2='Pinnacle'; ELSE SET macu2=o_cu2; SET casa2='OnceBet'; END IF;
         SET comp=p_lo+' - '+p_vi;
       END IF;
    ELSE
    SET comp='No encontrado';
    END IF;
    
    SET res =(100/macu1)+(100/macu2)+(100/macu3);
    SET merc1='Ganador Local 90MIN'; SET merc2='Ganador Empate 90 MIN'; SET merc3='Ganador Visita 90MIN';
    
    INSERT INTO `bet` (`IdBet`,`Deporte`,`Competicion`,`Evento`,`FechaEv`,`Mercado1`,`Mercado2`,`Mercado3`,`Cuota1`,
                       `Cuota2`,`Cuota3`,`Casa1`,`Casa2`,`Casa3`,`Beneficio`,`Resultado`,`Limite`,`FechaReg`)
          VALUES (NULL, 'Futbol', NULL, comp, NULL, merc1, merc2, merc3, macu1, 
                        macu2, macu3, casa1, casa2, casa3, NULL, res, NULL,CURRENT_TIME);   
  END IF;
END WHILE;

CLOSE curPi;
CLOSE curOb;

END;

DELIMITER ;
CALL PA_Procesa();
