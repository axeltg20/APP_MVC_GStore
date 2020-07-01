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
	idCategoria int references TB_Categoria not null,
	stock int default(0) not null
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

create table TB_Tarjetas
(
	idTarjeta int primary key identity not null,
	idUsuario int references TB_Usuario(idUsuario) not null,
	nombreTitular varchar(MAX),
	apellidoTitular varchar(MAX),
	nroTarjeta char(16),
	fechaExpiracion date,
	ccv char(3),
	saldo int default 100000
)
go

/*****************************************************************************************************
******************************************Creacion Procedures*****************************************
*****************************************************************************************************/

/*Procedicimientos Almacenados CRUD Producto*/
CREATE OR ALTER PROC usp_Admin_ListarProducto
AS
BEGIN
	SELECT p.idProd, p.nomProd, p.precio, p.descripcion, p.foto,c.nomCategoria, p.stock FROM TB_Producto p INNER JOIN tb_categoria c ON p.idCategoria = c.idCategoria
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
	DELETE TB_Producto WHERE idProd = @id
END
GO

/*Procedicimientos Almacenados CRUD Categoria*/

CREATE OR ALTER PROC usp_ListarCategoria
AS
BEGIN
	SELECT idCategoria,nomCategoria FROM TB_Categoria
END
GO

CREATE OR ALTER PROC usp_Admin_CrearCategoria
@nombre VARCHAR(30)
AS
BEGIN
	INSERT INTO TB_Categoria (nomCategoria) VALUES (@nombre)
END
GO

CREATE OR ALTER PROC usp_Admin_ActualizaCategoria
@idcat INT,
@nombre VARCHAR(30)
AS
BEGIN
	UPDATE TB_Categoria SET nomCategoria=@nombre WHERE idCategoria=@idcat
END
GO

CREATE OR ALTER PROC usp_Admin_EliminaCategoria
@idcat INT
AS
BEGIN
	DELETE TB_Categoria WHERE idCategoria=@idcat
END
GO

/*Procedimientos Almacenados*/

create or alter proc usp_ListarProducto
as
begin
	select idProd, nomProd, precio, nomCategoria, stock from TB_Producto p inner join tb_categoria c on p.idCategoria = c.idCategoria
end
go

create or alter proc usp_Logueo
@email varchar(250),
@contra varchar(15)
as
begin
	select email, contra from TB_Usuario where email = @email and contra = @contra
end
go

create or alter proc usp_AgregarCarrito
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

create or alter proc usp_AgregarTarjeta
	@idUsuario int,
	@nombreTitular varchar(MAX),
	@apellidoTitular varchar(MAX),
	@nroTarjeta char(16),
	@fechaExpiracion date,
	@ccv char(3)
as
begin
	insert into TB_Tarjetas(idUsuario,nombreTitular,apellidoTitular,nroTarjeta,fechaExpiracion,ccv)
	values(@idUsuario,@nombreTitular,@apellidoTitular,@nroTarjeta,@fechaExpiracion,@ccv)
end
go

create or alter procedure usp_Pagar
@idTarjeta int,
@total int
as
begin
	update TB_tarjetas set saldo = saldo - @total where idTarjeta = @idTarjeta
end
go
create or alter procedure usp_listarTarjetas
@idUsuario int
as
begin
	select * from TB_Tarjetas where idUsuario = @idUsuario
end
go

/*****************************************************************************************************
******************************************Agregado de Datos*******************************************
*****************************************************************************************************/

/*Usuario Administrador*/
INSERT INTO TB_Usuario VALUES('admin', 'sote', null,'admin@gmail.com', 1, null, 'admin')
GO

/*Categorias*/
exec usp_Admin_CrearCategoria 'Videojuegos'
exec usp_Admin_CrearCategoria 'Consolas'
exec usp_Admin_CrearCategoria 'Procesadores'
exec usp_Admin_CrearCategoria 'Tarjetas de video'

/*Productos*/
exec usp_Admin_InsertaProducto 'RTX 2080 Ti', 5000,'Tarjeta de Vide Nvidia RTX 2080 Ti', 4, 10
exec usp_Admin_InsertaProducto 'Intel Core i9 9900k', 3400,'Procesador Intel Core I9 9900K',3, 10

/*****************************************************************************************************
******************************************Ejecucion Procedures****************************************
*****************************************************************************************************/

/*Procedures Admin Producto*/
EXEC usp_Admin_InsertaProducto 'Nvdia GTX 1050 Ti', 700.00,'Tarjeta de Video Nvidia GTX 1050 TI 4GB' ,4, 10
GO
EXEC usp_Admin_ActualizaProducto 6,'Nvdia GTX 1060', 900.00,'Tarjeta de Video Nvidia GTX 1060 3GB' ,4, 15
EXEC usp_Admin_ListarProducto
GO

/*Procedures Categoria*/
EXEC usp_Admin_CrearCategoria 'Memoria RAM'
GO
EXEC usp_Admin_ActualizaCategoria 5,'Memorias RAM'
GO
EXEC usp_Admin_EliminaCategoria 5
GO
EXEC usp_ListarCategoria
GO

--Ejecutar los procedures

exec usp_AgregarTarjeta 1, 'admin', 'sote', '1234567890123456', '18/01/20', '123'
--exec usp_AgregarTarjeta 2, 'admin', 'soteasd', '1234567890123456', '18/01/20', '123' 
exec usp_Pagar 1, 1000.50
exec usp_listarTarjetas 1
select * from TB_Usuario
select * from TB_Tarjetas
GO