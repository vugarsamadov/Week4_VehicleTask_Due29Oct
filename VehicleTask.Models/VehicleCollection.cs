using System;

namespace VehicleTask.Models;

public class VehicleCollection
{
        public Vehicle[] Vehicles = new Vehicle[0];

        public VehicleCollection(Vehicle[] vehicles)
        {
            Vehicles = vehicles;
        }

    public VehicleCollection()
    {
        
    }
    public void AddVehicle(Vehicle vehicle)
        {
            Array.Resize(ref Vehicles, Vehicles.Length + 1);
            Vehicles[Vehicles.Length - 1] = vehicle;
        }

        public Vehicle[] GetAllVehicles()
        {
            return Vehicles;
        }

        public Result GetVehicle(int index)
        {
            if (index >= Vehicles.Length || index < 0)
            {
                Console.WriteLine("Invalid Vehicle Index");
                return new Result { IsValid = false };
            }
            return new Result { Vehicle = Vehicles[index], IsValid = true };
        }
    public Result RemoveVehicleFromDatabase(int itemIndx)
    {
        if (itemIndx >= Vehicles.Length || itemIndx < 0)
        {
            Console.WriteLine("Invalid Vehicle Index");
            return new Result { IsValid = false };
        }
        
        var UpdatedDataBase = new Vehicle[Vehicles.Length - 1];
        var removedVehicle = Vehicles[itemIndx];

        for (int i = 0; i < Vehicles.Length; i++)
        {
            if (i == itemIndx)
            {
                continue;
            }
            else if (i > itemIndx)
            {
                UpdatedDataBase[i - 1] = Vehicles[i];
            }
            else
            {
                UpdatedDataBase[i] = Vehicles[i];
            }
        }
        Vehicles = UpdatedDataBase;
        return new Result{IsValid = true,Vehicle = removedVehicle};
    }

}
