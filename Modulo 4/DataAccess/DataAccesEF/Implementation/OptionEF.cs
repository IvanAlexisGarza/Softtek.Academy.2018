using DataAccesEF.Entities;
using DataAccesEF.Helper;
using DataAccess.DTO;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Implementation
{
    public class OptionEF : IRepository<OptionDTO>
    {
        public void Add(OptionDTO entity)
        {
            Option option = DataConverter.OptionDTOToEntity(entity);

            using (var context = new DemoContext())
            {
                context.Options.Add(option);
                context.SaveChanges();
            };
        }

        public int CountItems()
        {
            int count = 0;

            using (var context = new DemoContext())
            {
                count = context.Options.Count();
                context.SaveChanges();
            }

            return count;
        }

        public void Delete(int entityId)
        {
            Option option = new Option();
            using (var context = new DemoContext())
            {
                option = context.Options.Where(x => x.OptionId == entityId).FirstOrDefault();
                context.Options.Remove(option);
            };
        }

        public List<OptionDTO> GetAll()
        {
            List<OptionDTO> optionList = new List<OptionDTO>();
            using (var context = new DemoContext()) 
            {
                optionList = context.Options.Select(x => new OptionDTO
                {
                    OptionId = x.OptionId,
                    Text = x.Text
                }).ToList();
            }

            return optionList;
        }

        public OptionDTO GetById(int entityId)
        {
            OptionDTO result = new OptionDTO();

            using (var context = new DemoContext())
            {
                result = DataConverter.OptionEntityToDTO(context.Options.Where(x => x.OptionId == entityId).FirstOrDefault());
                context.SaveChanges();
            }

            return result;
        }

        public void Update(OptionDTO optionDTO)
        {
            Option result = new Option();
            result = DataConverter.OptionDTOToEntity(optionDTO);

            using (var context = new DemoContext())
            {
                var temp = context.Options.Find(result.OptionId);
                temp.Text = optionDTO.Text;

                context.SaveChanges();
            }
            /*
             *             QuestionType result = DataConverter.QuestionTypeDTOToEntity(entity);

            using (var context = new DemoContext())
            {
                var found = context.QuestionTypes.
                    Find(result.QuestionTypeId);// find puede recibir varios parametros para hacer la busqueda

                found.Description = entity.Description;
                context.SaveChanges();

                // se tien que hacer un mapeo de DTO a la entidad para consultarlo?<-- bueno para algo 
                // se tiene que hacer un mapeo de entidad a DTO y luego subirlo
/*/
        }
    }
}
