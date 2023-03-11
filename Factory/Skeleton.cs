using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    // La clase Skeleton es un ejemplo de un enemigo concreto que implementa la interfaz IEnemy
    public class Skeleton : IEnemy
    {
        private string name;
        private int health;
        private int attackDamage;

        public Skeleton(string name, int health, int attackDamage)
        {
            this.name = name;
            this.health = health;
            this.attackDamage = attackDamage;
        }

        public string GetName()
        {
            return name;
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetAttackDamage()
        {
            return attackDamage;
        }
    }
}
