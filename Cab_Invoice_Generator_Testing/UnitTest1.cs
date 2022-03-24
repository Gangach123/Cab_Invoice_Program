using Cab_Invoice_Program;
using NUnit.Framework;

namespace Cab_Invoice_Generator_Testing
{
    public class Tests
    {
        public CabInvoiceGenerator cabInvoiceGenerator;
        //cost per km = 10 & per min = 1
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new CabInvoiceGenerator();
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
    }
}