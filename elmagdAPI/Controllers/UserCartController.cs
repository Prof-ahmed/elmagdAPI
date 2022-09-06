using Domain.shopdb;
using elmagdAPI.AutoMapper;
using elmagdAPI.Dto;
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
    public class UserCartController : ControllerBase
    {
        private readonly shopdbContext _shopdbContext;
        public UserCartController(shopdbContext shopdbContext)
        {
            _shopdbContext = shopdbContext;
        }
        // GET: api/<UserCartController>
        [HttpGet("{customerId}")]
        
        public IEnumerable<GetCustomerCart> Get(int customerId)
        {
            return _shopdbContext.CusCarts
                .Include(x => x.Cart)
                .ThenInclude(x => x.Customer)
                .Include(x => x.Color)
                .Include(x => x.Size)
                .Include(x => x.PaymentMethod)
                .Where(x=>x.Cart.CustomerId == customerId)
                .Select(x => new GetCustomerCart()
                {
                    Id = x.Id,
                    SizeName = x.Size.SizeValue,
                    ColorName = x.Color.ColorValue,
                    PaymentMethodName = x.PaymentMethod.PaymentName,
                    CartId = x.CartId,
                    Cart = x.Cart,
                    ItemName = x.Item.ItemName
                })
                .ToList();
        }

        // GET api/<UserCartController>/5
        //[HttpGet("{id}")]
        //public string Get(GetCustomerCart customerCart)
        //{
        //}

        // POST api/<UserCartController>
        [HttpPost]
        public void Post([FromBody] PostCustomerCart customerCart)
        {
            _shopdbContext.CusCarts.Add(customerCart.ToDto<PostCustomerCart, CusCart>());
            _shopdbContext.SaveChanges();
        }

        // PUT api/<UserCartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserCartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
