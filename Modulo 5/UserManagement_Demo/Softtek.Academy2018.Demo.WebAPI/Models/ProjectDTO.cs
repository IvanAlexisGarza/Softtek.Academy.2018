using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.Demo.WebAPI.Models
{
    public class ProjectDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Area { get; set; }

        public string TechnologyStack { get; set; }
    }
}