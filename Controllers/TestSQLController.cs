[ApiController]
[Route("api/[controller]")]
public class TestSQLController : ControllerBase
{
    private readonly MovieContext _context;

    public MoviesController(MovieContext context)
    {
        _context = context;

        // If the database is empty, we can append standard data
        if (!_context.Movies.Any())
        {
            _context.Movies.Add(new Movie { Title = "The Matrix", Director = "Wachowski Brothers", ReleaseYear = 1999 });
            _context.Movies.Add(new Movie { Title = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010 });
            _context.SaveChanges();
        }
    }

    // Handle the GET request
    // GET: api/movies
    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetMovies()
    {
        return _context.Movies.ToList();
    }

    // Handle the POST request
    [HttpPost]
    public ActionResult<Movie> PostMovie(Movie movie)
    {
       _context.Movies.Add(movie);
       _context.SaveChanges();

         return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
    }

    // Validate the model state
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
}
