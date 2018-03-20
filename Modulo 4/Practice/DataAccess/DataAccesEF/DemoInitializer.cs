using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccesEF.Entities;

namespace DataAccesEF
{
    public class DemoInitializer : DropCreateDatabaseAlways<DemoContext>
    {
        protected override void Seed(DemoContext context)
        {
            context.QuestionTypes.Add(new QuestionType { QuestionTypeId = 1, Description = "Si/NO " , CreateDate = DateTime.Now});
            context.QuestionTypes.Add(new QuestionType { QuestionTypeId = 2,  Description = "Abierta ", CreateDate = DateTime.Now });
            context.QuestionTypes.Add(new QuestionType { QuestionTypeId = 3,  Description = "Opcion Multiple", CreateDate = DateTime.Now });

            context.Questions.Add(new Entities.Question { QuestionId = 1, Text = "Cuanto es garnacha ?", QuestionTypeId = 1, IsActive = true, IsRequired = false, CreateDate = DateTime.Now, ModifyDate = DateTime.Now });
            context.Questions.Add(new Entities.Question { QuestionId = 2, Text = "VS CODE or Sublime ?", QuestionTypeId = 2, IsActive = true, IsRequired = false, CreateDate = DateTime.Now, ModifyDate = DateTime.Now });
            context.Questions.Add(new Entities.Question { QuestionId = 3, Text = "GitLab or GitHub ?", QuestionTypeId = 3, IsActive = false, IsRequired = true, CreateDate = DateTime.Now, ModifyDate = DateTime.Now });
            context.Questions.Add(new Entities.Question { QuestionId = 4, Text = "Can i diet to slim my eye lids ?", QuestionTypeId = 1, IsActive = true, IsRequired = false, CreateDate = DateTime.Now, ModifyDate = DateTime.Now });

            context.Options.Add(new Option { OptionId = 1, Text = "YES", CreateDate = DateTime.Now, ModifyDate = DateTime.Now });
            context.Options.Add(new Option { OptionId = 2, Text = "NO", CreateDate = DateTime.Now, ModifyDate = DateTime.Now });
            context.Options.Add(new Option { OptionId = 3, Text = "MAYBE", CreateDate = DateTime.Now, ModifyDate = DateTime.Now });
            context.Options.Add(new Option { OptionId = 3, Text = "I DON'T KNOW", CreateDate = DateTime.Now, ModifyDate = DateTime.Now });
            context.Options.Add(new Option { OptionId = 3, Text = "CAN YOU REPEAT THE QUESTION?", CreateDate = DateTime.Now, ModifyDate = DateTime.Now });

            context.SaveChanges();
        }
    }
}
