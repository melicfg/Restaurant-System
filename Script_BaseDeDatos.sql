USE [master]
GO

CREATE DATABASE [RESTUNED]
 GO
 
USE [RESTUNED]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Restaurante](
	[IdRestaurante] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Direccion] [varchar](255) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Restaurante] PRIMARY KEY CLUSTERED 
(
	[IdRestaurante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[IdCliente] [varchar](10) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[PrimerApellido] [varchar](255) NOT NULL,
	[SegundoApellido] [varchar](255) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Genero] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaPlato](
	[IdCategoria] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_CategoriaPlato] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Plato](
	[IdPlato] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Precio] [int] NOT NULL,
 CONSTRAINT [PK_Plato] PRIMARY KEY CLUSTERED 
(
	[IdPlato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Plato]  WITH CHECK ADD  CONSTRAINT [FK_Plato_CategoriaPlato] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CategoriaPlato] ([IdCategoria])
GO

ALTER TABLE [dbo].[Plato] CHECK CONSTRAINT [FK_Plato_CategoriaPlato]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlatoRestaurante](
	[IdAsignacion] [int] NOT NULL,
	[IdRestaurante] [int] NOT NULL,
	[IdPlato] [int] NOT NULL,
	[FechaAsignacion] [datetime] NOT NULL,
 CONSTRAINT [PK_PlatoRestaurante] PRIMARY KEY CLUSTERED 
(
	[IdRestaurante] ASC,
	[IdPlato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PlatoRestaurante]  WITH CHECK ADD  CONSTRAINT [FK_PlatoRestaurante_Restaurante] FOREIGN KEY([IdRestaurante])
REFERENCES [dbo].[Restaurante] ([IdRestaurante])
GO

ALTER TABLE [dbo].[PlatoRestaurante] CHECK CONSTRAINT [FK_PlatoRestaurante_Restaurante]
GO

ALTER TABLE [dbo].[PlatoRestaurante]  WITH CHECK ADD  CONSTRAINT [FK_PlatoRestaurante_Plato] FOREIGN KEY([IdPlato])
REFERENCES [dbo].[Plato] ([IdPlato])
GO

ALTER TABLE [dbo].[PlatoRestaurante] CHECK CONSTRAINT [FK_PlatoRestaurante_Plato]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Extra](
	[IdExtra] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Precio] [int] NOT NULL,
 CONSTRAINT [PK_Extra] PRIMARY KEY CLUSTERED 
(
	[IdExtra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Extra]  WITH CHECK ADD  CONSTRAINT [FK_Extra_CategoriaPlato] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[CategoriaPlato] ([IdCategoria])
GO

ALTER TABLE [dbo].[Extra] CHECK CONSTRAINT [FK_Extra_CategoriaPlato]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] NOT NULL,
	[IdCliente] [varchar](10) NULL,
	[IdPlato] [int] NOT NULL,
	[FechaPedido] [datetime] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC,
	[IdPlato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO

ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO

ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Plato] FOREIGN KEY([IdPlato])
REFERENCES [dbo].[Plato] ([IdPlato])
GO

ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Plato]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ExtraPedido](
	[IdPedido] [int] NOT NULL,
	[IdPlato] [int] NOT NULL,
	[IdExtra] [int] NOT NULL,
 CONSTRAINT [PK_ExtraPedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC,
	[IdPlato] ASC,
	[IdExtra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ExtraPedido]  WITH CHECK ADD  CONSTRAINT [FK_ExtraPedido_Pedido] FOREIGN KEY([IdPedido],[IdPlato])
REFERENCES [dbo].[Pedido] ([IdPedido],[IdPlato])
GO

ALTER TABLE [dbo].[ExtraPedido] CHECK CONSTRAINT [FK_ExtraPedido_Pedido]
GO
/*
ALTER TABLE [dbo].[ExtraPedido]  WITH CHECK ADD  CONSTRAINT [FK_ExtraPedido_Plato] FOREIGN KEY([IdPlato])
REFERENCES [dbo].[Plato] ([IdPlato])
GO

ALTER TABLE [dbo].[ExtraPedido] CHECK CONSTRAINT [FK_ExtraPedido_Plato]
GO
*/
ALTER TABLE [dbo].[ExtraPedido]  WITH CHECK ADD  CONSTRAINT [FK_ExtraPedido_Extra] FOREIGN KEY([IdExtra])
REFERENCES [dbo].[Extra] ([IdExtra])
GO

ALTER TABLE [dbo].[ExtraPedido] CHECK CONSTRAINT [FK_ExtraPedido_Extra]
GO
