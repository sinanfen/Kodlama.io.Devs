﻿using Application.Features.Developers.Dtos;
using Application.Features.Developers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Commands.LoginDeveloper
{
    public class LoginDeveloperCommand : UserForLoginDto, IRequest<TokenDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly DeveloperBusinessRules _developerBusinessRules;

        public LoginDeveloperCommand(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, DeveloperBusinessRules developerBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _developerBusinessRules = developerBusinessRules;
        }

        public async Task<TokenDto> Handle(LoginDeveloperCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(
                u => u.Email.ToLower() == request.Email.ToLower(),
                include: m => m.Include(c => c.UserOperationClaims).ThenInclude(x => x.OperationClaim));

            List<OperationClaim> operationClaims = new List<OperationClaim>() { };

            foreach (var userOperationClaim in user.UserOperationClaims)
            {
                operationClaims.Add(userOperationClaim.OperationClaim);
            }

            _developerBusinessRules.UserShouldExist(user);
            _developerBusinessRules.UserCredentialsMustMatch(request.Password, user.PasswordHash, user.PasswordSalt);

            AccessToken token = _tokenHelper.CreateToken(user, operationClaims);

            TokenDto tokenDto = _mapper.Map<TokenDto>(token);

            return tokenDto;
        }
    }
}
