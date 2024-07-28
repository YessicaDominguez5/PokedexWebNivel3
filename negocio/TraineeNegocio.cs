﻿using dominio;
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
                datos.setearConsulta("Update USERS set ImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fecha where Id = @id");

                /*datos.setearParametro("@imagen", user.ImagenPerfil != null? user.ImagenPerfil : ""); */// si no tengo ninguna imagen cargada y pongo guardar me manda vacío
               
                datos.setearParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                // manda o un string o un object

                //datos.setearParametro("@imagen", (object)user.ImagenPerfil ??DBNull.Value); Otra forma: evalúa el user.ImagenPerfil(manda null si tiene null, sino manda lo que tenga user.perfil).

                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@id", user.Id);
                datos.setearParametro("@fecha", user.FechaDeNacimiento);
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
                datos.setearConsulta("select Id,Email,Pass,Admin,Nombre,Apellido,ImagenPerfil,FechaNacimiento from USERS where Email = @email And Pass = @pass");
                datos.setearParametro("@email", trainee.Email);
                datos.setearParametro("@pass", trainee.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["Id"];
                    trainee.Admin = (bool)datos.Lector["Admin"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                    {
                        trainee.Nombre = (string)datos.Lector["Nombre"];

                    }
                    if (!(datos.Lector["Apellido"] is DBNull))
                    {
                        trainee.Apellido = (string)datos.Lector["Apellido"];

                    }
                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                    {
                        trainee.FechaDeNacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString()); //lo transformo primero a string porque es un object

                    }

                    if (!(datos.Lector["ImagenPerfil"] is DBNull))
                    {
                    trainee.ImagenPerfil = (string)datos.Lector["ImagenPerfil"];

                    }
               
                    //cuando recien te logueas y no tenes imagen de perfil la imagen es nula y te tira un error
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
            string imagen;

            if(!string.IsNullOrEmpty(trainee.ImagenPerfil))
            {
                imagen = _directorioImagen + trainee.ImagenPerfil;
            }
            else
            {
                imagen = "https://lh5.googleusercontent.com/proxy/9vqIPeIeHQHyGEo43DlSgD-DUtidieclv56O6UoAcYNGPXGNnZwFJL2V7oSodehCB1YT28jit7pMSVjNTnrBOnlBxW0CiRmOeH22FlPockzEbfdQPHLkDMPcgMwWdNfVHF1r2QpUk6W_aY_J87A9lFtYKMHf8_xhkMB7l_4=w1200-h630-p-k-no-nu";
            }

            return imagen;
        }

    }
}
