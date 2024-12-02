using Microsoft.EntityFrameworkCore;

namespace MovieAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Logging.AddConsole();
            // Below is test code on lines 21 to 27, do not publish these to production!
            // CORS user-spesifications, this is done to support CORS on Localhost on the same server when testing the monorepos Frontend, as ASP.NET by default disallows same-site origin fetch requests from the frontend.
            // See the comments above, and do not push this code to production!
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("Count-Disposition");
                });
            });
            builder.Services.AddLogging();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseDefaultFiles();

            app.UseStaticFiles();
            // https redirection, currently not working
            // this must be fixed before code can be pushed to production!
            app.UseHttpsRedirection();
            app.UseAuthorization();
            // allowing CORS, test code only! Do not push to production!
            app.UseCors("AllowAll");
            app.MapControllers();
            app.Run();
        }
    }
}
