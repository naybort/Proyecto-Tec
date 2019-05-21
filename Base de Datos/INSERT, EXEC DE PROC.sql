--INSERTS

USE SistemaConsultas
INSERT INTO Tematicas (IdTematica, NombreTematica)
VALUES (2, 'Arquitectura2');

USE SistemaConsultas
INSERT INTO Profesor (IdProfesor,Nombre,PrimerApellido,SegundoApellido,CorreoElectronico)
VALUES (3,'Bryan','Solano','Mendez','fiorellasolano@hotmail.com');

USE SistemaConsultas
INSERT INTO ProfesorXTematica (IdProfesor, IdTematica)
VALUES (3,1);

USE SistemaConsultas
INSERT INTO Horarios( Dia, HoraInicio, HoraFinal)
VALUES ('Viernes','10:00','11:00')


USE SistemaConsultas
INSERT INTO ProfesorXHorario (IdHorario, IdProfesor)
VALUES (1,3)

select * from ProfesorXHorario

USE SistemaConsultas
INSERT INTO Lugar (IdLugar, Nombre)
VALUES (1,'Biblioteca')


USE SistemaConsultas
INSERT INTO Citas (IdHorario, IdLugar)
VALUES (1,1)
USE SistemaConsultas
SELECT *
FROM Citas



USE SistemaConsultas
GO
EXEC dbo.Pr_Tematicas_Consultar;
EXEC dbo.Pr_TematicasProfesor_Consultar 2;
GO 
EXEC dbo.Pr_Cita_Insertar 1,1;
GO

SELECT * 
FROM Citas

insert into SubTematicas
values('Crack en ingeneria2', 'Puto amo2')

insert into SubTematicaXProfesor
values(3,2)

select * from SubTematicas

select * from Horarios