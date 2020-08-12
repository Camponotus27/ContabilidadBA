-- --------------------------------------------------------
-- Host:                         170.239.85.146
-- Versión del servidor:         10.3.18-MariaDB - MariaDB Server
-- SO del servidor:              Linux
-- HeidiSQL Versión:             10.3.0.5771
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Volcando estructura para tabla pitagoras_testing_3.contab_control_mes_contable
CREATE TABLE IF NOT EXISTS `contab_control_mes_contable` (
  `ano` year(4) NOT NULL,
  `ene` int(11) NOT NULL DEFAULT 0,
  `feb` int(11) NOT NULL DEFAULT 0,
  `mar` int(11) NOT NULL DEFAULT 0,
  `abr` int(11) NOT NULL DEFAULT 0,
  `may` int(11) NOT NULL DEFAULT 0,
  `jun` int(11) NOT NULL DEFAULT 0,
  `jul` int(11) NOT NULL DEFAULT 0,
  `ago` int(11) NOT NULL DEFAULT 0,
  `sep` int(11) NOT NULL DEFAULT 0,
  `oct` int(11) NOT NULL DEFAULT 0,
  `nov` int(11) NOT NULL DEFAULT 0,
  `dic` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`ano`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla pitagoras_testing_3.contab_control_mes_contable: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `contab_control_mes_contable` DISABLE KEYS */;
REPLACE INTO `contab_control_mes_contable` (`ano`, `ene`, `feb`, `mar`, `abr`, `may`, `jun`, `jul`, `ago`, `sep`, `oct`, `nov`, `dic`) VALUES
	('2017', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	('2018', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
	('2019', 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0);
/*!40000 ALTER TABLE `contab_control_mes_contable` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
