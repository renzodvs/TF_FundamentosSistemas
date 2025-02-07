USE [master]
GO
/****** Object:  Database [dbTrabajoFinalFundamentos]    Script Date: 18/11/2017 1:32:08 p. m. ******/
CREATE DATABASE [dbTrabajoFinalFundamentos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbTrabajoFinalFundamentos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\dbTrabajoFinalFundamentos.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbTrabajoFinalFundamentos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\dbTrabajoFinalFundamentos_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbTrabajoFinalFundamentos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET  MULTI_USER 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET DELAYED_DURABILITY = DISABLED 
GO
USE [dbTrabajoFinalFundamentos]
GO
/****** Object:  Table [dbo].[CV]    Script Date: 18/11/2017 1:32:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CV](
	[Oficio] [varchar](50) NULL,
	[AñosDeExperiencia] [int] NULL,
	[NumeroTrabajosAnteriores] [int] NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CV] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 18/11/2017 1:32:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empresa](
	[Nombre] [varchar](50) NULL,
	[IDEmpresa] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[IDEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 18/11/2017 1:32:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[Nombre] [varchar](50) NULL,
	[Edad] [int] NULL,
	[Direccion] [varchar](50) NULL,
	[IDTrabajo] [int] NULL,
	[IDPersona] [int] IDENTITY(1,1) NOT NULL,
	[Aceptado] [int] NOT NULL CONSTRAINT [DF_Persona_Aceptado]  DEFAULT ((0)),
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[IDPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Trabajo]    Script Date: 18/11/2017 1:32:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Trabajo](
	[Area] [varchar](50) NULL,
	[AñosDeExperiencia] [int] NULL,
	[Sueldo] [money] NULL,
	[LugarEmpleo] [varchar](50) NULL,
	[NumeroVacantes] [int] NULL,
	[IDtrabajo] [int] IDENTITY(1,1) NOT NULL,
	[IDempresa] [int] NULL,
 CONSTRAINT [PK_Trabajo] PRIMARY KEY CLUSTERED 
(
	[IDtrabajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_CV] FOREIGN KEY([Nombre])
REFERENCES [dbo].[CV] ([Nombre])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_CV]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Trabajo] FOREIGN KEY([IDTrabajo])
REFERENCES [dbo].[Trabajo] ([IDtrabajo])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Trabajo]
GO
ALTER TABLE [dbo].[Trabajo]  WITH CHECK ADD  CONSTRAINT [FK_Trabajo_Empresa] FOREIGN KEY([IDempresa])
REFERENCES [dbo].[Empresa] ([IDEmpresa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Trabajo] CHECK CONSTRAINT [FK_Trabajo_Empresa]
GO
USE [master]
GO
ALTER DATABASE [dbTrabajoFinalFundamentos] SET  READ_WRITE 
GO
