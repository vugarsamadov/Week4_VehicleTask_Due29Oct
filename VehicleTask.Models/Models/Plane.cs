using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTask.Models.Interfaces;
using VehicleTask.Models.Models;

namespace VehicleTask.Models
{
    public class Plane : MotorisedVehicle, IEngine
    {
        public float WingLength { get; init; }

        public Plane(string name,float wingLength, int horsePower, float tankSize, float currentOil, string fuelType, int driveTime, float drivePath)
        {
            WingLength = wingLength;
            HorsePower = horsePower;
            TankSize = tankSize;
            CurrentOil = currentOil;
            FuelType = fuelType;
            DriveTime = driveTime;
            DrivePath = drivePath;
            Name = name;
        }

    }
}
