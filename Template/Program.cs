using System;
using System.Collections.Generic;

namespace Template
{
    namespace RPGGame
    {
        public abstract class CharacterTemplate
        {
            public void PlayTurn()
            {
                Move();
                if (this is Bard)
                {
                    AditionalAction();
                }
                else
                {
                    Attack();
                }

                EndTurn();
            }
            protected virtual void Move()
            {
                Console.WriteLine("Moving...");
            }

            protected virtual void Attack() { }

            protected virtual void EndTurn()
            {
                Console.WriteLine("Ending turn...");
            }

            protected virtual void AditionalAction(){ }
        }

        public class Warrior : CharacterTemplate
        {
            protected override void Attack()
            {
                Console.WriteLine("Warrior is using a melee attack!");
            }
        }

        public class Mage : CharacterTemplate
        {
            protected override void Attack()
            {
                Console.WriteLine("Mage is casting a spell!");
            }
        }

        public class Bard : CharacterTemplate
        {
            // propiedades y métodos existentes aquí
            
            protected override void AditionalAction()
            {
                // El bardo no ataca, así que no hay implementación aquí.
                // En su lugar, se llama al método Sing.
                Sing();
            }

            private void Sing()
            {
                Console.WriteLine("Bard is singing!.");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                var warrior = new Warrior();
                var mage = new Mage();
                var bard = new Bard();

                Console.WriteLine("Warrior's turn:");
                warrior.PlayTurn();

                Console.WriteLine("\nMage's turn:");
                mage.PlayTurn();

                Console.WriteLine("\nBard's turn:");
                bard.PlayTurn();

                Console.ReadKey();
            }
        }
    }
}