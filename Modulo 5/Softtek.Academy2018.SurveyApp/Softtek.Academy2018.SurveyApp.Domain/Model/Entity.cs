using System;

namespace Softtek.Academy2018.SurveyApp.Domain.Model
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
