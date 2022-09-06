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
    public class CommonController : ControllerBase
    {
        private readonly shopdbContext _shopdbContext;
        public CommonController(shopdbContext shopdbContext)
        {
            _shopdbContext = shopdbContext;
        }
        // GET: api/<CommonController>
        [HttpGet]
        [Route("colors")]
        public IEnumerable<Color> Getcolors()
        {
            return _shopdbContext.Colors.ToList();
        }
        [HttpGet]
        [Route("sizes")]
        public IEnumerable<Size> Getsizes()
        {
            return _shopdbContext.Sizes.ToList();
        }
        // GET api/<CommonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CommonController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CommonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
