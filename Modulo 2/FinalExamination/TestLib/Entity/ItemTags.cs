using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib.Entity
{
    class TaskTags
    {
        public int TaskId { get; set; }
        public int TagId { get; set; }

        public TaskTags(int taskId, int tagId)
        {
            TaskId = taskId;
            TagId = tagId;
        }
    }
}
