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

-- Volcando estructura para tabla pitagoras_testing_3.empresas
CREATE TABLE IF NOT EXISTS `empresas` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `rut` int(8) NOT NULL,
  `dv` char(1) NOT NULL,
  `razon_social` char(100) NOT NULL,
  `codigo_actividad` char(50) DEFAULT NULL,
  `giro` char(100) NOT NULL,
  `direccion` char(100) NOT NULL,
  `comuna` int(50) NOT NULL,
  `ciudad` int(50) NOT NULL,
  `region` char(50) NOT NULL,
  `rut_representante_legal` char(8) NOT NULL,
  `dv_representante_legal` char(1) NOT NULL,
  `nombre_representante_legal` char(50) NOT NULL,
  `direccion_representante_legal` char(50) NOT NULL,
  `comuna_representante_legal` int(11) NOT NULL,
  `ciudad_representante_legal` int(11) NOT NULL,
  `iva` int(11) NOT NULL,
  `ila` int(11) NOT NULL,
  `otro_impuesto` int(11) NOT NULL,
  `margen_minimo` int(11) NOT NULL,
  `ajuste_precio` char(1) NOT NULL DEFAULT '0' COMMENT '0=Ultima Compra 1=Costo Promedio 2=Optimizar',
  `ajusta_margen` char(1) NOT NULL DEFAULT '0' COMMENT '0= Ajusta Margen y Mantiene Precio  1=Mantiene Margen y Ajusta Precio',
  `margen_a_nivel` char(1) NOT NULL DEFAULT '0' COMMENT '1 o 2 o 3 o 4 o 5',
  `sucursal_sii` varchar(100) NOT NULL,
  `permite_stock_negativo` char(50) NOT NULL DEFAULT '0' COMMENT '0 = no permite; 1= si permite',
  `prefijo_codigo_barra_ean13` char(3) DEFAULT '000',
  `cta_contable_proveedores` int(11) DEFAULT NULL,
  `cta_contable_clientes` int(11) DEFAULT NULL,
  `cta_contable_caja` int(11) DEFAULT NULL,
  `cta_contable_iva_debito` int(11) DEFAULT NULL,
  `cta_contable_iva_credito` int(11) DEFAULT NULL,
  `cta_contable_costo_venta` int(11) DEFAULT NULL,
  `cta_contable_resultado_venta` int(11) DEFAULT NULL,
  `cta_contable_existencia` int(11) DEFAULT NULL,
  `cta_contable_transbank_debito` int(11) DEFAULT NULL,
  `cta_contable_transbank_credito` int(11) DEFAULT NULL,
  `cta_contable_documentos_por_cobrar` int(11) DEFAULT NULL,
  `ano_contable_por_defecto` year(4) DEFAULT NULL,
  `mes_contable_por_defecto` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `rut` (`rut`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Volcando datos para la tabla pitagoras_testing_3.empresas: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `empresas` DISABLE KEYS */;
REPLACE INTO `empresas` (`id`, `rut`, `dv`, `razon_social`, `codigo_actividad`, `giro`, `direccion`, `comuna`, `ciudad`, `region`, `rut_representante_legal`, `dv_representante_legal`, `nombre_representante_legal`, `direccion_representante_legal`, `comuna_representante_legal`, `ciudad_representante_legal`, `iva`, `ila`, `otro_impuesto`, `margen_minimo`, `ajuste_precio`, `ajusta_margen`, `margen_a_nivel`, `sucursal_sii`, `permite_stock_negativo`, `prefijo_codigo_barra_ean13`, `cta_contable_proveedores`, `cta_contable_clientes`, `cta_contable_caja`, `cta_contable_iva_debito`, `cta_contable_iva_credito`, `cta_contable_costo_venta`, `cta_contable_resultado_venta`, `cta_contable_existencia`, `cta_contable_transbank_debito`, `cta_contable_transbank_credito`, `cta_contable_documentos_por_cobrar`, `ano_contable_por_defecto`, `mes_contable_por_defecto`) VALUES
	(1, 76035012, '5', 'BUNICK SPA', '741400', 'COMPRA Y VENTA DE ART. DE OFICINA, ESCRITORIO, COMPUTACION Y JUGUETES', 'PROVIDENCIA 1626', 13123, 401, '13', '12669341', '9', 'ELIZABETH MARIA VALERA SOTO', 'PROVIDENCIA 1626', 13123, 401, 19, 0, 0, 30, '2', '1', '1', 'PROVIDENCIA', '0', '569', 20101, 10201, 10101, 20105, 10306, 30305, 40101, 10202, 10310, 10309, 10300, '2019', 9);
/*!40000 ALTER TABLE `empresas` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
