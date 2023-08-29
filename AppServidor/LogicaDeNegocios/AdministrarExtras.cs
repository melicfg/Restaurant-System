using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios
{
    public class AdministrarExtras
    {
        public static string agregarExtra(int id, string descripcion, CategoriaPlato objCategoria, bool estado, int precio)
        {

            Extras nuevaExtra = new Extras(id, descripcion, objCategoria, estado, precio);

            AgregarDatos datos = new AgregarDatos();

            Tuple<bool, string> respuesta = datos.guardarExtra(nuevaExtra);


            return respuesta.Item2;

            AdministradorListas.extrasListas[AdministradorListas.indiceExtras] = nuevaExtra;
            AdministradorListas.indiceExtras += 1;

        }
    }
}
