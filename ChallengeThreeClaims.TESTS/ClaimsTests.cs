using ChallengeThreeClaims.POCO;
using ChallengeThreeClaims.REPO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeClaims.TESTS
{
    [TestClass]
    public class ClaimsTests
    {
        ClaimREPO _claimRepo = new ClaimREPO();

        [TestMethod]
        public void ShowClaimQueue_ShouldNotReturnNull()
        {
            Queue<Claim> test = _claimRepo.ShowClaimQueue();
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void CreateClaim_ShouldReturnTrue()
        {
            Claim newClaimToTest = new Claim();
            Assert.IsTrue(_claimRepo.CreateClaim(newClaimToTest));
        }

        [TestMethod]
        public void RemoveClaim_ShouldReturnTrue()
        {
            Claim test = new Claim();
            Queue<Claim> testQ = new Queue<Claim>();

            _claimRepo.CreateClaim(test);
            testQ.Enqueue(test);
                    
            Assert.IsTrue(_claimRepo.RemoveClaim());
        }

        [TestMethod]
        public void ValidateClaim_ShouldReturnTrue()
        {
            DateTime incident = new DateTime();
            DateTime claimDate = new DateTime();

            var dateOne = DateTime.Parse("11/1/21");
            incident = dateOne;

            var dateTwo = DateTime.Parse("11/5/21");
            claimDate = dateTwo;

            Assert.IsTrue(_claimRepo.ValidateClaim(incident, claimDate));
        }

        [TestMethod]
        public void ValidateClaim_ShouldReturnFalse()
        {
            DateTime incident = new DateTime();
            DateTime claimDate = new DateTime();

            var dateOne = DateTime.Parse("11/1/21");
            incident = dateOne;

            var dateTwo = DateTime.Parse("12/5/21");
            claimDate = dateTwo;

            Assert.IsFalse(_claimRepo.ValidateClaim(incident, claimDate));
        }
    }
}
