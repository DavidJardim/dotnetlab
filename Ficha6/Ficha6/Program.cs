using Microsoft.AspNetCore.Builder;
using System.Text.Json;

var people = LoadJSONData();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();


app.MapGet("/people", () =>
{
    return Results.Ok(people);
});

app.MapGet("/people/download", () =>
{
    byte[] bytes = File.ReadAllBytes("data.json");
    return Results.File(bytes,null,"people.json");
});

app.MapPost("/people", (Person person) =>
{
    people.PersonList.Add(person);
    // $ escapes the slash {} uses string interpolation
    return Results.Created($"/people/{person.Id}", person);
});

app.MapDelete("/people/{id}", (int id) =>
{
    int removed = people.PersonList.RemoveAll(p => p.Id == id);
    if (removed == 0)
    {
        return Results.NotFound($"/people/{id}");
    }
    else
    {
        return Results.Ok(String.Format("ID: {0} was deleted", id));        
    }
});


app.MapGet("/people/{id}/{age}", (int id, int age) => {

    var person = people.PersonList.Find(p => p.Id == id);
    if (person == null)
    {
        return Results.NotFound(String.Format("ID: {0} not found", id));
    }
    else
    {
        return Results.Ok(person);
    }
});

app.MapPut("/people/{id}", (int id, Person inputPerson) => {
    var person = people.PersonList.Find(p => p.Id == id);

    if (person == null)
    {
        return Results.NotFound(String.Format("ID: {0} not found", id));
    }
    else
    {
        person.FirstName = inputPerson.FirstName;
        person.LastName = inputPerson.LastName;
        person.Age = inputPerson.Age;
        person.Profession = inputPerson.Profession;

        return Results.Json(person.Id);
    }
});

app.Run();

People LoadJSONData()
{
    var jsonData = File.ReadAllText("data.json");
    People people = JsonSerializer.Deserialize<People>(jsonData);
    return people;
}

//return new OkObjectResult(new Item { Id = 123, Name = "Hero" });