<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="PokedexWeb.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />

    <h1>Creá tu perfil Trainee</h1>
    <div class="mb-3">
    <asp:Label ID="emailRegistrarse" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="txtEmailRegistrarse" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
    <asp:Label ID="PassRegistrarse" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="txtPassResistrarse" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <div class="mb-3">
    <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" runat="server" Text="Registrar" />
    <a href="Login.aspx">Cancelar</a>
    </div>

</asp:Content>