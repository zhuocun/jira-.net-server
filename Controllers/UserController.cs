using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/user/1
    [HttpGet("{userId}")]
    public IActionResult GetUser(int userId)
    {
        try
        {
            var user = _userService.GetUser(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            // Log the exception or perform additional error handling
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    // GET: api/user
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        try
        {
            var users = _userService.GetAllUsers();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }
        catch (Exception ex)
        {
            // Log the exception or perform additional error handling
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}