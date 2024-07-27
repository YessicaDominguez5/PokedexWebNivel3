using dominio;
using negocio;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexWeb
{
    public partial class MiPerfil : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Trainee trainee = (Trainee)Session["trainee"];
                if (Seguridad.SessionActiva(trainee))//si la session esta activa y el trainee no es null(lo resuelve en seguridad)
                {
                    TraineeNegocio traineeNegocio = new TraineeNegocio();
                    txtEmailPerfil.Text = trainee.Email.ToString();
                    txtEmailPerfil.Enabled = false;

                    if (trainee.Nombre != null)
                    {
                        txtNombrePerfil.Text = trainee.Nombre.ToString();
                    }
                    if (trainee.Apellido != null)
                    {
                        txtApellidoPerfil.Text = trainee.Apellido.ToString();
                    }


                    if (!string.IsNullOrWhiteSpace(trainee.ImagenPerfil)) // Si la imagen de perfil no es vacía o nula, la cargo en el imagen perfil cargada
                    {
                        ImagenPerfilCargada.ImageUrl = traineeNegocio.ObtenerImagenPerfil(trainee);
                    }
                }
            }
        }

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                TraineeNegocio negocio = new TraineeNegocio();

                //Para Escribir
                string ruta = Server.MapPath("./Imagenes/");

                Trainee user = (Trainee)Session["trainee"];


                if (!string.IsNullOrWhiteSpace(txtImagenPerfil.PostedFile.FileName))
                {
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";//guardo el nombre de la imagen 
                                                                 //user.ImagenPerfil = $"perfil-{user.Id}.jpg"; -> Interpolacion de string
                    txtImagenPerfil.PostedFile.SaveAs(ruta + user.ImagenPerfil);
                }


                user.Email = txtEmailPerfil.Text;
                user.Nombre = txtNombrePerfil.Text;
                user.Apellido = txtApellidoPerfil.Text;
                if (!string.IsNullOrWhiteSpace(txtFechaNacimientoPerfil.Text))
                {
                    user.FechaDeNacimiento = DateTime.Parse(txtFechaNacimientoPerfil.Text);
                }


                negocio.actualizar(user); //manda a la base de datos el nombre de la imagen

                //Para Leer

                Image img = (Image)Master.FindControl("imgAvatar"); //llamar desde Mi Perfil a imgAvatar que esta en la Master(clase padre)

                img.ImageUrl = "~/Imagenes/" + user.ImagenPerfil;

                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("error.aspx", false);
            }
        }
    }
}