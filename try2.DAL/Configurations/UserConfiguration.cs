using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using try2.Domain.Entities;

namespace try2.DAL.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Login).IsRequired().HasMaxLength(16);

            builder.Property(e => e.Email).IsRequired().HasMaxLength(20);
        }

    }
}
