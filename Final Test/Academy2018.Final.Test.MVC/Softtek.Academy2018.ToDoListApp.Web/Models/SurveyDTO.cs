using Academy2018.Final.Test.V2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.Models
{
    public class SurveyDTO : Entity
    {
        public SurveyDTO()
        {
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}