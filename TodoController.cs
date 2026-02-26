//==========================================================
// Gives access to API-related classes:
// ControllerBase → base class for API controllers
// ApiController → enables API behaviors (validation, auto 400)
// HttpGet / HttpPost → define HTTP methods
// ActionResult → used to return HTTP responses
// Use this when building Web APIs
//==========================================================
using Microsoft.AspNetCore.Mvc;


//==========================================================
// Gives access to Entity Framework Core methods:
// ToListAsync()
// SaveChangesAsync()
// Database operations
// Use this when working with database using EF Core
//==========================================================
using Microsoft.EntityFrameworkCore;


//==========================================================
// Gives access to AppDbContext (your database connection)
// Use this when accessing your database context
//==========================================================
using TodoApi.Data;


//==========================================================
// Gives access to TodoItem model (table structure)
// Use this when working with TodoItem entity
//==========================================================
using TodoApi.models;


//==========================================================
// Namespace helps organize project structure
// Usually matches folder structure
//==========================================================
namespace TodoApi.Controllers;


//==========================================================
// Defines the base URL for this controller
// [controller] automatically becomes "todo"
// Final route → api/todo
// Use this to define API endpoint route
//==========================================================
[Route("api/[controller]")]


//==========================================================
// Marks this class as an API controller
// Enables automatic validation & API behavior
// Always use for Web APIs
//==========================================================
[ApiController]


//==========================================================
// ControllerBase → base class for APIs (no Views)
// Use ControllerBase when building REST APIs
//==========================================================
public class TodoController : ControllerBase
{

    //======================================================
    // readonly → cannot be changed after constructor
    // AppDbContext → database connection
    // Used to access database tables
    //======================================================
    private readonly AppDbContext _context;


    //======================================================
    // Constructor
    // Dependency Injection:
    // ASP.NET automatically provides AppDbContext
    // Use constructor injection to access database
    //======================================================
    public TodoController(AppDbContext context)
    {
        _context = context;
    }


    //======================================================
    // [HttpGet] → Handles GET requests
    // URL: GET api/todo
    // Used when retrieving data from database
    //======================================================
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
    {
        //==================================================
        // ToListAsync() → gets all records from table
        // await → waits for database response
        // Returns list of TodoItem as JSON
        //==================================================
        return await _context.TodoItems.ToListAsync();
    }



    //======================================================
    // [HttpPost] → Handles POST requests
    // URL: POST api/todo
    // Used when creating new data
    //======================================================
    [HttpPost]
    public async Task<ActionResult<TodoItem>> CreateTodo(TodoItem item)
    {

        //==================================================
        // Add() → adds new item to DbContext memory
        // Not saved to database yet
        //==================================================
        _context.TodoItems.Add(item);


        //==================================================
        // SaveChangesAsync() → commits changes to database
        // Always call this after Add/Update/Delete
        //==================================================
        await _context.SaveChangesAsync();


        //==================================================
        // Ok() → returns HTTP 200 response
        // Sends created object back to client
        //==================================================
        return Ok(item);
    }
//     Situation	Use
// Get all data	HttpGet + ToListAsync()
// Create new data	HttpPost + Add() + SaveChangesAsync()
// Update data	HttpPut + Update()
// Delete data	HttpDelete + Remove()
// Access database	AppDbContext
// Return HTTP response	ActionResult

}