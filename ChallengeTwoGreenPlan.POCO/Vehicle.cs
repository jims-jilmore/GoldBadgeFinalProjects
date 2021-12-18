using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoGreenPlan.POCO
{
    public enum VehicleType
    {
        Gas,
        Hybrid,
        Electric
    }

     public class Vehicle
    {
        public VehicleType VehicleType { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public bool HasIncentive { get; set; }
        public int CityMPG { get; set; }
        public int HighwayMPG { get; set; }
        public int IdNumber { get; set; }
        public Vehicle() { }
        public Vehicle(VehicleType vehicleType, string year, string make, string model, decimal price, bool hasIncentive, int cityMPG, int highwayMPG, int idNumber)
        {
            VehicleType = vehicleType;
            Year = year;
            Make = make;
            Model = model;
            Price = price;
            HasIncentive = hasIncentive;
            CityMPG = cityMPG;
            HighwayMPG = highwayMPG;
            IdNumber = idNumber;
        }
        public Vehicle(VehicleType vehicleType, string year, string make, string model, bool hasIncentive, int cityMPG, int highwayMPG)
        {
            VehicleType = vehicleType;
            Year = year;
            Make = make;
            Model = model;
            HasIncentive = hasIncentive;
            CityMPG = cityMPG;
            HighwayMPG = highwayMPG;
        }
        public Vehicle(VehicleType vehicleType, string year, string make, string model, bool hasIncentive)
        {
            VehicleType = vehicleType;
            Year = year;
            Make = make;
            Model = model;
            HasIncentive = hasIncentive;
        }
        public Vehicle(string year, string make, string model)
        {
            Year = year;
            Make = make;
            Model = model;
        }

    }
}
