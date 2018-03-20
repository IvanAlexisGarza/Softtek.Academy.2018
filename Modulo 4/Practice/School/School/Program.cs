using School.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Entities;
using School.Interfaces;
using School.Implementation;
using School.DTO;

namespace School
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new DemoContext())
            {
                DemoInitializer Init = new DemoInitializer();
                Init.Filler();
                //IRepository<StudentDTO> studentRepository = new StudentEF();

                //studentRepository.Add(new StudentDTO
                //{
                //    FirstNames = "Luigi",
                //    LastName = "Mario",
                //    Email = "BigPlumber@MarioBros.com",
                //    IsActive = true,
                //    BirthDay = DateTime.Now,
                //    RegistrationDate = DateTime.Now,
                //    DropOut = DateTime.Now,
                //});
                context.SaveChanges();
            }
            
        }
    }
}



/*Crear modelo para la base de datos de una escuela

· Estudiantes(Nombre, apellido, Id, edad, email)
· Maestros(Nombre, apellido, id, teléfono, email)
· Materias(nombre, créditos, id)
· Clases(Id, MaestroId, MateriaId, horario)
· Asignaciones(EstudianteId, ClaseId, Calificacion)

Constraints:
· Los maestros pueden tener mas de una materia
· Una materia solo puede tener un maestro
· Los maestros pueden dar mas de una clase
· Los alumnos pueden estar asignados a mas de una clase

Utilizando Entity Framework:

1. Crear entidades para modelo de clases
2. Crear método Seed con información básica para cada entidad
3. Crear métodos Create, Update, Delete, Get All y GetById para cada entidad
4. Agregar siguientes campos:
a.Fecha de nacimiento a Estudiantes y Maestros
b.Fecha de ingreso a Estudiantes
c.Fecha de contratación a Maestro
d. EstaActivo para Estudiantes y Maestro
e. Fecha de Baja para Estudiantes y Maestros

5. Crear migraciones para agregar campos

6. Actualizar método Delete para que en lugar de borrarlos físicamente los desactive y actualize la fecha de baja.

*/
