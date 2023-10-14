using Crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(new List<Employee>());
        }

        [HttpPost]
        public ActionResult<bool>Add(Employee employee) 
        {
            return Ok(true);
        }

        [HttpPut("{id:int}")]
        public ActionResult<bool>Edit(int id, [FromBody] Employee employee)
        {
            return Ok(true);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(true);
        }

        [HttpGet("{id:int}")]
        public ActionResult<bool> Find(int id)
        {
            return Ok(new Employee());
        }

        [HttpGet("Filter")]
        public ActionResult<List<Employee>> Filter(

            [FromQuery] string key,
            [FromQuery] string oper,
            [FromQuery] string value)
        {
            return Ok(new List<Employee>());
        }
    }
}