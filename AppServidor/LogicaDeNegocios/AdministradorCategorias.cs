using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace LogicaDeNegocios
{
    public class AdministradorCategorias
    {

        public static string agregarCategoria (int id, string descripcion, bool estado)
        {

            CategoriaPlato nuevaCategoria = new CategoriaPlato (id, descripcion, estado);

            AgregarDatos datos = new AgregarDatos();

            Tuple<bool, string> respuesta = datos.guardarCategoria(nuevaCategoria);


            return respuesta.Item2;

            AdministradorListas.categoriasLista[AdministradorListas.indiceCategorias] = nuevaCategoria;
            AdministradorListas.indiceCategorias += 1;

        }

    }
}
