using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator() 
        {
            RuleFor(c => c.Content).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.IssueId).NotEmpty();
        }
    }
   
}
