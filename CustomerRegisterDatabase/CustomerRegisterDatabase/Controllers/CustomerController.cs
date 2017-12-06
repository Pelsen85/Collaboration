using CustomerRegisterDatabase.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CustomerRegisterDatabase.Controllers
{

    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private DatabaseContext databaseContext;

        public CustomerController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            databaseContext.Database.EnsureCreated();
        }

        [HttpGet, Route("GetCustomers")]

        public IActionResult GetCustomers()
        {
            var list = databaseContext.Customers.ToList();
            return Ok(list);
        }

        [HttpPost, Route("AddCustomer")]
        public IActionResult Add([FromBody]Customer obj)
        {

            databaseContext.Add(obj);
            databaseContext.SaveChanges();

            return Ok();
        }

        [HttpDelete,Route("DeleteCustomer/{id}")]

        public IActionResult DeleteCustomer(int id)
        {
            var customer = databaseContext.Customers.First(c => c.Id == id);

            databaseContext.Remove(customer);
            databaseContext.SaveChanges();
            return Ok();
        }

        [HttpPut,Route("EditCustomer/{id}")]
        public IActionResult EditCustomer(int id, Customer options)
        {
            var editedCustomer = databaseContext.Customers.FirstOrDefault(e => e.Id == id);

            editedCustomer.FirstName = options.FirstName;

            databaseContext.Update(editedCustomer);
            databaseContext.SaveChanges();
            return new ObjectResult("Customer updated successfully!");
        }
    }
}