USE [master]
GO
/****** Object:  Database [SistemaConsultas]    Script Date: 04/08/2019 23:02:20 ******/
CREATE DATABASE [SistemaConsultas] ON  PRIMARY 
( NAME = N'SistemaConsultas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SistemaConsultas.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SistemaConsultas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\SistemaConsultas_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SistemaConsultas] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaConsultas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaConsultas] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [SistemaConsultas] SET ANSI_NULLS OFF
GO
ALTER DATABASE [SistemaConsultas] SET ANSI_PADDING OFF
GO
ALTER DATABASE [SistemaConsultas] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [SistemaConsultas] SET ARITHABORT OFF
GO
ALTER DATABASE [SistemaConsultas] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [SistemaConsultas] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [SistemaConsultas] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [SistemaConsultas] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [SistemaConsultas] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [SistemaConsultas] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [SistemaConsultas] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [SistemaConsultas] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [SistemaConsultas] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [SistemaConsultas] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [SistemaConsultas] SET  DISABLE_BROKER
GO
ALTER DATABASE [SistemaConsultas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [SistemaConsultas] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [SistemaConsultas] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [SistemaConsultas] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [SistemaConsultas] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [SistemaConsultas] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [SistemaConsultas] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [SistemaConsultas] SET  READ_WRITE
GO
ALTER DATABASE [SistemaConsultas] SET RECOVERY FULL
GO
ALTER DATABASE [SistemaConsultas] SET  MULTI_USER
GO
ALTER DATABASE [SistemaConsultas] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [SistemaConsultas] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'SistemaConsultas', N'ON'
GO
USE [SistemaConsultas]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[IdProfesor] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[PrimerApellido] [nvarchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NOT NULL,
	[CorreoElectronico] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[IdProfesor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lugar]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lugar](
	[IdLugar] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lugar] PRIMARY KEY CLUSTERED 
(
	[IdLugar] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[idHorario] [int] NOT NULL,
	[HoraInicio] [datetime] NOT NULL,
	[HoraFinal] [datetime] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Dia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[idHorario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante](
	[IdEstudiante] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[PrimerApellido] [nvarchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NOT NULL,
	[CorreoElectronico] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[IdEstudiante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tematicas]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tematicas](
	[IdTematica] [int] NOT NULL,
	[NombreTematica] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tematicas] PRIMARY KEY CLUSTERED 
(
	[IdTematica] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubTematicas]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubTematicas](
	[IdSubTematica] [int] NOT NULL,
	[NombreSubTematica] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SubTematicas] PRIMARY KEY CLUSTERED 
(
	[IdSubTematica] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TematicaXSubTematica]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TematicaXSubTematica](
	[IdTematica] [int] NOT NULL,
	[IdSubTematica] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cita]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cita](
	[IdCita] [int] NOT NULL,
	[IdHorario] [int] NOT NULL,
	[IdLugar] [int] NOT NULL,
 CONSTRAINT [PK_Cita] PRIMARY KEY CLUSTERED 
(
	[IdCita] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfesorXTematica]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesorXTematica](
	[IdProfesor] [int] NOT NULL,
	[IdTematica] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfesorXHorario]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfesorXHorario](
	[IdProfesor] [int] NOT NULL,
	[IdHorario] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CitaXProfesor]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CitaXProfesor](
	[IdCita] [int] NOT NULL,
	[IdProfesor] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CitaXEstudiante]    Script Date: 04/08/2019 23:02:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CitaXEstudiante](
	[IdCita] [int] NOT NULL,
	[IdEstudiante] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_TematicaXSubTematica_SubTematicas]    Script Date: 04/08/2019 23:02:21 ******/
