create database TPC_Garcia
GO
use TPC_Garcia

create table marcas
( id bigint not null primary key identity(1,1), 
  nombre varchar (100) not null,
  estado bit not null,
)

create table categorias
( id bigint not null primary key identity(1,1),
  nombre varchar (100) not null,
  estado bit not null,
)


create table insumos
(
id bigint not null primary key identity (1,1),
nombre varchar (100) not null,
stock float not null,
Medida varchar(50) not null 
estado bit not null,
)

create table proveedores
(
id bigint not null primary key identity (1,1) ,
nombre varchar (100) not null,
telefono varchar (100) null,
direccion varchar (100) null,
estado bit not null,
)

create table productos 
(
id bigint not null primary key identity (1,1),
nombre varchar (100) not null,
idMarca bigint not null foreign key references marcas(id),
idCategoria bigint not null foreign key references categorias(id),
stock float not null,
costo float not null, 
precioVenta float not null, 
ultimaActualizacion datetime not null,
estado bit not null,
)

create table formulas
( id bigint not null primary key identity (1,1),
  idProducto bigint not null foreign key references productos(id),
  idInsumo bigint not null foreign key references insumos(id),
  cantidad int not null,
  estado bit not null,
)
create table compras
(
id bigint not null primary key identity (1,1),
Proveedor varchar(100) not null,
fecha datetime not null,
formaPago varchar(50) not null,
estadoCompra varchar (50) not null,
total float null,
estado bit not null,
)
select*from detallecompra
Insert into compras values (@Proveedor,@fecha,@total, @formaPago, @estado
create table detalleCompra
(
id bigint not null primary key identity,
idCompra bigint not null foreign key references compras(id),
idInsumo bigint not null foreign key references insumos(id),
cantidad int not null,
precioUnitario float not null,
estado bit not null,
)

create table empleados
(
id bigint not null primary key identity (1,1),
dni int not null,
nombre varchar (100) not null,
apellido varchar (100) not null,
telefono varchar(50) null,
cargo varchar (50) null,
estado bit not null,
) 

create table fabricaciones
( id bigint not null primary key identity (1,1),
  idProducto bigint not null foreign key references productos(id),
  cantidad float not null,
  idEmpleado bigint not null foreign key references empleados(id),
  estado bit null,
  )

create table clientes
  (
  id bigint not null primary key identity(1,1),
  dni int not null,
  nombre varchar(100) not null,
  apellido varchar (100) not null,
  direccion varchar(100) null,
  localidad varchar(100) null,
  telefono varchar(100) null,
  estado bit not null,
  )
  insert into insumos values('Harina',0,'Kilos'),('Azucar',0,'Gramos')

  insert into proveedores values ('Vital','1167485968','Hipolito Yrigoyen 2420')

  