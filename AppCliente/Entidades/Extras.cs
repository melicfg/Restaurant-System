using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Extras : Idble<int>
    {

        public Extras(int id, string descripcion, CategoriaPlato categoria, bool estado, int precio) : base(id)
        {
            descripcionCategoria = descripcion;
            categoriaExtra = categoria;
            estadoExtra = estado;
            precioExtra = precio;
        }
        private string descripcionCategoria;
        public string DescripcionCategoria { get => descripcionCategoria; set => descripcionCategoria = value; }

        private CategoriaPlato categoriaExtra;
        public CategoriaPlato CategoriaExtra { get => categoriaExtra; set => categoriaExtra = value; }

        private bool estadoExtra;
        public bool EstadoExtra { get => estadoExtra; set => estadoExtra = value; }

        private int precioExtra;
        public int PrecioExtra { get => precioExtra; set => precioExtra = value; }
    }
}
