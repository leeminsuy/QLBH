USE [master]
GO
/****** Object:  Database [csdlks1245]    Script Date: 11/27/2024 12:21:36 AM ******/
CREATE DATABASE [csdlks1245]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'csdlks1245', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER1\MSSQL\DATA\csdlks1245.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'csdlks1245_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER1\MSSQL\DATA\csdlks1245_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [csdlks1245] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [csdlks1245].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [csdlks1245] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [csdlks1245] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [csdlks1245] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [csdlks1245] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [csdlks1245] SET ARITHABORT OFF 
GO
ALTER DATABASE [csdlks1245] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [csdlks1245] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [csdlks1245] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [csdlks1245] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [csdlks1245] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [csdlks1245] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [csdlks1245] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [csdlks1245] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [csdlks1245] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [csdlks1245] SET  DISABLE_BROKER 
GO
ALTER DATABASE [csdlks1245] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [csdlks1245] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [csdlks1245] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [csdlks1245] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [csdlks1245] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [csdlks1245] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [csdlks1245] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [csdlks1245] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [csdlks1245] SET  MULTI_USER 
GO
ALTER DATABASE [csdlks1245] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [csdlks1245] SET DB_CHAINING OFF 
GO
ALTER DATABASE [csdlks1245] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [csdlks1245] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [csdlks1245] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [csdlks1245] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [csdlks1245] SET QUERY_STORE = ON
GO
ALTER DATABASE [csdlks1245] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [csdlks1245]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 11/27/2024 12:21:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDichVu] [int] IDENTITY(1,1) NOT NULL,
	[TenDichVu] [nvarchar](255) NULL,
	[MoTa] [nvarchar](max) NULL,
	[DonGia] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/27/2024 12:21:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[TenKhachHang] [nvarchar](255) NULL,
	[MaSuDungPhong] [int] NULL,
	[MaSuDungDichVu] [int] NULL,
	[NgayXuatHoaDon] [datetime] NULL,
	[TongTien] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/27/2024 12:21:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](255) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[SoDienThoai] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 11/27/2024 12:21:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [int] NOT NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phong]    Script Date: 11/27/2024 12:21:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phong](
	[MaPhong] [int] IDENTITY(1,1) NOT NULL,
	[TenPhong] [nvarchar](255) NULL,
	[LoaiPhong] [nvarchar](50) NULL,
	[TrangThai] [nvarchar](50) NULL,
	[Gia] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuDungDichVu]    Script Date: 11/27/2024 12:21:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuDungDichVu](
	[MaSuDungDichVu] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[MaDichVu] [int] NULL,
	[NgaySuDung] [date] NULL,
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSuDungDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuDungPhong]    Script Date: 11/27/2024 12:21:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuDungPhong](
	[MaSuDungPhong] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[MaPhong] [int] NULL,
	[NgayThue] [date] NULL,
	[NgayTra] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSuDungPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongKeDoanhThu]    Script Date: 11/27/2024 12:21:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongKeDoanhThu](
	[TuNgay] [datetime] NOT NULL,
	[DenNgay] [datetime] NOT NULL,
	[TongDoanhThu] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ThongKeDoanhThu] PRIMARY KEY CLUSTERED 
