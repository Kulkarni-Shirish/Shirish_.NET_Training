using System;
using System.Collections;
namespace PeopleArrayList
{
    //Person class 
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        //Constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        //Override ToString method to print details
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}