using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Program
{
    public class Ride_Repository
    {
        public static Dictionary<string, List<Ride>> mapRideForUser;

        public Ride_Repository()
        {
            mapRideForUser = new Dictionary<string, List<Ride>>();
        }

        public void AddRidesInRepo(string userId, List<Ride> ridesList)
        {
            if (mapRideForUser.ContainsKey(userId))
            {
                mapRideForUser[userId] = ridesList;
            }
            else
            {
                mapRideForUser.Add(userId, ridesList);
            }
        }
        public static List<Ride> GetRideListByUserID(string userId)
        {
            try
            {
                return mapRideForUser[userId];
            }
            catch (Exception ex)
            {
                throw new Exception("UserId does not exist");
            }
        }
    }
}
