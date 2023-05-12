using System;
using System.Collections.Generic;

namespace State
{   
    // Clase que representa al jugador del videojuego
    public class Player
    {
        private string name;
        private PlayerState state;
    
        public Player(string name)
        {
            this.name = name;
        }
    
        // Cambia el estado del jugador
        public void SetState(PlayerState state)
        {
            this.state = state;
            Console.WriteLine($"El jugador {name} cambia al estado {state.GetType().Name}");
        }
    
        // Ataca a un enemigo
        public void Attack()
        {
            state.Attack();
        }
    
        // Camina en el mundo del juego
        public void Walk()
        {
            state.Walk();
        }
    
        // Salta en el mundo del juego
        public void Jump()
        {
            state.Jump();
        }
    
        // Usa una poción durante una batalla
        public void UsePotion()
        {
            state.UsePotion();
        }
    
        // Se defiende durante una batalla
        public void Defend()
        {
            state.Defend();
        }
    }
    
    // Clase abstracta que representa un estado del jugador
    public abstract class PlayerState
    {
        public abstract void Attack();
        public abstract void Walk();
        public abstract void Jump();
        public abstract void UsePotion();
        public abstract void Defend();
    }
    
    // Clase que representa el estado "Idle" del jugador
    public class IdleState : PlayerState
    {
        public override void Attack()
        {
            Console.WriteLine("El jugador está inactivo y no puede atacar.");
        }
    
        public override void Walk()
        {
            Console.WriteLine("El jugador camina por el mundo del juego.");
        }
    
        public override void Jump()
        {
            Console.WriteLine("El jugador salta en el mundo del juego.");
        }
    
        public override void UsePotion()
        {
            Console.WriteLine("El jugador no está en combate y no puede usar pociones.");
        }
    
        public override void Defend()
        {
            Console.WriteLine("El jugador no está en combate y no puede defenderse.");
        }
    }
    
    // Clase que representa el estado "Combat" del jugador
    public class CombatState : PlayerState
    {
        public override void Attack()
        {
            Console.WriteLine("El jugador ataca al enemigo.");
        }
    
        public override void Walk()
        {
            Console.WriteLine("El jugador está en combate y no puede caminar.");
        }
    
        public override void Jump()
        {
            Console.WriteLine("El jugador está en combate y no puede saltar.");
        }
    
        public override void UsePotion()
        {
            Console.WriteLine("El jugador usa una poción para recuperar vida.");
        }
    
        public override void Defend()
        {
            Console.WriteLine("El jugador se defiende del ataque enemigo.");
        }
    }

    // Ejemplo de uso del patrón State en un videojuego RPG
    public class RPGGame
    {
        static void Main()
        {
            /*
         La clase Player representa al jugador del videojuego, mientras que 
         las clases PlayerState, IdleState y CombatState representan el estado actual 
         del jugador. La clase Player tiene un método SetState() que cambia el 
         estado del jugador. Los métodos Attack(), Walk(), Jump(), UsePotion() y 
         Defend() de la clase Player delegan su comportamiento al estado actual del jugador.
             */
            // Creamos un nuevo jugador
            Player player = new Player("John Due");

            // El jugador inicia el juego en el estado "Idle"
            player.SetState(new IdleState());

            // El jugador interactúa con el mundo del juego
            player.Attack();
            player.Walk();
            player.Jump();

            // El jugador encuentra un enemigo y cambia al estado "Combat"
            player.SetState(new CombatState());

            // El jugador lucha contra el enemigo
            player.Attack();
            player.UsePotion();
            player.Defend();

            // El jugador regresa al estado "Idle"
            player.SetState(new IdleState());

            // El jugador continúa interactuando con el mundo del juego
            player.Walk();
            player.Jump();

            Console.ReadKey();
        }
    }
}