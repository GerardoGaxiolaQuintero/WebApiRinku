USE [Rinku]
GO
/****** Object:  Table [dbo].[CtMes]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CtMes](
	[IdMes] [int] NOT NULL,
	[DescMes] [varchar](50) NOT NULL,
	[UsuarioCaptura] [varchar](50) NOT NULL,
	[FechaCaptura] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_CtMes] PRIMARY KEY CLUSTERED 
(
	[IdMes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CtRolEmpleado]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CtRolEmpleado](
	[idRolEmpleado] [int] NOT NULL,
	[DescRolEmpleado] [varchar](500) NOT NULL,
	[SueldoBasePH] [float] NOT NULL,
	[PagoPorEntrega] [float] NOT NULL,
	[BonoPorHora] [float] NOT NULL,
	[UsuarioCaptura] [varchar](50) NOT NULL,
	[FechaCaptura] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_CtRolEmpleado] PRIMARY KEY CLUSTERED 
(
	[idRolEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleados](
	[idEmpleado] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[ApePat] [varchar](100) NOT NULL,
	[ApeMat] [varchar](100) NOT NULL,
	[idRol] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ImpuestoExtra]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ImpuestoExtra](
	[idImpuesto] [int] IDENTITY(1,1) NOT NULL,
	[RangoMin] [float] NOT NULL,
	[RangoMax] [float] NOT NULL,
	[Porcentaje] [float] NOT NULL,
	[Anio] [char](4) NOT NULL,
	[Avtivo] [bit] NOT NULL,
 CONSTRAINT [PK_ImpuestoExtra] PRIMARY KEY CLUSTERED 
(
	[idImpuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MovimientosEmpleados]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientosEmpleados](
	[idMovimiento] [bigint] IDENTITY(1,1) NOT NULL,
	[idEmpleado] [bigint] NOT NULL,
	[idRol] [int] NOT NULL,
	[Anio] [int] NOT NULL,
	[idMes] [int] NOT NULL,
	[CantEntregas] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_MovimientosEmpleados] PRIMARY KEY CLUSTERED 
(
	[idMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Variantes]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Variantes](
	[idVariente] [int] NOT NULL,
	[DescVariante] [varchar](50) NOT NULL,
	[ValorVariante] [float] NOT NULL,
	[AnioVariante] [char](4) NOT NULL,
 CONSTRAINT [PK_Variantes] PRIMARY KEY CLUSTERED 
(
	[idVariente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_CtRolEmpleado] FOREIGN KEY([idRol])
REFERENCES [dbo].[CtRolEmpleado] ([idRolEmpleado])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_CtRolEmpleado]
GO
ALTER TABLE [dbo].[MovimientosEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosEmpleados_CtMes] FOREIGN KEY([idMes])
REFERENCES [dbo].[CtMes] ([IdMes])
GO
ALTER TABLE [dbo].[MovimientosEmpleados] CHECK CONSTRAINT [FK_MovimientosEmpleados_CtMes]
GO
ALTER TABLE [dbo].[MovimientosEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosEmpleados_Empleados] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleados] ([idEmpleado])
GO
ALTER TABLE [dbo].[MovimientosEmpleados] CHECK CONSTRAINT [FK_MovimientosEmpleados_Empleados]
GO
/****** Object:  StoredProcedure [dbo].[BorraEmpleado_U_ById]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Empleado_U_ById 4,'Yara', 'Herrera', 'Astorga', 2
*/

CREATE PROCEDURE [dbo].[BorraEmpleado_U_ById]
(
	@idEmpleado bigint 
	
)
AS
BEGIN


	update  Empleados set activo=0
	where idEmpleado=@idEmpleado


END





GO
/****** Object:  StoredProcedure [dbo].[BorraMovimientoEmpleado_D_ByIdMovimiento]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
MovimientoEmpleado_C_Nuevo 'Yara', 'Herrera', 'Astorga', 2
*/

create PROCEDURE [dbo].[BorraMovimientoEmpleado_D_ByIdMovimiento]
(
	@idMovimiento bigint
	
)
AS
BEGIN



	update MovimientosEmpleados set activo=0
	where   idMovimiento = @idMovimiento 

	

	
	
