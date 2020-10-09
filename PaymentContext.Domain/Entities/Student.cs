using System.Collections.Generic;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private List<Subscription> _subscriptions;


        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Addres { get; private set; }
        public IReadOnlyList<Subscription> Subscriptions { get { return _subscriptions; } }

        public void addSubscription(Subscription subscription)
        {
            foreach (var sub in Subscriptions)
            {


            }

            _subscriptions.Add(subscription);
        }
    }

}