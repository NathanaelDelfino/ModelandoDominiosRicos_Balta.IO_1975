using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayementContext.Text.Mocks;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]

    public class SubscriptionHandlersTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.BoletoNumber = "12315481215120";
            command.FirstName = "BRUCE";
            command.LastName = "WAYNE";
            command.Document = "99999999999";
            command.Email = "teste@teste.com.br";
            command.BarCode = "123151512";
            command.BoletoNumber = "12151512";
            command.PaymentNumber = "451212120000512";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "WAYNE CORP";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "batman@dc.com";
            command.Street = "jsaidjdidjsa";
            command.Number = "asdsafsaf";
            command.Neighborhood = "asdsadadsa";
            command.City = "sffsaffas";
            command.State = "sc";
            command.Country = "BRASIL";
            command.ZipCode = "00000000";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}