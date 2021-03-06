USE [master]
GO
/****** Object:  Database [TrangTrai]    Script Date: 03/17/2018 08:19:55 ******/
CREATE DATABASE [TrangTrai] ON  PRIMARY 
( NAME = N'TrangTrai', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.HUNG\MSSQL\DATA\TrangTrai.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TrangTrai_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.HUNG\MSSQL\DATA\TrangTrai_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TrangTrai] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrangTrai].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrangTrai] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TrangTrai] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TrangTrai] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TrangTrai] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TrangTrai] SET ARITHABORT OFF
GO
ALTER DATABASE [TrangTrai] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TrangTrai] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TrangTrai] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TrangTrai] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TrangTrai] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TrangTrai] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TrangTrai] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TrangTrai] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TrangTrai] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TrangTrai] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TrangTrai] SET  DISABLE_BROKER
GO
ALTER DATABASE [TrangTrai] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TrangTrai] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TrangTrai] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TrangTrai] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TrangTrai] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TrangTrai] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TrangTrai] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [TrangTrai] SET  READ_WRITE
GO
ALTER DATABASE [TrangTrai] SET RECOVERY SIMPLE
GO
ALTER DATABASE [TrangTrai] SET  MULTI_USER
GO
ALTER DATABASE [TrangTrai] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TrangTrai] SET DB_CHAINING OFF
GO
USE [TrangTrai]
GO
/****** Object:  Table [dbo].[LoaiTK]    Script Date: 03/17/2018 08:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTK](
	[ma_loaiTK] [int] NULL,
	[ten_loaiTK] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[LoaiTK] ([ma_loaiTK], [ten_loaiTK]) VALUES (0, N'Nhân Viên')
INSERT [dbo].[LoaiTK] ([ma_loaiTK], [ten_loaiTK]) VALUES (1, N'Quản Trị Viên')
/****** Object:  Table [dbo].[LoaiNhanVien]    Script Date: 03/17/2018 08:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNhanVien](
	[ma_loaiNV] [nvarchar](50) NOT NULL,
	[ten_loaiNV] [nvarchar](50) NULL,
	[luong] [int] NULL,
 CONSTRAINT [PK_LoaiNhanVien] PRIMARY KEY CLUSTERED 
(
	[ma_loaiNV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[LoaiNhanVien] ([ma_loaiNV], [ten_loaiNV], [luong]) VALUES (N'LNV001', N'Công Nhân', 3000000)
INSERT [dbo].[LoaiNhanVien] ([ma_loaiNV], [ten_loaiNV], [luong]) VALUES (N'LNV002', N'Quản Lý', 5000000)
/****** Object:  Table [dbo].[Loai]    Script Date: 03/17/2018 08:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[ma_loai] [nvarchar](50) NOT NULL,
	[ten_loai] [nvarchar](50) NULL,
	[soluongVN] [int] NULL,
	[soluongCH] [int] NULL,
 CONSTRAINT [PK_Loai] PRIMARY KEY CLUSTERED 
(
	[ma_loai] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Loai] ([ma_loai], [ten_loai], [soluongVN], [soluongCH]) VALUES (N'L001', N'Heo', 4, 2)
INSERT [dbo].[Loai] ([ma_loai], [ten_loai], [soluongVN], [soluongCH]) VALUES (N'L002', N'Bò', 4, 1)
INSERT [dbo].[Loai] ([ma_loai], [ten_loai], [soluongVN], [soluongCH]) VALUES (N'L003', N'Gà', 4, 1)
INSERT [dbo].[Loai] ([ma_loai], [ten_loai], [soluongVN], [soluongCH]) VALUES (N'L004', N'Vịt', 3, 2)
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 03/17/2018 08:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[usename] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[ma_loaiTK] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[TaiKhoan] ([usename], [password], [ma_loaiTK]) VALUES (N'dragodrex', N'123', 1)
INSERT [dbo].[TaiKhoan] ([usename], [password], [ma_loaiTK]) VALUES (N'thanhhung', N'123', 1)
INSERT [dbo].[TaiKhoan] ([usename], [password], [ma_loaiTK]) VALUES (N'tanhiep', N'123', 1)
INSERT [dbo].[TaiKhoan] ([usename], [password], [ma_loaiTK]) VALUES (N'nhanvien1', N'456', 0)
INSERT [dbo].[TaiKhoan] ([usename], [password], [ma_loaiTK]) VALUES (N'nhanvien2', N'456', 0)
INSERT [dbo].[TaiKhoan] ([usename], [password], [ma_loaiTK]) VALUES (N'nhanvien3', N'456', 0)
/****** Object:  Table [dbo].[Thuoc]    Script Date: 03/17/2018 08:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Thuoc](
	[ma_thuoc] [nvarchar](50) NOT NULL,
	[ten_thuoc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Thuoc] PRIMARY KEY CLUSTERED 
(
	[ma_thuoc] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc]) VALUES (N'TH001', N'Thuốc Trị Cúm Gà')
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc]) VALUES (N'TH002', N'Thuốc Trị Heo Tai Xanh')
INSERT [dbo].[Thuoc] ([ma_thuoc], [ten_thuoc]) VALUES (N'TH003', N'Thuốc Trị Bò Điên')
/****** Object:  Table [dbo].[NhanVien]    Script Date: 03/17/2018 08:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ma_NV] [nvarchar](50) NOT NULL,
	[ten_NV] [nvarchar](50) NULL,
	[ma_loaiNV] [nvarchar](50) NULL,
	[dienthoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ma_NV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NhanVien] ([ma_NV], [ten_NV], [ma_loaiNV], [dienthoai]) VALUES (N'NV001', N'Nhân Viên 1', N'LNV001', N'123456')
INSERT [dbo].[NhanVien] ([ma_NV], [ten_NV], [ma_loaiNV], [dienthoai]) VALUES (N'NV002', N'Nhân Viên 2', N'LNV002', N'132456')
INSERT [dbo].[NhanVien] ([ma_NV], [ten_NV], [ma_loaiNV], [dienthoai]) VALUES (N'NV003', N'Nhân Viên 3', N'LNV001', N'456241')
/****** Object:  Table [dbo].[Chuong]    Script Date: 03/17/2018 08:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chuong](
	[ma_chuong] [nvarchar](50) NOT NULL,
	[ten_chuong] [nvarchar](50) NULL,
	[ma_loai] [nvarchar](50) NULL,
	[soluong] [int] NULL,
	[sltoida] [int] NULL,
 CONSTRAINT [PK_Chuong] PRIMARY KEY CLUSTERED 
(
	[ma_chuong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Chuong] ([ma_chuong], [ten_chuong], [ma_loai], [soluong], [sltoida]) VALUES (N'CH001', N'Chuồng Heo 1', N'L001', 3, 10)
INSERT [dbo].[Chuong] ([ma_chuong], [ten_chuong], [ma_loai], [soluong], [sltoida]) VALUES (N'CH002', N'Chuồng Gà 1', N'L003', 4, 10)
INSERT [dbo].[Chuong] ([ma_chuong], [ten_chuong], [ma_loai], [soluong], [sltoida]) VALUES (N'CH003', N'Chuồng Heo 2', N'L001', 1, 10)
INSERT [dbo].[Chuong] ([ma_chuong], [ten_chuong], [ma_loai], [soluong], [sltoida]) VALUES (N'CH004', N'Chuồng Bò 1', N'L002', 4, 15)
INSERT [dbo].[Chuong] ([ma_chuong], [ten_chuong], [ma_loai], [soluong], [sltoida]) VALUES (N'CH005', N'Chuồng Vịt 1', N'L004', 3, 15)
INSERT [dbo].[Chuong] ([ma_chuong], [ten_chuong], [ma_loai], [soluong], [sltoida]) VALUES (N'CH006', N'Chuồng Vịt 2', N'L004', 0, 10)
/****** Object:  Table [dbo].[Benh]    Script Date: 03/17/2018 08:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Benh](
	[ma_benh] [nvarchar](50) NOT NULL,
	[ten_benh] [nvarchar](50) NULL,
	[ma_loai] [nvarchar](50) NULL,
 CONSTRAINT [PK_Benh] PRIMARY KEY CLUSTERED 
(
	[ma_benh] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Benh] ([ma_benh], [ten_benh], [ma_loai]) VALUES (N'B001', N'Cúm Gà', N'L003')
INSERT [dbo].[Benh] ([ma_benh], [ten_benh], [ma_loai]) VALUES (N'B002', N'Heo Tai Xanh', N'L001')
INSERT [dbo].[Benh] ([ma_benh], [ten_benh], [ma_loai]) VALUES (N'B003', N'Bò Điên', N'L002')
/****** Object:  Table [dbo].[LichSuBenh]    Script Date: 03/17/2018 08:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSuBenh](
	[ma_LS] [int] IDENTITY(1,1) NOT NULL,
	[ma_vatnuoi] [nvarchar](50) NULL,
	[ma_benh] [nvarchar](50) NULL,
	[ma_thuoc] [nvarchar](50) NULL,
	[ngay_macbenh] [datetime] NULL,
 CONSTRAINT [PK_LichSuBenh] PRIMARY KEY CLUSTERED 
(
	[ma_LS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LichSuBenh] ON
INSERT [dbo].[LichSuBenh] ([ma_LS], [ma_vatnuoi], [ma_benh], [ma_thuoc], [ngay_macbenh]) VALUES (1, N'VN001', N'B002', N'TH002', CAST(0x0000A8A400000000 AS DateTime))
INSERT [dbo].[LichSuBenh] ([ma_LS], [ma_vatnuoi], [ma_benh], [ma_thuoc], [ngay_macbenh]) VALUES (2, N'VN003', N'B001', N'TH001', CAST(0x0000A8A400000000 AS DateTime))
INSERT [dbo].[LichSuBenh] ([ma_LS], [ma_vatnuoi], [ma_benh], [ma_thuoc], [ngay_macbenh]) VALUES (3, N'VN002', N'B002', N'TH002', CAST(0x0000A8A400000000 AS DateTime))
INSERT [dbo].[LichSuBenh] ([ma_LS], [ma_vatnuoi], [ma_benh], [ma_thuoc], [ngay_macbenh]) VALUES (5, N'VN008', N'B002', N'TH002', CAST(0x0000A8A400000000 AS DateTime))
INSERT [dbo].[LichSuBenh] ([ma_LS], [ma_vatnuoi], [ma_benh], [ma_thuoc], [ngay_macbenh]) VALUES (6, N'VN005', N'B001', N'TH001', CAST(0x0000A8A500000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[LichSuBenh] OFF
/****** Object:  Table [dbo].[VatNuoi]    Script Date: 03/17/2018 08:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VatNuoi](
	[ma_vatnuoi] [nvarchar](50) NOT NULL,
	[ten_vatnuoi] [nvarchar](50) NULL,
	[ma_loai] [nvarchar](50) NULL,
	[ma_chuong] [nvarchar](50) NULL,
	[ngay_nhap] [datetime] NULL,
	[ngay_xuat] [datetime] NULL,
 CONSTRAINT [PK_VatNuoi] PRIMARY KEY CLUSTERED 
(
	[ma_vatnuoi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN001', N'Heo 1', N'L001', N'CH003', CAST(0x0000A8A400000000 AS DateTime), CAST(0x0000A8A400000000 AS DateTime))
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN002', N'Heo 2', N'L001', N'CH001', CAST(0x0000A8A400000000 AS DateTime), CAST(0x0000A8A500000000 AS DateTime))
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN003', N'Gà 1', N'L003', N'CH002', CAST(0x0000A8A400000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN004', N'Bò 1', N'L002', N'CH004', CAST(0x0000A8A400000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN005', N'Gà 2', N'L003', N'CH002', CAST(0x0000A8A400000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN006', N'Bò 2', N'L002', N'CH004', CAST(0x0000A8A400000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN007', N'Vit 1', N'L004', N'CH005', CAST(0x0000A8A400000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN008', N'Heo 3', N'L001', N'CH001', CAST(0x0000A8A400000000 AS DateTime), CAST(0x0000A8A500000000 AS DateTime))
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN009', N'Gà 3', N'L003', N'CH002', CAST(0x0000A8A400000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN010', N'Cow 3', N'L002', N'CH004', CAST(0x0000A8A500000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN011', N'Cow 4', N'L002', N'CH004', CAST(0x0000A8A500000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN012', N'Heo 555', N'L001', N'CH001', CAST(0x0000A8A500000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN013', N'Gà 100', N'L003', N'CH002', CAST(0x0000A8A500000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN014', N'Vịt 100', N'L004', N'CH005', CAST(0x0000A8A500000000 AS DateTime), NULL)
INSERT [dbo].[VatNuoi] ([ma_vatnuoi], [ten_vatnuoi], [ma_loai], [ma_chuong], [ngay_nhap], [ngay_xuat]) VALUES (N'VN015', N'Vịt 101', N'L004', N'CH005', CAST(0x0000A8A500000000 AS DateTime), NULL)
/****** Object:  StoredProcedure [dbo].[ThemChuong]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemChuong] @ma_chuong nvarchar(50), @ten_chuong nvarchar(50), @ma_loai nvarchar(50), @sltoida int
as 
begin
	insert into Chuong(ma_chuong, ten_chuong, ma_loai, soluong, sltoida) values(@ma_chuong, @ten_chuong, @ma_loai, 0, @sltoida)
	update Loai set soluongCH = soluongCH + 1 where Loai.ma_loai = @ma_loai
end
GO
/****** Object:  StoredProcedure [dbo].[XuatChuong]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[XuatChuong] @ma_vatnuoi nvarchar(50)
as
begin
	declare @ngay_xuat nvarchar(50)
	set @ngay_xuat = (select ngay_xuat from VatNuoi where ma_vatnuoi = @ma_vatnuoi)
	if(@ngay_xuat is null)
		update VatNuoi set ngay_xuat = CAST(GETDATE() AS DATE) where ma_vatnuoi = @ma_vatnuoi
end
GO
/****** Object:  StoredProcedure [dbo].[XoaVatNuoi]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[XoaVatNuoi] @ma_vatnuoi nvarchar(50)
as
begin
	declare @MaCH nvarchar(50)
	set @MaCH = (select ma_chuong from Chuong where ma_chuong = (select ma_chuong from VatNuoi where ma_vatnuoi = @ma_vatnuoi))
	declare @MaL nvarchar(50)
	set @MaL = (select ma_loai from Loai where ma_loai = (select ma_loai from VatNuoi where ma_vatnuoi = @ma_vatnuoi))
	
	delete from VatNuoi where ma_vatnuoi = @ma_vatnuoi
	
	update Loai set soluongVN = soluongVN - 1 where Loai.ma_loai = @MaL
	update Chuong set soluong = soluong - 1 where Chuong.ma_chuong = @MaCH
end
GO
/****** Object:  StoredProcedure [dbo].[XoaLSB]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaLSB] @ma_LS nvarchar(50)
as
begin
	delete from LichSuBenh where ma_LS = @ma_LS
end
GO
/****** Object:  StoredProcedure [dbo].[XoaChuong]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaChuong] @ma_chuong nvarchar(50)
as 
begin
	declare @MaL nvarchar(50)
	set @MaL = (select ma_loai from Chuong where ma_chuong = @ma_chuong)
	declare @SL nvarchar(50)
	set @SL = (select soluong from Chuong where ma_chuong = @ma_chuong)
	
	delete from Chuong where ma_chuong = @ma_chuong
	update Loai set soluongCH = soluongCH - 1 where Loai.ma_loai = @MaL
	
	declare @MaChuong nvarchar(50)
	set @MaChuong = (select top(1) ma_chuong from Chuong where ma_loai = @MaL and soluong < sltoida)
	update VatNuoi set ma_chuong = @MaChuong where ma_chuong = @ma_chuong
	update Chuong set soluong = soluong + @SL where ma_chuong = @MaChuong
end
GO
/****** Object:  StoredProcedure [dbo].[ThemVatNuoi]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ThemVatNuoi] @ma_vatnuoi nvarchar(50), @ten_vatnuoi nvarchar(50), @ma_loai nvarchar(50), @ma_chuong nvarchar(50)
as 
begin
	declare @MaLoai nvarchar(50)
	set @MaLoai = (select ma_loai from Chuong where ma_chuong = @ma_chuong)
	
	declare @SL nvarchar(50)
	set @SL = (select soluong from Chuong where ma_chuong = @ma_chuong)
	declare @SLTD nvarchar(50)
	set @SLTD = (select sltoida from Chuong where ma_chuong = @ma_chuong)
	
	if(@MaLoai = @ma_loai and @SL < @SLTD)
	begin
		insert into VatNuoi(ma_vatnuoi, ten_vatnuoi, ma_loai, ma_chuong, ngay_nhap, ngay_xuat) values(@ma_vatnuoi, @ten_vatnuoi, @ma_loai, @ma_chuong, CAST(GETDATE() AS DATE), null)
		update Loai set soluongVN = soluongVN + 1 where Loai.ma_loai = @ma_loai
		update Chuong set soluong = soluong + 1 where Chuong.ma_chuong = @ma_chuong
	end
	else
	begin
		declare @MaChuong nvarchar(50)
		set @MaChuong = (select top(1) ma_chuong from Chuong where ma_loai = @ma_loai and soluong < sltoida)
		
		insert into VatNuoi(ma_vatnuoi, ten_vatnuoi, ma_loai, ma_chuong, ngay_nhap, ngay_xuat) values(@ma_vatnuoi, @ten_vatnuoi, @ma_loai, @MaChuong, CAST(GETDATE() AS DATE), null)
		update Loai set soluongVN = soluongVN + 1 where Loai.ma_loai = @ma_loai
		update Chuong set soluong = soluong + 1 where Chuong.ma_chuong = @MaChuong
	end
end
GO
/****** Object:  StoredProcedure [dbo].[ThemLSB]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemLSB] @ma_vatnuoi nvarchar(50), @ma_benh nvarchar(50), @ma_thuoc nvarchar(50)
as
begin
	declare @MaLoai1 nvarchar(50)
	set @MaLoai1 = (select ma_loai from VatNuoi where ma_vatnuoi = @ma_vatnuoi)
	declare @MaLoai2 nvarchar(50)
	set @MaLoai2 = (select ma_loai from Benh where ma_benh = @ma_benh)
	if(@MaLoai1 = @MaLoai2)
	begin
		insert into LichSuBenh(ma_vatnuoi, ma_benh, ma_thuoc, ngay_macbenh) values(@ma_vatnuoi, @ma_benh, @ma_thuoc, CAST(GETDATE() AS DATE))
	end
end
GO
/****** Object:  StoredProcedure [dbo].[SuaVatNuoi]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SuaVatNuoi] @ma_vatnuoi nvarchar(50), @ten_vatnuoi nvarchar(50), @ma_loai nvarchar(50), @ma_chuong nvarchar(50)
as 
begin
	declare @MaLoai nvarchar(50)
	set @MaLoai = (select ma_loai from Chuong where ma_chuong = @ma_chuong)
	declare @MaCH nvarchar(50)
	set @MaCH = (select ma_chuong from Chuong where ma_chuong = (select ma_chuong from VatNuoi where ma_vatnuoi = @ma_vatnuoi))
	declare @MaL nvarchar(50)
	set @MaL = (select ma_loai from Loai where ma_loai = (select ma_loai from VatNuoi where ma_vatnuoi = @ma_vatnuoi))
	
	declare @SL nvarchar(50)
	set @SL = (select soluong from Chuong where ma_chuong = @ma_chuong)
	declare @SLTD nvarchar(50)
	set @SLTD = (select sltoida from Chuong where ma_chuong = @ma_chuong)
	
	if(@MaLoai = @ma_loai and @SL < @SLTD and @MaL = @ma_loai)
	begin
			update VatNuoi set ten_vatnuoi = @ten_vatnuoi, ma_loai = @ma_loai, ma_chuong = @ma_chuong where ma_vatnuoi = @ma_vatnuoi
			update Loai set soluongVN = soluongVN + 1 where Loai.ma_loai = @ma_loai
			update Chuong set soluong = soluong + 1 where Chuong.ma_chuong = @ma_chuong
	end
	else
	begin
		declare @MaChuong nvarchar(50)
		set @MaChuong = (select top(1) ma_chuong from Chuong where ma_loai = @ma_loai and soluong < sltoida)
		
		update VatNuoi set ten_vatnuoi = @ten_vatnuoi, ma_loai = @ma_loai, ma_chuong = @MaChuong where ma_vatnuoi = @ma_vatnuoi
		update Loai set soluongVN = soluongVN + 1 where Loai.ma_loai = @ma_loai
		update Chuong set soluong = soluong + 1 where Chuong.ma_chuong = @MaChuong
	end
	update Loai set soluongVN = soluongVN - 1 where Loai.ma_loai = @MaL
	update Chuong set soluong = soluong - 1 where Chuong.ma_chuong = @MaCH
end
GO
/****** Object:  StoredProcedure [dbo].[SuaLSB]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SuaLSB] @ma_LS nvarchar(50), @ma_vatnuoi nvarchar(50), @ma_benh nvarchar(50), @ma_thuoc nvarchar(50)
as
begin
	declare @MaLoai1 nvarchar(50)
	set @MaLoai1 = (select ma_loai from VatNuoi where ma_vatnuoi = @ma_vatnuoi)
	declare @MaLoai2 nvarchar(50)
	set @MaLoai2 = (select ma_loai from Benh where ma_benh = @ma_benh)
	if(@MaLoai1 = @MaLoai2)
	begin
		update LichSuBenh set ma_vatnuoi = @ma_vatnuoi, ma_benh = @ma_benh, ma_thuoc = @ma_thuoc where ma_LS = @ma_LS
	end
end
GO
/****** Object:  StoredProcedure [dbo].[SuaChuong]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SuaChuong] @ma_chuong nvarchar(50), @ten_chuong nvarchar(50), @ma_loai nvarchar(50), @sltoida int
as 
begin
	declare @MaL nvarchar(50)
	set @MaL = (select ma_loai from Chuong where ma_chuong = @ma_chuong)
	declare @SL nvarchar(50)
	set @SL = (select soluong from Chuong where ma_chuong = @ma_chuong)
	
	update Chuong set ten_chuong = @ten_chuong, ma_loai = @ma_loai, sltoida = @sltoida 
	where ma_chuong = @ma_chuong
	update Loai set soluongCH = soluongCH + 1 where Loai.ma_loai = @ma_loai
	update Loai set soluongCH = soluongCH - 1 where Loai.ma_loai = @MaL
	
	if(@MaL != @ma_loai)
	begin
		declare @MaChuong nvarchar(50)
		set @MaChuong = (select top(1) ma_chuong from Chuong where ma_loai = @MaL and soluong < sltoida)
		update VatNuoi set ma_chuong = @MaChuong where ma_chuong = @ma_chuong
		update Chuong set soluong = 0 where ma_chuong = @ma_chuong
		update Chuong set soluong = soluong + @SL where ma_chuong = @MaChuong
	end
end
GO
/****** Object:  StoredProcedure [dbo].[CountVatNuoichoLoai]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CountVatNuoichoLoai] @ma_loai nvarchar(50)
as
begin
	declare @count int
	set @count = (select COUNT(*) from VatNuoi where ma_loai = @ma_loai)
	update Loai set soluongVN = @count where ma_loai = @ma_loai
end
GO
/****** Object:  StoredProcedure [dbo].[CountVatNuoichoChuong]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CountVatNuoichoChuong] @ma_chuong nvarchar(50)
as
begin
	declare @count int
	set @count = (select COUNT(*) from VatNuoi where ma_chuong = @ma_chuong)
	update Chuong set soluong = @count where ma_chuong = @ma_chuong
end
GO
/****** Object:  StoredProcedure [dbo].[CountChuongchoLoai]    Script Date: 03/17/2018 08:20:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CountChuongchoLoai] @ma_loai nvarchar(50)
as
begin
	declare @count int
	set @count = (select COUNT(*) from Chuong where ma_loai = @ma_loai)
	update Loai set soluongCH = @count where ma_loai = @ma_loai
end
exec CountVatNuoichoChuong N'CH001'
GO
/****** Object:  ForeignKey [FK_NhanVien_LoaiNhanVien]    Script Date: 03/17/2018 08:19:56 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_LoaiNhanVien] FOREIGN KEY([ma_loaiNV])
REFERENCES [dbo].[LoaiNhanVien] ([ma_loaiNV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_LoaiNhanVien]
GO
/****** Object:  ForeignKey [FK_Chuong_Loai]    Script Date: 03/17/2018 08:19:56 ******/
ALTER TABLE [dbo].[Chuong]  WITH CHECK ADD  CONSTRAINT [FK_Chuong_Loai] FOREIGN KEY([ma_loai])
REFERENCES [dbo].[Loai] ([ma_loai])
GO
ALTER TABLE [dbo].[Chuong] CHECK CONSTRAINT [FK_Chuong_Loai]
GO
/****** Object:  ForeignKey [FK_Benh_Loai]    Script Date: 03/17/2018 08:19:56 ******/
ALTER TABLE [dbo].[Benh]  WITH CHECK ADD  CONSTRAINT [FK_Benh_Loai] FOREIGN KEY([ma_loai])
REFERENCES [dbo].[Loai] ([ma_loai])
GO
ALTER TABLE [dbo].[Benh] CHECK CONSTRAINT [FK_Benh_Loai]
GO
/****** Object:  ForeignKey [FK_LichSuBenh_Benh]    Script Date: 03/17/2018 08:19:56 ******/
ALTER TABLE [dbo].[LichSuBenh]  WITH CHECK ADD  CONSTRAINT [FK_LichSuBenh_Benh] FOREIGN KEY([ma_benh])
REFERENCES [dbo].[Benh] ([ma_benh])
GO
ALTER TABLE [dbo].[LichSuBenh] CHECK CONSTRAINT [FK_LichSuBenh_Benh]
GO
/****** Object:  ForeignKey [FK_LichSuBenh_Thuoc]    Script Date: 03/17/2018 08:19:56 ******/
ALTER TABLE [dbo].[LichSuBenh]  WITH CHECK ADD  CONSTRAINT [FK_LichSuBenh_Thuoc] FOREIGN KEY([ma_thuoc])
REFERENCES [dbo].[Thuoc] ([ma_thuoc])
GO
ALTER TABLE [dbo].[LichSuBenh] CHECK CONSTRAINT [FK_LichSuBenh_Thuoc]
GO
/****** Object:  ForeignKey [FK_VatNuoi_Chuong]    Script Date: 03/17/2018 08:19:56 ******/
ALTER TABLE [dbo].[VatNuoi]  WITH CHECK ADD  CONSTRAINT [FK_VatNuoi_Chuong] FOREIGN KEY([ma_chuong])
REFERENCES [dbo].[Chuong] ([ma_chuong])
GO
ALTER TABLE [dbo].[VatNuoi] CHECK CONSTRAINT [FK_VatNuoi_Chuong]
GO
/****** Object:  ForeignKey [FK_VatNuoi_Loai]    Script Date: 03/17/2018 08:19:56 ******/
ALTER TABLE [dbo].[VatNuoi]  WITH CHECK ADD  CONSTRAINT [FK_VatNuoi_Loai] FOREIGN KEY([ma_loai])
REFERENCES [dbo].[Loai] ([ma_loai])
GO
ALTER TABLE [dbo].[VatNuoi] CHECK CONSTRAINT [FK_VatNuoi_Loai]
GO
