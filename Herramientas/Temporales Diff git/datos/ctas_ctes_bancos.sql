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

-- Volcando estructura para tabla pitagoras_testing_3.ctas_ctes_bancos
CREATE TABLE IF NOT EXISTS `ctas_ctes_bancos` (
  `id_cta_cte_banco` int(11) NOT NULL AUTO_INCREMENT,
  `id_bancos` int(11) NOT NULL,
  `num_cta_cte` varchar(50) NOT NULL,
  `saldo_ini_cta_cte` int(11) NOT NULL DEFAULT 0,
  `fecha_saldo_actual` int(11) NOT NULL DEFAULT 0,
  `id_moneda` int(11) NOT NULL DEFAULT 1,
  `cta_contable` int(11) NOT NULL DEFAULT 0,
  `saldo_inicial` int(11) NOT NULL DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id_cta_cte_banco`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla pitagoras_testing_3.ctas_ctes_bancos: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `ctas_ctes_bancos` DISABLE KEYS */;
REPLACE INTO `ctas_ctes_bancos` (`id_cta_cte_banco`, `id_bancos`, `num_cta_cte`, `saldo_ini_cta_cte`, `fecha_saldo_actual`, `id_moneda`, `cta_contable`, `saldo_inicial`, `created_at`) VALUES
	(1, 7, '63165620', 0, 0, 1, 10103, 8434332, '2019-01-01 00:00:00'),
	(2, 4, '52216071', 0, 0, 1, 10104, 10272522, '2019-01-01 00:00:00');
/*!40000 ALTER TABLE `ctas_ctes_bancos` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
