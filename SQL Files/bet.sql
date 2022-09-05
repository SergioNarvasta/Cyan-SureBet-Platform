-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 05-09-2022 a las 14:27:58
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

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bet`
--

DROP TABLE IF EXISTS `bet`;
CREATE TABLE IF NOT EXISTS `bet` (
  `IdBet` int NOT NULL AUTO_INCREMENT,
  `Deporte` varchar(30) DEFAULT NULL,
  `Evento` varchar(40) DEFAULT NULL,
  `Mercado` varchar(20) DEFAULT NULL,
  `Competicion` varchar(30) DEFAULT NULL,
  `Cuota` decimal(8,2) DEFAULT NULL,
  `Beneficio` decimal(4,2) DEFAULT NULL,
  `CasaApuesta` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `FechaEv` datetime NOT NULL,
  `Limite` int DEFAULT NULL,
  `FechaReg` date NOT NULL,
  PRIMARY KEY (`IdBet`)
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `bet`
--

INSERT INTO `bet` (`IdBet`, `Deporte`, `Evento`, `Mercado`, `Competicion`, `Cuota`, `Beneficio`, `CasaApuesta`, `FechaEv`, `Limite`, `FechaReg`) VALUES
(10, 'Futbol Americano', 'Prueba', 'x2', 'La Liga', '1.32', '1.00', 'BET365', '2022-09-15 00:00:00', 1900, '2022-09-03'),
(14, 'Futbol', 'Prueba Data', 'Gana Local ', 'UEFA Champions League', '1.32', '11.00', 'BET365', '2022-09-02 00:00:00', 2500, '2022-09-05'),
(4, 'Futbol', 'Alianza vs Universitario', '1x', 'Liga 1 Peru', '1.32', '11.00', 'BET365', '2022-09-06 00:00:00', 1900, '2022-08-24'),
(8, 'Futbol', 'Liverpool vs Wolverhampton', '1X', 'Premier League', '1.08', '8.00', 'Pinnacle', '2022-09-10 00:00:00', 1200, '2022-09-03'),
(11, 'Futbol', 'Palmeiras vs Atletico Parananese', 'Doble Op. LoE', 'UEFA Champions League', '1.11', '11.00', 'Te Apuesto', '2022-09-06 00:00:00', 2500, '2022-09-05'),
(12, 'Futbol', 'B. Dormunt vs Copenhagen', 'Doble Op. LoE', 'UEFA Champions League', '1.05', '5.00', 'Te Apuesto', '2022-09-06 00:00:00', 1900, '2022-09-05'),
(15, 'Futbol', 'Prueba', 'Gana Local ', 'UEFA Champions League', '1.32', '11.00', 'BET365', '2022-09-02 00:00:00', 1300, '2022-09-05');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
