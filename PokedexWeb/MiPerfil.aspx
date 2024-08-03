<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="PokedexWeb.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion{

            color:red;
            font-size:12px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h1>Mi Perfil</h1>

    <div class="row">
        <div class="col-md-4">

            <div class="mb-3">
                <asp:Label ID="labelEmailPerfil" CssClass="form-label" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmailPerfil" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>

            </div>

            <div class="mb-3">
                <asp:Label ID="labelNombrePerfil" CssClass="form-label" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombrePerfil" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido" CssClass="validacion" ControlToValidate="txtNombrePerfil" runat="server" />

            </div>

            <div class="mb-3">
                <asp:Label ID="labelApellidoPerfil" CssClass="form-label" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellidoPerfil" CssClass="form-control" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ErrorMessage="El apellido es requerido" CssClass="validacion" ControlToValidate="txtApellidoPerfil" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label ID="labelFechaNacimientoPerfil" CssClass="form-label" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                <asp:TextBox ID="txtFechaNacimientoPerfil" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>

            </div>
            <asp:Button ID="btnGuardarPerfil" CssClass="btn btn-primary" OnClick="btnGuardarPerfil_Click" runat="server" Text="Guardar" />
            <a href="Default.aspx">Cancelar</a>

        </div>
        <div class="col-md-4">
            
            <div class="mb-3">
              
                <asp:Label ID="labelImagenPerfil" CssClass="form-label" runat="server" Text="Imagen Perfil"></asp:Label>
                <input type="file" id="txtImagenPerfil" runat="server" class="form-control" />
            </div>
           
            <asp:Image ID="ImagenPerfilCargada" runat="server" ImageUrl="https://epichotelsanluis.com/wp-content/uploads/2022/11/placeholder-2-300x200.png" CssClass="img-fluid mb-3" />


        </div>

    </div>



</asp:Content>
