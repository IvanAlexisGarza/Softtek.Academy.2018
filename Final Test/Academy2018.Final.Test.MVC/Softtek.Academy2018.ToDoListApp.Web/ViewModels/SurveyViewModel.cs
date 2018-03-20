using Softtek.Academy2018.ToDoListApp.Web.Models;
using Softtek.Academy2018.ToDoListApp.Web.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.ViewModels
{
    public class SurveyViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [DisplayName("Question")]
        public int QuestionId { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        public ICollection<QuestionDTO> Questions { get; set; }

        public string Action { get; set; }

        public SurveyViewModel()
        {
            //Id = 0;
            //Action = "Save";
        }

        //public ItemViewModel(Item item)
        //{
        //    Id = item.Id;
        //    Title = item.Title;
        //    Description = item.Description;
        //    StatusId = item.StatusId;
        //    PriorityId = item.PriorityId;
        //    DueDate = item.DueDate;
        //    Action = "Update";
        //}
    }
}