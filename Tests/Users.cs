public class Users
{
    public required int Id { get; set; }

    public required string Username { get; set; }
    /// <summary>
    /// This needs to be first passed to our HashPassword class, then we can update the value of the field.
    /// </summary>
    public required string Password { get; set; }
}