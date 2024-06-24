<%@ Page Title="Formulario" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokeForm.aspx.cs" Inherits="PokedexWeb.PokeForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="row">
        <div class="col-6">


            <div class="mb-3">
                <label for="txtId" class="form-label">ID</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtNumero" class="form-label">NÚMERO DE POKÉMON</label>
                <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">NOMBRE</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>


            <div class="mb-3">
                <label for="ddlTipo" class="form-label">TIPO</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">DEBILIDAD</label>
                <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

        </div>

        <div class="col-6">

            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">DESCRIPCIÓN</label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    

                    <div class="mb-3">
                        <label for="txtUrl" class="form-label">URL IMAGEN</label>
                        <asp:TextBox ID="txtUrl" CssClass="form-control" OnTextChanged="txtUrl_TextChanged" runat="server"></asp:TextBox>
                    </div>

                    <asp:Image ID="imgPokemon" ImageUrl="https://static.wikia.nocookie.net/espokemon/images/7/77/Pikachu.png/revision/latest?cb=20150621181250" Width="60%" runat="server" />
                    <div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" runat="server" Text="ACEPTAR" />
            <a href="ListaPokemon.aspx" class="btn btn-secondary">CANCELAR</a>

        </div>




    </div>
    </div>


    <br />

</asp:Content>




