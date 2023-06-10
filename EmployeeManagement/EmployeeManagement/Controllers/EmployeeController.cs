using EmployeeManagement.Commands;
using EmployeeManagement.Models;
using EmployeeManagement.Queries;
using EmployeeManagement.Validators;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

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
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommand command)
        {
            var validate = new EmployeeEmailVaidator();
            var validationResult = validate.Validate(command);
            if (validationResult.IsValid)
            {
                if (command.company != null
                && command.email != null)
                {
                    var address = new System.Net.Mail.MailAddress(command.email);
                    var emailDomain = address.Host;

                    var isDomainExists = emailDomain.Equals(command.company + ".com", StringComparison.OrdinalIgnoreCase);
                    if (!isDomainExists)
                    {
                        ModelState.AddModelError(nameof(Employee.email), "please provide email provided by company domain!");
                    }

                }
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                var result = _mediator.Send(command);
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(validationResult.Errors.Select(x => x.ErrorMessage));
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> UpdateEmployee( [FromBody] UpdateEmployeeCommand command)
        {

            var validate = new UpdateEmployeeEmailVaidator();
            var validationResult = validate.Validate(command);
            if (validationResult.IsValid)
            {
                if (command.company != null
                && command.email != null)
                {
                    var address = new System.Net.Mail.MailAddress(command.email);
                    var emailDomain = address.Host;

                    var isDomainExists = emailDomain.Equals(command.company + ".com", StringComparison.OrdinalIgnoreCase);
                    if (!isDomainExists)
                    {
                        ModelState.AddModelError(nameof(Employee.email), "please provide email provided by company domain!");
                    }

                }
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }
                if (command.id <= 0)
                {
                    return new BadRequestResult();
                }
                var result = _mediator.Send(command);
                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(validationResult.Errors.Select(x => x.ErrorMessage));
            } 
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateEmployeeExistance))]

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            
                var result = _mediator.Send(new DeleteEmployeeById(id));
                return new OkObjectResult(result);
        }
    }
}
