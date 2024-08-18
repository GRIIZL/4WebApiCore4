using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Data;
using WebApiCore.Data.Repository;
using WebApiCore.Data.Models;

namespace WebApiCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public IRepository<Customer> contextCustomers { get; private set; }

        public CustomersController(IRepository<Customer> contextCustomers)
        {
            this.contextCustomers = contextCustomers;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            // logger.LogInformation("getting all customers");
            //throw new Exception("We need to do this...");
            return contextCustomers.All;
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return contextCustomers.FindById(id);
        }

        [HttpPost]
        public void Post([FromQuery] Customer value)
        {
            contextCustomers.Update(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer value)
        {
            contextCustomers.Add(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = contextCustomers.FindById(id);
            contextCustomers.Delete(entity);
        }
    }
}