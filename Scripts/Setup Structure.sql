ALTER TABLE `laborutkm`.`role` 
CHANGE COLUMN `DateCreated` `DateCreated` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ;

alter table `Person` modify `Summary` longtext;
