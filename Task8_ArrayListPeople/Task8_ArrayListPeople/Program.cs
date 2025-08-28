using System;
using System.Collections;
namespace PeopleArrayList
{ 
    class Program
    {
        static void Main(String[] args)
        {
            //Create an ArrayList
            ArrayList people = new ArrayList();
            //Request info for 3 people
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Enter name of person {i}:");
                string name = Console.ReadLine();
                Console.WriteLine($"Enter age of Person{i}:");
                int age = int.Parse(Console.ReadLine());
                //Add new Person object to ArrayList
                people.Add(new Person(name, age));
            }
            Console.WriteLine("\n-- People in the list---");
            //Print all people using foreach loop
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("\nProgram Ended.");
        }
    }
}