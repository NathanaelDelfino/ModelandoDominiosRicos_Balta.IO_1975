using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();

            for (var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(new Name("Aluno", "Qualquer"),
                                          new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                                          new Email("teste" + i.ToString() + "@teste.com.br")));

            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExits()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreEqual(null, studn);
        }
        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExits()
        {
            var exp = StudentQueries.GetStudentInfo("111111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreEqual(null, studn);
        }
    }


}