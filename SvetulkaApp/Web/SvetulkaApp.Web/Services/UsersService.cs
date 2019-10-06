using Microsoft.AspNetCore.Identity;
using SvetulkaApp.Data;
using SvetulkaApp.Data.Models;
using SvetulkaApp.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvetulkaApp.Web.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SvetulkaDbContext db;

        public UsersService(UserManager<ApplicationUser> userManager, SvetulkaDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return this.userManager.FindByNameAsync(username).GetAwaiter().GetResult();
        }
    }
}
