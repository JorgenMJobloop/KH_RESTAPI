using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


[Route("api/movies")]
public class _MoviesController : ControllerBase
{
    private readonly AppDbContext _context;

    public _MoviesController(AppDbContext context)
    {
        _context = context;

        // If the database is empty, we append standard data
        if (!_context.Movies.Any())
        {
            _context.Movies.Add(new Movies { Title = "The Matrix", Director = "Wachowski Brothers", ReleaseYear = 1999 });
            _context.Movies.Add(new Movies { Title = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010 });
            _context.SaveChanges();
        }
    }

    // Handle the GET request
    // GET: api/movies
    [HttpGet]
    public ActionResult<IEnumerable<Movies>> GetMovies()
    {
        return _context.Movies.ToList();
    }

    // Handle the POST request
    [HttpPost]
    public IActionResult Post([FromBody] Movies movies)
    {
        if (movies == null)
        {
            return BadRequest("Movie is null!");
        }

        _context.Add(movies);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Post), new { id = movies.Id, title = movies.Title, director = movies.Director, releaseYear = movies.ReleaseYear }, movies);
    }
}
