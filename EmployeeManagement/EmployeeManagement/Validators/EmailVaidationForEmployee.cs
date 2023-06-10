using EmployeeManagement.Commands;
using FluentValidation;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EmployeeManagement.Validators
{
    public class EmployeeEmailVaidator : AbstractValidator<AddEmployeeCommand>
    {
         public EmployeeEmailVaidator()
        {
            RuleFor(x => x.email).Must(ValidateEmail.IsValidEmail).WithMessage("Email is invalid");
        }

    }

    public class UpdateEmployeeEmailVaidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeEmailVaidator()
        {
            RuleFor(x => x.email).Must(ValidateEmail.IsValidEmail).WithMessage("Email is invalid");
        }
     }
}
