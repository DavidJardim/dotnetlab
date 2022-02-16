using System.Text.Json;


People people = null;// = LoadJsonData();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/people", () =>
{
    if(people == null)
    {
        return Results.NotFound("NOT FOUND");
    }
    else
        return Results.Ok(people);    
});

app.MapGet("/people/{id}", (int id) =>
{
    for (int i = 0; i < people.PersonList.Count; i++)
    {
        Person person = people.PersonList[i];
        if(person.Id == id)
        {
            return Results.Ok(person);
        }
    }

    return Results.NotFound($"ID: {id} not found!");
});


app.MapPost("/people", (Person person) =>
{
    people.PersonList.Add(person);
    return Results.Ok(person);
});


app.MapDelete("/people/{id}", (int id) =>
{
    for (int i = 0; i < people.PersonList.Count; i++)
    {
        Person person = people.PersonList[i];
        if (person.Id == id)
        {
            people.PersonList.RemoveAt(i);
            return Results.Ok(id);
        }
    }

    return Results.NotFound($"ID: {id} not found!");
});

app.MapPut("/people/{id}", (int id, Person person) => {

    Person p = people.PersonList.Find(p => p.Id == id);
    if(p == null)
    {
        return Results.NotFound($"ID: {id} not found!");
    }
    else
    {
        p.FirstName = person.FirstName;
        p.LastName = person.LastName;
        return Results.Ok(p);
    }
});



app.Run();


People LoadJsonData()
{
    var jsonData = File.ReadAllText("data.json");
    People p = JsonSerializer.Deserialize<People>(jsonData);
    return p;
}


