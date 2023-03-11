using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class program
    {
        public static void Main(string[] args)
    {
            // Creamos un objeto PersonajeBuilder
            IPersonajeBuilder builder = new PersonajeBuilder();

            // Creamos un objeto Director y le pasamos el builder
            Director director = new Director(builder);

            // Construimos el personaje utilizando el Director y diferentes opciones
            director.ConstruirPersonaje("Rubio", "Verdes", "Blanca", "Humano");

            // Obtenemos el objeto Personaje construido por el builder
            Personaje personaje = builder.Build();

            // Imprimimos los atributos del objeto Personaje
            Console.WriteLine($"Cabello: {personaje.Cabello}");
            Console.WriteLine($"Ojos: {personaje.Ojos}");
            Console.WriteLine($"Color de piel: {personaje.ColorPiel}");
            Console.WriteLine($"Raza: {personaje.Raza}");

            // Construimos otro personaje con diferentes opciones
            director.ConstruirPersonaje("Negro", "Azules", "Negra", "Elfo");

            // Obtenemos el objeto Personaje construido por el builder
            personaje = builder.Build();

            // Imprimimos los atributos del objeto Personaje
            Console.WriteLine($"Cabello: {personaje.Cabello}");
            Console.WriteLine($"Ojos: {personaje.Ojos}");
            Console.WriteLine($"Color de piel: {personaje.ColorPiel}");
            Console.WriteLine($"Raza: {personaje.Raza}");

            Console.ReadKey();
        }

    }



}
