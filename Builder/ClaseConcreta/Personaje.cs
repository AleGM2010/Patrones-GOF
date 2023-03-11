using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // La clase Personaje representa el objeto que queremos construir
    public class Personaje
    {
        public string Cabello { get; set; }
        public string Ojos { get; set; }
        public string ColorPiel { get; set; }
        public string Raza { get; set; }

        public Personaje(string cabello, string ojos, string colorPiel, string raza)
        {
            Cabello = cabello;
            Ojos = ojos;
            ColorPiel = colorPiel;
            Raza = raza;
        }
    }
}
