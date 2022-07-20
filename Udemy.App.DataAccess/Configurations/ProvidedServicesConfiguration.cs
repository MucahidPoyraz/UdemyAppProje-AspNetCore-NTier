using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Udemy.App.Entities;

namespace Udemy.App.DataAccess.Configurations
{
    public class ProvidedServicesConfiguration : IEntityTypeConfiguration<ProvidedServices>
    {
        public void Configure(EntityTypeBuilder<ProvidedServices> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(300).IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(300).IsRequired();
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
        }
    }
}
