﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Domain.Contexts.Store.Entities.Customers.Entity;
using System;

namespace Store.Infrastructures.Data.Contexts.Store.EntityMappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder
                .Property<string>("Name")
                .HasColumnType("nvarchar(128)");

            builder
                .Property<string>("Email")
                .HasColumnType("nvarchar(128)");

            builder
                .Property<DateTime>("RegisteredAt")
                .HasColumnType("datetime");

            builder
                .HasKey("Id");

            builder
                .HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            builder
                .ToTable("Customers");
        }
    }
}
