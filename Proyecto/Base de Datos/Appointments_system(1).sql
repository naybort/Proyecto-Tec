USE [master]
GO
/****** Object:  Database [sistema_consultas]    Script Date: 21/03/2019 0:15:36 ******/
CREATE DATABASE [sistema_consultas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sistema_consultas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\sistema_consultas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'sistema_consultas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\sistema_consultas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [sistema_consultas] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sistema_consultas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sistema_consultas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sistema_consultas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sistema_consultas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sistema_consultas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sistema_consultas] SET ARITHABORT OFF 
GO
ALTER DATABASE [sistema_consultas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sistema_consultas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sistema_consultas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sistema_consultas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sistema_consultas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sistema_consultas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sistema_consultas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sistema_consultas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sistema_consultas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sistema_consultas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sistema_consultas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sistema_consultas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sistema_consultas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sistema_consultas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sistema_consultas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sistema_consultas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sistema_consultas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sistema_consultas] SET RECOVERY FULL 
GO
ALTER DATABASE [sistema_consultas] SET  MULTI_USER 
GO
ALTER DATABASE [sistema_consultas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sistema_consultas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sistema_consultas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sistema_consultas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [sistema_consultas] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'sistema_consultas', N'ON'
GO
ALTER DATABASE [sistema_consultas] SET QUERY_STORE = OFF
GO
USE [sistema_consultas]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 21/03/2019 0:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[id_appointment] [int] NOT NULL,
	[id_schedule] [int] NOT NULL,
	[id_place] [int] NOT NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[id_appointment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Places]    Script Date: 21/03/2019 0:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Places](
	[id_place] [int] NOT NULL,
	[name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED 
(
	[id_place] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor]    Script Date: 21/03/2019 0:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor](
	[id_professor] [int] NOT NULL,
	[name] [nchar](10) NOT NULL,
	[last_name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Professor_1] PRIMARY KEY CLUSTERED 
(
	[id_professor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[professor_appointment]    Script Date: 21/03/2019 0:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[professor_appointment](
	[id_professor] [int] NOT NULL,
	[id_appointment] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor_schedule]    Script Date: 21/03/2019 0:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor_schedule](
	[id_professor] [int] NOT NULL,
	[id_schedule] [int] NOT NULL,
	[availability] [binary](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professor_thematic]    Script Date: 21/03/2019 0:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professor_thematic](
	[id_professor] [int] NOT NULL,
	[id_thematic] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 21/03/2019 0:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[id_schedule] [int] NOT NULL,
	[hour_start] [time](7) NOT NULL,
	[hour_end] [time](7) NOT NULL,
	[date] [date] NOT NULL,
	[day] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[id_schedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 21/03/2019 0:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id_student] [int] NOT NULL,
	[name] [nchar](10) NOT NULL,
	[last_name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id_student] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[students_appointment]    Script Date: 21/03/2019 0:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students_appointment](
	[id_student] [int] NOT NULL,
	[id_appointment] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subthematics]    Script Date: 21/03/2019 0:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subthematics](
	[id_subthematic] [int] NOT NULL,
	[id_thematic] [int] NOT NULL,
	[name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Subthematics] PRIMARY KEY CLUSTERED 
(
	[id_subthematic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Thematics]    Script Date: 21/03/2019 0:15:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thematics](
	[id_thematic] [int] NOT NULL,
	[name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Thematics] PRIMARY KEY CLUSTERED 
(
	[id_thematic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Places] FOREIGN KEY([id_place])
REFERENCES [dbo].[Places] ([id_place])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Places]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Schedule] FOREIGN KEY([id_schedule])
REFERENCES [dbo].[Schedule] ([id_schedule])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_Schedule]
GO
ALTER TABLE [dbo].[professor_appointment]  WITH CHECK ADD  CONSTRAINT [FK_professor_appointment_Appointment] FOREIGN KEY([id_appointment])
REFERENCES [dbo].[Appointment] ([id_appointment])
GO
ALTER TABLE [dbo].[professor_appointment] CHECK CONSTRAINT [FK_professor_appointment_Appointment]
GO
ALTER TABLE [dbo].[professor_appointment]  WITH CHECK ADD  CONSTRAINT [FK_professor_appointment_Professor] FOREIGN KEY([id_professor])
REFERENCES [dbo].[Professor] ([id_professor])
GO
ALTER TABLE [dbo].[professor_appointment] CHECK CONSTRAINT [FK_professor_appointment_Professor]
GO
ALTER TABLE [dbo].[Professor_schedule]  WITH CHECK ADD  CONSTRAINT [FK_Professor_schedule_Professor] FOREIGN KEY([id_professor])
REFERENCES [dbo].[Professor] ([id_professor])
GO
ALTER TABLE [dbo].[Professor_schedule] CHECK CONSTRAINT [FK_Professor_schedule_Professor]
GO
ALTER TABLE [dbo].[Professor_schedule]  WITH CHECK ADD  CONSTRAINT [FK_Professor_schedule_Schedule] FOREIGN KEY([id_schedule])
REFERENCES [dbo].[Schedule] ([id_schedule])
GO
ALTER TABLE [dbo].[Professor_schedule] CHECK CONSTRAINT [FK_Professor_schedule_Schedule]
GO
ALTER TABLE [dbo].[Professor_thematic]  WITH CHECK ADD  CONSTRAINT [FK_Professor_thematic_Professor] FOREIGN KEY([id_professor])
REFERENCES [dbo].[Professor] ([id_professor])
GO
ALTER TABLE [dbo].[Professor_thematic] CHECK CONSTRAINT [FK_Professor_thematic_Professor]
GO
ALTER TABLE [dbo].[Professor_thematic]  WITH CHECK ADD  CONSTRAINT [FK_Professor_thematic_Thematics] FOREIGN KEY([id_thematic])
REFERENCES [dbo].[Thematics] ([id_thematic])
GO
ALTER TABLE [dbo].[Professor_thematic] CHECK CONSTRAINT [FK_Professor_thematic_Thematics]
GO
ALTER TABLE [dbo].[students_appointment]  WITH CHECK ADD  CONSTRAINT [FK_students_appointment_Appointment] FOREIGN KEY([id_appointment])
REFERENCES [dbo].[Appointment] ([id_appointment])
GO
ALTER TABLE [dbo].[students_appointment] CHECK CONSTRAINT [FK_students_appointment_Appointment]
GO
ALTER TABLE [dbo].[students_appointment]  WITH CHECK ADD  CONSTRAINT [FK_students_appointment_Student] FOREIGN KEY([id_student])
REFERENCES [dbo].[Student] ([id_student])
GO
ALTER TABLE [dbo].[students_appointment] CHECK CONSTRAINT [FK_students_appointment_Student]
GO
ALTER TABLE [dbo].[Subthematics]  WITH CHECK ADD  CONSTRAINT [FK_Subthematics_Thematics] FOREIGN KEY([id_thematic])
REFERENCES [dbo].[Thematics] ([id_thematic])
GO
ALTER TABLE [dbo].[Subthematics] CHECK CONSTRAINT [FK_Subthematics_Thematics]
GO
USE [master]
GO
ALTER DATABASE [sistema_consultas] SET  READ_WRITE 
GO