ALTER TABLE [dbo].[TematicaXSubTematica]  WITH CHECK ADD  CONSTRAINT [FK_TematicaXSubTematica_SubTematicas] FOREIGN KEY([IdSubTematica])
REFERENCES [dbo].[SubTematicas] ([IdSubTematica])
GO
ALTER TABLE [dbo].[TematicaXSubTematica] CHECK CONSTRAINT [FK_TematicaXSubTematica_SubTematicas]
GO
/****** Object:  ForeignKey [FK_TematicaXSubTematica_Tematicas]    Script Date: 04/08/2019 23:02:21 ******/
ALTER TABLE [dbo].[TematicaXSubTematica]  WITH CHECK ADD  CONSTRAINT [FK_TematicaXSubTematica_Tematicas] FOREIGN KEY([IdTematica])
REFERENCES [dbo].[Tematicas] ([IdTematica])
GO
ALTER TABLE [dbo].[TematicaXSubTematica] CHECK CONSTRAINT [FK_TematicaXSubTematica_Tematicas]
GO
/****** Object:  ForeignKey [FK_Cita_Lugar]    Script Date: 04/08/2019 23:02:21 ******/
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD  CONSTRAINT [FK_Cita_Lugar] FOREIGN KEY([IdLugar])
REFERENCES [dbo].[Lugar] ([IdLugar])
GO
ALTER TABLE [dbo].[Cita] CHECK CONSTRAINT [FK_Cita_Lugar]
GO
/****** Object:  ForeignKey [FK_Profesor_Tematica_Tematicas]    Script Date: 04/08/2019 23:02:21 ******/
ALTER TABLE [dbo].[ProfesorXTematica]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_Tematica_Tematicas] FOREIGN KEY([IdTematica])
REFERENCES [dbo].[Tematicas] ([IdTematica])
GO
ALTER TABLE [dbo].[ProfesorXTematica] CHECK CONSTRAINT [FK_Profesor_Tematica_Tematicas]
GO
/****** Object:  ForeignKey [FK_ProfesorXHorario_Horario]    Script Date: 04/08/2019 23:02:21 ******/
ALTER TABLE [dbo].[ProfesorXHorario]  WITH CHECK ADD  CONSTRAINT [FK_ProfesorXHorario_Horario] FOREIGN KEY([IdHorario])
REFERENCES [dbo].[Horario] ([idHorario])
GO
ALTER TABLE [dbo].[ProfesorXHorario] CHECK CONSTRAINT [FK_ProfesorXHorario_Horario]
GO
/****** Object:  ForeignKey [FK_ProfesorXHorario_Profesor]    Script Date: 04/08/2019 23:02:21 ******/
ALTER TABLE [dbo].[ProfesorXHorario]  WITH CHECK ADD  CONSTRAINT [FK_ProfesorXHorario_Profesor] FOREIGN KEY([IdProfesor])
REFERENCES [dbo].[Profesor] ([IdProfesor])
GO
ALTER TABLE [dbo].[ProfesorXHorario] CHECK CONSTRAINT [FK_ProfesorXHorario_Profesor]
GO
/****** Object:  ForeignKey [FK_CitaXProfesor_Cita]    Script Date: 04/08/2019 23:02:21 ******/
ALTER TABLE [dbo].[CitaXProfesor]  WITH CHECK ADD  CONSTRAINT [FK_CitaXProfesor_Cita] FOREIGN KEY([IdCita])
REFERENCES [dbo].[Cita] ([IdCita])
GO
ALTER TABLE [dbo].[CitaXProfesor] CHECK CONSTRAINT [FK_CitaXProfesor_Cita]
GO
/****** Object:  ForeignKey [FK_CitaXEstudiante_Cita]    Script Date: 04/08/2019 23:02:21 ******/
ALTER TABLE [dbo].[CitaXEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_CitaXEstudiante_Cita] FOREIGN KEY([IdCita])
REFERENCES [dbo].[Cita] ([IdCita])
GO
ALTER TABLE [dbo].[CitaXEstudiante] CHECK CONSTRAINT [FK_CitaXEstudiante_Cita]
GO
/****** Object:  ForeignKey [FK_CitaXEstudiante_Estudiante]    Script Date: 04/08/2019 23:02:21 ******/
ALTER TABLE [dbo].[CitaXEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_CitaXEstudiante_Estudiante] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([IdEstudiante])
GO
ALTER TABLE [dbo].[CitaXEstudiante] CHECK CONSTRAINT [FK_CitaXEstudiante_Estudiante]
GO
/****** Object:  ForeignKey [FK_CitaXEstudiante_Estudiante1]    Script Date: 04/08/2019 23:02:21 ******/
ALTER TABLE [dbo].[CitaXEstudiante]  WITH CHECK ADD  CONSTRAINT [FK_CitaXEstudiante_Estudiante1] FOREIGN KEY([IdEstudiante])
REFERENCES [dbo].[Estudiante] ([IdEstudiante])
GO
ALTER TABLE [dbo].[CitaXEstudiante] CHECK CONSTRAINT [FK_CitaXEstudiante_Estudiante1]
GO
