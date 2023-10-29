using System;
using System.Numerics;
using VehicleTask.Models;
using Plane = VehicleTask.Models.Plane;

namespace VehicleTaskDemo
{
    internal class VehicleTaskUI
    {
        private VehicleCollection _vehicleCollection;
        private string _status;

        public VehicleTaskUI()
        {
            _vehicleCollection = new VehicleCollection();
            var car = new Car("Porche",4,"AA33",3500,4.5f,1.2f,4500,60.5f,30.5f,"Diesel","AWD");
            var plane = new Plane("Boeing 777",34.4f,4500,45.4f,43.4f,"Kerosine",344,45.4f);
            var bicycle = new Bicycle("BMX",3.4f,5,5.7f);

            _vehicleCollection.AddVehicle(car);
            _vehicleCollection.AddVehicle(plane);
            _vehicleCollection.AddVehicle(bicycle);
        }

        public void Start()
        {
            
            int command;
            do
            {
                command = DisplayAndGetCommand();

                switch (command) 
                {
                    case 1:
                        var car = GetCarFromUser();
                        _vehicleCollection.AddVehicle(car);
                        break;
                    case 2:
                        var bicycle = GetBicycleFromUser();
                        _vehicleCollection.AddVehicle(bicycle);
                        break;
                    case 3:
                        var plane = GetPlaneFromUser();
                        _vehicleCollection.AddVehicle(plane);
                        break;
                    case 4:
                        PrintVehicles(_vehicleCollection.GetAllVehicles());
                        break;
                    case 5:
                        PrintVehicles(_vehicleCollection.GetAllVehicles());
                        var indx = PromptUserAndGetInt("Enter vehicle index to remove: ");
                        var result = _vehicleCollection.RemoveVehicleFromDatabase(indx);
                        _status = (result.IsValid ? "Vehicle removed successfully!" : "Vehicle can not be removed!");
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

            } while (command != 6);
        }



        public int DisplayAndGetCommand()
        {
            PrintVehicles(_vehicleCollection.GetAllVehicles());
            PrintStatus();
            Console.WriteLine(@"
1 - Create And Add new Car
2 - Create And Add new Bicycle
3 - Create And Add new Plane
4 - Print All Vehicles
5 - Remove Vehicle
6 - Quit

");
            _status = string.Empty;
            return PromptUserAndGetInt(string.Empty);
        }

        public void PrintVehicles(Vehicle[] Vehicles)
        {
            Console.Clear();
            Console.WriteLine("--------Vehicles----");
            for (int i = 0; i < Vehicles.Length; i++)
            {
                Console.WriteLine($"> {i} => {Vehicles[i]}");
            }
            Console.WriteLine("--------------------");
        }

        public Plane GetPlaneFromUser()
        {
            Console.Clear();
            var name = PromptUserAndGetString("Enter name: ");
            var wingLenght = PromptUserAndGetFloat("Enter wing length: ");
            var horsePower = PromptUserAndGetInt("Enter horsepower: ");
            GetTankSizeAndCurrentOil(out float tankSize, out float currentOilLevel);
            var fuelType = PromptUserAndGetString("Enter fuel type: ");
            var driveTime = PromptUserAndGetInt("Enter drive duration: ");
            var drivePath = PromptUserAndGetFloat("Enter traversed km: ");

            return new Plane(name,wingLenght,horsePower,tankSize,currentOilLevel,fuelType,driveTime,drivePath);
        }

        public Car GetCarFromUser()
        {
            Console.Clear();
            var name = PromptUserAndGetString("Enter name: ");
            var doorCount = PromptUserAndGetInt("Enter window count: ");
            var winCode = PromptUserAndGetString("Enter wincode: ");
            var driveTime = PromptUserAndGetInt("Enter drive duration (seconds) : ");
            var drivePath = PromptUserAndGetFloat("Enter traversed km: ");
            var wheelThickness = PromptUserAndGetFloat("Enter wheel thickness: ");
            var horsePower = PromptUserAndGetInt("Enter horsepower: ");
            GetTankSizeAndCurrentOil(out float tankSize, out float currentOilLevel);
            var fuelType = PromptUserAndGetString("Enter fuel type: ");
            var transmissionType = PromptUserAndGetString("Enter transmission type: ");

            return new Car(name,doorCount,winCode,driveTime,drivePath,wheelThickness,horsePower,tankSize,currentOilLevel,fuelType,transmissionType);
        }


        public Bicycle GetBicycleFromUser()
        {
            Console.Clear();
            var name = PromptUserAndGetString("Enter name: ");
            var wheelThickness = PromptUserAndGetFloat("Enter wheel thickness: ");
            var driveTime = PromptUserAndGetInt("Enter drive duration: ");
            var drivePath = PromptUserAndGetFloat("Enter traversed km: ");
            
            return new Bicycle(name,wheelThickness,driveTime,drivePath);
        }


        public void GetTankSizeAndCurrentOil(out float tankSize, out float currentOil)
        {
            float _tankSize = PromptUserAndGetFloat("Enter oil tank size: ");
            float _currentOilLevel;
            do
            {
                _currentOilLevel = PromptUserAndGetFloat("Enter current oil level: ");
                if(_tankSize < _currentOilLevel)
                    Console.WriteLine("Current oil level can not be bigger than tank size");
            } while (_tankSize < _currentOilLevel);
            tankSize = _tankSize;
            currentOil = _currentOilLevel;
        }

        void PrintStatus()
        {
            if (!string.IsNullOrEmpty(_status))
            {
                Console.WriteLine($">>> {_status} ");
            }
        }

        // Helper functions
        #region Helper
        public string PromptUserAndGetString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
                if (String.IsNullOrEmpty(result))
                    Console.WriteLine("No empty strings are allowed!");
            } while (String.IsNullOrEmpty(result));
            return result;
        }

        public float PromptUserAndGetFloat(string prompt)
        {
            float result;
            do
            {
                result = Convert.ToSingle(PromptUserAndGetString(prompt));
                if (result < 0)
                    Console.WriteLine("No negative value allowed for this prop!");
            } while (result < 0);

            return result;
        }

        public int PromptUserAndGetInt(string prompt)
        {
            int result;
            do
            {
                result = Convert.ToInt32(PromptUserAndGetString(prompt));
                if (result < 0)
                    Console.WriteLine("No negative value allowed for this prop!");
            } while (result < 0);

            return result;
        }
        #endregion
    }
}
