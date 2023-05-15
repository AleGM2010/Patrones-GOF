using System;

/*
El patron permite ampliacion porque, crear nuevas funciones solo requiere
Crear una nueva clase que implemente IVisitor , gracias a la relacion entre las clases
que hacen al patron. 
Crear una clase Visitante consta de crear un metodo para cada clase que va a implementar
el metodo. 
 */ 

namespace Visitor
{

    public interface IVisitor
    {
        void Visit(Enemigo enemigo);
        void Visit(Aliado aliado);
    }
    public abstract class Personaje
    {
        public abstract void Accept(IVisitor visitor);
    }
    public class Enemigo : Personaje
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Aliado : Personaje
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    public class CurarVisitor : IVisitor
    {
        public void Visit(Enemigo enemigo)
        {
            // Lógica para curar a un enemigo (si es posible)
            // ...
            Console.WriteLine($"Se ha curado a: {enemigo}");
        }

        public void Visit(Aliado aliado)
        {
            // Lógica para curar a un aliado (si es posible)
            // ...
            Console.WriteLine($"Se ha curado a: {aliado}");
        }
    }

    public class BuffVisitor : IVisitor
    {
        public void Visit(Enemigo enemigo)
        {
            // Lógica para aplicar el buff a un enemigo (si es posible)
            // ...
            Console.WriteLine($"Se ha Buffeado a: {enemigo}");
        }

        public void Visit(Aliado aliado)
        {
            // Lógica para aplicar el buff a un aliado (si es posible)
            // ...
            Console.WriteLine($"Se ha Buffeado a: {aliado}");
        }
    }

    public class Program
    {
        public static void Main()
        {
            Personaje enemigo = new Enemigo();
            Personaje aliado = new Aliado();
            IVisitor curarVisitor = new CurarVisitor();
            IVisitor buffVisitor = new BuffVisitor();

            enemigo.Accept(curarVisitor);
            aliado.Accept(curarVisitor);
            enemigo.Accept(buffVisitor);
            aliado.Accept(buffVisitor);


            Console.ReadKey();
        }
    }
}