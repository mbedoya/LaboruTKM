INSERT INTO `laborutkm`.`evaluation`
(
`Name`,
`Description`)
VALUES
(
'Test Evaluation',
'Test evaluation, QA purposes');


INSERT INTO `laborutkm`.`evaluation`
(
`Name`,
`Description`)
VALUES
(
'Gerente general',
'Permite evaluar a los gerentes generales de todo tipo de empresa');


INSERT INTO `laborutkm`.`evaluation`
(
`Name`,
`Description`)
VALUES
(
'Desarrollador de Software',
'Permite evaluar a los desarrolladores de Software de manera integral');

INSERT INTO `laborutkm`.`company`
(
`Name`,
`Logo`,
`ContactEmail`)
VALUES
('Intrepidez',
'logo-intrepidez.png',
'intrepidez'); commit;

INSERT INTO `laborutkm`.`person`
(
`Name`,
`Email`,
`PhoneNumber`,
`Title`,
`Summary`)
VALUES
(
'Carlos Eduardo Ospina',
'ceospina20@gmail.com',
'3004802277',
'Desarrollador .Net & Mobile',
'Ingeniero informático con 7 años de experiencia en la industria, con capacidad para diseñar y construir sistemas. He trabajado para las mejores casas de Software en Medellín.');

INSERT INTO `laborutkm`.`person`
(
`Name`,
`Email`,
`PhoneNumber`,
`Title`,
`Summary`)
VALUES
(
'Alexandra Ochoa',
'laochuva@gmail.com',
'3004802220',
'Desarrollador .Net, NodeJs & Font End',
'Ingeniera informática con 6 años de experiencia de desarrollo, con capacidad para diseñar y construir sistemas. He trabajado para empresas de desarrollo tanto en Colombia como en Estados Unidos.');

INSERT INTO `laborutkm`.`person`
(
`Name`,
`Email`,
`PhoneNumber`,
`Title`,
`Summary`)
VALUES
(
'Sandra Rivera',
'riverilla@gmail.com',
'3007738902',
'Gerente general',
'Administradora de Empresas con experiencia en gerencia en las principales empresas de confección de Colombia, bajo mi administración empresas medianas han llegado a ser líderes del sector.');


INSERT INTO `laborutkm`.`person`
(
`Name`,
`Email`,
`PhoneNumber`,
`Title`,
`Summary`)
VALUES
(
'Alejandro Díaz',
'alejodb@gmail.com',
'3006131410',
'Arquitecto .Net & Java',
'Ingeniero de sistemas con más de 15 años de experiencia de desarrollo y arquitectura de soluciones empresariales.');

INSERT INTO `laborutkm`.`role`
(
`Name`)
VALUES
(
'Desarrollador de Software');

INSERT INTO `laborutkm`.`role`
(
`Name`)
VALUES
(
'Gerente general');

INSERT INTO `laborutkm`.`role`
(
`Name`)
VALUES
(
'Psicóloga');

INSERT INTO `laborutkm`.`joboffer`
(
`Name`,
`CompanyId`,
`RoleId`,
`Description`)
VALUES
('Desarollador .Net',
1,
1,
'Creación de páginas web con Asp.Net MVC');

INSERT INTO `laborutkm`.`joboffer`
(
`Name`,
`CompanyId`,
`RoleId`,
`Description`)
VALUES
('Analista Desarrollador QA',
1,
1,
'Certificación de calidad en Java y .Net. Se requiere conocimientos avanzados en UnitTesting y TDD');