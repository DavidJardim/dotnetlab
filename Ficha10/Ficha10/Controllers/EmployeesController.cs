using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ficha10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployees employees;

        public EmployeesController(IEmployees employees)
        {
            this.employees = employees;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees.EmployeesList;
        }

        [HttpPost(Name = "PostEmployee")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee != null)
            {
                employees.EmployeesList.Add(employee);
                return CreatedAtRoute("GetById", new { id = employee.UserId }, employee);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Employee? emp = employees.EmployeesList.Find(e => e.UserId == id);

            if (emp == null)
            {
                return NotFound($"ID: {id} not found!");
            }
            else
            {
                return Ok(emp);
            }
        }

        [HttpGet("region/{region}", Name = "GetByRegion")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByRegion(string region)
        {
            Employee? emp = employees.EmployeesList.Find(e => e.Region == region);

            if (emp == null)
            {
                return NotFound($"region: {region} not found!");
            }
            else
            {
                return Ok(emp);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {


            return Ok();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            return Ok();
        }



        [HttpGet("download", Name = "GetDownload")]
        public IActionResult GetDownload()
        {
            // Save the current employee list to a file
            string jsonAllEmps = JsonSerializer.Serialize<IEmployees>(employees);
            System.IO.File.WriteAllText("./JSON/allEmps.json", jsonAllEmps);
            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes("./JSON/allEmps.json");
                return File(bytes, "application/json", "employees.json");
            }
            catch (FileNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
