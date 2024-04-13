
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;


namespace Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course> GetCourseById(string id);
        Task CreateCourse(Course course);
        Task UpdateCourse(Course course);
        Task DeleteCourse(string id);
    }
}

