using System.Collections.Generic;
using System;

// Clase Memento que almacena el estado actual de la partida
public class GameMemento
{
    private readonly int _playerLevel;
    private readonly int _playerHealth;
    private readonly int _playerMana;

    public GameMemento(int level, int health, int mana)
    {
        _playerLevel = level;
        _playerHealth = health;
        _playerMana = mana;
    }

    // Métodos getters para recuperar los valores guardados en el Memento
    public int GetPlayerLevel() => _playerLevel;
    public int GetPlayerHealth() => _playerHealth;
    public int GetPlayerMana() => _playerMana;
}

// Clase Originator que crea y almacena los Mementos
public class GameOriginator
{
    private int _playerLevel;
    private int _playerHealth;
    private int _playerMana;

    // Crea un Memento con el estado actual del juego
    public GameMemento SaveGame()
    {
        return new GameMemento(_playerLevel, _playerHealth, _playerMana);
    }

    // Carga un Memento para restaurar el estado anterior del juego
    public void LoadGame(GameMemento memento)
    {
        _playerLevel = memento.GetPlayerLevel();
        _playerHealth = memento.GetPlayerHealth();
        _playerMana = memento.GetPlayerMana();
    }

    // Métodos getters y setters para modificar el estado del juego
    public int GetPlayerLevel() => _playerLevel;
    public void SetPlayerLevel(int level) => _playerLevel = level;
    public int GetPlayerHealth() => _playerHealth;
    public void SetPlayerHealth(int health) => _playerHealth = health;
    public int GetPlayerMana() => _playerMana;
    public void SetPlayerMana(int mana) => _playerMana = mana;
}

// Clase Caretaker que almacena los Mementos
public class GameCaretaker
{
    private List<GameMemento> _mementos = new List<GameMemento>();

    // Agrega un Memento a la lista de Mementos
    public void AddMemento(GameMemento memento)
    {
        _mementos.Add(memento);
    }

    // Obtiene el Memento más reciente de la lista de Mementos
    public GameMemento GetLastMemento()
    {
        if (_mementos.Count == 0)
        {
            return null;
        }

        GameMemento lastMemento = _mementos[_mementos.Count - 1];
        _mementos.RemoveAt(_mementos.Count - 1);
        return lastMemento;
    }
}

// Ejemplo de uso del patrón Memento en un videojuego RPG
public class RPGGame
{
    static void Main()
    {
        GameOriginator game = new GameOriginator();
        GameCaretaker caretaker = new GameCaretaker();

        // El jugador avanza en el juego
        game.SetPlayerLevel(10);
        game.SetPlayerHealth(100);
        game.SetPlayerMana(50);

        // Guardamos la partida actual en un Memento y lo agregamos al Caretaker
        caretaker.AddMemento(game.SaveGame());

        // El jugador sigue avanzando en el juego
        game.SetPlayerLevel(12);
        game.SetPlayerHealth(90);
        game.SetPlayerMana(20);

        // Guardamos la partida actual en un Memento y lo agregamos al Caretaker
        caretaker.AddMemento(game.SaveGame());

        // El jugador quiere volver a un estado anterior del juego
        GameMemento memento = caretaker.GetLastMemento();

        // Si se encontró un Memento, se carga ese estado anterior del juego
        if (memento != null)
        {
            game.LoadGame(memento);
        }

        // El jugador sigue jugando en el estado anterior del juego
        Console.WriteLine($"Player level: {game.GetPlayerLevel()}");
        Console.WriteLine($"Player health: {game.GetPlayerHealth()}");
        Console.WriteLine($"Player mana: {game.GetPlayerMana()}");
        Console.ReadKey();
    }
}

