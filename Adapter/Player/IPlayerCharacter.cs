namespace StrategyGame
{
    // Interfaz que define los métodos que deben implementar los personajes controlados por el jugador
    public interface IPlayerCharacter
    {
        void Move();
        void Attack();
        void Defend();
    }
}


