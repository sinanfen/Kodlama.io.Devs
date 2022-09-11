using Application.Features.Socials.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Commands.UpdateSocial
{
    public class UpdateSocialCommand : IRequest<UpdatedSocialDto>
    {
        public int Id { get; set; }
        public string SocialUrl { get; set; }

        public class UpdateSocialCommandHandler : IRequestHandler<UpdateSocialCommand, UpdatedSocialDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialRepository _socialRepository;
            //private readonly SocialBusinessRules _socialBusinessRules;

            public UpdateSocialCommandHandler(IMapper mapper, ISocialRepository socialRepository)
            {
                _mapper = mapper;
                _socialRepository = socialRepository;
            }

            public async Task<UpdatedSocialDto> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
            {
                //Social social = await _socialRepository.GetAsync(s=>s.Id==request.Id);
                //_socialBusinessRules.ProgrammingLanguageShouldBeExistWhenDeleted(social);  --iş kuralı eklediğimde çalışacak.
                Social mappedSocial = _mapper.Map<Social>(request);
                Social updatedSocial = await _socialRepository.UpdateAsync(mappedSocial);
                UpdatedSocialDto updatedSocialDto = _mapper.Map<UpdatedSocialDto>(updatedSocial);
                return updatedSocialDto;

            }

        }
    }
}
