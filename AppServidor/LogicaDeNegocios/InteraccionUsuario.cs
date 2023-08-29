using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios
{
    public class InteraccionUsuario
    {

        public static int ingresarInt ()
        {
            //se usa un try catch para evitar problemas al ingresar un tipo de dato que no sea entero
            int num = -1;
            string numStr = Console.ReadLine();
            try
            {
                num = int.Parse(numStr);
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo puede ingresar numeros positivos");
            }

            return num;
        }

        public static string ingresarString ()
        {
            string str = Console.ReadLine();

            return str;
        }

        public static string ingresarStringNumeral()
        {
            //se quitan espacios y guiones y se comprueba que se tenga un numero determinado de caracteres
            string numero = Console.ReadLine();
            string numeroModificado = numero.Replace(" ", "").Replace("-", "");

            return numeroModificado;
        }

    }
}
