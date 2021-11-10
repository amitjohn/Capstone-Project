using GymUserApi.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymUserApi.Repository
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);
        bool Login(User user);
        
    }
}
