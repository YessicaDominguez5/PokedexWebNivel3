using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PokedexWeb
{
    public static class Validacion
    {
        public static bool validaTextoVacio(object control)//como es object puede recibir cualquier cosa
        {
            if(control is TextBox texto) //crea una variable texto de la clase TextBox, control es reemplazado por texto
            {
                //return string.IsNullOrEmpty(texto.Text);
                if(string.IsNullOrEmpty(texto.Text))
                {
                    return true;
                }else
                {
                    return false;
                }
            }
            return false;
        }

        
    }
}
