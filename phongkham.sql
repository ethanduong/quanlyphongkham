USE [master]
GO
/****** Object:  Database [phongkham]    Script Date: 4/15/2017 9:27:58 AM ******/
CREATE DATABASE [phongkham]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'phongkham', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.LOCAL\MSSQL\DATA\phongkham.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'phongkham_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.LOCAL\MSSQL\DATA\phongkham_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [phongkham] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [phongkham].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [phongkham] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [phongkham] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [phongkham] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [phongkham] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [phongkham] SET ARITHABORT OFF 
GO
ALTER DATABASE [phongkham] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [phongkham] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [phongkham] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [phongkham] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [phongkham] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [phongkham] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [phongkham] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [phongkham] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [phongkham] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [phongkham] SET  DISABLE_BROKER 
GO
ALTER DATABASE [phongkham] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [phongkham] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [phongkham] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [phongkham] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [phongkham] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [phongkham] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [phongkham] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [phongkham] SET RECOVERY FULL 
GO
ALTER DATABASE [phongkham] SET  MULTI_USER 
GO
ALTER DATABASE [phongkham] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [phongkham] SET DB_CHAINING OFF 
GO
ALTER DATABASE [phongkham] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [phongkham] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [phongkham] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'phongkham', N'ON'
GO
ALTER DATABASE [phongkham] SET QUERY_STORE = OFF
GO
USE [phongkham]
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
USE [phongkham]
GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[MACV] [int] IDENTITY(1,1) NOT NULL,
	[TEN] [nvarchar](100) NULL,
 CONSTRAINT [PK_NGHENGHIEP] PRIMARY KEY CLUSTERED 
