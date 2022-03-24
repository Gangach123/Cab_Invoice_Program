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
            double Fair = cabInvoiceGenerator.CalcuteFair(TypeOfRide.NORMAL_RIDE,2, 5);
            Assert.AreEqual(25, Fair);
        }
        [Test]
        public void Test2()
        {
            double Fair = cabInvoiceGenerator.CalcuteFair(TypeOfRide.NORMAL_RIDE,0, 0);
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
        public void GivenDistanceAndTimeForMultipleRide_InvoiceGenerator_ReturnTotalFare()
        {
            double result = cabInvoiceGenerator.MultipleRide(TypeOfRide.NORMAL_RIDE, multipleRides1);
            Assert.AreEqual(80, result);
        }
        [Test]
     
        public void GivenUserIDInInvoice_GetsListofRides_ReturnAverageFare()
        {
            ride_Repository.AddRidesInRepo("GANGA123", multipleRides1);
            ride_Repository.AddRidesInRepo("TEJA123", multipleRides2);
            var invoiceDetailsFor_Ganga = cabInvoiceGenerator.Get_Invoice_By_UserId(TypeOfRide.NORMAL_RIDE,"GANGA123");
            var invoiceDetailsFor_Teja = cabInvoiceGenerator.Get_Invoice_By_UserId(TypeOfRide.NORMAL_RIDE,"TEJA123");
            Assert.AreEqual(20, invoiceDetailsFor_Ganga.averageFarePerRide);
            Assert.AreEqual(5, invoiceDetailsFor_Teja.averageFarePerRide);
        }
        [Test]
        public void GivenUserIDInInvoice_GetsListofRides_ReturnTotalFare()
        {
            ride_Repository.AddRidesInRepo("GANGA123", multipleRides1);
            ride_Repository.AddRidesInRepo("TEJA123", multipleRides2);
            var invoiceDetailsFor_Ganga = cabInvoiceGenerator.Get_Invoice_By_UserId(TypeOfRide.NORMAL_RIDE,"GANGA123");
            var invoiceDetailsFor_Teja = cabInvoiceGenerator.Get_Invoice_By_UserId(TypeOfRide.NORMAL_RIDE,"TEJA123");
            Assert.AreEqual(80, invoiceDetailsFor_Ganga.totalFare);
            Assert.AreEqual(10, invoiceDetailsFor_Teja.totalFare);
        }
        [Test]
        public void GivenUserIDInInvoice_GetsListofRides_ReturnNumberOfRides()
        {
            ride_Repository.AddRidesInRepo("GANGA123", multipleRides1);
            ride_Repository.AddRidesInRepo("TEJA123", multipleRides2);
            var invoiceDetailsFor_Ganga = cabInvoiceGenerator.Get_Invoice_By_UserId(TypeOfRide.NORMAL_RIDE,"GANGA123");
            var invoiceDetailsFor_Teja = cabInvoiceGenerator.Get_Invoice_By_UserId(TypeOfRide.NORMAL_RIDE,"TEJA123");
            Assert.AreEqual(4, invoiceDetailsFor_Ganga.totalNumberOfRides);
            Assert.AreEqual(2, invoiceDetailsFor_Teja.totalNumberOfRides);
        }
        public void GivenUserIDInInvoice_WithPremiumAndNormalRide_GetsListofRides_ReturnAverageFareORespectiveRides()
        {
            ride_Repository.AddRidesInRepo("Gang123", multipleRides1);
            ride_Repository.AddRidesInRepo("Teja123", multipleRides2);
            var invoiceDetailsFor_Ganga = cabInvoiceGenerator.Get_Invoice_By_UserId(TypeOfRide.PREMIUM_RIDE, "Ganga123");
            var invoiceDetailsFor_Teja = cabInvoiceGenerator.Get_Invoice_By_UserId(TypeOfRide.NORMAL_RIDE, "Teja123");
            Assert.AreEqual(38.75, invoiceDetailsFor_Ganga.averageFarePerRide);
            Assert.AreEqual(5, invoiceDetailsFor_Teja.averageFarePerRide);
        }
    }
}