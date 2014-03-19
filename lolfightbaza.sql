-- phpMyAdmin SQL Dump
-- version 4.0.4
-- http://www.phpmyadmin.net
--
-- Računalo: localhost
-- Vrijeme generiranja: Ožu 19, 2014 u 12:49 PM
-- Verzija poslužitelja: 5.6.12-log
-- PHP verzija: 5.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Baza podataka: `lolfightbaza`
--
CREATE DATABASE IF NOT EXISTS `lolfightbaza` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `lolfightbaza`;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `admin`
--

CREATE TABLE IF NOT EXISTS `admin` (
  `idAdmina` int(11) NOT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `eMail` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idAdmina`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `championi`
--

CREATE TABLE IF NOT EXISTS `championi` (
  `idChampiona` int(11) NOT NULL,
  `Korisnici_idKorisnika` int(11) NOT NULL,
  `Nacija` varchar(45) DEFAULT NULL,
  `SviChampioni_idSviChampioni` int(11) NOT NULL,
  `Gold` varchar(45) DEFAULT NULL,
  `DaLiJeAktivan` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idChampiona`),
  KEY `fk_Championi_Korisnici_idx` (`Korisnici_idKorisnika`),
  KEY `fk_Championi_SviChampioni1_idx` (`SviChampioni_idSviChampioni`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `inventory`
--

CREATE TABLE IF NOT EXISTS `inventory` (
  `idItema` int(11) NOT NULL,
  `Championi_idChampiona` int(11) NOT NULL,
  `SviItemi_idSviItem` int(11) NOT NULL,
  `DaLiJeAktiviran` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`idItema`),
  KEY `fk_Itemi_Championi1_idx` (`Championi_idChampiona`),
  KEY `fk_Itemi_SviItemi1_idx` (`SviItemi_idSviItem`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `izvjestajiborbi`
--

CREATE TABLE IF NOT EXISTS `izvjestajiborbi` (
  `idIzvjestajiBorbi` int(11) NOT NULL,
  `idNapadaca` int(11) NOT NULL,
  `idBranioca` int(11) NOT NULL,
  `VrijemeNapada` varchar(45) DEFAULT NULL,
  `OstvareniGold` int(11) DEFAULT NULL,
  `IzvjestajBorbe` varchar(400) DEFAULT NULL,
  `idPobjednika` int(11) NOT NULL,
  PRIMARY KEY (`idIzvjestajiBorbi`),
  KEY `fk_IzvjestajiBorbi_Championi1_idx` (`idNapadaca`),
  KEY `fk_IzvjestajiBorbi_Championi2_idx` (`idBranioca`),
  KEY `fk_IzvjestajiBorbi_Championi3_idx` (`idPobjednika`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `korisnici`
--

CREATE TABLE IF NOT EXISTS `korisnici` (
  `idKorisnika` int(11) NOT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `eMail` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idKorisnika`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `logaktivnosti`
--

CREATE TABLE IF NOT EXISTS `logaktivnosti` (
  `idLogAktivnosti` int(11) NOT NULL,
  `Championi_idChampiona` int(11) NOT NULL,
  `LogFarmanja_idLogFarmanja` int(11) NOT NULL,
  `LogJunglanja_idLogJunglanja` int(11) NOT NULL,
  PRIMARY KEY (`idLogAktivnosti`),
  KEY `fk_LogAktivnosti_Championi1_idx` (`Championi_idChampiona`),
  KEY `fk_LogAktivnosti_LogFarmanja1_idx` (`LogFarmanja_idLogFarmanja`),
  KEY `fk_LogAktivnosti_LogJunglanja1_idx` (`LogJunglanja_idLogJunglanja`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `logfarmanja`
--

CREATE TABLE IF NOT EXISTS `logfarmanja` (
  `idLogFarmanja` int(11) NOT NULL,
  `PocetakFarmanja` varchar(45) DEFAULT NULL,
  `KojiPutUDanu` int(11) DEFAULT NULL,
  `DobiveniGold` int(11) DEFAULT NULL,
  `Statistika` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idLogFarmanja`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `logjunglanja`
--

CREATE TABLE IF NOT EXISTS `logjunglanja` (
  `idLogJunglanja` int(11) NOT NULL,
  `VrijemePocetka` varchar(45) DEFAULT NULL,
  `Trajanje` varchar(45) DEFAULT NULL,
  `DobiveniGold` int(11) DEFAULT NULL,
  `Statistka` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idLogJunglanja`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `poruke`
--

CREATE TABLE IF NOT EXISTS `poruke` (
  `idPoruke` int(11) NOT NULL,
  `idPosiljaoca` int(11) NOT NULL,
  `idPrimaoca` int(11) NOT NULL,
  `Admin_idAdmina` int(11) DEFAULT NULL,
  `NaslovPoruke` varchar(45) DEFAULT NULL,
  `VrijemePoruke` varchar(45) DEFAULT NULL,
  `TekstPoruke` varchar(400) DEFAULT NULL,
  PRIMARY KEY (`idPoruke`),
  KEY `fk_Poruke_Championi1_idx` (`idPosiljaoca`),
  KEY `fk_Poruke_Admin1_idx` (`Admin_idAdmina`),
  KEY `fk_Poruke_Championi2_idx` (`idPrimaoca`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `rankstatistika`
--

CREATE TABLE IF NOT EXISTS `rankstatistika` (
  `idRankStatistika` int(11) NOT NULL,
  `Championi_idChampiona` int(11) NOT NULL,
  `NafarmaniGold` varchar(45) DEFAULT NULL,
  `OpljackaniGold` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idRankStatistika`),
  KEY `fk_RankStatistika_Championi1_idx` (`Championi_idChampiona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `skilovi`
--

CREATE TABLE IF NOT EXISTS `skilovi` (
  `idSkila` int(11) NOT NULL,
  `Championi_idChampiona` int(11) NOT NULL,
  `HP` int(11) DEFAULT NULL,
  `AttackDmg` int(11) DEFAULT NULL,
  `AbilityPowerDmg` int(11) DEFAULT NULL,
  `AttackSpeed` int(11) DEFAULT NULL,
  `Armor` int(11) DEFAULT NULL,
  `MagicResist` int(11) DEFAULT NULL,
  `CritChance` int(11) DEFAULT NULL,
  `ArmorPen` int(11) DEFAULT NULL,
  `MagicPen` int(11) DEFAULT NULL,
  PRIMARY KEY (`idSkila`),
  KEY `fk_Skilovi_Championi1_idx` (`Championi_idChampiona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `svichampioni`
--

CREATE TABLE IF NOT EXISTS `svichampioni` (
  `idSviChampioni` int(11) NOT NULL,
  `Nacija` varchar(45) DEFAULT NULL,
  `Ime` varchar(45) DEFAULT NULL,
  `HP` int(11) DEFAULT NULL,
  `AttackDmg` int(11) DEFAULT NULL,
  `AbilityPowerDmg` int(11) DEFAULT NULL,
  `AttackSpeed` int(11) DEFAULT NULL,
  `Armor` int(11) DEFAULT NULL,
  `MagicResist` int(11) DEFAULT NULL,
  PRIMARY KEY (`idSviChampioni`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablična struktura za tablicu `sviitemi`
--

CREATE TABLE IF NOT EXISTS `sviitemi` (
  `idSviItem` int(11) NOT NULL,
  `Naziv` varchar(45) DEFAULT NULL,
  `Cijena` int(11) DEFAULT NULL,
  `HP` int(11) DEFAULT NULL,
  `AttackDmg` int(11) DEFAULT NULL,
  `AbilityPower` int(11) DEFAULT NULL,
  `AttackSpeed` int(11) DEFAULT NULL,
  `Armor` int(11) DEFAULT NULL,
  `MagicResist` int(11) DEFAULT NULL,
  `CritChance` int(11) DEFAULT NULL,
  `ArmorPen` int(11) DEFAULT NULL,
  `HealAmount` int(11) DEFAULT NULL,
  `linkslike` varchar(200) NOT NULL,
  PRIMARY KEY (`idSviItem`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Ograničenja za izbačene tablice
--

--
-- Ograničenja za tablicu `championi`
--
ALTER TABLE `championi`
  ADD CONSTRAINT `fk_Championi_Korisnici` FOREIGN KEY (`Korisnici_idKorisnika`) REFERENCES `korisnici` (`idKorisnika`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Championi_SviChampioni1` FOREIGN KEY (`SviChampioni_idSviChampioni`) REFERENCES `svichampioni` (`idSviChampioni`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ograničenja za tablicu `inventory`
--
ALTER TABLE `inventory`
  ADD CONSTRAINT `fk_Itemi_Championi1` FOREIGN KEY (`Championi_idChampiona`) REFERENCES `championi` (`idChampiona`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Itemi_SviItemi1` FOREIGN KEY (`SviItemi_idSviItem`) REFERENCES `sviitemi` (`idSviItem`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ograničenja za tablicu `izvjestajiborbi`
--
ALTER TABLE `izvjestajiborbi`
  ADD CONSTRAINT `fk_IzvjestajiBorbi_Championi1` FOREIGN KEY (`idNapadaca`) REFERENCES `championi` (`idChampiona`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_IzvjestajiBorbi_Championi2` FOREIGN KEY (`idBranioca`) REFERENCES `championi` (`idChampiona`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_IzvjestajiBorbi_Championi3` FOREIGN KEY (`idPobjednika`) REFERENCES `championi` (`idChampiona`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ograničenja za tablicu `logaktivnosti`
--
ALTER TABLE `logaktivnosti`
  ADD CONSTRAINT `fk_LogAktivnosti_Championi1` FOREIGN KEY (`Championi_idChampiona`) REFERENCES `championi` (`idChampiona`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_LogAktivnosti_LogFarmanja1` FOREIGN KEY (`LogFarmanja_idLogFarmanja`) REFERENCES `logfarmanja` (`idLogFarmanja`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_LogAktivnosti_LogJunglanja1` FOREIGN KEY (`LogJunglanja_idLogJunglanja`) REFERENCES `logjunglanja` (`idLogJunglanja`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ograničenja za tablicu `poruke`
--
ALTER TABLE `poruke`
  ADD CONSTRAINT `fk_Poruke_Admin1` FOREIGN KEY (`Admin_idAdmina`) REFERENCES `admin` (`idAdmina`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Poruke_Championi1` FOREIGN KEY (`idPosiljaoca`) REFERENCES `championi` (`idChampiona`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Poruke_Championi2` FOREIGN KEY (`idPrimaoca`) REFERENCES `championi` (`idChampiona`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ograničenja za tablicu `rankstatistika`
--
ALTER TABLE `rankstatistika`
  ADD CONSTRAINT `fk_RankStatistika_Championi1` FOREIGN KEY (`Championi_idChampiona`) REFERENCES `championi` (`idChampiona`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Ograničenja za tablicu `skilovi`
--
ALTER TABLE `skilovi`
  ADD CONSTRAINT `fk_Skilovi_Championi1` FOREIGN KEY (`Championi_idChampiona`) REFERENCES `championi` (`idChampiona`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
