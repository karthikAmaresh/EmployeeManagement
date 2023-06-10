using EmployeeManagement.Commands;
using EmployeeManagement.Models;
using EmployeeManagement.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<Employee>> GetEmployees()
        {
            return await _mediator.Send(new GetEmployeeListQuery());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            if(id <= 0)
            {
                return new BadRequestResult();
            }
            var result = _mediator.Send(new GetEmployeeByIdQuery(id));
            return new OkObjectResult(result);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommand command)
        {
            var result = _mediator.Send(command);
            return new OkObjectResult(result);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee( [FromBody] UpdateEmployeeCommand command)
        {
            if(command.id <= 0)
            {
                return new BadRequestResult();
            }
            var result = _mediator.Send(command);
            return new OkObjectResult(result);
        }

        /* 

         

         

         // DELETE api/<EmployeeController>/5
         [HttpDelete("{id}")]
         public void Delete(int id)
         {
         }*/
    }
}
