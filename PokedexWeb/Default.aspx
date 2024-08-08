<%@ Page Title="Pokedex" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PokedexWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-sm-center text-bg-success">POKEDEX</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <% foreach (dominio.Pokemon poke in ListaPokemon)
            {%>


        <div class="col">
            <div class="card">
                <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="<%: poke.Nombre%>">
                <div class="card-body">
                    <h5 class="card-title"><%: poke.Nombre %></h5>
                    <p class="card-text">Tipo: <%: poke.Tipo.Descripcion %></p>
                </div>
                <a href="Detalle.aspx?id=<%: poke.Id %>">Ver Detalle</a>
            </div>
        </div>

        <% } %>
    </div>


</asp:Content>
