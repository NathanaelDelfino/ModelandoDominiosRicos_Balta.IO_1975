using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PayementContext.Text.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {

        }

        public bool DocumentExists(string document)
        {
            if (document == "99999999999")
                return true;
            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "nathan@jrpdv.com.br")
                return true;
            return false;
        }
    }
}