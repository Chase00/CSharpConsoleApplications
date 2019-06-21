using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Repository
{
    public class Repository
    {
        private Dictionary<int, List<string>> _doorAccess = new Dictionary<int, List<string>>(); // New up dictonary

        public Dictionary<int, List<string>> GetDictonary() //Get List
        {
            return _doorAccess;
        }

        public void AddBadge(Badges badge) //Create a dictionary of badges
        {
            _doorAccess.Add(badge.BadgeID, badge.DoorAccess);
        }

        public void GiveAccess (int badgeid, string doorAccess) // Adds a door to a badge
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Add(doorAccess);
        }

        public void RemoveAccess(int badgeid, string doorAccess) // Remove a door from a badge
        {
            List<string> doors = _doorAccess[badgeid];
            doors.Remove(doorAccess);
        }
    }
}

//1. Create a dictionary of badges. 
//2. The key for the dictionary will be the BadgeID.
//3. The value for the dictionary will be the List of Door Names.