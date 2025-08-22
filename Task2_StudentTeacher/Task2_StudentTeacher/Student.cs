using System;


namespace Task2_StudentTeacher
{
    //Student class inherits from person
    public class Student : Person
    {
        //Constructor that calls base constructor(Person)
        public Student(string name) : base(name) { }
        //Method to show that student is studying
        public void Study()
        {
            Console.WriteLine($"{Name} is Studying ");
        }
    }
}
