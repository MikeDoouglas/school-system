using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Models;

namespace SchoolSystem.Data.Map
{
    public class TeacherMap : IEntityTypeConfiguration<TeacherModel>
    {
        public void Configure(EntityTypeBuilder<TeacherModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
        }
    }
}