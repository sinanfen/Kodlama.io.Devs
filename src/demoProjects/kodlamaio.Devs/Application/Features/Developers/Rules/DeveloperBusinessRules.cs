using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Developers.Rules
{
    public class DeveloperBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public DeveloperBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void UserShouldExist(User user)
        {
            if (user == null) throw new BusinessException("Uer does not exist.");
        }

        public void UserCredentialsMustMatch(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException("User Credentials are incorrect.");
        }

        public async Task EmailCanNotBeDuplicatedWhenInserted(string email)
        {
            var result = await _userRepository.GetAsync(u => u.Email.ToLower().Equals(email.ToLower()));
            if (result != null) throw new BusinessException("This email address is already registered.");
        }
    }
}
