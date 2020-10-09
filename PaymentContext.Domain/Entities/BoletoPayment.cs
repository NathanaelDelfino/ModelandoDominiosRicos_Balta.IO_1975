using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode,
                             string boletoNumber,
                             DateTime paidDate,
                             DateTime expireDate,
                             decimal total,
                             decimal totalPeid,
                             string payer,
                             Document document,
                             Address addres,
                             Email email) : base(paidDate, expireDate, total, totalPeid, payer, document, addres, email)
        {
            BarCode = barCode;

            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }

        public string BoletoNumber { get; private set; }

    }
}