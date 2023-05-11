﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace RefactoringGuru.DesignPatterns.Flyweight.Conceptual {

    public class Flyweight {
        private Car _sharedState;

        public Flyweight(Car car) {
            this._sharedState = car;
        }

        public void Operation(Car uniqueState) { 
            string s = JsonSerializer.Serialize(this._sharedState);
            string u = JsonSerializer.Serialize(uniqueState);
            Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
        }
            // Algo asi a guardar la info de Car en un txt 
    }

    public class FlyweightFactory { // Fabrica de los pesoPluma (Estado intrinseco - no cambia)
                                    // Administra y gestiona
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params Car[] args) { //Constructor que cada que se invoca agrega
                                                     //a la lista de tuplas un auto con su clave
            foreach (var elem in args) {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), this.getKey(elem)));
            }
        }

     
        public string getKey(Car key) { // Retorna en un solo string, la lista de string compuesta de
                                        // los elementos que contiene un coche (Modelo,Color,Compania,..etc)
                                        
            List<string> elements = new List<string>();

            elements.Add(key.Model);
            elements.Add(key.Color);
            elements.Add(key.Company);

            if (key.Owner != null && key.Number != null) { // Corrobora que el coche tenga dueño y numero de patente
                elements.Add(key.Number);
                elements.Add(key.Owner);
            }

            elements.Sort();

            return string.Join(" - ", elements); // Esta funcion permite juntar todo en un string
        }


        public Flyweight GetFlyweight(Car sharedState) {
            string key = this.getKey(sharedState);

            if (flyweights.Where(t => t.Item2 == key).Count() == 0) { // No encontro el coche
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                this.flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
            } else {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }
            return this.flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1; 
            //Devuelve el primer elemento encontrado con el criterio de key
        }

        public void listFlyweights() { // Como que lista todos los pesoPluma que tiene
            var count = flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            foreach (var flyweight in flyweights) {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }

    public class Car {
        public string Owner { get; set; }
        public string Number { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    } // Solo tiene Gets y Sets

    class Program {
        static void Main(string[] args) {
           
            // Fabrica de pesoPluma con todos los coches cargados de una sola vez (su constructor lo permite)
            var factory = new FlyweightFactory(
                new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                new Car { Company = "BMW", Model = "M5", Color = "red" },
                new Car { Company = "BMW", Model = "X6", Color = "white" }
            );
            factory.listFlyweights();

            addCarToPoliceDatabase(factory, new Car {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = "red"
            });

            addCarToPoliceDatabase(factory, new Car {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "X1",
                Color = "red"
            });

            factory.listFlyweights();
            Console.ReadKey();
        }

        public static void addCarToPoliceDatabase(FlyweightFactory factory, Car car) {
            Console.WriteLine("\nClient: Adding a car to database.");

            var flyweight = factory.GetFlyweight(new Car {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            // The client code either stores or calculates extrinsic state and
            // passes it to the flyweight's methods.
            flyweight.Operation(car);
        }
    }
}