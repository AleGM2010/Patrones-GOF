using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    // La clase EnemyFactory es la clase (Creadora) Factory que crea los diferentes tipos de enemigos
    public class EnemyFactory
    {
        // El método CreateEnemy recibe un parámetro string que indica el tipo de enemigo que se desea crear
        // Retorna un objeto que implementa la interfaz IEnemy
        public static IEnemy CreateEnemy(string enemyType)
        {
            switch (enemyType.ToLower())
            {
                case "skeleton":
                    return new Skeleton("Skeleton", 100, 10);
                case "goblin":
                    return new Goblin("Goblin", 80, 15);
                // Agregar otros tipos de enemigos aquí
                default:
                    throw new ArgumentException("Invalid enemy type");
            }
        }

        // Sobrecarga del constructor con mas control sobre vida y daño 
        public static IEnemy CreateEnemy(string enemyType, int health, int attackDamage)
        {
            switch (enemyType.ToLower())
            {
                case "skeleton":
                    return new Skeleton("Skeleton", health, attackDamage);
                case "goblin":
                    return new Goblin("Goblin", health, attackDamage);
                // Agregar otros tipos de enemigos aquí
                default:
                    throw new ArgumentException("Invalid enemy type");
            }
        }
    }
}
