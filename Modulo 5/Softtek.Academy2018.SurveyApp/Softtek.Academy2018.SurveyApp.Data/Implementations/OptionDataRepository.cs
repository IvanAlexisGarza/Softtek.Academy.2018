using Softtek.Academy2018.SurveyApp.Data.Contracts;
using Softtek.Academy2018.SurveyApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.SurveyApp.Data.Implementations
{
    class OptionDataRepository : IOptionRepository
    {
        public int Add(Option item)
        {
            if(item == null)
            {
                Console.WriteLine("Can't add option because it's a null value");
                return -1;
            }

            using (var context = new SurveyDBContext())
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                context.Options.Add(item);
                context.SaveChanges();
                return item.Id;
            }
        }

        public bool Delete(Option item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't delete option because it's a null value");
                return false;
            }
            using (var context = new SurveyDBContext())
            {
                context.Options.Remove(item);
                context.SaveChanges();
                return true;
            }
        }

        public bool Exist(int id)
        {
            using (var context = new SurveyDBContext())
            {
                return context.Options.Any(x => x.Id == id);
            }
        }

        public Option Get(int id)
        {
            using (var context = new SurveyDBContext())
            {
                return context.Options.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }

        public bool Update(Option item)
        {
            using (var context = new SurveyDBContext())
            {
                Option currentOption = context.Options.SingleOrDefault(x => x.Id == item.Id);

                if (currentOption == null) return false;

                currentOption.Id = item.Id;
                currentOption.Text = item.Text;
                currentOption.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }
    }
}
