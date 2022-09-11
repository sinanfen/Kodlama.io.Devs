using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Rules
{
    public class SocialBusinessRules
    {
        private readonly ISocialRepository _socialRepository;

        public SocialBusinessRules(ISocialRepository socialRepository)
        {
            _socialRepository = socialRepository;
        }

        public async Task SocialGitHubLinkCanNotBeDuplicatedWhenInserted(int userId)
        {
            Social result = await _socialRepository.GetAsync(s=>s.DeveloperId==userId);
            if (result != null) throw new BusinessException("There is already a GitHub link.");
        }

      
    }
}
