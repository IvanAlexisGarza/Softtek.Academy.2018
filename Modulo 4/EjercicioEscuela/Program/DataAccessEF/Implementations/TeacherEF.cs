using DataAccessEF.Helper;
using DataAccessEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Entities
{
    public class TeacherEF : IRepository<TeacherDTO>
    {
        public void Create(TeacherDTO item)
        {
            using (var context = new DemoContext())
            {
                context.Teachers.Add(DataConverter.TeacherDTOToEntity(item));
                context.SaveChanges();
            }
        }

        public void Delete(int itemId)
        {
            using (var context = new DemoContext())
            {
                var course = context.Teachers.Find(itemId);
                context.Teachers.Remove(course);
                context.SaveChanges();
            }
        }

        public List<TeacherDTO> GetAll()
        {
            List<TeacherDTO> resultList = new List<TeacherDTO>();
            using (var context = new DemoContext())
            {
                resultList = context.Teachers.Select(s => new TeacherDTO
                {
                    TeacherId = s.TeacherId,
                    Names = s.Names,
                    LastName = s.LastName,
                    SecondLastName = s.SecondLastName,
                    PhoneNumber = s.PhoneNumber,
                    Email = s.Email
                }).ToList();
            }
            return resultList;
        }

        public TeacherDTO GetById(int itemId)
        {
            using (var context = new DemoContext())
            {
                var teacher = context.Teachers.Find(itemId);
                return DataConverter.TeacherEntityToDTO(teacher);
            }
        }

        public void Update(TeacherDTO item)
        {
            Teacher result = DataConverter.TeacherDTOToEntity(item);

            using (var context = new DemoContext())
            {
                var found = context.Teachers.Find(result.TeacherId);
                found.Names = item.Names;
                found.LastName = item.LastName;
                found.SecondLastName = item.SecondLastName;
                found.PhoneNumber = item.PhoneNumber;
                found.Email = item.Email;
                context.SaveChanges();
            }
        }
    }
}
