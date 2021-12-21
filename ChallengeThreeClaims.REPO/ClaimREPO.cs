using ChallengeThreeClaims.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeClaims.REPO
{
    public class ClaimREPO
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();
        private int claimId = 0;

        public Queue<Claim> ShowClaimQueue()
        {
            return _claimQueue;
        }
        public bool CreateClaim(Claim claim)
        {
            if (claim is null)
            {
                return false;
            }
            claimId++;
            claim.ClaimID = claimId;
            return true;
        }
        
        public bool ValidateClaim(DateTime dateOfIncident, DateTime dateOfClaim)
        {
            TimeSpan timeSinceIncident = new TimeSpan();
            timeSinceIncident = dateOfClaim - dateOfIncident;
            int interval = timeSinceIncident.Days;
            if (interval > 30)
            {
                return false;
            }
            return true;
        }
    }
}
