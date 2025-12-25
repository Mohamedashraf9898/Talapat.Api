using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talapat.Repository._Identity.DataSeed
{
    public class ApplicationIdentityContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    DisplayName = "Mohamed Ashraf",
                    Email = "mohamed.ashraf@gmail.com",
                    UserName = "mohamed.ashraf",
                    PhoneNumber = "01024144092"
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }


        }
    }
}
