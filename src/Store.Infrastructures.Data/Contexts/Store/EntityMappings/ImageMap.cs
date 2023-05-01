﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Domain.Contexts.Store.Entities.Images.Entity;

namespace Store.Infrastructures.Data.Contexts.Store.EntityMappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder
                .Property<string>("Url")
                .HasColumnType("nvarchar(512)");

            builder
                .Property<string>("MimeType")
                .HasColumnType("nvarchar(32)");

            builder
                .Property<int>("ProductId")
                .HasColumnType("int");

            builder
                .HasKey("Id");

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProductId);

            builder
                .ToTable("Images");
        }
    }
}
