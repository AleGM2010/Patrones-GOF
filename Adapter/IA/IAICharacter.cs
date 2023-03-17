namespace StrategyGame
{
    // Interfaz que define los métodos que deben implementar los personajes controlados por IA
    public interface IAICharacter
    {
        void Move();
        void Attack();
        void Defend();
    }
}


