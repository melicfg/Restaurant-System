using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Idble<T>
    {

        protected Idble(T id)
        {
            Id = id;
        }

        public T Id { get; }

    }
}
