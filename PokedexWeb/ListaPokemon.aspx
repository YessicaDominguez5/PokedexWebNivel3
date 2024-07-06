<%@ Page Title="Lista de Pokémon" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="PokedexWeb.ListaPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-sm-center text-bg-success">LISTA DE POKEMON</h1>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row">


                <div class="col-6">

                    <div class="mb-3">

                        <asp:Label ID="labelFiltrarRapido" runat="server" Text="Filtrar:"></asp:Label>
                        <asp:TextBox ID="txtFiltroRapido" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged"
                            CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>

                                <asp:CheckBox ID="cbFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="cbFiltroAvanzado_CheckedChanged" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:Label ID="labelFiltroAvanzadoCB" runat="server" Text="Filtro Avanzado"></asp:Label>
                    </div>
                </div>
            </div>
            <%if (cbFiltroAvanzado.Checked)
                { %>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>


                    <div class="row">

                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label ID="labelCampo" runat="server" Text="Campo:"></asp:Label>
                                <asp:DropDownList ID="ddlCampo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Text="Nombre" />
                                    <asp:ListItem Text="Tipo" />
                                    <asp:ListItem Text="Número" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label ID="labelCriterio" runat="server" Text="Criterio:"></asp:Label>
                                <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>

                        </div>

                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label ID="labelFiltroAvanzadoTxt" runat="server" Text="Filtro:"></asp:Label>
                                <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                        </div>

                        <div class="col-3">
                            <div class="mb-3">
                                <asp:Label ID="labelEstado" runat="server" Text="Estado:"></asp:Label>
                                <asp:DropDownList ID="ddlEstado" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Todos" />
                                    <asp:ListItem Text="Activo" />
                                    <asp:ListItem Text="Inactivo" />
                                </asp:DropDownList>
                            </div>
                            <div class="col-3">
                                <div class="mb-3">
                                    <asp:Button ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" Text="Buscar" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%}%>

            <div class="row">


                <asp:GridView ID="dgvPokemon" CssClass="table" AutoGenerateColumns="false"
                    DataKeyNames="Id" OnSelectedIndexChanged="dgvPokemon_SelectedIndexChanged"
                    OnPageIndexChanging="dgvPokemon_PageIndexChanging" AllowPaging="true" PageSize="5"
                    runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Número" DataField="Numero" />
                        <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                        <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                        <asp:CommandField ShowSelectButton="true" HeaderText="Acción" SelectText="✏️​" />


                    </Columns>

                </asp:GridView>

            </div>
            <a href="PokeForm.aspx" class="btn btn-success">AGREGAR</a>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
