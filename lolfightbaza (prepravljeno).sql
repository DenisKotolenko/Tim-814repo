-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Mar 26, 2014 at 08:23 PM
-- Server version: 5.6.12-log
-- PHP Version: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `lolfightbaza`
--
CREATE DATABASE IF NOT EXISTS `lolfightbaza` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `lolfightbaza`;

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE IF NOT EXISTS `admin` (
  `idAdmin` int(11) NOT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `eMail` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idAdmin`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `adminmessage`
--

CREATE TABLE IF NOT EXISTS `adminmessage` (
  `idAdminMessage` int(11) NOT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `Time` int(11) DEFAULT NULL,
  `Text` varchar(400) DEFAULT NULL,
  `Champion_idChampion` int(11) NOT NULL,
  `Admin_idAdmin` int(11) NOT NULL,
  PRIMARY KEY (`idAdminMessage`),
  KEY `fk_AdminMessage_Champion1_idx` (`Champion_idChampion`),
  KEY `fk_AdminMessage_Admin1_idx` (`Admin_idAdmin`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `champion`
--

CREATE TABLE IF NOT EXISTS `champion` (
  `idChampion` int(11) NOT NULL,
  `User_idUser` int(11) NOT NULL,
  `Nation` varchar(45) DEFAULT NULL,
  `ChampionType_idChampionType` int(11) NOT NULL,
  `Gold` int(11) DEFAULT NULL,
  `BanCooldown` int(11) DEFAULT NULL,
  PRIMARY KEY (`idChampion`),
  KEY `fk_Championi_Korisnici_idx` (`User_idUser`),
  KEY `fk_Championi_SviChampioni1_idx` (`ChampionType_idChampionType`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `championtype`
--

CREATE TABLE IF NOT EXISTS `championtype` (
  `idChampionType` int(11) NOT NULL,
  `Nation` varchar(45) DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `PictureLink` varchar(45) DEFAULT NULL,
  `HP` int(11) DEFAULT NULL,
  `AttackDmg` int(11) DEFAULT NULL,
  `AbilityPowerDmg` int(11) DEFAULT NULL,
  `AttackSpeed` int(11) DEFAULT NULL,
  `Armor` int(11) DEFAULT NULL,
  `MagicResist` int(11) DEFAULT NULL,
  PRIMARY KEY (`idChampionType`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE IF NOT EXISTS `inventory` (
  `idInventory` int(11) NOT NULL,
  `Champion_idChampion` int(11) NOT NULL,
  `Item_idItem` int(11) NOT NULL,
  `Activated` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idInventory`),
  KEY `fk_Itemi_Championi1_idx` (`Champion_idChampion`),
  KEY `fk_Itemi_SviItemi1_idx` (`Item_idItem`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `item`
--

CREATE TABLE IF NOT EXISTS `item` (
  `idItem` int(11) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Price` int(11) DEFAULT NULL,
  `HP` int(11) DEFAULT NULL,
  `AttackDmg` int(11) DEFAULT NULL,
  `AbilityPower` int(11) DEFAULT NULL,
  `AttackSpeed` int(11) DEFAULT NULL,
  `Armor` int(11) DEFAULT NULL,
  `MagicResist` int(11) DEFAULT NULL,
  `CritChance` int(11) DEFAULT NULL,
  `ArmorPen` int(11) DEFAULT NULL,
  `HealAmount` int(11) DEFAULT NULL,
  PRIMARY KEY (`idItem`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `logbattle`
--

CREATE TABLE IF NOT EXISTS `logbattle` (
  `idLogBattle` int(11) NOT NULL,
  `idAttacker` int(11) NOT NULL,
  `idDefender` int(11) NOT NULL,
  `StartTime` int(11) DEFAULT NULL,
  `Gold` int(11) DEFAULT NULL,
  `BattleReport` varchar(400) DEFAULT NULL,
  `idWinner` int(11) NOT NULL,
  PRIMARY KEY (`idLogBattle`),
  KEY `fk_IzvjestajiBorbi_Championi1_idx` (`idAttacker`),
  KEY `fk_IzvjestajiBorbi_Championi2_idx` (`idDefender`),
  KEY `fk_IzvjestajiBorbi_Championi3_idx` (`idWinner`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `logfarm`
--

CREATE TABLE IF NOT EXISTS `logfarm` (
  `idLogFarm` int(11) NOT NULL,
  `StartTime` int(11) DEFAULT NULL,
  `Daily` int(11) DEFAULT NULL,
  `Gold` int(11) DEFAULT NULL,
  `Statistics` varchar(45) DEFAULT NULL,
  `Champion_idChampion` int(11) NOT NULL,
  PRIMARY KEY (`idLogFarm`),
  KEY `fk_LogFarm_Champion1_idx` (`Champion_idChampion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `logjungle`
--

CREATE TABLE IF NOT EXISTS `logjungle` (
  `idLogJungle` int(11) NOT NULL,
  `StartTime` int(11) DEFAULT NULL,
  `Duration` int(11) DEFAULT NULL,
  `Gold` int(11) DEFAULT NULL,
  `Statistics` varchar(45) DEFAULT NULL,
  `Champion_idChampion` int(11) NOT NULL,
  PRIMARY KEY (`idLogJungle`),
  KEY `fk_LogJungle_Champion1_idx` (`Champion_idChampion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `message`
--

CREATE TABLE IF NOT EXISTS `message` (
  `idMessage` int(11) NOT NULL,
  `idSender` int(11) NOT NULL,
  `idReciever` int(11) NOT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `Time` int(11) DEFAULT NULL,
  `Text` varchar(400) DEFAULT NULL,
  PRIMARY KEY (`idMessage`),
  KEY `fk_Poruke_Championi1_idx` (`idSender`),
  KEY `fk_Poruke_Championi2_idx` (`idReciever`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `ranking`
--

CREATE TABLE IF NOT EXISTS `ranking` (
  `idRanking` int(11) NOT NULL,
  `Champion_idChampion` int(11) NOT NULL,
  `FarmGold` int(11) DEFAULT NULL,
  `StolenGold` int(11) DEFAULT NULL,
  PRIMARY KEY (`idRanking`),
  KEY `fk_RankStatistika_Championi1_idx` (`Champion_idChampion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `skill`
--

CREATE TABLE IF NOT EXISTS `skill` (
  `idSkill` int(11) NOT NULL,
  `Champion_idChampion` int(11) NOT NULL,
  `HP` int(11) DEFAULT NULL,
  `AttackDmg` int(11) DEFAULT NULL,
  `AbilityPowerDmg` int(11) DEFAULT NULL,
  `AttackSpeed` int(11) DEFAULT NULL,
  `Armor` int(11) DEFAULT NULL,
  `MagicResist` int(11) DEFAULT NULL,
  `CritChance` int(11) DEFAULT NULL,
  `ArmorPen` int(11) DEFAULT NULL,
  `MagicPen` int(11) DEFAULT NULL,
  PRIMARY KEY (`idSkill`),
  KEY `fk_Skilovi_Championi1_idx` (`Champion_idChampion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `idUser` int(11) NOT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `eMail` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `adminmessage`
--
ALTER TABLE `adminmessage`
  ADD CONSTRAINT `fk_AdminMessage_Champion1` FOREIGN KEY (`Champion_idChampion`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_AdminMessage_Admin1` FOREIGN KEY (`Admin_idAdmin`) REFERENCES `admin` (`idAdmin`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `champion`
--
ALTER TABLE `champion`
  ADD CONSTRAINT `fk_Championi_Korisnici` FOREIGN KEY (`User_idUser`) REFERENCES `user` (`idUser`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Championi_SviChampioni1` FOREIGN KEY (`ChampionType_idChampionType`) REFERENCES `championtype` (`idChampionType`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `inventory`
--
ALTER TABLE `inventory`
  ADD CONSTRAINT `fk_Itemi_Championi1` FOREIGN KEY (`Champion_idChampion`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Itemi_SviItemi1` FOREIGN KEY (`Item_idItem`) REFERENCES `item` (`idItem`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `logbattle`
--
ALTER TABLE `logbattle`
  ADD CONSTRAINT `fk_IzvjestajiBorbi_Championi1` FOREIGN KEY (`idAttacker`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_IzvjestajiBorbi_Championi2` FOREIGN KEY (`idDefender`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_IzvjestajiBorbi_Championi3` FOREIGN KEY (`idWinner`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `logfarm`
--
ALTER TABLE `logfarm`
  ADD CONSTRAINT `fk_LogFarm_Champion1` FOREIGN KEY (`Champion_idChampion`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `logjungle`
--
ALTER TABLE `logjungle`
  ADD CONSTRAINT `fk_LogJungle_Champion1` FOREIGN KEY (`Champion_idChampion`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `message`
--
ALTER TABLE `message`
  ADD CONSTRAINT `fk_Poruke_Championi1` FOREIGN KEY (`idSender`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Poruke_Championi2` FOREIGN KEY (`idReciever`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `ranking`
--
ALTER TABLE `ranking`
  ADD CONSTRAINT `fk_RankStatistika_Championi1` FOREIGN KEY (`Champion_idChampion`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `skill`
--
ALTER TABLE `skill`
  ADD CONSTRAINT `fk_Skilovi_Championi1` FOREIGN KEY (`Champion_idChampion`) REFERENCES `champion` (`idChampion`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
