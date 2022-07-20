﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Udemy.App.Entities;

namespace Udemy.App.DataAccess.Configurations
{
    public class AdvertisementAppUserConfiguration : IEntityTypeConfiguration<AdvertisementAppUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUser> builder)
        {
            builder.HasIndex(x => new
            {
                x.AddvertisementId,
                x.AppUserId
            }).IsUnique();

            builder.Property(x => x.CvPath).HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.Advertisement).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AddvertisementId);

            builder.HasOne(x => x.AppUser).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.AdvertisementAppUserStatus).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AdvertisementAppUserStatusId);

            builder.HasOne(x => x.MilitaryStatus).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x=>x.MilitaryStatusId);
        }
    }
}
