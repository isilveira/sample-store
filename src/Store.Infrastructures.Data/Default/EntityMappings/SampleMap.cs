using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Domain.Default.Samples.Entities;

namespace Store.Infrastructures.Data.Default.EntityMappings
{
    public class SampleMap : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder
                .Property<int>(p=>p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .UseIdentityColumn();

            builder
                .Property<string>("Description")
                .IsRequired(true)
                .HasColumnType("nvarchar(512)");

            builder
                .HasKey(x=>x.Id);

            builder
                .ToTable("Samples");
        }
    }
}