using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Models;

namespace SchoolSystem.Data.Map
{
    public class SchoolMap : IEntityTypeConfiguration<SchoolModel>
    {
        public void Configure(EntityTypeBuilder<SchoolModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.TeacherId);
        }
    }
}