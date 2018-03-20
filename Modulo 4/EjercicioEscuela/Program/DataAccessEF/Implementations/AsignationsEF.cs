using DataAccessEF.Helper;
using DataAccessEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Entities
{
    public class AsignationsEF : IRepository<AsignationDTO>
    {
        public void Create(AsignationDTO item)
        {
            using (var context = new DemoContext())
            {
                context.Asignations.Add(DataConverter.AsignationDTOToEntity(item));
                context.SaveChanges();
            }
        }

        public void Delete(int itemId)
        {
            using (var context = new DemoContext())
            {
                var assignation = context.Asignations.Find(itemId);
                context.Asignations.Remove(assignation);
                context.SaveChanges();
            }
        }

        public List<AsignationDTO> GetAll()
        {
            List<AsignationDTO> resultList = new List<AsignationDTO>();
            using (var context = new DemoContext())
            {
                resultList = context.Asignations.Select(s => new AsignationDTO
                {
                    AsignationId = s.AsignationId,
                    StudentId = s.StudentId,
                    ClassId = s.ClassId,
                    Grade = s.Grade
                }).ToList();
            }
            return resultList;
        }

        public AsignationDTO GetById(int itemId)
        {
            using (var context = new DemoContext())
            {
                var asignation = context.Courses.Find(itemId);
                return DataConverter.AsignationEntityToDTO(asignation);
            }
        }

        public void Update(AsignationDTO item)
        {
            Asignation result = DataConverter.AsignationDTOToEntity(item);

            using (var context = new DemoContext())
            {
                var found = context.Asignations.Find(result.AsignationId);
                found.StudentId = item.StudentId;
                found.ClassId = item.ClassId;
                found.Grade = item.Grade;
                context.SaveChanges();
            }
        }
    }
}
