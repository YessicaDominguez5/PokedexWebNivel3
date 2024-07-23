using negocio;
using System;
using System.Web.UI;

namespace PokedexWeb
{
    public partial class Master : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Registrarse || Page is Default))
            {
                if (!Seguridad.SessionActiva(Session["trainee"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }

        }

        protected void btnDesLoguearse_Click(object sender, EventArgs e)
        {
            Session.Clear(); //borra toda la session
            //Session.Remove("trainee"); borra solo el objeto trainee
            Response.Redirect("Login.aspx");
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }
    }
}