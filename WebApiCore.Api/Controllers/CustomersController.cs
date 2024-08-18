using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Data;
using WebApiCore.Data.Models;

namespace WebApiCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly WebApiCoreContext context;

        public CustomersController(WebApiCoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return context.Customers.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return new Customer{BirthDate = DateTime.Now, Email = "some@gmail.com", Name = "Name", Id = 0};
        }

        [HttpPost]
        public void Post([FromQuery] Customer value)
        {

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromQuery] Customer value)
        {
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}