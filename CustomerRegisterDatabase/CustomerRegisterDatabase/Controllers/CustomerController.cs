using CustomerRegisterDatabase.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerRegisterDatabase.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private DatabaseContext databaseContext;

        public CustomerController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {

            databaseContext.Add(customer);
            databaseContext.SaveChanges();

            return Ok(customer.Id);
        }
        
    }
}
