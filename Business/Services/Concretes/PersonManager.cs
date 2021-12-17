using AutoMapper;
using Business.Handlers.ViewModels;
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

        public IResult Add(Person person)
        {
            _personRepository.Add(person);
            int result = _personRepository.SaveChanges();
            if (result == 0)
                return new Result("Kayıt Yapılamadı!", false);
            return new Result("Kayıt Yapıldı!", true);
        }

        public IDataResult<List<GetPersonsVM>> GetAll()
        {
            var data = _personRepository.GetList().ToList();
            var returnObj = _mapper.Map<List<GetPersonsVM>>(data);
            return new DataResult<List<GetPersonsVM>>(returnObj, true);
        }

        

        public Person GetByEmail(string email)
        {
            var person = _personRepository.Get(x => x.Email == email);
            return person;
        }
    }
}
