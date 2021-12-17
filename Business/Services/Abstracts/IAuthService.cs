using Business.Handlers.ViewModels;
using Core.Utilities.Results;
using Core.Utilities.TokenOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts
{
    public interface IAuthService
    {
        IResult RegisterPerson(RegisterPersonVM registerPerson);
        IDataResult<Token> LoginPerson(LoginPersonVM loginPerson);
    }
}
