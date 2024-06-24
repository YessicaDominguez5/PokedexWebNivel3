<%@ Page Title="Lista de Pokémon" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="PokedexWeb.ListaPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-sm-center text-bg-success">LISTA DE POKEMON</h1>
    <asp:GridView ID="dgvPokemon" CssClass="table" AutoGenerateColumns="false"
        DataKeyNames="Id" OnSelectedIndexChanged="dgvPokemon_SelectedIndexChanged"
        OnPageIndexChanging="dgvPokemon_PageIndexChanging" AllowPaging="true" PageSize="5"
         runat="server">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Número" DataField="Numero" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:CommandField ShowSelectButton="true" HeaderText="Acción" SelectText="✏️​" />


        </Columns>

    </asp:GridView>

    <a href="PokeForm.aspx" class="btn btn-success">AGREGAR</a>
   
</asp:Content>
