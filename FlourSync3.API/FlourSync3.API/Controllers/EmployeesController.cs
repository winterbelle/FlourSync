using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Importing EF Core for database operations
using FlourSync3.API.Data; // Importing the data context for database access
using FlourSync3.API.Models; // Importing the models for database entities


namespace FlourSync3.API.Controllers
{
    [ApiController] // Indicates that this class is an API controller
    [Route("api/[controller]")] // Sets the route for the controller
    public class EmployeesController : ControllerBase
    {
        private readonly FlourSyncContext _context; // Database context for accessing the database

        public EmployeesController(FlourSyncContext context) // Constructor that takes the database context as a parameter
        {
            _context = context; // Assigning the context to the private field
        }

        // GET: api/employees
        [HttpGet] // HTTP GET method to retrieve all employees
        public async Task<ActionResult<IEnumerable<Employees>>> GetEmployees() // Asynchronous method returning a list of Employees
        {
            return await _context.Employees.ToListAsync(); // Fetching all employees from the database asynchronously
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")] // HTTP GET method to retrieve a employee by its ID
        public async Task<ActionResult<Employees>> GetEmployees(int id) // Asynchronous method returning a single Employee
        {
            var employees = await _context.Employees.FindAsync(id); // Finding the Employee by ID asynchronously
            if (employees == null) // If the Employee is not found
            {
                return NotFound(); // Return 404 Not Found
            }
            return employees; // Return the found Employee
        }

        // POST: api/Employee
        [HttpPost] // HTTP POST method to create a new Employee
        public async Task<ActionResult<Employees>> PostEmployees(Employees employee) // Asynchronous method to create a new Employee
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employees.Add(employee); // Adding the new Employee to the context
            await _context.SaveChangesAsync(); // Saving changes to the database asynchronously
            return CreatedAtAction(nameof(GetEmployees), new { id = employee.EmployeeID }, employee); // Return 201 Created with the location of the new Employee
        }

        // PUT: api/Employees/{id}
        [HttpPut("{id}")] // HTTP PUT method to update an existing employee
        public async Task<IActionResult> PutEmployees(int id, [FromBody] Employees employee) // Asynchronous method to update a Employee
        {
            if (id != employee.EmployeeID) // If the ID in the URL does not match the Employee ID
            {
                return BadRequest(); // Return 400 Bad Request
            }
            _context.Entry(employee).State = EntityState.Modified; // Mark the Employee as modified
            try
            {
                await _context.SaveChangesAsync(); // Save changes to the database asynchronously
            }
            catch (DbUpdateConcurrencyException) // Handle concurrency exceptions
            {
                if (!_context.Employees.Any(e => e.EmployeeID == id)) // Check if the employee exists
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

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")] // HTTP DELETE method to delete a employee
        public async Task<IActionResult> DeleteEmployees(int id) // Asynchronous method to delete a employee
        {
            var employee = await _context.Employees.FindAsync(id); // Finding the employee by ID asynchronously
            if (employee == null) // If the employee is not found
            {
                return NotFound(); // Return 404 Not Found
            }
            _context.Employees.Remove(employee); // Remove the employee from the context
            await _context.SaveChangesAsync(); // Save changes to the database asynchronously
            return NoContent(); // Return 204 No Content on successful deletion  
        }
    }
}
