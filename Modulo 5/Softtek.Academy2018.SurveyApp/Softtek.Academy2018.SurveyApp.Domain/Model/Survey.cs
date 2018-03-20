using System.Collections.Generic;

namespace Softtek.Academy2018.SurveyApp.Domain.Model
{
    public class Survey : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsArchived { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Survey()
        {
            Questions = new HashSet<Question>();
        }
    }
}
