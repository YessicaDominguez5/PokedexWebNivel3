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
                //else
                //{
                //   laberUser.Text = sessionActiva.Email;
                //}
            }

            if (Seguridad.SessionActiva(sessionActiva))
            {
                TraineeNegocio negocio = new TraineeNegocio();
                string hayImagen= negocio.ObtenerImagenPerfil(sessionActiva);


                    imgAvatar.ImageUrl = hayImagen;
                    laberUser.Text = sessionActiva.Email;


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