﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectWithMvcAndWebApi.Models
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}
