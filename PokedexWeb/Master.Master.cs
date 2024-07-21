using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexWeb
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is Login || Page is Registrarse || Page is Default))
            {
                if (!Seguridad.SessionActiva(Session["trainee"]))
                {
                    Response.Redirect("Login.aspx", false);
                }


            }

        }

        protected void btnDesLoguearse_Click(object sender, EventArgs e)
        {
            Session.Remove("trainee");
            Response.Redirect("Login.aspx");
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }
    }
}