using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.API.Business.Repositories
{
    public interface ICourseRepository
    {
        void Add(Entities.Courses course);
        void Commit();
        IList<Entities.Courses> GetByUser(int userId);
    }
}
