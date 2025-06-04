using Microsoft.AspNetCore.Mvc;
using FlourSync3.API.Models; // Assuming Cart model is in this namespace
using FlourSync3.API.Data; // Assuming FlourSyncContext is in this namespace
using Microsoft.EntityFrameworkCore; // For DbContext functionality



namespace FlourSync3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly FlourSyncContext _context; // Injecting the DbContext to interact with the database

        public CartController(FlourSyncContext context)
        {
            _context = context; // Assigning the injected context to the private field
        }

        //Get: api/cart -> Retrieves all items added to the cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCartItems()
        {
            // Fetching all cart items from the database
            var cartItems = await _context.Cart.ToListAsync();
            return Ok(cartItems); // Returning the list of cart items with a 200 OK status
        }

        //Get: api/cart/{id} -> Retrieves a specific cart item by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCartItem(int id)
        {
            // Finding the cart item by ID
            var cartItem = await _context.Cart.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound(); // Returning 404 Not Found if the item does not exist
            }
            return Ok(cartItem); // Returning the found cart item with a 200 OK status
        }

        //Post: api/cart -> Adds a new item to the cart
        [HttpPost]
        public async Task<ActionResult<Cart>> AddCartItem(Cart cartItem)
        {
            // Adding the new cart item to the context
            _context.Cart.Add(cartItem);
            await _context.SaveChangesAsync(); // Saving changes to the database
            return CreatedAtAction(nameof(GetCartItem), new { id = cartItem.CartId }, cartItem); // Returning 201 Created with the location of the new item
        }

        //Put: api/cart/{id} -> Updates an existing cart item
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, Cart cartItem)
        {
            if (id != cartItem.CartId) // Checking if the ID in the URL matches the cart item ID
            {
                return BadRequest(); // Returning 400 Bad Request if they do not match
            }
            _context.Entry(cartItem).State = EntityState.Modified; // Marking the cart item as modified
            try
            {
                await _context.SaveChangesAsync(); // Saving changes to the database
            }
            catch (DbUpdateConcurrencyException) // Handling concurrency exceptions
            {
                if (!_context.Cart.Any(e => e.CartId == id)) // Checking if the cart item exists
                {
                    return NotFound(); // Returning 404 Not Found if it does not exist
                }
                throw; // Rethrowing the exception if it is a different issue
            }
            return NoContent(); // Returning 204 No Content on successful update
        }

        //Delete: api/cart/{id} -> Deletes a cart item by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var cartItem = await _context.Cart.FindAsync(id); // Finding the cart item by ID
            if (cartItem == null)
            {
                return NotFound(); // Returning 404 Not Found if the item does not exist
            }
            _context.Cart.Remove(cartItem); // Removing the cart item from the context
            await _context.SaveChangesAsync(); // Saving changes to the database
            return NoContent(); // Returning 204 No Content on successful deletion
        }
    }
}
