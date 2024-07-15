<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pagina1.aspx.cs" Inherits="PokedexWeb.Pagina1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola!</h1>
    <p>Pudiste entrar acá porque te logueaste</p>
    <a href="MenuLogin.aspx" class="btn btn-primary">Regresar</a>
</asp:Content>
