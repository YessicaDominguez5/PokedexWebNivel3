<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EnvioEmail.aspx.cs" Inherits="PokedexWeb.EnvioEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <hr />

    <div class="row">

        <div class="col-6">

            <div class="mb-3">

                <asp:Label runat="server" CssClass="form-label" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="name@example.com" runat="server"></asp:TextBox>

            </div>

            <div class="mb-3">

                <asp:Label ID="labelAsunto" runat="server" Text="Asunto"></asp:Label>
                <asp:TextBox ID="txtAsunto" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>

            </div>

            <div class="mb-3">

                <asp:Label ID="labelMensaje" runat="server" Text="Mensaje"></asp:Label>
                <asp:TextBox ID="txtMensaje" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>

            </div>

            <asp:Button ID="btnEnvioEmail" OnClick="btnEnvioEmail_Click" CssClass="btn btn-primary" runat="server" Text="Aceptar" />


        </div>

    </div>
</asp:Content>
