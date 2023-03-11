using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    // Implementación concreta de los objetos relacionados con la fábrica elfo
    public class CascoElfo : ICasco
    {
        public string Nombre => "Casco de los Elfos";
    }
}
