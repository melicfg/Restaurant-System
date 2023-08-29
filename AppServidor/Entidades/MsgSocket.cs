using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Nota: se uso como base el ejemplo subido por el tutor Uriel
    public class MsgSocket<T>
    {
        //Que metodo se va a usar
        public string Metodo { get; set; }

        //Entidad que se va a usar
        public T Entidad { get; set; }

    }
}
