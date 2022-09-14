using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Commands.UpdateSocial
{
    public class UpdateSocialCommandValidator : AbstractValidator<UpdateSocialCommand>
    {
        public UpdateSocialCommandValidator()
        {
            RuleFor(s => s.Id).NotNull();
            RuleFor(s => s.DeveloperId).NotNull();
            RuleFor(s => s.SocialUrl).NotNull();

        }
    }
}
