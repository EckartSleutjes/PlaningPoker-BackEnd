﻿using Microsoft.IdentityModel.Tokens;
using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;
using PlaningPoker.Domain.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PlaningPoker.Application.Service
{
    public class AuthenticationService(IAuthenticationRepository authenticationRepository) : IAuthenticationService
    {
        private readonly string _key = "=-erIs1|L9zrvXqN9}5bdI{OXS1UZa^?X{/Re-/v>#RqN9}5bdI{OerIs1|L9zrvXqN9>#RqN9}5bdI{OerIs1|L9zrv";
        private readonly IAuthenticationRepository _authenticationRepository = authenticationRepository;

        public async Task<UserDto?> FindAsync(Guid id)
        {
            var entity = await _authenticationRepository.FindByIdAsync(id);
            return entity == null ? null : new UserDto(entity);
        }

        public async Task<Guid?> AddAsync(AddOrUpdateUserDto user)
        {
            var userExist = await _authenticationRepository.FindByEmailAsync(user.Email);
            if (userExist != null) return null;
            using var hmac = new HMACSHA512();
            var passwordSalt = hmac.Key;
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            var entity = new User(user.Username, user.Email, passwordHash, passwordSalt);
            await _authenticationRepository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<AddOrUpdateUserDto?> UpdateAsync(AddOrUpdateUserDto user, Guid id)
        {
            var entity = await _authenticationRepository.FindByIdAsync(id);
            if (entity == null) return null;
            using var hmac = new HMACSHA512();
            var passwordSalt = hmac.Key;
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            entity.Name = user.Username;
            entity.Email = user.Email;
            await _authenticationRepository.UpdateAsync(entity);
            return user;
        }

        public async Task<Guid?> DeleteAsync(Guid id)
        {
            var entity = await _authenticationRepository.FindByIdAsync(id);
            if (entity == null) return null;
            entity.Delete();
            await _authenticationRepository.UpdateAsync(entity);
            return id;
        }

        public async Task<string?> LoginAsync(LoginDto request)
        {
            User? user;
            if (Guid.TryParse(request.Login, null, out Guid result))
                user = await _authenticationRepository.FindByIdAsync(result);
            else
                user = await _authenticationRepository.FindByEmailAsync(request.Login);
            if (user == null) return null;
            if (!VerifyPasswordHash(request.Password, user)) return null;
            return CreateToken(user);
        }
        #region private_methods
        private string CreateToken(User user)
        {
            List<Claim> claims =
            [
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            ];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private static bool VerifyPasswordHash(string passwordRequest, User user)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordRequest));
            return computedHash.SequenceEqual(user.PasswordHash);
        }
    }
    #endregion
}
