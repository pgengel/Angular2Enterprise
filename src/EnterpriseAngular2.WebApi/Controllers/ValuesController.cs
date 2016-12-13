using EnterpriseAngular2.Data.Contexts;
using EnterpriseAngular2.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Http;



namespace EnterpriseAngular2.WebApi.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private readonly IBusinessContext _context;
        private Customer _selectedCustomer;

        public ICollection<Customer> Customers { get; private set; }

        public ValuesController(IBusinessContext context)
        {
            _context = context;
            Customers = new ObservableCollection<Customer>();
        }


        // GET api/values
        public IEnumerable<Customer> Get()
        {
            try
            {
                Customers.Clear();
                return _context.GetCustomerList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        //// GET api/values/5
        //public Customer Get(int id)
        //{
        //    return _context.GetCustomerList().;
        //}

        // POST api/values
        public void Post([FromBody]Customer customer)
        {
            try
            {
                _context.CreateCustomer(customer);
            }
            catch (Exception e)
            {

                throw;
            }

            Customers.Add(customer);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Customer customer)
        {
            try
            {
                _context.UpdateCustomer(customer);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // DELETE api/values/5
        public void Delete(Customer customer)
        {
            try
            {
                _context.DeleteCustomer(customer);
                Customers.Remove(customer);
                customer = null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
