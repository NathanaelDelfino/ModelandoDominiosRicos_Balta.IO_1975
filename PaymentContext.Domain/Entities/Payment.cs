using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        public const int MaxTamanhoPay = 2;
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPeid, string payer, Document document, Address addres, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPeid = totalPeid;
            Payer = payer;
            Document = document;
            Addres = addres;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "O total não pode ser 0")
                .IsGreaterOrEqualsThan(Total, totalPeid, "Payment.TotalPaid", "O valor pago é menor que o valor total")
            );
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPeid { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Address Addres { get; private set; }
        public Email Email { get; private set; }

    }

}