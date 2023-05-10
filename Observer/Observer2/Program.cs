using System;
using System.Collections.Generic;

namespace Observer2
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(int value);
    }

    public class ConcreteSubject : ISubject
    {
        private int value;
        private List<IObserver> observers = new List<IObserver>();

        public ConcreteSubject()
        {
            value = 0;
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(int value)
        {
            foreach (var observer in observers)
            {
                observer.Update(value);
            }
        }

        public void ChangeValue()
        {
            Random r = new Random();
            value = r.Next(1, 11);
            Console.WriteLine($"Ha salido el {value}");
            Notify(value);
        }
    }

    public interface IObserver
    {
        void Update(int value);
    }

    public class ConcreteObserver : IObserver
    {
        public void Update(int value)
        {
            Console.WriteLine($"El valor de A ha cambiado! Ahora es:{value}");
        }
    }

    public class Program
    {
        public static void Main()
        {
            ConcreteSubject subject = new ConcreteSubject();
            ConcreteObserver observer = new ConcreteObserver();

            subject.Attach(observer);

            subject.ChangeValue();
            subject.ChangeValue();
            subject.ChangeValue();

            Console.ReadKey();
        }
    }
}

