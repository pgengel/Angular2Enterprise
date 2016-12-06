using System;
using Angular2Enterprise.Database.Contexts;
using Angular2Enterprise.Database.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Angular2Enterprise.Database.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewCustomer_ThrowsException_WhenEmailIsNull()
        {
            using (var bc = new BusinessContext())
            {
                var customer = new Customer
                {
                    Email = null,
                    FirstName = "David",
                    LastName = "Anderson"
                };
                bc.CreateCustomer(customer);
            }
        }
    }
}
