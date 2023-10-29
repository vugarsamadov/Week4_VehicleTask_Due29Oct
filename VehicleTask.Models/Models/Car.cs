using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTask.Models.Interfaces;
using VehicleTask.Models.Models;

namespace VehicleTask.Models
{
    public class Car : MotorisedVehicle, IWheel, ITransmission
    {
        public int DoorCount { get; init; }
        public string WinCode { get; init; }

        public float WheelThickness { get; init; }
        public string TransmissionType { get; init; }

        public Car(string name,int doorCount, string winCode, int driveTime, float drivePath, float wheelThickness, int horsePower, float tankSize, float currentOil, string fuelType, string transmissionType)
        {
            DoorCount = doorCount;
            WinCode = winCode;
            DriveTime = driveTime;
            DrivePath = drivePath;
            WheelThickness = wheelThickness;
            HorsePower = horsePower;
            TankSize = tankSize;
            CurrentOil = currentOil;
            FuelType = fuelType;
            TransmissionType = transmissionType;
            Name = name;
        }

        

    }
}
