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

        public bool CreateVehicle(Vehicle vehicle)
        {
            if (vehicle is null)
            {
                return false;
            }
            generateVehicleId++;
            _vehicle.Add(vehicle);
            return true;
        }
        public bool WasVehicleRemoved(Vehicle vehicleThatWasRemoved, int idOfVehicleToRemove)
        {
            vehicleThatWasRemoved = RemoveVehicle(idOfVehicleToRemove);

            if (vehicleThatWasRemoved is null)
            {
                return true;
            }
            return false;
        }
        public List<Vehicle> ViewAllVehicles()
        {
            return _vehicle;
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
        public Vehicle RemoveVehicle(int vehicleId)
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
        public void RemoveVehicleById(Vehicle vehicleToPull, int vehicleIdToPull)
        {
            foreach (Vehicle vehicle in _vehicle)
            {
                if (vehicle.IdNumber == vehicleIdToPull)
                {
                    RemoveVehicle(vehicle.IdNumber);
                    break;
                }
            }
        }
        public int GetListLength()
        {
            int listLength = _vehicle.Count();
            return listLength;  
        }
    }
}
