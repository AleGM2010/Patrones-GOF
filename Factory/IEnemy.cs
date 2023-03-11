using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    // La interfaz IEnemy define los métodos comunes que los enemigos deben tener
    public interface IEnemy
    {
        string GetName();
        int GetHealth();
        int GetAttackDamage();
    }
}
