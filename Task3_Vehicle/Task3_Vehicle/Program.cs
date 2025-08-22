using System;

namespace Task3_Vehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a car with 0 gasoline
            Car myCar = new Car(0);

            // Ask user for amount of gasoline
            Console.Write("Enter amount of gasoline to refuel: ");
            int fuel = Convert.ToInt32(Console.ReadLine());

            // Refuel the car
            myCar.Refuel(fuel);

            // Try to drive
            myCar.Drive();

            Console.WriteLine("Program finished.");
        }
    }
}