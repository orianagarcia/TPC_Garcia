<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="WebAplication.prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        *{
            margin: 0;
            padding: 0;
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;

        }
        body {
            background-color: antiquewhite;
            font-size-adjust: initial;
        }
        .navbar {
            width: 100%;
            background: lightgreen;
        }
        .navbar ul{   /*CADA UL DELTRO DE MI NAVBAR*/
            list-style: none;
        }
        /*menu*/
        .menu > li {
            position:relative;
            display:inline-block;  /*UN MENU AL LADO DEL OTRO--*/
        }
        .menu > li  a {
            display: block;
            padding: 15px 20px; /*ESPACIO */
            color: black;
            font-size: 16px;
            font-family: 'Calibri';
            text-decoration: none;
        }
        .menu li a:hover{
            color: green; /*color en el menu al desplazarme */
            border:  1px solid #808080;
        }

        /*SUBMENU*/
        .submenu 
        { 
            position: absolute; /*ordena los submenu debajo del menu que lo usa*/
            background: lightgreen; /*Color fondo del submenu*/
            width: 130%; /*Aumento para que se vea todo el tex de mi submenu, si supera el del menu*/
            display: none; /*Para que no se muestre automaticamente*/
        }
        .submenu li a{
            display:block block;
            padding: 15px; /*15px a todos los lados, espacio*/
            color: black;
            font-family: Calibri;
            font-size: 16px;
            text-decoration: none; /*SIN SUBRAYADO EL ENLACE*/

        }
        .menu li:hover .submenu{
            display: block;  /*Se muestra el submenu cuando paso el mouse por el menu*/
            border:  1px solid #808080;
        }

      
    </style>

    <nav class="navbar">
       <ul class="menu">
         <li><a href="#">Insumos</a>
         <ul class="submenu">
            <li><a href="#" class=""> Insumos </a></li>
            <li><a href="Proveedores.aspx" class=""> Proveedores </a></li>
            <li><a href="insumos.aspx" class="">Compras</a></li>
            <li><a href="#" class="">Stock</a></li>

        </ul>
         </li>
        <li><a href="#">Productos</a>
            <ul class="submenu">
                <li><a href="#" class="">Productos</a></li>
                <li><a href="#" class="">Marcas</a></li>
                <li><a href="#" class="">Categorias</a></li>
                <li><a href="#" class="">Tipos</a></li>
                <li><a href="#" class="">Formulas</a></li>
                <li><a href="#" class="">Stock</a></li>
            </ul>
        </li>
        <li><a href="#">Ventas</a>
        <ul class="submenu">
            <li><a href="#" class="">Ventas</a></li>
            <li><a href="#" class="">Clientes</a></li>
        </ul>
    </li>
    <li><a href="#">Ayuda</a></li>
 
</ul> <!-- end .menu -->
    </nav>
</asp:Content>
