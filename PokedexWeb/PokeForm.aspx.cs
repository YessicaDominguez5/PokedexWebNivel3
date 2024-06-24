using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexWeb
{
    public partial class PokeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);

                PokemonNegocio negocio = new PokemonNegocio();
                List<Pokemon> temporal = negocio.listarConSP();
                Pokemon seleccionado = temporal.Find(x => x.Id == id);

                txtId.Text = seleccionado.Id.ToString();
                txtId.ReadOnly = true;
                txtNumero.Text = seleccionado.Numero.ToString();
                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion;

 

            }

            ElementoNegocio negocioElemento = new ElementoNegocio();

            ddlTipo.DataSource = negocioElemento.listar();
            ddlTipo.DataBind();
            ddlDebilidad.DataSource = negocioElemento.listar();
            ddlDebilidad.DataBind();



        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Pokemon poke= new Pokemon();

            poke.Id = int.Parse(txtId.Text);
            poke.Numero = int.Parse(txtNumero.Text);
            poke.Nombre = txtNombre.Text;
            poke.Descripcion = txtDescripcion.Text;
            poke.Tipo.Descripcion = ddlTipo.SelectedValue;
            poke.Debilidad.Descripcion = ddlDebilidad.SelectedValue; 
            

        }

        protected void txtUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrl.Text;
        }
    }
}