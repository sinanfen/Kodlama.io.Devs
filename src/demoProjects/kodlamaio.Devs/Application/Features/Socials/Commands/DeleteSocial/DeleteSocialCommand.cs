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

namespace Application.Features.Socials.Commands.DeleteSocial
{
    public class DeleteSocialCommand : IRequest<DeletedSocialDto>
    {
        public int Id { get; set; }

        public class DeleteSociaCommandHandler : IRequestHandler<DeleteSocialCommand, DeletedSocialDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialRepository _socialRepository;
            //private readonly SocialBusinessRules _socialBusinessRules;

            public DeleteSociaCommandHandler(IMapper mapper, ISocialRepository socialRepository)
            {
                _mapper = mapper;
                _socialRepository = socialRepository;
            }

            public async Task<DeletedSocialDto> Handle(DeleteSocialCommand request, CancellationToken cancellationToken)
            {
                //Social social = await _socialRepository.GetAsync(s=>s.Id==request.Id);
                //_socialBusinessRules.ProgrammingLanguageShouldBeExistWhenDeleted(social);  --iş kuralı eklediğimde çalışacak.
                Social mappedSocial = _mapper.Map<Social>(request);
                Social deletedSocial = await _socialRepository.DeleteAsync(mappedSocial);
                DeletedSocialDto deletedSocialDto = _mapper.Map<DeletedSocialDto>(deletedSocial);
                return deletedSocialDto;

            }
        }
    }
}
