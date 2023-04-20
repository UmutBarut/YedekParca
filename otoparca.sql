/*
 Navicat Premium Data Transfer

 Source Server         : mysql
 Source Server Type    : MySQL
 Source Server Version : 80030
 Source Host           : localhost:3306
 Source Schema         : otoparca

 Target Server Type    : MySQL
 Target Server Version : 80030
 File Encoding         : 65001

 Date: 17/04/2023 02:08:39
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20230308202943_initialcreate', '6.0.11');
INSERT INTO `__efmigrationshistory` VALUES ('20230328175817_entityler', '6.0.11');
INSERT INTO `__efmigrationshistory` VALUES ('20230329175846_imagepath', '6.0.11');

-- ----------------------------
-- Table structure for aspnetroleclaims
-- ----------------------------
DROP TABLE IF EXISTS `aspnetroleclaims`;
CREATE TABLE `aspnetroleclaims`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AspNetRoleClaims_RoleId`(`RoleId` ASC) USING BTREE,
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetroleclaims
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetroles
-- ----------------------------
DROP TABLE IF EXISTS `aspnetroles`;
CREATE TABLE `aspnetroles`  (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `RoleNameIndex`(`NormalizedName` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetroles
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserclaims
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserclaims`;
CREATE TABLE `aspnetuserclaims`  (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_AspNetUserClaims_UserId`(`UserId` ASC) USING BTREE,
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetuserclaims
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserlogins
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserlogins`;
CREATE TABLE `aspnetuserlogins`  (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`, `ProviderKey`) USING BTREE,
  INDEX `IX_AspNetUserLogins_UserId`(`UserId` ASC) USING BTREE,
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetuserlogins
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetuserroles
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE `aspnetuserroles`  (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`, `RoleId`) USING BTREE,
  INDEX `IX_AspNetUserRoles_RoleId`(`RoleId` ASC) USING BTREE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetuserroles
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetusers
-- ----------------------------
DROP TABLE IF EXISTS `aspnetusers`;
CREATE TABLE `aspnetusers`  (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `AdSoyad` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `UserNameIndex`(`NormalizedUserName` ASC) USING BTREE,
  INDEX `EmailIndex`(`NormalizedEmail` ASC) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetusers
-- ----------------------------

-- ----------------------------
-- Table structure for aspnetusertokens
-- ----------------------------
DROP TABLE IF EXISTS `aspnetusertokens`;
CREATE TABLE `aspnetusertokens`  (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`UserId`, `LoginProvider`, `Name`) USING BTREE,
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of aspnetusertokens
-- ----------------------------

-- ----------------------------
-- Table structure for markalar
-- ----------------------------
DROP TABLE IF EXISTS `markalar`;
CREATE TABLE `markalar`  (
  `MarkaId` int NOT NULL AUTO_INCREMENT,
  `MarkaAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ImagePath` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Siralama` int NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  PRIMARY KEY (`MarkaId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 12 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of markalar
-- ----------------------------
INSERT INTO `markalar` VALUES (1, 'dasdad123123', NULL, 0, 0);
INSERT INTO `markalar` VALUES (2, 'dasdaddasd', NULL, 0, 0);
INSERT INTO `markalar` VALUES (3, 'asdasda', NULL, 0, 0);
INSERT INTO `markalar` VALUES (4, 'sdsada', NULL, 0, 0);
INSERT INTO `markalar` VALUES (5, 'umut', NULL, 0, 0);
INSERT INTO `markalar` VALUES (6, 'deneme aSDASda', NULL, 0, 0);
INSERT INTO `markalar` VALUES (7, 'ssjkşgjghj', NULL, 0, 0);
INSERT INTO `markalar` VALUES (8, 'AUDI', NULL, 0, 0);
INSERT INTO `markalar` VALUES (9, 'dasdsada', NULL, 0, 0);
INSERT INTO `markalar` VALUES (10, 'asdsadadadadadadsad', NULL, 0, 0);
INSERT INTO `markalar` VALUES (11, 'şşşşşşş', '84f1c8bd-3801-46ec-9e41-42b6397c6a57.png', 0, 0);
INSERT INTO `markalar` VALUES (12, 'asdasdsa', '5a39d48b-08c0-484f-a446-69651af02607.png', 0, 0);

-- ----------------------------
-- Table structure for modeller
-- ----------------------------
DROP TABLE IF EXISTS `modeller`;
CREATE TABLE `modeller`  (
  `ModelId` bigint NOT NULL AUTO_INCREMENT,
  `ModelAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TipId` bigint NOT NULL,
  `MarkaId` bigint NOT NULL,
  `Siralama` bigint NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  `ImagePath` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  PRIMARY KEY (`ModelId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of modeller
-- ----------------------------
INSERT INTO `modeller` VALUES (1, 'A3 Sportback 2022', 2, 8, 0, 0, NULL);
INSERT INTO `modeller` VALUES (2, 'asdasdsada', 1, 2, 0, 0, NULL);
INSERT INTO `modeller` VALUES (3, '333443111', 1, 3, 0, 0, NULL);
INSERT INTO `modeller` VALUES (4, 'sfdsafas', 2, 4, 0, 0, '61b87f5b-4b93-4c44-90e7-4beb25ae41aa.png');

-- ----------------------------
-- Table structure for motorlar
-- ----------------------------
DROP TABLE IF EXISTS `motorlar`;
CREATE TABLE `motorlar`  (
  `MotorId` int NOT NULL AUTO_INCREMENT,
  `MotorAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MotorGucu` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MotorHacmi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SilindirSayisi` int NOT NULL,
  `Yakit` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  PRIMARY KEY (`MotorId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of motorlar
-- ----------------------------

-- ----------------------------
-- Table structure for tip_motor
-- ----------------------------
DROP TABLE IF EXISTS `tip_motor`;
CREATE TABLE `tip_motor`  (
  `Tip_MotorId` int NOT NULL AUTO_INCREMENT,
  `MotorId` int NOT NULL,
  `TipId` int NOT NULL,
  PRIMARY KEY (`Tip_MotorId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tip_motor
-- ----------------------------

-- ----------------------------
-- Table structure for tipler
-- ----------------------------
DROP TABLE IF EXISTS `tipler`;
CREATE TABLE `tipler`  (
  `TipId` bigint NOT NULL AUTO_INCREMENT,
  `TipAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `MarkaId` bigint NOT NULL,
  `Siralama` bigint NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  PRIMARY KEY (`TipId`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tipler
-- ----------------------------
INSERT INTO `tipler` VALUES (1, 'A5 ', 8, 0, 0);
INSERT INTO `tipler` VALUES (2, 'A3', 8, 0, 0);
INSERT INTO `tipler` VALUES (3, 'A3', 1, 0, 0);

-- ----------------------------
-- Table structure for urungrubu
-- ----------------------------
DROP TABLE IF EXISTS `urungrubu`;
CREATE TABLE `urungrubu`  (
  `GrupId` int NOT NULL AUTO_INCREMENT,
  `GrupAdi` int NOT NULL,
  PRIMARY KEY (`GrupId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of urungrubu
-- ----------------------------

-- ----------------------------
-- Table structure for urunler
-- ----------------------------
DROP TABLE IF EXISTS `urunler`;
CREATE TABLE `urunler`  (
  `UrunId` int NOT NULL AUTO_INCREMENT,
  `UrunAdi` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Barkod` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ImagePath` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `Olcu` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Aciklama` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Pasif` tinyint(1) NOT NULL,
  `Fiyat` int NOT NULL,
  `MaxStok` int NOT NULL,
  `MinStok` int NOT NULL,
  `Miktar` int NOT NULL,
  `EklenmeTarihi` datetime(6) NOT NULL,
  PRIMARY KEY (`UrunId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of urunler
-- ----------------------------

SET FOREIGN_KEY_CHECKS = 1;
