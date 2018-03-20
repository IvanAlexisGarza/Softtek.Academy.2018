using School.DTO;
using School.Entities;
using School.Helper;
using School.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Implementation
{
    public class TeacherEF : IRepository<TeacherDTO>
    {
        public void Add(TeacherDTO item)
        {
            Teacher result = DataConverter.TeacherDTOtOEntity(item);

            using (var context = new DemoContext())
            {
                context.Teachers.Add(result);
                context.SaveChanges();
            }
        }

        public void Delete(int itemId)
        {
            //Soft delete, just deactivate user 
            using (var context = new DemoContext())
            {
                var found = context.Students.Find(itemId);
                found.IsActive = false;
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
                   Names = s.Names,
                   LastName = s.LastName,
                   SecondLastName = s.SecondLastName,
                   TeacherId = s.TeacherId,
                   Email = s.Email,
                   PhoneNumber = s.PhoneNumber,
                   IsActive = s.IsActive
                }).ToList();
            }
            return resultList;
        }

        public TeacherDTO GetById(int itemId)
        {
            TeacherDTO dtoObject;

            using (var context = new DemoContext())
            {
                //QUERYABLE
                //var result = from question in context.Questions where question.QuestionId == id select question; 
                //Regresa un resultado de tipo IQueryable

                //fORMA METODO
                var result = context.Teachers.Where(q => q.TeacherId == itemId).FirstOrDefault();

                //DESPARAMETRIZANDO result
                dtoObject = new TeacherDTO
                {
                    TeacherId = result.TeacherId,
                    Names = result.Names,
                    //Tags = result.Tags.ToList().Select(opt => new TagDTO
                    //{
                    //    TagId = opt.TagId,
                    //    Title = opt.Title
                    //}).ToList()
                };
            }
            return dtoObject;
        }

        public void Update(TeacherDTO item)
        {
            using (var context = new DemoContext())
            {
                var found = context.Teachers.Find(item.TeacherId);
                found.Names = item.Names;
                found.LastName = item.LastName;
                found.SecondLastName = item.SecondLastName;
                found.Email = item.Email;
                found.IsActive = item.IsActive;
                found.PhoneNumber = item.PhoneNumber;
            }
        }
    }
}
