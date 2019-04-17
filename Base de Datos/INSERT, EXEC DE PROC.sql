--INSERTS

USE SistemaConsultas
INSERT INTO Tematicas (IdTematica, NombreTematica)
VALUES (2, 'Arquitectura2');

USE SistemaConsultas
INSERT INTO Profesor (IdProfesor,Nombre,PrimerApellido,SegundoApellido,CorreoElectronico)
VALUES (2,'Fiorella2','Solano2','Mendez2','fiorellasolano@hotmail.com2');

USE SistemaConsultas
INSERT INTO ProfesorXTematica (IdProfesor, IdTematica)
VALUES (1,1);

USE SistemaConsultas
INSERT INTO Horario (idHorario, Fecha, Dia, HoraInicio, HoraFinal)
VALUES (2,'12/11/19','Jueves','7:00','9:00')


USE SistemaConsultas
INSERT INTO ProfesorXHorario (IdHorario, IdProfesor)
VALUES (2,2)

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

