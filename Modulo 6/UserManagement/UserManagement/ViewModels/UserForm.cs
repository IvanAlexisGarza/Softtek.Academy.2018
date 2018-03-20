using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UserManagement.Models;

namespace UserManagement.ViewModels
{
    public class UserForm
    {
        public UserForm()
        {
            Id = 0;
        }

        public UserForm(User user)
        {
            Id = user.Id;
            IS = user.IS;
            FirstName = user.FirstName;
            LastName = user.LastName;
            IsActive = user.IsActive;
            Salary = user.Salary;
            ProjectId = user.ProjectId;
            CreatedDate = user.CreatedDate;
        }

        public IEnumerable<Project> Projects { get; set; }

        public int? Id { get; set; }

        public string IS { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public Double Salary { get; set; }

        [Display(Name = "Project")]
        public int? ProjectId { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}

