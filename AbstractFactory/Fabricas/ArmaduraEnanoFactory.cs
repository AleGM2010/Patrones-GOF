using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    // Implementación concreta de la fábrica abstracta para crear objetos específicos

    public class ArmaduraEnanoFactory : IEquipamientoFactory
    {
        public IArma CrearArma()
        {
            return new HachaEnana();
        }

        public IPechera CrearPechera()
        {
            return new PecheraEnana();
        }

        public ICasco CrearCasco()
        {
            return new CascoEnano();
        }
    }
}
