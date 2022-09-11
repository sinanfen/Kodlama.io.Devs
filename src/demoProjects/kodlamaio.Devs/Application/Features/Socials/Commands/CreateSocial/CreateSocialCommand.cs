using Application.Features.Socials.Dtos;
using Application.Features.Socials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Commands.CreateSocial
{
    public class CreateSocialCommand : IRequest<CreatedSocialDto>
    {
        public int DeveloperId { get; set; }
        public string SocialUrl { get; set; }

        public class CreateSocialCommandHandler : IRequestHandler<CreateSocialCommand, CreatedSocialDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialRepository _socialRepository;
            private readonly SocialBusinessRules _socialBusinessRules;

            public CreateSocialCommandHandler(IMapper mapper, ISocialRepository socialRepository, SocialBusinessRules socialBusinessRules)
            {
                _mapper = mapper;
                _socialRepository = socialRepository;
                _socialBusinessRules = socialBusinessRules;
            }

            public async Task<CreatedSocialDto> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
            {
                await _socialBusinessRules.SocialGitHubLinkCanNotBeDuplicatedWhenInserted(request.DeveloperId);
                Social mappedSocial = _mapper.Map<Social>(request);
                Social createdSocial = await _socialRepository.AddAsync(mappedSocial);
                CreatedSocialDto createdSocialDto = _mapper.Map<CreatedSocialDto>(createdSocial);
                return createdSocialDto;
            }
        }
    }
}
