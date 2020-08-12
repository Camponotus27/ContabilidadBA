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

-- Volcando estructura para tabla pitagoras_testing_3.documentos_tributarios
CREATE TABLE IF NOT EXISTS `documentos_tributarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_documento` int(11) NOT NULL,
  `descripcion_documento` varchar(100) DEFAULT NULL,
  `descripcion_documento_abreviada` varchar(50) DEFAULT NULL,
  `descripcion_documento_abreviada_2` varchar(50) DEFAULT NULL,
  `aplica_iva` char(1) NOT NULL DEFAULT 'N',
  `disponible_venta` char(1) NOT NULL DEFAULT '0',
  `disponible_compra` char(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla pitagoras_testing_3.documentos_tributarios: ~10 rows (aproximadamente)
/*!40000 ALTER TABLE `documentos_tributarios` DISABLE KEYS */;
REPLACE INTO `documentos_tributarios` (`id`, `codigo_documento`, `descripcion_documento`, `descripcion_documento_abreviada`, `descripcion_documento_abreviada_2`, `aplica_iva`, `disponible_venta`, `disponible_compra`) VALUES
	(1, 39, 'Boleta Electrónica', 'Bol', 'B', 'S', '1', '1'),
	(2, 33, 'Factura Electrónica', 'Fac', 'F', 'S', '1', '1'),
	(3, 56, 'Nota de Débito Electrónica', 'ND', 'ND', 'S', '1', '1'),
	(4, 61, 'Nota de Crédito Electrónica', 'NC', 'NC', 'S', '1', '1'),
	(5, 0, 'Remuneraciones', 'R', 'R', 'N', '0', '0'),
	(6, 1, 'Boleta Honorarios', 'H', 'H', 'N', '0', '0'),
	(7, 2, 'Socio', 'S', 'S', 'N', '0', '0'),
	(8, 3, 'Cheque Traspado Fondo', 'T', 'T', 'N', '0', '0'),
	(9, 4, 'Pago Arriendo', 'A', 'A', 'N', '0', '0'),
	(10, 34, 'Factura Electronica Exenta', 'FacEx', 'FEE', 'N', '0', '1'),
	(11, 5, 'Cheque', 'CH', 'CH', 'N', '0', '0'),
	(12, 52, 'Guia Despacho', 'GD', 'GD', 'S', '0', '1');
/*!40000 ALTER TABLE `documentos_tributarios` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
