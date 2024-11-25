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
CREATE DATABASE IF NOT EXISTS `doselete` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `doselete`;

-- Volcando estructura para tabla doselete.master
CREATE TABLE IF NOT EXISTS `master` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL COMMENT 'Almacena los combo de tipo seleccion',
  `Create` timestamp NOT NULL DEFAULT current_timestamp(),
  `Modify` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla doselete.master: ~8 rows (aproximadamente)
REPLACE INTO `master` (`Id`, `Name`, `Create`, `Modify`) VALUES
	(1, 'Show Genre', '2024-10-05 16:39:26', '2024-10-06 11:50:50'),
	(2, 'days', '2024-10-05 16:39:43', '2024-10-04 22:00:00'),
	(3, 'Show Type', '2024-10-05 22:29:31', '2024-10-06 12:18:14'),
	(4, 'Show Status', '2024-10-05 22:30:00', '2024-10-06 11:51:59'),
	(5, 'Rating', '2024-10-06 11:52:00', '2024-10-06 11:52:00'),
	(6, 'Runtime', '2024-10-06 11:52:00', '2024-10-06 11:52:00'),
	(7, 'Country', '2024-10-06 12:12:00', '2024-10-06 12:12:54'),
	(8, 'Language', '2024-10-06 12:12:00', '2024-10-06 12:12:50');

-- Volcando estructura para tabla doselete.master_option
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

