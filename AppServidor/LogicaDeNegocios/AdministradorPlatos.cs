using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace LogicaDeNegocios
{
    public class AdministradorPlatos
    {

        public static string agregarPlato(int id, string nombre, int precio, CategoriaPlato objCategoria) 
        { 
        
            Plato nuevoPlato = new Plato(id, nombre, precio, objCategoria);

            AgregarDatos datos = new AgregarDatos();

            Tuple<bool, string> respuesta = datos.guardarPlato(nuevoPlato);


            return respuesta.Item2;

            AdministradorListas.platosLista[AdministradorListas.indicePlatos] = nuevoPlato;
            AdministradorListas.indicePlatos += 1;

        }

    }
}
