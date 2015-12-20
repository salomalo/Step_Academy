using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Entities;

namespace ToDo.Repositories
{
    public class FakeTaskRepository : ITaskRepository
    {
        public static List<TaskEntity> task = new List<TaskEntity>(){
            new TaskEntity(1,"Task 1",true),
            new TaskEntity(2,"Task 2",false),
            new TaskEntity(3,"Task 3",true),
            new TaskEntity(4,"Task 4",false),
            new TaskEntity(5,"Task 5",true)
        };
   
        public List<TaskEntity> SelectAll()
        {
            List<TaskEntity> list = new List<TaskEntity>();

            foreach (var item in task)
            {
                list.Add(item);
            }

            return list;
        }

        public void AddTask(string txtTask)
        {
            #region Validation

            if (string.IsNullOrWhiteSpace(txtTask))
            {
                throw new ArgumentException("Error! The task can not be empty!");
            }
            if (txtTask.Length > 10)
            {
                throw new ArgumentException("Error! The task can not be more 10 symbols!");
            }

            #endregion

            task.Add(new TaskEntity(task.Count + 1, txtTask, true));
        }

        public void Delete(int t)
        {
            task.RemoveAt(t);
        }

        public void Edit(int t)
        {
           // task.;
        }


    }
}