(
	[TuNgay] ASC,
	[DenNgay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DichVu] ON 

INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [MoTa], [DonGia]) VALUES (19, N'Dọn phòng', N'dọn', CAST(555.00 AS Decimal(18, 2)))
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [MoTa], [DonGia]) VALUES (24, N'Đồ ăn ', N'gà', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [MoTa], [DonGia]) VALUES (25, N'Đồ ăn ', N'chicken', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [MoTa], [DonGia]) VALUES (26, N'Đồ ăn ', N'gà', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [MoTa], [DonGia]) VALUES (27, N'Đồ ăn ', N'kem', CAST(12222.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[DichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [TenKhachHang], [MaSuDungPhong], [MaSuDungDichVu], [NgayXuatHoaDon], [TongTien]) VALUES (41, 13, N'hu', 44, 29, CAST(N'2024-05-22T00:00:00.000' AS DateTime), CAST(215000.00 AS Decimal(18, 2)))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [TenKhachHang], [MaSuDungPhong], [MaSuDungDichVu], [NgayXuatHoaDon], [TongTien]) VALUES (43, 13, N'nguyen van a', 44, 28, CAST(N'2024-05-22T00:00:00.000' AS DateTime), CAST(212222.00 AS Decimal(18, 2)))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [TenKhachHang], [MaSuDungPhong], [MaSuDungDichVu], [NgayXuatHoaDon], [TongTien]) VALUES (45, 12, N'hu', 42, 28, CAST(N'2024-05-22T00:00:00.000' AS DateTime), CAST(13722.00 AS Decimal(18, 2)))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [TenKhachHang], [MaSuDungPhong], [MaSuDungDichVu], [NgayXuatHoaDon], [TongTien]) VALUES (46, 12, N'hu', 42, 28, CAST(N'2024-05-22T00:00:00.000' AS DateTime), CAST(13722.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (12, N'hu', N'hn', N'0355226947', N'hiep@')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [DiaChi], [SoDienThoai], [Email]) VALUES (13, N'nguyen van a', N'hn', N'0355229614', N'ha@')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[Phong] ON 

INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [LoaiPhong], [TrangThai], [Gia]) VALUES (30, N'a01', N'ba ', N'Tốt', CAST(1500.00 AS Decimal(18, 2)))
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [LoaiPhong], [TrangThai], [Gia]) VALUES (34, N'a01', N'ba ', N'Trạng thái', CAST(200000.00 AS Decimal(18, 2)))
INSERT [dbo].[Phong] ([MaPhong], [TenPhong], [LoaiPhong], [TrangThai], [Gia]) VALUES (41, N'a0355', N'đơn', N'Tốt', CAST(999999.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Phong] OFF
GO
SET IDENTITY_INSERT [dbo].[SuDungDichVu] ON 

INSERT [dbo].[SuDungDichVu] ([MaSuDungDichVu], [MaKhachHang], [MaDichVu], [NgaySuDung], [SoLuong]) VALUES (28, 13, 27, CAST(N'2024-05-21' AS Date), 3)
INSERT [dbo].[SuDungDichVu] ([MaSuDungDichVu], [MaKhachHang], [MaDichVu], [NgaySuDung], [SoLuong]) VALUES (29, 13, 24, CAST(N'2024-05-21' AS Date), 3)
SET IDENTITY_INSERT [dbo].[SuDungDichVu] OFF
GO
SET IDENTITY_INSERT [dbo].[SuDungPhong] ON 

INSERT [dbo].[SuDungPhong] ([MaSuDungPhong], [MaKhachHang], [MaPhong], [NgayThue], [NgayTra]) VALUES (42, 13, 30, CAST(N'2024-05-20' AS Date), CAST(N'2024-05-21' AS Date))
INSERT [dbo].[SuDungPhong] ([MaSuDungPhong], [MaKhachHang], [MaPhong], [NgayThue], [NgayTra]) VALUES (44, 12, 34, CAST(N'2024-05-20' AS Date), CAST(N'2024-05-20' AS Date))
INSERT [dbo].[SuDungPhong] ([MaSuDungPhong], [MaKhachHang], [MaPhong], [NgayThue], [NgayTra]) VALUES (45, 12, 30, CAST(N'2024-05-20' AS Date), CAST(N'2024-05-20' AS Date))
SET IDENTITY_INSERT [dbo].[SuDungPhong] OFF
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaSuDungPhong])
REFERENCES [dbo].[SuDungPhong] ([MaSuDungPhong])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaSuDungDichVu])
REFERENCES [dbo].[SuDungDichVu] ([MaSuDungDichVu])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SuDungDichVu]  WITH CHECK ADD FOREIGN KEY([MaDichVu])
REFERENCES [dbo].[DichVu] ([MaDichVu])
GO
ALTER TABLE [dbo].[SuDungDichVu]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[SuDungPhong]  WITH CHECK ADD FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[SuDungPhong]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[Phong] ([MaPhong])
GO
USE [master]
GO
ALTER DATABASE [csdlks1245] SET  READ_WRITE 
GO
