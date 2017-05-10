ALTER TABLE `laborutkm`.`applicant` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;
ALTER TABLE `laborutkm`.`applicant` auto_increment=1;

ALTER TABLE `laborutkm`.`company` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;
ALTER TABLE `laborutkm`.`company`  auto_increment=1;

ALTER TABLE `laborutkm`.`evaluation` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;
ALTER TABLE `laborutkm`.`evaluation`  auto_increment=1;

ALTER TABLE `laborutkm`.`joboffer` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;
ALTER TABLE `laborutkm`.`joboffer` auto_increment=1;

ALTER TABLE `laborutkm`.`companyrole` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;
ALTER TABLE `laborutkm`.`companyrole` auto_increment=1;

ALTER TABLE `laborutkm`.`person` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;
ALTER TABLE `laborutkm`.`person`  auto_increment=1;

ALTER TABLE `laborutkm`.`recruitmentprocess` auto_increment=1;
ALTER TABLE `laborutkm`.`question` auto_increment=1;
ALTER TABLE `laborutkm`.`answer` auto_increment=1;
ALTER TABLE `laborutkm`.`assesment` auto_increment=1;

ALTER TABLE `laborutkm`.`recruitmentprocessstepdtoes` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;
ALTER TABLE `laborutkm`.`recruitmentprocessstepdtoes`  auto_increment=1;

ALTER TABLE `laborutkm`.`role` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;
ALTER TABLE `laborutkm`.`role`  auto_increment=1;

ALTER TABLE `laborutkm`.`section` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;
ALTER TABLE `laborutkm`.`section`  auto_increment=1;

ALTER TABLE `laborutkm`.`employee` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;
ALTER TABLE `laborutkm`.`employee`  auto_increment=1;

USE `laborutkm`;
DROP procedure IF EXISTS `RestartAssesment`;

DELIMITER $$
USE `laborutkm`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `RestartAssesment`(p_assesementID INT)
BEGIN

delete from assesmentcontexttoes where assesmentid = p_assesementID; commit;
delete from assesmentresponse where assesmentid = p_assesementID; commit;
update assesment set DateStarted = NULL, DateFinished = NULL where assesmentid = p_assesementID; commit;

END$$

DELIMITER ;