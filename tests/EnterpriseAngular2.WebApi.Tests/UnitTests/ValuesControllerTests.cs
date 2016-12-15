using EnterpriseAngular2.Data.Contexts;
using EnterpriseAngular2.Data.Models;
using EnterpriseAngular2.WebApi.Controllers;
using NSubstitute;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EnterpriseAngular2.WebApi.Tests.UnitTests
{
    [TestFixture]
    public class ValuesControllerTests
    {
        [Test]
        public void GetCustomer_GivenCustomers_ShouldReturnCustomers()
        {
            //arrange
            var testCustomers = GetTestCustomer();
            var fakeController = Substitute.For<IBusinessContext>();
            var expectedResult = fakeController.GetCustomerList().Returns(testCustomers);

            var valueController = new ValuesController(fakeController);

            //act
            var actualResult = valueController.Get();

            //assert
            //Assert.AreEqual(expectedResult, actualResult);

        }

        private List<Customer> GetTestCustomer()
        {
            var testCustomer = new List<Customer>();
            testCustomer.Add(new Customer()
            {
                Id = 1,
                Email = "p@g.e",
                FirstName = "p",
                LastName = "e"
            });

            testCustomer.Add(new Customer()
            {
                Id = 2,
                Email = "a@b.c",
                FirstName = "a",
                LastName = "b"
            });

            return testCustomer;
        }
    }
}
