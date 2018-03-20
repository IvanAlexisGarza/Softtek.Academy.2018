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
            context.QuestionTypes.Add(new QuestionType { QuestionTypeId = 1, Description = "Si/NO " });
            context.QuestionTypes.Add(new QuestionType { QuestionTypeId = 2,  Description = "Abierta " });
            context.QuestionTypes.Add(new QuestionType { QuestionTypeId = 3,  Description = "Opcion Multiple" });

            context.Questions.Add(new Entities.Question { QuestionId = 1, Text = "Cuanto es garnacha ?", QuestionTypeId = 1, IsActive = true, IsRequired = false });
            context.Questions.Add(new Entities.Question { QuestionId = 2, Text = "VS CODE or Sublime ?", QuestionTypeId = 2, IsActive = true, IsRequired = false });
            context.Questions.Add(new Entities.Question { QuestionId = 3, Text = "GitLab or GitHub ?", QuestionTypeId = 3, IsActive = false, IsRequired = true });
            context.Questions.Add(new Entities.Question { QuestionId = 4, Text = "Can i diet to slim my eye lids ?", QuestionTypeId = 1, IsActive = true, IsRequired = false });

            context.Options.Add(new Option { OptionId = 1, Text = "YES" });
            context.Options.Add(new Option { OptionId = 2, Text = "NO"});
            context.Options.Add(new Option { OptionId = 3, Text = "MAYBE"});
            context.Options.Add(new Option { OptionId = 3, Text = "I DON'T KNOW" });
            context.Options.Add(new Option { OptionId = 3, Text = "CAN YOU REPEAT THE QUESTION?" });

            context.SaveChanges();
        }
    }
}
