using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechnolgy
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(t => t.Id).NotNull();
            RuleFor(t => t.Name).NotNull().NotEmpty();
            RuleFor(t => t.ProgrammingLanguageId).NotNull();
        }
    }
}
