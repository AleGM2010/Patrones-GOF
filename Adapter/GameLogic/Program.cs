using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame
{
    public class program
    {
         // Ejemplo de uso del juego
        static void Main(string[] args)
        {
            Game game = new Game();
    
            // Añadir personajes controlados por el jugador
            game.AddPlayerCharacter(new PlayerCharacter());
            game.AddPlayerCharacter(new PlayerCharacter());
    
            // Añadir personajes controlados por IA, adaptándolos a la interfaz de los personajes controlados por el jugador
            game.AddAICharacter(new AICharacter());
            game.AddAICharacter(new AICharacter());
    
            // Jugar
            game.Play();
    
            Console.ReadKey();
        }
    }
}