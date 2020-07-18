using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

         private IEmployeeRepository context;
         
         public EmployeeController(IEmployeeRepository _context)
        {
            context = _context;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await context.GetEmployeeList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(long id)
        {
            return await context.GetEmployee(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task Post([FromBody] Employee model)
        {
             await context.SaveEmployee(model);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task  Put(int id, [FromBody] Employee model)
        {

            await context.UpdateEmployee(id, model);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task  Delete(long id)
        {
            await context.DeleteEmployee(id);
        }
    }
}
