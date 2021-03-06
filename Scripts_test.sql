USE [master]
GO
/****** Object:  Database [registrar_test]    Script Date: 6/14/2017 11:05:27 AM ******/
CREATE DATABASE [registrar_test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'registrar', FILENAME = N'C:\Users\epicodus\registrar_test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'registrar_log', FILENAME = N'C:\Users\epicodus\registrar_test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [registrar_test] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [registrar_test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [registrar_test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [registrar_test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [registrar_test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [registrar_test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [registrar_test] SET ARITHABORT OFF 
GO
ALTER DATABASE [registrar_test] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [registrar_test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [registrar_test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [registrar_test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [registrar_test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [registrar_test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [registrar_test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [registrar_test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [registrar_test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [registrar_test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [registrar_test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [registrar_test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [registrar_test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [registrar_test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [registrar_test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [registrar_test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [registrar_test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [registrar_test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [registrar_test] SET  MULTI_USER 
GO
ALTER DATABASE [registrar_test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [registrar_test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [registrar_test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [registrar_test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [registrar_test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [registrar_test] SET QUERY_STORE = OFF
GO
USE [registrar_test]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [registrar_test]
GO
/****** Object:  Table [dbo].[courses]    Script Date: 6/14/2017 11:05:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[course_number] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[courses_students]    Script Date: 6/14/2017 11:05:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courses_students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[course_id] [int] NULL,
	[student_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[students]    Script Date: 6/14/2017 11:05:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[enrollment_date] [datetime] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[courses_students] ON 

INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (1, 2, 1)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (2, 2, 2)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (3, 4, 3)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (4, 5, 7)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (5, 7, 8)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (6, 8, 8)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (7, 10, 10)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (8, 10, 11)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (9, 12, 12)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (10, 13, 16)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (11, 15, 17)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (12, 16, 17)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (14, 18, 19)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (15, 18, 20)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (16, 20, 21)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (17, 21, 25)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (18, 23, 26)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (19, 24, 26)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (21, 26, 28)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (22, 26, 29)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (23, 28, 30)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (24, 29, 34)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (25, 31, 35)
INSERT [dbo].[courses_students] ([id], [course_id], [student_id]) VALUES (26, 32, 35)
SET IDENTITY_INSERT [dbo].[courses_students] OFF
USE [master]
GO
ALTER DATABASE [registrar_test] SET  READ_WRITE 
GO
