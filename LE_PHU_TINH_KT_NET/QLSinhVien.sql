USE [QLSinhVien]
GO
/****** Object:  Table [dbo].[DIEM]    Script Date: 12/4/2019 6:28:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIEM](
	[maSV] [nvarchar](100) NOT NULL,
	[maMonHoc] [nchar](10) NOT NULL,
	[diem] [int] NULL,
 CONSTRAINT [PK_DIEM] PRIMARY KEY CLUSTERED 
(
	[maSV] ASC,
	[maMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MONHOC]    Script Date: 12/4/2019 6:28:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONHOC](
	[maMonHoc] [nchar](10) NOT NULL,
	[tenMonHoc] [nvarchar](50) NULL,
 CONSTRAINT [PK_MONHOC] PRIMARY KEY CLUSTERED 
(
	[maMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHOM]    Script Date: 12/4/2019 6:28:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOM](
	[maNhom] [nvarchar](50) NOT NULL,
	[tenNhom] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHOM_1] PRIMARY KEY CLUSTERED 
(
	[maNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SINHVIEN]    Script Date: 12/4/2019 6:28:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SINHVIEN](
	[Ma] [nvarchar](100) NOT NULL,
	[Hoten] [nvarchar](50) NULL,
	[Gioitinh] [int] NULL,
	[Ngaysinh] [date] NULL,
	[maNhom] [nvarchar](50) NULL,
 CONSTRAINT [PK_SINHVIEN] PRIMARY KEY CLUSTERED 
(
	[Ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'001', N'cshap     ', 7)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'001', N'pascal    ', 7)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'001', N'sql       ', 8)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'005', N'cohoc     ', 9)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'005', N'dien      ', 7)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'005', N'quanghoc  ', 9)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'005', N'VLHN      ', 6)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'006', N'vancd     ', 7)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'006', N'vanhd     ', 7)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'008', N'vancd     ', 6)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'008', N'vanhd     ', 9)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'1         ', N'cshap     ', 7)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'1         ', N'pascal    ', 10)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'1         ', N'sql       ', 7)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'12', N'vancd     ', 8)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'12', N'vanhd     ', 9)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'121221', N'cshap     ', 9)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'121221', N'pascal    ', 9)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'121221', N'sql       ', 9)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'123', N'cohoc     ', 9)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'123', N'dien      ', 8)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'123', N'quanghoc  ', 10)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'123', N'VLHN      ', 7)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'3123', N'cohoc     ', 8)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'3123', N'dien      ', 9)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'3123', N'quanghoc  ', 8)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'3123', N'VLHN      ', 8)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'321', N'cshap     ', 7)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'321', N'pascal    ', 7)
INSERT [dbo].[DIEM] ([maSV], [maMonHoc], [diem]) VALUES (N'321', N'sql       ', 7)
INSERT [dbo].[MONHOC] ([maMonHoc], [tenMonHoc]) VALUES (N'cohoc     ', N'Cơ học')
INSERT [dbo].[MONHOC] ([maMonHoc], [tenMonHoc]) VALUES (N'cshap     ', N'C#')
INSERT [dbo].[MONHOC] ([maMonHoc], [tenMonHoc]) VALUES (N'dien      ', N'Điện')
INSERT [dbo].[MONHOC] ([maMonHoc], [tenMonHoc]) VALUES (N'pascal    ', N'Pascal')
INSERT [dbo].[MONHOC] ([maMonHoc], [tenMonHoc]) VALUES (N'quanghoc  ', N'Quang Học')
INSERT [dbo].[MONHOC] ([maMonHoc], [tenMonHoc]) VALUES (N'sql       ', N'SQL')
INSERT [dbo].[MONHOC] ([maMonHoc], [tenMonHoc]) VALUES (N'vancd     ', N'Văn học cổ điển')
INSERT [dbo].[MONHOC] ([maMonHoc], [tenMonHoc]) VALUES (N'vanhd     ', N'Văn học hiện đại')
INSERT [dbo].[MONHOC] ([maMonHoc], [tenMonHoc]) VALUES (N'VLHN      ', N'Vật lý hạt nhân')
INSERT [dbo].[NHOM] ([maNhom], [tenNhom]) VALUES (N'cntt      ', N'CNTT')
INSERT [dbo].[NHOM] ([maNhom], [tenNhom]) VALUES (N'van       ', N'Van')
INSERT [dbo].[NHOM] ([maNhom], [tenNhom]) VALUES (N'vatly     ', N'Vật Lý')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'001', N'anh', 1, CAST(N'2019-12-02' AS Date), N'cntt')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'005', N'anh', 1, CAST(N'2019-12-02' AS Date), N'vatly')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'006', N'hihi', 1, CAST(N'2019-12-04' AS Date), N'van')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'008', N'adv', 1, CAST(N'2019-12-02' AS Date), N'van')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'0123', N'huynh', 0, CAST(N'2019-12-04' AS Date), N'van')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'1         ', N'cong', 1, CAST(N'2019-10-10' AS Date), N'cntt      ')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'12', N'abc', 1, CAST(N'2019-12-02' AS Date), N'van')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'121221', N'hoang', 1, CAST(N'2019-12-04' AS Date), N'cntt')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'123', N'thanh', 1, CAST(N'2019-12-02' AS Date), N'vatly')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'13241', N'dang', 1, CAST(N'2019-12-04' AS Date), N'vatly')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'3123', N'hoanghoa', 1, CAST(N'2003-06-11' AS Date), N'vatly')
INSERT [dbo].[SINHVIEN] ([Ma], [Hoten], [Gioitinh], [Ngaysinh], [maNhom]) VALUES (N'321', N'tinh', 1, CAST(N'2019-12-04' AS Date), N'cntt')
ALTER TABLE [dbo].[DIEM]  WITH CHECK ADD  CONSTRAINT [FK_DIEM_MONHOC] FOREIGN KEY([maMonHoc])
REFERENCES [dbo].[MONHOC] ([maMonHoc])
GO
ALTER TABLE [dbo].[DIEM] CHECK CONSTRAINT [FK_DIEM_MONHOC]
GO
ALTER TABLE [dbo].[DIEM]  WITH CHECK ADD  CONSTRAINT [FK_DIEM_SINHVIEN] FOREIGN KEY([maSV])
REFERENCES [dbo].[SINHVIEN] ([Ma])
GO
ALTER TABLE [dbo].[DIEM] CHECK CONSTRAINT [FK_DIEM_SINHVIEN]
GO
ALTER TABLE [dbo].[SINHVIEN]  WITH CHECK ADD  CONSTRAINT [FK_SINHVIEN_NHOM1] FOREIGN KEY([maNhom])
REFERENCES [dbo].[NHOM] ([maNhom])
GO
ALTER TABLE [dbo].[SINHVIEN] CHECK CONSTRAINT [FK_SINHVIEN_NHOM1]
GO