-- Volcando datos para la tabla doselete.master_option: ~233 rows (aproximadamente)
REPLACE INTO `master_option` (`Id`, `IdMaster`, `Key`, `Value`, `Place`) VALUES
	(3, 1, 'Action', 'Action', 1),
	(4, 1, 'Adult', 'Adult', 2),
	(5, 1, 'Adventure', 'Adventure', 3),
	(6, 1, 'Anime', 'Anime', 4),
	(7, 1, 'Children', 'Children', 5),
	(8, 1, 'Comedy', 'Comedy', 6),
	(9, 1, 'Crime', 'Crime', 7),
	(10, 1, 'DIY', 'DIY', 8),
	(11, 1, 'Drama', 'Drama', 9),
	(12, 1, 'Espionage', 'Espionage', 10),
	(13, 1, 'Family', 'Family', 11),
	(14, 1, 'Fantasy', 'Fantasy', 12),
	(15, 1, 'Food', 'Food', 13),
	(16, 1, 'History', 'History', 14),
	(17, 1, 'Horror', 'Horror', 15),
	(18, 1, 'Legal', 'Legal', 16),
	(19, 1, 'Medical', 'Medical', 17),
	(20, 1, 'Music', 'Music', 18),
	(21, 1, 'Mystery', 'Mystery', 19),
	(22, 1, 'Nature', 'Nature', 20),
	(23, 1, 'Romance', 'Romance', 21),
	(24, 1, 'Science-Fiction', 'Science-Fiction', 22),
	(25, 1, 'Sports', 'Sports', 23),
	(26, 1, 'Supernatural', 'Supernatural', 24),
	(27, 1, 'Thriller', 'Thriller', 25),
	(28, 1, 'Travel', 'Travel', 26),
	(29, 1, 'War', 'War', 27),
	(30, 1, 'Western', 'Western', 28),
	(31, 2, 'Monday', 'Monday', 2),
	(32, 2, 'Tuesday', 'Tuesday', 3),
	(33, 2, 'Wednesday', 'Wednesday', 4),
	(34, 2, 'Thursday', 'Thursday', 5),
	(35, 2, 'Friday', 'Friday', 6),
	(36, 2, 'Saturday', 'Saturday', 7),
	(37, 2, 'Sunday', 'Sunday', 1),
	(38, 3, 'Scripted', 'Scripted', 1),
	(39, 3, 'Animation', 'Animation', 2),
	(40, 3, 'Reality', 'Reality', 3),
	(41, 3, 'Talk Show', 'Talk Show', 4),
	(42, 3, 'Documentary', 'Documentary', 5),
	(43, 3, 'Game Show', 'Game Show', 6),
	(44, 3, 'News', 'News', 7),
	(45, 3, 'Sports', 'Sports', 8),
	(46, 3, 'Variety', 'Variety', 9),
	(47, 3, 'Award Show', 'Award Show', 10),
	(48, 3, 'Panel Show', 'Panel Show', 11),
	(49, 8, 'Afrikaans', 'Afrikaans', 3),
	(50, 8, 'Albanian', 'Albanian', 5),
	(51, 8, 'Arabic', 'Arabic', 7),
	(52, 8, 'Armenian', 'Armenian', 8),
	(53, 8, 'Azerbaijani', 'Azerbaijani', 11),
	(54, 8, 'Basque', 'Basque', 14),
	(55, 8, 'Belarusian', 'Belarusian', 15),
	(56, 8, 'Bengali', 'Bengali', 16),
	(57, 8, 'Bosnian', 'Bosnian', 18),
	(58, 8, 'Bulgarian', 'Bulgarian', 20),
	(59, 8, 'Burmese', 'Burmese', 21),
	(60, 8, 'Catalan', 'Catalan', 22),
	(61, 8, 'Chechen', 'Chechen', 24),
	(62, 8, 'Chichewa', 'Chichewa', 25),
	(63, 8, 'Chinese', 'Chinese', 26),
	(64, 8, 'Croatian', 'Croatian', 29),
	(65, 8, 'Czech', 'Czech', 30),
	(66, 8, 'Danish', 'Danish', 31),
	(67, 8, 'Divehi', 'Divehi', 32),
	(68, 8, 'Dutch', 'Dutch', 33),
	(69, 8, 'English', 'English', 35),
	(70, 8, 'Estonian', 'Estonian', 36),
	(71, 8, 'Fijian', 'Fijian', 38),
	(72, 8, 'Finnish', 'Finnish', 39),
	(73, 8, 'French', 'French', 40),
	(74, 8, 'Galician', 'Galician', 42),
	(75, 8, 'Georgian', 'Georgian', 44),
	(76, 8, 'German', 'German', 45),
	(77, 8, 'Greek', 'Greek', 46),
	(78, 8, 'Gujarati', 'Gujarati', 49),
	(79, 8, 'Hebrew', 'Hebrew', 52),
	(80, 8, 'Hindi', 'Hindi', 54),
	(81, 8, 'Hungarian', 'Hungarian', 55),
	(82, 8, 'Icelandic', 'Icelandic', 56),
	(83, 8, 'Indonesian', 'Indonesian', 58),
	(84, 8, 'Irish', 'Irish', 59),
	(85, 8, 'Italian', 'Italian', 60),
	(86, 8, 'Japanese', 'Japanese', 61),
	(87, 8, 'Javanese', 'Javanese', 62),
	(88, 8, 'Kannada', 'Kannada', 63),
	(89, 8, 'Kazakh', 'Kazakh', 65),
	(90, 8, 'Kongo', 'Kongo', 68),
	(91, 8, 'Korean', 'Korean', 69),
	(92, 8, 'Kyrgyz', 'Kyrgyz', 71),
	(93, 8, 'Lao', 'Lao', 72),
	(94, 8, 'Latin', 'Latin', 73),
	(95, 8, 'Latvian', 'Latvian', 74),
	(96, 8, 'Lithuanian', 'Lithuanian', 76),
	(97, 8, 'Luxembourgish', 'Luxembourgish', 78),
	(98, 8, 'Malagasy', 'Malagasy', 80),
	(99, 8, 'Malay', 'Malay', 81),
	(100, 8, 'Malayalam', 'Malayalam', 82),
	(101, 8, 'Marathi', 'Marathi', 84),
	(102, 8, 'Mongolian', 'Mongolian', 85),
	(103, 8, 'Norwegian', 'Norwegian', 91),
	(104, 8, 'Panjabi', 'Panjabi', 97),
	(105, 8, 'Pashto', 'Pashto', 98),
	(106, 8, 'Persian', 'Persian', 99),
	(107, 8, 'Polish', 'Polish', 100),
	(108, 8, 'Portuguese', 'Portuguese', 101),
	(109, 8, 'Romanian', 'Romanian', 103),
	(110, 8, 'Russian', 'Russian', 106),
	(111, 8, 'Serbian', 'Serbian', 110),
	(112, 8, 'Sinhalese', 'Sinhalese', 113),
	(113, 8, 'Slovak', 'Slovak', 114),
	(114, 8, 'Slovenian', 'Slovenian', 115),
	(115, 8, 'Spanish', 'Spanish', 118),
	(116, 8, 'Swahili', 'Swahili', 120),
	(117, 8, 'Swedish', 'Swedish', 122),
	(118, 8, 'Tagalog', 'Tagalog', 123),
	(119, 8, 'Tamil', 'Tamil', 126),
	(120, 8, 'Telugu', 'Telugu', 128),
	(121, 8, 'Thai', 'Thai', 129),
	(122, 8, 'Turkish', 'Turkish', 135),
	(123, 8, 'Ukrainian', 'Ukrainian', 139),
	(124, 8, 'Urdu', 'Urdu', 140),
	(125, 8, 'Uzbek', 'Uzbek', 141),
	(126, 8, 'Vietnamese', 'Vietnamese', 143),
	(127, 8, 'Welsh', 'Welsh', 144),
	(128, 8, 'Yoruba', 'Yoruba', 148),
	(129, 8, 'Zulu', 'Zulu', 150),
	(130, 8, 'Scottish Gaelic', 'Scottish Gaelic', 151),
	(131, 7, 'Afghanistan', 'Afghanistan', 1),
	(132, 7, 'Albania', 'Albania', 3),
	(133, 7, 'Algeria', 'Algeria', 4),
	(134, 7, 'Argentina', 'Argentina', 11),
	(135, 7, 'Armenia', 'Armenia', 12),
	(136, 7, 'Australia', 'Australia', 14),
	(137, 7, 'Austria', 'Austria', 15),
	(138, 7, 'Azerbaijan', 'Azerbaijan', 16),
	(139, 7, 'Bangladesh', 'Bangladesh', 19),
	(140, 7, 'Belarus', 'Belarus', 21),
	(141, 7, 'Belgium', 'Belgium', 22),
	(142, 7, 'Bolivia, Plurinational State of', 'Bolivia, Plurinational State of', 27),
	(143, 7, 'Bosnia and Herzegovina', 'Bosnia and Herzegovina', 29),
	(144, 7, 'Brazil', 'Brazil', 32),
	(145, 7, 'Bulgaria', 'Bulgaria', 35),
	(146, 7, 'Canada', 'Canada', 40),
	(147, 7, 'Chile', 'Chile', 45),
	(148, 7, 'China', 'China', 46),
	(149, 7, 'Colombia', 'Colombia', 49),
	(150, 7, 'Croatia', 'Croatia', 56),
	(151, 7, 'Cyprus', 'Cyprus', 59),
	(152, 7, 'Czech Republic', 'Czech Republic', 60),
	(153, 7, 'Denmark', 'Denmark', 61),
	(154, 7, 'Egypt', 'Egypt', 66),
	(155, 7, 'Estonia', 'Estonia', 70),
	(156, 7, 'Faroe Islands', 'Faroe Islands', 73),
	(157, 7, 'Finland', 'Finland', 75),
	(158, 7, 'France', 'France', 76),
	(159, 7, 'French Polynesia', 'French Polynesia', 78),
	(160, 7, 'Georgia', 'Georgia', 82),
	(161, 7, 'Germany', 'Germany', 83),
	(162, 7, 'Greece', 'Greece', 86),
	(163, 7, 'Hong Kong', 'Hong Kong', 100),
	(164, 7, 'Hungary', 'Hungary', 101),
	(165, 7, 'Iceland', 'Iceland', 102),
	(166, 7, 'India', 'India', 103),
	(167, 7, 'Indonesia', 'Indonesia', 104),
	(168, 7, 'Iran, Islamic Republic of', 'Iran, Islamic Republic of', 105),
	(169, 7, 'Iraq', 'Iraq', 106),
	(170, 7, 'Ireland', 'Ireland', 107),
	(171, 7, 'Israel', 'Israel', 109),
	(172, 7, 'Italy', 'Italy', 110),
	(173, 7, 'Japan', 'Japan', 112),
	(174, 7, 'Kazakhstan', 'Kazakhstan', 115),
	(175, 7, 'Korea, Democratic People\'s Republic of', 'Korea, Democratic People\'s Republic of', 118),
	(176, 7, 'Korea, Republic of', 'Korea, Republic of', 119),
	(177, 7, 'Latvia', 'Latvia', 123),
	(178, 7, 'Lebanon', 'Lebanon', 124),
	(179, 7, 'Lithuania', 'Lithuania', 129),
	(180, 7, 'Luxembourg', 'Luxembourg', 130),
	(181, 7, 'Malaysia', 'Malaysia', 135),
	(182, 7, 'Maldives', 'Maldives', 136),
	(183, 7, 'Mexico', 'Mexico', 144),
	(184, 7, 'Moldova, Republic of', 'Moldova, Republic of', 146),
	(185, 7, 'Mongolia', 'Mongolia', 148),
	(186, 7, 'Netherlands', 'Netherlands', 157),
	(187, 7, 'New Zealand', 'New Zealand', 159),
	(188, 7, 'Nigeria', 'Nigeria', 162),
	(189, 7, 'Norway', 'Norway', 166),
	(190, 7, 'Pakistan', 'Pakistan', 169),
	(191, 7, 'Peru', 'Peru', 174),
	(192, 7, 'Philippines', 'Philippines', 175),
	(193, 7, 'Poland', 'Poland', 177),
	(194, 7, 'Portugal', 'Portugal', 178),
	(195, 7, 'Puerto Rico', 'Puerto Rico', 179),
	(196, 7, 'Qatar', 'Qatar', 180),
	(197, 7, 'Romania', 'Romania', 182),
	(198, 7, 'Russian Federation', 'Russian Federation', 183),
	(199, 7, 'Saudi Arabia', 'Saudi Arabia', 195),
	(200, 7, 'Serbia', 'Serbia', 197),
	(201, 7, 'Singapore', 'Singapore', 200),
	(202, 7, 'Slovakia', 'Slovakia', 202),
	(203, 7, 'Slovenia', 'Slovenia', 203),
	(204, 7, 'South Africa', 'South Africa', 206),
	(205, 7, 'Spain', 'Spain', 208),
	(206, 7, 'Sri Lanka', 'Sri Lanka', 209),
	(207, 7, 'Sweden', 'Sweden', 214),
	(208, 7, 'Switzerland', 'Switzerland', 215),
	(209, 7, 'Taiwan, Province of China', 'Taiwan, Province of China', 217),
	(210, 7, 'Thailand', 'Thailand', 220),
	(211, 7, 'Trinidad and Tobago', 'Trinidad and Tobago', 225),
	(212, 7, 'Tunisia', 'Tunisia', 226),
	(213, 7, 'Turkey', 'Turkey', 227),
	(214, 7, 'Ukraine', 'Ukraine', 232),
	(215, 7, 'United Arab Emirates', 'United Arab Emirates', 233),
	(216, 7, 'United Kingdom', 'United Kingdom', 234),
	(217, 7, 'United States', 'United States', 235),
	(218, 7, 'Uzbekistan', 'Uzbekistan', 238),
	(219, 7, 'Vanuatu', 'Vanuatu', 239),
	(220, 7, 'Venezuela, Bolivarian Republic of', 'Venezuela, Bolivarian Republic of', 240),
	(221, 7, 'Viet Nam', 'Viet Nam', 241),
	(222, 6, '30 minutes or less', '30', 1),
	(223, 6, '30 to 60 minutes', '60', 2),
	(224, 6, 'Over 60 minutes', '90', 3),
	(225, 4, 'Scripted', 'Scripted', 1),
	(226, 4, 'Animation', 'Animation', 2),
	(227, 4, 'Reality', 'Reality', 3),
	(228, 4, 'Talk Show', 'Talk Show', 4),
	(229, 4, 'Documentary', 'Documentary', 5),
	(230, 4, 'Game Show', 'Game Show', 6),
	(231, 4, 'News', 'News', 7),
	(232, 4, 'Sports', 'Sports', 8),
	(233, 4, 'Variety', 'Variety', 9),
	(234, 4, 'Award Show', 'Award Show', 10),
	(235, 4, 'Panel Show', 'Panel Show', 11);

