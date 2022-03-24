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
        public double CalcuteFair(double distance, double time)
        {
            double Fare = distance * COST_PER_KM + time * COST_PER_MINUTE;
            if (Fare > MINIMUM_FARE)
            {
                return Fare;
            }
            return MINIMUM_FARE;
        }
        public double MultipleRide(Ride[] rides)
        {
            double multipleRideFare = 0;
            foreach (Ride ride in rides)
            {
                multipleRideFare += CalcuteFair(ride.distance, ride.time);
            }
            return multipleRideFare;
        }


    }
}
