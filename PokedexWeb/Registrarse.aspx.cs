using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace PokedexWeb
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();
                TraineeNegocio negocio = new TraineeNegocio();
                EmailService emailService = new EmailService();
                user.Email = txtEmailRegistrarse.Text;
                user.Pass = txtPassResistrarse.Text;
                int id = negocio.InsertarNuevo(user);
                emailService.ArmarCorreo(user.Email, "Bienvenida Trainee", "Hola! Te damos la bienvenida a la aplicación");
                emailService.EnviarEmail();
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx");
            }
        }
    }
}