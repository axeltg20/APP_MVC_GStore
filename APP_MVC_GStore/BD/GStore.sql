/*Crear la BD*/
if db_ID('GameStore') is not null
	begin
		use master 
		drop database GameStore
	end
GO

create database GameStore
go

use GameStore
GO

/*Establecer formato de fecha*/
set dateformat DMY
go

/*Tabla Categoria*/
create table TB_Categoria
(
idCategoria int primary key identity,
nomCategoria varchar(20) not null
)
go

/*Tabla Producto*/
create table TB_Producto
(
	idProd int primary key identity,
	nomProd varchar(70) not null,
	precio money not null,
	descripcion varchar(max),
	foto varchar(1024) default (N'/Content/Images/default.png'),
	idCategoria int  references TB_Categoria not null,
	stock int default(0) not null,
	estado int default(1) not null
)
go

/*Tabla Usuario*/
create table TB_Usuario
(
	idUsuario int primary key identity,
	nombre varchar(30) not null,
	apellido varchar(20) not null,
	celular varchar(9),
	email varchar(250) not null,
	emailverficiado bit DEFAULT(0),
	codigoactivacion uniqueidentifier,
	contra varchar(15) not null,
)
go

/*Tabla Direcciones*/
create table TB_Direcciones
(
	idDireccion int primary key identity not null,
	nomDireccion varchar(150) not null,
	nomDistrito varchar(50) not null,
	nomCiudad varchar(50) not null,
	idUsuario int references TB_Usuario
)
go

/*Tabla Comprobante Pago*/
Create table TB_ComprobantePago
(
	idComprobante int primary key identity not null,
	fecha date not null,
	idUsuario int references TB_Usuario not null,
	NombreCli varchar(100) not null,
	fechaCompra date,
	Destinatario varchar(50)
)
go

/*Tabla Detalle Comprobante Pago*/
Create table TB_DetalleComprobante
(
	numDetalle int primary key identity not null,
	idComprobante int references TB_ComprobantePago  not null,
	idProducto int references TB_Producto not null,
	Precio money,
	Cantidad int
)
go

/*Tabla Carrito*/
create table TB_Carrito
(
	idCarrito int primary key identity not null,
	idprod int references tb_producto,
	cantidad int
)
go

/*Procedicimientos Almacenados CRUD Producto*/
CREATE OR ALTER PROC usp_Admin_ListarProducto
AS
BEGIN
	SELECT p.idProd, p.nomProd, p.precio, p.descripcion, p.foto,c.nomCategoria, p.stock FROM TB_Producto p INNER JOIN tb_categoria c ON p.idCategoria = c.idCategoria WHERE estado = 1
END
GO

CREATE OR ALTER PROC usp_Admin_InsertaProducto
@nomProd VARCHAR(50),
@precio MONEY,
@desc VARCHAR(MAX),
@idCategoria INT,
@stock INT
AS
BEGIN
INSERT INTO TB_Producto(nomProd, precio, descripcion, idCategoria, stock)
VALUES(@nomProd, @precio, @desc,@idCategoria, @stock)
END
GO

CREATE OR ALTER PROC usp_Admin_ActualizaProducto
@id INT,
@nomProd VARCHAR(50),
@precio MONEY,
@desc VARCHAR(MAX),
@idCategoria INT,
@stock INT
AS
BEGIN
	UPDATE TB_Producto SET nomProd=@nomProd, precio=@precio, descripcion=@desc, idCategoria=@idCategoria, stock=@stock WHERE idProd = @id
END
GO

CREATE OR ALTER PROC usp_Admin_EliminarProducto
@id INT
AS
BEGIN
	UPDATE TB_Producto SET estado = 1 WHERE idProd = @id
END
GO

EXEC usp_Admin_InsertaProducto 'Nvdia GTX 1050 Ti', 700.00,'Tarjeta de Video Nvidia GTX 1050 TI 4GB' ,4, 10
GO
EXEC usp_Admin_ActualizaProducto 6,'Nvdia GTX 1060', 900.00,'Tarjeta de Video Nvidia GTX 1060 3GB' ,4, 15
EXEC usp_Admin_ListarProducto
GO
EXEC usp_Admin_EliminarProducto 6
GO

/*Procedimientos Almacenados*/

CREATE OR ALTER PROC usp_ListarCategoria
AS
BEGIN
	SELECT * FROM TB_Categoria
END
GO

create proc usp_InsertaProducto
@nomProd varchar(50),
@precio money, 
@idCategoria int,
@stock int
as
begin
insert into TB_Producto(nomProd, precio, idCategoria, stock, estado)
values(@nomProd, @precio, @idCategoria, @stock, 1)
end
go

create proc usp_ListarProducto
as
begin
	select idProd, nomProd, precio, nomCategoria, stock, estado from TB_Producto p inner join tb_categoria c on p.idCategoria = c.idCategoria where estado = 1
end
go

create proc usp_InsertarCategoria
@nomCategoria varchar(50)
as
begin
	insert into TB_Categoria(nomCategoria)
	values(@nomCategoria)
end
go

create proc usp_Logueo
@email varchar(250),
@contra varchar(15)
as
begin
	select email, contra from TB_Usuario where email = @email and contra = @contra
end
go

create proc usp_AgregarCarrito
@idProd int,
@cantidad int
as
begin
	insert into TB_Carrito(idprod, cantidad) values(@idProd, @cantidad)
end
go


create or alter proc usp_CrearUsuario
	@nombre varchar(30),
	@apellido varchar(20),
	@email varchar(250),
	@emailverif uniqueidentifier,
	@contra varchar(15)
as
begin 
	insert into TB_Usuario(nombre, apellido, email, codigoactivacion, contra)
	values(@nombre, @apellido, @email, @emailverif,@contra)
end
go



INSERT INTO TB_Usuario VALUES('admin', 'sote', null,'admin@gmail.com', 1, null, 'admin')
GO
exec usp_InsertarCategoria 'Videojuegos'
exec usp_InsertarCategoria 'Consolas'
exec usp_InsertarCategoria 'Procesadores'
exec usp_InsertarCategoria 'Tarjetas de video'
exec usp_InsertaProducto 'RTX 2080 Ti', 5000, 4, 10
exec usp_InsertaProducto 'Intel Core i9 9900k', 3400, 3, 10
exec usp_ListarProducto
select * from TB_Usuario
select * from TB_Categoria

SELECT * FROM TB_Usuario
GO

SELECT * FROM TB_Producto
GO