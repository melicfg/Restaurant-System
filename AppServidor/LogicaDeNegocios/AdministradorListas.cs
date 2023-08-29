using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace LogicaDeNegocios
{
    public class AdministradorListas
    {

        public static CategoriaPlato[] categoriasLista = new CategoriaPlato[20];
        public static int indiceCategorias = 0;

        public static Clientes[] clientesLista = new Clientes[20];
        public static int indiceCliente = 0;

        public static Plato[] platosLista = new Plato[20];
        public static int indicePlatos = 0;

        public static Restaurante[] restaurantesLista = new Restaurante[20];
        public static int indiceRestaurante = 0;

        public static PlatoRestaurante[] platoRestaurantesLista = new PlatoRestaurante[20];
        public static int indicePlatoRestaurante = 0;

        public static Plato[] platosAgregar = new Plato[10];
        public static int IndicePlatosAgregar = 0;

        public static Extras[] extrasListas = new Extras[20];
        public static int indiceExtras = 0;

        public static bool listaVacia(object[] lista) //comprueba si una lista esta vacía o no
        {
            //se busca con ayuda de un any si algun elemento de la lista es diferente de null
            return !lista.Any(elemento => elemento != null);
        }

        public static bool listaLlena(object[] lista) //comprueba si una lista esta vacía o no
        {
            //se busca con ayuda de un any si algun elemento de la lista es diferente de null
            return !lista.Any(elemento => elemento == null);
        }

        //public static bool idrepetido<t>(dynamic id, idble<t>[] lista) //funcion para comprobar si un id es repetido en los arreglos

        //{
        //    //se usa un where para que solo tome en consideración los elementos del arreglo que no sean nulos y evitar errores
        //    //se usa un any para que regrese el elemento que cumpla con que el id ingresado es igual a un id del arreglo
        //    return lista.where(objeto => objeto != null).any(objeto =>
        //    {
        //        //aqui se obtiene el valor del id o la propiedad que se quiera comprobar si esta repetida en cada elemento del arreglo
        //        dynamic valorpropiedad = objeto.id.tostring(); 
        //        return valorpropiedad == id.tostring();
        //    });
        //}
        
        public static void borrarDatosLita(Object[] lista, ref int indice)
        {
            for (int i = 0; i < lista.Length; i++)
            {
                lista[i] = default(Object);
            }

            indice = 0;

        }

        public static void crearDatosRandom()
        {
            for (int i = 0; i < 20; i++)
            {
                Random random = new Random();
                bool valorAleatorio = random.NextDouble() < 0.5;

                const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                int longitudCadena = 10;
                string cadenaAleatoria = new string(Enumerable.Repeat(caracteresPermitidos, longitudCadena)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
                string direccion = new string(Enumerable.Repeat(caracteresPermitidos, longitudCadena)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                const string caracteresPermitidos2 = "0123456789";
                string cadenaAleatoria2 = new string(Enumerable.Repeat(caracteresPermitidos2, longitudCadena)
                .Select(s => s[random.Next(s.Length)]).ToArray());

                Restaurante restaurante = new Restaurante(i,cadenaAleatoria, direccion,valorAleatorio,cadenaAleatoria2);

                restaurantesLista[i] = restaurante;
            }

            for (int i = 0; i < 20; i++)
            {
                Random random = new Random();
                bool valorAleatorio = random.NextDouble() < 0.5;

                const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                int longitudCadena = 10;
                string cadenaAleatoria = new string(Enumerable.Repeat(caracteresPermitidos, longitudCadena)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                const string caracteresPermitidos2 = "0123456789";
                string cadenaAleatoria2 = new string(Enumerable.Repeat(caracteresPermitidos2, longitudCadena)
                .Select(s => s[random.Next(s.Length)]).ToArray());

                CategoriaPlato categoria = new CategoriaPlato(i, cadenaAleatoria, valorAleatorio);
                categoriasLista[i] = categoria;

            }

            for (int i = 0; i < 20; i++)
            {
                Random random = new Random();
                bool valorAleatorio = random.NextDouble() < 0.5;

                const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                int longitudCadena = 10;
                string cadenaAleatoria = new string(Enumerable.Repeat(caracteresPermitidos, longitudCadena)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
                string direccion = new string(Enumerable.Repeat(caracteresPermitidos, longitudCadena)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                int contador = 0;
                const string caracteresPermitidos2 = "0123456789";
                string cadenaAleatoria2 = new string(Enumerable.Repeat(caracteresPermitidos2, longitudCadena)
                .Select(s => s[random.Next(s.Length)]).ToArray());

                int numeroAleatorio = random.Next(0, 20);
                int numeroAleatorio1 = random.Next(0, 999999);

                Plato plato = new Plato(i, cadenaAleatoria, numeroAleatorio1, categoriasLista[numeroAleatorio]);

                platosLista[i] = plato;
                
            }
        }


    }
}
