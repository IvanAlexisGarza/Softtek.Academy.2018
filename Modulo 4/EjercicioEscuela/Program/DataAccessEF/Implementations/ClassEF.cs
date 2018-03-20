using DataAccessEF.Helper;
using DataAccessEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Entities
{
    public class ClassEF : IRepository<ClassDTO>
    {
        public void Create(ClassDTO item)
        {
            using (var context = new DemoContext())
            {
                context.Classes.Add(DataConverter.ClassDTOToEntity(item));
                context.SaveChanges();
            }
        }

        public void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public List<ClassDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ClassDTO GetById(int itemId)
        {
            ClassDTO dtoObj = new ClassDTO();

            using (var context = new DemoContext())
            {
                var result = from question in context.Classes
                             where question.ClassId == itemId
                             select question;
            }

            return dtoObj;
        }

        public void Update(ClassDTO item)
        {
            Class result = DataConverter.ClassDTOToEntity(item);

            using (var context = new DemoContext())
            {
                var found = context.Classes.Find(result.ClassId);
                found.TeacherId = item.TeacherId;
                found.CourseId = item.CourseId;
                found.Teacher = context.Teachers.FirstOrDefault(t => t.TeacherId == item.TeacherId);
                found.Course = context.Courses.FirstOrDefault(c => c.CourseId == item.CourseId);
                found.Schedule = item.Schedule;
                context.SaveChanges();
            }
        }
    }
}
