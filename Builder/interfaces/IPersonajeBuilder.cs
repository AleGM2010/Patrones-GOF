using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    // La interfaz IPersonajeBuilder define los métodos necesarios para construir un objeto Personaje
    public interface IPersonajeBuilder
    {
        void SetCabello(string cabello);
        void SetOjos(string ojos);
        void SetColorPiel(string colorPiel);
        void SetRaza(string raza);
        Personaje Build();
    }
}
