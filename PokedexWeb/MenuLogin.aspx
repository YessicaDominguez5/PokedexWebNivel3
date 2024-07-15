<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="PokedexWeb.MenuLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Te logueaste correctamente</h1>
    <hr />

    <div class="row">

        <div class="col">
            <asp:Button ID="btnPagina1" runat="server" Text="Página 1" OnClick="btnPagina1_Click" CssClass="btn btn-primary" />

        </div>
        <div class="col">
            <%if (UsuarioAdmin())
                { %>
            <asp:Button ID="btnPagina2" runat="server" CssClass="btn btn-primary" OnClick="btnPagina2_Click" Text="Página 2" />
            <div class="row">

            <asp:Label ID="labelAdmin" runat="server"  Text="Tenés que ser Admin"></asp:Label>
                <%} %>
            </div>

        </div>
    </div>


</asp:Content>
