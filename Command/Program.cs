using System;
using System.Collections.Generic;

namespace Command
{
    public interface IBeverageCommand
    {
        void Execute();
    }

    public class AddIngredientCommand : IBeverageCommand
    {
        private readonly string _ingredient;

        public AddIngredientCommand(string ingredient)
        {
            _ingredient = ingredient;
        }

        public void Execute()
        {
            Console.WriteLine($"Agregando {_ingredient}...");
        }
    }

    public class BrewCommand : IBeverageCommand
    {
        public void Execute()
        {
            Console.WriteLine("Preparando el café...");
        }
    }

    public class ServeCommand : IBeverageCommand
    {
        public void Execute()
        {
            Console.WriteLine("Sirviendo la bebida...");
        }
    }

    public class Beverage
    {
        private readonly List<IBeverageCommand> _commands;

        public Beverage()
        {
            _commands = new List<IBeverageCommand>();
        }

        public void AddCommand(IBeverageCommand command)
        {
            _commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (var command in _commands)
            {
                command.Execute();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var beverage = new Beverage();
            beverage.AddCommand(new AddIngredientCommand("café"));
            beverage.AddCommand(new AddIngredientCommand("agua caliente"));
            beverage.AddCommand(new BrewCommand());
            beverage.AddCommand(new ServeCommand());

            beverage.ExecuteCommands();
            Console.ReadKey();
        }
    }
}
