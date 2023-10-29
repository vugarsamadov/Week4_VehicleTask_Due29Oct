using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTask.Models.Interfaces;

namespace VehicleTask.Models
{
    public class Bicycle : Vehicle, IWheel
    {
        public float WheelThickness { get; init; }

        public Bicycle(string name,float wheelThickness, int driveTime, float drivePath)
        {
            WheelThickness = wheelThickness;
            DriveTime = driveTime;
            DrivePath = drivePath;
            Name = name;
        }


    }
}
