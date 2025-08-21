using System;
class Person
{
    public string Name { get; set; }
    //Constructor
    public Person(string name)
    {
        Name = name;
    }
    //Destructor
    ~Person()
    {
        Name = string.Empty;
    }
    //Override ToString()
    public override string ToString()
    {
        return $"Person Name:{Name}";
    }

}
class Program
{
    static void Main(string[] args)
    {
        Person[] people = new Person[3];
        for(int i=0;i<3;i++)
        {
            Console.Write($"Enter name of person {i+1}:");
            string name = Console.ReadLine();
            people[i] = new Person(name);
        }
        Console.WriteLine("\nYou entered");
        foreach(var p in people)
        {
            Console.WriteLine(p.ToString());
        }
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}