using dominio;
using negocio;
using System;


namespace PokedexWeb
{
    public partial class Pagina2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            UsuarioNegocio negocio = new UsuarioNegocio();
            if (usuario == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("error.aspx");

            }
            else if (!negocio.UsuarioAdmin(usuario))
            {
                Session.Add("error", "Debes ser Admin para poder ingresar");
                Response.Redirect("error.aspx");
            }
            else
            {

            }
        }
    }
}