using Academy2018.Final.Test.V2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy2018.Final.Test.V2.WebAPI2.Models
{
    public class SurveyDTO : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public Status Status { get; set; }
    }
}