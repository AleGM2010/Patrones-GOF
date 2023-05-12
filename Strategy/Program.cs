using System;
using System.Collections.Generic;


namespace Strategy
{
    // Interfaz para las estrategias de ataque
    // Contrato de firma para una "Estrategia" de Ataque. 
    public interface IAttackStrategy
    {
        void Attack();
    }

    // Implementación de la estrategia de ataque "Melee con hacha"
    // (Estrategia Concreta)
    public class MeleeAxeAttackStrategy : IAttackStrategy
    {
        public void Attack()
        {
            Console.WriteLine("El jugador ataca en melee con un hacha.");
        }
    }

    // Implementación de la estrategia de ataque "Melee con espada"
    // (Estrategia Concreta)
    public class MeleeSwordAttackStrategy : IAttackStrategy
    {
        public void Attack()
        {
            Console.WriteLine("El jugador ataca en melee con una espada.");
        }
    }

    // Implementación de la estrategia de ataque "Ataque mágico de fuego"
    // (Estrategia Concreta)
    public class FireMagicAttackStrategy : IAttackStrategy
    {
        public void Attack()
        {
            Console.WriteLine("El jugador realiza un ataque mágico de fuego.");
        }
    }

    // Implementación de la estrategia de ataque "Ataque mágico de hielo"
    // (Estrategia Concreta)
    public class IceMagicAttackStrategy : IAttackStrategy
    {
        public void Attack()
        {
            Console.WriteLine("El jugador realiza un ataque mágico de hielo.");
        }
    }

    // Implementación de la estrategia de ataque "Ataque a distancia con arco"
    // (Estrategia Concreta)
    public class BowRangeAttackStrategy : IAttackStrategy
    {
        public void Attack()
        {
            Console.WriteLine("El jugador ataca a distancia con un arco.");
        }
    }

    // Implementación de la estrategia de ataque "Ataque a distancia con boomerang"
    // (Estrategia Concreta)
    public class BoomerangRangeAttackStrategy : IAttackStrategy
    {
        public void Attack()
        {
            Console.WriteLine("El jugador ataca a distancia con un boomerang.");
        }
    }

    // Clase para el jugador (Contexto)
    public class Player
    {
        private IAttackStrategy _attackStrategy;

        // Establece la estrategia de ataque actual
        public void SetAttackStrategy(IAttackStrategy attackStrategy)
        {
            _attackStrategy = attackStrategy;
        }

        // Ejecuta la estrategia de ataque actual
        public void Attack()
        {
            _attackStrategy.Attack();
        }
    }

    // Ejemplo de uso del patrón de diseño Strategy con nuevas opciones de ataque
    public class RPGGame
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            // El jugador ataca en melee con un hacha
            player.SetAttackStrategy(new MeleeAxeAttackStrategy());
            player.Attack();

            // El jugador ataca en melee con una espada
            player.SetAttackStrategy(new MeleeSwordAttackStrategy());
            player.Attack();

            // El jugador realiza un ataque mágico de fuego
            player.SetAttackStrategy(new FireMagicAttackStrategy());
            player.Attack();

            // El jugador realiza un ataque mágico de hielo
            player.SetAttackStrategy(new IceMagicAttackStrategy());
            player.Attack();

            // El jugador ataca a distancia con un arco
            player.SetAttackStrategy(new BowRangeAttackStrategy());
            player.Attack();

            // El jugador ataca a distancia con un boomerang
            player.SetAttackStrategy(new BoomerangRangeAttackStrategy());
            player.Attack();

            Console.ReadKey();
        }
    }

}
