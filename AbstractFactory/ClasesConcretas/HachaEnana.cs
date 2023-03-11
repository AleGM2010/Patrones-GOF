using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    // Implementación concreta de los objetos relacionados con la fábrica enano
    public class HachaEnana : IArma
    {
        public string Nombre => "Hacha de los Enanos";
    }

}
