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

create table estados
(
id bigint not null primary key identity(1,1),
nombre varchar(50),
estado bit not null,
)
create table medidas
(
id bigint not null primary key identity(1,1),
nombre varchar(50),
estado bit not null,
)
create table insumos
(
id bigint not null primary key identity (1,1),
nombre varchar (100) not null,
stock float not null,
Medida varchar(50) not null,
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

CREATE table compras
(
id bigint not null primary key identity (1,1),
idProveedor bigint not null foreign key references proveedores(id),
fecha datetime not null,
formaPago varchar(50) not null,
estadoCompra varchar (50) not null,
total float null,
estado bit not null,
)
CREATE table detalleCompra
(
id bigint not null primary key identity,
idCompra bigint not null ,
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
insert into fabricca
create table fabricaciones
( id bigint not null primary key identity (1,1),
  idProducto bigint not null foreign key references productos(id),
  cantidad float not null,
  idEmpleado bigint not null foreign key references empleados(id),
  estadoFabricacion varchar(50),
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

  create table comentariosXcompra
  ( id bigint not null identity (1,1),
    idCompra bigint not null foreign key references compras(id),
    descripcion varchar(100)null,
)
  insert into insumos values('Harina',0,'Kilos',1),('Azucar',0,'Gramos',1)

  insert into proveedores values ('Vital','1167485968','Hipolito Yrigoyen 2420',1),('Chino',454785,'Brasil 1036',1)

  insert into medidas values 
  ('Kilos',1),
  ('Gramos',1),
  ('Miligramos',1),
  ('Litros',1),
  ('Mililitros',1)

insert into estados values ('Entregado',1),('Pedido',1),('Devolucion',1)

insert into compras values (1,GETDATE(),'Mercado Pago','Entregado',1000,1)

insert into detalleCompra values (1,1,50,1),(1,2,10,1)
