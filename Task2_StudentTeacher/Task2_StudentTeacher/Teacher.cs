using System;


namespace Task2_StudentTeacher
{
    //Teacher class inherits from Person
    public class Teacher : Person
    {
        //Constructor that calls base constructor (Person)
        public Teacher(string name) : base(name) { }
        //Method to show that teacher is explaining
        public void Explain()
        {
            Console.WriteLine($"{Name} is explaining");
        }
    }
}
