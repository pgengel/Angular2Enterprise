using EnterpriseAngular2.Data.Contexts;
using EnterpriseAngular2.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Http;
using System.Web.WebPages;


namespace EnterpriseAngular2.WebApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private readonly IBusinessContext _context;
        private Customer _selectedCustomer;

        public ICollection<Customer> Customers { get; private set; }

        public ValuesController()
        {

        }

        public ValuesController(IBusinessContext context)
        {
            _context = context;
            Customers = new ObservableCollection<Customer>();
        }


        // GET api/values/get
        public IEnumerable<Customer> Get()
        {
            try
            {
                using (var bc = new BusinessContext())
                {
                    var customers = bc.GetCustomerList();
                    return customers;    
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values/post
        public void Post([FromBody]string customer)
        {
            try
            {
                if (!customer.IsEmpty())
                {
                    
                    using (var bc = new BusinessContext())
                    {
                        Customer deserializedCustomer = JsonConvert.DeserializeObject<Customer>(customer);
                        bc.CreateCustomer(deserializedCustomer);
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string customer)
        {
            try
            {
                if (!customer.IsEmpty())
                {

                    using (var bc = new BusinessContext())
                    {
                        Customer deserializedCustomer = JsonConvert.DeserializeObject<Customer>(customer);
                        bc.UpdateCustomer(deserializedCustomer);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        public void Delete(string customer)
        {
            try
            {

                if (!customer.IsEmpty())
                {

                    using (var bc = new BusinessContext())
                    {
                        Customer deserializedCustomer = JsonConvert.DeserializeObject<Customer>(customer);
                        bc.DeleteCustomer(deserializedCustomer);
                        Customers.Remove(deserializedCustomer);
                        deserializedCustomer = null;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
