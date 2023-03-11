using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{   // Implementación concreta de los objetos relacionados con la fábrica enano
    public class PecheraEnana : IPechera
    {
        public string Nombre => "Pechera de los Enanos";
    }
}
