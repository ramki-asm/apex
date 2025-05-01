﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APEX.Services.Interfaces
{
    public interface IPasswordHasher
    {
        (string Hash, string Salt) CreatePasswordHash(string password);
        bool VerifyPassword(string password, string hash, string salt);
    }
}
