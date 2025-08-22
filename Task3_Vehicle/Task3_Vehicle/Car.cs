using System;

namespace Task3_Vehicle
{
    // Represents a Car that implements IVehiculo
    public class Car : IVehiculo
    {
        private int gasoline;  // Stores current gasoline amount

        // Constructor to set initial gasoline
        public Car(int initialGasoline)
        {
            gasoline = initialGasoline;
        }

        // Drives the car if gasoline is available
        public void Drive()
        {
            if (gasoline > 0)
                Console.WriteLine("The car is Driving...");
            else
                Console.WriteLine("Not enough gasoline to drive!");
        }

        // Refuels the car with given amount
        public bool Refuel(int amount)
        {
            if(amount < 0)
            {
                Console.WriteLine("Invalid Fuel Amount.Must be greater than zero");
                return false;   
            }
            gasoline += amount;
            Console.WriteLine($"Car refueled with {amount} liters.");
            return true;
        }
    }
}
