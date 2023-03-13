using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    // Clase Mapa con Singleton
    public class Mapa
    {
        // Instancia única del mapa
        private static Mapa instancia;

        // Atributos del mapa
        public int ancho;
        public int largo;
        public int nivelDelMar;
        public string[] elementos;

        // Constructor privado
        private Mapa()
        {
            // Inicializar los atributos del mapa
            ancho = 100;
            largo = 100;
            nivelDelMar = 0;
            elementos = new string[ancho * largo];
        }

        // Método para obtener la instancia única del mapa
        public static Mapa ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Mapa();
            }
            return instancia;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mapa mapa = Mapa.ObtenerInstancia();

            // Acceder a los atributos del mapa
            int ancho = mapa.ancho;
            int largo = mapa.largo;
            int nivelDelMar = mapa.nivelDelMar;
            string[] elementos = mapa.elementos;

            // Imprimir información del mapa
            Console.WriteLine("Ancho del mapa: " + ancho);
            Console.WriteLine("Largo del mapa: " + largo);
            Console.WriteLine("Nivel del mar: " + nivelDelMar);
            Console.WriteLine("Número de elementos en el mapa: " + elementos.Length);
            Console.ReadKey();
        }
    }
    /*
    Script de ejemplo en Unity
    public class EjemploMapa : MonoBehaviour
    {
        // Variables para almacenar los datos del mapa
        private int ancho;
        private int largo;
        private int nivelDelMar;
        private string[] elementos;

        // Inicialización
        void Start()
        {
            // Obtener la instancia única del mapa
            Mapa mapa = Mapa.ObtenerInstancia();

            // Acceder a los atributos del mapa
            ancho = mapa.ancho;
            largo = mapa.largo;
            nivelDelMar = mapa.nivelDelMar;
            elementos = mapa.elementos;

            // Imprimir información del mapa
            Debug.Log("Ancho del mapa: " + ancho);
            Debug.Log("Largo del mapa: " + largo);
            Debug.Log("Nivel del mar: " + nivelDelMar);
            Debug.Log("Número de elementos en el mapa: " + elementos.Length);
        }
      }
     */
}
