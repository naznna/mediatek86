-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mar. 26 mai 2026 à 11:20
-- Version du serveur : 8.4.7
-- Version de PHP : 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `mediatek86`
--
CREATE DATABASE IF NOT EXISTS `mediatek86` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `mediatek86`;

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `idpersonnel` int NOT NULL,
  `datedebut` datetime NOT NULL,
  `datefin` datetime DEFAULT NULL,
  `idmotif` int NOT NULL,
  PRIMARY KEY (`idpersonnel`,`datedebut`),
  KEY `idmotif` (`idmotif`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES
(1, '2024-02-12 08:00:00', '2024-02-16 18:00:00', 1),
(1, '2024-05-20 08:00:00', '2024-05-21 18:00:00', 2),
(1, '2024-08-05 08:00:00', '2024-08-23 18:00:00', 1),
(1, '2025-01-15 08:00:00', '2025-01-15 18:00:00', 2),
(1, '2025-06-10 08:00:00', '2025-06-14 18:00:00', 3),
(2, '2024-03-04 08:00:00', '2024-03-08 18:00:00', 1),
(2, '2024-07-15 08:00:00', '2024-08-09 18:00:00', 1),
(2, '2024-11-22 08:00:00', '2024-11-22 18:00:00', 2),
(2, '2025-03-10 08:00:00', '2025-03-12 18:00:00', 2),
(2, '2025-09-01 08:00:00', '2025-09-05 18:00:00', 3),
(3, '2024-01-08 08:00:00', '2024-01-10 18:00:00', 2),
(3, '2024-04-22 08:00:00', '2024-05-03 18:00:00', 1),
(3, '2024-10-14 08:00:00', '2024-10-18 18:00:00', 3),
(3, '2025-02-20 08:00:00', '2025-02-21 18:00:00', 2),
(3, '2025-07-07 08:00:00', '2025-07-25 18:00:00', 1),
(4, '2024-02-26 08:00:00', '2024-03-01 18:00:00', 1),
(4, '2024-06-17 08:00:00', '2024-06-17 18:00:00', 2),
(4, '2024-09-09 08:00:00', '2024-09-13 18:00:00', 1),
(4, '2025-04-14 08:00:00', '2025-04-18 18:00:00', 3),
(4, '2025-10-06 08:00:00', '2025-10-06 18:00:00', 2),
(5, '2024-01-29 08:00:00', '2024-02-02 18:00:00', 1),
(5, '2024-05-13 08:00:00', '2024-05-14 18:00:00', 2),
(5, '2024-08-19 08:00:00', '2024-09-06 18:00:00', 4),
(5, '2025-01-06 08:00:00', '2025-01-08 18:00:00', 2),
(5, '2025-05-26 08:00:00', '2025-05-30 18:00:00', 1),
(6, '2024-03-18 08:00:00', '2024-03-22 18:00:00', 1),
(6, '2024-07-01 08:00:00', '2024-07-19 18:00:00', 1),
(6, '2024-12-09 08:00:00', '2024-12-10 18:00:00', 2),
(6, '2025-03-24 08:00:00', '2025-03-28 18:00:00', 3),
(6, '2025-08-11 08:00:00', '2025-08-29 18:00:00', 1),
(7, '2024-02-05 08:00:00', '2024-02-09 18:00:00', 1),
(7, '2024-06-03 08:00:00', '2024-06-03 18:00:00', 2),
(7, '2024-10-21 08:00:00', '2024-11-08 18:00:00', 4),
(7, '2025-07-14 00:00:00', '2025-07-18 00:00:00', 3),
(8, '2024-04-08 08:00:00', '2024-04-12 18:00:00', 1),
(8, '2024-08-26 08:00:00', '2024-08-30 18:00:00', 1),
(8, '2024-11-04 08:00:00', '2024-11-05 18:00:00', 2),
(8, '2025-05-12 08:00:00', '2025-05-16 18:00:00', 3),
(8, '2025-09-22 08:00:00', '2025-09-22 18:00:00', 2),
(9, '2024-01-22 08:00:00', '2024-01-26 18:00:00', 1),
(9, '2024-05-06 08:00:00', '2024-05-07 18:00:00', 2),
(9, '2024-09-30 08:00:00', '2024-10-18 18:00:00', 1),
(9, '2025-04-07 08:00:00', '2025-04-09 18:00:00', 3),
(9, '2025-11-17 08:00:00', '2025-11-21 18:00:00', 2),
(10, '2024-03-11 08:00:00', '2024-03-15 18:00:00', 1),
(10, '2024-07-22 08:00:00', '2024-08-16 18:00:00', 1),
(10, '2024-12-02 08:00:00', '2024-12-03 18:00:00', 2),
(10, '2025-06-23 08:00:00', '2025-06-27 18:00:00', 3),
(10, '2025-10-13 08:00:00', '2025-10-13 18:00:00', 2),
(3, '2042-03-01 08:00:00', '2044-11-12 18:00:00', 1),
(3, '2042-03-01 00:00:00', '2044-11-12 00:00:00', 1),
(7, '2027-07-14 00:00:00', '2027-07-18 00:00:00', 2);

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idmotif`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `prenom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tel` varchar(15) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `mail` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `idservice` int NOT NULL,
  PRIMARY KEY (`idpersonnel`),
  KEY `idservice` (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES
(1, 'Martin', 'Sophie', '0612345678', 'sophie.martin@mediatek86.fr', 1),
(2, 'Dubois', 'Pierre', '0623456789', 'pierre.dubois@mediatek86.fr', 1),
(3, 'Bernard', 'Marie', '0634567890', 'marie.bernard@mediatek86.fr', 2),
(4, 'Petit', 'Lucas', '0645678901', 'lucas.petit@mediatek86.fr', 2),
(5, 'Robert', 'Emma', '0656789012', 'emma.robert@mediatek86.fr', 2),
(6, 'Richard', 'Thomas', '0667890123', 'thomas.richard@mediatek86.fr', 3),
(7, 'Durand', 'Julie', '0678901234', 'julie.durand@mediatek86.fr', 3),
(8, 'Moreau', 'Antoine', '0689012345', 'antoine.moreau@mediatek86.fr', 3),
(9, 'Laurent', 'Camille', '0690123456', 'camille.laurent@mediatek86.fr', 1),
(10, 'Simon', 'Hugo', '0601234567', 'hugo.simon@mediatek86.fr', 2);

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `pwd` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation culturelle'),
(3, 'prêt');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
