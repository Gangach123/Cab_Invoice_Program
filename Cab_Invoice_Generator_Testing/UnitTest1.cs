using Cab_Invoice_Program;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cab_Invoice_Generator_Testing
{
    public class Tests
    {
        public CabInvoiceGenerator cabInvoiceGenerator;
        List<Enhanced_Invoice> enhancedInvoiceList;
        Ride[] multipleRides;
        
        
        //cost per km = 10 & per min = 1
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new CabInvoiceGenerator();
            multipleRides = new Ride[] { new Ride(2, 5), new Ride(3, 10), new Ride(0.1, 0.5) };
        }
        //Given distance in kmand time in minshould generate fair
        [Test]
        public void Test1()
        {
            double Fair = cabInvoiceGenerator.CalcuteFair(2,5);
            Assert.AreEqual(25, Fair);
        }
        [Test]
        public void Test2()
        {
            double Fair = cabInvoiceGenerator.CalcuteFair(0,0);
            Assert.AreEqual(5, Fair);
        }
        public void GivenDistanceAndTimeForMultipleRide_InvoiceGenerator_ReturnListofInvoiceDetails()
        {
            var details = enhancedInvoiceList[0];
            double totalFare = details.totalFare; double avgFare = details.averageFarePerRide; int noOfRides = details.totalNumberOfRides;
            Assert.AreEqual(80, totalFare);
            Assert.AreEqual(20, avgFare);
            Assert.AreEqual(4, noOfRides);
        }
    }
}