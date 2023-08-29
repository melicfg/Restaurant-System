using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Plato : Idble<int>
    {

        public Plato(int id, string nombre, int precio, CategoriaPlato categoria) : base(id)
        {
            nombrePlato = nombre;
            precioPlato = precio;
            categoriaPlato = categoria;
        }

        private string nombrePlato;
        public string NombrePlato { get => nombrePlato; set => nombrePlato = value; }
        private int precioPlato;
        public int PrecioPlato { get => precioPlato; set => precioPlato = value; }
        private CategoriaPlato categoriaPlato;
        public CategoriaPlato CategoriaPlato { get => categoriaPlato; set => categoriaPlato = value; }

    }
}