END





GO
/****** Object:  StoredProcedure [dbo].[CalculaNomina_MesAnio]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
CalculaNomina_MesAnio '2023', 1
*/

CREATE PROCEDURE [dbo].[CalculaNomina_MesAnio]
(
	@Anio char(4),
	@idMes int
)
AS
BEGIN


	select * from Empleados where (Year(fechaalta)>=@Anio and MONTH(FechaAlta) >=@idMes)


END





GO
/****** Object:  StoredProcedure [dbo].[Empleado_C_Nuevo]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Empleado_C_Nuevo 'Yara', 'Herrera', 'Astorga', 2
*/

CREATE PROCEDURE [dbo].[Empleado_C_Nuevo]
(
	@Nombre varchar(100),
	@ApePat varchar(100),
	@ApeMat varchar(100),
	@FechaAlta date,
	@idRol int
	
)
AS
BEGIN

DECLARE @id BIGINT

	insert into Empleados(Nombre, ApePat, ApeMat, idRol,FechaAlta,Activo) values (@Nombre, @ApePat, @ApeMat,@idRol,@FechaAlta,1)  

	SET @id = @@IDENTITY

	
	select @id
END





GO
/****** Object:  StoredProcedure [dbo].[Empleado_R_ById]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*

Empleado_R_ById
*/

CREATE PROCEDURE [dbo].[Empleado_R_ById]
(
	@idEmpleado bigint
	
	
)
AS
BEGIN



	select idEmpleado, Nombre, ApePat, ApeMat, idRol , E.FechaAlta, RE.DescRolEmpleado as DescRol
	from Empleados as E
	inner join CtRolEmpleado RE on RE.idRolEmpleado=E.idRol
 	where E.activo =1 and E.idEmpleado=@idEmpleado
	
END



GO
/****** Object:  StoredProcedure [dbo].[Empleado_U_ById]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
Empleado_U_ById 4,'Yara', 'Herrera', 'Astorga', 2
*/

CREATE PROCEDURE [dbo].[Empleado_U_ById]
(
	@idEmpleado int,
	@Nombre varchar(100),
	@ApePat varchar(100),
	@ApeMat varchar(100),
	@idRol int
	
)
AS
BEGIN


	update  Empleados set Nombre=@Nombre , ApePat=@ApePat, ApeMat=@ApeMat, idRol=@idRol
	where idEmpleado=@idEmpleado

	select @idEmpleado


END





GO
/****** Object:  StoredProcedure [dbo].[Empleados_R_Todos]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[Empleados_R_Todos]

AS
BEGIN



	select idEmpleado, Nombre, ApePat, ApeMat, idRol, RE.DescRolEmpleado as DescRol
	from Empleados as E
	inner join CtRolEmpleado RE on RE.idRolEmpleado=E.idRol
 	where E.activo =1
	
END



GO
/****** Object:  StoredProcedure [dbo].[ImpuestoExtra_BySueldo]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/**
ImpuestoExtra_BySueldo 10500
*/

CREATE PROCEDURE [dbo].[ImpuestoExtra_BySueldo]
(
	@Sueldo float,
	@Anio char(4)


	
)
AS
BEGIN




	select Porcentaje 
	from impuestoextra
	where rangomin <= @Sueldo and rangomax >= @Sueldo
	
END



GO
/****** Object:  StoredProcedure [dbo].[Meses_R_Todos]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
[Meses_R_Todos]
select * from CtMes
*/

CREATE PROCEDURE [dbo].[Meses_R_Todos]

AS
BEGIN



	select IdMes as id, DescMes as Descripcion
	from  CtMes 
 	where activo =1
	order by id asc
	
END



GO
/****** Object:  StoredProcedure [dbo].[Movimiento_R_ById]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*

Movimiento_R_ById 4
*/

CREATE PROCEDURE [dbo].[Movimiento_R_ById]
(
	@idMovimiento bigint
	
	
)
AS
BEGIN



	select idMovimiento, idEmpleado, idRol , Anio, idMes, CantEntregas
	from movimientosempleados
 	where activo =1 and idmovimiento=@idMovimiento
	
END



