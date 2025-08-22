using System;
using Task2_StudentTeacher;
namespace Task2_StudentTeacher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an array to store 3 persons
            Person[] people = new Person[3];
            //Prompt user for names
            Console.Write("Enter the name of Student1:  ");
            string student1Name = Console.ReadLine();
            people[0] = new Student(student1Name ?? "Unknown");
            Console.Write("Enter the name of Student2: ");
            string student2Name = Console.ReadLine();
            people[1] = new Student(student2Name ?? "Unknown");
            Console.Write("Enter name of The Teacher:");
            string teacherName = Console.ReadLine();
            people[2] = new Teacher(teacherName ?? "Unknown");
            Console.WriteLine("\n-- Output --\n");
            //Call Study() for Students
            ((Student)people[0]).Study();
            ((Student)people[1]).Study();
            //Call Explain() for teacher
            ((Teacher)people[2]).Explain();
        }
    }
}