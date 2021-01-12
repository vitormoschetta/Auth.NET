using Domain;
using Domain.Entities;
using Infra.Context.Maps;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }                            

        public DbSet<User> User { get; set; }                  

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {           
            options.UseSqlServer(AppSettings.ConnectionString);                                                   
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());                                            
        }
    }
}