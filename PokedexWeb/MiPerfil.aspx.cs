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
                    if (trainee.FechaDeNacimiento != null)
                    {
                        txtFechaNacimientoPerfil.Text =  trainee.FechaDeNacimiento.ToString("yyyy-MM-dd");

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
                Page.Validate(); // se fija las validaciones como el requiredFieldValidator(ej: que el campo del nombre este completo)
                if(!Page.IsValid) //si las validaciones no son validas no las guarda en la base de datos termina y te muestra por ej el requiredFieldValidator "El nombre es requerido"
                {
                    return;
                }
                TraineeNegocio negocio = new TraineeNegocio();

                //Para Escribir


                Trainee user = (Trainee)Session["trainee"];


                if (txtImagenPerfil.PostedFile.FileName != "") // Si no selecciono nada, no modifico la imagen
                {
                    string ruta = Server.MapPath("./Imagenes/");

                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";//guardo el nombre de la imagen 
                                                                 //user.ImagenPerfil = $"perfil-{user.Id}.jpg"; -> Interpolacion de string
                    txtImagenPerfil.PostedFile.SaveAs(ruta + user.ImagenPerfil); // Guarda la imagen en la ruta, con lo que esté cargado en el txt de imagen perfil
                }


                user.Email = txtEmailPerfil.Text;
                user.Nombre = txtNombrePerfil.Text;
                user.Apellido = txtApellidoPerfil.Text;
                user.FechaDeNacimiento = DateTime.Parse(txtFechaNacimientoPerfil.Text);
               
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