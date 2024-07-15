using dominio;
using negocio;
using System;

namespace PokedexWeb
{
    public partial class MenuLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("error.aspx", false);
                

            }
        }

        protected void btnPagina1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina1.aspx");
        }

        protected void btnPagina2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina2.aspx");
        }
        public bool UsuarioAdmin()
        {
            Usuario user = (Usuario)Session["usuario"];
            UsuarioNegocio negocio = new UsuarioNegocio();
            return negocio.UsuarioAdmin(user);
            //si es Admin retorna true, sino false

        }

    }
}