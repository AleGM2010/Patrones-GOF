using System;

namespace StrategyGame
{
    // Clase que representa un personaje controlado por IA
    public class AICharacter : IAICharacter
    {
        public void Move()
        {
            Console.WriteLine("Moving AI character.");
        }
        public void Attack()
        {
            Console.WriteLine("AI character is attacking.");
        }
        public void Defend()
        {
            Console.WriteLine("AI character is defending.");
        }
    }
}


