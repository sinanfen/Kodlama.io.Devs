using Application.Features.Socials.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Queries.GetListSocial
{
    public class GetListSocialQuery : IRequest<SocialListModel>
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } = new string[1] { "admin" };

        public class GetListSocialQueryHandler : IRequestHandler<GetListSocialQuery, SocialListModel>
        {
            private readonly IMapper _mapper;
            private readonly ISocialRepository _socialRepository;

            public GetListSocialQueryHandler(IMapper mapper, ISocialRepository socialRepository)
            {
                _mapper = mapper;
                _socialRepository = socialRepository;
            }

            public async Task<SocialListModel> Handle(GetListSocialQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Social> socials = await _socialRepository
                    .GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                SocialListModel socialListModel = _mapper.Map<SocialListModel>(socials);

                return socialListModel;
            }
        }
    }
}
