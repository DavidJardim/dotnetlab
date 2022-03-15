using Ficha10.Models;

public class Employee
{
    public int UserId { get; set; }
    public string JobTitle { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string EmployeeCode { get; set; }

    public string Region { get; set; }

    public string PhoneNumber { get; set; }

    public string EmailAddress { get; set; }

    public string FullName()
    {
        return FirstName + " " + LastName;
    }

}