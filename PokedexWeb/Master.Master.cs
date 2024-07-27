using dominio;
using negocio;
using System;
using System.Web.UI;

namespace PokedexWeb
{
    public partial class Master : MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            Trainee sessionActiva = (Trainee)Session["trainee"];
            if (!(Page is Login || Page is Registrarse || Page is Default || Page is error))
            {
                if (!Seguridad.SessionActiva(sessionActiva))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (Seguridad.SessionActiva(sessionActiva))
            {
                TraineeNegocio negocio = new TraineeNegocio();
                string hayImagen= negocio.ObtenerImagenPerfil(sessionActiva);

                if(!string.IsNullOrWhiteSpace(hayImagen))
                {
                    imgAvatar.ImageUrl = hayImagen;

                }

            }
            else
            {
                imgAvatar.ImageUrl = "https://lh5.googleusercontent.com/proxy/9vqIPeIeHQHyGEo43DlSgD-DUtidieclv56O6UoAcYNGPXGNnZwFJL2V7oSodehCB1YT28jit7pMSVjNTnrBOnlBxW0CiRmOeH22FlPockzEbfdQPHLkDMPcgMwWdNfVHF1r2QpUk6W_aY_J87A9lFtYKMHf8_xhkMB7l_4=w1200-h630-p-k-no-nu";

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