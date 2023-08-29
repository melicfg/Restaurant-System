using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios
{
    public class AdministradorVariables
    {


        public static int comprobarInt(int min)
        {
            bool numeroValido = false;
            int num = -1;

            do
            {
                num = InteraccionUsuario.ingresarInt();

                numeroValido = (num >= min && num >= 0) ? true : false;

                if (!numeroValido)
                {
                    Console.WriteLine($"Debe ingresar almenos {min} digitos y solo se admiten enteros positivos");
                    Console.WriteLine("Ingrese el numero de nuevo:");

                }

            } while (!numeroValido);

            return num;
        }

        public static bool stringValido(string variable) // funcion que se utiliza cada vez que es necesario ingresar un string
        {
            //se comprueba que el string no este vacio
            return !string.IsNullOrEmpty(variable);

        }

        public static string formatearString(string variable)
        {
            string numeroModificado = variable.Replace(" ", "").Replace("-", "");
            return numeroModificado;
        }

        public static string[] ingresoStringNumeral(string numero, int numMinimoDigitos, string variable) //funcion para el ingreso de strings de numeros
        {

            string numeroModificado = formatearString(numero);
            string mensaje = "";
            string[] respuesta = new string[2];


            if (numeroModificado.Length >= numMinimoDigitos)
            {
                foreach (char num in numeroModificado)
                {
                    //si alguno de los elementos no es numero se sale del foreach y el numero no es valido
                    if (!char.IsDigit(num))
                    {

                        mensaje = "No se permite el ingreso de letras como "+variable;
                        break;
                    }
                }

            }
            else
            {
                mensaje = "El/la " + variable + " debe contener " + numMinimoDigitos + " digitos. ";
            }

            respuesta[0] = mensaje;
            respuesta[1] = numeroModificado;

            return respuesta;
        }

    }
}
