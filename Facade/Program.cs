using System;

namespace RefactoringGuru.DesignPatterns.Facade.Conceptual {
    class Program {
        static void Main(string[] args) {

            Subsystem1 subsystem1 = new Subsystem1(); // Crea SubSystema 1 y 2
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2); // Llama a "Fachada" construyendolo con SS1 y SS2
            Client.ClientCode(facade); // Le pasa al cliente, Dicha fachada. en el metodo CodigoCliente
        }
    }

    class Client {

        public static void ClientCode(Facade facade) {
            Console.Write(facade.Operation()); // El cliente hace uso de alguna operacion que Pertenece a "fachada"
        }
    }
    public class Subsystem1 { // Clase subsistema 1 donde este sistema "se encarga de ciertas cosas"
        public string operation1() {
            return "Subsystem1: Ready! (SS1)\n";
        }
        public string operationN() {
            return "Subsystem1: Go! (SS1)\n";
        }
    }

    public class Subsystem2 { // Al igual que subsistema1 , este es el 2 y realiza otras tareas
        public string operation1() {
            return "Subsystem2: Get ready! (SS2)\n";
        }
        public string operationZ() {
            return "Subsystem2: Fire! (SS2)\n";
        }
    }

    public class Facade { // Posee tantas variables como subsistemas existen
                          // (Ya que actua de portero o bibliotecario a lo Ready player one)
        protected Subsystem1 _subsystem1;
        protected Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2) { // Solo es el constructor con sus sistemas
            this._subsystem1 = subsystem1;
            this._subsystem2 = subsystem2;
        }

        public string Operation() { // operacion en este caso, llama a todo lo que tiene
                                    // (Bien puede ser recolectar todas las funciones por nombre que
                                    // posee cada substitema y no necesariamente "que hagan" lo que
                                    // tengan que hacer (como reportarse))

            string result = "Facade initializes subsystems:\n";
            result += this._subsystem1.operation1();
            result += this._subsystem2.operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += this._subsystem1.operationN();
            result += this._subsystem2.operationZ();
            return result;
        }
    }
}
