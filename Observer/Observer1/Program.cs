using System;
using System.Collections.Generic;


namespace Observer // for using this do "using Observer" like "using [namespace]
{

    public class ConcreteClassA
    {
        private int value;

        public ConcreteClassA()
        {
            value = 0;
        }

        public void ChangeValue()
        {
            Random r = new Random();
            value = r.Next(1, 11);
            Console.WriteLine($"Ha salido el {value}");
            EventManager.Notify(value);
            
        }
    }

    static class EventManager
    {
        public static event Action<int> ValueChanged;     

        public static void Notify(int value)
        {
            ValueChanged.Invoke(value);
        }

    }
 
    public class ConcreteSuscriber
    {
        public void DoStuff(int value)
        {
            Console.WriteLine($"El valor de A ha cambiado! Ahora es:{value}");
        }
    }

    public class Program
    {
        public static void Main()
        {
            ConcreteClassA a = new ConcreteClassA();
            ConcreteSuscriber b = new ConcreteSuscriber();
            EventManager.ValueChanged += b.DoStuff;

            a.ChangeValue();
            a.ChangeValue();
            a.ChangeValue();

            Console.ReadKey();
        }
    }
}