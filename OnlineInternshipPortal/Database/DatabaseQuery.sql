USE [master]
GO
/****** Object:  Database [OnlineInternship]    Script Date: 9/17/2021 2:06:30 PM ******/
CREATE DATABASE [OnlineInternship]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnlineInternship', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OnlineInternship.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OnlineInternship_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\OnlineInternship_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OnlineInternship] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineInternship].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineInternship] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineInternship] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineInternship] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineInternship] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineInternship] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineInternship] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OnlineInternship] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineInternship] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineInternship] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineInternship] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineInternship] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineInternship] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineInternship] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineInternship] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineInternship] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OnlineInternship] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineInternship] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineInternship] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineInternship] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineInternship] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineInternship] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [OnlineInternship] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineInternship] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OnlineInternship] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineInternship] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineInternship] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineInternship] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineInternship] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OnlineInternship] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OnlineInternship] SET QUERY_STORE = OFF
GO
USE [OnlineInternship]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[ApplicationId] [nvarchar](450) NOT NULL,
	[DateOfRegistration] [date] NOT NULL,
	[InternId] [nvarchar](450) NOT NULL,
	[InternshipId] [nvarchar](450) NOT NULL,
	[CompanyId] [nvarchar](450) NOT NULL,
	[CV_Id] [int] NOT NULL,
	[ApprovalId] [int] NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY NONCLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [nvarchar](450) NOT NULL,
	[CompanyName] [nvarchar](max) NOT NULL,
	[CompanyAddress] [nvarchar](max) NOT NULL,
	[CompanyLocation] [nvarchar](max) NOT NULL,
	[CompanyRegNo] [nvarchar](max) NOT NULL,
	[CompanyDescription] [nvarchar](max) NOT NULL,
	[Companywebsite] [nvarchar](max) NOT NULL,
	[companyVideoLink] [nvarchar](max) NOT NULL,
	[ContactNumber] [char](20) NOT NULL,
	[CompanyEmail] [nvarchar](max) NOT NULL,
	[RegionId] [int] NOT NULL,
	[SectorId] [int] NOT NULL,
	[IndustryId] [int] NOT NULL,
	[OtherIndustry] [nvarchar](256) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[DesignationId] [int] NOT NULL,
	[CompanyImageId] [int] NULL,
	[RegistrationDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY NONCLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyLogo]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyLogo](
	[CompanyImageId] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_CompanyLogo] PRIMARY KEY NONCLUSTERED 
(
	[CompanyImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CV]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CV](
	[CV_Id] [int] IDENTITY(1,1) NOT NULL,
	[Filename] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_CV] PRIMARY KEY NONCLUSTERED 
