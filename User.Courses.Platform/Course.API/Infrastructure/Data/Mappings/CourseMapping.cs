using Course.API.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.API.Infrastructure.Data.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Courses>
    {
        public void Configure(EntityTypeBuilder<Courses> builder)
        {
            builder.ToTable("TB_COURSE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name);
            builder.Property(p => p.Description);
            builder.HasOne(p => p.User)
                .WithMany().HasForeignKey(fk => fk.UserId);
        }
    }
}
