using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    // Interfaz que define el método Clone para clonar un objeto
    public interface IEnemigoClone
    {
        IEnemigoClone Clone();
    }

    // Clase concreta Orco que implementa la interfaz IEnemigo
    public class Orco : IEnemigoClone
    {
        private int nivel;
        private int puntosVida;

        public Orco(int nivel, int puntosVida)
        {
            this.nivel = nivel;
            this.puntosVida = puntosVida;
        }

        // Implementación del método Clone que crea un nuevo objeto Orco con los mismos valores de nivel y puntosVida
        public IEnemigoClone Clone()
        {
            return new Orco(this.nivel, this.puntosVida);
        }

        public override string ToString()
        {
            return "Orco de nivel " + this.nivel + " con " + this.puntosVida + " puntos de vida.";
        }
    }

    // Clase concreta Troll que implementa la interfaz IEnemigo

    public class Troll : IEnemigoClone
    {
        private int nivel;
        private int puntosVida;

        public Troll(int nivel, int puntosVida)
        {
            this.nivel = nivel;
            this.puntosVida = puntosVida;
        }

        // Implementación del método Clone que crea un nuevo objeto Troll con los mismos valores de nivel y puntosVida
        public IEnemigoClone Clone()
        {
            return new Troll(this.nivel, this.puntosVida);
        }

        public override string ToString()
        {
            return "Troll de nivel " + this.nivel + " con " + this.puntosVida + " puntos de vida.";
        }
    }
    // Clase concreta Dragon que implementa la interfaz IEnemigo

    public class Dragon : IEnemigoClone
    {
        private int nivel;
        private int puntosVida;

        public Dragon(int nivel, int puntosVida)
        {
            this.nivel = nivel;
            this.puntosVida = puntosVida;
        }

        // Implementación del método Clone que crea un nuevo objeto Dragon con los mismos valores de nivel y puntosVida
        public IEnemigoClone Clone()
        {
            return new Dragon(this.nivel, this.puntosVida);
        }

        public override string ToString()
        {
            return "Dragon de nivel " + this.nivel + " con " + this.puntosVida + " puntos de vida.";
        }
    }

    // Clase que contiene un diccionario con los prototipos de enemigos y los métodos para clonarlos
    public class EnemigoFactory
    {
        private Dictionary<string, IEnemigoClone> prototipos = new Dictionary<string, IEnemigoClone>();

        // Constructor que inicializa los prototipos de enemigos
        public EnemigoFactory()
        {
            this.prototipos.Add("orco", new Orco(1, 100));
            this.prototipos.Add("troll", new Troll(3, 300));
            this.prototipos.Add("dragon", new Dragon(5, 500));
        }

        // Método que devuelve una copia del prototipo de enemigo especificado
        public IEnemigoClone CrearEnemigo(string tipo)
        {
            return this.prototipos[tipo].Clone();
        }
    }

    public class EjercitoEnemigos
    {
        private readonly IEnemigoClone _prototipo;
        public EjercitoEnemigos(IEnemigoClone prototipo){
            _prototipo = prototipo;
        }

        public List<IEnemigoClone> Ejercito(int numero){
            List<IEnemigoClone> lista = new List<IEnemigoClone>();

            for (int i = 0; i < numero; i++){
                IEnemigoClone enemigo = _prototipo.Clone();
                lista.Add(enemigo);
            }
            return lista;
        }
    }
    // Ejemplo de uso
    public class Program
    {
        public static void Main()
        {
            EnemigoFactory factory = new EnemigoFactory();

            IEnemigoClone orco = factory.CrearEnemigo("orco");
            IEnemigoClone troll = factory.CrearEnemigo("troll");
            IEnemigoClone dragon = factory.CrearEnemigo("dragon");

            // Concat devuelve una lista , por lo que debe asignarse a algo , sino el resultado se pierde
            List<IEnemigoClone> GranEjercito =  new EjercitoEnemigos(orco).Ejercito(10).Concat(
                                                new EjercitoEnemigos(troll).Ejercito(3)).Concat(
                                                new EjercitoEnemigos(dragon).Ejercito(5)).ToList();
         
            foreach (var d in GranEjercito)
            {
                Console.WriteLine("Enemigo: " + d);
            }
            Console.ReadKey();

            /* Esto solo demuestra que IEnemigoClone puede contener Dragon , al revez no
            Dragon modeloDragon = new Dragon(10,500);
            IEnemigoClone DragonCopia =  modeloDragon.Clone();
            List<IEnemigoClone> a = new List<IEnemigoClone>() { modeloDragon, DragonCopia };
             */
        }
    }
}
