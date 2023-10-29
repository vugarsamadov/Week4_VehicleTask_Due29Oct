using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleTask.Models.Interfaces;

namespace VehicleTask.Models.Models
{
    public abstract class MotorisedVehicle : Vehicle, IEngine
    {
        public int HorsePower { get; init; }
        public float TankSize { get; init; }
        public float CurrentOil { get; set; }
        public string FuelType { get; init; }

        public float RemainingOilAmount()
        {
            return TankSize - CurrentOil < 0 ? 0 : TankSize - CurrentOil;
        }
        public override string ToString()
        {
            return $@"{base.ToString()} HorsePower: {HorsePower} Remaining Oil: {RemainingOilAmount()} Fuel Type: {FuelType}";
        }
    }
}
