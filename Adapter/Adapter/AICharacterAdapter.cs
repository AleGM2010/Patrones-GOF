namespace StrategyGame
{
    // Clase Adapter que adapta los personajes controlados por IA a la interfaz de los personajes controlados por el jugador
    public class AICharacterAdapter : IPlayerCharacter  
    {
        private readonly IAICharacter _aiCharacter;

        public AICharacterAdapter(IAICharacter aiCharacter)
        {
            _aiCharacter = aiCharacter;
        }
        public void Move()
        {
            _aiCharacter.Move();
        }
        public void Attack()
        {
            _aiCharacter.Attack();
        }

        public void Defend()
        {
            _aiCharacter.Defend();
        }
    }
}


