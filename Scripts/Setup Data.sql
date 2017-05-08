
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
'Ingeniero inform�tico con 7 a�os de experiencia en la industria, con capacidad para dise�ar y construir sistemas. He trabajado para las mejores casas de Software en Medell�n.');

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
'Ingeniera inform�tica con 6 a�os de experiencia de desarrollo, con capacidad para dise�ar y construir sistemas. He trabajado para empresas de desarrollo tanto en Colombia como en Estados Unidos.');

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
'Administradora de Empresas con experiencia en gerencia en las principales empresas de confecci�n de Colombia, bajo mi administraci�n empresas medianas han llegado a ser l�deres del sector.');


INSERT INTO `laborutkm`.`person`
(
`Name`,
`Email`,
`PhoneNumber`,
`Title`,
`Summary`)
VALUES
(
'Alejandro D�az',
'alejodb@gmail.com',
'3006131410',
'Arquitecto .Net & Java',
'Ingeniero de sistemas con m�s de 15 a�os de experiencia de desarrollo y arquitectura de soluciones empresariales.');

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
'Psic�loga');

INSERT INTO `laborutkm`.`companyrole`
(
`Name`,
`Description`,
`RoleSenority`,
`CompanyId`,
`RoleId`)
VALUES
('Desarollador Junior .Net',
'Creaci�n de p�ginas web con Asp.Net MVC',
1,
1,
1);

INSERT INTO `laborutkm`.`companyrole`
(
`Name`,
`Description`,
`RoleSenority`,
`CompanyId`,
`RoleId`)
VALUES
('Analista Desarrollador Medio QA',
'Certificaci�n de calidad en Java y .Net. Se requiere conocimientos avanzados en UnitTesting y TDD',
1,
1,
1);


INSERT INTO `laborutkm`.`joboffer`
(
`CompanyRoleId`)
VALUES
(
1);

INSERT INTO `laborutkm`.`joboffer`
(
`CompanyRoleId`)
VALUES
(
2);

INSERT INTO `laborutkm`.`applicant`
(
`PersonId`,
`JobOfferId`)
VALUES
(
1,
1);

INSERT INTO `laborutkm`.`recruitmentprocess`
(
`Comments`,
`State`,
`DateUpdated`,
`Applicant_ApplicantId`)
VALUES
(
NULL,
1,
CURRENT_TIMESTAMP,
1);

INSERT INTO `laborutkm`.`recruitmentprocessstepdtoes`
(
`Comments`,
`RecruitmentProcessId`,
`Name`)
VALUES
(
NULL,
1,
'CandidateCreated');

INSERT INTO `laborutkm`.`employee`
(
`Name`,
`Email`,
`Password`,
`ApplicantId`,
`PersonId`,
`CompanyId`)
VALUES
(
'Mauricio Bedoya',
'mauricio.bedoya@intrepidez.co',
'1234',
NULL,
NULL,
1);

INSERT INTO `laborutkm`.`employee`
(
`Name`,
`Email`,
`Password`,
`ApplicantId`,
`PersonId`,
`CompanyId`)
VALUES
(
'M�nica Naranjo',
'monica.naranjo@intrepidez.co',
'1234',
NULL,
NULL,
1);

INSERT INTO `laborutkm`.`employeedtocompanyroledtoes`
(`EmployeeDTO_EmployeeId`,
`CompanyRoleDTO_CompanyRoleId`)
VALUES
(1,
1);

INSERT INTO `laborutkm`.`employeedtocompanyroledtoes`
(`EmployeeDTO_EmployeeId`,
`CompanyRoleDTO_CompanyRoleId`)
VALUES
(2,
2);

/* ASSESMENT */

INSERT INTO `laborutkm`.`evaluation`
(
`Name`,
`Description`,
`RoleId`)
VALUES
(
'Desarrollador de Software',
'Permite evaluar a los desarrolladores de Software de manera integral',
1);

INSERT INTO `laborutkm`.`assesment`
(
`AssesmentKey`,
`CompanyID`,
`EmployeeId`,
`EvaluationID`,
`Type`)
VALUES
('intrepidez_mb',
1,
1,
1,
1); commit;

INSERT INTO `laborutkm`.`section`
(
`Name`,
`Description`,
`Type`,
`EstimatedDuration`)
VALUES
('Capacidad de an�lisis',
'Esta prueba mide la capacidad de entendimiento y soluci�n a diversos problemas.',
'Internal',
1); commit;

INSERT INTO `laborutkm`.`evaluationdtosectiondtoes`
(`EvaluationDTO_Id`,
`SectionDTO_SectionId`)
VALUES
(1,
1);

INSERT INTO `laborutkm`.`section`
(
`Name`,
`Description`,
`Type`,
`EstimatedDuration`)
VALUES
('L�gica de Programaci�n',
'Esta prueba mide la capacidad para crear, entender y modificar algoritmos.',
'Internal',
2); commit;

INSERT INTO `laborutkm`.`evaluationdtosectiondtoes`
(`EvaluationDTO_Id`,
`SectionDTO_SectionId`)
VALUES
(1,
2);

INSERT INTO `laborutkm`.`question`
(
`Text`,
`Type`,
`SectionID`,
`Points`)
VALUES
('El n�mero de posibles reordenamientos de las letras de la palabra perro que no empiezan por la letra p es:',
'Simple',
1,
50); commit;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
(48,
1); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
(24,
1); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
(12,
1); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
(120,
1); COMMIT;

update `laborutkm`.`question` set RightAnswerID = 1 where questionid=1; commit;

