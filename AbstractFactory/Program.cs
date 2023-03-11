using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la fábrica para los Enanos
            IEquipamientoFactory fabricaEnanos = new ArmaduraEnanoFactory();

            // Crear un casco enano
            ICasco cascoEnano = fabricaEnanos.CrearCasco();

            // Crear una instancia de la fábrica para los Elfos
            IEquipamientoFactory fabricaElfos = new ArmaduraElfoFactory();

            // Crear una espada elfo
            IArma espadaElfo = fabricaElfos.CrearArma();
            IPechera pecheraElfo = fabricaElfos.CrearPechera();

            List<string > equipamiento = new List<string>();
            equipamiento.Add(espadaElfo.Nombre);
            equipamiento.Add(cascoEnano.Nombre);
            equipamiento.Add(pecheraElfo.Nombre);


            foreach (var result in equipamiento){

                Console.WriteLine($"Se ha creado: {result}");
            }

            Console.ReadKey();
        }
    }
}
