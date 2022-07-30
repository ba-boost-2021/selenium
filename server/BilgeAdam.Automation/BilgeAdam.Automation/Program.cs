using BilgeAdam.Automation.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<NorthwindDbContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Mevlana", policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("Mevlana");
app.UseAuthorization();
app.MapControllers();
app.Run();
