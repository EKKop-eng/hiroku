
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HerokuCrudApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> Records = new List<string>();

        public IActionResult Index()
        {
            return View(Records);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Records.Add(name);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id >= 0 && id < Records.Count)
            {
                ViewBag.Record = Records[id];
                ViewBag.Id = id;
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, string name)
        {
            if (id >= 0 && id < Records.Count && !string.IsNullOrEmpty(name))
            {
                Records[id] = name;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id >= 0 && id < Records.Count)
            {
                Records.RemoveAt(id);
            }
            return RedirectToAction("Index");
        }
    }
}
