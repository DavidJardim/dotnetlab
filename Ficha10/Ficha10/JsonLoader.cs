using System.Text.Json;

namespace Ficha10
{
    public class JsonLoader
    {       
        public static List<Employee>? LoadEmployeesJSON()
        {
            string text = System.IO.File.ReadAllText("./JSON/employees.json");
            return JsonSerializer.Deserialize<List<Employee>>(text);            
        }

    }
}



