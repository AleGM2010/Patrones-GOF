using System;

namespace RefactoringGuru.DesignPatterns.Proxy.Conceptual {
    class Program {
        static void Main(string[] args) {
            Client client = new Client();

            Console.WriteLine("Client: Executing the client code with a real subject:");

            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy);
            Console.ReadKey();
        }
    }
    public class Client {
        public void ClientCode(ISubject subject) {

            subject.Request();
        }
    }
    public interface ISubject {
        void Request();
    }

    class RealSubject : ISubject {
        public void Request() {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    class Proxy : ISubject {
        private RealSubject _realSubject; // campo del objeto original.
        public Proxy(RealSubject realSubject) {
            this._realSubject = realSubject;
        }

        public void Request() {
            if (this.CheckAccess()) {
                this._realSubject.Request();

                this.LogAccess();
            }
        } // Tarea a realizar (Comun al objeto original, por lo tanto <I>)

        public bool CheckAccess() {

            Console.WriteLine("Proxy: Checking access prior to firing a real request.");
            return true;
        } // Acciones de control (Previas/posteriores) a la solicitud

        public void LogAccess() {
            Console.WriteLine("Proxy: Logging the time of request.");
        } // Acciones de control (Previas/posteriores) a la solicitud

    }
}