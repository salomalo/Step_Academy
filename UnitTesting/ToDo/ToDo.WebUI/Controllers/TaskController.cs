using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Entities;
using ToDo.Repositories;

namespace ToDo.WebUI.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController()
        {
            this._taskRepository = new FakeTaskRepository();
        }

        //
        // GET: /ToDo/
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Tasks = _taskRepository.SelectAll();
            return View();
        }

        // POST: /ToDo/
        [HttpPost]
        public ActionResult Index(string txtTask)
        {
            if (string.IsNullOrWhiteSpace(txtTask))
            {
                ViewBag.Error = "Error! The task can not be empty!";
            }
            else if (txtTask.Length > 10)
            {
                ViewBag.TaskTitle = txtTask;
                ViewBag.Error = "Error! The task can not be more 10 symbols!";
            }
            else
            {
                _taskRepository.AddTask(txtTask);
            }
            ViewBag.Tasks = _taskRepository.SelectAll();
            return View();
        }



        [HttpPost]
        public ActionResult Delete(int taskId)
        {
            int id = taskId;
            _taskRepository.Delete(id);
            ViewBag.Tasks = _taskRepository.SelectAll();
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int taskId)
        {

     
            ViewBag.Tasks = _taskRepository.SelectAll();
            return View();
        }


    }
}