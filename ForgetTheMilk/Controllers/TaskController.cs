using ForgetTheMilk.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ForgetTheMilk.Controllers
{
    public class TaskController : Controller
    {
        public static readonly List<Task> Tasks = new List<Task>();

        public ActionResult Index()
        {
            return View(Tasks);
        }

        [HttpPost]
        public ActionResult Add(string task)
        {
            var newTask = new Task(task);
            Tasks.Add(newTask);
            return RedirectToAction("Index");
        }
    }
}