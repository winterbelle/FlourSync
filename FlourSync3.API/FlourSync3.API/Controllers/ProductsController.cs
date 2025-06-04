using Microsoft.AspNetCore.Mvc; // Importing ASP.NET Core MVC for building web APIs
using Microsoft.EntityFrameworkCore; // Importing EF Core for database operations
using FlourSync3.API.Data; // Importing the data context for database access
using FlourSync3.API.Models; // Importing the models for database entities

namespace FlourSync3.API.Controllers
{
    [ApiController] // Indicates that this class is an API controller
        [Route("api/[controller]")] // Sets the route for the controller
    public class ProductsController: ControllerBase
    {
        private readonly FlourSyncContext _context; // Database context for accessing the database

        public ProductsController(FlourSyncContext context) // Constructor that takes the database context as a parameter
        {
            _context = context; // Assigning the context to the private field
        }

        // GET: api/products
        [HttpGet] // HTTP GET method to retrieve all products
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts() // Asynchronous method returning a list of Products
        {
            return await _context.Products.ToListAsync(); // Fetching all products from the database asynchronously
        }

        // GET: api/products/{id}
        [HttpGet("{id}")] // HTTP GET method to retrieve a product by its ID
        public async Task<ActionResult<Products>> GetProduct(int id) // Asynchronous method returning a single Product
        {
            var product = await _context.Products.FindAsync(id); // Finding the product by ID asynchronously
            if (product == null) // If the product is not found
            {
                return NotFound(); // Return 404 Not Found
            }
            return product; // Return the found product
        }

        // POST: api/products
        [HttpPost] // HTTP POST method to create a new product
        public async Task<ActionResult<Products>> PostProduct(Products product) // Asynchronous method to create a new Product
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Products.Add(product); // Adding the new product to the context
            await _context.SaveChangesAsync(); // Saving changes to the database asynchronously
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductID }, product); // Return 201 Created with the location of the new product
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")] // HTTP PUT method to update an existing product
        public async Task<IActionResult> PutProduct(int id, [FromBody] Products product) // Asynchronous method to update a Product
        {
            if (id != product.ProductID) // If the ID in the URL does not match the product ID
            {
                return BadRequest(); // Return 400 Bad Request
            }
            _context.Entry(product).State = EntityState.Modified; // Mark the product as modified
            try
            {
                await _context.SaveChangesAsync(); // Save changes to the database asynchronously
            }
            catch (DbUpdateConcurrencyException) // Handle concurrency exceptions
            {
                if (!_context.Products.Any(e => e.ProductID == id)) // Check if the product exists
                {
                    return NotFound(); // Return 404 Not Found if it does not exist
                }
                else
                {
                    throw; // Rethrow the exception if it is a different issue
                }
            }
            return NoContent(); // Return 204 No Content on successful update
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")] // HTTP DELETE method to delete a product
        public async Task<IActionResult> DeleteProduct(int id) // Asynchronous method to delete a Product
        {
            var product = await _context.Products.FindAsync(id); // Finding the product by ID asynchronously
            if (product == null) // If the product is not found
            {
                return NotFound(); // Return 404 Not Found
            }
            _context.Products.Remove(product); // Remove the product from the context
            await _context.SaveChangesAsync(); // Save changes to the database asynchronously
            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}
