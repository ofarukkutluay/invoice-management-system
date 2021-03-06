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
using Entities.Dtos;

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
            if (_personRepository.GetCount()==0)
            {
                person.OperationClaim = OperationClaims.Admin;
            }
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
            Person person = _personRepository.Get(x => x.Id == id);
            if (person is null)
                return new Result("Kullanıcı bulunamadı", false);
            person.Email = entity.Email==default ? person.Email : entity.Email;
            person.CitizenId = entity.CitizenId == default ? person.CitizenId : entity.CitizenId;
            person.FullName = entity.FullName == default ? person.FullName : entity.FullName;
            person.MobileNumber = entity.MobileNumber == default ? person.MobileNumber : entity.MobileNumber;
            person.IsActive = entity.IsActive == default ? person.IsActive : entity.IsActive;
            var result = _personRepository.SaveChanges();
            if (result == 0)
                return new Result("Güncelleme Yapılamadı!", false);
            return new Result("Güncelleme Yapıldı!", true);
        }

        public IDataResult<Person> GetById(int id)
        {
            Person person = _personRepository.Get(x => x.Id == id);
            if (person is null)
                return new DataResult<Person>(null, "Kullanıcı bulunamadı!", false);
            return new DataResult<Person>(person, true);
        }

        public IDataResult<PersonDto> GetByIdPerson(int id)
        {
            Person person = _personRepository.Get(x => x.Id == id);
            if (person is null)
                return new DataResult<PersonDto>(null, "Kullanıcı bulunamadı!", false);
            PersonDto rtnObj = _mapper.Map<PersonDto>(person);
            return new DataResult<PersonDto>(rtnObj, true);
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

        public IDataResult<Person> GetByEmail(string email)
        {
            Person person = _personRepository.Get(x => x.Email == email);
            if (person is null)
                return new DataResult<Person>(null, "Kullanıcı bulunamadı!", false);
            return new DataResult<Person>(person,true);
        }

        public IDataResult<PersonDto> GetByEmailPerson(string email)
        {
            Person person = _personRepository.Get(x => x.Email == email);
            if (person is null)
                return new DataResult<PersonDto>(null, "Kullanıcı bulunamadı!", false);
            PersonDto rtnObj = _mapper.Map<PersonDto>(person);
            return new DataResult<PersonDto>(rtnObj, true);
        }

        public IDataResult<IEnumerable<PersonDto>> GetAllPerson()
        {
            var data = _personRepository.GetList();
            var rtnObj = _mapper.Map<IEnumerable<PersonDto>>(data);
            return new DataResult<IEnumerable<PersonDto>>(rtnObj, true);
        }
    }
}
