USE [Tienda_DB]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 13/5/2023 00:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[precio] [money] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([id], [descripcion], [precio]) VALUES (1, N'Cerveza', 700.0000)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
/****** Object:  StoredProcedure [dbo].[editarProductos]    Script Date: 13/5/2023 00:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editarProductos]
@id int,
@precio money
as
update Productos
set precio = @precio
where id = @id
GO
/****** Object:  StoredProcedure [dbo].[eliminarProductos]    Script Date: 13/5/2023 00:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminarProductos]
@id int
as
delete from Productos
where id = @id
GO
/****** Object:  StoredProcedure [dbo].[insertarProductos]    Script Date: 13/5/2023 00:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertarProductos]
@descripcion varchar(50),
@precio money
as
insert into Productos
values(@descripcion, @precio)
GO
/****** Object:  StoredProcedure [dbo].[mostrarProductos]    Script Date: 13/5/2023 00:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarProductos]
as
select * from Productos
GO
