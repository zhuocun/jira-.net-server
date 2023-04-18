using Microsoft.AspNetCore.Mvc;

namespace jira_.net_server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainController : ControllerBase
{
    // GET: api/main/hello
    [HttpGet("hello")]
    public IActionResult GetHelloWorld()
    {
        try
        {
            // Your code here
            return Ok("Hello, World!");
        }
        catch (Exception ex)
        {
            // Log the exception or perform additional error handling
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    // GET: api/main/greet?name=John
    [HttpGet("greet")]
    public IActionResult GetGreeting(string name)
    {
        try
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Name parameter cannot be empty.");
            }

            return Ok($"Hello, {name}!");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // Log the exception or perform additional error handling
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    // POST: api/main/message
    [HttpPost("message")]
    public IActionResult PostMessage([FromBody] string message)
    {
        try
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException("message", "Message cannot be empty.");
            }

            return Ok($"Received message: {message}");
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // Log the exception or perform additional error handling
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
