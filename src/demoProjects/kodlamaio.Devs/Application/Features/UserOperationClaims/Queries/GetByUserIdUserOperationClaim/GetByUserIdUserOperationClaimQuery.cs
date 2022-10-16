using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetByUserIdUserOperationClaim
{
    public class GetByUserIdUserOperationClaimQuery : IRequest<GetByUserIdUserOperationClaimDto>
    {
        public int UserId { get; set; }

        public class GetByUserIdUserOperationClaimQueryHandler : IRequestHandler<GetByUserIdUserOperationClaimQuery, GetByUserIdUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public GetByUserIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<GetByUserIdUserOperationClaimDto> Handle(GetByUserIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                var userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                    c => c.UserId == request.UserId,
                    include: m =>
                        m.Include(c => c.User)
                        .Include(c => c.OperationClaim));

                GetByUserIdUserOperationClaimDto getByUserIdUserOperationClaimDto = new()
                {
                    Email = userOperationClaims.Items.FirstOrDefault(c => c.User.Id == request.UserId).User.Email,
                    ClaimsName = userOperationClaims.Items.Select(c => c.OperationClaim.Name)
                };
                return getByUserIdUserOperationClaimDto;
            }
        }
    }
}
