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
        Queue<Claim> _testQueue = new Queue<Claim>();

        [TestMethod]
        public void ShowClaimQueue_ShouldReturnQueue()
        {
            //Expected is a queue
            //Actual is _claimRepo.ShowClaimQueue();
        }
    }
}
