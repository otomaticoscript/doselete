-- --------------------------------------------------------
-- Host:                         localhost
-- Versión del servidor:         10.4.28-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             12.5.0.6677
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para doselete
DROP DATABASE IF EXISTS `doselete`;
CREATE DATABASE IF NOT EXISTS `doselete` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `doselete`;

-- Volcando estructura para tabla doselete.master
DROP TABLE IF EXISTS `master`;
CREATE TABLE IF NOT EXISTS `master` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL COMMENT 'Almacena los combo de tipo seleccion',
  `Create` timestamp NOT NULL DEFAULT current_timestamp(),
  `Modify` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando estructura para tabla doselete.master_option
DROP TABLE IF EXISTS `master_option`;
CREATE TABLE IF NOT EXISTS `master_option` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdMaster` int(11) NOT NULL,
  `Key` varchar(255) DEFAULT NULL COMMENT 'Almacena el nombre de la opcion',
  `Value` varchar(255) DEFAULT NULL COMMENT 'Almacena la el valor de la opcion',
  `Place` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`),
  KEY `producto_nodo_FK` (`IdMaster`),
  CONSTRAINT `maesto_opcion_FK` FOREIGN KEY (`IdMaster`) REFERENCES `master` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=236 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Almacena las tuplas(nombre,valor) de un combo de seleccion';


-- Volcando estructura para tabla doselete.node
DROP TABLE IF EXISTS `node`;
CREATE TABLE IF NOT EXISTS `node` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdTemplate` int(11) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `JsonValue` varchar(255) DEFAULT NULL,
  `Modify` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`),
  KEY `nodo_plantilla` (`IdTemplate`),
  CONSTRAINT `nodo_plantilla` FOREIGN KEY (`IdTemplate`) REFERENCES `template` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Almacena los nodos de mi arbol que es el producto';


-- Volcando estructura para tabla doselete.node_relation
DROP TABLE IF EXISTS `node_relation`;
CREATE TABLE IF NOT EXISTS `node_relation` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdNode` bigint(20) NOT NULL COMMENT 'Nodo Hijo',
  `IdNodeParent` bigint(20) NOT NULL COMMENT 'NodoPadre',
  `IdNodeRoot` bigint(20) NOT NULL COMMENT 'NodoRaiz de donde se cuelga todo los demas Nodos',
  `Place` int(11) DEFAULT NULL COMMENT 'Orden',
  PRIMARY KEY (`Id`) USING BTREE,
  KEY `ParenteNode` (`IdNodeParent`) USING BTREE,
  KEY `RootNode` (`IdNodeRoot`) USING BTREE,
  KEY `Children` (`IdNode`) USING BTREE,
  CONSTRAINT `Children` FOREIGN KEY (`IdNode`) REFERENCES `node` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `ParenteNode` FOREIGN KEY (`IdNodeParent`) REFERENCES `node` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `RootNode` FOREIGN KEY (`IdNodeRoot`) REFERENCES `node` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Establece relacion entre nodo';


-- Volcando estructura para tabla doselete.template
DROP TABLE IF EXISTS `template`;
CREATE TABLE IF NOT EXISTS `template` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL COMMENT 'Nombre de la Plantilla',
  `AttributeName` varchar(255) DEFAULT '',
  `Create` timestamp NOT NULL DEFAULT current_timestamp(),
  `Modify` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando estructura para tabla doselete.template_allowed_children
DROP TABLE IF EXISTS `template_allowed_children`;
CREATE TABLE IF NOT EXISTS `template_allowed_children` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdTemplate` int(11) NOT NULL,
  `IdTemplateParent` int(11) NOT NULL,
  `MaxAllowed` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `hijo_plantilla` (`IdTemplate`),
  KEY `padre_plantilla` (`IdTemplateParent`),
  CONSTRAINT `hijo_plantilla` FOREIGN KEY (`IdTemplate`) REFERENCES `template` (`Id`),
  CONSTRAINT `padre_plantilla` FOREIGN KEY (`IdTemplateParent`) REFERENCES `template` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;


-- Volcando estructura para tabla doselete.template_field
DROP TABLE IF EXISTS `template_field`;
CREATE TABLE IF NOT EXISTS `template_field` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IdTemplate` int(11) NOT NULL,
  `IdType` int(11) DEFAULT NULL,
  `IdMaster` int(11) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL COMMENT 'Nombre del Campo',
  `AttributeName` varchar(50) DEFAULT '',
  `DefaultValue` varchar(20) DEFAULT NULL,
  `Required` tinyint(1) NOT NULL DEFAULT 0,
  `Place` int(11) DEFAULT 0,
  PRIMARY KEY (`Id`),
  KEY `formulario_plantilla` (`IdTemplate`),
  KEY `formulario_tipo` (`IdType`),
  CONSTRAINT `formulario_plantilla` FOREIGN KEY (`IdTemplate`) REFERENCES `template` (`Id`),
  CONSTRAINT `formulario_tipo` FOREIGN KEY (`IdType`) REFERENCES `type_field` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando estructura para tabla doselete.tvmaze
DROP TABLE IF EXISTS `tvmaze`;
CREATE TABLE IF NOT EXISTS `tvmaze` (
  `IdRoot` int(11) NOT NULL DEFAULT 0,
  `Id` int(11) DEFAULT NULL,
  `Name` varchar(255) NOT NULL DEFAULT 'Unknown',
  `Type` varchar(255) DEFAULT NULL,
  `Status` varchar(255) NOT NULL DEFAULT '',
  `Genre` varchar(255) DEFAULT NULL,
  `Language` varchar(255) DEFAULT NULL,
  `Country` varchar(255) DEFAULT NULL,
  `Runtime` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdRoot`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando estructura para tabla doselete.type_field
DROP TABLE IF EXISTS `type_field`;
CREATE TABLE IF NOT EXISTS `type_field` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Field` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla doselete.type_field: ~6 rows (aproximadamente)
REPLACE INTO `type_field` (`Id`, `Field`) VALUES
	(1, 'Boleano'),
	(2, 'Numero'),
	(3, 'Texto'),
	(4, 'Seleccion'),
	(5, 'Seleccion Multiple'),
	(6, 'Recurso');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