INSERT INTO `laborutkm`.`question`
(
`Text`,
`Type`,
`SectionID`,
`Points`)
VALUES
('Si �ngela habla m�s bajo que Rosa y Celia habla m�s alto que Rosa, �habla �ngela m�s alto o m�s bajo que Celia?',
'Simple',
1,
50); commit;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('M�s bajo',
2); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('M�s alto',
2); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('No se puede saber',
2); COMMIT;

update `laborutkm`.`question` set RightAnswerID = 5 where questionid=2; commit;

INSERT INTO `laborutkm`.`question`
(
`Text`,
`Type`,
`SectionID`,
`Points`)
VALUES
('La nota media conseguida en una clase de 20 alumnos ha sido de 6. Ocho alumnos han suspendido con un 3 y el resto super� el 5. �Cu�l es la nota media de los alumnos aprobados?',
'Simple',
2,
50); commit;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('10',
2); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('8',
2); COMMIT;


INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('12',
2); COMMIT;

update `laborutkm`.`question` set RightAnswerID = 9 where questionid=3; commit;

INSERT INTO `laborutkm`.`evaluation`
(
`Name`,
`Description`,
`RoleID`)
VALUES
('Evaluaci�n Gerente General',
'Esta evaluaci�n busca determinar el conocimiento que se tiene en el �rea de la gerencia y su capacidad de aplicaci�n',
2);

INSERT INTO `laborutkm`.`section`
(
`Name`,
`Description`,
`Type`,
`EstimatedDuration`)
VALUES
('Motivaci�n & Liderazgo',
'Esta prueba mide las aptitudes para liderar equipos.',
'Internal',
0.5); commit;

INSERT INTO `laborutkm`.`evaluationdtosectiondtoes`
(`EvaluationDTO_Id`,
`SectionDTO_SectionId`)
VALUES
(2,
3);

INSERT INTO `laborutkm`.`section`
(
`Name`,
`Description`,
`Type`,
`EstimatedDuration`)
VALUES
('Planeaci�n',
'Esta prueba mide los conocimientos en planeaci�n.',
'Internal',
0.5); commit;

INSERT INTO `laborutkm`.`evaluationdtosectiondtoes`
(`EvaluationDTO_Id`,
`SectionDTO_SectionId`)
VALUES
(2,
4);

INSERT INTO `laborutkm`.`section`
(
`Name`,
`Description`,
`Type`,
`EstimatedDuration`)
VALUES
('Ingl�s',
'Esta prueba mide conocimientos b�sicos en ingl�s.',
'Internal',
0.5); commit;

INSERT INTO `laborutkm`.`evaluationdtosectiondtoes`
(`EvaluationDTO_Id`,
`SectionDTO_SectionId`)
VALUES
(2,
5);

INSERT INTO `laborutkm`.`question`
(
`Text`,
`Type`,
`SectionID`,
`RightAnswerID`,
`Points`)
VALUES
('�La misi�n o el prop�sito de mi compa��a en cuanto a mis empleados es?',
'Simple',
3,
NULL,
100);

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('Explotarlos',
4); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('Regarles dinero',
4); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('Apoyar sus iniciativas',
4); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('Brindarles mucho cari�o',
4); COMMIT;

update laborutkm.question set rightanswerid=13 where questionid=4;


INSERT INTO `laborutkm`.`question`
(
`Text`,
`Type`,
`SectionID`,
`RightAnswerID`,
`Points`)
VALUES
('�Cu�l de los siguientes no es un plan a largo plazo?',
'Simple',
4,
NULL,
100);


INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('Ventas',
5); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('Fiscales',
5); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('Compras de activos',
5); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('Financieros',
5); COMMIT;


update laborutkm.question set rightanswerid=15 where questionid=5;


INSERT INTO `laborutkm`.`question`
(
`Text`,
`Type`,
`SectionID`,
`RightAnswerID`,
`Points`)
VALUES
('You can have ice cream ______ you finish your dinner.',
'Simple',
5,
NULL,
50);

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('when',
6); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('but',
6); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('and',
6); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('while',
6); COMMIT;


update laborutkm.question set rightanswerid=19 where questionid=6;


INSERT INTO `laborutkm`.`question`
(
`Text`,
`Type`,
`SectionID`,
`RightAnswerID`,
`Points`)
VALUES
('How long ______ in Spain on vacation last summer?',
'Simple',
5,
NULL,
50);

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('was',
7); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('are been',
7); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('were they',
7); COMMIT;

INSERT INTO `laborutkm`.`answer`
(
`Text`,
`QuestionID`)
VALUES
('you are been',
7); COMMIT;

update laborutkm.question set rightanswerid=25 where questionid=7;

INSERT INTO `laborutkm`.`roleanalysis`
(`RoleID`,
`Name`,
`Points`,
`Description`)
VALUES
(2,
'N/D POCA CAPACIDAD',
0,
'No cuenta con los conocimientos b�sicos para desempe�ar la funci�n');

INSERT INTO `laborutkm`.`roleanalysis`
(`RoleID`,
`Name`,
`Points`,
`Description`)
VALUES
(2,
'JUNIOR',
100,
'Posee algunos conocimientos, no se recomienda que gerencie una empresa');

INSERT INTO `laborutkm`.`roleanalysis`
(`RoleID`,
`Name`,
`Points`,
`Description`)
VALUES
(2,
'MEDIO',
180,
'Cuenta con las habilidades necesarias para gerenciar peque�as y medianas empresas.');

INSERT INTO `laborutkm`.`roleanalysis`
(`RoleID`,
`Name`,
`Points`,
`Description`)
VALUES
(2,
'CLASE MUNDIAL',
280,
'Posee conocimiento de clase mundial, entiende las necesidades del negocio y sus empleados.');
