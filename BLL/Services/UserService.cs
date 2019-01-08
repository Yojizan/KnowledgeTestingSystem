using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using BLL.Interfaces;
using BLL.Models;
using BLL.Infrastructure;
using DAL.Interfaces;
using DAL.Entities;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork database;

        public UserService(IUnitOfWork db)
        {
            database = db;
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(User user)
        {
            ClaimsIdentity claim = null;
            ApplicationUser foundUser = await database.UserManager.FindAsync(user.Email, user.Password);
            if(foundUser != null)
            {
                claim = await database.UserManager.CreateIdentityAsync(foundUser, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        public async Task<CreationDetails> CreateAsync(User user)
        {
            ApplicationUser newUser = await database.UserManager.FindByEmailAsync(user.Email);
            if (newUser == null)
            {
                IdentityResult result = await database.UserManager.CreateAsync(newUser, user.Password);
                if (result.Errors.Count() > 0)
                {
                    return new CreationDetails(false, result.Errors.FirstOrDefault(), "");
                }
                await database.UserManager.AddToRoleAsync(newUser.Id, user.Role);
                UserProfile userProfile = new UserProfile() { Id = newUser.Id, CompletedTests = null };
                database.UserProfilesRepository.Create(userProfile);
                await database.SaveAsync();
                return new CreationDetails(true, "Registration completed successfully", "");
            }
            else
            {
                return new CreationDetails(false, "User with this login already exist", "Email");
            }
        }

        public async Task SetInitialDataAsync(User admin, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                ApplicationRole role = await database.RoleManager.FindByNameAsync(roleName);
                if(role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await database.RoleManager.CreateAsync(role);
                }
            }
            await CreateAsync(admin);
        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}
