using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ExtraPedido
    {

        public ExtraPedido(int idPedido, int idPlato, int idExtra) 
        {
            IdPedido = idPedido;
            IdPlato = idPlato;
            IdExtra = idExtra;
        }

        private int idPedido;
        public int IdPedido { get => idPedido; set => idPedido = value; }

        private int idPlato;
        public int IdPlato { get => idPlato; set => idPlato = value; }

        private int idExtra;
        public int IdExtra { get => idExtra; set => idExtra = value; }

    }
}
