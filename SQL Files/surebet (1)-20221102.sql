-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 02-11-2022 a las 14:29:38
-- Versión del servidor: 8.0.27
-- Versión de PHP: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `surebet`
--

DELIMITER $$
--
-- Procedimientos
--
DROP PROCEDURE IF EXISTS `PA_Procesa`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PA_Procesa` ()  BEGIN
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
END$$

DROP PROCEDURE IF EXISTS `PA_Procesa_SB`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PA_Procesa_SB` ()  BEGIN
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

END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bet`
--

DROP TABLE IF EXISTS `bet`;
CREATE TABLE IF NOT EXISTS `bet` (
  `IdBet` int NOT NULL AUTO_INCREMENT,
  `Deporte` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Competicion` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Evento` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `FechaEv` varchar(16) DEFAULT NULL,
  `Mercado1` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Mercado2` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Mercado3` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Cuota1` decimal(8,2) DEFAULT NULL,
  `Cuota2` decimal(8,2) DEFAULT NULL,
  `Cuota3` decimal(8,2) DEFAULT NULL,
  `Casa1` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Casa2` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Casa3` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Beneficio` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Resultado` decimal(8,3) DEFAULT NULL,
  `Limite` int DEFAULT NULL,
  `FechaReg` datetime NOT NULL,
  PRIMARY KEY (`IdBet`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `bet`
--

INSERT INTO `bet` (`IdBet`, `Deporte`, `Competicion`, `Evento`, `FechaEv`, `Mercado1`, `Mercado2`, `Mercado3`, `Cuota1`, `Cuota2`, `Cuota3`, `Casa1`, `Casa2`, `Casa3`, `Beneficio`, `Resultado`, `Limite`, `FechaReg`) VALUES
(1, 'Futbol', NULL, 'Shrewsbury Town – Oxford United', '09/11\r\n14:45', 'H1(+0.25)', 'X', '2', '1.69', '3.14', '3.00', 'Pinnacle', 'Chaskibet', 'Bet365', '       1,00 % \r', '101.000', 1500, '2022-11-01 22:48:22'),
(2, 'Futbol', NULL, 'Ferroviaria (W) – Portuguesa de Desporto', '02/11\r\n15:00', 'H2(+3)', '1(0:2)', '1(0:3)', '2.45', '1.51', '2.14', 'Pinnacle', 'Chaskibet', 'Bet365', '       1,00 % \r', '101.000', 1500, '2022-11-01 22:48:23'),
(3, 'Futbol', NULL, 'Cruzeiro EC – Centro Sportivo Alagoano', '06/11\r\n15:30', '1 / DNB', 'X', '2', '1.33', '3.41', '6.00', 'Pinnacle', 'Chaskibet', 'Bet365', '       1,00 % \r', '101.000', 1500, '2022-11-01 22:48:23'),
(4, 'Futbol', NULL, 'Juventus – PSG', '02/11\r\n15:00', '2 / DNB', 'X', 'H1(−0.5)', '1.31', '4.25', '5.88', 'Pinnacle', 'Chaskibet', 'Bet365', '       1,00 % \r', '101.000', 1500, '2022-11-01 22:48:23'),
(5, 'Futbol', NULL, 'US Lecce – Atalanta Bergamasca Calcio', '09/11\r\n12:30', '2 / DNB', 'X', '1', '1.44', '3.67', '4.75', 'Pinnacle', 'Chaskibet', 'Bet365', '       1,00 % \r', '101.000', 1500, '2022-11-01 22:48:23'),
(6, 'Futbol', NULL, 'Wolves – Arsenal', '12/11\r\n14:45', 'H1(−0.25)', 'X', '2 / DNB', '5.20', '4.20', '1.31', 'Pinnacle', 'Chaskibet', 'Bet365', '       1,00 % \r', '101.000', 1500, '2022-11-01 22:48:23'),
(7, 'Futbol', NULL, 'CFR 1907 Cluj – KF Ballkani', '03/11\r\n12:45', 'H2(+3) - saques de esquina', 'X(0:3) - saques de esquina', '1(0:3) - saques de esquina', '2.00', '6.50', '2.42', 'Pinnacle', 'Chaskibet', 'Bet365', '       1,00 % \r', '101.000', 1500, '2022-11-01 22:48:23');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bet_cab`
--

DROP TABLE IF EXISTS `bet_cab`;
CREATE TABLE IF NOT EXISTS `bet_cab` (
  `idcab` varchar(16) NOT NULL,
  `deporte` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `local` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `visita` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `feceve` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `fecreg` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bet_det`
--

DROP TABLE IF EXISTS `bet_det`;
CREATE TABLE IF NOT EXISTS `bet_det` (
  `idcab` varchar(16) NOT NULL,
  `iddet` int NOT NULL AUTO_INCREMENT,
  `casa` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `cuota_local` decimal(8,3) DEFAULT NULL,
  `cuota_empate` decimal(8,3) DEFAULT NULL,
  `cuota_visita` decimal(8,3) DEFAULT NULL,
  `fecreg` datetime DEFAULT NULL,
  PRIMARY KEY (`iddet`),
  UNIQUE KEY `iddet` (`iddet`)
) ENGINE=MyISAM AUTO_INCREMENT=196 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `bet_det`
--

INSERT INTO `bet_det` (`idcab`, `iddet`, `casa`, `cuota_local`, `cuota_empate`, `cuota_visita`, `fecreg`) VALUES
('PiShakhtaRB Leip', 1, 'Pinnacle', '5.170', '4.240', '1.662', '2022-11-01 22:44:14'),
('PiReal MaCeltic', 2, 'Pinnacle', '1.236', '6.560', '13.160', '2022-11-01 22:44:14'),
('PiFC CopeBorussi', 3, 'Pinnacle', '4.840', '3.950', '1.751', '2022-11-01 22:44:14'),
('PiJuventuParis S', 4, 'Pinnacle', '5.530', '4.280', '1.621', '2022-11-01 22:44:14'),
('PiMaccabiBenfica', 5, 'Pinnacle', '4.950', '4.350', '1.671', '2022-11-01 22:44:14'),
('PiManchesSevilla', 6, 'Pinnacle', '1.249', '6.500', '11.990', '2022-11-01 22:44:14'),
('PiChelseaDinamo ', 7, 'Pinnacle', '1.340', '5.610', '9.310', '2022-11-01 22:44:14'),
('PiAC MilaRed Bul', 8, 'Pinnacle', '1.507', '4.480', '6.870', '2022-11-01 22:44:14'),
('PiReal SoManches', 9, 'Pinnacle', '3.280', '3.520', '2.250', '2022-11-01 22:44:14'),
('PiSheriffOmonia ', 10, 'Pinnacle', '1.952', '3.570', '4.140', '2022-11-01 22:44:14'),
('PiOlympiaNantes', 11, 'Pinnacle', '3.380', '3.660', '2.150', '2022-11-01 22:44:14'),
('PiFC MidtSturm G', 12, 'Pinnacle', '1.917', '3.840', '3.960', '2022-11-01 22:44:14'),
('PiAS MonaCrvena ', 13, 'Pinnacle', '1.632', '4.300', '5.190', '2022-11-01 22:44:14'),
('PiTrabzonFerencv', 14, 'Pinnacle', '1.574', '4.330', '5.860', '2022-11-01 22:44:14'),
('PiFK QaraFreibur', 15, 'Pinnacle', '2.010', '3.800', '3.650', '2022-11-01 22:44:14'),
('PiFeyenooLazio', 16, 'Pinnacle', '2.240', '3.700', '3.160', '2022-11-01 22:44:14'),
('PiRennesAEK Lar', 17, 'Pinnacle', '1.177', '7.630', '16.190', '2022-11-01 22:44:14'),
('PiBodo GlPSV Ein', 18, 'Pinnacle', '3.270', '4.000', '2.090', '2022-11-01 22:44:14'),
('PiReal BeHJK Hel', 19, 'Pinnacle', '1.255', '5.970', '12.550', '2022-11-01 22:44:14'),
('PiDinamo Fenerba', 20, 'Pinnacle', '4.070', '3.710', '1.925', '2022-11-01 22:44:14'),
('Obainz 05Wolfsbu', 21, 'OnceBet', '2.000', '3.800', '3.450', '2022-11-01 22:44:22'),
('OboffenheRB Leip', 22, 'OnceBet', '4.300', '4.000', '1.750', '2022-11-01 22:44:22'),
('ObWerder Schalke', 23, 'OnceBet', '1.300', '5.800', '9.000', '2022-11-01 22:44:22'),
('Obayer LeUnion B', 24, 'OnceBet', '9.000', '5.800', '1.300', '2022-11-01 22:44:22'),
('ObGirona Athleti', 25, 'OnceBet', '2.000', '3.800', '3.450', '2022-11-01 22:44:22'),
('ObValladoElche', 26, 'OnceBet', '2.850', '3.600', '2.350', '2022-11-01 22:44:22'),
('ObCelta dOsasuna', 27, 'OnceBet', '1.650', '4.200', '4.800', '2022-11-01 22:44:22'),
('ObBarceloAlmerí', 28, 'OnceBet', '2.100', '3.700', '3.250', '2022-11-01 22:44:22'),
('ObtléticEspanyo', 29, 'OnceBet', '1.800', '3.900', '4.150', '2022-11-01 22:44:22'),
('ObReal S.Valenci', 30, 'OnceBet', '4.100', '3.400', '1.950', '2022-11-01 22:44:22'),
('ObVillarrMallorc', 31, 'OnceBet', '1.950', '3.400', '4.100', '2022-11-01 22:44:22'),
('ObRayo VaReal M', 32, 'OnceBet', '1.800', '3.550', '4.650', '2022-11-01 22:44:22'),
('ObTroyes Auxerre', 33, 'OnceBet', '2.050', '3.350', '3.750', '2022-11-01 22:44:22'),
('ObAjaccioStrasbo', 34, 'OnceBet', '1.100', '10.000', '22.000', '2022-11-01 22:44:22'),
('ObAngers Lens', 35, 'OnceBet', '4.200', '7.200', '1.080', '2022-11-01 22:44:22'),
('Oborient Paris S', 36, 'OnceBet', '3.400', '4.300', '1.190', '2022-11-01 22:44:22'),
('OblermontMontpel', 37, 'OnceBet', '3.900', '5.850', '1.110', '2022-11-01 22:44:22'),
('OboulouseMonaco', 38, 'OnceBet', '4.000', '1.550', '2.350', '2022-11-01 22:44:22'),
('ObLille OStade R', 39, 'OnceBet', '3.400', '4.300', '1.190', '2022-11-01 22:44:22'),
('ObMarseilLyon', 40, 'OnceBet', '3.250', '2.650', '1.450', '2022-11-01 22:44:22'),
('ObUdineseLecce', 41, 'OnceBet', '3.600', '1.750', '2.000', '2022-11-01 22:44:23'),
('ObalernitCremone', 42, 'OnceBet', '5.700', '1.320', '3.150', '2022-11-01 22:44:23'),
('Obmpoli Sassuol', 43, 'OnceBet', '2.350', '3.250', '3.150', '2022-11-01 22:44:23'),
('ObAtalantNapoli', 44, 'OnceBet', '2.150', '1.800', '3.550', '2022-11-01 22:44:23'),
('ObAC MilaSpezia', 45, 'OnceBet', '1.320', '3.150', '2.150', '2022-11-01 22:44:23'),
('Obologna Torino ', 46, 'OnceBet', '1.950', '1.530', '2.400', '2022-11-01 22:44:23'),
('Obonza CaHellas ', 47, 'OnceBet', '2.300', '1.580', '2.550', '2022-11-01 22:44:23'),
('ObampdoriFiorent', 48, 'OnceBet', '1.460', '2.050', '1.720', '2022-11-01 22:44:23'),
('ObJuventuInter M', 49, 'OnceBet', '1.300', '1.620', '2.100', '2022-11-01 22:44:23'),
('ObSpezia Udinese', 50, 'OnceBet', '1.100', '1.220', '2.350', '2022-11-01 22:44:23'),
('ObCremoneAC Mila', 51, 'OnceBet', '3.300', '1.300', '1.240', '2022-11-01 22:44:23'),
('ObLecce Atalant', 52, 'OnceBet', '3.250', '2.500', '1.500', '2022-11-01 22:44:23'),
('ObInter MBologna', 53, 'OnceBet', '3.450', '3.800', '2.000', '2022-11-01 22:44:23'),
('ObTorino Sampdor', 54, 'OnceBet', '1.480', '1.250', '6.000', '2022-11-01 22:44:23'),
('ObFiorentSalerni', 55, 'OnceBet', '1.700', '2.100', '2.850', '2022-11-01 22:44:23'),
('ObHellas Juventu', 56, 'OnceBet', '2.150', '2.000', '1.750', '2022-11-01 22:44:23'),
('ObLazio Monza C', 57, 'OnceBet', '1.870', '1.870', '1.550', '2022-11-01 22:44:23'),
('ObReal M Glasgow', 58, 'OnceBet', '1.190', '1.750', '2.000', '2022-11-01 22:44:23'),
('ObShakhtaRB Leip', 59, 'OnceBet', '1.240', '1.800', '1.950', '2022-11-01 22:44:23'),
('ObMaccabiSL Benf', 60, 'OnceBet', '1.530', '1.310', '1.350', '2022-11-01 22:44:23'),
('ObManchesSevilla', 61, 'OnceBet', '18.000', '1.060', '5.000', '2022-11-01 22:44:23'),
('ObAC MilaSalzbur', 62, 'OnceBet', '1.750', '2.000', '1.260', '2022-11-01 22:44:23'),
('ObFC CopeBorussi', 63, 'OnceBet', '4.100', '1.500', '2.500', '2022-11-01 22:44:23'),
('ObChelseaDynamo ', 64, 'OnceBet', '3.950', '3.900', '1.850', '2022-11-01 22:44:23'),
('ObJuventuParis S', 65, 'OnceBet', '1.370', '3.450', '3.800', '2022-11-01 22:44:23'),
('PiShakhtaRB Leip', 66, 'Pinnacle', '5.170', '4.240', '1.662', '2022-11-01 23:08:21'),
('PiReal MaCeltic', 67, 'Pinnacle', '1.236', '6.560', '13.160', '2022-11-01 23:08:21'),
('PiFC CopeBorussi', 68, 'Pinnacle', '4.840', '3.950', '1.751', '2022-11-01 23:08:21'),
('PiJuventuParis S', 69, 'Pinnacle', '5.530', '4.280', '1.621', '2022-11-01 23:08:21'),
('PiMaccabiBenfica', 70, 'Pinnacle', '4.950', '4.350', '1.671', '2022-11-01 23:08:21'),
('PiManchesSevilla', 71, 'Pinnacle', '1.249', '6.500', '11.990', '2022-11-01 23:08:21'),
('PiChelseaDinamo ', 72, 'Pinnacle', '1.340', '5.610', '9.310', '2022-11-01 23:08:21'),
('PiAC MilaRed Bul', 73, 'Pinnacle', '1.507', '4.480', '6.870', '2022-11-01 23:08:21'),
('PiReal SoManches', 74, 'Pinnacle', '3.280', '3.520', '2.250', '2022-11-01 23:08:21'),
('PiSheriffOmonia ', 75, 'Pinnacle', '1.952', '3.570', '4.140', '2022-11-01 23:08:21'),
('PiOlympiaNantes', 76, 'Pinnacle', '3.380', '3.660', '2.150', '2022-11-01 23:08:21'),
('PiFC MidtSturm G', 77, 'Pinnacle', '1.917', '3.840', '3.960', '2022-11-01 23:08:21'),
('PiAS MonaCrvena ', 78, 'Pinnacle', '1.632', '4.300', '5.190', '2022-11-01 23:08:21'),
('PiTrabzonFerencv', 79, 'Pinnacle', '1.574', '4.330', '5.860', '2022-11-01 23:08:21'),
('PiFK QaraFreibur', 80, 'Pinnacle', '2.010', '3.800', '3.650', '2022-11-01 23:08:21'),
('PiFeyenooLazio', 81, 'Pinnacle', '2.240', '3.700', '3.160', '2022-11-01 23:08:21'),
('PiRennesAEK Lar', 82, 'Pinnacle', '1.177', '7.630', '16.190', '2022-11-01 23:08:21'),
('PiBodo GlPSV Ein', 83, 'Pinnacle', '3.270', '4.000', '2.090', '2022-11-01 23:08:21'),
('PiReal BeHJK Hel', 84, 'Pinnacle', '1.255', '5.970', '12.550', '2022-11-01 23:08:21'),
('PiDinamo Fenerba', 85, 'Pinnacle', '4.070', '3.710', '1.925', '2022-11-01 23:08:21'),
('Obainz 05Wolfsbu', 86, 'OnceBet', '2.000', '3.800', '3.450', '2022-11-01 23:08:23'),
('OboffenheRB Leip', 87, 'OnceBet', '4.300', '4.000', '1.750', '2022-11-01 23:08:23'),
('ObWerder Schalke', 88, 'OnceBet', '1.300', '5.800', '9.000', '2022-11-01 23:08:23'),
('Obayer LeUnion B', 89, 'OnceBet', '9.000', '5.800', '1.300', '2022-11-01 23:08:23'),
('ObGirona Athleti', 90, 'OnceBet', '2.000', '3.800', '3.450', '2022-11-01 23:08:23'),
('ObValladoElche', 91, 'OnceBet', '2.850', '3.600', '2.350', '2022-11-01 23:08:23'),
('ObCelta dOsasuna', 92, 'OnceBet', '1.650', '4.200', '4.800', '2022-11-01 23:08:23'),
('ObBarceloAlmerí', 93, 'OnceBet', '2.100', '3.700', '3.250', '2022-11-01 23:08:23'),
('ObtléticEspanyo', 94, 'OnceBet', '1.800', '3.900', '4.150', '2022-11-01 23:08:23'),
('ObReal S.Valenci', 95, 'OnceBet', '4.100', '3.400', '1.950', '2022-11-01 23:08:23'),
('ObVillarrMallorc', 96, 'OnceBet', '1.950', '3.400', '4.100', '2022-11-01 23:08:23'),
('ObRayo VaReal M', 97, 'OnceBet', '1.800', '3.550', '4.650', '2022-11-01 23:08:23'),
('ObTroyes Auxerre', 98, 'OnceBet', '2.050', '3.350', '3.750', '2022-11-01 23:08:23'),
('ObAjaccioStrasbo', 99, 'OnceBet', '1.100', '10.000', '22.000', '2022-11-01 23:08:23'),
('ObAngers Lens', 100, 'OnceBet', '4.200', '7.200', '1.080', '2022-11-01 23:08:23'),
('Oborient Paris S', 101, 'OnceBet', '3.400', '4.300', '1.190', '2022-11-01 23:08:23'),
('OblermontMontpel', 102, 'OnceBet', '3.900', '5.850', '1.110', '2022-11-01 23:08:23'),
('OboulouseMonaco', 103, 'OnceBet', '4.000', '1.550', '2.350', '2022-11-01 23:08:23'),
('ObLille OStade R', 104, 'OnceBet', '3.400', '4.300', '1.190', '2022-11-01 23:08:23'),
('ObMarseilLyon', 105, 'OnceBet', '3.250', '2.650', '1.450', '2022-11-01 23:08:23'),
('ObUdineseLecce', 106, 'OnceBet', '3.600', '1.750', '2.000', '2022-11-01 23:08:23'),
('ObalernitCremone', 107, 'OnceBet', '5.700', '1.320', '3.150', '2022-11-01 23:08:23'),
('Obmpoli Sassuol', 108, 'OnceBet', '2.350', '3.250', '3.150', '2022-11-01 23:08:23'),
('ObAtalantNapoli', 109, 'OnceBet', '2.150', '1.800', '3.550', '2022-11-01 23:08:23'),
('ObAC MilaSpezia', 110, 'OnceBet', '1.320', '3.150', '2.150', '2022-11-01 23:08:23'),
('Obologna Torino ', 111, 'OnceBet', '1.950', '1.530', '2.400', '2022-11-01 23:08:23'),
('Obonza CaHellas ', 112, 'OnceBet', '2.300', '1.580', '2.550', '2022-11-01 23:08:23'),
('ObampdoriFiorent', 113, 'OnceBet', '1.460', '2.050', '1.720', '2022-11-01 23:08:23'),
('ObJuventuInter M', 114, 'OnceBet', '1.300', '1.620', '2.100', '2022-11-01 23:08:23'),
('ObSpezia Udinese', 115, 'OnceBet', '1.100', '1.220', '2.350', '2022-11-01 23:08:23'),
('ObCremoneAC Mila', 116, 'OnceBet', '3.300', '1.300', '1.240', '2022-11-01 23:08:23'),
('ObLecce Atalant', 117, 'OnceBet', '3.250', '2.500', '1.500', '2022-11-01 23:08:23'),
('ObInter MBologna', 118, 'OnceBet', '3.450', '3.800', '2.000', '2022-11-01 23:08:23'),
('ObTorino Sampdor', 119, 'OnceBet', '1.480', '1.250', '6.000', '2022-11-01 23:08:23'),
('ObFiorentSalerni', 120, 'OnceBet', '1.700', '2.100', '2.850', '2022-11-01 23:08:23'),
('ObHellas Juventu', 121, 'OnceBet', '2.150', '2.000', '1.750', '2022-11-01 23:08:23'),
('ObLazio Monza C', 122, 'OnceBet', '1.870', '1.870', '1.550', '2022-11-01 23:08:23'),
('ObReal M Glasgow', 123, 'OnceBet', '1.190', '1.750', '2.000', '2022-11-01 23:08:24'),
('ObShakhtaRB Leip', 124, 'OnceBet', '1.240', '1.800', '1.950', '2022-11-01 23:08:24'),
('ObMaccabiSL Benf', 125, 'OnceBet', '1.530', '1.310', '1.350', '2022-11-01 23:08:24'),
('ObManchesSevilla', 126, 'OnceBet', '18.000', '1.060', '5.000', '2022-11-01 23:08:24'),
('ObAC MilaSalzbur', 127, 'OnceBet', '1.750', '2.000', '1.260', '2022-11-01 23:08:24'),
('ObFC CopeBorussi', 128, 'OnceBet', '4.100', '1.500', '2.500', '2022-11-01 23:08:24'),
('ObChelseaDynamo ', 129, 'OnceBet', '3.950', '3.900', '1.850', '2022-11-01 23:08:24'),
('ObJuventuParis S', 130, 'OnceBet', '1.370', '3.450', '3.800', '2022-11-01 23:08:24'),
('PiShakhtaRB Leip', 131, 'Pinnacle', '5.170', '4.240', '1.662', '2022-11-01 23:08:36'),
('PiReal MaCeltic', 132, 'Pinnacle', '1.236', '6.560', '13.160', '2022-11-01 23:08:36'),
('PiFC CopeBorussi', 133, 'Pinnacle', '4.840', '3.950', '1.751', '2022-11-01 23:08:36'),
('PiJuventuParis S', 134, 'Pinnacle', '5.530', '4.280', '1.621', '2022-11-01 23:08:36'),
('PiMaccabiBenfica', 135, 'Pinnacle', '4.950', '4.350', '1.671', '2022-11-01 23:08:36'),
('PiManchesSevilla', 136, 'Pinnacle', '1.249', '6.500', '11.990', '2022-11-01 23:08:36'),
('PiChelseaDinamo ', 137, 'Pinnacle', '1.340', '5.610', '9.310', '2022-11-01 23:08:36'),
('PiAC MilaRed Bul', 138, 'Pinnacle', '1.507', '4.480', '6.870', '2022-11-01 23:08:36'),
('PiReal SoManches', 139, 'Pinnacle', '3.280', '3.520', '2.250', '2022-11-01 23:08:36'),
('PiSheriffOmonia ', 140, 'Pinnacle', '1.952', '3.570', '4.140', '2022-11-01 23:08:36'),
('PiOlympiaNantes', 141, 'Pinnacle', '3.380', '3.660', '2.150', '2022-11-01 23:08:36'),
('PiFC MidtSturm G', 142, 'Pinnacle', '1.917', '3.840', '3.960', '2022-11-01 23:08:36'),
('PiAS MonaCrvena ', 143, 'Pinnacle', '1.632', '4.300', '5.190', '2022-11-01 23:08:36'),
('PiTrabzonFerencv', 144, 'Pinnacle', '1.574', '4.330', '5.860', '2022-11-01 23:08:36'),
('PiFK QaraFreibur', 145, 'Pinnacle', '2.010', '3.800', '3.650', '2022-11-01 23:08:36'),
('PiFeyenooLazio', 146, 'Pinnacle', '2.240', '3.700', '3.160', '2022-11-01 23:08:36'),
('PiRennesAEK Lar', 147, 'Pinnacle', '1.177', '7.630', '16.190', '2022-11-01 23:08:36'),
('PiBodo GlPSV Ein', 148, 'Pinnacle', '3.270', '4.000', '2.090', '2022-11-01 23:08:36'),
('PiReal BeHJK Hel', 149, 'Pinnacle', '1.255', '5.970', '12.550', '2022-11-01 23:08:36'),
('PiDinamo Fenerba', 150, 'Pinnacle', '4.070', '3.710', '1.925', '2022-11-01 23:08:36'),
('Obainz 05Wolfsbu', 151, 'OnceBet', '2.000', '3.800', '3.450', '2022-11-01 23:08:39'),
('OboffenheRB Leip', 152, 'OnceBet', '4.300', '4.000', '1.750', '2022-11-01 23:08:39'),
('ObWerder Schalke', 153, 'OnceBet', '1.300', '5.800', '9.000', '2022-11-01 23:08:39'),
('Obayer LeUnion B', 154, 'OnceBet', '9.000', '5.800', '1.300', '2022-11-01 23:08:39'),
('ObGirona Athleti', 155, 'OnceBet', '2.000', '3.800', '3.450', '2022-11-01 23:08:39'),
('ObValladoElche', 156, 'OnceBet', '2.850', '3.600', '2.350', '2022-11-01 23:08:39'),
('ObCelta dOsasuna', 157, 'OnceBet', '1.650', '4.200', '4.800', '2022-11-01 23:08:39'),
('ObBarceloAlmerí', 158, 'OnceBet', '2.100', '3.700', '3.250', '2022-11-01 23:08:39'),
('ObtléticEspanyo', 159, 'OnceBet', '1.800', '3.900', '4.150', '2022-11-01 23:08:39'),
('ObReal S.Valenci', 160, 'OnceBet', '4.100', '3.400', '1.950', '2022-11-01 23:08:39'),
('ObVillarrMallorc', 161, 'OnceBet', '1.950', '3.400', '4.100', '2022-11-01 23:08:39'),
('ObRayo VaReal M', 162, 'OnceBet', '1.800', '3.550', '4.650', '2022-11-01 23:08:39'),
('ObTroyes Auxerre', 163, 'OnceBet', '2.050', '3.350', '3.750', '2022-11-01 23:08:39'),
('ObAjaccioStrasbo', 164, 'OnceBet', '1.100', '10.000', '22.000', '2022-11-01 23:08:39'),
('ObAngers Lens', 165, 'OnceBet', '4.200', '7.200', '1.080', '2022-11-01 23:08:39'),
('Oborient Paris S', 166, 'OnceBet', '3.400', '4.300', '1.190', '2022-11-01 23:08:39'),
('OblermontMontpel', 167, 'OnceBet', '3.900', '5.850', '1.110', '2022-11-01 23:08:39'),
('OboulouseMonaco', 168, 'OnceBet', '4.000', '1.550', '2.350', '2022-11-01 23:08:39'),
('ObLille OStade R', 169, 'OnceBet', '3.400', '4.300', '1.190', '2022-11-01 23:08:39'),
('ObMarseilLyon', 170, 'OnceBet', '3.250', '2.650', '1.450', '2022-11-01 23:08:39'),
('ObUdineseLecce', 171, 'OnceBet', '3.600', '1.750', '2.000', '2022-11-01 23:08:39'),
('ObalernitCremone', 172, 'OnceBet', '5.700', '1.320', '3.150', '2022-11-01 23:08:39'),
('Obmpoli Sassuol', 173, 'OnceBet', '2.350', '3.250', '3.150', '2022-11-01 23:08:39'),
('ObAtalantNapoli', 174, 'OnceBet', '2.150', '1.800', '3.550', '2022-11-01 23:08:39'),
('ObAC MilaSpezia', 175, 'OnceBet', '1.320', '3.150', '2.150', '2022-11-01 23:08:39'),
('Obologna Torino ', 176, 'OnceBet', '1.950', '1.530', '2.400', '2022-11-01 23:08:39'),
('Obonza CaHellas ', 177, 'OnceBet', '2.300', '1.580', '2.550', '2022-11-01 23:08:39'),
('ObampdoriFiorent', 178, 'OnceBet', '1.460', '2.050', '1.720', '2022-11-01 23:08:39'),
('ObJuventuInter M', 179, 'OnceBet', '1.300', '1.620', '2.100', '2022-11-01 23:08:39'),
('ObSpezia Udinese', 180, 'OnceBet', '1.100', '1.220', '2.350', '2022-11-01 23:08:39'),
('ObCremoneAC Mila', 181, 'OnceBet', '3.300', '1.300', '1.240', '2022-11-01 23:08:39'),
('ObLecce Atalant', 182, 'OnceBet', '3.250', '2.500', '1.500', '2022-11-01 23:08:39'),
('ObInter MBologna', 183, 'OnceBet', '3.450', '3.800', '2.000', '2022-11-01 23:08:39'),
('ObTorino Sampdor', 184, 'OnceBet', '1.480', '1.250', '6.000', '2022-11-01 23:08:39'),
('ObFiorentSalerni', 185, 'OnceBet', '1.700', '2.100', '2.850', '2022-11-01 23:08:39'),
('ObHellas Juventu', 186, 'OnceBet', '2.150', '2.000', '1.750', '2022-11-01 23:08:39'),
('ObLazio Monza C', 187, 'OnceBet', '1.870', '1.870', '1.550', '2022-11-01 23:08:39'),
('ObReal M Glasgow', 188, 'OnceBet', '1.190', '1.750', '2.000', '2022-11-01 23:08:39'),
('ObShakhtaRB Leip', 189, 'OnceBet', '1.240', '1.800', '1.950', '2022-11-01 23:08:40'),
('ObMaccabiSL Benf', 190, 'OnceBet', '1.530', '1.310', '1.350', '2022-11-01 23:08:40'),
('ObManchesSevilla', 191, 'OnceBet', '18.000', '1.060', '5.000', '2022-11-01 23:08:40'),
('ObAC MilaSalzbur', 192, 'OnceBet', '1.750', '2.000', '1.260', '2022-11-01 23:08:40'),
('ObFC CopeBorussi', 193, 'OnceBet', '4.100', '1.500', '2.500', '2022-11-01 23:08:40'),
('ObChelseaDynamo ', 194, 'OnceBet', '3.950', '3.900', '1.850', '2022-11-01 23:08:40'),
('ObJuventuParis S', 195, 'OnceBet', '1.370', '3.450', '3.800', '2022-11-01 23:08:40');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