-- Volcando estructura para tabla doselete.node
CREATE TABLE IF NOT EXISTS `node` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `IdTemplate` int(11) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `JsonValue` varchar(4000) DEFAULT NULL,
  `Modify` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`),
  KEY `nodo_plantilla` (`IdTemplate`),
  CONSTRAINT `nodo_plantilla` FOREIGN KEY (`IdTemplate`) REFERENCES `template` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Almacena los nodos de mi arbol que es el producto';

-- Volcando datos para la tabla doselete.node: ~0 rows (aproximadamente)

-- Volcando estructura para tabla doselete.node_relation
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='Establece relacion entre nodo';

-- Volcando datos para la tabla doselete.node_relation: ~0 rows (aproximadamente)

-- Volcando estructura para tabla doselete.template
CREATE TABLE IF NOT EXISTS `template` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL COMMENT 'Nombre de la Plantilla',
  `AttributeName` varchar(255) DEFAULT '',
  `Create` timestamp NOT NULL DEFAULT current_timestamp(),
  `Modify` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Volcando datos para la tabla doselete.template: ~11 rows (aproximadamente)
REPLACE INTO `template` (`Id`, `Name`, `AttributeName`, `Create`, `Modify`) VALUES
	(1, 'Country', 'country', '2024-10-05 22:00:00', '2024-10-06 08:58:51'),
	(2, 'Image', 'image', '2024-10-05 22:00:00', '2024-10-06 08:53:06'),
	(3, 'Externals', 'externals', '2024-10-05 22:00:00', '2024-10-06 08:53:38'),
	(4, 'Links', '_links', '2024-10-05 22:00:00', '2024-10-06 08:52:59'),
	(5, 'Network', 'network', '2024-10-05 22:00:00', '2024-10-06 08:52:30'),
	(6, 'Previous Episode', 'previousepisode', '2024-10-05 22:00:00', '2024-10-06 08:54:55'),
	(7, 'Rating', 'rating', '2024-10-05 22:00:00', '2024-10-06 08:52:27'),
	(8, 'Schedule', 'schedule', '2024-10-05 22:00:00', '2024-10-06 08:53:53'),
	(9, 'Self Link', 'self', '2024-10-05 22:00:00', '2024-10-06 08:52:50'),
	(10, 'Next Episode', 'nextepisode', '2024-10-05 22:00:00', '2024-10-06 08:56:45'),
	(11, 'TvMaze', '', '2024-10-05 21:59:00', '2024-10-15 08:09:47');

-- Volcando estructura para tabla doselete.template_allowed_children
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

-- Volcando datos para la tabla doselete.template_allowed_children: ~10 rows (aproximadamente)
REPLACE INTO `template_allowed_children` (`Id`, `IdTemplate`, `IdTemplateParent`, `MaxAllowed`) VALUES
	(1, 4, 11, 1),
	(2, 2, 11, 1),
	(3, 3, 11, 1),
	(4, 5, 11, 1),
	(5, 7, 11, 1),
	(6, 8, 11, 1),
	(7, 9, 4, 1),
	(8, 6, 4, 1),
	(9, 10, 4, 1),
	(10, 1, 5, 1);

-- Volcando estructura para tabla doselete.template_field
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

-- Volcando datos para la tabla doselete.template_field: ~35 rows (aproximadamente)
REPLACE INTO `template_field` (`Id`, `IdTemplate`, `IdType`, `IdMaster`, `Name`, `AttributeName`, `DefaultValue`, `Required`, `Place`) VALUES
	(1, 9, 3, NULL, 'link', 'href', '', 0, 1),
	(2, 6, 3, NULL, 'link', 'href', '', 0, 1),
	(3, 6, 3, NULL, 'name', 'name', '', 0, 2),
	(4, 2, 6, NULL, 'medium', 'medium', '', 0, 1),
	(5, 2, 6, NULL, 'original', 'original', '', 0, 2),
	(6, 1, 3, NULL, 'name', 'name', '', 0, 1),
	(7, 1, 3, NULL, 'code country', 'code', '', 0, 2),
	(8, 1, 3, NULL, 'time zone', 'timezone', '', 0, 3),
	(9, 3, 2, NULL, 'tv rage', 'tvrage', '', 0, 1),
	(10, 3, 2, NULL, 'the tvdb', 'thetvdb', '', 0, 2),
	(11, 3, 3, NULL, 'imdb', 'imdb', '', 0, 3),
	(12, 10, 3, NULL, 'link', 'href', '', 0, 1),
	(13, 10, 3, NULL, 'name', 'name', '', 0, 2),
	(14, 5, 2, NULL, 'Identification', 'id', '', 0, 1),
	(15, 5, 3, NULL, 'Tv Channel', 'name', '', 0, 2),
	(16, 5, 3, NULL, 'Official Site', 'officialSite', '', 0, 3),
	(17, 7, 2, NULL, 'Average', 'average', NULL, 0, 1),
	(18, 8, 3, NULL, 'time', 'time', NULL, 0, 1),
	(19, 11, 2, NULL, 'Identificaction', 'id', NULL, 1, 1),
	(20, 11, 3, NULL, 'Page More Info', 'url', NULL, 1, 2),
	(21, 11, 4, 3, 'Show Type', 'type', NULL, 1, 3),
	(22, 11, 4, 8, 'Language', 'language', NULL, 1, 4),
	(23, 11, 4, 4, 'Show Status', 'status', NULL, 1, 6),
	(24, 11, 4, 6, 'Runtime', 'runtime', NULL, 1, 7),
	(25, 11, 2, NULL, 'Average Runtime', 'averageRuntime', NULL, 1, 8),
	(26, 11, 3, NULL, 'Premiered', 'premiered', NULL, 1, 9),
	(27, 11, 3, NULL, 'Ended', 'ended', NULL, 0, 10),
	(28, 11, 3, NULL, 'Official Site', 'officialSite', NULL, 0, 11),
	(29, 11, 2, NULL, 'Weight', 'weight', NULL, 0, 13),
	(30, 11, 3, NULL, 'WEB Channel', 'webChannel', NULL, 0, 12),
	(31, 11, 4, 7, 'DVDCountry', 'dvdCountry', NULL, 0, 14),
	(32, 11, 3, NULL, 'Summary', 'summary', NULL, 0, 15),
	(33, 11, 2, NULL, 'Modify Date', 'updated', '-1', 1, 16),
	(34, 11, 5, 2, 'Show Gener', 'genres', NULL, 0, 5),
	(35, 8, 5, 4, 'days', 'days', NULL, 0, 2);

-- Volcando estructura para tabla doselete.tvmaze
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

-- Volcando datos para la tabla doselete.tvmaze: ~0 rows (aproximadamente)

-- Volcando estructura para tabla doselete.type_field
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
