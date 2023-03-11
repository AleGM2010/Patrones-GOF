using System;
using System.Collections.Generic;

namespace RefactoringGuru.DesignPatterns.ChainOfResponsibility.Conceptual
{
    public interface IHandler // La interfaz "YoSoyAyudador"
    {
        IHandler SetNext(IHandler handler); // Comienza con IHandler porque va a apuntar 
                                            // Hacia un elemento que SI O SI implemente IHandler
                                            // internamente ese IHandler se llamara handler
                                            // (Recordar el uso del foreach con una Interfaz)
         object Handle(object request);      // Similar a lo anterior
    }

    abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;
        public IHandler SetNext(IHandler handler) // Encadena "Handlers" 
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual object Handle(object request) // Si este no contiene la request, avanza
                                                     // Lo hace con nextHandler.Handle(request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
    class HumanHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Cup of coffee")
            {
                return $"Human: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
    class MonkeyHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string) == "Banana")
            {
                return $"Monkey: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class SquirrelHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "Nut")
            {
                return $"Squirrel: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class DogHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request.ToString() == "MeatBall")
            {
                return $"Dog: I'll eat the {request.ToString()}.\n";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class Client
    {
        // El cliente es la clase que contiene "Todo lo que se le pide al programa" , 
        // porque aqui se cree que el cliente es quien desea y sabe que es lo que quiere 
        // solicitar... de forma inteligente se coloca una lista con new en un foreach
        public static void ClientCode(AbstractHandler handler)
        {
            foreach (var food in new List<string> { "Nut", "Banana", "Cup of coffee", "Soup" })
            {
                Console.WriteLine($"Client: Who wants a {food}?");
                var result = handler.Handle(food);

                if (result != null)
                {
                    Console.Write($"   {result}");
                }
                else
                {
                    Console.WriteLine($"   {food} was left untouched.");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Se crean los "Helpers"
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();
            var human = new HumanHandler();

            // Se "Encadenan" los helpers (Responsabiliad conectada porque si X no tiene
            // le pasa la papa caliente al otro)
            monkey.SetNext(squirrel).SetNext(dog).SetNext(human);

        
            // Como estan conectados , las siguientes lineas deciden desde que punto comenzar a hacer 
            // las pruebas o solicitudes , IMPORTA el orden e IMPORTA desde donde se pide.
            // por lo tanto
            Console.WriteLine("Chain: Monkey > Squirrel > Dog > Human\n");
            Client.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Subchain: Squirrel > Dog > Human\n");
            Client.ClientCode(squirrel);

            Console.ReadKey();
        }
    }
}