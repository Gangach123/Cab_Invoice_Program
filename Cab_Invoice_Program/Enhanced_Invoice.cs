using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Program
{
    public class Enhanced_Invoice : CabInvoiceGenerator
    {
        public int totalNumberOfRides { get; set; }
        public double totalFare { get; set; }
        public double averageFarePerRide { get; set; }

        public object Getting_Details_Of_Invoice_In_Object(TypeOfRide rideTypes, List<Ride> rides)
        {
            this.totalFare = MultipleRide(rideTypes,rides);
            this.totalNumberOfRides = rides.Count;
            this.averageFarePerRide = this.totalFare / this.totalNumberOfRides;
            return this; ;
        }
    }
}
