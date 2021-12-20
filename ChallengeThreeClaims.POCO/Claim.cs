﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeClaims.POCO
{
    public enum TypeOfClaim
    {
        Car,
        Home,
        Theft
    }
    public class Claim
    {
        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsClaimValid { get; set; }

        public Claim() { }
        public Claim(int claimID, TypeOfClaim claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isClaimValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsClaimValid = isClaimValid;
        }

        public Claim(TypeOfClaim claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isClaimValid)
        {
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsClaimValid = isClaimValid;
        }

        public Claim(TypeOfClaim claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public Claim(int claimID, TypeOfClaim claimType, string description, decimal claimAmount, bool isClaimValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            IsClaimValid = isClaimValid;
        }
    }
}
