using Demo.Data.Context;
using Demo.Data.Contracts;
using Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IPlanRepository _planRepository;

        public StudentRepository(IStudentRepository studentRepository, IPlanRepository planRepository)
        {
            _studentRepository = studentRepository;
            _planRepository = planRepository;
        }

        public int Add(Student item)
        {
            using (var context = new SchoolContext())
            {
                if (item == null)
                {
                    Console.WriteLine("Object Reference is null :(");
                    return -1;
                }

                context.Students.Add(item);
                context.SaveChanges();

                return item.Id;
            }
        }

        public bool Exist(int id)
        {
            using (var context = new SchoolContext())
            {
                Student currentStudent = context.Students.Where(x => x.Id == id).FirstOrDefault();

                if (currentStudent == null) return false;

                return true;
            }
        }

        public ICollection<Student> GetAll()
        {
            using (var context = new SchoolContext())
            {
                return context.Students.ToList();
            }
        }

        public Student GetById(int id)
        {
            using (var context = new SchoolContext())
            {
                Student studentInDb = context.Students.Where(x => x.Id == id).FirstOrDefault();
                if (studentInDb == null)
                {
                    Console.WriteLine("Object does not exist in DataBase");
                    return null;
                }

                return studentInDb;
            }
        }

        public bool Remove(int id)
        {
            using (var context = new SchoolContext())
            {
                Student currentStudent = _studentRepository.GetById(id);
                context.Students.Remove(currentStudent);
                context.SaveChanges();

                if (_studentRepository.Exist(id) == true)
                {
                    Console.WriteLine("Item couldn't be deleted.");
                    return false;
                }
                return true;
            }
        }

        public bool Update(Student item)
        {
            using (var context = new SchoolContext())
            {
                if (!_studentRepository.Exist(item.Id)) return false;

                Student studentInDb = context.Students.Where(x => x.Id == item.Id).FirstOrDefault();
                studentInDb = item;
                context.SaveChanges();
                return true;
            }
        }

        public bool AddPlanToStudent(int studentId, int planId)
        {
            using (var context = new SchoolContext())
            {
                Student studentInDb =  _studentRepository.GetById(studentId);
                Plan planInDb = _planRepository.GetById(planId);

                studentInDb.Plan = planInDb;

                return _studentRepository.Update(studentInDb);
            }
        }
    }
}
