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
        private readonly List<Claim> _claims = new List<Claim>();
        private Queue<Claim> _claimQueue = new Queue<Claim>();
        private int claimId = 0;

        public List<Claim>ViewAllClaims()
        {
            return _claims;
        }
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
            _claims.Add(claim);
            _claimQueue.Enqueue(claim);
            return true;
        }
        public Claim RemoveClaim(int claimIdToRemove)
        {
            foreach (Claim claim in _claims)
            {
                if (claim.ClaimID == claimIdToRemove)
                {
                    _claims.Remove(claim);
                    return claim;
                }
            }
            return null;
        }
        public bool UpdateClaim(int claimIdToUpdate, Claim oldClaim)
        {
            Claim claimToUpdate = ViewSingleClaim(claimIdToUpdate);
            if (oldClaim != null)
            {
                claimToUpdate.ClaimID = oldClaim.ClaimID;
                claimToUpdate.ClaimType = oldClaim.ClaimType;
                claimToUpdate.Description = oldClaim.Description;
                claimToUpdate.ClaimAmount = oldClaim.ClaimAmount;
                claimToUpdate.DateOfIncident = oldClaim.DateOfIncident;
                claimToUpdate.DateOfClaim = oldClaim.DateOfClaim;
                claimToUpdate.IsClaimValid = oldClaim.IsClaimValid;
                return true;
            }
            else
            {
                return false;
            }
        }
        public Claim ViewSingleClaim(int claimId)
        {
            foreach (var claim in _claims)
            {
                if (claim.ClaimID == claimId)
                {
                    return claim;
                }
            }
            return null;
        }
        public bool ValidateClaim(DateTime dateOfIncident, DateTime dateOfClaim)
        {
            TimeSpan durationSinceIncident = dateOfClaim - dateOfIncident;
            if (durationSinceIncident.Days > 0 && durationSinceIncident.Days <= 30)
            {
                return true;
            }
            return false;
        }
    }
}
