create database TPC_Garcia
GO
use TPC_Garcia

create table marcas
( id bigint not null primary key identity(1,1), 
  nombre varchar (100) not null,
)


create table categorias
( id bigint not null primary key identity(1,1),
  nombre varchar (100) not null,
)

create table tipos 
( 
id bigint not null primary key identity(1,1),
nombre varchar(100) not null,
) 

create table insumos
(
id bigint not null primary key identity (1,1),
nombre varchar (100) not null,
stock int not null,
Medida varchar(50) not null 
)

create table proveedores
(
id bigint not null primary key identity (1,1) ,
nombre varchar (100) not null,
telefono varchar (100) null,
direccion varchar (100) null,
)

create table productos 
(
id bigint not null primary key identity (1,1),
nombre varchar (100) not null,
idMarca bigint not null foreign key references marcas(id),
idCategoria bigint not null foreign key references categorias(id),
idTipo bigint not null foreign key references tipos (id),
stock int null,
costo int null, 
precioVenta int null, 
ultimaActualizacion datetime not null,
estado bit not null,
)

create table formulas
( id bigint not null primary key identity (1,1),
  idProducto bigint not null foreign key references productos(id),
  idInsumo bigint not null foreign key references insumos(id),
  cantidad int not null,
)

create table compras
(
id bigint not null primary key identity (1,1),
idProveedor bigint not null foreign key references proveedores(id),
fecha datetime not null,
total int null,
)


create table detalleCompra
(
id bigint not null primary key identity,
idCompra bigint not null foreign key references compras(id),
idInsumo bigint not null foreign key references insumos(id),
cantidad int not null,
precioUnitario float not null,
)

create table empleados
(
id bigint not null primary key identity (1,1),
nombre varchar (100) not null,
telefono varchar(50) null,
genero varchar (10) null,
) 

create table fabricaciones
( id bigint not null primary key identity (1,1),
  idProducto bigint not null foreign key references productos(id),
  cantidad int not null,
  idEmpleado bigint not null foreign key references empleados(id),
  )

  insert into insumos values('Harina',0,'Kilos'),('Azucar',0,'Gramos')

  insert into proveedores values ('Vital','1167485968','Hipolito Yrigoyen 2420')

