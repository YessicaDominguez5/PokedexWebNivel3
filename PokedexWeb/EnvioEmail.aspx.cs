using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexWeb
{
    public partial class EnvioEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnEnvioEmail_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            emailService.ArmarCorreo(txtEmail.Text,txtAsunto.Text,txtMensaje.Text);
            try
            {
                emailService.EnviarEmail();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx", false);
            }
        }
    }
}