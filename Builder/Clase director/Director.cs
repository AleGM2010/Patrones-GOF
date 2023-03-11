using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{

    // La clase Director se encarga de utilizar el builder para construir el objeto Personaje
    public class Director
    {
        private readonly IPersonajeBuilder _builder;

        public Director(IPersonajeBuilder builder)
        {
            _builder = builder;
        }

        public void ConstruirPersonaje(string cabello, string ojos, string colorPiel, string raza)
        {
            _builder.SetCabello(cabello);
            _builder.SetOjos(ojos);
            _builder.SetColorPiel(colorPiel);
            _builder.SetRaza(raza);
        }
    }
}
