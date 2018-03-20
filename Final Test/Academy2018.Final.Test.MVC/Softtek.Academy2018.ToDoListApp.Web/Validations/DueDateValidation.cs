using Softtek.Academy2018.ToDoListApp.Web.Models;
using Softtek.Academy2018.ToDoListApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.Validations
{
    public class DueDateValidation : ValidationAttribute
    {
        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    var item = (ItemViewModel)validationContext.ObjectInstance;

        //    if (item.DueDate < DateTime.Now.AddHours(2))
        //    {
        //        return new ValidationResult("Due ");
        //    }

        //    return ValidationResult.Success;
        //}
    }
}