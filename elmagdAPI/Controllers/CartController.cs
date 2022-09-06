using Domain.shopdb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace elmagdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly shopdbContext _shopdbContext;
        public CartController(shopdbContext shopdbContext)
        {
            _shopdbContext = shopdbContext;
        }
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            return _shopdbContext.Carts.Find(id);
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CartController>/5
        [HttpPut]
        public void Put([FromBody] Cart cart)
        {
            var currentCart = _shopdbContext.Carts.Find(cart.Id);
            currentCart.ItemsNumber = cart.ItemsNumber;
            currentCart.TotalPrice = cart.TotalPrice;
            _shopdbContext.SaveChanges();
        }
    }

        
    
}
