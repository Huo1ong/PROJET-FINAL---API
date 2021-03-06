USE [master]
GO
/****** Object:  Database [Garderie]    Script Date: 26/05/2022 10:07:22 ******/
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
/****** Object:  Table [dbo].[T_CategoriesDepense]    Script Date: 26/05/2022 10:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_CategoriesDepense](
	[idCategorieDepense] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](100) NOT NULL,
	[pourcentage] [float] NULL,
 CONSTRAINT [PK_idCategorieDepense] PRIMARY KEY CLUSTERED 
(
	[idCategorieDepense] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Commerces]    Script Date: 26/05/2022 10:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Commerces](
	[idCommerce] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NOT NULL,
	[adresse] [varchar](200) NOT NULL,
	[telephone] [varchar](12) NOT NULL,
 CONSTRAINT [PK_idCommerce] PRIMARY KEY CLUSTERED 
(
	[idCommerce] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Depenses]    Script Date: 26/05/2022 10:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Depenses](
	[idDepense] [int] IDENTITY(1,1) NOT NULL,
	[dateTemps] [datetime] NOT NULL,
	[Montant] [money] NULL,
	[idGarderie] [int] NULL,
	[idCategorieDepense] [int] NULL,
	[idCommerce] [int] NULL,
 CONSTRAINT [PK_idDepense] PRIMARY KEY CLUSTERED 
(
	[idDepense] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Educateurs]    Script Date: 26/05/2022 10:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Educateurs](
	[idEducateur] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](100) NULL,
	[prenom] [varchar](100) NULL,
	[dateNaissance] [datetime] NULL,
	[adresse] [varchar](200) NULL,
	[ville] [varchar](100) NULL,
	[province] [varchar](50) NULL,
	[telephone] [varchar](12) NULL,
 CONSTRAINT [PK_idEducateur] PRIMARY KEY CLUSTERED 
(
	[idEducateur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Enfants]    Script Date: 26/05/2022 10:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Enfants](
	[idEnfant] [int] IDENTITY(1,1) NOT NULL,
	[nom] [varchar](100) NULL,
	[prenom] [varchar](100) NULL,
	[dateNaissance] [datetime] NULL,
	[adresse] [varchar](200) NULL,
	[ville] [varchar](100) NULL,
	[province] [varchar](50) NULL,
	[telephone] [varchar](12) NULL,
 CONSTRAINT [PK_idEnfant] PRIMARY KEY CLUSTERED 
(
	[idEnfant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Garderies]    Script Date: 26/05/2022 10:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Garderies](
	[idGarderie] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](100) NULL,
	[Adresse] [varchar](200) NULL,
	[Ville] [varchar](100) NULL,
	[Province] [varchar](50) NULL,
	[Telephone] [varchar](12) NULL,
 CONSTRAINT [PK__T_Garder__709C5C8A195CD0F4] PRIMARY KEY CLUSTERED 
(
	[idGarderie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Presences]    Script Date: 26/05/2022 10:07:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Presences](
	[date] [datetime] NOT NULL,
	[idGarderie] [int] NOT NULL,
	[idEnfant] [int] NOT NULL,
	[idEducateur] [int] NULL,
 CONSTRAINT [PK_idPresence] PRIMARY KEY CLUSTERED 
(
	[date] ASC,
	[idGarderie] ASC,
	[idEnfant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IndexUniqueNom]    Script Date: 26/05/2022 10:07:22 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IndexUniqueNom] ON [dbo].[T_Garderies]
(
	[Nom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_Depenses]  WITH CHECK ADD  CONSTRAINT [FK_idCategorieDepense] FOREIGN KEY([idCategorieDepense])
REFERENCES [dbo].[T_CategoriesDepense] ([idCategorieDepense])
GO
ALTER TABLE [dbo].[T_Depenses] CHECK CONSTRAINT [FK_idCategorieDepense]
GO
ALTER TABLE [dbo].[T_Depenses]  WITH CHECK ADD  CONSTRAINT [FK_idCommerce] FOREIGN KEY([idCommerce])
REFERENCES [dbo].[T_Commerces] ([idCommerce])
GO
ALTER TABLE [dbo].[T_Depenses] CHECK CONSTRAINT [FK_idCommerce]
GO
ALTER TABLE [dbo].[T_Depenses]  WITH CHECK ADD  CONSTRAINT [FK_idGarderie] FOREIGN KEY([idGarderie])
REFERENCES [dbo].[T_Garderies] ([idGarderie])
GO
ALTER TABLE [dbo].[T_Depenses] CHECK CONSTRAINT [FK_idGarderie]
GO
ALTER TABLE [dbo].[T_Presences]  WITH CHECK ADD  CONSTRAINT [FK_idEducateur ] FOREIGN KEY([idEducateur])
REFERENCES [dbo].[T_Educateurs] ([idEducateur])
GO
ALTER TABLE [dbo].[T_Presences] CHECK CONSTRAINT [FK_idEducateur ]
GO
ALTER TABLE [dbo].[T_Presences]  WITH CHECK ADD  CONSTRAINT [FK_idEnfant] FOREIGN KEY([idEnfant])
REFERENCES [dbo].[T_Enfants] ([idEnfant])
GO
ALTER TABLE [dbo].[T_Presences] CHECK CONSTRAINT [FK_idEnfant]
GO
ALTER TABLE [dbo].[T_Presences]  WITH CHECK ADD  CONSTRAINT [FK_idGarderie2] FOREIGN KEY([idGarderie])
REFERENCES [dbo].[T_Garderies] ([idGarderie])
GO
ALTER TABLE [dbo].[T_Presences] CHECK CONSTRAINT [FK_idGarderie2]
GO
USE [master]
GO
ALTER DATABASE [Garderie] SET  READ_WRITE 
GO
