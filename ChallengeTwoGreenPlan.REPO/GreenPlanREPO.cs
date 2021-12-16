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
        private int generateVehicleId = 0; // <<<-Curious about generating different types of unique id's (especially how to use and manipulate hast tables)

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
        public List<Vehicle> ViewAllVehicles()
        {
            return _vehicle;
        }
        public Vehicle ViewSingleVehicle(int vehicleId)
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
        //Compare Vehicle(s)?

        public List<Vehicle> UpdateVehicleInfo(Vehicle vehicle)
        {
            // alter old info | return new info

            
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            _vehicle.Remove(vehicle);
        }



    }
}
