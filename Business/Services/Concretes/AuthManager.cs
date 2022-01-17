using Business.Services.Abstracts;
using Core.Entities.Concretes;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using Core.Utilities.TokenOperations;
using Core.Utilities.TokenOperations.Models;
using Entities.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IPersonService _personService;
        private readonly IConfiguration _configuration;
        public AuthManager(IPersonService personService,IConfiguration configuration)
        {
            _personService = personService; 
            _configuration = configuration;
        }

        public IResult RegisterPerson(RegisterPersonDto registerPerson)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            var person = _personService.GetByEmail(registerPerson.Email);
            if (person is not null)
                return new Result("Kullanıcı zaten mevcut!", false);
            HashingHelper.CreatePasswordHash(registerPerson.Password,out passwordSalt, out passwordHash);
            person = new Person
            {
                FullName = registerPerson.FullName,
                Email = registerPerson.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,

            };
            var result = _personService.Create(person);
            if (!result.Success)
                return new Result("Kayıt Yapılamadı!", false);
            return new Result("Kayıt Yapıldı!", true);

        }

        public IDataResult<Token> LoginPerson(LoginPersonDto loginPerson)
        {
            var person = _personService.GetByEmail(loginPerson.Email);
            if (person is null)
                return new DataResult<Token>(null,"Kullanıcı bulunamadı!", false);
            if (!HashingHelper.VerifyPasswordHash(loginPerson.Password,person.PasswordSalt, person.PasswordHash))
                return new DataResult<Token>(null,"Şifre hatalı!", false);
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(person);
            _personService.AddRefreshToken(person.Id, token.RefreshToken, token.Expiration.AddMinutes(5));
            return new DataResult<Token>(token,true);
        }
    }
}
