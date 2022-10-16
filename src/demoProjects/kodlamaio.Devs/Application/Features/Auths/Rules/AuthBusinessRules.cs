using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Auths.Constants;
using Core.Security.Hashing;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail already exists.");
        }

        public Task UserShouldBeExists(Core.Security.Entities.User? user)
        {
            if (user == null) throw new BusinessException(Messages.UserShouldBeExists);
            return Task.CompletedTask;
        }

        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            Core.Security.Entities.User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException(Messages.PasswordShouldBeMatch);
        }
    }
}
