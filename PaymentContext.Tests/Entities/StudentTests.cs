using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var subscription = new Subscription(null);
            var name = new Name("NATHANAEL", "DELFINO");
            var document = new Document("08634676951", Domain.Enums.EDocumentType.CPF);
            var email = new Email("teste@test.com");
            var student = new Student(name, document, email);
            student.addSubscription(subscription);
        }
    }

}