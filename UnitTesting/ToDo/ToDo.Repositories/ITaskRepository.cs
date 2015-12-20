using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Entities;

namespace ToDo.Repositories
{
    public interface ITaskRepository
    {
        List<TaskEntity> SelectAll();
        void AddTask(string text);

        // 
        void Delete(int id);


        void Edit(int id);
    }
}