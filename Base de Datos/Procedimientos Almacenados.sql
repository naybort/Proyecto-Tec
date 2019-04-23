USE SistemaConsultas
GO
-- Procedimiento para traer las tematicas
CREATE PROCEDURE Pr_Tematicas_Consultar
AS 
	SELECT NombreTematica
	FROM Tematicas
GO
 
--Procedimiento para traer los profesores por tematica

DROP PROCEDURE Pr_TematicasProfesor_Consultar
GO
USE SistemaConsultas
GO
CREATE PROCEDURE Pr_TematicasProfesor_Consultar
	@IdTematica int
AS
	SELECT Nombre, PrimerApellido, SegundoApellido, h.Dia, h.HoraInicio, h.HoraFinal
	FROM Profesor p
	INNER JOIN ProfesorXTematica pt
	on p.IdProfesor = pt.IdProfesor
	INNER JOIN Tematicas t
	on t.IdTematica = pt.IdTematica
	INNER JOIN ProfesorXHorario ph
	on ph.IdProfesor = p.IdProfesor
	INNER JOIN Horario h
	on h.idHorario = ph.IdHorario
	WHERE t.IdTematica = @IdTematica;
GO

--Procedimiento para mostrar los horarios de cada profesor
USE SistemaConsultas
GO
CREATE PROCEDURE Pr_HorarioProfesor_Consultar
	@IdProfesor int
AS
	SELECT *
	FROM ProfesorXHorario ph
	INNER JOIN Horario h
	on h.idHorario = ph.IdHorario
	WHERE ph.IdProfesor = @IdProfesor;
GO


-- Procedimiento para insertar citas
USE SistemaConsultas
GO
CREATE PROCEDURE Pr_Cita_Insertar
	@IdLugar int,
	@IdHorario int 
AS
	INSERT INTO Citas (IdLugar,IdHorario)
	VALUES (@IdLugar, @IdHorario)
	
GO

--Procedimiento para insertar en CitasxProfesor
USE SistemaConsultas
GO
CREATE PROCEDURE Pr_CitaxProfesor_Insertar
	@IdProfesor int,
	@IdCita int 
AS
	INSERT INTO CitaXProfesor(IdCita, IdProfesor)
	VALUES (@IdCita, @IdProfesor)
GO

--Procedimiento para insertar en CitasxEstudiante
USE SistemaConsultas
GO
CREATE PROCEDURE Pr_CitaxEstudiante_Insertar
	@IdEstudiante int,
	@IdCita int 
AS
	INSERT INTO CitaXEstudiante(IdCita, IdEstudiante)
	VALUES (@IdCita, @IdEstudiante)
GO


-- Eliminar procedimiento en caso de necesitar cambiarlo. 
DROP PROCEDURE Pr_Cita_Insertar_Prueba
GO


-- Procedimiento para insertar citas prueba
USE SistemaConsultas
GO
ALTER PROCEDURE Pr_Cita_Insertar_Prueba
	@IdLugar int,
	@IdHorario int,
	@IdProfesor int,
	@IdEstudiante int
AS
	DECLARE @IdCita int
	
	INSERT INTO Citas (IdLugar,IdHorario)
	VALUES (@IdLugar, @IdHorario);
	SET @IdCita = (SELECT IdCita FROM Citas WHERE IdCita= (SELECT MAX(IdCita) FROM Citas))
	PRINT @IdCita

	INSERT INTO CitaXProfesor(IdCita, IdProfesor)
	VALUES (@IdCita, @IdProfesor)
	
	INSERT INTO CitaXEstudiante(IdCita, IdEstudiante)
	VALUES (@IdCita, @IdEstudiante)
GO