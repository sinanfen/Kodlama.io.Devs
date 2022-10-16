using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules 
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimShouldNotDuplicatedWhenInserted(string role)
        {
            var result = await _operationClaimRepository.GetAsync(o => o.Name.ToLower() == role.ToLower());

            if (result is not null) throw new BusinessException("This role already exists.");
        }

        public void OperationClaimShouldBeExistToDelete(OperationClaim operationClaim)
        {
            if (operationClaim is null) throw new BusinessException("This role does not exist.");
        }

        public async Task OperationClaimNameCanNotBeDuplicatedWhenUpdated(int id, string name)
        {
            OperationClaim? getByNameOperationClaimResult = await _operationClaimRepository.GetAsync(oc => oc.Id != id && oc.Name == name);
            if (getByNameOperationClaimResult != null) throw new BusinessException("This Operation Claim name already exists.");
        }
    }
}
