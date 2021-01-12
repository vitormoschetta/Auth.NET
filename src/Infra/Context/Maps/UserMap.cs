using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.ToTable("UserAuth");      

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)");                 

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(44)
                .HasColumnType("char(44)");

            builder.Property(x => x.Salt)
                .IsRequired()
                .HasMaxLength(24)
                .HasColumnType("char(24)");

            builder.HasKey(x => x.Username);
        }
    }
}