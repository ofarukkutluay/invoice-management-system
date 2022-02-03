using Core.Utilities.Results;
using Core.Utilities.TokenOperations.Models;
using Entities.Dtos;


namespace Business.Services.Abstracts
{
    public interface IAuthService
    {
        IResult RegisterPerson(RegisterPersonDto registerPerson);
        IDataResult<Token> LoginPerson(LoginPersonDto loginPerson);
        IDataResult<PersonDto> GetPersonDtoByEmail(string email);
    }
}
