using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angular2Enterprise.Database.Contexts;
using Angular2Enterprise.Database.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Angular2Enterprise.Database.Tests.FunctionalTests
{
    [TestClass]
    public class CustomerScenarioTests
    {
        [TestMethod]
        public void CreateCustomer()
        {
            using (var bc = new BusinessContext())
            {
                var customer = new Customer
                {
                    Email = "p@g.e",
                    FirstName = "P",
                    LastName = "E"
                };

                bc.CreateCustomer(customer);

                bool exists = bc.DataContext.Customers.Any(c => c.Id == customer.Id);

                Assert.IsTrue(exists);
            }
        }
    }
}
