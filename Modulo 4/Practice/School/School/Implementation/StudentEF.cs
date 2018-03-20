using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Helper;
using School.Entities;
using School.Interfaces;
using School.DTO;

namespace School.Implementation
{
    public class StudentEF : IRepository<StudentDTO>
    {
        public void Add(StudentDTO item)
        {
            Student result = DataConverter.StudentDTOtOEntity(item);

            using (var context = new DemoContext())
            {
                context.Students.Add(result);
                context.SaveChanges();
            }
        }

        public void Delete(int itemId)
        {
            using (var context = new DemoContext())
            {
                var found = context.Students.Find(itemId);
                found.IsActive = false;
                context.SaveChanges();
            }
        }

        public List<StudentDTO> GetAll()
        {
            List<StudentDTO> resultList = new List<StudentDTO>();
            using (var context = new DemoContext())
            {
                resultList = context.Students.Select(s => new StudentDTO
                {
                    FirstNames = s.FirstNames,
                    LastName = s.LastName,
                    SecondLastName = s.SecondLastName,
                    StudentId = s.StudentId,
                    BirthDay = s.BirthDay,
                    DropOut = s.DropOut,
                    Email = s.Email,
                    IsActive = s.IsActive,
                    Age = s.Age,
                    RegistrationDate = s.RegistrationDate
                }).ToList();
            }
            return resultList;
        }

        public StudentDTO GetById(int itemId)
        {
            using (var context = new DemoContext())
            {
                Student student = new Student();
                StudentDTO studentDTO = new StudentDTO();

                student = context.Students.SingleOrDefault(x => x.StudentId == itemId);

                if (student != null) return studentDTO = DataConverter.StudentEntityToDTO(student);
                return null;
            }

        }

        public void Update(StudentDTO item)
        {
            using (var context = new DemoContext())
            {
                var found = context.Students.Find(item.StudentId);
                found.FirstNames = item.FirstNames;
                found.LastName = item.LastName;
                found.SecondLastName = item.SecondLastName;
                found.IsActive = item.IsActive;
                found.Email = item.Email;
                found.BirthDay = item.BirthDay;
                context.SaveChanges();
            }
        }
    }
}



