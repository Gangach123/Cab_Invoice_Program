using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Program
{
    public class CabInvoiceGenerator
    {
        const int COST_PER_KM = 10;
        const int COST_PER_MINUTE = 1;
        const int MINIMUM_FARE = 5;
        public double CalcuteFair(TypeOfRide ride, double distance, double time)
        {
            double Fare = distance * COST_PER_KM + time * COST_PER_MINUTE;
            if (Fare > MINIMUM_FARE)
            {
                return Fare;
            }
            return MINIMUM_FARE;
        }
        public double MultipleRide(TypeOfRide typeRides,List<Ride> rides)
        {
            double multipleRideFare = 0;
            foreach (Ride ride in rides)
            {
                multipleRideFare += CalcuteFair(typeRides, ride.distance, ride.time);
            }
            return multipleRideFare;
        }
        public Enhanced_Invoice GetInvoiceDetailsOfRides(TypeOfRide typeRides,List<Ride> rides)
        {
            Enhanced_Invoice invoiceDetails = new Enhanced_Invoice();
            invoiceDetails.Getting_Details_Of_Invoice_In_Object(typeRides, rides);
            return invoiceDetails;
        }

        public Enhanced_Invoice Get_Invoice_By_UserId(TypeOfRide typeRides, string userId)
        {
            var userRideList = Ride_Repository.GetRideListByUserID(userId);
            var invoiceDetailsByUserId = GetInvoiceDetailsOfRides(typeRides,userRideList);
            return invoiceDetailsByUserId;
        }

    }
}
