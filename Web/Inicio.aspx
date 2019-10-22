<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Web.Inicio" %>

<!DOCTYPE html>
<style>
    .sidebar {
	position: absolute;
	width: 210px;
	height: 100%;	
	background: #000000;
	color: #fff;
}
.sidebar ul {
	list-style: none;
	padding: 0;
	margin: 0;
}
.sidebar h2 {
	text-align: center;
	margin: 0;
	background: blue;
	padding: 10px;
}
.sidebar li {
	border: 1px solid 
}
.sidebar li:hover {
	background: #F10F64;
	
}
.sidebar a {
	display: block;
	color: #FFFFFF;
	padding: 10px;
	text-decoration: none;
}
.contenido {
	width: 100%;
	height: 100%;
	position: absolute;
	background: lightblue;
}
.menu-bar {
	cursor: pointer;
}
.abrir {
	transform: translateX(210px);
}
</style>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <div class= "navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
        <h2>   MENU  </h2>
        <ul>
         <li> <a href="#">Inicio</a></li>
         <li> <a href="#">Compras</a></li> 
         <li> <a href="#">Insumos</a></li>
         <li> <a href="#">Proveedores</a></li>   
         <li> <a href="#">Ventas</a></li>   
         <li> <a href="#">Productos</a></li>
         <li> <a href="#">Stock</a></li>   
         <li> <a href="#">Empleados</a></li>   
        </ul>
    </div>

</body>
</html>
