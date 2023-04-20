using System;

namespace RefactoringGuru.DesignPatterns.Composite.Conceptual {
    class Program {
        static void Main(string[] args) {
            Client client = new Client();


            var centroChocolate = new ConcreteComponentB(); // Fijate , esto es "Quien va envolviendo a quien"
            client.ClientCode(centroChocolate);
            concreteDecorator2A capa1 = new concreteDecorator2A(centroChocolate);
            concreteDecorator2B capa2 = new concreteDecorator2B(capa1);

            client.ClientCode(capa2);
            Console.ReadKey();
        }
    }
    public class Client {

        public void ClientCode(Component component) {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }

    public abstract class Component { // ¿Si quiero mas funcionalidades pero no obligadamente juntas,
                                      // aqui iria una <I>?
        public abstract string Operation();
    } // Herencia para "HaceAlgo" (Solo printea algo)

    class ConcreteComponentB : Component {
        public override string Operation() {
            return "Soy el envuelto, el centro de chocolate";
        }
    }

    class ConcreteComponent : Component {
        public override string Operation() {
            return "ConcreteComponent";
        }
    } // Hereda de Component (Y codea algo)

    abstract class Decorator : Component { // Decorador base
        protected Component _component; // Recibe el tipo que se va a envolver.
                                        // Pensar , ¿que pasa si hay mas de 1 envoltorio o lo envuelto?
                                        // ¿Si necesita una "funcionalidad" /= a la de la <I> o C.Abstracta ?
     

        public Decorator(Component component) { // Constructor para ya asignar un componente
            this._component = component;
        }

        public void SetComponent(Component component) { // Set para componente
                                                        // (No tiene que quedarse con el que se construyo)
            this._component = component;
        }

        public override string Operation() { // Si esta vacio dice, sino devuelve quien es/Que tiene
            if (this._component != null) {
                return this._component.Operation();
            } else {
                return string.Empty;
            }
        }
    }

    class ConcreteDecoratorA : Decorator { // Decorador A (Como decir grupo de funciones A o traje de iron man rojo)
        public ConcreteDecoratorA(Component comp) : base(comp) { // Reutiliza codigo, esto era usar una funcion
                                                                 // que fue heredada, tal cual esta definida en el padre
                                                                 // (Creo era el padre de padres, por si hay mas jerarquia)

        }

        public override string Operation() {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    class ConcreteDecoratorB : Decorator { // Decorador B (Este seria otro traje encima del otro traje de ironman)
                                            // El que se cojio a Hulk :v 
        public ConcreteDecoratorB(Component comp) : base(comp) {
        }

        public override string Operation() {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }


    class concreteDecorator2A : Decorator {
        public concreteDecorator2A(Component comp) : base(comp) {
        }
        public override string Operation() {
            return $"Capita de chocolate({base.Operation()})";
        }
    }
    class concreteDecorator2B : Decorator {
        public concreteDecorator2B(Component comp) : base(comp) {
        }
        public override string Operation() {
            return $"Capita de glaseado({base.Operation()})";
        }
    }

}