using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NinjectWithMvcAndWebApi.Models
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            return new List<User> {
                    new User { FirstName = "Julien", LastName = "Plée"},
                    new User { FirstName = "Jack", LastName = "Sparrow" }
                };
        }
    }
}