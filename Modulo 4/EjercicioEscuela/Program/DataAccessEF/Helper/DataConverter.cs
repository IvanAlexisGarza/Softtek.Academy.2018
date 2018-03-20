using DataAccessEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Helper
{
    public class DataConverter
    {
        #region Teacher Converters
        public static Teacher TeacherDTOToEntity(TeacherDTO entity)
        {
            Teacher result = new Teacher
            {
                TeacherId = entity.TeacherId,
                Names = entity.Names,
                LastName = entity.LastName,
                SecondLastName = entity.SecondLastName,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email
            };

            return result;
        }

        public static TeacherDTO TeacherEntityToDTO(Teacher entity)
        {
            TeacherDTO result = new TeacherDTO
            {
                TeacherId = entity.TeacherId,
                Names = entity.Names,
                LastName = entity.LastName,
                SecondLastName = entity.SecondLastName,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email
            };

            return result;
        }
        #endregion

        #region Student Converters
        public static StudentDTO StudentDTOToEntity(StudentDTO entity)
        {
            StudentDTO result = new StudentDTO
            {
                StudentId = entity.StudentId,
                Names = entity.Names,
                LastName = entity.LastName,
                SecondLastName = entity.SecondLastName,
                Age = entity.Age,
                Email = entity.Email
            };

            return result;
        }

        public static StudentDTO StudentEntityToDTO(StudentDTO entity)
        {
            StudentDTO result = new StudentDTO
            {
                StudentId = entity.StudentId,
                Names = entity.Names,
                LastName = entity.LastName,
                SecondLastName = entity.SecondLastName,
                Age = entity.Age,
                Email = entity.Email
            };

            return result;
        }
        #endregion

        #region Course Converters
        public static Course CourseDTOToEntity(CourseDTO entity)
        {
            Course result = new Course
            {
                CourseId = entity.CourseId,
                CourseName = entity.CourseName,
                Credits = entity.Credits
            };

            return result;
        }

        public static CourseDTO CourseEntityToDTO(Course entity)
        {
            CourseDTO result = new CourseDTO
            {
                CourseId = entity.CourseId,
                CourseName = entity.CourseName,
                Credits = entity.Credits
            };

            return result;
        }
        #endregion

        #region Class Converters
        public static Class ClassDTOToEntity(ClassDTO entity)
        {
            Class result = new Class
            {
                ClassId = entity.ClassId,
                TeacherId = entity.TeacherId,
                CourseId = entity.CourseId,
                Schedule = entity.Schedule
            };

            return result;
        }

        public static ClassDTO ClassEntityToDTO(Class entity)
        {
            ClassDTO result = new ClassDTO
            {
                ClassId = entity.ClassId,
                TeacherId = entity.TeacherId,
                CourseId = entity.CourseId,
                Schedule = entity.Schedule
            };

            return result;
        }
        #endregion

        #region Asignation Converters
        public static Asignation AsignationDTOToEntity(AsignationDTO entity)
        {
            Asignation result = new Asignation
            {
                AsignationId = entity.AsignationId,
                StudentId = entity.StudentId,
                ClassId = entity.ClassId,
                Grade = entity.Grade
            };

            return result;
        }

        public static AsignationDTO AsignationEntityToDTO(Asignation entity)
        {
            AsignationDTO result = new AsignationDTO
            {
                AsignationId = entity.AsignationId,
                StudentId = entity.StudentId,
                ClassId = entity.ClassId,
                Grade = entity.Grade
            };

            return result;
        }
        #endregion

    }
}
