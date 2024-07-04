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
        public bool ConfirmarEliminar { get; set; }
        public bool Modificar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmarEliminar = false;
            Modificar = false;

            try
            {
                //configuración inicial
                if (!IsPostBack)
                {
                    ElementoNegocio negocioElemento = new ElementoNegocio();
                    List<Elemento> listaDeElementos = negocioElemento.listar();

                    ddlTipo.DataSource = listaDeElementos;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = listaDeElementos;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();

                }
                //configuración si estamos modificando

                string id = Request.QueryString["id"];

                if (id != null && !IsPostBack)
                {
                    Modificar = true;
                    PokemonNegocio negocio = new PokemonNegocio();

                    List<Pokemon> lista = negocio.listar(id);

                    Pokemon seleccionado = lista[0];

                    Session.Add("pokeSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrl.Text = seleccionado.UrlImagen;
                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();

                    imgPokemon.ImageUrl = txtUrl.Text; //que la imagen aparezca cargada en el modificar sin esperar al text changed

                    if(!seleccionado.Activo)
                    {
                        btnDesactivar.Text = "REACTIVAR";

                    }

                }



            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

                Response.Redirect("error.aspx");
                //throw;
            }

            //Asi se hace cuando se guarda en Session
            //if (Request.QueryString["id"] != null)
            //{
            //    int id = int.Parse(Request.QueryString["id"]);

            //    PokemonNegocio negocio = new PokemonNegocio();
            //    List<Pokemon> temporal = negocio.listarConSP();
            //    Pokemon seleccionado = temporal.Find(x => x.Id == id);

            //    txtId.Text = seleccionado.Id.ToString();
            //    txtId.ReadOnly = true;
            //    txtNumero.Text = seleccionado.Numero.ToString();
            //    txtNombre.Text = seleccionado.Nombre;
            //    txtDescripcion.Text = seleccionado.Descripcion;



            //}




        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
           
            try
            {

                Pokemon poke = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                poke.Numero = int.Parse(txtNumero.Text);
                poke.Nombre = txtNombre.Text;
                poke.Descripcion = txtDescripcion.Text;
                poke.UrlImagen = txtUrl.Text;

                poke.Tipo = new Elemento();
                poke.Tipo.Id = int.Parse(ddlTipo.SelectedValue);

                poke.Debilidad = new Elemento();
                poke.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);
                
               
                if (Request.QueryString["id"] != null)
                {
                    poke.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(poke);


                }
                else
                {
                    negocio.agregarConSP(poke);
                }

               
                Response.Redirect("ListaPokemon.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

                Response.Redirect("error.aspx");
            }
        }

        protected void txtUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminar = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbEliminar.Checked)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.eliminarConSP(int.Parse(txtId.Text));
                    Response.Redirect("ListaPokemon.aspx", false);

                }
                else
                {
                    Response.Redirect("ListaPokemon.aspx", false);
                }
               


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
            PokemonNegocio negocio = new PokemonNegocio();
                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];

                negocio.eliminarLogico(seleccionado.Id, !seleccionado.Activo);
                //Esta negado porque si esta inactivo lo quiero activar, y si esta activo lo quiero inactivar
                Response.Redirect("ListaPokemon.aspx",false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }



        }
    }
}