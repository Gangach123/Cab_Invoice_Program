using Cab_Invoice_Program;
using NUnit.Framework;
using System.Collections.Generic;

namespace Cab_Invoice_Generator_Testing
{
    public class Tests
    {
        public CabInvoiceGenerator cabInvoiceGenerator;
        List<Enhanced_Invoice> enhancedInvoiceList;
        Ride_Repository ride_Repository;
        List<Ride> multipleRides1;
        List<Ride> multipleRides2;


        //cost per km = 10 & per min = 1
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new CabInvoiceGenerator();
            multipleRides1 = new List<Ride> { new Ride(2, 10), new Ride(3, 10), new Ride(0.1, 0.5), new Ride(0.1, 0.5) };
            multipleRides2 = new List<Ride> { new Ride(0.1, 0.5), new Ride(0.1, 0.5) };
            ride_Repository = new Ride_Repository();
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
        [Test]
        public void GivenUserIDInInvoice_GetsListofRides_ReturnAverageFare()
        {
            ride_Repository.AddRidesInRepo("Viney111", multipleRides1);
            ride_Repository.AddRidesInRepo("Yash111", multipleRides2);
            var invoiceDetailsFor_Viney = cabInvoiceGenerator.Get_Invoice_By_UserId("Viney111");
            var invoiceDetailsFor_Yash = cabInvoiceGenerator.Get_Invoice_By_UserId("Yash111");
            Assert.AreEqual(20, invoiceDetailsFor_Viney.averageFarePerRide);
            Assert.AreEqual(5, invoiceDetailsFor_Yash.averageFarePerRide);
        }
        [Test]
        public void GivenUserIDInInvoice_GetsListofRides_ReturnTotalFare()
        {
            ride_Repository.AddRidesInRepo("Viney111", multipleRides1);
            ride_Repository.AddRidesInRepo("Yash111", multipleRides2);
            var invoiceDetailsFor_Viney = cabInvoiceGenerator.Get_Invoice_By_UserId("Viney111");
            var invoiceDetailsFor_Yash = cabInvoiceGenerator.Get_Invoice_By_UserId("Yash111");
            Assert.AreEqual(80, invoiceDetailsFor_Viney.totalFare);
            Assert.AreEqual(10, invoiceDetailsFor_Yash.totalFare);
        }
        [Test]
        public void GivenUserIDInInvoice_GetsListofRides_ReturnNumberOfRides()
        {
            ride_Repository.AddRidesInRepo("Viney111", multipleRides1);
            ride_Repository.AddRidesInRepo("Yash111", multipleRides2);
            var invoiceDetailsFor_Viney = cabInvoiceGenerator.Get_Invoice_By_UserId("Viney111");
            var invoiceDetailsFor_Yash = cabInvoiceGenerator.Get_Invoice_By_UserId("Yash111");
            Assert.AreEqual(4, invoiceDetailsFor_Viney.totalNumberOfRides);
            Assert.AreEqual(2, invoiceDetailsFor_Yash.totalNumberOfRides);
        }
    }
}