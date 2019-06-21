using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Repository
{
    public class Repository
    {
        private Queue<Claims> _claims = new Queue<Claims>();
        public Queue<Claims> GetList()
        {
            return _claims; // RETURNS THE QUEUE LIST
        }

        public void AddClaim(Claims newClaim)
        {
            _claims.Enqueue(newClaim); // ADDS A NEW CLAIM
        }

        public void RemoveClaim()
        {
            _claims.Dequeue(); // REMOVE THE TOP CLAIM
        }

        public void IsValid(Claims claim) // IS WITHIN 30 DAYS OF
        {
            if (claim.DateOfClaim < claim.DateOfIncident)
                claim.DateOfClaim = claim.DateOfIncident;

            TimeSpan difference = claim.DateOfClaim - claim.DateOfIncident;

            if (difference.Days <= 30)
            {
                claim.IsValid = true;
            }
            else
                claim.IsValid = false;
        }
    }
}

//List all claims
//Take care of next claim (When confirmed, claim is taken and deleted)
//Enter new claim

//Komodo allows an insurance claim to be made up to 30 days after an incident took place.If the claim is not in the proper time limit, it is not valid.  

//The app will need methods in to do the following:
//Show a claims agent a menu:

//Choose a menu item:
//1. See all claims
//2. Take care of next claim
//3. Enter a new claim