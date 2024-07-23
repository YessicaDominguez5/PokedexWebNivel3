using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexWeb
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Server.MapPath("./Imagenes/");

                Trainee user = (Trainee)Session["trainee"];
                txtImagenPerfil.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx", false);
            }
        }
    }
}