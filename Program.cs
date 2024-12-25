using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext")));
}
else
{
    builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMovieContext")));
}
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
