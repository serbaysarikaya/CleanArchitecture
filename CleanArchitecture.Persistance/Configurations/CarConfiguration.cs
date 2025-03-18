using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistance.Configurations
{
    public sealed class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("TBLCars");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
