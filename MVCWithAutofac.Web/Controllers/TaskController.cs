using MVCWithAutofac.Core.Interfaces;
using MVCWithAutofac.Core.Model;
using MVCWithAutofac.Web.Filters;
using MVCWithAutofac.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVCWithAutofac.Web.Controllers
{
    public class TaskController : Controller
    {
        private IRepository repo;
        public TaskController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ListTasks model = new ListTasks();
            model.Tasks = repo.GetAll<Tasks>().ToList();
            model.Status = repo.GetAll<TaskStatus>().ToList();
            model.TaskType = repo.GetAll<TaskType>().ToList();
            model.Users = repo.GetAll<User>().ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult InsertTask()
        {
            TaskModel model = new TaskModel();
            model.Task = new Tasks();
            model.Task.TaskDateCreated = System.DateTime.Now.ToShortDateString();
            model.Status = repo.GetAll<TaskStatus>().ToList();
            model.TaskType = repo.GetAll<TaskType>().ToList();
            model.Users = repo.GetAll<User>().ToList();
            return View(model);
        }

        [HttpPost]
        [LogActionFilter]
        public ActionResult InsertTask(TaskModel model)
        {
            model.Task.Name = model.Task.Description;
            model.Status = repo.GetAll<TaskStatus>().ToList();
            model.TaskType = repo.GetAll<TaskType>().ToList();
            model.Users = repo.GetAll<User>().ToList();

            ModelState.Clear();
            TryValidateModel(model);

            if (ModelState.IsValid)
            {
                repo.Insert<Tasks>(model.Task);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult TaskDetails(int id)
        {
            TasksWithCommentsModel model = new TasksWithCommentsModel();
            model.Task = repo.GetById<Tasks>(id);
            model.Status = repo.GetAll<TaskStatus>().ToList();
            model.TaskType = repo.GetAll<TaskType>().ToList();
            model.Users = repo.GetAll<User>().ToList();
            model.Comments = repo.GetAll<Comments>().Where(c=>c.TaskId == model.Task.Id).ToList();
            model.Comment = new Comments();
            model.Comment.TaskId = model.Task.Id;
            model.Comment.CommentDateAdded = System.DateTime.Now.ToShortDateString();
            model.Comment.TaskReminderDate = System.DateTime.Now.ToShortDateString();

            return View(model);
        }

        [HttpGet]
        public ActionResult Search()
        {
            ListTasks model = new ListTasks();
            model.Tasks = repo.GetAll<Tasks>().ToList();
            model.Status = repo.GetAll<TaskStatus>().ToList();
            model.TaskType = repo.GetAll<TaskType>().ToList();
            model.Users = repo.GetAll<User>().ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Search(string searchText)
        {
            ListTasks model = new ListTasks();
            //List of searched Tasks with the required text
            model.Tasks = repo.Search<Tasks>(searchText).ToList();

            model.Status = repo.GetAll<TaskStatus>().ToList();
            model.TaskType = repo.GetAll<TaskType>().ToList();
            model.Users = repo.GetAll<User>().ToList();
            model.searchText = searchText;

            return View(model);
        }

    }
}