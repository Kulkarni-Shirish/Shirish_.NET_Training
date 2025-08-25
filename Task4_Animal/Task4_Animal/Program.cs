using System;

namespace Task4_Animal
{
    // Abstract class
    abstract class Animal
    {
        public string Name { get; set; }

        public void SetName(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        // Abstract method
        public abstract void Eat();
    }

    // Dog class that implements Animal
    class Dog : Animal
    {
        public override void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the dog's name: ");
            string dogName = Console.ReadLine();

            Dog myDog = new Dog();
            myDog.SetName(dogName);

            Console.WriteLine("Dog's name is: " + myDog.GetName());
            myDog.Eat();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}