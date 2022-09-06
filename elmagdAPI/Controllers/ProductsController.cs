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
    public class ProductsController : ControllerBase
    {
        private readonly shopdbContext _shopdbContext;
        public ProductsController(shopdbContext shopdbContext)
        {
            _shopdbContext = shopdbContext;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _shopdbContext.Items.ToList();
        }
        [HttpGet]
        [Route("ProductsByBrand/{barndId}")]
        public IEnumerable<Item> Get(int barndId)
        {
            return _shopdbContext.Items.Where(x => x.BrandId == barndId).ToList();
        }


        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
