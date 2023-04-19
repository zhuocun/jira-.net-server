using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/users/1
    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(string userId)
    {
        try
        {
            var user = await _userService.Get(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    // GET: api/users
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var users = await _userService.GetMembers();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

}