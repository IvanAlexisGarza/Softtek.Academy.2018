using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Entities;
using School.DTO;

namespace School.Helper
{
    public class DataConverter
    {
        #region Student Converters
        public static Student StudentDTOtOEntity(StudentDTO studentDTO)
        {
            Student result = new Student
            {
                StudentId = studentDTO.StudentId,
                FirstNames = studentDTO.FirstNames,
                LastName = studentDTO.LastName,
                SecondLastName = studentDTO.SecondLastName,
                Email = studentDTO.Email
            };
            return result;
        }

        public static StudentDTO StudentEntityToDTO(Student student)
        {
            StudentDTO result = new StudentDTO
            {
                StudentId = student.StudentId,
                FirstNames = student.FirstNames,
                LastName = student.LastName,
                SecondLastName = student.SecondLastName,
                Age = student.Age,
                Email = student.Email
            };
            return result;
        }
        #endregion

        #region Teacher Converters
        public static Teacher TeacherDTOtOEntity(TeacherDTO teacherDTO)
        {
            Teacher result = new Teacher
            {
                TeacherId = teacherDTO.TeacherId,
                Names = teacherDTO.Names,
                LastName = teacherDTO.LastName,
                SecondLastName = teacherDTO.SecondLastName,
                Email = teacherDTO.Email,
                PhoneNumber = teacherDTO.PhoneNumber
            };
            return result;
        }

        public static TeacherDTO TeacherEntityToDTO(Teacher teacher)
        {
            TeacherDTO result = new TeacherDTO
            {
                TeacherId= teacher.TeacherId,
                Names = teacher.Names,
                LastName = teacher.LastName,
                SecondLastName = teacher.SecondLastName,
                Email = teacher.Email,
                PhoneNumber = teacher.PhoneNumber
            };
            return result;
        }
        #endregion
    }
}
