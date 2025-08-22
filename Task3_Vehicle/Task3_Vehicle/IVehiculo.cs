using System;


namespace Task3_Vehicle
{
    // Defines vehicle behavior with Drive and Refuel methods
    public interface IVehiculo
    {
        void Drive();              // Makes the vehicle drive
        bool Refuel(int amount);   // Refuels the vehicle with given amount
    }
}
