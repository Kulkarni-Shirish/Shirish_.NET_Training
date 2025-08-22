using System;


namespace Task2_StudentTeacher
{
    //Base Person class
    public class Person
    {
        public string Name { get; set; }
        
        //Constructor that sets the Name
        public Person(string name)
        {
            Name = name;
        }
        //Override ToString to return the person's name
        public override string ToString()
        {
            return Name;
        }
    }
}
