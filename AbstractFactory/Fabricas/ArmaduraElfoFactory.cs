using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    // Implementación concreta de la fábrica abstracta para crear objetos específicos
    public class ArmaduraElfoFactory : IEquipamientoFactory
    {
        public IArma CrearArma()
        {
            return new EspadaElfo();
        }

        public IPechera CrearPechera()
        {
            return new PecheraElfo();
        }

        public ICasco CrearCasco()
        {
            return new CascoElfo();
        }
    }
}
