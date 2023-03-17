using System;


namespace StrategyGame
{
    // Clase que representa un personaje controlado por el jugador
    public class PlayerCharacter : IPlayerCharacter
    {
        public void Move()
        {
            Console.WriteLine("Moving player character.");
        }

        public void Attack()
        {
            Console.WriteLine("Player character is attacking.");
        }

        public void Defend()
        {
            Console.WriteLine("Player character is defending.");
        }
    }
}


