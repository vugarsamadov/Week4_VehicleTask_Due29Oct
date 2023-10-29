using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTask.Models.Interfaces
{
    public interface IEngine
    {
        public int HorsePower { get; init; }
        public float TankSize { get; init; }
        public float CurrentOil { get; set; }
        public string FuelType { get; init; }

        public float RemainingOilAmount();

    }
}
