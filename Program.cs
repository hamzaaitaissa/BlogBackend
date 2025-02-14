using blogfolio.Data;
using blogfolio.Mapping;
using blogfolio.Repositories;
using blogfolio.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BlogfolioContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true; // Optional: for better readability
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

}); ;
// Register AutoMapper and scan for profiles in the current assembly
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