GO
/****** Object:  StoredProcedure [dbo].[MovimientoEmpleado_C_Nuevo]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
MovimientoEmpleado_C_Nuevo 'Yara', 'Herrera', 'Astorga', 2
*/

CREATE PROCEDURE [dbo].[MovimientoEmpleado_C_Nuevo]
(
	@idEmpleado bigint,
	@idRol int,
	@Anio char(4),
	@idMes int,
	@CantEntregadas int
	
)
AS
BEGIN

DECLARE @id BIGINT

	insert into MovimientosEmpleados(idEmpleado, idRol, anio, idMes, CantEntregas ,Activo) values (@idEmpleado, @idRol,@Anio, @idMes,@CantEntregadas,1)  

	SET @id = @@IDENTITY

	
	select @id
END





GO
/****** Object:  StoredProcedure [dbo].[MovimientoEmpleado_R_ByIdEmpleado]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
MovimientoEmpleado_R_ByIdEmpleado 2
*/

CREATE PROCEDURE [dbo].[MovimientoEmpleado_R_ByIdEmpleado]
(
	@idEmpleado bigint
	
	
)
AS
BEGIN



	select M.idmovimiento, M.idempleado ,M.Anio, CtR.DescRolEmpleado, CtM.DescMes, M.CantEntregas
	from movimientosEmpleados M
	inner join CtRolEmpleado CtR on  M.idRol = CtR.idRolEmpleado
	inner join CtMes CtM on CtM.IdMes=M.idMes 
 	where idempleado=@idEmpleado and  M.activo=1

	

	
	
END





GO
/****** Object:  StoredProcedure [dbo].[MovimientoEmpleado_U_ByIdMovimiento]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
MovimientoEmpleado_C_Nuevo 'Yara', 'Herrera', 'Astorga', 2
*/

CREATE PROCEDURE [dbo].[MovimientoEmpleado_U_ByIdMovimiento]
(
	@idMovimiento bigint,
	@idRol int,
	@Anio char(4),
	@idMes int,
	@CantEntregadas int
	
)
AS
BEGIN



	update MovimientosEmpleados set idRol=@idRol, idMes=@idMes, Anio=@Anio, CantEntregas= @CantEntregadas
	where   idMovimiento = @idMovimiento 

	

	
	
END





GO
/****** Object:  StoredProcedure [dbo].[NominaEmpleados_R_Todos]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/**
NominaEmpleados_R_Todos  '2023' ,  1
*/

CREATE PROCEDURE [dbo].[NominaEmpleados_R_Todos]
(
	@Anio char(4),
	@idMes int

	
)
AS
BEGIN




	select E.idEmpleado, case when ME.idRol is null then E.idRol else ME.idRol END as idRol , E.Nombre, E.ApePat, E.ApeMat, case when  ME.CantEntregas is null THEN 0 else ME.CantEntregas  END as CantEntregadas,
	RE.SueldoBasePH, RE.PagoPorEntrega, RE.BonoPorHora
	/*case when ME.CantEntregas > 0 then 192 else 0 END as HorasTrabajadas*/
		from Empleados as E
	left join movimientosEmpleados ME on  ME.idempleado = E.idEmpleado  and ME.idmes=@idMes and ME.anio = @Anio
	inner join CtRolEmpleado RE on RE.idRolEmpleado= E.idRol

	
 	where E.activo =1 
	
END



GO
/****** Object:  StoredProcedure [dbo].[Roles_R_Todos]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Roles_R_Todos
select * from ctrolempleado
*/

CREATE PROCEDURE [dbo].[Roles_R_Todos]

AS
BEGIN



	select idRolEmpleado as id, DescRolEmpleado as Descripcion
	from  CtRolEmpleado 
 	where activo =1
	
END



GO
/****** Object:  StoredProcedure [dbo].[Variantes_Todas]    Script Date: 17/04/2023 12:50:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/**
NominaEmpleados_R_Todos  '2023' ,  1
*/

create PROCEDURE [dbo].[Variantes_Todas]
(
	@Anio char(4)

	
)
AS
BEGIN




	select DescVariante, ValorVariante
	from Variantes
	 
	
END



GO
