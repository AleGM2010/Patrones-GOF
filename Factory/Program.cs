using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{

    class Program
    {
        static void Main(string[] args)
        {

            List<IEnemy> EnemyTeam = new List<IEnemy>();
            
            EnemyTeam.Add(EnemyFactory.CreateEnemy("skeleton"));
            EnemyTeam.Add(EnemyFactory.CreateEnemy("goblin"));
            EnemyTeam.Add(EnemyFactory.CreateEnemy("skeleton",60,20));
            EnemyTeam.Add(EnemyFactory.CreateEnemy("goblin", 200, 10));

            foreach (var e in EnemyTeam)
            {
            Console.WriteLine($"Name: {e.GetName()}, Health: {e.GetHealth()}, Attack Damage: {e.GetAttackDamage()}");
            }
            Console.ReadKey();


            // ¿Si quisiera agregar por ejemplo: Un Arquero esqueleto , con un atributo 
            // nuevo , "Rango" y que en consola pudiera ver con 1 metodo , cada componente que tiene 
            // cualquier enemigo , como haria?
            // En principio se puede hacer ArcherSkeleton: Skeleton , agregarle el atributo
            // En la interfaz enemy , agregar la firma de un metodo void LookAtributes , donde 
            // Skeleton  , Goblin , ArcherSkeleton modifiquen para si ese metodo en el que usan sus 
            // Get para mostrar un mensaje en pantalla , entonces luego solo se usa un foreach
            // Para enemy.LookAtributes y listo. Polimorfismo y Herencia , lo que queda es 
            // Ir a la EnemyFactory y agregar este tipo de enemigo y en su metodo sobrecargado
        }
    }


} // Fin factory

