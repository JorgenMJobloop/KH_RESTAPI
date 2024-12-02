using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/testing/users")]
public class TestUserController : ControllerBase
{
    // TODO: Add the required logic for our usercontroller to support our database implementation
    /// <summary>
    /// Mock data for our GET-endpoint
    /// </summary>

    private readonly AppDbContext _context;

    private List<Users> testUserTables = new List<Users> {
        new Users {Id = 1, Username = "John Doe", Password = HashPassword.ComputeSHA256Hash("test1234")},
        new Users {Id = 2, Username = "Jane Doe", Password = HashPassword.ComputeSHA256Hash("test12345")},
        new Users {Id = 3, Username = "", Password = HashPassword.ComputeSHA256Hash("afjkasfjask4123124jksdjfksd")}
    };

    public TestUserController(AppDbContext context)
    {
        _context = context;
        if (!_context.Users.Any())
        {
            _context.Users.AddRange(testUserTables);
            _context.SaveChanges();
        }
    }

    // simple GET-endpoint using an IEnumerable
    [HttpGet]
    public ActionResult<IEnumerable<Users>> Get()
    {
        return _context.Users.ToList();
    }

    [HttpPost]
    public IActionResult Post([FromBody] Users _testUserTable)
    {
        if (_testUserTable == null)
        {
            return BadRequest("There was an error appending data to the server!");
        }

        var obj = new Users
        {
            Id = _testUserTable.Id,
            Username = _testUserTable.Username,
            Password = HashPassword.ComputeSHA256Hash(_testUserTable.Password)
        };

        _context.Users.Add(obj);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Post), obj);
    }
}