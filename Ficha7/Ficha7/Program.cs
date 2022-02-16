
using System.Text.Json;

Employee LoadEmployeeJSON()
{
    string text = File.ReadAllText("./JSON/employee.json");
    Employee emp = JsonSerializer.Deserialize<Employee>(text);
    return emp;
}

Employees LoadEmployeesJSON()
{
    string text = File.ReadAllText("./JSON/employees.json");
    Employees emps = JsonSerializer.Deserialize<Employees>(text);
    return emps;
}

Employee emp = LoadEmployeeJSON();
Employees employees = LoadEmployeesJSON();

Employee emp1 = new Employee()
{
    UserId = 1,
    FirstName = "Test",
    LastName = "Name",
    EmailAddress = "email",
    JobTitle = "job",
    EmployeeCode = "123",
    PhoneNumber = "98765",
    Region = "FX"
};

Employee emp2 = new Employee()
{
    UserId = 2,
    FirstName = "Test",
    LastName = "Name",
    EmailAddress = "email",
    JobTitle = "job",
    EmployeeCode = "123",
    PhoneNumber = "98765",
    Region = "FX"
};

Employee emp3 = new Employee()
{
    UserId = 3,
    FirstName = "Test",
    LastName = "Name",
    EmailAddress = "email",
    JobTitle = "job",
    EmployeeCode = "123",
    PhoneNumber = "98765",
    Region = "FX"
};


Employees emps = new Employees();

emps.EmployeesList.Add(emp1);
emps.EmployeesList.Add(emp2);
emps.EmployeesList.Add(emp3);

string jsonSingleEmp = JsonSerializer.Serialize<Employee>(emp1);
File.WriteAllText("./JSON/singleEmp.json", jsonSingleEmp);

string jsonAllEmps = JsonSerializer.Serialize<Employees>(emps);
File.WriteAllText("./JSON/allEmps.json", jsonAllEmps);


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

/// <summary>
/// List all employees
/// </summary>
app.MapGet("/employees", () =>
{
    return Results.Ok(employees.EmployeesList);
});

/// <summary>
/// Add details of a new employee
/// </summary>
app.MapPost("/employees", (Employee employee) =>
{
    if (employees.EmployeesList.Count == 0)
    {
        employee.UserId = 1;
        employees.EmployeesList.Add(employee);
    }
    else
    {
        var lastEmp = employees.EmployeesList[employees.EmployeesList.Count - 1];
        employee.UserId = lastEmp.UserId + 1;
        employees.EmployeesList.Add(employee);
    }
    return Results.Created($"/employees/{employee.UserId}", employee);
});

/// <summary>
/// Delete an existing employee
/// </summary>
app.MapDelete("/employees/{id}", (int id) =>
{
    int removed = employees.EmployeesList.RemoveAll(e => e.UserId == id);

    if (removed == 0)
    {
        return Results.NotFound(String.Format("ID: {0} not found", id));
    }
    else
    {
        return Results.Ok(String.Format("Employee with ID: {0} was deleted", id));
    }
});


/// <summary>
/// Show details of an employee by user id
/// </summary>
//https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-6.0#route-constraints
app.MapGet("/employees/{id:int}", (int id) =>
{
    Employee emp = employees.EmployeesList.Find(e => e.UserId == id);
    if (emp == null)
    {
        return Results.NotFound(String.Format("ID: {0} not found", id));
    }
    else
    {
        return Results.Ok(emp);
    }
});

/// <summary>
/// Update details of an employee
/// </summary>
app.MapPut("/employees/{id}", (int id, Employee employeeFromBody) => {
    var employee = employees.EmployeesList.Find(p => p.UserId == id);

    if (employee == null)
    {
        return Results.NotFound(String.Format("ID: {0} not found", id));
    }
    else
    {
        employee.FirstName = employeeFromBody.FirstName;
        employee.LastName = employeeFromBody.LastName;
        employee.Region = employeeFromBody.Region;
        employee.EmailAddress = employeeFromBody.EmailAddress;
        employee.EmployeeCode = employeeFromBody.EmployeeCode;
        employee.JobTitle = employeeFromBody.JobTitle;
        employee.PhoneNumber = employeeFromBody.PhoneNumber;
        return Results.Ok(employee);
    }
});


/// <summary>
/// List all employees from a region
/// </summary>
app.MapGet("/employees/{region}", (string region) =>
{
    List<Employee> emps = employees.EmployeesList.FindAll(e => e.Region == region);
    if (emps.Count == 0)
    {
        return Results.NotFound(String.Format("Region: {0} not found", region));
    }
    else
    {
        return Results.Ok(emps);
    }
});

/// <summary>
/// Download list of all employees as a JSON file
/// </summary>
app.MapGet("/employees/download", () =>
{
    // Save the current employee list to a file
    string jsonAllEmps = JsonSerializer.Serialize<Employees>(emps);
    File.WriteAllText("./JSON/allEmps.json", jsonAllEmps);

    try
    {
        byte[] bytes = File.ReadAllBytes("./JSON/allEmps.json");
        return Results.File(bytes, null, "employees.json");
    }
    catch (FileNotFoundException e)
    {
        return Results.NotFound(e.Message);
    }   
});


app.Run();