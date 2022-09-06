using Domain.shopdb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace elmagdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly shopdbContext _shopdbContext;
        public AccountController(shopdbContext shopdbContext)
        {
            _shopdbContext = shopdbContext;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _shopdbContext.Customers.ToList();
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _shopdbContext.Customers.Include(x=>x.Carts).Where(x=>x.Id == id).FirstOrDefault();
        }

        // POST api/<AccountController>
        [HttpPost]
        [Route("Register")]
        public decimal Post([FromBody] Customer customer)
        {
            var newCustomer = _shopdbContext.Customers.Add(customer);
            _shopdbContext.SaveChanges();
            return newCustomer.Entity.Id;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult<Customer> Get([FromBody] Customer customer)
        {
            return _shopdbContext.Customers
                .Include(x=>x.Carts)
                .Where(x => x.UserName == customer.UserName && x.UserPassward == customer.UserPassward).FirstOrDefault();
        }
        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
