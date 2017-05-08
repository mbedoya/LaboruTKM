ALTER TABLE `laborutkm`.`applicant` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

ALTER TABLE `laborutkm`.`company` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

ALTER TABLE `laborutkm`.`evaluation` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

ALTER TABLE `laborutkm`.`joboffer` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

ALTER TABLE `laborutkm`.`companyrole` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

ALTER TABLE `laborutkm`.`person` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

ALTER TABLE `laborutkm`.`recruitmentprocessstepdtoes` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

ALTER TABLE `laborutkm`.`role` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

ALTER TABLE `laborutkm`.`section` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

ALTER TABLE `laborutkm`.`employee` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

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
