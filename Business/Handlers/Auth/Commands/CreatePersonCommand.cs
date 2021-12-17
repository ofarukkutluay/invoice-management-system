using Business.Handlers.ViewModels;
using Core.Entities.Concretes;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Auth.Commands
{
    public class CreatePersonCommand
    {
        public RegisterPersonVM Model;
        private readonly IPersonRepository _personRepository;
        public CreatePersonCommand(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IResult Handle()
        {
            byte[] passwordHash;
            var person = _personRepository.Get(x => x.Email == Model.Email);
            if (person is not null)
                return new Result("Kullanıcı zaten mevcut!", false);
            HashingHelper.CreatePasswordHash(Model.Password, out passwordHash);
            person = new Person
            {
                FullName = Model.FullName,
                Email = Model.Email,
                PasswordHash = passwordHash,
            };
            _personRepository.Add(person);
            int result = _personRepository.SaveChanges();
            if (result == 0)
                return new Result("Kayıt Yapılamadı!", false);
            return new Result("Kayıt Yapıldı!", true);

        }


    }

}
