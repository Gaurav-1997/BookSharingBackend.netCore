using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.Models
{
    public class UserWithToken: User
    {
        //private readonly User _user;
        public UserWithToken(User user)
        {
            this.UserId = user.UserId;
            this.UserName = user.UserName;
            this.UserPassword = user.UserPassword;
            this.UserEmail = user.UserEmail;
        }
    }
}
