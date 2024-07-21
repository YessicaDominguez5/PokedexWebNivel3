using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public static class Seguridad
    {
        public static bool SessionActiva(object user)
        {
            Trainee trainee = user != null ? (Trainee)user : null;

            if(trainee != null && trainee.Id !=0)
            {
                return true;
                //session activa
            }
            else 
            {
                return false; 
                //sin session activa
            
            }



        }

        public static bool esAdmin(object user)
        {
            Trainee trainee = user != null ? (Trainee)user : null;

            return trainee != null ? trainee.Admin : false;

        }
    }
}
