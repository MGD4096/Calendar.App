using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User.Domain.Users;

namespace User.Infrastructure.Domain.Calendars
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User.Domain.Users.User>
    {
        public void Configure(EntityTypeBuilder<User.Domain.Users.User> builder)
        {
            builder.ToTable("user", "dbo");
            builder.HasKey(x => x.UserId);
            builder.Property<UserId>(x => x.UserId).HasColumnName("user_id");
            builder.Property<string>(x => x.UserName).HasColumnName("user_name");
            builder.Property<string>(x => x.ForName).HasColumnName("for_name");
            builder.Property<string>(x => x.SurName).HasColumnName("sur_name");
            builder.Property<string>(x => x.Password).HasColumnName("password");
        }
    }
}
