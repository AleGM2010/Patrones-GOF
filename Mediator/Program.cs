using System;
using System.Collections.Generic;

namespace Mediator
{
    // Interfaz del Mediator , para que pueda Enviar mensajes. 
    public interface IMediator
    {
        void Send(string message, IColleague colleague);
        void Send(string name, int life, int str);
    }

    // Interfaz de los Colleague (personajes, enemigos, objetos)
    // Permite que quien la implementa pueda recibir Mensajes. 
    public interface IColleague
    {
        void SetMediator(IMediator mediator);
        void Receive(string message);
    }

    // ConcreteMediator
    public class GameMediator : IMediator
    {
        private Dictionary<string, IColleague> colleagues = new Dictionary<string, IColleague>();

        public void RegisterColleague(string name, IColleague colleague)
        {
            colleagues.Add(name, colleague);
            colleague.SetMediator(this);
        }

        public void Send(string message, IColleague colleague)
        {

            // Comunica a cada "colleague" que otro realizo una accion. 
            foreach (var c in colleagues)
            {
                if (c.Value != colleague)
                {
                    c.Value.Receive(message);
                }
            }
        }

        public void Send(string name, int life, int str)
        {
            CheckLife(name, life,str);
        }
        // Este metodo tendria que tener sentido solo aqui dentro, disponiendo
        // solo de los tipos de mensajes que pasen a travez del mismo, Ya que 
        // no puede ser llamado dentro de las clases que contiene, porque NO son de 
        // tipo GameMediator, sino IMediator , que no contiene CheckLife. 
        public void CheckLife(string name, int life,int str)
        {

            if (life-str <= 0)
            {

                colleagues.Remove(name);
                Console.WriteLine($"[{name}] ha muerto");
            }
        }
    }

    // ConcreteColleague (Personaje)
    public class Character : IColleague
    {
        private IMediator mediator;
        private string name;
        private int life;
        private int str = 15;



        public string Name { get => name; }
        public int Life { get => life; }

        public Character(string name)
        {
            this.name = name;
            this.life = 100;
        }

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Receive(string message)
        {
            Console.WriteLine($"[{name}] ha recibido un mensaje: {message}");
        }

        public void Attack(string target, int lifeTarget)
        {
            Console.WriteLine($"[{name}] ataca a [{target}]");
            mediator.Send($"[{name}] ha atacado a [{target}]", this);
            mediator.Send(target, lifeTarget, str);
        }

        public void Heal()
        {
            life += 20;
            Console.WriteLine($"[{name}] se ha curado");
            mediator.Send($"[{name}] se ha curado! Hp:{life}", this);
        }
    }

    // ConcreteColleague (Enemigo)
    public class Enemy : IColleague
    {
        private IMediator mediator;
        private string name;
        private int life;
        private int str = 10;
        public string Name { get => name; }
        public int Life { get => life; }
        public Enemy(string name)
        {
            this.name = name;
            this.life = 60;
        }

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Receive(string message)
        {
            Console.WriteLine($"[{name}] ha recibido un mensaje: {message}");
        }

        public void Attack(string target, int lifeTarget)
        {
            Console.WriteLine($"[{name}] ataca a [{target}]");

            mediator.Send($"[{name}] ha atacado a [{target}]", this);
            mediator.Send(target, lifeTarget, str);
        }
    }

    // ConcreteColleague (Objeto)
    public class Item : IColleague
    {
        private IMediator mediator;
        private string name;
        public string Name { get => name; }
        public Item(string name)
        {
            this.name = name;
        }

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Receive(string message)
        {
            Console.WriteLine($"[{name}] ha recibido un mensaje: {message}");
        }

        public void Use()
        {
            Console.WriteLine($"[{name}] ha sido utilizado");
            mediator.Send($"[{name}] ha sido utilizado", this);
        }
    }

    // Ejemplo de uso
    public class Program
    {
        static void Main(string[] args)
        {
            // Creamos el Mediador
            var mediator = new GameMediator();

            // Creamos instancias de las clases que se quiere que trabajen juntas
            var player1 = new Character("Player 1");
            var player2 = new Character("Player 2");
            var enemy = new Enemy("Enemy 1");
            var item = new Item("Item 1");

            // Las acoplamos al Mediador
            mediator.RegisterColleague(player1.Name, player1);
            mediator.RegisterColleague(player2.Name, player2);
            mediator.RegisterColleague(enemy.Name, enemy);
            mediator.RegisterColleague(item.Name, item);

            // A Comenzar con el juego!

            // El jugador 1 ataca al enemigo
            player1.Attack(enemy.GetType().ToString(),enemy.Life);

            // El jugador 2 ataca al enemigo
            player2.Attack(enemy.GetType().ToString(),enemy.Life);

            // El enemigo ataca al jugador 2
            enemy.Attack(player2.GetType().ToString(),player2.Life);

            // El jugador 1 se cura
            player1.Heal();


            Console.ReadKey();
        }
    }
}