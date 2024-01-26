using API.Net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly APIDbContext _context;

        public OrderController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var loai = _context.Orders.ToList();
            return Ok(loai);
        }

        [HttpPost]
        public IActionResult Create(Order model)
        {
            try
            {
                var order = new Order
                {

                    ItemCode = model.ItemCode,
                    ItemName = model.ItemName,
                    ItemQty = model.ItemQty,
                    OrderDelivery = model.OrderDelivery,
                    OrderAddress = model.OrderAddress,
                    PhoneNumber = model.PhoneNumber
                };
                _context.Add(order);
                _context.SaveChanges();
                return Ok(order);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Order model)
        {
            var order = _context.Orders.SingleOrDefault(o => o.Id == id);
            if (order != null)
            {
                order.ItemName = model.ItemName;
                _context.SaveChanges();
                return Ok(order);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(o => o.Id == id);
                if (order == null)
                {
                    return NotFound();
                }

                _context.Orders.Remove(order);
                _context.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
