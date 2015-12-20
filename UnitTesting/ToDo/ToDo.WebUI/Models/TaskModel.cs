using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.WebUI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public TaskModel(int id, string title, bool isDone)
        {
            this.Id = id;
            this.Title = title;
            this.IsDone = isDone;
        }
    }
}