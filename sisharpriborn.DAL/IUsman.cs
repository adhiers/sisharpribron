using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisharpriborn.DAL
{
    public interface IUsman
    {
        //registration asp identity
        Task<bool> RegisterAsync(string email, string password);
        //login asp identity
        Task<IdentityUser> LoginAsync(string email, string password);
        //create role
        Task<bool> CreateRoleAsync(string roleName);
        //add user to role
        Task<bool> AddUserToRoleAsync(string email, string roleName);
    }
}
