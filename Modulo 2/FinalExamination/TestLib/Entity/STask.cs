using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib.Entity
{
    public class STask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public Status StatusId { get; set; }
        public bool IsArchived { get; set; }
        public List<Tag> Tagged { get; set; }

        public STask(int id, string title, string description, DateTime createDate, DateTime modifyDate, DateTime dueDate, int priority, Status statusId, bool isArchived, List<Tag> tagged)
        {
            Id = id;
            Title = title;
            Description = description;
            CreateDate = createDate;
            ModifyDate = modifyDate;
            DueDate = dueDate;
            Priority = priority;
            StatusId = statusId;
            IsArchived = isArchived;
            Tagged = Tagged;
        }

        public STask(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            CreateDate = DateTime.Now;
            ModifyDate = DateTime.Now;
            DueDate = dueDate;
            Priority = 1;
            StatusId = Status.Draft;
            IsArchived = false;
        }



        //public void NewSTask(int id, string title, string description, DateTime dueDate, int priority)
        //{
        //    this.Id = id;
        //    this.Title = title;
        //    this.Description = description;
        //    this.DueDate = dueDate;
        //    this.Priority = priority;
        //}

        public STask()
        {
        }
    }
}
