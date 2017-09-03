using MVCWithAutofac.Core.Interfaces;
using MVCWithAutofac.Core.Model;
using MVCWithAutofac.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithAutofac.Web.Controllers
{
    public class CommentController : Controller
    {
        private IRepository repo;
        public CommentController(IRepository repo)
        {
            this.repo = repo;
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(Core.Model.Comments comment)
        {
            comment.Name = comment.Description;
            ModelState.Clear();
            TryValidateModel(comment);

            if (ModelState.IsValid)
            {
                Tasks task = repo.GetById<Tasks>(comment.TaskId);
                task.TaskNextActionDate = comment.TaskReminderDate;
                repo.Update<Tasks>(task);
                repo.Insert<Core.Model.Comments>(comment);
                repo.SaveChanges();
            }
            return RedirectToAction("TaskDetails","Task", new { id = comment.TaskId });
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetById<Core.Model.Comments>(id));
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(Core.Model.Comments comment)
        {
            comment.Name = comment.Description;
            repo.Update<Core.Model.Comments>(comment);
            repo.SaveChanges();
            return RedirectToAction("TaskDetails", "Task", new { id = comment.TaskId });
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchText)
        {
            ListTasks model = new ListTasks();
            //List of searched Tasks with the required text
            model.Comments = repo.Search<Comments>(searchText).ToList();

            model.Status = repo.GetAll<TaskStatus>().ToList();
            model.TaskType = repo.GetAll<TaskType>().ToList();
            model.Users = repo.GetAll<User>().ToList();
            model.searchText = searchText;

            return View(model);
        }

    }
}
