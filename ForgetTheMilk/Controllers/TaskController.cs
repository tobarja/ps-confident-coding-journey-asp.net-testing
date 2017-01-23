using System.Collections.Generic;
using System.Web.Mvc;

namespace ForgetTheMilk.Controllers
{
    public class TaskController : Controller
    {
        public static readonly List<string> Tasks = new List<string>();

        public ActionResult Index()
        {
            return View(Tasks);
        }

        [HttpPost]
        public ActionResult Add(string task)
        {
            Tasks.Add(task);
            return RedirectToAction("Index");
        }
    }
}