using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{


    // Implementación concreta de los objetos relacionados con la fábrica elfo
    public class EspadaElfo : IArma
    {
        public string Nombre => "Espada de los Elfos";
    }
}
