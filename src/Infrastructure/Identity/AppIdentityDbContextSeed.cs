using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(AppIdentityDbContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            // veritabanı yoksa oluştur ve migration'ları yap
            await db.Database.MigrateAsync();

            // Admin rolü yoksa oluştur
            // Adını sabitlerden al
            if (!await roleManager.RoleExistsAsync(AuthorizationConstants.Roles.ADMINISTRATOR))
            {
                await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATOR));
            }

            // Admin kullanıcısı yoksa oluştur
            // Emaili doğrulanmış olarak belirt, bilgileri sabitlerden al
            // Admin rolünü bu kullanıcıya ata
            if (!await userManager.Users.AnyAsync(u => u.Email == AuthorizationConstants.DEFAULT_ADMIN_USER))
            {
                var user = new ApplicationUser()
                {
                    UserName = AuthorizationConstants.DEFAULT_ADMIN_USER,
                    Email = AuthorizationConstants.DEFAULT_ADMIN_USER,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, AuthorizationConstants.DEFAULT_PASSWORD);
                await userManager.AddToRoleAsync(user, AuthorizationConstants.Roles.ADMINISTRATOR);
            }

            // Aynı şekilde demo kullanıcısı yoksa oluştur ve bilgileri sabitlerden al
            if (!await userManager.Users.AnyAsync(u => u.Email == AuthorizationConstants.DEFAULT_DEMO_USER))
            {
                var user = new ApplicationUser()
                {
                    UserName = AuthorizationConstants.DEFAULT_DEMO_USER,
                    Email = AuthorizationConstants.DEFAULT_DEMO_USER,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, AuthorizationConstants.DEFAULT_PASSWORD);
            }

        }
    }
}
