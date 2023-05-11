<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Abstracción que representa un arma
public abstract class Weapon
{
    // Composición con la implementación de Effect para el efecto de daño
    protected IEffect damageEffect;

    public Weapon(IEffect damageEffect)
    {
        this.damageEffect = damageEffect;
    }

    // Método abstracto que deberá ser implementado por las subclases para su uso en el juego
    public abstract void Use();
}

// Implementación de la interfaz IEffect para el efecto de daño
public interface IEffect
{
    int CalculateDamage(int damage);
}

// Implementación concreta de IEffect para un efecto de daño simple
public class SimpleDamageEffect : IEffect
{
    public int CalculateDamage(int damage)
    {
        return damage;
    }
}

// Implementación concreta de IEffect para un efecto de daño crítico
public class CriticalDamageEffect : IEffect
{
    public int CalculateDamage(int damage)
    {
        return damage * 2; // Daño crítico doble
    }
}

// Subclase que representa un tipo de arma concreto (ej. espada)
public class Sword : Weapon
{
    public Sword(IEffect damageEffect) : base(damageEffect)
    {
    }

    public override void Use()
    {
        int baseDamage = 10; // Daño base de la espada
        int totalDamage = damageEffect.CalculateDamage(baseDamage); // Aplicar efecto de daño
        Console.WriteLine("Usando espada: " + totalDamage + " de daño.");
    }
}

// Subclase que representa otro tipo de arma concreto (ej. arco)
public class Bow : Weapon
{
    public Bow(IEffect damageEffect) : base(damageEffect)
    {
    }

    public override void Use()
    {
        int baseDamage = 8; // Daño base del arco
        int totalDamage = damageEffect.CalculateDamage(baseDamage); // Aplicar efecto de daño
        Console.WriteLine("Usando arco: " + totalDamage + " de daño.");
    }
}

// Clase principal del juego que utiliza las armas
public class Game
{

    public static void Main()
    {


        // Crear una espada con efecto de daño simple
        Sword sword = new Sword(new SimpleDamageEffect());
        sword.Use(); // Salida esperada: "Usando espada: 10 de daño."

        

        // Crear un arco con efecto de daño crítico
        Bow bow = new Bow(new CriticalDamageEffect());
        bow.Use(); // Salida esperada: "Usando arco: 16 de daño."

        
    }
}

=======
﻿using System;

namespace RefactoringGuru.DesignPatterns.Bridge.Conceptual {


    class Program {
        static void Main(string[] args) {
            Client client = new Client();

            Abstraction abstraction;

            abstraction = new Abstraction(new ConcreteImplementationA());
            client.ClientCode(abstraction);

            Console.WriteLine();

            abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
            client.ClientCode(abstraction);
        }
    }
    class Client {
        public void ClientCode(Abstraction abstraction) {
            Console.Write(abstraction.Operation());
        }
    }

    class Abstraction {
        protected IImplementation _implementation;

        public Abstraction(IImplementation implementation) {
            this._implementation = implementation;
        }

        public virtual string Operation() {
            return "Abstract: Base operation with:\n" +
                _implementation.OperationImplementation();
        }
    }

    class ExtendedAbstraction : Abstraction {
        public ExtendedAbstraction(IImplementation implementation) : base(implementation) {
        }

        public override string Operation() {
            return "ExtendedAbstraction: Extended operation with:\n" +
                base._implementation.OperationImplementation();
        }
    }

    public interface IImplementation {
        string OperationImplementation();
    }

    class ConcreteImplementationA : IImplementation {
        public string OperationImplementation() {
            return "ConcreteImplementationA: The result in platform A.\n";
        }
    }

    class ConcreteImplementationB : IImplementation {
        public string OperationImplementation() {
            return "ConcreteImplementationA: The result in platform B.\n";
        }
    }


}
>>>>>>> 72ee8e37255ec0f72214eaa05f154b66d15cf46d
