﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Udemy.App.Entities;

namespace Udemy.App.DataAccess.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasIndex(x => new
            {
                x.AppRoleId,
                x.AppUserId
            }).IsUnique();

            builder.HasOne(x => x.AppRole).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppRoleId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppUserId);
        }
    }
}