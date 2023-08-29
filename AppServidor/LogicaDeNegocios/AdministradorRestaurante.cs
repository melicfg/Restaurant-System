using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace LogicaDeNegocios
{
    public class AdministradorRestaurante
    {
        private static int idAsignacion = 0;


        public static string agregarRestaurante(int id, string nombre, string direccion, bool estado, string telefono)
        {

            Restaurante nuevoRestaurante = new Restaurante(id, nombre, direccion, estado, telefono);
            Restaurante[] lista = AdministradorListas.restaurantesLista;
            lista[AdministradorListas.indiceRestaurante] = nuevoRestaurante;
            AdministradorListas.indiceRestaurante += 1;

            AgregarDatos agregar = new AgregarDatos();

            Tuple<bool, string> resultadoFuncion = agregar.guardarRestaurante(nuevoRestaurante);

            return resultadoFuncion.Item2;

        }

        public static string agregarPlatoRestaurante(int id, DateTime fecha, Restaurante restauranteSeleccionado, Plato[] platosAgregar)
        {
            Plato[] platosParaAgregar = (Plato[])platosAgregar.Clone();
            PlatoRestaurante nuevoPlatoRestaurante = new PlatoRestaurante(id, fecha, restauranteSeleccionado, platosParaAgregar);


            AgregarDatos datos = new AgregarDatos();

            Tuple<bool, string> respuesta = datos.guardarPlatoRestaurante(nuevoPlatoRestaurante);


            return respuesta.Item2;


            AdministradorListas.platoRestaurantesLista[AdministradorListas.indicePlatoRestaurante] = nuevoPlatoRestaurante;
            AdministradorListas.indicePlatoRestaurante += 1;
        }

    }
}
