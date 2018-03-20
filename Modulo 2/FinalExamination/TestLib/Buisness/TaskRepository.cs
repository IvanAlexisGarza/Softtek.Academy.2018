using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestLib.Entity;

namespace TestLib.Buisness
{
    public class TaskRepository : IGeneric<STask>
    {

        DateTime inputtedDate;
        bool Flag;

        public TaskRepository()
        {

        }

        private readonly List<STask> STaskList;

        private readonly List<STask> STaskListArchived;

        public TaskRepository(List<STask> stasklist)
        {
            STaskList = stasklist;
        }

        public void AssignDueDate(int id)
        {
            Flag = true;
            do
            {
                Console.Write("Enter a date (e.g. 10/22/1987): ");
                inputtedDate = DateTime.Parse(Console.ReadLine());
                if (inputtedDate < DateTime.Today)
                {
                    Console.WriteLine("Please enter a valid Date");
                    Flag = false;
                }
                else
                {
                    Console.WriteLine("Due Date set to:");
                    Console.WriteLine(inputtedDate.ToString());
                    Flag = true;
                }
            } while (Flag == false);
           // STaskList[id].DueDate = inputtedDate;
        }

        public void AssignPriority(int id)
        {
            Flag = true;
            do
            {
                Console.WriteLine("Please select priority (from 1-10)");
                int priority = Console.Read();
                Console.Read();// VS buffers 13 & 10 :(
                Console.Read();
                priority = priority - '0';
               // Console.WriteLine("Priority is :{0}",priority);
                if (priority > 0 && priority <= 10)
                {
                    Console.WriteLine(" the priority is set to -> {0}", priority);
                    Flag = true;
                    STaskList[id].Priority  = priority;
                }
                else
                {
                    Console.WriteLine("Range not valid.");
                    Flag = false;
                }
            } while (Flag == false);
        }

        public void AssignTag(STask Item, Tag tag)
        {
            if(Item.Tagged.Count() <= 10)
            {
                Item.Tagged.Add(tag);
                Console.WriteLine("Tag Added.");
            }
            else
            {
                Console.WriteLine($" The Task:{Item.Title} Exceed the maximum number of Tags.");
            }
        }

        public void Create(STask item)
        {
            STaskList.Add(item);

            int id = STaskList.Count() - 1;
            //STaskList[id].CreateDate = DateTime.Today;

            Console.WriteLine("{0}",id);

            Modify(item.Id, 1); //modify title

            Modify(item.Id, 2); // Modify Description

            AssignDueDate(id);

            AssignPriority(id);

            STaskList[id].StatusId = Status.New;

            ChangeStatus(id, 1);

        }

        public void ChangeStatus(int id, int status)
        {
            switch(status)
            {
                case 1://Draft    
                    if(STaskList[id].StatusId == Status.New || STaskList[id].StatusId == Status.InProgress)
                    {
                        STaskList[id].StatusId = Status.Draft;
                        Console.WriteLine("Status changed successfully !");
                    }
                    else
                    {
                        Console.WriteLine("You can't change to that status");
                    }
                    break;

                case 2: //New
                    if (STaskList[id].StatusId == Status.Draft)
                    {
                        STaskList[id].StatusId = Status.New;
                        Console.WriteLine("Status changed successfully !");
                    }
                    else
                    {
                        Console.WriteLine("You can't change to that status");
                    }
                    break;

                case 3://InProgress
                    if (STaskList[id].StatusId == Status.New)
                    {
                        STaskList[id].StatusId = Status.InProgress;
                        Console.WriteLine("Status changed successfully !");
                    }
                    else
                    {
                        Console.WriteLine("You can't change to that status");
                    }
                    break;

                case 4://Cancel
                    if (STaskList[id].StatusId == Status.New || STaskList[id].StatusId == Status.InProgress)
                    {
                        STaskList[id].StatusId = Status.Cancel;
                        Console.WriteLine("Status changed successfully !");
                    }
                    else
                    {
                        Console.WriteLine("You can't change to that status");
                    }
                    break;

                case 5://Done
                    if (STaskList[id].StatusId == Status.InProgress)
                    {
                        STaskList[id].StatusId = Status.Done;
                        Console.WriteLine("Status changed successfully !");
                    }
                    else
                    {
                        Console.WriteLine("You can't change to that status");
                    }
                    break;
            }

        }

        public void Modify(int id, int option)
        {

            switch(option)
            {
                case 1://Title
                    {
                        Console.WriteLine("Type in the new Task Title");
                        STaskList[id].Title = Console.ReadLine();
                    }break;

                case 2: //Description
                    {
                        Console.WriteLine("Type in the new Task description");
                        STaskList[id].Description = Console.ReadLine();
                    }break; 
            }
        }

        public void Remove(int id)
        {
            STaskList.Remove(SearchId(id));
        }

        public STask SearchId(int id)
        {
            STask sTask = STaskList.Where(e => e.Id == id).FirstOrDefault();
            return sTask;
        }

        public void Archive(STask item)
        {
            STaskListArchived.Add(item);
            STaskList.Remove(item);
            item.IsArchived = true;
        }

        public List<STask> SearchByTitle(string title)
        {
            return STaskList.Where(e => e.Title.Contains(title)).ToList();
        }

        public List<STask> SearchByStatus(Status status)
        {
            return STaskList.Where(e => e.StatusId == status).ToList();
        }

        public List<STask> SearchByDueDate(DateTime dueDate)
        {
            return STaskList.Where(e => e.DueDate == dueDate).ToList();
        }

        public void SaveToFile(List<STask> taskList)
        {
            using (TextWriter tw = new StreamWriter("Tasks.txt"))
            {
                foreach (STask task in taskList)
                {
                    tw.WriteLine(task.Id + "," +
                                 task.Title + "," +
                                 task.Description + "," +
                                 task.CreateDate + "," +
                                 task.ModifyDate + "," +
                                 task.DueDate + "," +
                                 task.Priority.ToString() + "," +
                                 task.StatusId + "," +
                                 task.IsArchived + "," +
                                 task.Tagged);
                }

            }
        }

        public void ReadFromFile(string fileName)
        {
            List<string> logFile = File.ReadAllLines(fileName).ToList();

            foreach (string line in logFile)
            {
                string[] parameters = line.Split(',');
                Status stat;
                Enum.TryParse(parameters[6], out stat);
                STask newTask = new STask(Convert.ToInt32(parameters[0]),
                                        parameters[1],
                                        parameters[2],
                                        DateTime.Parse(parameters[3]),
                                        DateTime.Parse(parameters[4]),
                                        DateTime.Parse(parameters[5]),
                                        Convert.ToInt32(parameters[6]),
                                        stat,
                                        bool.Parse(parameters[8]),
                                        new List<Tag>());

                STaskList.Add(newTask);
            }
        }
    }
}
