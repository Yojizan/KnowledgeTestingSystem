using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Infrastructure;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<CreationDetails> CreateAsync(User user);
        Task<ClaimsIdentity> AuthenticateAsync(User user);
        Task SetInitialDataAsync(User admin, List<string> roles);
    }
}
