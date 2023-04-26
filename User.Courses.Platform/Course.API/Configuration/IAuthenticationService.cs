using Course.API.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.API.Configuration
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserViewModelOutput userViewModelOutput);
    }
}
