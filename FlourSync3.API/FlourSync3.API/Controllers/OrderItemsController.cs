using FlourSync3.API.Data;
using FlourSync3.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlourSync3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly FlourSyncContext _context;

        public OrderItemsController(FlourSyncContext context)
        {
            _context = context;
        }

        // ===========================================
        // GET: api/OrderItems
        // ===========================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItems>>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        // ===========================================
        // GET: api/OrderItems/{id}
        // ===========================================
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItems>> GetOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
                return NotFound();

            return orderItem;
        }

        // ===========================================
        // POST: api/OrderItems
        // ===========================================
        [HttpPost]
        public async Task<ActionResult<OrderItems>> PostOrderItem(OrderItems orderItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the new order item
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            // Return 201 Created with a Location: header
            return CreatedAtAction(
                nameof(GetOrderItem),
                new { id = orderItem.ItemID },
                orderItem
            );
        }

        // ===========================================
        // PUT: api/OrderItems/{id}
        // ===========================================
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItems orderItem)
        {
            // Make sure the URL ID matches the body’s OrderItemID
            if (id != orderItem.ItemID)
                return BadRequest("OrderItem ID mismatch.");

            // Tell EF we’ve updated this record
            _context.Entry(orderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemsExists(id))
                    return NotFound();
                else
                    throw;
            }

            // 204 No Content on success (no response body)
            return NoContent();
        }

        // ===========================================
        // DELETE: api/OrderItems/{id}
        // ===========================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
                return NotFound();

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ===========================================
        // Helper: Check if an order item exists by ID
        // ===========================================
        private bool OrderItemsExists(int id)
        {
            return _context.OrderItems.Any(e => e.ItemID == id);
        }
    }
}


// Note: Ensure that the OrderItems model has a property named OrderItemID as the primary key.  
// If it is named differently, adjust the code accordingly.
// Once you match the controller code to the actual property names in your model, the compiler error will disappear.
// Also, ensure that the FlourSyncContext is properly configured to include the OrderItems DbSet.
// Example DbSet in FlourSyncContext:   
// public DbSet<OrderItems> OrderItems { get; set; } // Maps to the OrderItems table in the database.
// This allows the controller to interact with the OrderItems table in the database.