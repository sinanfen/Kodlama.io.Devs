using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
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

        public async Task SocialGitHubLinkCanNotBeDuplicatedWhenInserted(string socialUrl)
        {
            IPaginate<Social> result = await _socialRepository.GetListAsync(s => s.SocialUrl == socialUrl);
            if (result.Items.Any()) throw new BusinessException("Social Url already exist.");
        }

        public void SocialUrlShouldExistWhenRequested(Social social)
        {
            if (social == null) throw new BusinessException("Requested Social Url does not exist.");
        }


    }
}
