using Ficha10;

public class Employees : IEmployees
{
    private List<Employee> employeesList;
    List<Employee> IEmployees.EmployeesList
    {
        get => employeesList;
        set => employeesList = value;
    }

    public Employees()
    {
        employeesList = JsonLoader.LoadEmployeesJSON();
    }     
}