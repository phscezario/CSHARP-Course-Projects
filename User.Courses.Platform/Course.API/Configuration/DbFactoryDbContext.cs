using Course.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Course.API.Configuration
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CourseDbContext>
    {
        public CourseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Course;Trusted_Connection=True;");

            CourseDbContext context = new CourseDbContext(optionsBuilder.Options);

            return context;
        }
    }
}
