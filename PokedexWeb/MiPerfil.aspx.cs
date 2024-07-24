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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Trainee trainee = (Trainee)Session["trainee"];
            if(trainee != null)
            {
                txtEmailPerfil.Text = trainee.Email.ToString();
                txtEmailPerfil.Enabled = false;
            }
        }

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                TraineeNegocio negocio = new TraineeNegocio();
                string ruta = Server.MapPath("./Imagenes/");

                Trainee user = (Trainee)Session["trainee"];

                user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                txtImagenPerfil.PostedFile.SaveAs(ruta + user.ImagenPerfil);
                user.Email = txtEmailPerfil.Text;
                user.Nombre = txtNombrePerfil.Text;
                user.Apellido = txtApellidoPerfil.Text;
                user.FechaDeNacimiento = DateTime.Parse(txtFechaNacimientoPerfil.Text);


                negocio.actualizar(user);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Imagenes/" + user.ImagenPerfil;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx", false);
            }
        }
    }
}