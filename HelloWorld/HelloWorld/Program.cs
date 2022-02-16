var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/", () =>
{
    return "Hello World";
});

app.MapGet("/name", () =>
{
    return "David";
});

app.Run();