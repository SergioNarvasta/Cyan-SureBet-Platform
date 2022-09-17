-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 17-09-2022 a las 02:06:27
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
CREATE DATABASE IF NOT EXISTS `surebet` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `surebet`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bet`
--

DROP TABLE IF EXISTS `bet`;
CREATE TABLE IF NOT EXISTS `bet` (
  `IdBet` int NOT NULL AUTO_INCREMENT,
  `Deporte` varchar(30) DEFAULT NULL,
  `Evento` varchar(40) DEFAULT NULL,
  `Mercado` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Competicion` varchar(30) DEFAULT NULL,
  `Cuota` decimal(8,2) DEFAULT NULL,
  `Beneficio` decimal(4,2) DEFAULT NULL,
  `CasaApuesta` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `FechaEv` datetime NOT NULL,
  `Limite` int DEFAULT NULL,
  `FechaReg` date NOT NULL,
  PRIMARY KEY (`IdBet`)
) ENGINE=MyISAM AUTO_INCREMENT=45 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `bet`
--

INSERT INTO `bet` (`IdBet`, `Deporte`, `Evento`, `Mercado`, `Competicion`, `Cuota`, `Beneficio`, `CasaApuesta`, `FechaEv`, `Limite`, `FechaReg`) VALUES
(21, 'Futbol', ' DINAMO ZAGREB vs CHELSEA', 'Doble Op. EoV', 'UEFA Champions League', '1.11', '11.00', 'Pinnacle', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(19, 'Futbol', ' DORTMUND vs FC COPENHAGEN', 'Doble Op. LoE', 'UEFA Champions League', '1.07', '7.00', 'Pinnacle', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(20, 'Futbol', ' DORTMUND vs FC COPENHAGEN', 'Goles +1.5', 'UEFA Champions League', '1.05', '5.00', 'Pinnacle', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(11, 'Futbol', 'Palmeiras vs Atletico Parananese', 'Doble Op. LoE', 'Copa Libertadores', '1.11', '11.00', 'Te Apuesto', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(12, 'Futbol', 'B. Dormunt vs Copenhagen', 'Doble Op. LoE', 'UEFA Champions League', '1.05', '5.00', 'Te Apuesto', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(18, 'Futbol', ' DORTMUND vs FC COPENHAGEN', 'Doble Op. LoE', 'UEFA Champions League', '1.05', '5.00', 'Te Apuesto', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(16, 'Futbol', 'DINAMO ZAGREB vs CHELSEA', 'Doble Op. EoV', 'UEFA Champions League', '1.06', '6.00', 'BET365', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(17, 'Futbol', ' DORTMUND vs FC COPENHAGEN', 'Goles +1.5', 'UEFA Champions League', '1.06', '6.00', 'Te Apuesto', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(22, 'Futbol', ' DINAMO ZAGREB vs CHELSEA', 'Doble Op. EoV', 'UEFA Champions League', '1.12', '12.00', 'Te Apuesto', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(23, 'Futbol', 'CELTIC vs REAL MADRID', 'Doble Op. EoV', 'UEFA Champions League', '1.10', '10.00', 'Te Apuesto', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(24, 'Futbol', 'CELTIC vs REAL MADRID', 'Goles +1.5', 'UEFA Champions League', '1.13', '13.00', 'Pinnacle', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(25, 'Futbol', 'CELTIC vs REAL MADRID', 'Apuesta sin Empate V', 'UEFA Champions League', '1.08', '8.00', 'Te Apuesto', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(26, 'Futbol', 'CELTIC vs REAL MADRID', 'Doble Op. EoV', 'UEFA Champions League', '1.08', '8.00', 'Inka Bet', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(27, 'Futbol', ' RB LEIPZIG vs SHAKHTAR DONETSK', 'Doble Op. LoE', 'UEFA Champions League', '1.08', '8.00', 'Pinnacle', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(28, 'Futbol', 'RB LEIPZIG vs SHAKHTAR DONETSK', 'Goles +0.5', 'UEFA Champions League', '1.05', '5.00', 'Pinnacle', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(29, 'Futbol', 'RB LEIPZIG vs SHAKHTAR DONETSK', 'Doble Op. LoE', 'UEFA Champions League', '1.11', '11.00', 'Te Apuesto', '2022-09-06 00:00:00', 1200, '2022-09-05'),
(30, 'Futbol', ' SEVILLA  vs  MANCHESTER CITY', 'Doble Op. EoV', 'UEFA Champions League', '1.08', '8.00', 'Te Apuesto', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(31, 'Futbol', ' SEVILLA vs MANCHESTER CITY', 'Goles +0.5', 'UEFA Champions League', '1.07', '7.00', 'Pinnacle', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(32, 'Futbol', 'PARIS ST. GERMAIN vs JUVENTUS', 'Apuesta sin Empate Local', 'UEFA Champions League', '1.09', '9.00', 'Te Apuesto', '0000-00-00 00:00:00', 2500, '2022-09-05'),
(33, 'Futbol', 'PARIS ST. GERMAIN vs JUVENTUS', 'Doble Op. LoE', 'UEFA Champions League', '1.08', '8.00', 'Te Apuesto', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(34, 'Futbol', 'CELTIC vs REAL MADRID', 'Doble Op. EoV', 'UEFA Champions League', '1.12', '12.00', 'Inka Bet', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(35, 'Futbol', ' DORTMUND vs FC COPENHAGEN', 'Goles +0.5', 'UEFA Champions League', '1.04', '4.00', 'Betsson', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(36, 'Futbol', ' DINAMO ZAGREB vs CHELSEA', 'Goles +1.5', 'UEFA Champions League', '1.06', '6.00', 'Inka Bet', '2022-09-06 00:00:00', 1200, '2022-09-05'),
(37, 'Futbol', ' BENFICA vs MACCABI HAIFA', 'Doble Op. LoV', 'UEFA Champions League', '1.11', '11.00', 'Betsson', '2022-09-06 00:00:00', 1300, '2022-09-05'),
(38, 'Futbol', 'PALMEIRAS vs ATLETICO PR', 'Doble Op. LoE', 'Copa Libertadores', '1.11', '11.00', 'Te Apuesto', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(39, 'Futbol', 'PALMEIRAS vs ATLETICO PR', 'Goles +0.5', 'UEFA Champions League', '1.06', '6.00', 'Pinnacle', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(40, 'Futbol', 'PALMEIRAS vs ATLETICO PR', 'Goles +1.5', 'Copa Libertadores', '1.11', '11.00', 'Te Apuesto', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(41, 'Futbol', ' FLAMENGO vs VELEZ SARSFIELD', 'Doble Op. LoE', 'Copa Libertadores', '1.09', '9.00', 'Te Apuesto', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(42, 'Futbol', 'FLAMENGO vs VELEZ SARSFIELD', 'Goles +2.5', 'Copa Libertadores', '1.13', '13.00', 'Pinnacle', '2022-09-07 00:00:00', 2500, '2022-09-05'),
(43, 'Futbol', ' AJAX vs RANGERS', 'Doble Op. LoE', 'UEFA Champions League', '1.06', '6.00', 'Te Apuesto', '2022-09-07 00:00:00', 1900, '2022-09-05'),
(44, 'Futbol', ' AJAX vs RANGERS', 'Goles +1.5', 'UEFA Champions League', '1.11', '11.00', 'Te Apuesto', '2022-09-07 00:00:00', 1300, '2022-09-05');

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
  `fecreg` datetime NOT NULL,
  PRIMARY KEY (`idcab`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `bet_cab`
--

INSERT INTO `bet_cab` (`idcab`, `deporte`, `local`, `visita`, `feceve`, `fecreg`) VALUES
('4e7837a8c79f3da8', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-11 23:56:51'),
('3132d39fa2aaf1f8', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 00:06:36'),
('78d33b6f45fbcba8', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 00:09:05'),
('0b2e844a814da987', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 00:09:07'),
('cc63b4e34a663cea', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 00:10:31'),
('27e607dad5f394d8', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 00:11:33'),
('c0c20c678086703c', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 00:13:17'),
('b7ade5b577197b3b', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 00:16:15'),
('f7048fd9b46fa2a5', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 00:19:05'),
('80fab22afda79c74', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 10:00:44'),
('46ff3eb9d5d0abb4', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 10:02:07'),
('ecec374acf03def8', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 10:02:25'),
('12aedc7be488a30d', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 10:02:27'),
('40db86837ecc45c0', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 10:03:11'),
('3dc7f090a9955a63', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 10:04:31'),
('7f989f68f24826c1', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:44:15'),
('c32a1d18a12b0e2c', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:47:49'),
('dfdde9da6e375562', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:48:32'),
('e8323e260c118b9d', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:48:57'),
('c199e75ee44e15f9', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:50:41'),
('51a50ebe857274a5', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:54:07'),
('5e322b02bf9cc4e6', 'Futbol', 'Sporting Lisbon', 'Tottenham Hotspur', '9/13/2022 11:45', '2022-09-12 12:54:08'),
('0c3146e2f3fdb3b0', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:54:48'),
('cf51f71cb0ca9f6d', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:55:27'),
('f0bf0cbb103feaa0', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:55:29'),
('ef8008dc62abe599', 'Futbol', 'Sporting Lisbon', 'Tottenham Hotspur', '9/13/2022 11:45', '2022-09-12 12:55:30'),
('7f62dd3e8d7c1757', 'Futbol', 'Sporting Lisbon', 'Tottenham Hotspur', '9/13/2022 11:45', '2022-09-12 12:56:07'),
('7824d3d319aa4e92', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:56:27'),
('331292aa0da9fe63', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 12:59:05'),
('00331087ff1d22d8', 'Futbol', 'Empoli', 'AS Roma', '9/12/2022 13:45', '2022-09-12 13:02:55');

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
  PRIMARY KEY (`iddet`),
  UNIQUE KEY `iddet` (`iddet`)
) ENGINE=MyISAM AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `bet_det`
--

INSERT INTO `bet_det` (`idcab`, `iddet`, `casa`, `cuota_local`, `cuota_empate`, `cuota_visita`) VALUES
('4e7837a8c79f3da8', 14, 'Pinnacle', '4.880', '3.930', '1.769'),
('4e7837a8c79f3da8', 15, 'Pinnacle', '2.850', '3.210', '2.780'),
('3132d39fa2aaf1f8', 16, 'Pinnacle', '4.880', '3.930', '1.769'),
('3132d39fa2aaf1f8', 17, 'Pinnacle', '2.850', '3.210', '2.780'),
('78d33b6f45fbcba8', 18, 'Pinnacle', '4.880', '3.930', '1.769'),
('78d33b6f45fbcba8', 19, 'Pinnacle', '2.850', '3.210', '2.780'),
('0b2e844a814da987', 20, 'Pinnacle', '4.880', '3.930', '1.769'),
('0b2e844a814da987', 21, 'Pinnacle', '2.850', '3.210', '2.780'),
('cc63b4e34a663cea', 22, 'Pinnacle', '4.880', '3.930', '1.769'),
('27e607dad5f394d8', 23, 'Pinnacle', '4.880', '3.930', '1.769'),
('c0c20c678086703c', 24, 'Pinnacle', '4.880', '3.930', '1.769'),
('b7ade5b577197b3b', 25, 'Pinnacle', '4.880', '3.930', '1.769'),
('f7048fd9b46fa2a5', 26, 'Pinnacle', '4.880', '3.930', '1.769'),
('80fab22afda79c74', 27, 'Pinnacle', '4.880', '3.930', '1.769'),
('46ff3eb9d5d0abb4', 28, 'Pinnacle', '4.880', '3.930', '1.769'),
('ecec374acf03def8', 29, 'Pinnacle', '4.880', '3.930', '1.769'),
('12aedc7be488a30d', 30, 'Pinnacle', '4.880', '3.930', '1.769'),
('40db86837ecc45c0', 31, 'Pinnacle', '4.880', '3.930', '1.769'),
('3dc7f090a9955a63', 32, 'Pinnacle', '4.880', '3.930', '1.769'),
('7f989f68f24826c1', 33, 'Pinnacle', '4.880', '3.930', '1.769'),
('7f989f68f24826c1', 34, 'Pinnacle', '2.850', '3.210', '2.780'),
('7f989f68f24826c1', 35, 'Pinnacle', '3.800', '3.650', '2.030'),
('c32a1d18a12b0e2c', 36, 'Pinnacle', '4.880', '3.930', '1.769'),
('c32a1d18a12b0e2c', 37, 'Pinnacle', '2.850', '3.210', '2.780'),
('c32a1d18a12b0e2c', 38, 'Pinnacle', '3.800', '3.650', '2.030'),
('dfdde9da6e375562', 39, 'Pinnacle', '4.880', '3.930', '1.769'),
('dfdde9da6e375562', 40, 'Pinnacle', '2.850', '3.210', '2.780'),
('dfdde9da6e375562', 41, 'Pinnacle', '3.800', '3.650', '2.030'),
('e8323e260c118b9d', 42, 'Pinnacle', '4.880', '3.930', '1.769'),
('e8323e260c118b9d', 43, 'Pinnacle', '2.850', '3.210', '2.780'),
('e8323e260c118b9d', 44, 'Pinnacle', '3.800', '3.650', '2.030'),
('c199e75ee44e15f9', 45, 'Pinnacle', '4.880', '3.930', '1.769'),
('c199e75ee44e15f9', 46, 'Pinnacle', '2.850', '3.210', '2.780'),
('c199e75ee44e15f9', 47, 'Pinnacle', '3.800', '3.650', '2.030'),
('51a50ebe857274a5', 48, 'Pinnacle', '4.880', '3.930', '1.769'),
('51a50ebe857274a5', 49, 'Pinnacle', '2.850', '3.210', '2.780'),
('5e322b02bf9cc4e6', 50, 'Pinnacle', '3.800', '3.650', '2.030'),
('0c3146e2f3fdb3b0', 51, 'Pinnacle', '4.880', '3.930', '1.769'),
('0c3146e2f3fdb3b0', 52, 'Pinnacle', '2.850', '3.210', '2.780'),
('0c3146e2f3fdb3b0', 53, 'Pinnacle', '3.800', '3.650', '2.030'),
('cf51f71cb0ca9f6d', 54, 'Pinnacle', '4.880', '3.930', '1.769'),
('cf51f71cb0ca9f6d', 55, 'Pinnacle', '2.850', '3.210', '2.780'),
('cf51f71cb0ca9f6d', 56, 'Pinnacle', '3.800', '3.650', '2.030'),
('f0bf0cbb103feaa0', 57, 'Pinnacle', '4.880', '3.930', '1.769'),
('f0bf0cbb103feaa0', 58, 'Pinnacle', '2.850', '3.210', '2.780'),
('ef8008dc62abe599', 59, 'Pinnacle', '3.800', '3.650', '2.030'),
('7f62dd3e8d7c1757', 60, 'Pinnacle', '4.880', '3.930', '1.769'),
('7f62dd3e8d7c1757', 61, 'Pinnacle', '2.850', '3.210', '2.780'),
('7f62dd3e8d7c1757', 62, 'Pinnacle', '3.800', '3.650', '2.030'),
('7824d3d319aa4e92', 63, 'Pinnacle', '4.880', '3.930', '1.769'),
('7824d3d319aa4e92', 64, 'Pinnacle', '2.850', '3.210', '2.780'),
('7824d3d319aa4e92', 65, 'Pinnacle', '3.800', '3.650', '2.030'),
('331292aa0da9fe63', 66, 'Pinnacle', '4.880', '3.930', '1.769'),
('331292aa0da9fe63', 67, 'Pinnacle', '2.850', '3.210', '2.780'),
('331292aa0da9fe63', 68, 'Pinnacle', '3.800', '3.650', '2.030'),
('00331087ff1d22d8', 69, 'Pinnacle', '4.880', '3.930', '1.769'),
('00331087ff1d22d8', 70, 'Pinnacle', '2.850', '3.210', '2.780'),
('00331087ff1d22d8', 71, 'Pinnacle', '3.800', '3.650', '2.030');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
