using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace PokedexWeb
{
    public partial class ListaPokemon : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

         
            FiltroAvanzado = false;

            PokemonNegocio negocio = new PokemonNegocio();

            Session.Add("listaPokemon", negocio.listarConSP());

            dgvPokemon.DataSource = Session["listaPokemon"];
            dgvPokemon.DataBind();

         
            
        }

        protected void dgvPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemon.SelectedDataKey.Value.ToString();
            Response.Redirect("PokeForm.aspx?id=" + id);
        }

        protected void dgvPokemon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemon.PageIndex = e.NewPageIndex;
            dgvPokemon.DataBind();
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemon"];
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
            dgvPokemon.DataSource = listaFiltrada;
            dgvPokemon.DataBind();
            
            
        }

        protected void cbFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = cbFiltroAvanzado.Checked;
            txtFiltroRapido.Enabled = !FiltroAvanzado;
            if (FiltroAvanzado)
            {
                // Forzamos el metodo selected index changed cuando 
                // apretamos en el check de filtro avanzado
                ddlCampo_SelectedIndexChanged(sender, e);
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
           ddlCriterio.Items.Clear();

            if(ddlCampo.SelectedItem.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");


            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();

            dgvPokemon.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),ddlCriterio.SelectedItem.ToString(),txtFiltroAvanzado.Text,ddlEstado.SelectedItem.ToString());
            dgvPokemon.DataBind();


        }
    }
}