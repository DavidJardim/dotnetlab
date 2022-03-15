using Ficha9;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCustomMiddleware();


/*
app.Use(async (context, next) =>
{
    // Do work that doesn't write to the Response.
    Debug.WriteLine("BEFORE FIRST MIDDLEWARE");    
    await next.Invoke();
    Debug.WriteLine("AFTER FIRST MIDDLEWARE");
    // Do logging or other work that doesn't write to the Response.
});



app.Use(async (context, next) =>
{
    // Do work that doesn't write to the Response.
    Debug.WriteLine("BEFORE SECOND MIDDLEWARE");
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
    Debug.WriteLine("AFTER SECOND MIDDLEWARE");
});*/

app.MapGet("/weatherforecast/{region}", (string region) =>
{
    Debug.WriteLine("REGION");
    return Results.Ok("REGION");
})
.WithName("GetWeatherForecastRegion");

app.MapGet("/weatherforecast/{id:int}", (HttpContext context, int id) =>
{
    return Results.Ok("ID");
})
.WithName("GetWeatherForecastId");


app.UseCustomMiddleware();

app.Run();
