using Softtek.Academy2018.ToDoListApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academia2018.ToDoListApp.DTO
{
    public class ItemDTO : EntityDTO
    {
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Title must have between 6 and 20 characters")]
        public string Title { get; set; }

        [StringLength(1000,ErrorMessage = "Description must have less than 1000 characters")]
        public string Description { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }

        public bool IsArchived { get; set; }

        public int StatusId { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }
    }
}
