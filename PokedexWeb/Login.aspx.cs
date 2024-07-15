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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try 
            {
                usuario.User = txtUser.Text;
                usuario.Pass = txtPass.Text;

                if(negocio.Loguear(usuario))
                {
                    Session.Add("usuario",usuario);
                    Response.Redirect("MenuLogin.aspx",false);
                }else
                {
                    Session.Add("error", "User o Password incorrectos");
                    Response.Redirect("error.aspx");
                }

                //si el usuario existe lo gurdo en session para que pueda acceder a las otras páginas, si el usuario es null debería dirigirme al login y no poder acceder a las páginas hasta que me loguee
            
            } 
            catch (Exception ex) 
            {
                Session.Add("error", ex);
                Response.Redirect("error.aspx");
            }
        }
    }
}