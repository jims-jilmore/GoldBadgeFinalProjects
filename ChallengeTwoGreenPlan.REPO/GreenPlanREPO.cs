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
                if (vehicle.VehicleType == "Gas")
                {
                    _vehicle.Add(vehicle);
                    return _vehicle; ;
                }
            }
            return null;
        }
        public List<Vehicle> ViewElectricVehicles()
        {
            foreach (var vehicle in _vehicle)
            {
                if (vehicle.VehicleType == "Electric")
                {
                    _vehicle.Add(vehicle);
                    return _vehicle;
                }
            }
            return null;
        }
        public List<Vehicle> ViewHybridVehicles()
        {
            foreach (var vehicle in _vehicle)
            {
                if (vehicle.VehicleType == "Hybrid")
                {
                    
                    _vehicle.Add(vehicle);
                    return _vehicle;
                }
            }
            return null;
        }
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
        public int GetListLength()
        {
            int listLength = _vehicle.Count();
            return listLength;  
        }
        public bool UpdateVehicle(int idToUpdate, Vehicle oldVehicle)
        {
            Vehicle vehicleToUpdate = ViewVehicleById(idToUpdate);
            if (oldVehicle != null)
            {
                oldVehicle.IdNumber = vehicleToUpdate.IdNumber;
                oldVehicle.Year = vehicleToUpdate.Year;
                oldVehicle.Make = vehicleToUpdate.Make;
                oldVehicle.Model = vehicleToUpdate.Model;
                oldVehicle.Price = vehicleToUpdate.Price;
                oldVehicle.HasIncentive = vehicleToUpdate.HasIncentive;
                oldVehicle.CityMPG = vehicleToUpdate.CityMPG;
                oldVehicle.HighwayMPG = vehicleToUpdate.HighwayMPG;

                return true;
            }
            else
            {
            return false;
            }
        }
    }
}
