using AutoMapper;
using Business.Services.Abstracts;
using Core.Entities.Concretes;
using Core.Utilities.Hashing;
using Core.Utilities.Results;
using Core.Utilities.TokenOperations;
using DataAccess.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonManager(IPersonRepository personRepository,IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public IResult Create(Person person)
        {
            _personRepository.Add(person);
            int result = _personRepository.SaveChanges();
            if (result == 0)
                return new Result("Kayıt Yapılamadı!", false);
            return new Result("Kayıt Yapıldı!", true);
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(int id, Person entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Person> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult AddRefreshToken(int id,string refreshToken, DateTime expirationTime)
        {
            var person = _personRepository.Get(x => x.Id == id);
            person.RefreshToken = refreshToken;
            person.RefresTokenExpireDate = expirationTime;
            int result = _personRepository.SaveChanges();
            if (result == 0)
                return new Result("Kayıt Yapılamadı!", false);
            return new Result("Kayıt Yapıldı!", true);
        }

        public IDataResult<IEnumerable<Person>> GetAll()
        {
            var data = _personRepository.GetList();
            return new DataResult<IEnumerable<Person>>(data, true);
        }

        public Person GetByEmail(string email)
        {
            var person = _personRepository.Get(x => x.Email == email);
            return person;
        }
    }
}
