using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTask.Models
{
    public abstract class Vehicle
    {
        public int DriveTime { get; init; }
        public float DrivePath { get; init; }
        public string Name { get; init; }

        protected float AverageSpeed()
        {
            return DrivePath / DrivePath;
        }

        protected string GetVehicleType()
        {
            string type = "N/A";

            if (this is Car)
                type = "Car";
            else if (this is Plane)
                type = "Plane";
            else if (this is Bicycle)
                type = "Bicycle";

            return type;
        }
        public override string ToString()
        {
            return $@" Vehicle Type: {GetVehicleType()} Vehicle Name: {Name} Average Speed: {AverageSpeed()}";
        }

    }
}
