using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeTwoGreenPlan.POCO;

namespace ChallengeTwoGreenPlan.REPO
{
    public class GreenPlanREPO
    {
        private readonly List<Vehicle> _vehicle = new List<Vehicle>();
        private int generateVehicleId = 0; 

        public bool CreateVehicle(Vehicle vehicleToCreate)
        {
            if (vehicleToCreate is null)
            {
                return false;
            }
            generateVehicleId++;
            vehicleToCreate.IdNumber = generateVehicleId;
            _vehicle.Add(vehicleToCreate);
            return true;
        }
        public List<Vehicle> ViewAllVehicles()
        {
            return _vehicle;
        }
        public List<Vehicle> ViewGasVehicles()
        {
            foreach (var vehicle in _vehicle)
            {
                if (vehicle.VehicleType == VehicleType.Gas)
                {
                    List<Vehicle> gasVehicles = new List<Vehicle>();
                    return gasVehicles;
                }
            }
            return null;
        }
        public List<Vehicle> ViewElectricVehicles()
        {
            foreach (var vehicle in _vehicle)
            {
                if (vehicle.VehicleType == VehicleType.Electric)
                {
                    List<Vehicle> electricVehicles = new List<Vehicle>();
                    return electricVehicles;
                }
            }
            return null;
        }
        public List<Vehicle> ViewHybridVehicles()
        {
            foreach (var vehicle in _vehicle)
            {
                if (vehicle.VehicleType == VehicleType.Hybrid)
                {
                    List<Vehicle> hybridVehicles = new List<Vehicle>();
                    return hybridVehicles;
                }
            }
            return null;
        }
        //Method For Vehicle Comparison?
        public Vehicle ViewVehicleById(int vehicleId)
        {
           foreach (var vehicle in _vehicle)
            {
                if (vehicleId == vehicle.IdNumber)
                {
                    return vehicle;
                }
            }
            return null;
        }
        public Vehicle RemoveVehicleById(int vehicleId)
        {
            foreach (var vehicle in _vehicle)
            {
                if (vehicle.IdNumber == vehicleId)
                {
                    _vehicle.Remove(vehicle);
                    return vehicle;
                }
            }
            return null;
        }
        public bool RemoveVehicle(Vehicle vehicle)
        {
            if (vehicle is null)
            {
                return false;
            }
            _vehicle.Remove(vehicle);
            return true;
        }
        //Method For Updating Vehicle Info
        public int GetListLength()
        {
            int listLength = _vehicle.Count();
            return listLength;  
        }
    }
}
