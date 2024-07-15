<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PokedexWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="mb-3">
        <asp:Label ID="laberUser" runat="server" Text="USER"></asp:Label>
        <asp:TextBox ID="txtUser" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="mb-3">
        <asp:Label ID="labelPass" runat="server" Text="PASSWORD"></asp:Label>
        <asp:TextBox ID="txtPass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="btnLogin" OnClick="btnLogin_Click" CssClass="btn btn-primary" runat="server" Text="INGRESAR" />
</asp:Content>
