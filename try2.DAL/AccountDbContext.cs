using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using try2.DAL.Configurations;
using try2.Domain.Entities;
using try2.Domain.Models.Entities;


namespace try2.DAL
{
    public class AccountDbContext :DbContext
    {

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<User> Users { get; set; }


        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        }



    }
}
