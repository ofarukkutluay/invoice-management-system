using Business.Handlers.ViewModels;
using Business.Services.Abstracts;
using Core.Entities.Concretes;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using Core.Utilities.TokenOperations;
using Core.Utilities.TokenOperations.Models;
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

        public IResult RegisterPerson(RegisterPersonVM registerPerson)
        {
            byte[] passwordHash;
            var person = _personService.GetByEmail(registerPerson.Email);
            if (person is not null)
                return new Result("Kullanıcı zaten mevcut!", false);
            HashingHelper.CreatePasswordHash(registerPerson.Password, out passwordHash);
            person = new Person
            {
                FullName = registerPerson.FullName,
                Email = registerPerson.Email,
                PasswordHash = passwordHash,
            };
            var result = _personService.Add(person);
            if (!result.Success)
                return new Result("Kayıt Yapılamadı!", false);
            return new Result("Kayıt Yapıldı!", true);

        }

        public IDataResult<Token> LoginPerson(LoginPersonVM loginPerson)
        {
            var person = _personService.GetByEmail(loginPerson.Email);
            if (person is null)
                return new DataResult<Token>(null,"Kullanıcı bulunamadı!", false);
            if (!HashingHelper.VerifyPasswordHash(loginPerson.Password, person.PasswordHash))
                return new DataResult<Token>(null,"Şifre hatalı!", false);
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(person);

            return new DataResult<Token>(token,true);


        }
    }
}
