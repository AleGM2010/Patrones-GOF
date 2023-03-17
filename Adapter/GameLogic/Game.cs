using System.Collections.Generic;


namespace StrategyGame
{
    // Clase que representa el juego
    public class Game
    {
            private List<IPlayerCharacter> _playerCharacters;

        public Game()
        {
            _playerCharacters = new List<IPlayerCharacter>();
        }

        // Método que añade un personaje controlado por el jugador al juego
        public void AddPlayerCharacter(IPlayerCharacter playerCharacter)
        {
            _playerCharacters.Add(playerCharacter);
        }

        // Método que añade un personaje controlado por IA al juego, adaptándolo primero a la interfaz de los personajes controlados por el jugador
        public void AddAICharacter(IAICharacter aiCharacter)
        {
            IPlayerCharacter adaptedCharacter = new AICharacterAdapter(aiCharacter);
            _playerCharacters.Add(adaptedCharacter);
        }

        // Método que simula una jugada del juego, haciendo que cada personaje controlado por el jugador se mueva, ataque o defienda
        public void Play()
        {
            foreach (IPlayerCharacter playerCharacter in _playerCharacters)
            {
                playerCharacter.Move();
                playerCharacter.Attack();
                playerCharacter.Defend();
            }
        }
    }
}


