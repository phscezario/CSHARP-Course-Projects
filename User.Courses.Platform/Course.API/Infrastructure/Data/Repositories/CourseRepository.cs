using Course.API.Business.Entities;
using Course.API.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.API.Infrastructure.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;

        public CourseRepository(CourseDbContext context)
        {
            _context = context;
        }

        public void Add(Courses course)
        {
            _context.Course.Add(course);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Courses> GetByUser(int userId)
        {
            return _context.Course.Include(i => i.User).Where(w => w.UserId == userId).ToList();
        }
    }
}
