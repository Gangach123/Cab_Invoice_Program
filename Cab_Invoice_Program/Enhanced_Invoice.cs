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

        public object GettingDetailsOfInvoiceInObject(Ride[] rides)
        {
            this.totalFare = MultipleRide(rides);
            this.totalNumberOfRides = rides.Length;
            this.averageFarePerRide = this.totalFare / this.totalNumberOfRides;
            return this;
        }
    }
}
