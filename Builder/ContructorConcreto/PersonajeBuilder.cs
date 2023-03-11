using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // La clase PersonajeBuilder implementa la interfaz IPersonajeBuilder y se encarga de construir el objeto Personaje
    public class PersonajeBuilder : IPersonajeBuilder

    {
        private string _cabello;
        private string _ojos;
        private string _colorPiel;
        private string _raza;

        public void SetCabello(string cabello)
        {
            _cabello = cabello;
        }
        public void SetOjos(string ojos)
        {
            _ojos = ojos;
        }
        public void SetColorPiel(string colorPiel)
        {
            _colorPiel = colorPiel;
        }
        public void SetRaza(string raza)
        {
            _raza = raza;
        }

        public Personaje Build() // Build es el metodo , Personaje es la firma
        {
            return new Personaje(_cabello, _ojos, _colorPiel, _raza);
        }
    }
}