(
	[CV_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY NONCLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[GenderId] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Genders] PRIMARY KEY NONCLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guardian]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guardian](
	[GuardianId] [int] IDENTITY(1,1) NOT NULL,
	[GuardianName] [nvarchar](max) NOT NULL,
	[ContactNumber] [char](20) NOT NULL,
	[Residence] [nvarchar](max) NOT NULL,
	[GuardianCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Guardian] PRIMARY KEY NONCLUSTERED 
(
	[GuardianId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuardianCategory]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuardianCategory](
	[GuardianCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_GuardianCategory] PRIMARY KEY NONCLUSTERED 
(
	[GuardianCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hired]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hired](
	[HireId] [int] IDENTITY(1,1) NOT NULL,
	[HireDate] [date] NOT NULL,
	[InternId] [nvarchar](450) NOT NULL,
	[CompanyId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Hired] PRIMARY KEY NONCLUSTERED 
(
	[HireId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Industry]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Industry](
	[IndustryId] [int] IDENTITY(1,1) NOT NULL,
	[industryName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Industry] PRIMARY KEY NONCLUSTERED 
(
	[IndustryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interns]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interns](
	[InternId] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[BirthDate] [date] NULL,
	[GenderId] [int] NOT NULL,
	[HomeTown] [nvarchar](max) NOT NULL,
	[RegionId] [int] NOT NULL,
	[Residence] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[ContactNumber] [char](20) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[SchoolId] [int] NOT NULL,
	[Student_Id_Card_Number] [nvarchar](256) NOT NULL,
	[Course] [nvarchar](256) NOT NULL,
	[GuardianId] [int] NOT NULL,
	[Photo] [nvarchar](256) NOT NULL,
	[CV_Id] [int] NOT NULL,
	[RegistrationDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Interns] PRIMARY KEY NONCLUSTERED 
(
	[InternId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Internship]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Internship](
	[InternshipId] [nvarchar](450) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Location] [nvarchar](max) NOT NULL,
	[Duration] [nvarchar](256) NOT NULL,
	[WorkDescription] [nvarchar](max) NOT NULL,
	[SkillsRequired] [nvarchar](max) NOT NULL,
	[Additional_Info] [nvarchar](max) NOT NULL,
	[DeadLineDate] [date] NOT NULL,
	[WhoCanApply] [nvarchar](max) NOT NULL,
	[PostedDate] [date] NOT NULL,
	[PostedTime] [nvarchar](20) NULL,
	[InternshipStatusId] [int] NOT NULL,
	[RemoteId] [int] NOT NULL,
	[CompanyImageId] [int] NULL,
	[PublicizeId] [int] NOT NULL,
	[IndustryId] [int] NOT NULL,
	[CompanyId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Internship] PRIMARY KEY NONCLUSTERED 
(
	[InternshipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InternshipApproval]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InternshipApproval](
	[ApprovalId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_InternshipApproval] PRIMARY KEY NONCLUSTERED 
(
	[ApprovalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InternshipStatus]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InternshipStatus](
	[InternshipStatusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_InternshipStatus] PRIMARY KEY NONCLUSTERED 
(
	[InternshipStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgReadStatus]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgReadStatus](
	[MsgReadStatusId] [int] IDENTITY(1,1) NOT NULL,
	[MsgReadStatusName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_MsgReadStatus] PRIMARY KEY NONCLUSTERED 
(
	[MsgReadStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publicize]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publicize](
	[PublicizeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Publicize] PRIMARY KEY NONCLUSTERED 
(
	[PublicizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecievedMsgFromCompany]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecievedMsgFromCompany](
	[RecieveId] [nvarchar](450) NOT NULL,
	[subject] [nvarchar](256) NOT NULL,
	[Messagebody] [nvarchar](max) NOT NULL,
	[Attachments] [nvarchar](256) NOT NULL,
	[FileType] [nvarchar](256) NOT NULL,
	[Extension] [nvarchar](256) NOT NULL,
	[FilePath] [nvarchar](256) NOT NULL,
	[ReceivedDate] [date] NOT NULL,
	[ReceivedTime] [nvarchar](20) NULL,
	[CompanyId] [nvarchar](450) NOT NULL,
	[ReceivedStatusId] [int] NOT NULL,
	[MsgReadStatusId] [int] NOT NULL,
	[InternId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_RecievedMsgFromCompany] PRIMARY KEY NONCLUSTERED 
(
	[RecieveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecievedStatus]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecievedStatus](
	[ReceivedStatusId] [int] IDENTITY(1,1) NOT NULL,
	[ReceiveStatusName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_RecievedStatus] PRIMARY KEY NONCLUSTERED 
(
	[ReceivedStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[RegionId] [int] IDENTITY(1,1) NOT NULL,
	[RegionName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY NONCLUSTERED 
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Remote]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Remote](
	[RemoteId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Remote] PRIMARY KEY NONCLUSTERED 
(
	[RemoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School](
	[SchoolId] [int] IDENTITY(1,1) NOT NULL,
	[SchoolName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_School] PRIMARY KEY NONCLUSTERED 
(
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sector]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sector](
	[SectorId] [int] IDENTITY(1,1) NOT NULL,
	[SectorName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Sector] PRIMARY KEY NONCLUSTERED 
(
	[SectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SentMsgToHiredInterns]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SentMsgToHiredInterns](
	[SentId] [nvarchar](450) NOT NULL,
	[subject] [nvarchar](256) NOT NULL,
	[Messagebody] [nvarchar](max) NOT NULL,
	[Attachments] [nvarchar](max) NULL,
	[FileType] [nvarchar](256) NOT NULL,
	[Extension] [nvarchar](256) NOT NULL,
	[FilePath] [nvarchar](256) NOT NULL,
	[SentDate] [date] NOT NULL,
	[SentTime] [nvarchar](20) NULL,
	[CompanyId] [nvarchar](450) NOT NULL,
	[SentStatusId] [int] NOT NULL,
	[InternId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_SentMsgToHiredInterns] PRIMARY KEY NONCLUSTERED 
(
	[SentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SentStatus]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SentStatus](
	[SentStatusId] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_SentStatus] PRIMARY KEY NONCLUSTERED 
(
	[SentStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY NONCLUSTERED 
(
	[LoginProvider] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY NONCLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[BirthDate] [datetime2](7) NULL,
	[GenderId] [int] NOT NULL,
	[HomeTown] [nvarchar](max) NULL,
	[RegionId] [int] NOT NULL,
	[Residence] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[ProfilePic] [varbinary](max) NULL,
	[RegistrationDate] [datetime2](7) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY NONCLUSTERED 
(
	[LoginProvider] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[verifyCategory]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[verifyCategory](
	[VerifyCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[VerifyName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_verifyCategory] PRIMARY KEY NONCLUSTERED 
(
	[VerifyCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VerifyCompany]    Script Date: 9/17/2021 2:06:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VerifyCompany](
	[CompanyId] [nvarchar](450) NOT NULL,
	[VerifyCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_VerifyCompany] PRIMARY KEY NONCLUSTERED 
(
	[CompanyId] ASC,
	[VerifyCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Application_ApprovalId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Application_ApprovalId] ON [dbo].[Application]
(
	[ApprovalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Application_CompanyId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Application_CompanyId] ON [dbo].[Application]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Application_CV_Id]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Application_CV_Id] ON [dbo].[Application]
(
	[CV_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Application_InternId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Application_InternId] ON [dbo].[Application]
(
	[InternId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Application_InternshipId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Application_InternshipId] ON [dbo].[Application]
(
	[InternshipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Company_CompanyImageId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Company_CompanyImageId] ON [dbo].[Company]
(
	[CompanyImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Company_DesignationId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Company_DesignationId] ON [dbo].[Company]
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Company_IndustryId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Company_IndustryId] ON [dbo].[Company]
(
	[IndustryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Company_RegionId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Company_RegionId] ON [dbo].[Company]
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Company_SectorId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Company_SectorId] ON [dbo].[Company]
(
	[SectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Company_UserId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Company_UserId] ON [dbo].[Company]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Guardian_GuardianCategoryId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Guardian_GuardianCategoryId] ON [dbo].[Guardian]
(
	[GuardianCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Hired_CompanyId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Hired_CompanyId] ON [dbo].[Hired]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Hired_InternId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Hired_InternId] ON [dbo].[Hired]
(
	[InternId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interns_CV_Id]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Interns_CV_Id] ON [dbo].[Interns]
(
	[CV_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interns_GenderId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Interns_GenderId] ON [dbo].[Interns]
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interns_GuardianId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Interns_GuardianId] ON [dbo].[Interns]
(
	[GuardianId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interns_RegionId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Interns_RegionId] ON [dbo].[Interns]
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Interns_SchoolId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Interns_SchoolId] ON [dbo].[Interns]
(
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Internship_CompanyId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Internship_CompanyId] ON [dbo].[Internship]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Internship_CompanyImageId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Internship_CompanyImageId] ON [dbo].[Internship]
(
	[CompanyImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Internship_IndustryId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Internship_IndustryId] ON [dbo].[Internship]
(
	[IndustryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Internship_InternshipStatusId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Internship_InternshipStatusId] ON [dbo].[Internship]
(
	[InternshipStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Internship_PublicizeId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Internship_PublicizeId] ON [dbo].[Internship]
(
	[PublicizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Internship_RemoteId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Internship_RemoteId] ON [dbo].[Internship]
(
	[RemoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RecievedMsgFromCompany_CompanyId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_RecievedMsgFromCompany_CompanyId] ON [dbo].[RecievedMsgFromCompany]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RecievedMsgFromCompany_InternId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_RecievedMsgFromCompany_InternId] ON [dbo].[RecievedMsgFromCompany]
(
	[InternId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecievedMsgFromCompany_MsgReadStatusId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_RecievedMsgFromCompany_MsgReadStatusId] ON [dbo].[RecievedMsgFromCompany]
(
	[MsgReadStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecievedMsgFromCompany_ReceivedStatusId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_RecievedMsgFromCompany_ReceivedStatusId] ON [dbo].[RecievedMsgFromCompany]
(
	[ReceivedStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[Role]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [dbo].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SentMsgToHiredInterns_CompanyId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_SentMsgToHiredInterns_CompanyId] ON [dbo].[SentMsgToHiredInterns]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SentMsgToHiredInterns_InternId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_SentMsgToHiredInterns_InternId] ON [dbo].[SentMsgToHiredInterns]
(
	[InternId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SentMsgToHiredInterns_SentStatusId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_SentMsgToHiredInterns_SentStatusId] ON [dbo].[SentMsgToHiredInterns]
(
	[SentStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [dbo].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [dbo].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_UserId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_UserId] ON [dbo].[UserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_GenderId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_GenderId] ON [dbo].[Users]
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RegionId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_RegionId] ON [dbo].[Users]
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[Users]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserTokens_UserId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserTokens_UserId] ON [dbo].[UserTokens]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VerifyCompany_VerifyCategoryId]    Script Date: 9/17/2021 2:06:31 PM ******/
CREATE NONCLUSTERED INDEX [IX_VerifyCompany_VerifyCategoryId] ON [dbo].[VerifyCompany]
(
	[VerifyCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Company_Application] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Company_Application]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_CV_Application] FOREIGN KEY([CV_Id])
REFERENCES [dbo].[CV] ([CV_Id])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_CV_Application]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Interns_Application] FOREIGN KEY([InternId])
REFERENCES [dbo].[Interns] ([InternId])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Interns_Application]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Internship_Application] FOREIGN KEY([InternshipId])
REFERENCES [dbo].[Internship] ([InternshipId])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Internship_Application]
GO
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_InternshipApproval_Application] FOREIGN KEY([ApprovalId])
REFERENCES [dbo].[InternshipApproval] ([ApprovalId])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_InternshipApproval_Application]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Users_UserId]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_CompanyLogo_Company] FOREIGN KEY([CompanyImageId])
REFERENCES [dbo].[CompanyLogo] ([CompanyImageId])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_CompanyLogo_Company]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Designation_Company] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([DesignationId])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Designation_Company]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Industry_Company] FOREIGN KEY([IndustryId])
REFERENCES [dbo].[Industry] ([IndustryId])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Industry_Company]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Region_Company] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Region] ([RegionId])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Region_Company]
GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Sector_Company] FOREIGN KEY([SectorId])
REFERENCES [dbo].[Sector] ([SectorId])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Sector_Company]
GO
ALTER TABLE [dbo].[Guardian]  WITH CHECK ADD  CONSTRAINT [FK_GuardianCategory_Guardian] FOREIGN KEY([GuardianCategoryId])
REFERENCES [dbo].[GuardianCategory] ([GuardianCategoryId])
GO
ALTER TABLE [dbo].[Guardian] CHECK CONSTRAINT [FK_GuardianCategory_Guardian]
GO
ALTER TABLE [dbo].[Hired]  WITH CHECK ADD  CONSTRAINT [FK_Company_Hired] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[Hired] CHECK CONSTRAINT [FK_Company_Hired]
GO
ALTER TABLE [dbo].[Hired]  WITH CHECK ADD  CONSTRAINT [FK_Interns_Hired] FOREIGN KEY([InternId])
REFERENCES [dbo].[Interns] ([InternId])
GO
ALTER TABLE [dbo].[Hired] CHECK CONSTRAINT [FK_Interns_Hired]
GO
ALTER TABLE [dbo].[Interns]  WITH CHECK ADD  CONSTRAINT [FK_CV_Interns] FOREIGN KEY([CV_Id])
REFERENCES [dbo].[CV] ([CV_Id])
GO
ALTER TABLE [dbo].[Interns] CHECK CONSTRAINT [FK_CV_Interns]
GO
ALTER TABLE [dbo].[Interns]  WITH CHECK ADD  CONSTRAINT [FK_Genders_Interns] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([GenderId])
GO
ALTER TABLE [dbo].[Interns] CHECK CONSTRAINT [FK_Genders_Interns]
GO
ALTER TABLE [dbo].[Interns]  WITH CHECK ADD  CONSTRAINT [FK_Guardian_Interns] FOREIGN KEY([GuardianId])
REFERENCES [dbo].[Guardian] ([GuardianId])
GO
ALTER TABLE [dbo].[Interns] CHECK CONSTRAINT [FK_Guardian_Interns]
GO
ALTER TABLE [dbo].[Interns]  WITH CHECK ADD  CONSTRAINT [FK_Region_Inte15] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Region] ([RegionId])
GO
ALTER TABLE [dbo].[Interns] CHECK CONSTRAINT [FK_Region_Inte15]
GO
ALTER TABLE [dbo].[Interns]  WITH CHECK ADD  CONSTRAINT [FK_School_Interns] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([SchoolId])
GO
ALTER TABLE [dbo].[Interns] CHECK CONSTRAINT [FK_School_Interns]
GO
ALTER TABLE [dbo].[Internship]  WITH CHECK ADD  CONSTRAINT [FK_Company_Internship] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[Internship] CHECK CONSTRAINT [FK_Company_Internship]
GO
ALTER TABLE [dbo].[Internship]  WITH CHECK ADD  CONSTRAINT [FK_CompanyLogo_Internship] FOREIGN KEY([CompanyImageId])
REFERENCES [dbo].[CompanyLogo] ([CompanyImageId])
GO
ALTER TABLE [dbo].[Internship] CHECK CONSTRAINT [FK_CompanyLogo_Internship]
GO
ALTER TABLE [dbo].[Internship]  WITH CHECK ADD  CONSTRAINT [FK_Industry_Internship] FOREIGN KEY([IndustryId])
REFERENCES [dbo].[Industry] ([IndustryId])
GO
ALTER TABLE [dbo].[Internship] CHECK CONSTRAINT [FK_Industry_Internship]
GO
ALTER TABLE [dbo].[Internship]  WITH CHECK ADD  CONSTRAINT [FK_InternshipStatus_Internship] FOREIGN KEY([InternshipStatusId])
REFERENCES [dbo].[InternshipStatus] ([InternshipStatusId])
GO
ALTER TABLE [dbo].[Internship] CHECK CONSTRAINT [FK_InternshipStatus_Internship]
GO
ALTER TABLE [dbo].[Internship]  WITH CHECK ADD  CONSTRAINT [FK_Publicize_Internship] FOREIGN KEY([PublicizeId])
REFERENCES [dbo].[Publicize] ([PublicizeId])
GO
ALTER TABLE [dbo].[Internship] CHECK CONSTRAINT [FK_Publicize_Internship]
GO
ALTER TABLE [dbo].[Internship]  WITH CHECK ADD  CONSTRAINT [FK_Remote_Internship] FOREIGN KEY([RemoteId])
REFERENCES [dbo].[Remote] ([RemoteId])
GO
ALTER TABLE [dbo].[Internship] CHECK CONSTRAINT [FK_Remote_Internship]
GO
ALTER TABLE [dbo].[RecievedMsgFromCompany]  WITH CHECK ADD  CONSTRAINT [FK_Company_RecievedMsgFromCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[RecievedMsgFromCompany] CHECK CONSTRAINT [FK_Company_RecievedMsgFromCompany]
GO
ALTER TABLE [dbo].[RecievedMsgFromCompany]  WITH CHECK ADD  CONSTRAINT [FK_Interns_RecievedMsgFromCompany] FOREIGN KEY([InternId])
REFERENCES [dbo].[Interns] ([InternId])
GO
ALTER TABLE [dbo].[RecievedMsgFromCompany] CHECK CONSTRAINT [FK_Interns_RecievedMsgFromCompany]
GO
ALTER TABLE [dbo].[RecievedMsgFromCompany]  WITH CHECK ADD  CONSTRAINT [FK_MsgReadStatus_RecievedMsgFromCompany] FOREIGN KEY([MsgReadStatusId])
REFERENCES [dbo].[MsgReadStatus] ([MsgReadStatusId])
GO
ALTER TABLE [dbo].[RecievedMsgFromCompany] CHECK CONSTRAINT [FK_MsgReadStatus_RecievedMsgFromCompany]
GO
ALTER TABLE [dbo].[RecievedMsgFromCompany]  WITH CHECK ADD  CONSTRAINT [FK_RecievedStatus_RecievedMsgFromCompany] FOREIGN KEY([ReceivedStatusId])
REFERENCES [dbo].[RecievedStatus] ([ReceivedStatusId])
GO
ALTER TABLE [dbo].[RecievedMsgFromCompany] CHECK CONSTRAINT [FK_RecievedStatus_RecievedMsgFromCompany]
GO
ALTER TABLE [dbo].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Role_RoleId]
GO
ALTER TABLE [dbo].[SentMsgToHiredInterns]  WITH CHECK ADD  CONSTRAINT [FK_Company_SentMsgToHiredInterns] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[SentMsgToHiredInterns] CHECK CONSTRAINT [FK_Company_SentMsgToHiredInterns]
GO
ALTER TABLE [dbo].[SentMsgToHiredInterns]  WITH CHECK ADD  CONSTRAINT [FK_Interns_SentMsgToHiredInterns] FOREIGN KEY([InternId])
REFERENCES [dbo].[Interns] ([InternId])
GO
ALTER TABLE [dbo].[SentMsgToHiredInterns] CHECK CONSTRAINT [FK_Interns_SentMsgToHiredInterns]
GO
ALTER TABLE [dbo].[SentMsgToHiredInterns]  WITH CHECK ADD  CONSTRAINT [FK_SentStatus_SentMsgToHiredInterns] FOREIGN KEY([SentStatusId])
REFERENCES [dbo].[SentStatus] ([SentStatusId])
GO
ALTER TABLE [dbo].[SentMsgToHiredInterns] CHECK CONSTRAINT [FK_SentStatus_SentMsgToHiredInterns]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Role_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Gender_GenderId] FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([GenderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Gender_GenderId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Region_RegionId] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Region] ([RegionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Region_RegionId]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
ALTER TABLE [dbo].[VerifyCompany]  WITH CHECK ADD  CONSTRAINT [FK_Company_VerifyCompany] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([CompanyId])
GO
ALTER TABLE [dbo].[VerifyCompany] CHECK CONSTRAINT [FK_Company_VerifyCompany]
GO
ALTER TABLE [dbo].[VerifyCompany]  WITH CHECK ADD  CONSTRAINT [FK_verifyCategory_VerifyCompany] FOREIGN KEY([VerifyCategoryId])
REFERENCES [dbo].[verifyCategory] ([VerifyCategoryId])
GO
ALTER TABLE [dbo].[VerifyCompany] CHECK CONSTRAINT [FK_verifyCategory_VerifyCompany]
GO
USE [master]
GO
ALTER DATABASE [OnlineInternship] SET  READ_WRITE 
GO
