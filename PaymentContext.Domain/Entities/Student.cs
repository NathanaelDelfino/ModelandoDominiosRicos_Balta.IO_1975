using System.Collections.Generic;
using Flunt.Validations;
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

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura ativa")
                .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possuí pagamentos")
            );

            if (Valid)
                _subscriptions.Add(subscription);
            // if (hasSubscriptionActive)
            //     AddNotification("Student.Subscription", "Você já tem uma assinatura ativa");
        }
    }

}