(
	[MACV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [int] IDENTITY(1,1) NOT NULL,
	[HOTEN] [nvarchar](100) NULL,
	[NGAYSINH] [date] NULL,
	[GIOITINH] [bit] NULL,
	[DIENTHOAI] [nvarchar](15) NULL,
	[MACV] [int] NULL,
	[MAPB] [int] NULL,
	[URL_IMAGE] [nvarchar](500) NULL,
	[FILE_NAME] [nvarchar](500) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHONGBAN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONGBAN](
	[MAPB] [int] IDENTITY(1,1) NOT NULL,
	[TENPHONG] [nvarchar](100) NULL,
 CONSTRAINT [PK_PHONGBAN] PRIMARY KEY CLUSTERED 
(
	[MAPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[view_NhanVien]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_NhanVien]
AS
SELECT        dbo.NHANVIEN.MANV, dbo.NHANVIEN.HOTEN, dbo.NHANVIEN.NGAYSINH, 
                         CASE dbo.NHANVIEN.GIOITINH WHEN 'TRUE' THEN N'Nam' WHEN 'FALSE' THEN N'Nữ' END AS GIOITINH, dbo.NHANVIEN.DIENTHOAI, dbo.PHONGBAN.TENPHONG, 
                         dbo.CHUCVU.TEN, dbo.NHANVIEN.URL_IMAGE, dbo.NHANVIEN.FILE_NAME
FROM            dbo.NHANVIEN INNER JOIN
                         dbo.PHONGBAN ON dbo.NHANVIEN.MAPB = dbo.PHONGBAN.MAPB INNER JOIN
                         dbo.CHUCVU ON dbo.NHANVIEN.MACV = dbo.CHUCVU.MACV


GO
/****** Object:  Table [dbo].[TT_BENHNHAN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TT_BENHNHAN](
	[MABN] [int] IDENTITY(1,1) NOT NULL,
	[HOTEN] [nvarchar](100) NULL,
	[NGAYSINH] [date] NULL,
	[GIOITINH] [bit] NULL,
	[DIENTHOAI] [nvarchar](15) NULL,
	[CHIEUCAO] [int] NULL,
	[CANNANG] [int] NULL,
	[TIENSU] [nvarchar](max) NULL,
 CONSTRAINT [PK_TT_BENHNHAN] PRIMARY KEY CLUSTERED 
(
	[MABN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[VIEW_TT_BENHNHAN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VIEW_TT_BENHNHAN]
AS
SELECT        MABN, HOTEN, NGAYSINH, CASE dbo.TT_BENHNHAN.GIOITINH WHEN 'TRUE' THEN N'Nam' WHEN 'FALSE' THEN N'Nữ' END AS GIOITINH, DIENTHOAI, CHIEUCAO, 
                         CANNANG, TIENSU
FROM            dbo.TT_BENHNHAN


GO
/****** Object:  Table [dbo].[SANPHAM_DICHVU]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM_DICHVU](
	[ID_SP] [int] IDENTITY(1,1) NOT NULL,
	[MAPB] [int] NULL,
	[TENDV] [nvarchar](200) NULL,
	[MOTA] [nvarchar](200) NULL,
 CONSTRAINT [PK_SANPHAM_DICHVU] PRIMARY KEY CLUSTERED 
(
	[ID_SP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[view_SANPHAMDICHVU]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_SANPHAMDICHVU]
AS
SELECT        dbo.SANPHAM_DICHVU.ID_SP, dbo.SANPHAM_DICHVU.TENDV, dbo.SANPHAM_DICHVU.MOTA, dbo.PHONGBAN.TENPHONG
FROM            dbo.SANPHAM_DICHVU INNER JOIN
                         dbo.PHONGBAN ON dbo.SANPHAM_DICHVU.MAPB = dbo.PHONGBAN.MAPB


GO
/****** Object:  Table [dbo].[THONGSOKYTHUAT]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THONGSOKYTHUAT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TENTHONGSO] [nvarchar](200) NULL,
	[ID_SP] [int] NULL,
 CONSTRAINT [PK_THONGSOKYTHUAT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[view_THONGSOKYTHUAT]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_THONGSOKYTHUAT]
AS
SELECT        dbo.THONGSOKYTHUAT.ID, dbo.THONGSOKYTHUAT.TENTHONGSO, dbo.SANPHAM_DICHVU.TENDV
FROM            dbo.THONGSOKYTHUAT INNER JOIN
                         dbo.SANPHAM_DICHVU ON dbo.THONGSOKYTHUAT.ID_SP = dbo.SANPHAM_DICHVU.ID_SP


GO
/****** Object:  Table [dbo].[CHISO_BENHNHAN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHISO_BENHNHAN](
	[ID_CTK] [bigint] NOT NULL,
	[ID_TS] [int] NOT NULL,
	[CHISO] [nchar](10) NULL,
 CONSTRAINT [PK_CHISO_BENHNHAN] PRIMARY KEY CLUSTERED 
(
	[ID_CTK] ASC,
	[ID_TS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHITIETKHAM]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETKHAM](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MAPHIEU] [bigint] NULL,
	[ID_SP] [int] NULL,
	[MOTA] [nvarchar](500) NULL,
	[KETLUAN] [nvarchar](500) NULL,
	[NGAYKHAM] [datetime] NULL,
	[MANV] [int] NULL,
	[URL_IMAGE] [nvarchar](500) NULL,
 CONSTRAINT [PK_CHITIETKHAM] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[ID_USER] [int] NOT NULL,
	[XEM_CHISO] [bit] NULL,
	[THEM_CHISO] [bit] NULL,
	[SUA_CHISO] [bit] NULL,
	[XOA_CHISO] [bit] NULL,
	[XEM_CHITITET] [bit] NULL,
	[THEM_CHITITET] [bit] NULL,
	[SUA_CHITITET] [bit] NULL,
	[XOA_CHITIET] [bit] NULL,
	[XEM_CHUCVU] [bit] NULL,
	[THEM_CHUCVU] [bit] NULL,
	[SUA_CHUCVU] [bit] NULL,
	[XOA_CHUCVU] [bit] NULL,
	[XEM_NHANVIEN] [bit] NULL,
	[THEM_NHANVIEN] [bit] NULL,
	[SUA_NHANVIEN] [bit] NULL,
	[XOA_NHANVIEN] [bit] NULL,
	[XEM_PHIEU] [bit] NULL,
	[THEM_PHIEU] [bit] NULL,
	[SUA_PHIEU] [bit] NULL,
	[XOA_PHIEU] [bit] NULL,
	[XEM_PHONGBAN] [bit] NULL,
	[THEM_PHONGBAN] [bit] NULL,
	[SUA_PHONGBAN] [bit] NULL,
	[XOA_PHONGBAN] [bit] NULL,
	[XEM_SANPHAM] [bit] NULL,
	[THEM_SANPHAM] [bit] NULL,
	[SUA_SANPHAM] [bit] NULL,
	[XOA_SANPHAM] [bit] NULL,
	[XEM_BENHNHAN] [bit] NULL,
	[THEM_BENHNHAN] [bit] NULL,
	[SUA_BENHNHAN] [bit] NULL,
	[XOA_BENHNHAN] [bit] NULL,
	[XEM_THONGSO] [bit] NULL,
	[THEM_THONGSO] [bit] NULL,
	[SUA_THONGSO] [bit] NULL,
	[XOA_THONGSO] [bit] NULL,
	[XEM_USER] [bit] NULL,
	[THEM_USER] [bit] NULL,
	[SUA_USER] [bit] NULL,
	[XOA_USER] [bit] NULL,
 CONSTRAINT [PK_PHANQUYEN] PRIMARY KEY CLUSTERED 
(
	[ID_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUKHAMBENH]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUKHAMBENH](
	[MAPHIEU] [bigint] IDENTITY(1,1) NOT NULL,
	[MABN] [int] NULL,
	[NGAYKHAM] [datetime] NULL,
	[LYDO] [nvarchar](500) NULL,
	[MANV] [int] NULL,
	[KETLUAN] [nvarchar](max) NULL,
	[DIEUTRI] [nvarchar](max) NULL,
	[TAIKHAM] [date] NULL,
 CONSTRAINT [PK_PHIEUKHAMBENH] PRIMARY KEY CLUSTERED 
(
	[MAPHIEU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USER]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [nvarchar](50) NULL,
	[PASS] [char](84) NULL,
	[HOTEN] [nvarchar](50) NULL,
	[ISADMIN] [bit] NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CHISO_BENHNHAN]  WITH CHECK ADD  CONSTRAINT [FK_CHISO_BENHNHAN_CHITIETKHAM] FOREIGN KEY([ID_CTK])
REFERENCES [dbo].[CHITIETKHAM] ([ID])
GO
ALTER TABLE [dbo].[CHISO_BENHNHAN] CHECK CONSTRAINT [FK_CHISO_BENHNHAN_CHITIETKHAM]
GO
ALTER TABLE [dbo].[CHISO_BENHNHAN]  WITH CHECK ADD  CONSTRAINT [FK_CHISO_BENHNHAN_THONGSOKYTHUAT] FOREIGN KEY([ID_TS])
REFERENCES [dbo].[THONGSOKYTHUAT] ([ID])
GO
ALTER TABLE [dbo].[CHISO_BENHNHAN] CHECK CONSTRAINT [FK_CHISO_BENHNHAN_THONGSOKYTHUAT]
GO
ALTER TABLE [dbo].[CHITIETKHAM]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETKHAM_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[CHITIETKHAM] CHECK CONSTRAINT [FK_CHITIETKHAM_NHANVIEN]
GO
ALTER TABLE [dbo].[CHITIETKHAM]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETKHAM_PHIEUKHAMBENH] FOREIGN KEY([MAPHIEU])
REFERENCES [dbo].[PHIEUKHAMBENH] ([MAPHIEU])
GO
ALTER TABLE [dbo].[CHITIETKHAM] CHECK CONSTRAINT [FK_CHITIETKHAM_PHIEUKHAMBENH]
GO
ALTER TABLE [dbo].[CHITIETKHAM]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETKHAM_SANPHAM_DICHVU] FOREIGN KEY([ID_SP])
REFERENCES [dbo].[SANPHAM_DICHVU] ([ID_SP])
GO
ALTER TABLE [dbo].[CHITIETKHAM] CHECK CONSTRAINT [FK_CHITIETKHAM_SANPHAM_DICHVU]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_NGHENGHIEP] FOREIGN KEY([MACV])
REFERENCES [dbo].[CHUCVU] ([MACV])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_NGHENGHIEP]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_PHONGBAN] FOREIGN KEY([MAPB])
REFERENCES [dbo].[PHONGBAN] ([MAPB])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_PHONGBAN]
GO
ALTER TABLE [dbo].[PHIEUKHAMBENH]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUKHAMBENH_NHANVIEN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[PHIEUKHAMBENH] CHECK CONSTRAINT [FK_PHIEUKHAMBENH_NHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUKHAMBENH]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUKHAMBENH_TT_BENHNHAN] FOREIGN KEY([MABN])
REFERENCES [dbo].[TT_BENHNHAN] ([MABN])
GO
ALTER TABLE [dbo].[PHIEUKHAMBENH] CHECK CONSTRAINT [FK_PHIEUKHAMBENH_TT_BENHNHAN]
GO
ALTER TABLE [dbo].[SANPHAM_DICHVU]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_DICHVU_PHONGBAN] FOREIGN KEY([MAPB])
REFERENCES [dbo].[PHONGBAN] ([MAPB])
GO
ALTER TABLE [dbo].[SANPHAM_DICHVU] CHECK CONSTRAINT [FK_SANPHAM_DICHVU_PHONGBAN]
GO
ALTER TABLE [dbo].[THONGSOKYTHUAT]  WITH CHECK ADD  CONSTRAINT [FK_THONGSOKYTHUAT_SANPHAM_DICHVU] FOREIGN KEY([ID_SP])
REFERENCES [dbo].[SANPHAM_DICHVU] ([ID_SP])
GO
ALTER TABLE [dbo].[THONGSOKYTHUAT] CHECK CONSTRAINT [FK_THONGSOKYTHUAT_SANPHAM_DICHVU]
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_CHISOBENHNHAN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table NhanVien>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_CHISOBENHNHAN]
(
 @ID_CTK bigint
,@ID_TS  int
,@CHISO  nvarchar(200)

)
AS
BEGIN

 INSERT INTO dbo.CHISO_BENHNHAN
 ( 
 ID_CTK
,ID_TS
,CHISO
)
 VALUES
 (
 @ID_CTK
,@ID_TS
,@CHISO
)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_CHITIETKHAM]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table CHITIETKHAM>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_CHITIETKHAM]
( 
 @MAPHIEU  bigint
,@ID_SP  int
,@MOTA  nvarchar(500)
,@KETLUAN nvarchar(500)
,@NGAYKHAM datetime
,@MANV int
,@URL_IMAGE nvarchar(500)
)
AS
BEGIN

 INSERT INTO dbo.CHITIETKHAM
 ( 
 MAPHIEU
,ID_SP
,MOTA
,KETLUAN
,NGAYKHAM
,MANV
,URL_IMAGE
)
 VALUES
 (
 @MAPHIEU
,@ID_SP  
,@MOTA  
,@KETLUAN 
,@NGAYKHAM 
,@MANV 
,@URL_IMAGE 
)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_CHUCVU]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table CHUCVU>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_CHUCVU]
( 
@TEN nvarchar(100)
)
AS
BEGIN

 INSERT INTO dbo.CHUCVU
 ( 
 TEN
)
 VALUES
 (
 @TEN
)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_NhanVien]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table NhanVien>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_NhanVien]
(
 @HOTEN  nvarchar(100)
,@NGAYSINH  date
,@GIOITINH BIT
,@DIENTHOAI  nvarchar(15)
,@MACV  int
,@MAPB int
,@URL_IMAGE nvarchar(500)
,@FILE_NAME nvarchar(500)
)
AS
BEGIN

 INSERT INTO dbo.NHANVIEN
 ( 
 HOTEN
,NGAYSINH
,GIOITINH
,DIENTHOAI
,MACV
,MAPB
,URL_IMAGE
,[FILE_NAME]
)
 VALUES
 (
 @HOTEN
,@NGAYSINH
,@GIOITINH
,@DIENTHOAI
,@MACV
,@MAPB
,@URL_IMAGE
,@FILE_NAME
)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON


GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_PHANQUYEN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table PHANQUYEN>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_PHANQUYEN]
(@ID_USER INT
,@XEM_CHISO BIT
,@THEM_CHISO BIT
,@SUA_CHISO BIT
,@XOA_CHISO BIT
,@XEM_CHITITET BIT
,@THEM_CHITITET BIT
,@SUA_CHITITET BIT
,@XOA_CHITIET BIT
,@XEM_CHUCVU BIT
,@THEM_CHUCVU BIT
,@SUA_CHUCVU BIT
,@XOA_CHUCVU BIT
,@XEM_NHANVIEN BIT
,@THEM_NHANVIEN BIT
,@SUA_NHANVIEN BIT
,@XOA_NHANVIEN BIT
,@XEM_PHIEU BIT
,@THEM_PHIEU BIT
,@SUA_PHIEU BIT
,@XOA_PHIEU BIT
,@XEM_PHONGBAN BIT
,@THEM_PHONGBAN BIT
,@SUA_PHONGBAN BIT
,@XOA_PHONGBAN BIT
,@XEM_SANPHAM BIT
,@THEM_SANPHAM BIT
,@SUA_SANPHAM BIT
,@XOA_SANPHAM BIT
,@XEM_THONGSO BIT
,@THEM_THONGSO BIT
,@SUA_THONGSO BIT
,@XOA_THONGSO BIT
,@XEM_USER BIT
,@THEM_USER BIT
,@SUA_USER BIT
,@XOA_USER BIT
)
AS
BEGIN

 INSERT INTO dbo.PHANQUYEN
 ( 
 ID_USER
,XEM_CHISO
,THEM_CHISO
,SUA_CHISO
,XOA_CHISO
,XEM_CHITITET
,THEM_CHITITET
,SUA_CHITITET
,XOA_CHITIET
,XEM_CHUCVU
,THEM_CHUCVU
,SUA_CHUCVU
,XOA_CHUCVU
,XEM_NHANVIEN
,THEM_NHANVIEN
,SUA_NHANVIEN
,XOA_NHANVIEN
,XEM_PHIEU
,THEM_PHIEU
,SUA_PHIEU
,XOA_PHIEU
,XEM_PHONGBAN
,THEM_PHONGBAN
,SUA_PHONGBAN
,XOA_PHONGBAN
,XEM_SANPHAM
,THEM_SANPHAM
,SUA_SANPHAM
,XOA_SANPHAM
,XEM_THONGSO
,THEM_THONGSO
,SUA_THONGSO
,XOA_THONGSO
,XEM_USER
,THEM_USER
,SUA_USER
,XOA_USER

)
 VALUES
 (
@ID_USER 
,@XEM_CHISO 
,@THEM_CHISO 
,@SUA_CHISO 
,@XOA_CHISO 
,@XEM_CHITITET 
,@THEM_CHITITET 
,@SUA_CHITITET 
,@XOA_CHITIET 
,@XEM_CHUCVU 
,@THEM_CHUCVU 
,@SUA_CHUCVU 
,@XOA_CHUCVU 
,@XEM_NHANVIEN 
,@THEM_NHANVIEN 
,@SUA_NHANVIEN 
,@XOA_NHANVIEN 
,@XEM_PHIEU 
,@THEM_PHIEU 
,@SUA_PHIEU 
,@XOA_PHIEU 
,@XEM_PHONGBAN 
,@THEM_PHONGBAN 
,@SUA_PHONGBAN 
,@XOA_PHONGBAN 
,@XEM_SANPHAM
,@THEM_SANPHAM 
,@SUA_SANPHAM 
,@XOA_SANPHAM 
,@XEM_THONGSO 
,@THEM_THONGSO 
,@SUA_THONGSO 
,@XOA_THONGSO 
,@XEM_USER 
,@THEM_USER 
,@SUA_USER 
,@XOA_USER 

)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_PHIEUKHAMBENH]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table PHIEUKHAMBENH>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_PHIEUKHAMBENH]
( 
@MAPHIEU BIGINT
,@MABN INT
,@NGAYKHAM DATETIME
,@LYDO NVARCHAR(500)
,@MANV INT
,@KETLUAN NVARCHAR(MAX)
,@DIEUTRI NVARCHAR(MAX)
,@TAIKHAM DATE
)
AS
BEGIN

 INSERT INTO dbo.PHIEUKHAMBENH
 ( 
 MAPHIEU
 ,MABN
 ,NGAYKHAM
 ,LYDO
 ,MANV
 ,KETLUAN
 ,DIEUTRI
 ,TAIKHAM
)
 VALUES
 (
@MAPHIEU 
,@MABN 
,@NGAYKHAM 
,@LYDO 
,@MANV 
,@KETLUAN 
,@DIEUTRI 
,@TAIKHAM 
)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_PHONGBAN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table PHONGBAN>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_PHONGBAN]
( 
@TENPHONG NVARCHAR(100)
)
AS
BEGIN

 INSERT INTO dbo.PHONGBAN
 ( 
TENPHONG 
)
 VALUES
 (
@TENPHONG 

)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_SANPHAM_DICHVU]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table SANPHAM_DICHVU>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_SANPHAM_DICHVU]
( 
@MAPB INT
,@TENDV NVARCHAR(200)
,@MOTA NVARCHAR(200)
)
AS
BEGIN

 INSERT INTO dbo.SANPHAM_DICHVU
 ( 
 MAPB
 ,TENDV
 ,MOTA 
)
 VALUES
 (
@MAPB
,@TENDV
,@MOTA
)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_THONGSOKYTHUAT]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table THONGSOKYTHUAT>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_THONGSOKYTHUAT]
( 
@TENTHONGSO NVARCHAR(200)
,@ID_SP INT
)
AS
BEGIN

 INSERT INTO dbo.THONGSOKYTHUAT
 ( 
TENTHONGSO
,ID_SP
)
 VALUES
 (
@TENTHONGSO
,@ID_SP

)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_TT_BENHNHAN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table TT_BENHNHAN>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_TT_BENHNHAN]
( 
@HOTEN NVARCHAR(100)
,@NGAYSINH DATE
,@GIOITINH BIT
,@DIENTHOAI NVARCHAR(15)
,@CHIEUCAO int
,@CANNANG int
,@TIENSU NVARCHAR(MAX)
)
AS
BEGIN

 INSERT INTO dbo.TT_BENHNHAN
 ( 
 HOTEN
 ,NGAYSINH
 ,GIOITINH
 ,DIENTHOAI
 ,CHIEUCAO
 ,CANNANG
 ,TIENSU 
)
 VALUES
 (
@HOTEN 
,@NGAYSINH 
,@GIOITINH 
,@DIENTHOAI 
,@CHIEUCAO 
,@CANNANG 
,@TIENSU
)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_USER]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure insert table USER>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Insert_USER]
( 
 @USERNAME NVARCHAR(50)
,@PASS CHAR(84)
,@HOTEN NVARCHAR(50)
,@ISADMIN BIT
)
AS
BEGIN

 INSERT INTO dbo.[USER]
 ( 
 USERNAME
,PASS
,HOTEN
,ISADMIN
)
 VALUES
 (
@USERNAME
,@PASS
,@HOTEN
,@ISADMIN
)
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Update_CHISOBENHNHAN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table CHISO_BENHNHAN>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_CHISOBENHNHAN]
(
 @ID_CTK bigint
,@ID_TS  int
,@CHISO  nvarchar(200)
)
AS
BEGIN
UPDATE dbo.CHISO_BENHNHAN
SET
 ID_CTK=@ID_CTK
,ID_TS=@ID_TS
,CHISO=@CHISO

WHERE ID_CTK=@ID_CTK AND ID_TS=@ID_TS
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Update_CHITIETKHAM]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table CHITIETKHAM>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_CHITIETKHAM]
(
@ID bigint
,@MAPHIEU  bigint
,@ID_SP  int
,@MOTA  nvarchar(500)
,@KETLUAN nvarchar(500)
,@NGAYKHAM datetime
,@MANV int
,@URL_IMAGE nvarchar(500)
)
AS
BEGIN
UPDATE dbo.CHITIETKHAM
SET
 MAPHIEU=@MAPHIEU
,ID_SP=@ID_SP
,MOTA=@MOTA
,KETLUAN=@KETLUAN
,NGAYKHAM=@NGAYKHAM
,MANV=@MANV
,URL_IMAGE=@URL_IMAGE

WHERE ID=@ID
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Update_CHUCVU]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table CHUCVU>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_CHUCVU]
(
@MACV INT
,@TEN nvarchar(100)
)
AS
BEGIN
UPDATE dbo.CHUCVU
SET
 TEN=@TEN
 WHERE MACV=@MACV
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Update_NhanVien]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table NhanVien>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_NhanVien]
(
@MANV int
,@HOTEN  nvarchar(100)
,@NGAYSINH  date
,@GIOITINH  BIT
,@DIENTHOAI  nvarchar(15)
,@MACV  int
,@MAPB int
,@URL_IMAGE nvarchar(500)
,@FILE_NAME nvarchar(500)
)
AS
BEGIN
UPDATE dbo.NHANVIEN
SET
 HOTEN=@HOTEN
,NGAYSINH=@NGAYSINH
,GIOITINH=@GIOITINH
,DIENTHOAI=@DIENTHOAI
,MACV=@MACV
,MAPB=@MAPB
,URL_IMAGE=@URL_IMAGE
,[FILE_NAME]=@FILE_NAME
WHERE MANV=@MANV
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON


GO
/****** Object:  StoredProcedure [dbo].[sp_Update_PHANQUYEN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table PHANQUYEN>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_PHANQUYEN]
(
@ID_USER INT
,@XEM_CHISO BIT
,@THEM_CHISO BIT
,@SUA_CHISO BIT
,@XOA_CHISO BIT
,@XEM_CHITITET BIT
,@THEM_CHITITET BIT
,@SUA_CHITITET BIT
,@XOA_CHITIET BIT
,@XEM_CHUCVU BIT
,@THEM_CHUCVU BIT
,@SUA_CHUCVU BIT
,@XOA_CHUCVU BIT
,@XEM_NHANVIEN BIT
,@THEM_NHANVIEN BIT
,@SUA_NHANVIEN BIT
,@XOA_NHANVIEN BIT
,@XEM_PHIEU BIT
,@THEM_PHIEU BIT
,@SUA_PHIEU BIT
,@XOA_PHIEU BIT
,@XEM_PHONGBAN BIT
,@THEM_PHONGBAN BIT
,@SUA_PHONGBAN BIT
,@XOA_PHONGBAN BIT
,@XEM_SANPHAM BIT
,@THEM_SANPHAM BIT
,@SUA_SANPHAM BIT
,@XOA_SANPHAM BIT
,@XEM_THONGSO BIT
,@THEM_THONGSO BIT
,@SUA_THONGSO BIT
,@XOA_THONGSO BIT
,@XEM_USER BIT
,@THEM_USER BIT
,@SUA_USER BIT
,@XOA_USER BIT
)
AS
BEGIN
UPDATE dbo.PHANQUYEN
SET
XEM_CHISO=@XEM_CHISO
,THEM_CHISO=@THEM_CHISO
,SUA_CHISO=@SUA_CHISO
,XOA_CHISO=@XOA_CHISO
,XEM_CHITITET=@XEM_CHITITET
,THEM_CHITITET=@THEM_CHITITET
,SUA_CHITITET=@SUA_CHITITET
,XOA_CHITIET=@XOA_CHITIET
,XEM_CHUCVU=@XEM_CHUCVU
,THEM_CHUCVU=@THEM_CHUCVU
,SUA_CHUCVU=@SUA_CHUCVU
,XOA_CHUCVU=@XOA_CHUCVU
,XEM_NHANVIEN=@XEM_NHANVIEN
,THEM_NHANVIEN=@THEM_NHANVIEN
,SUA_NHANVIEN=@SUA_NHANVIEN
,XOA_NHANVIEN=@XOA_NHANVIEN
,XEM_PHIEU=@XEM_PHIEU
,THEM_PHIEU=@THEM_PHIEU
,SUA_PHIEU=@SUA_PHIEU
,XOA_PHIEU=@XOA_PHIEU
,XEM_PHONGBAN=@XEM_PHONGBAN
,THEM_PHONGBAN=@THEM_PHONGBAN
,SUA_PHONGBAN=@SUA_PHONGBAN
,XOA_PHONGBAN=@XOA_PHONGBAN
,XEM_SANPHAM=@XEM_SANPHAM
,THEM_SANPHAM=@THEM_SANPHAM
,SUA_SANPHAM=@SUA_SANPHAM
,XOA_SANPHAM=@XOA_SANPHAM
,XEM_THONGSO=@XEM_THONGSO
,THEM_THONGSO=@THEM_THONGSO
,SUA_THONGSO=@SUA_THONGSO
,XOA_THONGSO=@XOA_THONGSO
,XEM_USER=@XEM_USER
,THEM_USER=@THEM_USER
,SUA_USER=@SUA_USER
,XOA_USER=@XOA_USER

WHERE ID_USER=@ID_USER
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Update_PHIEUKHAMBENH]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table CHISO_PHIEUKHAMBENH>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_PHIEUKHAMBENH]
(
 @MAPHIEU BIGINT
,@MABN INT
,@NGAYKHAM DATETIME
,@LYDO NVARCHAR(500)
,@MANV INT
,@KETLUAN NVARCHAR(MAX)
,@DIEUTRI NVARCHAR(MAX)
,@TAIKHAM DATE
)
AS
BEGIN
UPDATE dbo.PHIEUKHAMBENH
SET
 MABN=@MABN
,NGAYKHAM=@NGAYKHAM
,LYDO=@LYDO
,MANV=@MANV
,KETLUAN=@KETLUAN
,DIEUTRI=@DIEUTRI
,TAIKHAM=@TAIKHAM

WHERE MAPHIEU=@MAPHIEU
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Update_PHONGBAN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table CHISO_PHONGBAN>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_PHONGBAN]
(
 @MAPB INT
,@TENPHONG NVARCHAR(100)
)
AS
BEGIN
UPDATE dbo.PHONGBAN
SET
 TENPHONG=@TENPHONG

WHERE MAPB=@MAPB
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Update_SANPHAM_DICHVU]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table SANPHAM_DICHVU>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_SANPHAM_DICHVU]
(
  @ID_SP INT
,@MAPB INT
,@TENDV NVARCHAR(200)
,@MOTA NVARCHAR(200)
)
AS
BEGIN
UPDATE dbo.SANPHAM_DICHVU
SET
MAPB=@MAPB
 ,TENDV=@TENDV
 ,MOTA= @MOTA

WHERE ID_SP=@ID_SP
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Update_THONGSOKYTHUAT]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table THONGSOKYTHUAT>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_THONGSOKYTHUAT]
(
@ID INT
,@TENTHONGSO NVARCHAR(200)
,@ID_SP INT
)
AS
BEGIN
UPDATE dbo.THONGSOKYTHUAT
SET
TENTHONGSO=@TENTHONGSO
,ID_SP=@ID_SP

WHERE ID=@ID
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Update_TT_BENHNHAN]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table TT_BENHNHAN>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_TT_BENHNHAN]
(
  @MABN INT
,@HOTEN NVARCHAR(100)
,@NGAYSINH DATE
,@GIOITINH BIT
,@DIENTHOAI NVARCHAR(15)
,@CHIEUCAO int
,@CANNANG int
,@TIENSU NVARCHAR(MAX)
)
AS
BEGIN
UPDATE dbo.TT_BENHNHAN
SET
  HOTEN=@HOTEN
 ,NGAYSINH=@NGAYSINH
 ,GIOITINH= @GIOITINH
 ,DIENTHOAI=@DIENTHOAI
 ,CHIEUCAO=@CHIEUCAO
 ,CANNANG=@CANNANG
 ,TIENSU=@TIENSU

WHERE MABN=@MABN
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
/****** Object:  StoredProcedure [dbo].[sp_Update_USER]    Script Date: 4/15/2017 9:27:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Van Chinh>
-- Create date: <24/03/2017>
-- Description:	<create store procedure update table USER>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_USER]
(
 @ID int
,@USERNAME NVARCHAR(50)
,@PASS CHAR(84)
,@HOTEN NVARCHAR(50)
,@ISADMIN BIT
)
AS
BEGIN
UPDATE dbo.[USER]
SET
 USERNAME=@USERNAME
,PASS=@PASS
,HOTEN=@HOTEN
,ISADMIN=@ISADMIN

WHERE ID=@ID
	
END
 SET ANSI_NULLS ON
 SET QUOTED_IDENTIFIER ON




GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CHUCVU"
            Begin Extent = 
               Top = 27
               Left = 499
               Bottom = 122
               Right = 669
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PHONGBAN"
            Begin Extent = 
               Top = 111
               Left = 275
               Bottom = 206
               Right = 445
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "NHANVIEN"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_NhanVien'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_NhanVien'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SANPHAM_DICHVU"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PHONGBAN"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_SANPHAMDICHVU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_SANPHAMDICHVU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "THONGSOKYTHUAT"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SANPHAM_DICHVU"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_THONGSOKYTHUAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'view_THONGSOKYTHUAT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TT_BENHNHAN"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_TT_BENHNHAN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_TT_BENHNHAN'
GO
USE [master]
GO
ALTER DATABASE [phongkham] SET  READ_WRITE 
GO
