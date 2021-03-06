CREATE DATABASE Empresa

USE [Empresa]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 25/7/2018 18:59:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[idempleado] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](40) NULL,
	[apellido] [varchar](50) NULL,
	[dui] [varchar](10) NULL,
	[direccion] [varchar](255) NULL,
	[telefono] [varchar](9) NULL,
	[fechaIngreso] [date] NULL,
	[salario] [float] NULL,
	[idoficina] [int] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[idempleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oficina]    Script Date: 25/7/2018 18:59:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oficina](
	[idoficina] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[telefono] [varchar](9) NULL,
	[direccion] [varchar](255) NULL,
	[nombreofi] [varchar](100) NULL,
 CONSTRAINT [PK_Oficina] PRIMARY KEY CLUSTERED 
(
	[idoficina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Empleado] FOREIGN KEY([idempleado])
REFERENCES [dbo].[Empleado] ([idempleado])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Empleado]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Oficina] FOREIGN KEY([idoficina])
REFERENCES [dbo].[Oficina] ([idoficina])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Oficina]
GO
