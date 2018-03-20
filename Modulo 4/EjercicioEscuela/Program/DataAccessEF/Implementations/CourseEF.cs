using DataAccessEF.Helper;
using DataAccessEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Entities
{
    public class CourseEF : IRepository<CourseDTO>
    {
        public void Create(CourseDTO item)
        {
            using (var context = new DemoContext())
            {
                context.Courses.Add(DataConverter.CourseDTOToEntity(item));
                context.SaveChanges();
            }
        }

        public void Delete(int itemId)
        {
            using (var context = new DemoContext())
            {
                var course = context.Courses.Find(itemId);
                context.Courses.Remove(course);
                context.SaveChanges();
            }
        }

        public List<CourseDTO> GetAll()
        {
            List<CourseDTO> resultList = new List<CourseDTO>();
            using (var context = new DemoContext())
            {
                resultList = context.Courses.Select(s => new CourseDTO
                {
                    CourseId = s.CourseId,
                    CourseName = s.CourseName,
                    Credits = s.Credits
                }).ToList();
            }
            return resultList;
        }

        public CourseDTO GetById(int itemId)
        {
            using (var context = new DemoContext())
            {
                var course = context.Courses.Find(itemId);
                return DataConverter.CourseEntityToDTO(course);
            }
        }

        public void Update(CourseDTO item)
        {
            Course result = DataConverter.CourseDTOToEntity(item);

            using (var context = new DemoContext())
            {
                var found = context.Courses.Find(result.CourseId);
                found.CourseName = item.CourseName;
                found.Credits = item.Credits;
                context.SaveChanges();
            }
        }
    }
}
