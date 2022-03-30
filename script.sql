USE [master]
GO
/****** Object:  Database [Garderie]    Script Date: 30/03/2022 08:09:11 ******/
CREATE DATABASE [Garderie]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Garderie', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Garderie.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Garderie_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Garderie_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Garderie] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Garderie].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Garderie] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Garderie] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Garderie] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Garderie] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Garderie] SET ARITHABORT OFF 
GO
ALTER DATABASE [Garderie] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Garderie] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Garderie] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Garderie] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Garderie] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Garderie] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Garderie] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Garderie] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Garderie] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Garderie] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Garderie] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Garderie] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Garderie] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Garderie] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Garderie] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Garderie] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Garderie] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Garderie] SET RECOVERY FULL 
GO
ALTER DATABASE [Garderie] SET  MULTI_USER 
GO
ALTER DATABASE [Garderie] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Garderie] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Garderie] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Garderie] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Garderie] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Garderie] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Garderie', N'ON'
GO
ALTER DATABASE [Garderie] SET QUERY_STORE = OFF
GO
USE [Garderie]
GO
/****** Object:  Table [dbo].[T_Garderies]    Script Date: 30/03/2022 08:09:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Garderies](
	[idCaserne] [int] NOT NULL,
	[Nom] [varchar](100) NULL,
	[Adresse] [varchar](200) NULL,
	[Ville] [varchar](100) NULL,
	[Province] [varchar](50) NULL,
	[Telephone] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCaserne] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Garderie] SET  READ_WRITE 
GO
