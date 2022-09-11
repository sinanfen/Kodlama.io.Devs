using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Commands.DeleteSocial
{
    public class DeleteSocialCommandValidator : AbstractValidator<DeleteSocialCommand>
    {
        public DeleteSocialCommandValidator()
        {
            RuleFor(s => s.Id).NotNull();
        }
    }
}
