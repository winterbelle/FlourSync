using FlourSync3.API.Data;
using FlourSync3.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlourSync3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly FlourSyncContext _context;

        public OrdersController(FlourSyncContext context)
        {
            _context = context;
        }

        // ===========================================
        // GET: api/orders
        // ===========================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // ===========================================
        // GET: api/orders/{id}
        // ===========================================
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            return order;
        }

        // ===========================================
        // POST: api/orders
        // ===========================================
        [HttpPost]
        public async Task<ActionResult<Orders>> PostOrder(Orders order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the new order
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Return 201 Created with a Location: header
            return CreatedAtAction(
                nameof(GetOrder),
                new { id = order.OrderID },
                order
            );
        }

        // ===========================================
        // PUT: api/orders/{id}
        // ===========================================
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Orders order)
        {
            // Make sure the URL ID matches the body’s OrderID
            if (id != order.OrderID)
                return BadRequest("Order ID mismatch.");

            // Tell EF we’ve updated this record
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
                    return NotFound();
                else
                    throw; // Bubble up any other concurrency issues
            }

            // 204 No Content on success (no response body)
            return NoContent();
        }

        // ===========================================
        // DELETE: api/orders/{id}
        // ===========================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ===========================================
        // Helper: Check if an order exists by ID
        // ===========================================
        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
