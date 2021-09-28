using BookSharing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.Services
{
    public interface IAuthenticateService
    {
        User Authenticate(string UserName, string Password);
    }
}
