using System;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace Infra.Context
{
    public static class InitializeData
    {
        public static void InitializeUsers(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.User.Any())  // <-- Se já possui dados, não prossegue
                    return;

                // Admin
                var user = new User("admin", "admin@gmail.com", "123456", "admin", true, true);
                var salt = SaltGenerator.Generate();
                var hash = HashGenerator.Generate(user.Password, salt);
                user.AddHash(hash, Convert.ToBase64String(salt));
                context.Add(user);
                context.SaveChanges();

                // User 
                user = new User("user", "user@gmail.com", "123456", "user", true, true);
                salt = SaltGenerator.Generate();
                hash = HashGenerator.Generate(user.Password, salt);
                user.AddHash(hash, Convert.ToBase64String(salt));
                context.Add(user);
                context.SaveChanges();           
            }
        }       

    }
}