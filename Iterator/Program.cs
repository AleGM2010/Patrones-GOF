using System;
using System.Collections.Generic;

namespace Iterator
{
    // Define la clase de nodo
    public class Nodo
    {
        public int Value { get; set; }
        public Nodo Left { get; set; }
        public Nodo Right { get; set; }

        public Nodo(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    // Define la clase de árbol y un metodo para agregar a iz o derecha
    public class Tree
    {
        public Nodo Root { get; set; }

        public void Add(int value)
        {
            Nodo newNode = new Nodo(value);

            if (Root == null)
            {
                Root = newNode;
                return;
            }

            Nodo current = Root;
            Nodo parent;

            while (true)
            {
                parent = current;

                if (value < current.Value)
                {
                    current = current.Left;

                    if (current == null)
                    {
                        parent.Left = newNode;
                        return;
                    }
                }
                else
                {
                    current = current.Right;

                    if (current == null)
                    {
                        parent.Right = newNode;
                        return;
                    }
                }
            }
        }
    }

    public interface IIterator
    {
        bool HasNext();
        Nodo Next();
    }

    public class ConcreteIterator : IIterator
    {
        private Stack<Nodo> stack;

        public ConcreteIterator(Nodo root)
        {
            stack = new Stack<Nodo>();
            while (root != null)
            {
                stack.Push(root);
                root = root.Left;
            }
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }

        public Nodo Next()
        {
            Nodo node = stack.Pop();
            Nodo temp = node.Right;
            while (temp != null)
            {
                stack.Push(temp);
                temp = temp.Left;
            }
            return node;
        }
    }

    public interface IIterable
    {
        IIterator CreateIterator();
    }

    public class TreeIterator : IIterable
    {
        private Nodo root;

        public TreeIterator(Nodo root)
        {
            this.root = root;
        }

        public IIterator CreateIterator()
        {
            return new ConcreteIterator(root);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Creamos un árbol binario y agregamos algunos nodos
            Tree tree = new Tree();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(9);

            // Creamos un iterador para recorrer el árbol
            TreeIterator treeIterator = new TreeIterator(tree.Root);
            IIterator iterator = treeIterator.CreateIterator();

            // Iteramos sobre los nodos del árbol y los imprimimos en la consola
            Console.WriteLine("Nodos del árbol:");
            while (iterator.HasNext())
            {
                Nodo node = iterator.Next();
                Console.WriteLine(node.Value);
            }
            Console.ReadKey();
        }
    }
}