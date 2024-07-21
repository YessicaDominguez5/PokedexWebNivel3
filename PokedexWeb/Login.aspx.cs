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
            Trainee trainee = new Trainee();
            TraineeNegocio negocio = new TraineeNegocio();
            try
            {
                trainee.Email = txtUser.Text;
                trainee.Pass = txtPass.Text;
                if(negocio.Login(trainee) )
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("MiPerfil.aspx",false);
                }else
                {
                    Session.Add("error", "User o password incorrectos");
                    Response.Redirect("error.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx");

            } 
        }
    }
}