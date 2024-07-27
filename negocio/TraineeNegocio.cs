using dominio;
using System;

namespace negocio
{
    public class TraineeNegocio
    {
        private readonly string _directorioImagen = "~/Imagenes/";

        public void actualizar(Trainee user)
        {
            AccesoDatos datos = new AccesoDatos(); //afuera del try sino no agarra el finally
            try
            {
                datos.setearConsulta("Update USERS set ImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido where Id = @id");
                datos.setearParametro("@imagen", user.ImagenPerfil);
                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("id", user.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public int InsertarNuevo(Trainee nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);

                return datos.ejecutarAccionScalar();
                //lo llama el evento Registrarse
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }




        }

        public bool Login(Trainee trainee)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Id,Email,Pass,Admin,Nombre,Apellido,ImagenPerfil from USERS where Email = @email And Pass = @pass");
                datos.setearParametro("@email", trainee.Email);
                datos.setearParametro("@pass", trainee.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["Id"];
                    trainee.Admin = (bool)datos.Lector["Admin"];
                    trainee.Nombre = (string)datos.Lector["Nombre"];
                    trainee.Apellido = (string)datos.Lector["Apellido"];

                    if (!(datos.Lector["ImagenPerfil"] is DBNull))
                    {
                    trainee.ImagenPerfil = (string)datos.Lector["ImagenPerfil"];

                    }//cuando recien te logueas y no tenes imagen de perfil la imagen es nula y te tira un error
                    return true;

                }
                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public string ObtenerImagenPerfil(Trainee trainee)
        {
            return _directorioImagen + trainee.ImagenPerfil;
        }
    }
}
