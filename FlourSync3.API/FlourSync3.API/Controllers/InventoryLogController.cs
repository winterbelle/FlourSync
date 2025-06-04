using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Importing EF Core for database operations
using FlourSync3.API.Data; // Importing the data context for database access
using FlourSync3.API.Models; // Importing the models for database entities

namespace FlourSync3.API.Controllers
{
    [ApiController] // Indicates that this class is an API controller
    [Route("api/[controller]")] // Sets the route for the controller
    public class InventoryLogController : ControllerBase
    {
        private readonly FlourSyncContext _context; // Database context for accessing the database
        public InventoryLogController(FlourSyncContext context) // Constructor that takes the database context as a parameter
        {
            _context = context; // Assigning the context to the private field
        }
        // GET: api/inventorylog
        [HttpGet] // HTTP GET method to retrieve all inventory logs
        public async Task<ActionResult<IEnumerable<InventoryLog>>> GetInventoryLog() // Asynchronous method returning a list of InventoryLogs
        {
            return await _context.InventoryLog.ToListAsync(); // Fetching all inventory logs from the database asynchronously
        }
        // GET: api/inventorylog/{id}
        [HttpGet("{id}")] // HTTP GET method to retrieve an inventory log by its ID
        public async Task<ActionResult<InventoryLog>> GetInventoryLog(int id) // Asynchronous method returning a single InventoryLog
        {
            var inventoryLog = await _context.InventoryLog.FindAsync(id); // Finding the InventoryLog by ID asynchronously
            if (inventoryLog == null) // If the InventoryLog is not found
            {
                return NotFound(); // Return 404 Not Found
            }
            return inventoryLog; // Return the found InventoryLog
        }
        // POST: api/inventorylog
        [HttpPost] // HTTP POST method to create a new inventory log entry
        public async Task<ActionResult<InventoryLog>> PostInventoryLog(InventoryLog inventoryLog) // Asynchronous method to create a new InventoryLog
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InventoryLog.Add(inventoryLog); // Adding the new InventoryLog to the context
            await _context.SaveChangesAsync(); // Saving changes to the database asynchronously
            return CreatedAtAction(nameof(GetInventoryLog), new { id = inventoryLog.LogID }, inventoryLog); // Return 201 Created with the location of the new InventoryLog
        }

        // PUT: api/inventorylog/{id}
        [HttpPut("{id}")] // HTTP PUT method to update an existing inventory log entry
        public async Task<IActionResult> PutInventoryLog(int id, [FromBody] InventoryLog inventoryLog) // Asynchronous method to update an InventoryLog
        {
            if (id != inventoryLog.LogID) // If the ID in the URL does not match the InventoryLog ID
            {
                return BadRequest(); // Return
            }
            _context.Entry(inventoryLog).State = EntityState.Modified; // Mark the InventoryLog as modified
            try
            {
                await _context.SaveChangesAsync(); // Save changes to the database asynchronously
            }
            catch (DbUpdateConcurrencyException) // Handle concurrency exceptions
            {
                if (!_context.InventoryLog.Any(e => e.LogID == id)) // If the InventoryLog does not exist
                {
                    return NotFound(); // Return 404 Not Found
                }
                else
                {
                    throw; // Rethrow the exception if it is a different issue
                }
            }
            return NoContent(); // Return 204 No Content if the update was successful
        }
        //DELETE: api/inventorylog/{id}
        [HttpDelete("{id}")] // HTTP DELETE method to delete an inventory log entry by its ID
        public async Task<IActionResult> DeleteInventoryLog(int id) 
        { 
                var inventoryLog = await _context.InventoryLog.FindAsync(id); // Finding the InventoryLog by ID Asynchronously
            if (inventoryLog == null) // If the InventoryLog is not found
                {
                    return NotFound(); // Return 404 Not Found
                }
                _context.InventoryLog.Remove(inventoryLog); // Removing the InventoryLog from the context
                await _context.SaveChangesAsync(); // Saving changes to the database synchronously
                return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}
