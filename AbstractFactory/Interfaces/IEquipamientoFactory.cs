using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    // Interfaz de la fábrica abstracta
    public interface IEquipamientoFactory
    {
        IArma CrearArma();
        IPechera CrearPechera();
        ICasco CrearCasco();
    }
}
