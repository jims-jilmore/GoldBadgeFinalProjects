using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ChallengeTwoGreenPlan.REPO;
using ChallengeTwoGreenPlan.POCO;

namespace ChallengeTwoGreenPlan.TESTS
{
    [TestClass]
    public class GreenPlanTests
    {
        GreenPlanREPO _gRepo = new GreenPlanREPO();
        Vehicle _vehicle = new Vehicle();

        [TestMethod]
        public void CreateVehicle_ShouldReturnTrue()
        {
            Vehicle test = new Vehicle();

            Assert.IsTrue(_gRepo.CreateVehicle(test));
        }

        [TestMethod]
        public void ViewAllVehicles_ShouldNotReturnNull()
        {
            List<Vehicle> test = new List<Vehicle>();
            test = _gRepo.ViewAllVehicles();

            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void ViewVehicleByType_ShouldNotReturnNull()
        {

        }

        [TestMethod]
        public void ViewVehicleById_ShouldReturnNotNull()
        {
            _gRepo.CreateVehicle(_vehicle);
            Assert.IsNotNull(_gRepo.ViewVehicleById(_vehicle.IdNumber));
        }

        [TestMethod]
        public void RemoveVehicle_ShouldReturnTrue()
        {
            Assert.IsTrue(_gRepo.RemoveVehicle(_vehicle));
        }

        [TestMethod]
        public void UpdateVehicle_ShouldReturnTrue()
        {
            _gRepo.CreateVehicle(_vehicle);

            Vehicle vToUpdate = new Vehicle();
            _gRepo.CreateVehicle(vToUpdate);

            Assert.IsTrue(_gRepo.UpdateVehicle(vToUpdate.IdNumber, _vehicle));
            
        }
    }
}
