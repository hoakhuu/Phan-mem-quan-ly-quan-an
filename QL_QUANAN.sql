USE [master]
GO
/****** Object:  Database [QUANLY_NHAHANG]    Script Date: 09/01/2023 10:26:27 CH ******/
CREATE DATABASE [QUANLY_NHAHANG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUANLY_NHAHANG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QUANLY_NHAHANG.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QUANLY_NHAHANG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QUANLY_NHAHANG_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QUANLY_NHAHANG] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUANLY_NHAHANG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUANLY_NHAHANG] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET  MULTI_USER 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUANLY_NHAHANG] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QUANLY_NHAHANG] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QUANLY_NHAHANG] SET QUERY_STORE = OFF
GO
USE [QUANLY_NHAHANG]
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_CTHD]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_CTHD]()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(MACTHD) FROM CTHD) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(MACTHD, 1)) FROM CTHD
		SELECT @ID = CASE
			WHEN @ID >= 0 THEN 'KH' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			
		END
	RETURN @ID
END
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ban](
	[MaDatBan] [varchar](10) NOT NULL,
	[SoBan] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDatBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mon]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mon](
	[MaMon] [varchar](10) NOT NULL,
	[Tenmon] [nvarchar](100) NOT NULL,
	[Trangthai] [nvarchar](50) NOT NULL,
	[DonGia] [int] NOT NULL,
	[Hinh] [varchar](max) NOT NULL,
	[Maloai] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[Mahd] [varchar](10) NOT NULL,
	[Ngaytao] [date] NOT NULL,
	[Manv] [varchar](10) NOT NULL,
	[MaDatBan] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Mahd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[Sl] [int] NOT NULL,
	[Thanhtien] [int] NOT NULL,
	[MaMon] [varchar](10) NOT NULL,
	[Mahd] [varchar](10) NOT NULL,
	[MaCTHD] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCTHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[BienLai]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[BienLai]
as
select m.Tenmon,m.DonGia,sum(Sl) as SoLuong,sum(ThanhTien) as ThanhTien ,h.Mahd
from HoaDon h, CTHD c, Ban b, Mon m 
where  b.MaDatBan=h.MaDatBan and c.Mahd=h.Mahd and m.MaMon = c.MaMon 
group by m.Tenmon, m.DonGia,h.Mahd
GO
/****** Object:  Table [dbo].[Đặt]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Đặt](
	[NgayDat] [date] NOT NULL,
	[MaDatBan] [varchar](10) NOT NULL,
	[Makh] [varchar](10) NOT NULL,
	[TrangThai] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Duockhuyenmai]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duockhuyenmai](
	[ThoiGianBD] [date] NOT NULL,
	[ThoigianKT] [date] NOT NULL,
	[MaMon] [varchar](10) NOT NULL,
	[MaKM] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC,
	[MaKM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[Makh] [varchar](10) NOT NULL,
	[Tenkh] [nvarchar](50) NOT NULL,
	[Sdt] [varchar](16) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Makh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[MaKM] [varchar](10) NOT NULL,
	[TenKM] [nvarchar](50) NOT NULL,
	[Giam] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LichSu]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LichSu](
	[MaLichSu] [varchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[Ngay] [date] NOT NULL,
	[Gio] [time](7) NOT NULL,
	[ThanhToan] [int] NULL,
	[SoBan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLichSu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loai]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[Maloai] [varchar](10) NOT NULL,
	[Tenloai] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Maloai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[maLogin] [varchar](10) NOT NULL,
	[Tenlogin] [varchar](50) NOT NULL,
	[Matkhau] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 09/01/2023 10:26:27 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[Manv] [varchar](10) NOT NULL,
	[Tennv] [nvarchar](50) NOT NULL,
	[Ngaysinh] [date] NOT NULL,
	[Gioitinh] [nvarchar](20) NOT NULL,
	[Sdt] [varchar](8) NOT NULL,
	[maLogin] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B01', 1)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B010', 10)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B011', 11)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B012', 12)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B013', 13)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B014', 14)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B015', 15)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B02', 2)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B03', 3)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B04', 4)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B05', 5)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B06', 6)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B07', 7)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B08', 8)
INSERT [dbo].[Ban] ([MaDatBan], [SoBan]) VALUES (N'B09', 9)
GO
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 343332, N'M003', N'H010', N'C010')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 11000, N'M003', N'H010', N'C011')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (3, 150000, N'M003', N'H010', N'C012')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (3, 30000, N'M006', N'H011', N'C016')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (5, 75000, N'M013', N'H011', N'C017')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 30000, N'M018', N'H011', N'C018')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 20000, N'M014', N'H08', N'C019')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 30000, N'M007', N'H08', N'C020')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 30000, N'M007', N'H09', N'C021')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (3, 45000, N'M018', N'H09', N'C023')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (4, 160000, N'M010', N'H012', N'C025')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (1, 15000, N'M016', N'H012', N'C026')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 50000, N'M008', N'H013', N'C027')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (3, 45000, N'M013', N'H013', N'C028')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (4, 40000, N'M007', N'H013', N'C030')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 80000, N'M010', N'H014', N'C031')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (4, 36000, N'M020', N'H014', N'C033')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (3, 150000, N'M005', N'H013', N'C034')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 30000, N'M007', N'H013', N'C035')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 30000, N'M013', N'H013', N'C036')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 30000, N'M016', N'H013', N'C038')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 100000, N'M003', N'H014', N'C039')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (3, 120000, N'M010', N'H014', N'C040')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 30000, N'M007', N'H014', N'C041')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (4, 160000, N'M010', N'H015', N'C042')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 20000, N'M006', N'H015', N'C043')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (4, 40000, N'M014', N'H015', N'C044')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (3, 27000, N'M020', N'H015', N'C045')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (4, 40000, N'M015', N'H016', N'C046')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (4, 32000, N'M019', N'H016', N'C047')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 30000, N'M012', N'H016', N'C048')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 100000, N'M003', N'H07', N'C049')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 30000, N'M012', N'H013', N'C050')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 11000, N'M003', N'H010', N'C08')
INSERT [dbo].[CTHD] ([Sl], [Thanhtien], [MaMon], [Mahd], [MaCTHD]) VALUES (2, 11000, N'M003', N'H010', N'C09')
GO
INSERT [dbo].[Đặt] ([NgayDat], [MaDatBan], [Makh], [TrangThai]) VALUES (CAST(N'2022-12-02' AS Date), N'B02', N'K025', N'2')
INSERT [dbo].[Đặt] ([NgayDat], [MaDatBan], [Makh], [TrangThai]) VALUES (CAST(N'2022-12-02' AS Date), N'B09', N'K024', N'2')
INSERT [dbo].[Đặt] ([NgayDat], [MaDatBan], [Makh], [TrangThai]) VALUES (CAST(N'2022-12-02' AS Date), N'B08', N'K018', N'2')
INSERT [dbo].[Đặt] ([NgayDat], [MaDatBan], [Makh], [TrangThai]) VALUES (CAST(N'2022-12-02' AS Date), N'B06', N'K020', N'2')
GO
INSERT [dbo].[HoaDon] ([Mahd], [Ngaytao], [Manv], [MaDatBan]) VALUES (N'H010', CAST(N'2022-12-03' AS Date), N'NV0001', N'B014')
INSERT [dbo].[HoaDon] ([Mahd], [Ngaytao], [Manv], [MaDatBan]) VALUES (N'H011', CAST(N'2022-12-03' AS Date), N'NV0001', N'B01')
INSERT [dbo].[HoaDon] ([Mahd], [Ngaytao], [Manv], [MaDatBan]) VALUES (N'H012', CAST(N'2022-12-03' AS Date), N'NV0001', N'B03')
INSERT [dbo].[HoaDon] ([Mahd], [Ngaytao], [Manv], [MaDatBan]) VALUES (N'H013', CAST(N'2022-12-03' AS Date), N'NV0001', N'B04')
INSERT [dbo].[HoaDon] ([Mahd], [Ngaytao], [Manv], [MaDatBan]) VALUES (N'H014', CAST(N'2022-12-03' AS Date), N'NV0002', N'B08')
INSERT [dbo].[HoaDon] ([Mahd], [Ngaytao], [Manv], [MaDatBan]) VALUES (N'H015', CAST(N'2022-12-03' AS Date), N'NV0001', N'B010')
INSERT [dbo].[HoaDon] ([Mahd], [Ngaytao], [Manv], [MaDatBan]) VALUES (N'H016', CAST(N'2022-12-03' AS Date), N'NV0001', N'B06')
INSERT [dbo].[HoaDon] ([Mahd], [Ngaytao], [Manv], [MaDatBan]) VALUES (N'H07', CAST(N'2022-12-03' AS Date), N'NV0001', N'B02')
INSERT [dbo].[HoaDon] ([Mahd], [Ngaytao], [Manv], [MaDatBan]) VALUES (N'H08', CAST(N'2022-12-03' AS Date), N'NV0001', N'B07')
INSERT [dbo].[HoaDon] ([Mahd], [Ngaytao], [Manv], [MaDatBan]) VALUES (N'H09', CAST(N'2022-12-03' AS Date), N'NV0001', N'B015')
GO
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K01', N'Đặng Ngọc Tuân', N'0961605643')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K010', N'Khánh Vân', N'093456764')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K011', N'Khuu Van Hòa', N'0923510618')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K012', N'Kim Ngân', N'0926465262')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K013', N'Hà Giang', N'12345565')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K014', N'Trần Thanh Tâm', N'0125416654')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K015', N'Hà Anh Tuấn', N'09564112542')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K016', N'Thanh Hằng', N'0964524656')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K017', N'Bùi Thị Xuân', N'012546857')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K018', N'Trần Thành', N'0165487254')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K019', N'Hồ Ngọc Hà', N'012565774')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K02', N'Ngô Thị Tính', N'0329120655')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K020', N'Mỹ Tâm', N'0125468412')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K021', N'Van Hoa', N'84736484')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K022', N'Tran Thanh', N'09453234')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K023', N'Ngoc Anh', N'06743456')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K024', N'Ngoc Trinh', N'08674545')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K025', N'Bao Ngoc Anh', N'095453434')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K026', N'Tran Thanh My Ai', N'05342345')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K027', N'Ly Nha Ky', N'096745345')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K028', N'Tran Ngoc Anh', N'09563434')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K03', N'Lê Ngọc Trinh', N'0927362729')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K04', N'Nguyễn Văn Khôi', N'0326489524')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K05', N'Phạm Văn Hào', N'0961478965')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K06', N'fgfg', N'3444')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K07', N'fgfghfg', N'fgggg5555555555')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K08', N'La Thanh Thanh', N'1234556')
INSERT [dbo].[KhachHang] ([Makh], [Tenkh], [Sdt]) VALUES (N'K09', N'Lê Anh Thu', N'0978476352')
GO
INSERT [dbo].[KhuyenMai] ([MaKM], [TenKM], [Giam]) VALUES (N'KM001', N'NOEN', 20)
INSERT [dbo].[KhuyenMai] ([MaKM], [TenKM], [Giam]) VALUES (N'KM002', N'Năm mới', 25)
INSERT [dbo].[KhuyenMai] ([MaKM], [TenKM], [Giam]) VALUES (N'KM003', N'Thứ 6/13', 10)
INSERT [dbo].[KhuyenMai] ([MaKM], [TenKM], [Giam]) VALUES (N'KM004', N'Black friday', 20)
GO
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q010', N'Van Hoa', CAST(N'2022-12-20' AS Date), CAST(N'10:48:46' AS Time), 294000, 2)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q011', N'Tran Thanh', CAST(N'2022-12-25' AS Date), CAST(N'22:59:49' AS Time), 309000, 2)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q012', N'Ngoc Anh', CAST(N'2022-12-25' AS Date), CAST(N'23:07:03' AS Time), 100000, 2)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q013', N'Tr?n Thanh Tâm', CAST(N'2022-12-25' AS Date), CAST(N'23:07:33' AS Time), 470000, 4)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q014', N'Tran Thanh My Ai', CAST(N'2022-12-25' AS Date), CAST(N'23:22:46' AS Time), 405000, 4)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q015', N'H? Ng?c Hà', CAST(N'2022-12-25' AS Date), CAST(N'23:35:55' AS Time), 247000, 10)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q02', N'Khánh Vân', CAST(N'2022-11-12' AS Date), CAST(N'22:31:14' AS Time), 526332, 14)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q03', N'La Thanh Thanh', CAST(N'2022-12-12' AS Date), CAST(N'15:13:34' AS Time), 255000, 7)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q05', N'Kim Ngân', CAST(N'2022-11-12' AS Date), CAST(N'23:33:38' AS Time), 135000, 1)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q06', N'Hà Giang', CAST(N'2022-12-13' AS Date), CAST(N'00:23:40' AS Time), 50000, 7)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q07', N'Lê Anh Thu', CAST(N'2022-10-16' AS Date), CAST(N'12:30:00' AS Time), 175000, 3)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q08', N'Bùi Th? Xuân', CAST(N'2022-12-17' AS Date), CAST(N'11:08:41' AS Time), 146000, 8)
INSERT [dbo].[LichSu] ([MaLichSu], [TenKH], [Ngay], [Gio], [ThanhToan], [SoBan]) VALUES (N'Q09', N'Ph?m Van Hào', CAST(N'2022-12-17' AS Date), CAST(N'20:29:33' AS Time), 75000, 15)
GO
INSERT [dbo].[Loai] ([Maloai], [Tenloai]) VALUES (N'L002', N'Hải sản')
INSERT [dbo].[Loai] ([Maloai], [Tenloai]) VALUES (N'L003', N'Nông sản')
INSERT [dbo].[Loai] ([Maloai], [Tenloai]) VALUES (N'L004', N'Giải khát')
INSERT [dbo].[Loai] ([Maloai], [Tenloai]) VALUES (N'L005', N'Tráng miệng')
GO
INSERT [dbo].[Login] ([maLogin], [Tenlogin], [Matkhau]) VALUES (N'01', N'llal', N'lala')
INSERT [dbo].[Login] ([maLogin], [Tenlogin], [Matkhau]) VALUES (N'02', N'khanh12', N'khanh')
INSERT [dbo].[Login] ([maLogin], [Tenlogin], [Matkhau]) VALUES (N'03', N'ngoc23', N'ngoc')
INSERT [dbo].[Login] ([maLogin], [Tenlogin], [Matkhau]) VALUES (N'04', N'la23', N'la')
GO
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M001', N'Nghêu hấp xả', N'còn', 20000, N'cach-lam-ngao-hap-sa-ot-dam-da-nong-hoi-ca-nha-me-tit-202006291324239176 (1).jpg', N'L002')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M002', N'Ốc xào me', N'còn', 30000, N'cach-lam-oc-xao-me (2).jpg', N'L002')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M003', N'Mực xào trứng', N'còn', 50000, N'imager_24 (1).jpg', N'L002')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M004', N'Sò điệp hấp ', N'còn', 57000, N'so-diep-nuong-mo-hanh (1).jpg', N'L002')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M005', N'Lươn Xào Cay', N'còn', 50000, N'luon-xao (1).jpg', N'L002')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M006', N'Rau muống luộc', N'còn', 10000, N'luoc-rau-muong-khong-bi-den (2).jpg', N'L003')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M007', N'Thit kho', N'còn', 10000, N'7069c91882d1c4d7b7657ec766e3e492 (1).jpg', N'L003')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M008', N'Xườn xào ngọt', N'còn', 25000, N'Suon-xao-chua-ngot-ngon-1 (1).jpg', N'L003')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M009', N'Thịt kho tàu', N'còn', 35000, N'7069c91882d1c4d7b7657ec766e3e492 (1).jpg', N'L003')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M010', N'Thịt nướng', N'còn', 40000, N'maxresdefault (1).jpg', N'L003')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M011', N'Pepsi', N'còn', 5000, N'6a43a966-86ad-4f92-894b-6b6c76235546 (1).jpg', N'L004')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M012', N'Cocacola', N'còn', 15000, N'f13fe8229ae06ebe37f1 (1).jpg', N'L004')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M013', N'Cafe', N'còn', 15000, N'cafe-Americano-1 (1).jpg', N'L004')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M014', N'Sting', N'còn', 10000, N'6-lon-nuoc-t061732537179 (1).jpg', N'L004')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M015', N'Wake up 247', N'còn', 10000, N'nuoc-tang-luc-wake-up-247-vi-ca-phe-co-ngon-khong-202112300701283850 (1).jpg', N'L004')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M016', N'Xoài', N'còn', 15000, N'qua_xoai_1 (1).jpg', N'L005')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M017', N'Táo', N'còn', 10000, N'tao-do-2-6-16-794-709-1623469683 (1).jpg', N'L005')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M018', N'Lê', N'còn', 15000, N'an-qua-le-co-tac-dung-gi-4 (1).jpg', N'L005')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M019', N'Dưa hấu', N'còn', 8000, N'dua-hau-16682703712011380946081 (1).jpg', N'L005')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M020', N'Lựu', N'còn', 9000, N'cach-chon-mua-qua-luu-ngon-do-chac-tay-va-mong-nuoc-cuc-don-avt-1200x6761-1648395872120641017349 (1).jpg', N'L005')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M021', N'Thit  Bo', N'còn', 3333333, N'maxresdefault (1).jpg', N'L003')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M022', N'nuoc cam', N'còn', 34523, N'6a43a966-86ad-4f92-894b-6b6c76235546 (1).jpg', N'L002')
INSERT [dbo].[Mon] ([MaMon], [Tenmon], [Trangthai], [DonGia], [Hinh], [Maloai]) VALUES (N'M023', N'Nuoc Cam', N'còn', 234534, N'qua_xoai_1 (1).jpg', N'L003')
GO
INSERT [dbo].[NhanVien] ([Manv], [Tennv], [Ngaysinh], [Gioitinh], [Sdt], [maLogin]) VALUES (N'NV0001', N'Nguyễn Hương Ly', CAST(N'1998-10-03' AS Date), N'Nam', N'0961', N'01')
INSERT [dbo].[NhanVien] ([Manv], [Tennv], [Ngaysinh], [Gioitinh], [Sdt], [maLogin]) VALUES (N'NV0002', N'Thủy Tiên', CAST(N'1997-10-25' AS Date), N'Nữ', N'0329', N'02')
INSERT [dbo].[NhanVien] ([Manv], [Tennv], [Ngaysinh], [Gioitinh], [Sdt], [maLogin]) VALUES (N'NV0003', N'Thảo Nhi Lê', CAST(N'1997-03-25' AS Date), N'Nữ', N'03294', N'03')
INSERT [dbo].[NhanVien] ([Manv], [Tennv], [Ngaysinh], [Gioitinh], [Sdt], [maLogin]) VALUES (N'NV0004', N'Ngọc Châu', CAST(N'1999-10-04' AS Date), N'Nam', N'0325', N'04')
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [fk_CTHD] FOREIGN KEY([MaMon])
REFERENCES [dbo].[Mon] ([MaMon])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [fk_CTHD]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD  CONSTRAINT [fk_CTHD1] FOREIGN KEY([Mahd])
REFERENCES [dbo].[HoaDon] ([Mahd])
GO
ALTER TABLE [dbo].[CTHD] CHECK CONSTRAINT [fk_CTHD1]
GO
ALTER TABLE [dbo].[Đặt]  WITH CHECK ADD FOREIGN KEY([MaDatBan])
REFERENCES [dbo].[Ban] ([MaDatBan])
GO
ALTER TABLE [dbo].[Đặt]  WITH CHECK ADD FOREIGN KEY([Makh])
REFERENCES [dbo].[KhachHang] ([Makh])
GO
ALTER TABLE [dbo].[Duockhuyenmai]  WITH CHECK ADD FOREIGN KEY([MaMon])
REFERENCES [dbo].[Mon] ([MaMon])
GO
ALTER TABLE [dbo].[Duockhuyenmai]  WITH CHECK ADD FOREIGN KEY([MaKM])
REFERENCES [dbo].[KhuyenMai] ([MaKM])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaDatBan])
REFERENCES [dbo].[Ban] ([MaDatBan])
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([Manv])
REFERENCES [dbo].[NhanVien] ([Manv])
GO
ALTER TABLE [dbo].[Mon]  WITH CHECK ADD FOREIGN KEY([Maloai])
REFERENCES [dbo].[Loai] ([Maloai])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([maLogin])
REFERENCES [dbo].[Login] ([maLogin])
GO
/****** Object:  StoredProcedure [dbo].[getBan]    Script Date: 09/01/2023 10:26:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getBan]
as
select *
from Ban
GO
/****** Object:  StoredProcedure [dbo].[getBanDaDat]    Script Date: 09/01/2023 10:26:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getBanDaDat]
as

select b.MaDatBan, d.TrangThai,b.SoBan
from Ban b full outer join  Đặt d
on b.MaDatBan = d.MaDatBan
ORDER BY SoBan
GO
/****** Object:  StoredProcedure [dbo].[getMenu]    Script Date: 09/01/2023 10:26:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getMenu]
as
select *
from Mon
GO
/****** Object:  StoredProcedure [dbo].[InsertCTHD]    Script Date: 09/01/2023 10:26:28 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[InsertCTHD] @soluong int, @thanhtien int, @mmon varchar(10), @mahd varchar(10)
as
	insert into CTHD values(@soluong,@thanhtien,@mmon,@mahd)
GO
USE [master]
GO
ALTER DATABASE [QUANLY_NHAHANG] SET  READ_WRITE 
GO
